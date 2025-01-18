namespace Token;

public class BondData
{
	public int Price { get; set; }
	public double InterestRate { get; set; }
	public Period Period { get; set; }
	public int PaymentDay { get; set; }
	public DateTime BuyDate { get; set; }
	public DateTime YieldDate { get; set; }
}

public class SecondaryBondData : BondData
{
	public double BuyPrice { get; set; }
	public double CommissionRate { get; set; } = 0.005;
	public double Commission => BuyPrice * CommissionRate;
}

public enum Period
{
	Month,
	Quarter
}