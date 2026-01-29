using Terraria;
using V2.PlayerHandling;

namespace V2.UI.StomachCapacityMeter;

public struct PlayerPredStomachCapacitySnapshot
{
	public double Fullness;

	public double CapacityMax;

	public double KickyPreyPercentage;

	private int numCapacitySegments;

	private static readonly int minCapacitySegments = 4;

	private static readonly int maxCapacitySegments = 15;

	public int AmountOfCapacitySegments
	{
		get
		{
			if (numCapacitySegments < minCapacitySegments)
			{
				numCapacitySegments = minCapacitySegments;
			}
			if (numCapacitySegments > maxCapacitySegments)
			{
				numCapacitySegments = maxCapacitySegments;
			}
			return numCapacitySegments;
		}
		set
		{
			numCapacitySegments = value;
		}
	}

	public PlayerPredStomachCapacitySnapshot(Player player)
	{
		Fullness = player.AsPred().StomachFullness;
		CapacityMax = player.AsPred().StomachCapacity;
		if (CapacityMax == -1.0)
		{
			KickyPreyPercentage = player.AsPred().KickyStomachFullness / player.AsPred().StomachFullness;
			numCapacitySegments = 10;
		}
		else
		{
			KickyPreyPercentage = player.AsPred().KickyStomachFullness / CapacityMax;
			numCapacitySegments = (int)(CapacityMax / 0.2);
		}
	}
}
