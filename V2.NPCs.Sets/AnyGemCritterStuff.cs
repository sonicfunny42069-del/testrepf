using System;
using Terraria;

namespace V2.NPCs.Sets;

public static class AnyGemCritterStuff
{
	public static AnyButterfly AsGemCritter(this NPC npc)
	{
		AnyButterfly tastySparklySnack = default(AnyButterfly);
		if (!npc.TryGetGlobalNPC<AnyButterfly>(ref tastySparklySnack))
		{
			throw new Exception("this instance of a gem critter, supposedly, doesn't exist");
		}
		return tastySparklySnack;
	}
}
