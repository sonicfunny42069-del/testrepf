using System;
using Terraria;

namespace V2.NPCs.Sets;

public static class AnyGoldCritterStuff
{
	public static AnyGoldCritter AsAGoldCritter(this NPC npc)
	{
		AnyGoldCritter tastySparklySnack = default(AnyGoldCritter);
		if (!npc.TryGetGlobalNPC<AnyGoldCritter>(ref tastySparklySnack))
		{
			throw new Exception("this instance of a gold critter, supposedly, doesn't exist");
		}
		return tastySparklySnack;
	}
}
