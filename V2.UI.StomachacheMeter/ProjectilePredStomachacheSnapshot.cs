using Terraria;
using V2.Projectiles;

namespace V2.UI.StomachacheMeter;

public struct ProjectilePredStomachacheSnapshot
{
	public double Stomachache;

	public double StomachacheMax;

	private int numCapacitySegments;

	private static readonly int minCapacitySegments = 4;

	private static readonly int maxCapacitySegments = 20;

	public int AmountOfStomachacheMeterSegments
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

	public ProjectilePredStomachacheSnapshot(Projectile projectile)
	{
		Stomachache = projectile.AsPred().Stomachache;
		StomachacheMax = projectile.AsPred().StomachacheMeterCapacity;
		if (StomachacheMax == -1.0)
		{
			numCapacitySegments = 5;
		}
		else
		{
			numCapacitySegments = (int)(StomachacheMax / 20.0);
		}
	}
}
