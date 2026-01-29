using System;
using Terraria;

namespace V2.NPCs.Vanilla.Desert;

public static class SandElementalStuff
{
	public static SandElemental AsSandElemental(this NPC npc)
	{
		SandElemental sandElemental = default(SandElemental);
		if (!npc.TryGetGlobalNPC<SandElemental>(ref sandElemental))
		{
			throw new Exception("this instance of a SandElemental, supposedly, doesn't exist");
		}
		return sandElemental;
	}
}
