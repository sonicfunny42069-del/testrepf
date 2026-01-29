using System;
using Terraria;

namespace V2.NPCs.Vanilla.Cavern;

public static class YellowSlimeStuff
{
	public static YellowSlime AsYellowSlime(this NPC npc)
	{
		YellowSlime YellowSlime = default(YellowSlime);
		if (!npc.TryGetGlobalNPC<YellowSlime>(ref YellowSlime))
		{
			throw new Exception("this instance of a Yellow Slime, supposedly, doesn't exist");
		}
		return YellowSlime;
	}
}
