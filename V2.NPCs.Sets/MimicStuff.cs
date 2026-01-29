using System;
using Terraria;

namespace V2.NPCs.Sets;

public static class MimicStuff
{
	public static Mimic AsMimic(this NPC npc)
	{
		Mimic tastySparklySnack = default(Mimic);
		if (!npc.TryGetGlobalNPC<Mimic>(ref tastySparklySnack))
		{
			throw new Exception("this instance of a gem critter, supposedly, doesn't exist");
		}
		return tastySparklySnack;
	}
}
