using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Consumables.Catchables;
using V2.NPCs.Sets;
using V2.PlayerHandling.PredPlayerGoals.Beginner;

namespace V2.NPCs.Vanilla.Forest;

public class Pinky : GlobalNPC
{
	public static int DigestedHeal => 40;

	public static int EatenHappyLength => V2Utils.SensibleTime(0, 0, 35);

	public static int DigestedRegenTime => V2Utils.SensibleTime(0, 0, 15);

	public override bool InstancePerEntity => true;

	public static bool V2PinkyAI(NPC npc)
	{
		return GeneralizedAIOverrides.SimpleSlimeAI(npc, 0.6f, 14, 10);
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 1;
	}

	public override void SetDefaultsFromNetId(NPC npc)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (npc.netID == -4)
		{
			npc.catchItem = ModContent.ItemType<CaughtPinky>();
			npc.AsV2NPC().Gender = EntityGender.Other;
			npc.AsV2NPC().NewAIMethod = V2PinkyAI;
			npc.AsSlime().JumpSpeed = new Vector2(5f, 8f);
			npc.AsSlime().JumpDelayBase = V2Utils.SensibleTime(0, 0, 0, 30);
			npc.AsSlime().JumpDelayExtra = (Min: V2Utils.SensibleTime(), Max: V2Utils.SensibleTime(0, 0, 0, 10));
			npc.AsSlime().OccasionalHighJumps = false;
			npc.AsFood().DefinedBaseSize = 0.1;
			npc.AsPred().MaxStomachCapacity = 0.15;
			npc.AsPred().SmallGulpThreshold = 0.0;
			npc.AsPred().BigGulps = null;
			npc.AsPred().CanBeForceFed = CanCottonCandySlimeBeForceFed;
			npc.AsPred().DigestionType = EntityDigestionType.Acidic;
			npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
			npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
			npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
			npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
			PreyNPC preyNPC = npc.AsFood();
			preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantPinkyGoal));
			PreyNPC preyNPC2 = npc.AsFood();
			preyNPC2.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC2.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(SlimeNPC.OnKilledByDigestion_GrantSlimeMultiPreyGoal));
		}
	}

	public override bool? CanBeCaughtBy(NPC npc, Item item, Player player)
	{
		if (npc.netID != -4)
		{
			return null;
		}
		return true;
	}

	public static bool CanCottonCandySlimeBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SlimePred.1", "Mods.V2.Death.DigestedPlayer.SlimePred.2", "Mods.V2.Death.DigestedPlayer.SlimePred.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Forest.Pinky.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Forest.Pinky.2" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Forest.Pinky.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 0.65;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 4.0 * (npc.AsFood().DefinedEffectiveSize / npc.AsFood().DefinedBaseSize);
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 15);
	}

	public static void OnKilledByDigestion_GrantPinkyGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatPinky>().TrySetCompletion(predPlayer);
		}
	}
}
