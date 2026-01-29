using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Charms;
using V2.NPCs.Voraria.TownNPCs.Enigma;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.Crimson;

public class CrimsonAxe : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public static List<(TargetType, int, TargetPriorityLevel)> Diet => new List<(TargetType, int, TargetPriorityLevel)>
	{
		(TargetType.NPC, 22, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 17, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 18, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 38, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 207, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 633, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 20, TargetPriorityLevel.Neutral),
		(TargetType.NPC, ModContent.NPCType<LucindaBound>(), TargetPriorityLevel.Neutral),
		(TargetType.NPC, ModContent.NPCType<Lucinda>(), TargetPriorityLevel.Neutral),
		(TargetType.NPC, 227, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 589, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 588, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 19, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 368, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 579, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 550, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 354, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 353, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 54, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 123, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 124, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 208, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 106, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 108, TargetPriorityLevel.Neutral),
		(TargetType.NPC, ModContent.NPCType<CloverBound>(), TargetPriorityLevel.Neutral),
		(TargetType.NPC, ModContent.NPCType<Clover>(), TargetPriorityLevel.Neutral),
		(TargetType.NPC, 441, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 229, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 178, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 209, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 663, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 213, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 215, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 214, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 212, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 216, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 195, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 196, TargetPriorityLevel.Neutral),
		(TargetType.NPC, 75, TargetPriorityLevel.High),
		(TargetType.NPC, 86, TargetPriorityLevel.High),
		(TargetType.NPC, 122, TargetPriorityLevel.High),
		(TargetType.NPC, 244, TargetPriorityLevel.High),
		(TargetType.NPC, 527, TargetPriorityLevel.High),
		(TargetType.NPC, 171, TargetPriorityLevel.High),
		(TargetType.NPC, 545, TargetPriorityLevel.High),
		(TargetType.NPC, 475, TargetPriorityLevel.VeryHigh),
		(TargetType.NPC, 528, TargetPriorityLevel.High),
		(TargetType.NPC, 84, TargetPriorityLevel.Favorite),
		(TargetType.Player, -1, TargetPriorityLevel.Neutral)
	};

	public static bool V2CrimsonAxeAI(NPC npc)
	{
		npc.noGravity = true;
		npc.ai[3] += 1f;
		if (npc.ai[3] > 15f)
		{
			npc.ai[3] = 0f;
		}
		Entity targetEntity = null;
		npc.TryFindNewTarget(Diet);
		npc.TryVerifyRemainingTarget(Diet);
		if (npc.target != -1)
		{
			targetEntity = (Entity)(npc.AsV2NPC().TargetType switch
			{
				TargetType.Player => Main.player[npc.target], 
				TargetType.NPC => Main.npc[npc.target], 
				TargetType.Projectile => Main.projectile[npc.target], 
				_ => null, 
			});
		}
		if (npc.AsV2NPC().BehaviorPattern != null)
		{
			npc.AsV2NPC().BehaviorPattern.DoBehavior(npc, targetEntity);
		}
		else
		{
			npc.SwitchToPattern<CrimsonAxeAI.Idle>(targetEntity);
		}
		return false;
	}

	public static void VanillaCrimsonAxeAI(NPC npc)
	{
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		npc.noGravity = true;
		npc.noTileCollide = true;
		Lighting.AddLight((int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f), (int)((((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f), 0.3f, 0.15f, 0.05f);
		if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
		{
			npc.TargetClosest(true);
		}
		Player targetPlayer = Main.player[npc.target];
		if (npc.ai[0] == 0f)
		{
			Vector2 vector37 = default(Vector2);
			((Vector2)(ref vector37))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
			float num336 = ((Entity)targetPlayer).position.X + (float)(((Entity)targetPlayer).width / 2) - vector37.X;
			float num337 = ((Entity)targetPlayer).position.Y + (float)(((Entity)targetPlayer).height / 2) - vector37.Y;
			float num338 = (float)Math.Sqrt(num336 * num336 + num337 * num337);
			num338 = 9f / num338;
			num336 *= num338;
			num337 *= num338;
			((Entity)npc).velocity.X = num336;
			((Entity)npc).velocity.Y = num337;
			npc.rotation = (float)Math.Atan2(((Entity)npc).velocity.Y, ((Entity)npc).velocity.X) + 0.785f;
			npc.ai[0] = 1f;
			npc.ai[1] = 0f;
			npc.netUpdate = true;
			return;
		}
		if (npc.ai[0] == 1f)
		{
			if (npc.justHit)
			{
				npc.ai[0] = 2f;
				npc.ai[1] = 0f;
			}
			((Entity)npc).velocity = ((Entity)npc).velocity * 0.99f;
			npc.ai[1] += 1f;
			if (npc.ai[1] >= 100f)
			{
				npc.netUpdate = true;
				npc.ai[0] = 2f;
				npc.ai[1] = 0f;
				((Entity)npc).velocity.X = 0f;
				((Entity)npc).velocity.Y = 0f;
			}
			else
			{
				npc.rotation = (float)Math.Atan2(((Entity)npc).velocity.Y, ((Entity)npc).velocity.X) + 0.785f;
			}
			return;
		}
		if (npc.justHit)
		{
			npc.ai[0] = 2f;
			npc.ai[1] = 0f;
		}
		((Entity)npc).velocity = ((Entity)npc).velocity * 0.96f;
		npc.ai[1] += 1f;
		float num340 = npc.ai[1] / 120f;
		num340 = 0.1f + num340 * 0.4f;
		npc.rotation += num340 * (float)((Entity)npc).direction;
		if (npc.ai[1] >= 120f)
		{
			npc.netUpdate = true;
			npc.ai[0] = 0f;
			npc.ai[1] = 0f;
		}
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return false;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 179;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.AsFood().DefinedBaseSize = 1.04;
		npc.AsPred().MaxStomachCapacity = 5.5;
		npc.AsPred().BaseStomachacheMeterCapacity = 275.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.5;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(4.7);
		npc.AsPred().CanBeForceFed = CanCrimsonAxeBeForceFed;
		npc.AsPred().OnForceFed = OnCrimsonAxeForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().SmallBurps = null;
		npc.AsPred().SmallBurpThreshold = 0.5;
		npc.AsPred().StandardBurps = null;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		PreyNPC preyNPC = npc.AsFood();
		int num = 1;
		List<ItemTheftRule> list = new List<ItemTheftRule>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<ItemTheftRule> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = CrimsonAxeStuff.ItemTheftRules.Crimtane;
		num2++;
		preyNPC.ItemTheftRules = list;
	}

	public static bool CanCrimsonAxeBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnCrimsonAxeForceFed(NPC npc, Player player)
	{
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Crimson.CrimsonAxe.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Crimson.CrimsonAxe.2" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Crimson.CrimsonAxe.Hardcore");
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
