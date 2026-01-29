using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Sets;

namespace V2.NPCs.Vanilla.Cavern;

public class RedSlime : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public static void V2RedSlimeFirstFrameAI(NPC npc)
	{
		GeneralizedAIOverrides.SimpleSlimeFirstFrameAI(npc, 18);
	}

	public static bool V2RedSlimeAI(NPC npc)
	{
		return GeneralizedAIOverrides.SimpleSlimeAI(npc, 1.025f, 24, 18);
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
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		if (npc.netID == -8)
		{
			npc.AsV2NPC().Gender = EntityGender.Other;
			npc.AsV2NPC().FirstFramePreAIMethod = V2RedSlimeFirstFrameAI;
			npc.AsV2NPC().NewAIMethod = V2RedSlimeAI;
			npc.AsSlime().JumpSpeed = new Vector2(5f, 3.75f);
			npc.AsSlime().JumpDelayBase = V2Utils.SensibleTime(0, 0, 1, 30);
			npc.AsSlime().JumpDelayExtra = (Min: V2Utils.SensibleTime(), Max: V2Utils.SensibleTime(0, 0, 1, 30));
			npc.AsSlime().OccasionalHighJumps = true;
			npc.AsSlime().HighJumpFrequency = 2;
			SlimeNPC slimeNPC = npc.AsSlime();
			slimeNPC.HighJumpXModifier += 0.5f;
			SlimeNPC slimeNPC2 = npc.AsSlime();
			slimeNPC2.HighJumpYModifier += 1f;
			npc.AsFood().DefinedBaseSize = 0.52;
			npc.AsPred().MaxStomachCapacity = 0.78;
			npc.AsPred().SmallGulpThreshold = 0.0;
			npc.AsPred().BigGulps = null;
			npc.AsPred().CanBeForceFed = CanRedSlimeBeForceFed;
			npc.AsPred().DigestionType = EntityDigestionType.Other;
			npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
			npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
			npc.AsPred().StandardBurps = null;
			npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
			npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
			PreyNPC preyNPC = npc.AsFood();
			preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(SlimeNPC.OnKilledByDigestion_GrantSlimeMultiPreyGoal));
		}
	}

	public static bool CanRedSlimeBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SlimePred.1", "Mods.V2.Death.DigestedPlayer.SlimePred.2", "Mods.V2.Death.DigestedPlayer.SlimePred.3" });
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
		return 1.0 / (double)V2Utils.SensibleTime(0, 15) * (npc.AsFood().DefinedEffectiveSize / npc.AsFood().DefinedBaseSize);
	}
}
