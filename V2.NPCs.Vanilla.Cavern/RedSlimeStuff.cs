using System;
using Terraria;

namespace V2.NPCs.Vanilla.Cavern;

public static class RedSlimeStuff
{
	public static RedSlime AsRedSlime(this NPC npc)
	{
		RedSlime RedSlime = default(RedSlime);
		if (!npc.TryGetGlobalNPC<RedSlime>(ref RedSlime))
		{
			throw new Exception("this instance of a Red Slime, supposedly, doesn't exist");
		}
		return RedSlime;
	}
}
