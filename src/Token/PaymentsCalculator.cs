namespace Calculator.Core;

public class PaymentsCalculator
{
	public List<Payment> CalculatePayments(Token data, List<HoldingPeriod> periods)
	{
		List<Payment> payments = new List<Payment>();
		for (var i = 0; i < periods.Count; i++)
		{
			var period = periods[i];
			var daysIsPeriodYear = DateTime.IsLeapYear(period.End.Year) ? 366 : 365;
			double value = period.Days * data.ParValue * data.CouponRate/ 100 / daysIsPeriodYear;

			DateTime paymentDate;
			if (i != periods.Count - 1)
			{
				paymentDate = GetDate(data, period.End);
			}
			else
			{
				paymentDate = data.MaturityDate.AddDays(+1);
			}

            payments.Add(new Payment(period, paymentDate, value));
		}

		return payments;
	}

	private DateTime GetDate(Token data, DateTime periodEnd)
	{
		var nextMonth = periodEnd.AddMonths(1);
		return new DateTime(nextMonth.Year, nextMonth.Month, data.PaymentDay);
	}
}