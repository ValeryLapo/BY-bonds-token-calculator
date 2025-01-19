using System.ComponentModel;
using Calculator.Core;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calculator.Ui.ViewModels;

public partial class CalculatorViewModel : ObservableObject, IDisposable
{
    private readonly TokensCalculator _tokensCalculator;

    public CalculatorViewModel(TokensCalculator tokensCalculator)
    {
        _tokensCalculator = tokensCalculator;
        Token = new TokenViewModel();
        Token.PropertyChanged += OnTokenChanged;
    }

    public TokenViewModel Token { get; set; }
    [ObservableProperty] private List<PaymentViewModel> _payments = new ();
    [ObservableProperty] private double _yieldToMaturity;
    public void Dispose()
    {
        Token.PropertyChanged -= OnTokenChanged;
    }

    private void OnTokenChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (!Token.HasErrors)
        {
            RecalculateData();
        }
    }

    public void RecalculateData()
    {
        var tokenData = new Token(Token.ParValue, Token.CouponRate,
            Token.CouponFrequency, Token.PaymentDay, Token.AcquisitionDate, Token.MaturityDate);
        var result = _tokensCalculator.Calculate(tokenData);
        Payments = result.Payments.Select(p => new PaymentViewModel()
        {
            PeriodStart = p.Period.Start,
            PeriodEnd = p.Period.End,
            PayDate = p.Date,
            Value = p.Value
        }).ToList();
        YieldToMaturity = result.YieldToMaturity;

    }

}