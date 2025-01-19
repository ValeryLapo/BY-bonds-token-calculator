using System.Globalization;
using Calculator.Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Calculator.Tests;

public class PeriodCalculatorTests
{
    [Theory]
    [InlineData("01.01.2025", "01.01.2025")]
    [InlineData("19.01.2025", "01.01.2025")]
    [InlineData("31.01.2025", "01.01.2025")]
    [InlineData("01.04.2025", "01.04.2025")]
    [InlineData("30.05.2025", "01.04.2025")]
    [InlineData("30.06.2025", "01.04.2025")]
    [InlineData("01.07.2025", "01.07.2025")]
    [InlineData("03.08.2025", "01.07.2025")]
    [InlineData("30.09.2025", "01.07.2025")]
    [InlineData("01.10.2025", "01.10.2025")]
    [InlineData("11.11.2025", "01.10.2025")]
    [InlineData("31.12.2025", "01.10.2025")]

    public void GetQuarterStart_WithValidInput_ReturnsValidQuarterStart(string dateAsString, string assertDateAsString)
    {
        var periodCalculator = new PeriodCalculator();

        DateTime inputDate = DateTime.ParseExact(dateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime quarterStart = periodCalculator.GetQuarterStart(inputDate);
        DateTime assertDate = DateTime.ParseExact(assertDateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        
        Assert.Equal(assertDate, quarterStart);
    }

    [Theory]
    [InlineData("01.01.2025", "31.03.2025")]
    [InlineData("19.01.2025", "31.03.2025")]
    [InlineData("31.01.2025", "31.03.2025")]
    [InlineData("01.04.2025", "30.06.2025")]
    [InlineData("30.05.2025", "30.06.2025")]
    [InlineData("30.06.2025", "30.06.2025")]
    [InlineData("01.07.2025", "30.09.2025")]
    [InlineData("03.08.2025", "30.09.2025")]
    [InlineData("30.09.2025", "30.09.2025")]
    [InlineData("01.10.2025", "31.12.2025")]
    [InlineData("11.11.2025", "31.12.2025")]
    [InlineData("31.12.2025", "31.12.2025")]

    public void GetQuarterEnd_WithValidInput_ReturnsValidQuarterEnd(string dateAsString, string assertDateAsString)
    {
        var periodCalculator = new PeriodCalculator();

        DateTime inputDate = DateTime.ParseExact(dateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        DateTime quarterStart = periodCalculator.GetQuarterEnd(inputDate);
        DateTime assertDate = DateTime.ParseExact(assertDateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        
        Assert.Equal(assertDate, quarterStart);
    }
}