using Microsoft.VisualBasic.CompilerServices;

namespace Calculator.Ui.ViewModels;

public class PaymentViewModel
{
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public DateTime PayDate { get; set; }
    public double Value { get; set; }
}