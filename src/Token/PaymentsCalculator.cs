namespace Token;

internal class PaymentsCalculator
{
	public List<Payment> CalculatePayments(BondData data, List<CalculatePeriod> periods)
	{
		List<Payment> payments = new List<Payment>();
		for (var i = 0; i < periods.Count; i++)
		{
			var period = periods[i];
			var daysIsPeriodYear = DateTime.IsLeapYear(period.End.Year) ? 366 : 365;
			double value = period.Days * data.Price * data.InterestRate / 100 / daysIsPeriodYear;

			DateTime paymentDate;
			if (i != periods.Count - 1)
			{
				paymentDate = GetDate(data, period.End);
			}
			else
			{
				paymentDate = data.YieldDate.AddDays(+1);
			}

			payments.Add(new Payment
			{
				Date = paymentDate,
				Period = period,
				Value = value
			});
		}

		return payments;
	}

	private DateTime GetDate(BondData data, DateTime periodEnd)
	{
		var nextMonth = periodEnd.AddMonths(1);
		return new DateTime(nextMonth.Year, nextMonth.Month, data.PaymentDay);
	}
}