using System;
using Terraria;

namespace V2.NPCs.Sets;

public static class MiniFairyStuff
{
	public static MiniFairy AsMiniFairy(this NPC npc)
	{
		MiniFairy tastySparklySnack = default(MiniFairy);
		if (!npc.TryGetGlobalNPC<MiniFairy>(ref tastySparklySnack))
		{
			throw new Exception("this instance of a gem critter, supposedly, doesn't exist");
		}
		return tastySparklySnack;
	}
}
