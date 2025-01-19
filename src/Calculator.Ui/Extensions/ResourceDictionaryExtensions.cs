using Calculator.Core;
using Calculator.Ui.ViewModels;
using Calculator.Ui.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Ui.Extensions;

internal static class ResourceDictionaryExtensions
{
    internal static IServiceCollection AddUiServices(this IServiceCollection services)
    {
        services.AddSingleton<CalculatorViewModel>();
        services.AddSingleton<CalculatorWindow>();
        return services;
    }

    internal static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<PeriodCalculator>();
        services.AddSingleton<PaymentsCalculator>();
        services.AddSingleton<TokensCalculator>();
        return services;
    }
}