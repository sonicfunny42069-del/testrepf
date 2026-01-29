using System;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Sets;

public class MiniFairy : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return V2Utils.NPCIDSets.MiniFairies.Contains(entity.type);
	}

	public override void SetDefaults(NPC npc)
	{
		npc.AsV2NPC().Gender = ((!Utils.NextBool(Main.rand)) ? EntityGender.Female : EntityGender.Male);
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnDigestedBy_GrantMiniFairyGoal));
	}

	public static void OnDigestedBy_GrantMiniFairyGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null && !(npc.ai[2] <= 1f))
		{
			ModContent.GetInstance<EatHelpfulFairy>().TrySetCompletion(predPlayer);
		}
	}
}
