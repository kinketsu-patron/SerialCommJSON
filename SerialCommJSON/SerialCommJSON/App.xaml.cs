using Prism.Ioc;
using SerialCommJSON.Views;
using System.Windows;

namespace SerialCommJSON
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell( )
        {
            return Container.Resolve<MainWindow>( );
        }

        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {

        }
    }
}
