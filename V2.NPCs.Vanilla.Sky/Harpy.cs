using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using V2.Core;
using V2.Items.Voraria.Consumables;
using V2.NPCs.Voraria.TownNPCs.Enigma;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling.PredPlayerGoals.Amateur;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.Sky;

public class Harpy : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public int WingFlapTimer { get; set; }

	public int DirectionChangeTimer { get; set; }

	public float BellyWeightFlightMovementModifier { get; set; }

	public static List<(TargetType, int, TargetPriorityLevel)> Diet
	{
		get
		{
			int num = 42;
			List<(TargetType, int, TargetPriorityLevel)> list = new List<(TargetType, int, TargetPriorityLevel)>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<(TargetType, int, TargetPriorityLevel)> span = CollectionsMarshal.AsSpan(list);
			int num2 = 0;
			span[num2] = (TargetType.NPC, 22, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 17, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 18, TargetPriorityLevel.Favorite);
			num2++;
			span[num2] = (TargetType.NPC, 38, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 207, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 633, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 20, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, ModContent.NPCType<LucindaBound>(), TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, ModContent.NPCType<Lucinda>(), TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 227, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 589, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 588, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 19, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 368, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 579, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 550, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 354, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 353, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 54, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 123, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 124, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 208, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 106, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 108, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, ModContent.NPCType<CloverBound>(), TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, ModContent.NPCType<Clover>(), TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 441, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 229, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 178, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 209, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 663, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.NPC, 213, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 215, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 214, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 212, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 216, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 529, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 528, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 195, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.NPC, 196, TargetPriorityLevel.Neutral);
			num2++;
			span[num2] = (TargetType.Projectile, 895, TargetPriorityLevel.High);
			num2++;
			span[num2] = (TargetType.Player, -1, TargetPriorityLevel.Neutral);
			num2++;
			return list;
		}
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 48;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.aiStyle = -1;
		npc.AsV2NPC().NewAIMethod = V2HarpyAI;
		npc.AsV2NPC().TargetRange = V2Utils.TileCountAsPixelCount(48.0);
		npc.AsV2NPC().TargetRequiresLineOfSight = true;
		npc.AsFood().DefinedBaseSize = 1.335;
		npc.AsPred().MaxStomachCapacity = 1.9;
		npc.AsPred().BaseStomachacheMeterCapacity = 250.0;
		npc.AsPred().WeightGainRatio = 0.15;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.35;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(4.7);
		npc.AsPred().CanBeForceFed = CanHarpyBeForceFed;
		npc.AsPred().OnForceFed = OnHarpyForceFed;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		npc.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 0.35;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantHarpyGoal));
		PreyNPC preyNPC2 = npc.AsFood();
		int num = 1;
		List<ItemTheftRule> list = new List<ItemTheftRule>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<ItemTheftRule> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = HarpyStuff.ItemTheftRules.GiantHarpyFeather;
		num2++;
		preyNPC2.ItemTheftRules = list;
	}

	public override void OnSpawn(NPC npc, IEntitySource source)
	{
		((Entity)npc).direction = Utils.ToDirectionInt(Utils.NextBool(Main.rand));
		((Entity)npc).position.Y -= 12f;
		npc.target = -1;
		npc.AsV2NPC().TargetType = TargetType.None;
		npc.AsHarpy().WingFlapTimer = Main.rand.Next(-4, 71);
		npc.AsHarpy().DirectionChangeTimer = -Main.rand.Next(V2Utils.SensibleTime(0, 0, 2), V2Utils.SensibleTime(0, 0, 4) + 1);
		npc.AsV2NPC().BehaviorPattern = new HarpyAI.MainFlying();
		WeightedRandom<double> preSetWeight = new WeightedRandom<double>(Main.rand);
		preSetWeight.Add(0.0, 13.0);
		preSetWeight.Add(0.1, 6.0);
		preSetWeight.Add(0.5, 1.0);
		npc.AsPred().ExtraWeight = WeightedRandom<double>.op_Implicit(preSetWeight);
	}

	public static bool V2HarpyAI(NPC npc)
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
			npc.SwitchToPattern<HarpyAI.MainFlying>(targetEntity);
		}
		return false;
	}

	public static bool CanHarpyBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnHarpyForceFed(NPC npc, Player player)
	{
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Sky.Harpy.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Sky.Harpy.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Sky.Harpy.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Sky.Harpy.4", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Sky.Harpy.5" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Sky.Harpy.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 1.25;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 18.0;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 2, 30);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 6);
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		npc.frame.X = 90 * GetVisualBellySize(npc);
		if (npc.AsV2NPC().BehaviorPattern is HarpyAI.DiveBombing)
		{
			npc.frame.Y = 500;
			return;
		}
		if (npc.AsV2NPC().BehaviorPattern is HarpyAI.ChargingDiveBomb)
		{
			npc.spriteDirection = (((Entity)npc).direction = Utils.ToDirectionInt(((Entity)(npc.AsV2NPC().TargetType switch
			{
				TargetType.Player => Main.player[npc.target], 
				TargetType.NPC => Main.npc[npc.target], 
				TargetType.Projectile => Main.projectile[npc.target], 
				_ => null, 
			})).position.X >= ((Entity)(object)npc).TrueCenter().X));
		}
		_ = npc.frame;
		int i = WingFlapTimer;
		int y;
		if (i < 0)
		{
			y = 200;
		}
		else
		{
			int i2 = i;
			if (i2 >= 0 && i2 < 5)
			{
				y = 300;
			}
			else
			{
				int i3 = i;
				y = ((i3 >= 5 && i3 < 10) ? 400 : 0);
			}
		}
		npc.frame.Y = y;
		if (npc.frame.Y == 0 && npc.ai[3] > 7f)
		{
			npc.frame.Y = 100;
		}
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(Math.Sqrt(8.0) * Math.Sqrt(npc.AsPred().ExtraWeight)), 4);
	}

	public static void OnKilledByDigestion_GrantHarpyGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<EatHarpy>().TrySetCompletion(predPlayer);
		}
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		if (npc.AsV2NPC().BehaviorPattern is HarpyAI.ChargingDiveBomb)
		{
			npc.spriteDirection = (((Entity)npc).direction = Utils.ToDirectionInt(((Entity)(npc.AsV2NPC().TargetType switch
			{
				TargetType.Player => Main.player[npc.target], 
				TargetType.NPC => Main.npc[npc.target], 
				TargetType.Projectile => Main.projectile[npc.target], 
				_ => null, 
			})).position.X >= ((Entity)(object)npc).TrueCenter().X));
		}
		Vector2 Offset = default(Vector2);
		((Vector2)(ref Offset))._002Ector(-24f, -12f);
		if (((Entity)npc).direction == 1)
		{
			((Vector2)(ref Offset))._002Ector(-36f, -12f);
		}
		SpriteEffects spriteEffects = (SpriteEffects)(((Entity)npc).direction == 1);
		int weightStage = npc.AsPred().GetVisualWeightStage(npc);
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(npc.frame.X, npc.frame.Y, 90, 100);
		Texture2D sprite = ModContent.Request<Texture2D>("V2/NPCs/Vanilla/Sky/Harpy_Weight" + weightStage, (AssetRequestMode)2).Value;
		spriteBatch.Draw(sprite, ((Entity)npc).position - Main.screenPosition, (Rectangle?)sourceRect, drawColor, npc.rotation, -Offset, 1f, spriteEffects, 0f);
		return false;
	}

	public override void SaveData(NPC npc, TagCompound tag)
	{
		tag["BehaviorPattern"] = "Main Flying";
	}

	public override void LoadData(NPC npc, TagCompound tag)
	{
		npc.AsV2NPC().BehaviorPattern = new HarpyAI.MainFlying();
	}

	public override void PostAI(NPC npc)
	{
		npc.DoContactGulpage(Diet);
	}

	public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a6: Expected O, but got Unknown
		//IL_00a6: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0159: Expected O, but got Unknown
		//IL_0159: Expected O, but got Unknown
		((NPCLoot)(ref npcLoot)).RemoveWhere((Predicate<IItemDropRule>)delegate(IItemDropRule x)
		{
			CommonDropNotScalingWithLuck val = (CommonDropNotScalingWithLuck)(object)((x is CommonDropNotScalingWithLuck) ? x : null);
			return val != null && ((CommonDrop)val).itemId == 320;
		}, true);
		((NPCLoot)(ref npcLoot)).RemoveWhere((Predicate<IItemDropRule>)delegate(IItemDropRule x)
		{
			CommonDrop val = (CommonDrop)(object)((x is CommonDrop) ? x : null);
			return val != null && val.itemId == 1516;
		}, true);
		((NPCLoot)(ref npcLoot)).RemoveWhere((Predicate<IItemDropRule>)delegate(IItemDropRule x)
		{
			ItemDropWithConditionRule val = (ItemDropWithConditionRule)(object)((x is ItemDropWithConditionRule) ? x : null);
			return val != null && ((CommonDrop)val).itemId == 4016;
		}, true);
		((NPCLoot)(ref npcLoot)).Add((IItemDropRule)(object)new V2CommonDropRules.DifficultyScalingDrop((IItemDropRule)new CommonDrop(320, 1, 1, 3, 1), (IItemDropRule)new CommonDrop(320, 1, 2, 3, 1), (IItemDropRule)new CommonDrop(320, 1, 3, 3, 1)));
		((NPCLoot)(ref npcLoot)).Add((IItemDropRule)(object)new V2CommonDropRules.DifficultyScalingDrop((IItemDropRule)(object)new V2CommonDropRules.RerollsBasedOnWeightLevelRule(1516, 50, 1, 1, 1, 1), (IItemDropRule)(object)new V2CommonDropRules.RerollsBasedOnWeightLevelRule(1516, 40, 1, 1, 1, 1), (IItemDropRule)(object)new V2CommonDropRules.RerollsBasedOnWeightLevelRule(1516, 30, 1, 1, 1, 1)));
		((NPCLoot)(ref npcLoot)).Add((IItemDropRule)(object)new V2CommonDropRules.DifficultyScalingDrop((IItemDropRule)(object)new V2CommonDropRules.RerollsBasedOnWeightLevelRule(4016, 40), (IItemDropRule)(object)new V2CommonDropRules.RerollsBasedOnWeightLevelRule(4016, 30), (IItemDropRule)(object)new V2CommonDropRules.RerollsBasedOnWeightLevelRule(4016, 25)));
		((NPCLoot)(ref npcLoot)).Add((IItemDropRule)(object)new V2CommonDropRules.DifficultyScalingDrop((IItemDropRule)new CommonDrop(ModContent.ItemType<FeatherDuster>(), 10, 3, 6, 1), (IItemDropRule)new CommonDrop(ModContent.ItemType<FeatherDuster>(), 8, 4, 8, 1), (IItemDropRule)new CommonDrop(ModContent.ItemType<FeatherDuster>(), 6, 5, 10, 1)));
	}
}
