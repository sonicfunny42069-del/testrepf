using System;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Vanilla.Tundra;

public class SnowFlinx : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 185;
	}

	public override void SetDefaults(NPC NPC)
	{
		NPC.AsV2NPC().Gender = EntityGender.Other;
		NPC.AsFood().DefinedBaseSize = 0.72;
		PreyNPC preyNPC = NPC.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantSnowFlinxGoal));
	}

	public static void OnKilledByDigestion_GrantSnowFlinxGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatSnowFlinx>().TrySetCompletion(predPlayer);
		}
	}
}
