using Microsoft.Extensions.Configuration;
using Ninject;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.UI.Controls.Fragments;
using Notes.UI.Controls.Views;
using Notes.UI.Windows;
using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace Notes.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Config { get; set; }

        public UserDto User { get; set; }

        private IKernel Kernel { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoadStyles();

            Start();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureDependencies();

            base.OnStartup(e);
        }

        private void ConfigureDependencies()
        {
            string b = Environment.CurrentDirectory;
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory + "/../../")
                .AddJsonFile("appsettings.json");

            Config = configBuilder.Build();

            Kernel = new StandardKernel();

            RegisterWindows(Kernel);
            RegisterControls(Kernel);
        }

        private void RegisterWindows(IKernel kernel)
        {
            kernel.Bind<MainWindow>().To<MainWindow>();
        }

        private void RegisterControls(IKernel kernel)
        {
            kernel.Bind<DashboardView>().To<DashboardView>();
            kernel.Bind<NoteFragment>().To<NoteFragment>();
        }

        private void Start()
        {
            MainWindow window = Kernel.Get<MainWindow>();
            window.Show();
        }

        private void LoadStyles()
        {
            // Load a custom styles file if it exists
            string currentAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string assembly = Path.GetFileNameWithoutExtension(currentAssembly);
            string stylesBaseFile = Path.Combine(Path.GetDirectoryName(currentAssembly), "..\\..\\", assembly + ".Styles");
            string stylesFile = stylesBaseFile + ".xml";

            if (!File.Exists(stylesFile))
            {
                stylesFile = stylesBaseFile + ".Default.xaml";
            }

            if (!File.Exists(stylesFile))
            {
                return;
            }

            try
            {
                using (Stream stream = new FileStream(stylesFile, FileMode.Open, FileAccess.Read))
                {
                    ResourceDictionary resources = (ResourceDictionary)XamlReader.Load(stream);
                    Resources.MergedDictionaries.Add(resources);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load styles file '{stylesFile}'.\n{ex.Message}");
            }
        }
    }
}
