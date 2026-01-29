using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Sets;

public class AnyButterfly : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return V2Utils.NPCIDSets.Butterflies.Contains(entity.type);
	}

	public override void SetDefaults(NPC npc)
	{
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsFood().DefinedBaseSize = 0.035;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnSwallowedBy = (PreyNPC.DelegateOnSwallowedBy)Delegate.Combine(preyNPC.OnSwallowedBy, new PreyNPC.DelegateOnSwallowedBy(OnSwallowedBy_GrantButterflyGroupMultiPreyGoal));
	}

	public static void OnSwallowedBy_GrantButterflyGroupMultiPreyGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer == null || predPlayer.AsPred().StomachTracker == null)
		{
			return;
		}
		List<int> butterflies = new List<int>(V2Utils.NPCIDSets.Butterflies);
		int butterfliesInTummy = 0;
		List<PreyData> preyQueue = predPlayer.AsPred().StomachTracker.PreyQueue;
		if (preyQueue == null || preyQueue.Count > 0)
		{
			foreach (PreyData prey in predPlayer.AsPred().StomachTracker.PreyQueue)
			{
				if (prey.Type == PreyType.NPC)
				{
					int preyNPCID = prey.ExactType;
					if (butterflies.Contains(preyNPCID))
					{
						butterfliesInTummy++;
					}
				}
			}
		}
		List<PreyData> prey2 = predPlayer.AsPred().StomachTracker.Prey;
		if (prey2 == null || prey2.Count > 0)
		{
			foreach (PreyData prey3 in predPlayer.AsPred().StomachTracker.Prey)
			{
				if (prey3.Type == PreyType.NPC)
				{
					int preyNPCID2 = prey3.ExactType;
					if (butterflies.Contains(preyNPCID2))
					{
						butterfliesInTummy++;
					}
				}
			}
		}
		if (butterfliesInTummy >= 3)
		{
			ModContent.GetInstance<StomachButterflies>().TrySetCompletion(predPlayer);
		}
	}
}
