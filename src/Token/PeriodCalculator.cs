namespace Calculator.Core;

public class PeriodCalculator
{
	public List<HoldingPeriod> GetPeriods(Token data)
	{
		List<HoldingPeriod> periods = data.CouponFrequency switch
		{
			CouponFrequency.Month=> CalculateMonthly(data),
            CouponFrequency.Quoter=> CalculateQuarterly(data),
			_ => throw new ArgumentOutOfRangeException()
		};
		return periods;
	}

	private List<HoldingPeriod> CalculateQuarterly(Token data)
	{
		var periods = new List<HoldingPeriod>();
        var firstPeriod = new HoldingPeriod(data.AcquisitionDate, GetQuarterEnd(data.AcquisitionDate));
		periods.Add(firstPeriod);

		var currentDate = data.AcquisitionDate;
		while (true)
		{
			currentDate = currentDate.AddMonths(3);

            var period = new HoldingPeriod(GetQuarterStart(currentDate), GetQuarterEnd(currentDate));

			if (period.End > data.MaturityDate)
			{
                period = new HoldingPeriod(GetQuarterStart(currentDate), data.MaturityDate);
				periods.Add(period);
				break;
			}

			periods.Add(period);
		}

		
		return periods;
	}

	

	private List<HoldingPeriod> CalculateMonthly(Token data)
	{
		var periods = new List<HoldingPeriod>();

        var firstPeriod = new HoldingPeriod(data.AcquisitionDate, new DateTime(data.AcquisitionDate.Year,
            data.AcquisitionDate.Month,
            DateTime.DaysInMonth(data.AcquisitionDate.Year, data.AcquisitionDate.Month)));
		periods.Add(firstPeriod);
		var currentDate = data.AcquisitionDate;
		while (currentDate < data.MaturityDate)
		{
			currentDate = currentDate.AddMonths(1);

            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var period = new HoldingPeriod(startDate,
                new DateTime(currentDate.Year, currentDate.Month,
                    DateTime.DaysInMonth(currentDate.Year, currentDate.Month)));
			if (period.End > data.MaturityDate)
			{
                period = new HoldingPeriod(startDate, data.MaturityDate);
				periods.Add(period);
				break;
			}

			periods.Add(period);


		}
		return periods;
	}
    public DateTime GetQuarterStart(DateTime date)
    {
        int quarter = (date.Month -1) / 3 + 1;
        DateTime start = new DateTime(date.Year, (quarter - 1) * 3 + 1, 1);
		return start;
    }
    public DateTime GetQuarterEnd(DateTime date)
	{
        int quarter = (date.Month -1) / 3 + 1;
        DateTime quarterStart = GetQuarterStart(date);
        return quarterStart.AddMonths(3).AddDays(-1);
	}
}