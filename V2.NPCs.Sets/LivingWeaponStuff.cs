using System;
using Terraria;

namespace V2.NPCs.Sets;

public static class LivingWeaponStuff
{
	public static LivingWeapon AsMimic(this NPC npc)
	{
		LivingWeapon greedyLivingWeapon = default(LivingWeapon);
		if (!npc.TryGetGlobalNPC<LivingWeapon>(ref greedyLivingWeapon))
		{
			throw new Exception("this instance of a gem critter, supposedly, doesn't exist");
		}
		return greedyLivingWeapon;
	}
}
