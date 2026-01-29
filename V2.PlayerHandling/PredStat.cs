namespace V2.PlayerHandling;

public class PredStat
{
	public int Spent { get; set; }

	public int Base { get; set; }

	public int Extra { get; set; }

	public int Total => Spent + Base + Extra;

	public PredStat()
	{
		Spent = 0;
		Base = 0;
		Extra = 0;
	}

	public void Reset()
	{
		Spent = 0;
		Base = 0;
		Extra = 0;
	}
}
