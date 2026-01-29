using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.Bosses.EmpressOfLight;

public class CandyFairy : GlobalNPC
{
	private int _muffledScreechDelay;

	public static int MuffledScreechMinDelay => V2Utils.SensibleTime(0, 0, 5);

	public int MuffledScreechDelay
	{
		get
		{
			return _muffledScreechDelay;
		}
		set
		{
			_muffledScreechDelay = Math.Max(0, value);
		}
	}

	public SlotId MuffledMusic { get; set; }

	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 636;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.AsFood().DefinedBaseSize = 40.0;
		npc.AsPred().MaxStomachCapacity = 1000.0;
		npc.AsPred().BaseStomachacheMeterCapacity = 50000.0;
		npc.AsV2NPC().NewAIMethod = V2UnreasonablyThickFairyAI;
		npc.AsFood().SpecialPreyAI = UnreasonablyThickFairyPreyAI;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 3.75;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().CanBeForceFed = CanUnreasonablyThickFairyBeForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().OnDigestionKill = OnDigestionKill;
		npc.AsPred().MouthSoundRawOffset = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 0f, -40f);
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 3.75;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().WeightGainRatio = 0.4;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		npc.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		npc.AsCandyFairy().MuffledScreechDelay = 0;
		npc.AsFood().DigestedDeathSound = CandyFairyStuff.MuffledCandyFairyDeathScreech;
		PreyNPC preyNPC = npc.AsFood();
		int num = 10;
		List<ItemTheftRule> list = new List<ItemTheftRule>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<ItemTheftRule> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = CandyFairyStuff.ItemTheftRules.WeaponDrops;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.StarGuitar;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.EmpressWings;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.PrismaticDye;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.Mask;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.Trophy;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.ExpertDrop;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.MasterTrophy;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.MasterPetItem;
		num2++;
		span[num2] = CandyFairyStuff.ItemTheftRules.HangrySwordDrop;
		num2++;
		preyNPC.ItemTheftRules = list;
	}

	public override void ModifyHitNPC(NPC npc, NPC target, ref HitModifiers modifiers)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		float num = npc.ai[0];
		if ((num == 8f || num == 9f) ? true : false)
		{
			ref StatModifier finalDamage = ref modifiers.FinalDamage;
			finalDamage *= 0f;
		}
	}

	public override void ModifyHitPlayer(NPC npc, Player target, ref HurtModifiers modifiers)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		float num = npc.ai[0];
		if ((num == 8f || num == 9f) ? true : false)
		{
			ref StatModifier finalDamage = ref modifiers.FinalDamage;
			finalDamage *= 0f;
		}
	}

	public static bool CanUnreasonablyThickFairyBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[4] { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Bosses.UnreasonablyThickFairy.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Bosses.UnreasonablyThickFairy.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Bosses.UnreasonablyThickFairy.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Bosses.UnreasonablyThickFairy.4" }));
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Bosses.UnreasonablyThickFairy.Hardcore");
		}
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		if (!Main.dayTime)
		{
			return 100.0;
		}
		return 1000.0;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		if (npc.AI_120_HallowBoss_IsGenuinelyEnraged())
		{
			return 12.0;
		}
		if (Main.bloodMoon)
		{
			if (npc.AI_120_HallowBoss_IsInPhase2())
			{
				return 9.0;
			}
			return 6.0;
		}
		if (npc.AI_120_HallowBoss_IsInPhase2())
		{
			return 4.5;
		}
		return 3.0;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		double baseAbsorptionRate = 1.0 / (double)V2Utils.SensibleTime(0, 0, 6);
		if (Main.dayTime)
		{
			baseAbsorptionRate *= 10.0;
		}
		if (npc.AI_120_HallowBoss_IsInPhase2())
		{
			baseAbsorptionRate *= 1.5;
		}
		return baseAbsorptionRate;
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(1.5 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 9);
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(0.4 * Math.Sqrt(npc.AsPred().ExtraWeight)), 3);
	}

	public static int GetKingSlimeDigestionStage(NPC npc)
	{
		PreyData giantJelloDessert = PredNPC.GetStomachTracker(npc)?.Prey?.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 50);
		if (giantJelloDessert == null)
		{
			return 0;
		}
		if (!giantJelloDessert.NoHealth)
		{
			return 1;
		}
		if (giantJelloDessert.WeightLeftToDigest > 60.0)
		{
			return 1;
		}
		if (giantJelloDessert.WeightLeftToDigest > 50.0)
		{
			return 2;
		}
		if (giantJelloDessert.WeightLeftToDigest > 40.0)
		{
			return 3;
		}
		return 0;
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		if (GetKingSlimeDigestionStage(npc) > 0)
		{
			npc.frame = new Rectangle(128 * (GetKingSlimeDigestionStage(npc) - 1), 214 * npc.AsPred().GetVisualWeightStage(npc), 126, 212);
		}
		else
		{
			npc.frame = new Rectangle(92 * npc.AsPred().GetVisualBellySize(npc), 170 * npc.AsPred().GetVisualWeightStage(npc), 90, 168);
		}
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Unknown result type (might be due to invalid IL or missing references)
		//IL_0785: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_088a: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0901: Unknown result type (might be due to invalid IL or missing references)
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_099c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		string fatFuckingTummyTypeString = "_MainSheet";
		if (GetKingSlimeDigestionStage(npc) > 0)
		{
			fatFuckingTummyTypeString = "_BossBelly_KingSlime";
		}
		string text = "V2/NPCs/Vanilla/Bosses/EmpressOfLight/EmpressOfLight_MainBody" + fatFuckingTummyTypeString;
		if (GetVisualWeightStage(npc) > 0)
		{
			_ = "_WeightGain" + GetVisualWeightStage(npc);
		}
		Texture2D mainBody = ModContent.Request<Texture2D>(text, (AssetRequestMode)1).Value;
		Vector2 npcCenterOnScreen = ((Entity)npc).Center - screenPos;
		bool inPhase2 = npc.AI_120_HallowBoss_IsInPhase2();
		int num = (int)npc.ai[0];
		Texture2D wingsBack = TextureAssets.Extra[159].Value;
		Rectangle wingsBackFrameBounds = Utils.Frame(wingsBack, 1, 11, 0, (int)(npc.localAI[0] / 4f) % 11, 0, 0);
		Color drawColorWithAlphaConsidered = npc.GetAlpha(drawColor);
		Texture2D leftArm = TextureAssets.Extra[158].Value;
		Texture2D rightArm = TextureAssets.Extra[160].Value;
		Texture2D wingsFront = TextureAssets.Extra[157].Value;
		Vector2 drawOrigin = default(Vector2);
		((Vector2)(ref drawOrigin))._002Ector((float)(npc.frame.Width / 2), 84f);
		DrawNPCDirect_GetHallowBossArmFrame(npc, out var armFrame_Count, out var armFrameToUseLeft, out var armFrameToUseRight);
		Rectangle leftArmFrameBounds = Utils.Frame(leftArm, 1, armFrame_Count, 0, armFrameToUseLeft, 0, 0);
		Rectangle rightArmFrameBounds = Utils.Frame(rightArm, 1, armFrame_Count, 0, armFrameToUseRight, 0, 0);
		Vector2 leftArmOrigin = Utils.Size(leftArmFrameBounds) / 2f;
		Vector2 rightArmOrigin = Utils.Size(rightArmFrameBounds) / 2f;
		int num2 = 0;
		int num3 = 0;
		if (armFrameToUseLeft == 5)
		{
			num2 = 1;
		}
		if (armFrameToUseRight == 5)
		{
			num3 = 1;
		}
		float num4 = 1f;
		int num5 = 0;
		int num6 = 0;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		if (num == 8 || num == 9)
		{
			num7 = Utils.GetLerpValue(0f, 30f, npc.ai[1], true) * Utils.GetLerpValue(90f, 30f, npc.ai[1], true);
			num8 = Utils.GetLerpValue(0f, 30f, npc.ai[1], true) * Utils.GetLerpValue(90f, 70f, npc.ai[1], true);
			num9 = Utils.GetLerpValue(0f, 15f, npc.ai[1], true) * Utils.GetLerpValue(45f, 30f, npc.ai[1], true);
			drawColorWithAlphaConsidered = Color.Lerp(drawColorWithAlphaConsidered, Color.White, num7);
			num4 *= 1f - num9;
			num5 = 4;
			num6 = 3;
		}
		if (num == 10)
		{
			num7 = Utils.GetLerpValue(30f, 90f, npc.ai[1], true) * Utils.GetLerpValue(165f, 90f, npc.ai[1], true);
			num8 = Utils.GetLerpValue(0f, 60f, npc.ai[1], true) * Utils.GetLerpValue(180f, 120f, npc.ai[1], true);
			num9 = Utils.GetLerpValue(0f, 60f, npc.ai[1], true) * Utils.GetLerpValue(180f, 120f, npc.ai[1], true);
			drawColorWithAlphaConsidered = Color.Lerp(drawColorWithAlphaConsidered, Color.White, num7);
			num4 *= 1f - num9;
			num6 = 4;
		}
		if (num6 + num5 > 0)
		{
			for (int i = -num6; i <= num6 + num5; i++)
			{
				if (i == 0)
				{
					continue;
				}
				Color color2 = Color.White;
				Vector2 position = npcCenterOnScreen;
				if (num == 8 || num == 9)
				{
					float num10 = ((float)i + 5f) / 10f;
					float num11 = 200f;
					float num12 = (float)Main.timeForVisualEffects / 60f;
					Matrix val = Matrix.CreateRotationX((num12 - 0.3f + (float)i * 0.1f) * 0.7f * ((float)Math.PI * 2f)) * Matrix.CreateRotationY((num12 - 0.8f + (float)i * 0.3f) * 0.7f * ((float)Math.PI * 2f)) * Matrix.CreateRotationZ((num12 + (float)i * 0.5f) * 0.1f * ((float)Math.PI * 2f));
					Vector3 vector2 = Vector3.Transform(Vector3.Forward, val);
					num11 += Utils.GetLerpValue(-1f, 1f, vector2.Z, true) * 150f;
					Vector2 spinningpoint = new Vector2(vector2.X, vector2.Y) * num11 * num7;
					float lerpValue = Utils.GetLerpValue(90f, 0f, npc.ai[1], true);
					color2 = Main.hslToRgb(num10, 1f, MathHelper.Lerp(0.5f, 1f, lerpValue), byte.MaxValue) * 0.8f * num8;
					((Color)(ref color2)).A = (byte)(((Color)(ref color2)).A / 3);
					position += Utils.RotatedBy(spinningpoint, (double)(npc.ai[1] / 180f * ((float)Math.PI * 2f)), default(Vector2));
				}
				if (num == 10)
				{
					if (npc.ai[1] >= 90f)
					{
						float num13 = (float)Main.timeForVisualEffects / 90f;
						int num14 = i;
						if (num14 < 0)
						{
							num14++;
						}
						Vector2 vector3 = Utils.ToRotationVector2(((float)num14 + 0.5f) * ((float)Math.PI / 4f) + (float)Math.PI * 2f * num13);
						position += vector3 * new Vector2(600f * num7, 150f * num7);
					}
					else
					{
						position += 200f * new Vector2((float)i, 0f) * num7;
					}
					color2 = Color.White * 0.8f * num8 * num4;
					((Color)(ref color2)).A = (byte)(((Color)(ref color2)).A / 3);
				}
				if (i > num6)
				{
					float lerpValue2 = Utils.GetLerpValue(30f, 70f, npc.ai[1], true);
					if (lerpValue2 == 0f)
					{
						continue;
					}
					position = npcCenterOnScreen + ((Entity)npc).velocity * -3f * ((float)i - 4f) * lerpValue2;
					color2 *= 1f - num9;
				}
				spriteBatch.Draw(wingsBack, position, (Rectangle?)wingsBackFrameBounds, color2, npc.rotation, Utils.Size(wingsBackFrameBounds) / 2f, npc.scale * 2f, (SpriteEffects)0, 0f);
				spriteBatch.Draw(wingsFront, position, (Rectangle?)wingsBackFrameBounds, color2, npc.rotation, Utils.Size(wingsBackFrameBounds) / 2f, npc.scale * 2f, (SpriteEffects)0, 0f);
				if (inPhase2)
				{
					Texture2D value6 = TextureAssets.Extra[187].Value;
					Rectangle value7 = Utils.Frame(value6, 1, 8, 0, (int)(npc.localAI[0] / 4f) % 8, 0, 0);
					spriteBatch.Draw(value6, position, (Rectangle?)value7, color2, npc.rotation, drawOrigin, npc.scale, (SpriteEffects)0, 0f);
				}
				spriteBatch.Draw(mainBody, position, (Rectangle?)npc.frame, color2, npc.rotation, drawOrigin, npc.scale, (SpriteEffects)0, 0f);
				for (int j = 0; j < 2; j++)
				{
					if (j == num2)
					{
						spriteBatch.Draw(leftArm, position, (Rectangle?)leftArmFrameBounds, color2, npc.rotation, leftArmOrigin, npc.scale, (SpriteEffects)0, 0f);
					}
					if (j == num3)
					{
						spriteBatch.Draw(rightArm, position, (Rectangle?)rightArmFrameBounds, color2, npc.rotation, rightArmOrigin, npc.scale, (SpriteEffects)0, 0f);
					}
				}
			}
		}
		drawColorWithAlphaConsidered *= num4;
		spriteBatch.Draw(wingsBack, npcCenterOnScreen, (Rectangle?)wingsBackFrameBounds, drawColorWithAlphaConsidered, npc.rotation, Utils.Size(wingsBackFrameBounds) / 2f, npc.scale * 2f, (SpriteEffects)0, 0f);
		if (!npc.IsABestiaryIconDummy)
		{
			spriteBatch.End();
			spriteBatch.Begin((SpriteSortMode)1, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, (Effect)null, Main.Transform);
		}
		DrawData value8 = default(DrawData);
		((DrawData)(ref value8))._002Ector(wingsFront, npcCenterOnScreen, (Rectangle?)wingsBackFrameBounds, drawColorWithAlphaConsidered, npc.rotation, Utils.Size(wingsBackFrameBounds) / 2f, npc.scale * 2f, (SpriteEffects)0, 0f);
		GameShaders.Misc["HallowBoss"].Apply((DrawData?)value8);
		((DrawData)(ref value8)).Draw(spriteBatch);
		Main.pixelShader.CurrentTechnique.Passes[0].Apply();
		if (!npc.IsABestiaryIconDummy)
		{
			spriteBatch.End();
			spriteBatch.Begin((SpriteSortMode)0, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, (Effect)null, Main.Transform);
		}
		float num15 = (float)Math.Sin(Main.GlobalTimeWrappedHourly * ((float)Math.PI * 2f) * 0.5f) * 0.5f + 0.5f;
		Color color3 = Main.hslToRgb((num15 * 0.08f + 0.6f) % 1f, 1f, 0.5f, byte.MaxValue);
		((Color)(ref color3)).A = 0;
		color3 *= 0.6f;
		if (NPC.ShouldEmpressBeEnraged())
		{
			color3 = Main.OurFavoriteColor;
			((Color)(ref color3)).A = 0;
			color3 *= 0.3f;
		}
		color3 *= num4 * npc.Opacity;
		if (inPhase2)
		{
			Texture2D value9 = TextureAssets.Extra[187].Value;
			Rectangle value10 = Utils.Frame(value9, 1, 8, 0, (int)(npc.localAI[0] / 4f) % 8, 0, 0);
			spriteBatch.Draw(value9, npcCenterOnScreen, (Rectangle?)value10, drawColorWithAlphaConsidered, npc.rotation, drawOrigin, npc.scale, (SpriteEffects)0, 0f);
			for (float num16 = 0f; num16 < 1f; num16 += 0.25f)
			{
				Vector2 vector4 = Utils.RotatedBy(Utils.ToRotationVector2(npc.rotation), (double)(num16 * ((float)Math.PI * 2f) + (float)Math.PI / 4f), default(Vector2)) * MathHelper.Lerp(2f, 8f, num15);
				spriteBatch.Draw(value9, npcCenterOnScreen + vector4, (Rectangle?)value10, color3, npc.rotation, drawOrigin, npc.scale, (SpriteEffects)0, 0f);
			}
		}
		spriteBatch.Draw(mainBody, npcCenterOnScreen, (Rectangle?)npc.frame, drawColorWithAlphaConsidered, npc.rotation, drawOrigin, npc.scale, (SpriteEffects)0, 0f);
		if (inPhase2)
		{
			Texture2D glowySkirtOverlay = ModContent.Request<Texture2D>("V2/NPCs/Vanilla/Bosses/EmpressOfLight/EmpressOfLight_SkirtOverlay" + fatFuckingTummyTypeString, (AssetRequestMode)1).Value;
			for (float num17 = 0f; num17 < 1f; num17 += 0.25f)
			{
				Vector2 vector5 = Utils.RotatedBy(Utils.ToRotationVector2(npc.rotation), (double)(num17 * ((float)Math.PI * 2f) + (float)Math.PI / 4f), default(Vector2)) * MathHelper.Lerp(2f, 8f, num15);
				spriteBatch.Draw(glowySkirtOverlay, npcCenterOnScreen + vector5, (Rectangle?)npc.frame, color3, npc.rotation, drawOrigin, npc.scale, (SpriteEffects)0, 0f);
			}
		}
		for (int k = 0; k < 2; k++)
		{
			if (k == num2)
			{
				spriteBatch.Draw(leftArm, npcCenterOnScreen, (Rectangle?)leftArmFrameBounds, drawColorWithAlphaConsidered, npc.rotation, leftArmOrigin, npc.scale, (SpriteEffects)0, 0f);
			}
			if (k == num3)
			{
				spriteBatch.Draw(rightArm, npcCenterOnScreen, (Rectangle?)rightArmFrameBounds, drawColorWithAlphaConsidered, npc.rotation, rightArmOrigin, npc.scale, (SpriteEffects)0, 0f);
			}
		}
		return false;
	}

	private static void DrawNPCDirect_GetHallowBossArmFrame(NPC npc, out int armFrame_Count, out int armFrameToUseLeft, out int armFrameToUseRight)
	{
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int num2 = 1;
		int num3 = 2;
		int num4 = 3;
		int num5 = 4;
		int num6 = 5;
		int num7 = 6;
		armFrame_Count = 7;
		armFrameToUseLeft = num;
		armFrameToUseRight = num;
		float num8 = npc.ai[1];
		switch ((int)npc.ai[0])
		{
		case 6:
			armFrameToUseRight = (armFrameToUseLeft = ((num8 < 6f) ? num3 : ((num8 < 174f) ? num4 : ((!(num8 < 180f)) ? num : num3))));
			break;
		case 0:
			armFrameToUseRight = (armFrameToUseLeft = ((num8 < 106f) ? num2 : ((!(num8 < 110f)) ? num : num3)));
			break;
		case 2:
		case 11:
			armFrameToUseLeft = ((num8 < 5f) ? num3 : ((!(num8 < 65f)) ? num3 : num4));
			break;
		case 5:
			armFrameToUseRight = ((num8 < 6f) ? num3 : ((!(num8 < 54f)) ? num3 : num4));
			break;
		case 4:
		case 10:
			armFrameToUseRight = (armFrameToUseLeft = ((num8 < 6f) ? num3 : ((!(num8 < 54f)) ? num3 : num4)));
			break;
		case 8:
		case 9:
		{
			int targetRightArmFrame;
			int targetLeftArmFrame = (targetRightArmFrame = ((num8 < 10f) ? num3 : ((num8 < 20f) ? num4 : ((!(num8 < 30f)) ? num6 : num3))));
			int num15 = (int)npc.ai[3];
			int num16 = -1;
			if (num8 < 30f)
			{
				if (num15 == -1 * num16)
				{
					targetLeftArmFrame = num2;
				}
				if (num15 == num16)
				{
					targetRightArmFrame = num2;
				}
			}
			int num17 = num6;
			int num18 = num7;
			if (num15 == num16 && targetLeftArmFrame == num17)
			{
				targetLeftArmFrame = num18;
			}
			if (num15 == -1 * num16 && targetRightArmFrame == num17)
			{
				targetRightArmFrame = num18;
			}
			armFrameToUseLeft = targetLeftArmFrame;
			armFrameToUseRight = targetRightArmFrame;
			break;
		}
		case 7:
		{
			GameModeData gameModeInfo = Main.GameModeInfo;
			bool isExpertMode = ((GameModeData)(ref gameModeInfo)).IsExpertMode;
			int num10 = (isExpertMode ? 40 : 60);
			int num11 = 0;
			int num12 = 5;
			if (num8 < (float)(num11 + num12))
			{
				armFrameToUseLeft = num3;
				break;
			}
			num11 += num12;
			if (num8 < (float)(num11 + num10 - num12))
			{
				armFrameToUseLeft = num4;
				break;
			}
			num11 += num10 - num12;
			if (num8 < (float)(num11 + num12))
			{
				armFrameToUseLeft = num4;
				armFrameToUseRight = num3;
				break;
			}
			num11 += num12;
			if (num8 < (float)(num11 + num10 - num12))
			{
				armFrameToUseLeft = num4;
				armFrameToUseRight = num4;
				break;
			}
			num11 += num10 - num12;
			if (num8 < (float)(num11 + num10))
			{
				armFrameToUseLeft = num5;
				armFrameToUseRight = num4;
				break;
			}
			num11 += num10;
			if (num8 < (float)(num11 + num10))
			{
				armFrameToUseLeft = num5;
				armFrameToUseRight = num5;
				break;
			}
			num11 += num10;
			if (isExpertMode)
			{
				if (num8 < (float)(num11 + num12))
				{
					armFrameToUseLeft = num4;
					armFrameToUseRight = num5;
					break;
				}
				num11 += num12;
				if (num8 < (float)(num11 + num10 - num12))
				{
					armFrameToUseLeft = num2;
					armFrameToUseRight = num5;
					break;
				}
				num11 += num10 - num12;
				if (num8 < (float)(num11 + num12))
				{
					armFrameToUseLeft = num2;
					armFrameToUseRight = num4;
					break;
				}
				num11 += num12;
				if (num8 < (float)(num11 + num10 - num12))
				{
					armFrameToUseLeft = num2;
					armFrameToUseRight = num2;
					break;
				}
				num11 += num10 - num12;
			}
			if (num8 >= (float)num11)
			{
				armFrameToUseLeft = num3;
				armFrameToUseRight = num3;
			}
			break;
		}
		case 1:
		case 3:
			break;
		}
	}

	public static bool V2UnreasonablyThickFairyAI(NPC npc)
	{
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		float num = npc.ai[0];
		if ((num == 8f || num == 9f) ? true : false)
		{
			npc.DoContactGulpage();
		}
		bool pastTense = default(bool);
		if (npc.target == -1 || !Main.player[npc.target].IsFoodFor((Entity)(object)npc, out pastTense) || pastTense)
		{
			return true;
		}
		num = npc.ai[0];
		if ((num == 8f || num == 9f) ? true : false)
		{
			float num2 = 0.5f;
			float num3 = 12f;
			int num33 = ((npc.ai[0] != 8f) ? 1 : (-1));
			if (npc.ai[1] <= 40f)
			{
				if (npc.ai[1] == 20f)
				{
					SoundEngine.PlaySound(ref SoundID.Item160, (Vector2?)((Entity)npc).Center, (SoundUpdateCallback)null);
				}
				NPCAimedTarget targetData3 = npc.GetTargetData(true);
				Vector2 destination = (((NPCAimedTarget)(ref targetData3)).Invalid ? ((Entity)npc).Center : ((NPCAimedTarget)(ref targetData3)).Center) + new Vector2((float)(num33 * -550), 0f);
				npc.SimpleFlyMovement(Utils.SafeNormalize(((Entity)npc).DirectionTo(destination), Vector2.Zero) * num3, num2 * 2f);
				if (npc.ai[1] == 40f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.3f;
				}
			}
			else if (npc.ai[1] <= 90f)
			{
				Vector2 val = default(Vector2);
				((Vector2)(ref val))._002Ector((float)(num33 * 50), 0f);
				((Entity)npc).velocity = Vector2.Lerp(((Entity)npc).velocity, val, 0.05f);
				if (npc.ai[1] == 90f)
				{
					((Entity)npc).velocity = ((Entity)npc).velocity * 0.7f;
				}
			}
			else
			{
				((Entity)npc).velocity = ((Entity)npc).velocity * 0.92f;
			}
			bool num34 = npc.AI_120_HallowBoss_IsInPhase2();
			bool flag2 = Main.expertMode;
			int num35 = 0;
			if (num34)
			{
				num35 += 15;
			}
			if (flag2)
			{
				num35 += 5;
			}
			float num36 = 20 - num35;
			npc.ai[1] += 1f;
			if (npc.ai[1] >= 90f + num36)
			{
				npc.ai[0] = 1f;
				npc.ai[1] = 0f;
				npc.netUpdate = true;
			}
		}
		else
		{
			npc.ai[0] = 1f;
			npc.ai[1] = 0f;
			((Entity)npc).velocity = ((Entity)npc).velocity * 0.85f;
			npc.netUpdate = true;
		}
		return false;
	}

	public static void UnreasonablyThickFairyPreyAI(NPC npc, Entity pred)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		ActiveSound muffledMusic = default(ActiveSound);
		SoundStyle val;
		if (!SoundEngine.TryGetActiveSound(npc.AsCandyFairy().MuffledMusic, ref muffledMusic))
		{
			CandyFairy candyFairy = npc.AsCandyFairy();
			val = CandyFairyStuff.MuffledCandyFairyMusic;
			candyFairy.MuffledMusic = SoundEngine.PlaySound(ref val, (Vector2?)pred.TrueCenter(), (SoundUpdateCallback)null);
			SoundEngine.TryGetActiveSound(npc.AsCandyFairy().MuffledMusic, ref muffledMusic);
		}
		if (muffledMusic != null)
		{
			muffledMusic.Position = pred.TrueCenter();
			muffledMusic.Volume = (float)npc.life / (float)npc.lifeMax;
			npc.AsCandyFairy().MuffledScreechDelay--;
			if (npc.AsCandyFairy().MuffledScreechDelay == 0 && Utils.NextBool(Main.rand, 200))
			{
				npc.AsCandyFairy().MuffledScreechDelay = MuffledScreechMinDelay;
				val = (Utils.NextBool(Main.rand) ? CandyFairyStuff.MuffledCandyFairyScreech1 : CandyFairyStuff.MuffledCandyFairyScreech2);
				((SoundStyle)(ref val)).Volume = 1f;
				((SoundStyle)(ref val)).PitchVariance = 0.07f;
				SoundEngine.PlaySound(ref val, (Vector2?)pred.TrueCenter(), (SoundUpdateCallback)null);
			}
		}
	}
}
