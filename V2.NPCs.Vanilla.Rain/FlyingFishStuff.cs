using System;
using Terraria;

namespace V2.NPCs.Vanilla.Rain;

public static class FlyingFishStuff
{
	public static FlyingFish AsFlyingFish(this NPC npc)
	{
		FlyingFish flyingFish = default(FlyingFish);
		if (!npc.TryGetGlobalNPC<FlyingFish>(ref flyingFish))
		{
			throw new Exception("this instance of a Flying Fish, supposedly, doesn't exist");
		}
		return flyingFish;
	}
}
