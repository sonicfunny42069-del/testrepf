using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Vanilla.Hallow;

public class PrismaticLacewing : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 661;
	}

	public override void SetDefaults(NPC npc)
	{
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsFood().DefinedBaseSize = 0.035;
		npc.AsPred().MaxStomachCapacity = 5.0;
		npc.AsPred().BaseStomachacheMeterCapacity = 10000.0;
		npc.AsPred().SmallGulpThreshold = 0.0;
		npc.AsPred().BigGulps = null;
		npc.AsPred().CanBeForceFed = CanLacewingBeForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().StandardBurps = null;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		npc.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		npc.AsFood().OnDigestedBy = PreyNPC.OnKilledByDigestion_GrantLivePreyGoal;
	}

	public static bool CanLacewingBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Hallow.EmpressButterfly.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Hallow.EmpressButterfly.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Hallow.EmpressButterfly.3" }));
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Hallow.EmpressButterfly.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 2.0 / 3.0;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 31.4;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 0, 40);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(6.75 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 5);
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(4.0 * Math.Sqrt(npc.AsPred().ExtraWeight)), 0);
	}

	public override void PostAI(NPC npc)
	{
		if (ModContent.GetInstance<V2ServerConfig>().EasilyEdibleEmpress)
		{
			int num = 1;
			List<(TargetType, int, TargetPriorityLevel)> list = new List<(TargetType, int, TargetPriorityLevel)>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<(TargetType, int, TargetPriorityLevel)> span = CollectionsMarshal.AsSpan(list);
			int num2 = 0;
			span[num2] = (TargetType.NPC, 636, TargetPriorityLevel.Favorite);
			num2++;
			npc.DoContactGulpage(list);
		}
	}

	public static int GetEmpressDigestionStage(NPC npc)
	{
		if (PredNPC.GetStomachTracker(npc) == null)
		{
			return 0;
		}
		PreyData candyFairy = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
		if (candyFairy == null || candyFairy.WeightLeftToDigest < 6.0)
		{
			return 0;
		}
		if (!candyFairy.NoHealth)
		{
			return 1;
		}
		if (candyFairy.WeightLeftToDigest > 34.0)
		{
			return 1;
		}
		if (candyFairy.WeightLeftToDigest > 28.0)
		{
			return 2;
		}
		if (candyFairy.WeightLeftToDigest > 16.0)
		{
			return 3;
		}
		if (candyFairy.WeightLeftToDigest > 6.0)
		{
			return 4;
		}
		return 0;
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		int flapFrameTime = 7;
		int flapFrame = ((!(npc.frameCounter < (double)flapFrameTime)) ? ((npc.frameCounter < (double)(flapFrameTime * 2)) ? 1 : ((!(npc.frameCounter < (double)(flapFrameTime * 3))) ? 1 : 2)) : 0);
		if (GetEmpressDigestionStage(npc) > 0)
		{
			npc.frame = new Rectangle(70 * flapFrame, 116 * (GetEmpressDigestionStage(npc) - 1), 68, 114);
		}
		else
		{
			npc.frame = new Rectangle(60 * flapFrame, 60 * npc.AsPred().GetVisualBellySize(npc), 58, 58);
		}
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		SpriteEffects spriteEffects = (SpriteEffects)0;
		if (npc.spriteDirection == 1)
		{
			spriteEffects = (SpriteEffects)1;
		}
		string tastyLightButterflyTummyTypeString = "_MainSheet";
		if (GetEmpressDigestionStage(npc) > 0)
		{
			tastyLightButterflyTummyTypeString = "_BossBelly_EmpressOfLight";
		}
		string tastyLightButterflyWeightString = ((GetVisualWeightStage(npc) > 0) ? ("_WeightGain" + GetVisualWeightStage(npc)) : "_BaseWeight");
		Texture2D exactLacewingTexture = ModContent.Request<Texture2D>("V2/NPCs/Vanilla/Hallow/PrismaticLacewing" + tastyLightButterflyWeightString + tastyLightButterflyTummyTypeString, (AssetRequestMode)1).Value;
		Color whiteColor = Color.White;
		float lerpRatioA = 0.5f;
		float lerpRatioB = 0f;
		int rotatingAfterimages = 6;
		float strangeConstantThatIDoNotKnowTheMeaningOf = (float)Math.Cos(Main.GlobalTimeWrappedHourly % 2.4f / 2.4f * ((float)Math.PI * 2f)) / 2f + 0.5f;
		strangeConstantThatIDoNotKnowTheMeaningOf = MathHelper.Max(strangeConstantThatIDoNotKnowTheMeaningOf, Utils.GetLerpValue(0f, 60f, npc.ai[2], true));
		float num277 = 6f;
		float num278 = 0f;
		Vector2 origin = default(Vector2);
		((Vector2)(ref origin))._002Ector(30f, 12f);
		if (GetEmpressDigestionStage(npc) > 0)
		{
			((Vector2)(ref origin))._002Ector(54f, 12f);
		}
		for (int i = 0; i < rotatingAfterimages; i++)
		{
			Color modifiedDrawColorA = drawColor;
			modifiedDrawColorA = Color.Lerp(modifiedDrawColorA, whiteColor, lerpRatioA);
			modifiedDrawColorA = npc.GetAlpha(modifiedDrawColorA);
			modifiedDrawColorA = Color.Lerp(modifiedDrawColorA, whiteColor, lerpRatioB);
			modifiedDrawColorA *= 1f - strangeConstantThatIDoNotKnowTheMeaningOf;
			Vector2 afterimageDrawPosition = ((Entity)npc).Center + Utils.ToRotationVector2((float)i / (float)rotatingAfterimages * ((float)Math.PI * 2f) + npc.rotation + num278) * num277 * strangeConstantThatIDoNotKnowTheMeaningOf - screenPos;
			spriteBatch.Draw(exactLacewingTexture, afterimageDrawPosition, (Rectangle?)npc.frame, modifiedDrawColorA, npc.rotation, origin, npc.scale, spriteEffects, 0f);
		}
		Vector2 mainDrawPosition = ((Entity)npc).Center - screenPos;
		spriteBatch.Draw(exactLacewingTexture, mainDrawPosition, (Rectangle?)npc.frame, npc.GetAlpha(drawColor), npc.rotation, origin, npc.scale, spriteEffects, 0f);
		num278 = MathHelper.Lerp(0f, 3f, Utils.GetLerpValue(0f, 60f, npc.ai[2], true));
		for (int j = 0; j < rotatingAfterimages; j++)
		{
			Color rainbowColor = Utils.MultiplyRGBA(new Color(127 - npc.alpha, 127 - npc.alpha, 127 - npc.alpha, 0), Main.hslToRgb((Main.GlobalTimeWrappedHourly + (float)j / (float)rotatingAfterimages) % 1f, 1f, 0.5f, byte.MaxValue));
			rainbowColor = npc.GetAlpha(rainbowColor);
			rainbowColor *= 1f - strangeConstantThatIDoNotKnowTheMeaningOf * 0.5f;
			((Color)(ref rainbowColor)).A = 0;
			float num296 = 2f + npc.ai[2];
			Vector2 rainbowAfterimageDrawPosition = ((Entity)npc).Center + Utils.ToRotationVector2((float)j / (float)rotatingAfterimages * ((float)Math.PI * 2f) + npc.rotation + num278) * (num296 * strangeConstantThatIDoNotKnowTheMeaningOf + 2f) - screenPos;
			spriteBatch.Draw(exactLacewingTexture, rainbowAfterimageDrawPosition, (Rectangle?)npc.frame, rainbowColor, npc.rotation, origin, npc.scale, spriteEffects, 0f);
		}
		spriteBatch.Draw(exactLacewingTexture, mainDrawPosition, (Rectangle?)npc.frame, new Color(255, 255, 255, 0) * 0.1f, npc.rotation, origin, npc.scale, spriteEffects, 0f);
		return false;
	}
}
