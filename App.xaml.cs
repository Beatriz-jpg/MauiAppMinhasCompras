using System.IO;
using MauiAppMinhasCompras.Views;
using Microsoft.Maui.Controls;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public static string DBPath;

        public App()
        {
            InitializeComponent();

            DBPath = Path.Combine(FileSystem.AppDataDirectory, "data.db3");

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(MainPage);
        }
    }
}