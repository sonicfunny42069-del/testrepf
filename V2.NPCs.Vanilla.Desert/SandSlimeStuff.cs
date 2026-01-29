using System;
using Terraria;

namespace V2.NPCs.Vanilla.Desert;

public static class SandSlimeStuff
{
	public static SandSlime AsSandSlime(this NPC npc)
	{
		SandSlime SandSlime = default(SandSlime);
		if (!npc.TryGetGlobalNPC<SandSlime>(ref SandSlime))
		{
			throw new Exception("this instance of a Sand Slime, supposedly, doesn't exist");
		}
		return SandSlime;
	}
}
