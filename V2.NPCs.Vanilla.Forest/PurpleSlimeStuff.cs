using System;
using Terraria;

namespace V2.NPCs.Vanilla.Forest;

public static class PurpleSlimeStuff
{
	public static PurpleSlime AsPurpleSlime(this NPC npc)
	{
		PurpleSlime PurpleSlime = default(PurpleSlime);
		if (!npc.TryGetGlobalNPC<PurpleSlime>(ref PurpleSlime))
		{
			throw new Exception("this instance of a Purple Slime, supposedly, doesn't exist");
		}
		return PurpleSlime;
	}
}
