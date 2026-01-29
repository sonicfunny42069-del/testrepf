using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Sets;

namespace V2.NPCs.Vanilla.Forest;

public class BlueSlime : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public static void V2BlueSlimeFirstFrameAI(NPC npc)
	{
		GeneralizedAIOverrides.SimpleSlimeFirstFrameAI(npc, 18);
	}

	public static bool V2BlueSlimeAI(NPC npc)
	{
		return GeneralizedAIOverrides.SimpleSlimeAI(npc, 1f, 24, 18);
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 1;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsV2NPC().FirstFramePreAIMethod = V2BlueSlimeFirstFrameAI;
		npc.AsV2NPC().NewAIMethod = V2BlueSlimeAI;
		npc.AsSlime().JumpSpeed = new Vector2(3f, 3.5f);
		npc.AsSlime().JumpDelayBase = V2Utils.SensibleTime(0, 0, 2, 20);
		npc.AsSlime().JumpDelayExtra = (Min: V2Utils.SensibleTime(0, 0, 0, 10), Max: V2Utils.SensibleTime(0, 0, 0, 40));
		npc.AsSlime().OccasionalHighJumps = false;
		npc.AsFood().DefinedBaseSize = 0.5;
		npc.AsPred().MaxStomachCapacity = 0.75;
		npc.AsPred().SmallGulpThreshold = 0.0;
		npc.AsPred().BigGulps = null;
		npc.AsPred().CanBeForceFed = CanBlueSlimeBeForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Other;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().StandardBurps = null;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(SlimeNPC.OnKilledByDigestion_GrantSlimeMultiPreyGoal));
	}

	public static bool CanBlueSlimeBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Mods.V2.Death.DigestedPlayer.SlimePred.1", "Mods.V2.Death.DigestedPlayer.SlimePred.2", "Mods.V2.Death.DigestedPlayer.SlimePred.3" }));
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
