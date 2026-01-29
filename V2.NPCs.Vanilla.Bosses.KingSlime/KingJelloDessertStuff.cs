using System;
using Terraria;

namespace V2.NPCs.Vanilla.Bosses.KingSlime;

public static class KingJelloDessertStuff
{
	public static class ItemTheftRules
	{
	}

	public static KingJelloDessert AsKingSlime(this NPC npc)
	{
		KingJelloDessert unreasonablyThickFairy = default(KingJelloDessert);
		if (!npc.TryGetGlobalNPC<KingJelloDessert>(ref unreasonablyThickFairy))
		{
			throw new Exception("this instance of the King Slime, sadly, can't be pred or prey. no monstrously large jell-o dessert for you, I guess");
		}
		return unreasonablyThickFairy;
	}
}
