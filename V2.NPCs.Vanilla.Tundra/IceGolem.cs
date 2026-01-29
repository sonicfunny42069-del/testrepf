using System;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Intermediate;

namespace V2.NPCs.Vanilla.Tundra;

public class IceGolem : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 243;
	}

	public override void SetDefaults(NPC NPC)
	{
		NPC.AsV2NPC().Gender = EntityGender.Other;
		NPC.AsFood().DefinedBaseSize = 4.18;
		PreyNPC preyNPC = NPC.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantIceGolemGoal));
	}

	public static void OnKilledByDigestion_GrantIceGolemGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatIceGolem>().TrySetCompletion(predPlayer);
		}
	}
}
