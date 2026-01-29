using Terraria;
using V2.NPCs;

namespace V2.UI.StomachacheMeter;

public struct NPCPredStomachacheSnapshot
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

	public NPCPredStomachacheSnapshot(NPC npc)
	{
		Stomachache = npc.AsPred().Stomachache;
		StomachacheMax = npc.AsPred().StomachacheMeterCapacity;
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
