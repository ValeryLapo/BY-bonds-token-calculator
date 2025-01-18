namespace Token;

public class CalculatePeriod
{
	public DateTime Start { get; set; }
	public DateTime End { get; set; }
	public int Days => (End - Start).Days + 1;
}