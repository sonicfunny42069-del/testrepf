using System;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Vanilla.Forest;

public class AngryDandelion : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 628;
	}

	public override void SetDefaults(NPC npc)
	{
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsFood().DefinedBaseSize = 0.475;
		npc.AsFood().OnDigestedBy = PreyNPC.OnKilledByDigestion_GrantLivePreyGoal;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantAngryDandelionGoal));
	}

	public static void OnKilledByDigestion_GrantAngryDandelionGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatAngyFlower>().TrySetCompletion(predPlayer);
		}
	}
}
