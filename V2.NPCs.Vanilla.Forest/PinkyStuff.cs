using System;
using Terraria;

namespace V2.NPCs.Vanilla.Forest;

public static class PinkyStuff
{
	public static Pinky AsPinky(this NPC npc)
	{
		Pinky cottonCandySlime = default(Pinky);
		if (!npc.TryGetGlobalNPC<Pinky>(ref cottonCandySlime))
		{
			throw new Exception("this instance of Pinky, supposedly, doesn't exist");
		}
		return cottonCandySlime;
	}
}
