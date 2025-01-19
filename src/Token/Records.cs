namespace Calculator.Core;

public record Token(
    double ParValue,
    double CouponRate,
    CouponFrequency CouponFrequency,
    int PaymentDay,
    DateTime AcquisitionDate,
    DateTime MaturityDate);

public record TokenSecondaryData(
    double ParValue,
    double CouponRate,
    CouponFrequency CouponFrequency,
    int PaymentDay,
    DateTime AcquisitionDate,
    double AcquisitionPrice,
    double AcquisitionFeeRate,
    DateTime MaturityDate) : Token(ParValue, CouponRate, CouponFrequency, PaymentDay, AcquisitionDate, MaturityDate)
{
    public double Fee => AcquisitionPrice * AcquisitionFeeRate;
}

public record HoldingPeriod(DateTime Start, DateTime End)
{
    public int Days => (End - Start).Days + 1;
}

public record Payment(HoldingPeriod Period, DateTime Date, double Value);

public record InvestResult(List<Payment> Payments, double YieldToMaturity);

public enum CouponFrequency
{
    Month, Quoter
}