using System;
using Terraria;

namespace V2.NPCs.Vanilla.Forest;

public static class GreenSlimeStuff
{
	public static GreenSlime AsGreenSlime(this NPC npc)
	{
		GreenSlime GreenSlime = default(GreenSlime);
		if (!npc.TryGetGlobalNPC<GreenSlime>(ref GreenSlime))
		{
			throw new Exception("this instance of a Green Slime, supposedly, doesn't exist");
		}
		return GreenSlime;
	}
}
