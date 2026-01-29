using System;
using Terraria;

namespace V2.NPCs.Vanilla.Ocean;

public static class SquidStuff
{
	public static Squid AsSquid(this NPC npc)
	{
		Squid squid = default(Squid);
		if (!npc.TryGetGlobalNPC<Squid>(ref squid))
		{
			throw new Exception("this instance of a Squid, supposedly, doesn't exist");
		}
		return squid;
	}
}
