using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Sets;

namespace V2.NPCs.Vanilla.Tundra;

public class IceSlime : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public static void V2IceSlimeFirstFrameAI(NPC npc)
	{
		GeneralizedAIOverrides.SimpleSlimeFirstFrameAI(npc, 18);
	}

	public static bool V2IceSlimeAI(NPC npc)
	{
		return GeneralizedAIOverrides.SimpleSlimeAI(npc, 1f, 24, 18);
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 147;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsV2NPC().FirstFramePreAIMethod = V2IceSlimeFirstFrameAI;
		npc.AsV2NPC().NewAIMethod = V2IceSlimeAI;
		npc.AsSlime().JumpSpeed = new Vector2(0.75f, 5.5f);
		npc.AsSlime().JumpDelayBase = V2Utils.SensibleTime(0, 0, 1, 10);
		npc.AsSlime().JumpDelayExtra = (Min: V2Utils.SensibleTime(), Max: V2Utils.SensibleTime(0, 0, 0, 10));
		npc.AsSlime().OccasionalHighJumps = true;
		npc.AsSlime().HighJumpFrequency = 4;
		SlimeNPC slimeNPC = npc.AsSlime();
		slimeNPC.HighJumpXModifier += 4f;
		SlimeNPC slimeNPC2 = npc.AsSlime();
		slimeNPC2.HighJumpYModifier *= 2f / 3f;
		npc.AsFood().DefinedBaseSize = 0.5;
		npc.AsPred().MaxStomachCapacity = 0.75;
		npc.AsPred().SmallGulpThreshold = 0.0;
		npc.AsPred().BigGulps = null;
		npc.AsPred().CanBeForceFed = CanIceSlimeBeForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Other;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().StandardBurps = null;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(SlimeNPC.OnKilledByDigestion_GrantSlimeMultiPreyGoal));
	}

	public static bool CanIceSlimeBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SlimePred.1", "Mods.V2.Death.DigestedPlayer.SlimePred.2", "Mods.V2.Death.DigestedPlayer.SlimePred.3" });
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 0.5;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 12.0 * (npc.AsFood().DefinedEffectiveSize / npc.AsFood().DefinedBaseSize);
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 20) * (npc.AsFood().DefinedEffectiveSize / npc.AsFood().DefinedBaseSize);
	}
}
