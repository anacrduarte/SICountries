using System.Windows;

namespace CountryWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsShuttingDown { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IsShuttingDown = false;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            IsShuttingDown = true;
            base.OnExit(e);
        }


    }

}
