using System;
using Terraria;

namespace V2.NPCs.Vanilla.Hallow;

public static class PrismaticLacewingStuff
{
	public static PrismaticLacewing AsPrismaticLacewing(this NPC npc)
	{
		PrismaticLacewing lacewing = default(PrismaticLacewing);
		if (!npc.TryGetGlobalNPC<PrismaticLacewing>(ref lacewing))
		{
			throw new Exception("this instance of a Prismatic Lacewing, supposedly, doesn't exist");
		}
		return lacewing;
	}
}
