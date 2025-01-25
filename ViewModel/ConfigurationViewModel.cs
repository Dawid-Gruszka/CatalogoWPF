using System.Diagnostics;
using System.Globalization;
using System.Windows;
using CatálogoDeProductos.Properties;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatálogoDeProductos.ViewModel
{
    partial class ConfigurationViewModel : ObservableObject
    {
        [RelayCommand]
        private void EnglishCommand() => EnglishLanguage();
        [RelayCommand]
        private void SpanishCommand() => SpanishLanguage();

        private void SpanishLanguage()
        {
            Settings.Default.Language = "es";
            MessageBox.Show("Idioma cambiado a Español" +
                "\nLa aplicacion se va a reiniciar para ver los cambios");
            Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void EnglishLanguage()
        {
            Settings.Default.Language = "en";
            MessageBox.Show("Language changed to English" +
            "\nThe application is going to restart to see changes");
            Settings.Default.Save();
            Application.Current.Shutdown();
        }
    }
}
