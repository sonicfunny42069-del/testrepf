using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Charms;
using V2.PlayerHandling.PredPlayerGoals.Amateur;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.Cavern;

public class Nymph : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		int type = entity.type;
		if ((uint)(type - 195) <= 1u)
		{
			return true;
		}
		return false;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.AsFood().DefinedBaseSize = 1.04;
		npc.AsPred().MaxStomachCapacity = 5.5;
		npc.AsPred().BaseStomachacheMeterCapacity = 275.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.5;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(4.7);
		npc.AsPred().CanBeForceFed = CanNymphBeForceFed;
		npc.AsPred().OnForceFed = OnNymphForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 0.65;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantNymphGoal));
		PreyNPC preyNPC2 = npc.AsFood();
		int num = 3;
		List<ItemTheftRule> list = new List<ItemTheftRule>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<ItemTheftRule> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = NymphStuff.ItemTheftRules.NymphHairStrands;
		num2++;
		span[num2] = NymphStuff.ItemTheftRules.MetalDetector;
		num2++;
		span[num2] = NymphStuff.ItemTheftRules.FatassCharm;
		num2++;
		preyNPC2.ItemTheftRules = list;
	}

	public static bool CanNymphBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnNymphForceFed(NPC npc, Player player)
	{
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Cavern.Nymph.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Cavern.Nymph.2" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Cavern.Nymph.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 1.4;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 22.0;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 1, 15);
	}

	public static void OnKilledByDigestion_GrantNymphGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatNymph>().TrySetCompletion(predPlayer);
		}
	}

	public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0033: Expected O, but got Unknown
		//IL_0033: Expected O, but got Unknown
		((NPCLoot)(ref npcLoot)).Add((IItemDropRule)(object)new V2CommonDropRules.DifficultyScalingDrop((IItemDropRule)new CommonDrop(ModContent.ItemType<CharmFatass>(), 10, 1, 1, 1), (IItemDropRule)new CommonDrop(ModContent.ItemType<CharmFatass>(), 20, 1, 1, 3), (IItemDropRule)new CommonDrop(ModContent.ItemType<CharmFatass>(), 5, 1, 1, 1)));
	}
}
