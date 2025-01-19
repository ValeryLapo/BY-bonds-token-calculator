using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Calculator.Core;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Calculator.Ui.ViewModels;


public partial class TokenViewModel : ObservableValidator
{
    [NotifyDataErrorInfo]
    [Required]
    [ObservableProperty] 
    private double _parValue;
    [NotifyDataErrorInfo]
    [Required]
    [ObservableProperty] 
    private double _couponRate;
    [NotifyDataErrorInfo]
    [Required]
    [ObservableProperty] 
    private int _paymentDay;
    [NotifyDataErrorInfo]
    [Required]
    [ObservableProperty] 
    private CouponFrequency _couponFrequency;
    [NotifyDataErrorInfo]
    [Required]
    [ObservableProperty] 
    private DateTime _acquisitionDate;
    [NotifyDataErrorInfo]
    [Required]
    [ObservableProperty] 
    private DateTime _maturityDate;
    
}