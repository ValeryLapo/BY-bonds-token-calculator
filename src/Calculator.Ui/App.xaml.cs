using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using Calculator.Ui.Extensions;
using Calculator.Ui.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SetRuCulture();

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddUiServices()
                .AddCoreServices()
                .BuildServiceProvider();

            var window = serviceProvider.GetRequiredService<CalculatorWindow>();
            window.Show();
        }

        private static void SetRuCulture()
        {
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
