using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using Notes.Security.Authentication;
using System.Security.Principal;
using Notes.Data.Infrastructure;
using Notes.Data.Implementation;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Notes.Data.Model.Users;
using Ninject;
using AutoMapper;
using Notes.BusinessObjects.DataTransferObjects.Users;

namespace Notes.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private string Secret = "JcR3IzwJTOQeQgFEEM7ODZAx6W8qdNDq5y17NEpCoG8hhBFVYDIuwWLgaQNx";
        private int SaltLength = 16;
        private int ExpireMinutes = 10;

        private static string UserName = null;
        private static string UserPasswordHash = null;

        private Func<User, bool> IsValidUser = e => (e != null && !e.IsRemoved && !e.IsSystemOnly && e.Name == UserName);
        private Func<User, bool> IsValidUserWithPasswordHash = e => (e != null && !e.IsRemoved && !e.IsSystemOnly && e.Name == UserName && e.PasswordHash == UserPasswordHash);

        private IDbContext Context { get; set; }
        
        [Inject]
        public AuthenticationService(IDbContext Context)
        {
            this.Context = Context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public UserDto Authenticate(string name, string passwordOrHash, string salt = null)
        {
            User user = GetUserEntity(name, passwordOrHash, salt);

            if (!CheckUser(user))
            {
                throw new Exception($"No valid user {name} exists with the given password");
            }
            
            user.Token = GenerateToken(user.Name);

            NotesPrincipal principal = Thread.CurrentPrincipal as NotesPrincipal;

            if (principal == null)
            {
                throw new Exception($"Unable to login as {name}");
            }

            return Mapper.Map<UserDto>(user);
        }

        public UserDto Register(string name, string passwordOrHash, string salt = null)
        {
            User user = GetUserEntity(name, passwordOrHash, salt);

            user = ((NotesContext)Context).Users.Add(user);

            if (user == null)
            {
                throw new Exception("Couldn't add user, maybe username is taken? lol idk glhfdd");
            }

            Context.SaveChanges();

            if (!CheckUser(user))
            {
                throw new Exception("User should have been added, but it either wasn't found, was 'removed,' or is invalid");
            }

            user.Token = GenerateToken(user.Name);

            NotesPrincipal principal = Thread.CurrentPrincipal as NotesPrincipal;

            if (principal == null)
            {
                throw new Exception("User should have been registered and valid, but was unable to login automatically... Maybe try to login manually?");
            }
            
            return Mapper.Map<UserDto>(user);
        }

        public UserDto Ping(string token)
        {
            if (ValidateToken(token, out string name))
            {
                UserName = name;

                User user = ((NotesContext)Context).Users.DefaultIfEmpty(null).SingleOrDefault(IsValidUser);

                user.Token = token;

                if (user == null)
                {
                    throw new Exception("No valid user associated with a valid session for the given token");
                }

                SetThreadPrincipal(new NotesPrincipal
                {
                    Identity = new NotesIdentity(user.Name, user.OrganizationRoles?.Select(e => e.OrganizationRole.Role.Name).ToList() ?? new List<string>())
                });

                return Mapper.Map<UserDto>(user);
            }
            else
            {
                throw new Exception("No valid session associated with this token");
            }
        }

        private void SetThreadPrincipal(IPrincipal principal)
        {

            Thread.CurrentPrincipal = principal;
        }

        private User GetUserEntity(string name, string passwordOrHash, string salt = null)
        {
            try
            {
                UserName = name;

                User dbUser = ((NotesContext)Context).Users.DefaultIfEmpty(null).SingleOrDefault(IsValidUser);

                if (string.IsNullOrEmpty(salt))
                {
                    HashAlgorithm hashAlgorithm = new SHA512Managed();

                    byte[] saltValue = new byte[SaltLength];

                    if (dbUser == null)
                    {
                        using (var random = new RNGCryptoServiceProvider())
                        {
                            random.GetNonZeroBytes(saltValue);
                        }

                        salt = Convert.ToBase64String(saltValue);
                    }
                    else
                    {
                        salt = dbUser.PasswordSalt;
                    }

                    string passwordWithSalt = string.Format("{0}{1}", passwordOrHash, salt);

                    string hash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt)));

                    passwordOrHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(string.Format("{0}{1}", hash, salt))));
                }

                User user = new User
                {
                    Name = name,
                    PasswordHash = passwordOrHash,
                    PasswordSalt = salt
                };

                SetThreadPrincipal(new NotesPrincipal
                {
                    Identity = new NotesIdentity(user.Name, user.OrganizationRoles?.Select(e => e.OrganizationRole.Role.Name).ToList() ?? new List<string>())
                });

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool CheckUser(User user)
        {
            UserName = user.Name;
            UserPasswordHash = user.PasswordHash;
            return ((NotesContext)Context).Users.Any(IsValidUserWithPasswordHash);
        }

        private string GenerateToken(string username)
        {
            byte[] symmetricKey = Convert.FromBase64String(Secret);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            DateTime now = DateTime.UtcNow;
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Name, username)
                    }),

                Expires = now.AddMinutes(Convert.ToInt32(ExpireMinutes)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken stoken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(stoken);

            return token;
        }

        private bool ValidateToken(string token, out string name)
        {
            name = null;

            var principal = GetPrincipal(token);
            var identity = principal.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            name = usernameClaim?.Value;

            if (string.IsNullOrEmpty(name))
                return false;

            UserName = name;

            return ((NotesContext)Context).Users.Any(IsValidUser);
        }

        private IPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                byte[] symmetricKey = Convert.FromBase64String(Secret);

                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }

            catch (Exception)
            {
                //should write log
                return null;
            }
        }
    }
}
