using Newtonsoft.Json;
using Notes.BusinessObjects.WebApiModels;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notes.UI.Apis
{
    public static class NotesApi
    {
        private static readonly string BaseUrl = $"{((App)Application.Current).Config.GetSection("api:notes:baseUrl").Value}api/";

        private static readonly string Secret = "JcR3IzwJTOQeQgFEEM7ODZAx6W8qdNDq5y17NEpCoG8hhBFVYDIuwWLgaQNx";

        private static string Token { get; set; }

        private static int SaltLength = 16;

        public static void SetToken(string token)
        {
            Token = token;
        }

        public static IRestResponse<T> Execute<T>(string apiPath, Method method, dynamic body = null) where T : new()
        {
            RestClient client = new RestClient();

            client.BaseUrl = new Uri(BaseUrl);

            RestRequest request = new RestRequest(apiPath, method) { RequestFormat = RestSharp.DataFormat.Json };

            request.JsonSerializer = new RestSharpJsonNetSerializer();

            if (Token != null)
            {
                request.AddHeader("Authorization", $"Bearer {Token}");
            }

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            return client.Execute<T>(request);
        }

        public static T GetData<T>(IRestResponse<T> response) where T : new()
        {
            if (response.StatusCode == 0)
            {
                throw new Exception(response.ErrorException.Message);
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ExceptionModel exceptionModel = JsonConvert.DeserializeObject<ExceptionModel>(response.Content);
                throw new Exception(exceptionModel.Message);
            }

            T result = response.Data;

            return result;
        } 

        public static AuthenticationModel GetAuthenticationModel(string username, string password, string salt = null)
        {
            HashAlgorithm hashAlgorithm = new SHA512Managed();

            if (string.IsNullOrEmpty(salt))
            {
                try
                {
                    IRestResponse<AuthenticationModel> response = NotesApi.Execute<AuthenticationModel>($"Authentication/Salt/{username}", Method.GET);
                    salt = JsonConvert.DeserializeObject<AuthenticationModel>(response.Content).PasswordSalt;
                }
                catch { }

                if (string.IsNullOrEmpty(salt))
                {
                    byte[] saltValue = new byte[SaltLength];

                    using (var random = new RNGCryptoServiceProvider())
                    {
                        random.GetNonZeroBytes(saltValue);
                    }

                    salt = Convert.ToBase64String(saltValue);
                }
            }

            string passwordWithSalt = string.Format("{0}{1}", password, salt);

            string hash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt)));

            string passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}{1}", hash, salt))));

            return new AuthenticationModel
            {
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = salt
            };
        }

        /// <summary>
        /// Default JSON serializer for request bodies
        /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
        /// </summary>
        private class RestSharpJsonNetSerializer : ISerializer
        {
            private readonly Newtonsoft.Json.JsonSerializer _serializer;

            /// <summary>
            /// Default serializer
            /// </summary>
            public RestSharpJsonNetSerializer()
            {
                ContentType = "application/json";
                _serializer = new Newtonsoft.Json.JsonSerializer
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include,
                    DefaultValueHandling = DefaultValueHandling.Include
                };
            }

            /// <summary>
            /// Default serializer with overload for allowing custom Json.NET settings
            /// </summary>
            public RestSharpJsonNetSerializer(Newtonsoft.Json.JsonSerializer serializer)
            {
                ContentType = "application/json";
                _serializer = serializer;
            }

            /// <summary>
            /// Serialize the object as JSON
            /// </summary>
            /// <param name="obj">Object to serialize
            /// <returns>JSON as String</returns>
            public string Serialize(object obj)
            {
                using (var stringWriter = new StringWriter())
                {
                    using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                    {
                        jsonTextWriter.Formatting = Formatting.Indented;
                        jsonTextWriter.QuoteChar = '"';

                        _serializer.Serialize(jsonTextWriter, obj);

                        var result = stringWriter.ToString();
                        return result;
                    }
                }
            }

            /// <summary>
            /// Unused for JSON Serialization
            /// </summary>
            public string DateFormat { get; set; }
            /// <summary>
            /// Unused for JSON Serialization
            /// </summary>
            public string RootElement { get; set; }
            /// <summary>
            /// Unused for JSON Serialization
            /// </summary>
            public string Namespace { get; set; }
            /// <summary>
            /// Content type for serialized content
            /// </summary>
            public string ContentType { get; set; }
        }
    }
}
