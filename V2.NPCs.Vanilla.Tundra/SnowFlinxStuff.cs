using System;
using Terraria;

namespace V2.NPCs.Vanilla.Tundra;

public static class SnowFlinxStuff
{
	public static SnowFlinx AsSnowFlinx(this NPC npc)
	{
		SnowFlinx snowFlinx = default(SnowFlinx);
		if (!npc.TryGetGlobalNPC<SnowFlinx>(ref snowFlinx))
		{
			throw new Exception("this instance of a Snow Flinx, supposedly, doesn't exist");
		}
		return snowFlinx;
	}
}
