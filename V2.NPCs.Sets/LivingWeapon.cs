using System;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Intermediate;

namespace V2.NPCs.Sets;

public class LivingWeapon : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return V2Utils.NPCIDSets.LivingWeapons.Contains(entity.type);
	}

	public override void SetDefaults(NPC npc)
	{
		npc.AsV2NPC().Gender = EntityGender.Other;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnDigestedBy_GrantLivingWeaponGoal));
	}

	public static void OnDigestedBy_GrantLivingWeaponGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatMimic>().TrySetCompletion(predPlayer);
		}
	}
}
