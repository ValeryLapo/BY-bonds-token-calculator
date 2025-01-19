using System.Globalization;
using Microsoft.VisualBasic;

namespace Calculator.Core;

public class TokensCalculator(PeriodCalculator periodCalculator, PaymentsCalculator paymentCalculator)
{
	public InvestResult Calculate(Token token)
	{
		var periodCalculator = new PeriodCalculator();
		var paymentCalculator = new PaymentsCalculator();
		var periods = periodCalculator.GetPeriods(token);
		var payments = paymentCalculator.CalculatePayments(token, periods);

		var totalPayments = payments.Sum(p => p.Value);
		var totalDays = (payments.Last().Period.End - payments.First().Period.Start).Days;
		var yieldToMaturity = Math.Pow((totalPayments + token.ParValue) / token.ParValue, 365d / totalDays) - 1;
        return new InvestResult(payments, yieldToMaturity);
    }

	internal static void CalculateSecond()
	{
		//var tokenData = ReadInputData();

		//var periodCalculator = new PeriodCalculator();
		//var paymentCalculator = new PaymentsCalculator();
		//var periods = periodCalculator.GetPeriods(tokenData);
		//var payments = paymentCalculator.CalculatePayments(tokenData, periods);

		//var totalPayments = 0d;
		//foreach (var payment in payments)
		//{
		//	totalPayments += payment.Value;
		//	Console.WriteLine($"{payment.Period.Start:dd.MM.yyyy} - {payment.Period.End:dd.MM.yyyy}. Будет выплачено {payment.Value:F2} {payment.Date:dd.MM.yyyy}");
		//}

		//var totalDays = (payments.Last().Period.End - payments.First().Period.Start).Days;

		//var yearProfit = Math.Pow((tokenData.ParValue + totalPayments) / (tokenData.AcquisitionPrice + tokenData.Fee), 365d / totalDays) - 1;
		//Console.WriteLine($"Годовой доход: {yearProfit:p}");
	}

}