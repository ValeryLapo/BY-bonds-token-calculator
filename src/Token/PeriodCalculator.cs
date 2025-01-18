namespace Token;

internal class PeriodCalculator
{
	public List<CalculatePeriod> GetPeriods(BondData data)
	{
		List<CalculatePeriod> periods = data.Period switch
		{
			Period.Month => CalculateMonthly(data),
			Period.Quarter => CalculateQuarterly(data),
			_ => throw new ArgumentOutOfRangeException()
		};
		return periods;
	}

	private List<CalculatePeriod> CalculateQuarterly(BondData data)
	{
		var periods = new List<CalculatePeriod>();

		var firstPeriod = new CalculatePeriod()
		{
			Start = data.BuyDate,
			End = GetQuarterEnd(data.BuyDate),
		};
		periods.Add(firstPeriod);

		var currentDate = data.BuyDate;
		while (true)
		{
			currentDate = currentDate.AddMonths(3);

			var period = new CalculatePeriod()
			{
				Start = GetQuarterStart(currentDate),
				End = GetQuarterEnd(currentDate)
			};
			if (period.End > data.YieldDate)
			{
				period.End = data.YieldDate;
				periods.Add(period);
				break;
			}

			periods.Add(period);
		}

		
		return periods;
	}

	private DateTime GetQuarterStart(DateTime date)
	{
		switch (date.Month)
		{
			case 1 or 2 or 3:
				return new DateTime(date.Year, 1, 1);
			case 4 or 5 or 6:
				return new DateTime(date.Year, 4, 1);
			case 7 or 8 or 9:
				return new DateTime(date.Year, 7, 1);
			case 10 or 11 or 12:
				return new DateTime(date.Year, 10, 1);
		}

		throw new Exception("Unreal");
	}

	private List<CalculatePeriod> CalculateMonthly(BondData data)
	{
		var periods = new List<CalculatePeriod>();

		var firstPeriod = new CalculatePeriod()
		{
			Start = data.BuyDate,
			End = new DateTime(data.BuyDate.Year, data.BuyDate.Month,
				DateTime.DaysInMonth(data.BuyDate.Year, data.BuyDate.Month)),
		};
		periods.Add(firstPeriod);
		var currentDate = data.BuyDate;
		while (currentDate < data.YieldDate)
		{
			currentDate = currentDate.AddMonths(1);

			var period = new CalculatePeriod()
			{
				Start = new DateTime(currentDate.Year, currentDate.Month, 1),
				End = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month))
			};
			if (period.End > data.YieldDate)
			{
				period.End = data.YieldDate;
				periods.Add(period);
				break;
			}

			periods.Add(period);


		}
		return periods;
	}
	private DateTime GetQuarterEnd(DateTime date)
	{
		switch (date.Month)
		{
			case 1 or 2 or 3:
				return new DateTime(date.Year, 3, 31);
			case 4 or 5 or 6:
				return new DateTime(date.Year, 6, 30);
			case 7 or 8 or 9:
				return new DateTime(date.Year, 9, 30);
			case 10 or 11 or 12:
				return new DateTime(date.Year, 12, 31);
		}

		throw new Exception("Unreal");
	}
}