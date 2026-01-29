using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.NPCs.Sets;

public static class GeneralizedAIOverrides
{
	public static SlimeNPC AsSlime(this NPC npc)
	{
		SlimeNPC slime = default(SlimeNPC);
		if (!npc.TryGetGlobalNPC<SlimeNPC>(ref slime))
		{
			throw new Exception("this slime, supposedly, doesn't exist");
		}
		return slime;
	}

	private static ref float SlimeBonusDrop(this NPC npc)
	{
		return ref npc.ai[1];
	}

	public static void SimpleSlimeFirstFrameAI(NPC npc, int baseHeight)
	{
		((Entity)npc).position.Y -= (float)baseHeight * 0.75f;
	}

	public static bool SimpleSlimeAI(NPC npc, float baseScale, int baseWidth, int baseHeight)
	{
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_095a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_0976: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_0873: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1109: Unknown result type (might be due to invalid IL or missing references)
		//IL_1126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1302: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Unknown result type (might be due to invalid IL or missing references)
		//IL_130f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1319: Unknown result type (might be due to invalid IL or missing references)
		//IL_1323: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1807: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_184c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1869: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_21cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1382: Unknown result type (might be due to invalid IL or missing references)
		//IL_139f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_122e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0deb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df2: Unknown result type (might be due to invalid IL or missing references)
		//IL_105d: Unknown result type (might be due to invalid IL or missing references)
		//IL_107a: Unknown result type (might be due to invalid IL or missing references)
		//IL_107f: Unknown result type (might be due to invalid IL or missing references)
		//IL_109a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_276c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1915: Unknown result type (might be due to invalid IL or missing references)
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1712: Unknown result type (might be due to invalid IL or missing references)
		//IL_1719: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_14da: Unknown result type (might be due to invalid IL or missing references)
		//IL_1513: Unknown result type (might be due to invalid IL or missing references)
		//IL_151a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1521: Unknown result type (might be due to invalid IL or missing references)
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_24dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_265b: Unknown result type (might be due to invalid IL or missing references)
		//IL_267d: Unknown result type (might be due to invalid IL or missing references)
		//IL_25dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2534: Unknown result type (might be due to invalid IL or missing references)
		//IL_2539: Unknown result type (might be due to invalid IL or missing references)
		//IL_2543: Unknown result type (might be due to invalid IL or missing references)
		//IL_256a: Unknown result type (might be due to invalid IL or missing references)
		//IL_256f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2579: Unknown result type (might be due to invalid IL or missing references)
		if (PredNPC.GetCurrentBellyWeight(npc) > 0.0 || npc.AsPred().ExtraWeight > 0.0)
		{
			npc.scale = baseScale * (1f + 0.3f * (float)Math.Sqrt(npc.AsPred().ExtraWeight / npc.AsFood().DefinedBaseSize));
			_ = npc.scale;
			npc.AsPred().MaxStomachCapacity = npc.AsFood().DefinedBaseSize * 1.5 * (double)(npc.scale / baseScale);
			npc.AsFood().DefinedEffectiveSize = npc.AsFood().DefinedBaseSize * (double)(npc.scale / baseScale);
			npc.scale *= 1f + (float)(PredNPC.GetCurrentBellyWeight(npc) / npc.AsFood().DefinedEffectiveSize);
			((Entity)npc).width = (int)((float)baseWidth * npc.scale);
			((Entity)npc).height = (int)((float)baseHeight * npc.scale);
		}
		float movementModifier = 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
		movementModifier /= npc.scale / baseScale;
		if (npc.type == 1 && (npc.SlimeBonusDrop() == 1f || npc.SlimeBonusDrop() == 2f || npc.SlimeBonusDrop() == 3f))
		{
			npc.SlimeBonusDrop() = -1f;
		}
		if (npc.type == 1 && npc.SlimeBonusDrop() == 75f)
		{
			float num = 0.3f;
			Lighting.AddLight((int)(((Entity)npc).Center.X / 16f), (int)(((Entity)npc).Center.Y / 16f), 0.8f * num, 0.7f * num, 0.1f * num);
			if (Utils.NextBool(Main.rand, 12))
			{
				Dust obj = Dust.NewDustPerfect(((Entity)npc).Center + new Vector2(0f, (float)((Entity)npc).height * 0.2f) + Utils.NextVector2CircularEdge(Main.rand, (float)((Entity)npc).width, (float)((Entity)npc).height * 0.6f) * (0.3f + Utils.NextFloat(Main.rand) * 0.5f), 228, (Vector2?)new Vector2(0f, (0f - Utils.NextFloat(Main.rand)) * 0.3f - 1.5f), 127, default(Color), 1f);
				obj.scale = 0.5f;
				obj.fadeIn = 1.1f;
				obj.noGravity = true;
				obj.noLight = true;
			}
		}
		if (npc.type == 1 && npc.SlimeBonusDrop() == 0f && Main.netMode != 1 && npc.value > 0f)
		{
			npc.SlimeBonusDrop() = -1f;
			if (Main.remixWorld && npc.ai[0] != -999f && Utils.NextBool(Main.rand, 3))
			{
				npc.SlimeBonusDrop() = 75f;
				npc.netUpdate = true;
			}
			else if (Utils.NextBool(Main.rand, 20))
			{
				int num2 = DetermineSlimeBonusItem(npc.netID, npc.ai[0] == -999f);
				npc.SlimeBonusDrop() = num2;
				npc.netUpdate = true;
			}
		}
		if (npc.type == 1 && npc.ai[0] == -999f)
		{
			npc.frame.Y = 0;
			npc.frameCounter = 0.0;
			npc.rotation = 0f;
			return false;
		}
		if (npc.type == 244)
		{
			float num3 = (float)Main.DiscoR / 255f;
			float num4 = (float)Main.DiscoG / 255f;
			float num5 = (float)Main.DiscoB / 255f;
			num3 *= 1f;
			num4 *= 1f;
			num5 *= 1f;
			Lighting.AddLight((int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f), (int)((((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f), num3, num4, num5);
			npc.AI_001_SetRainbowSlimeColor();
		}
		bool flag = false;
		if (!Main.dayTime || npc.life != npc.lifeMax || (double)((Entity)npc).position.Y > Main.worldSurface * 16.0 || Main.slimeRain)
		{
			flag = true;
		}
		if (Main.remixWorld && npc.type == 59 && npc.life == npc.lifeMax)
		{
			flag = false;
		}
		if (npc.type == 81)
		{
			flag = true;
			if (Utils.NextBool(Main.rand, 30))
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				int num6 = Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 14, 0f, 0f, npc.alpha, npc.color, 1f);
				Dust obj2 = Main.dust[num6];
				obj2.velocity *= 0.3f;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		if (npc.type == 183)
		{
			flag = true;
		}
		if (npc.type == 304)
		{
			flag = true;
		}
		if (npc.type == 667)
		{
			flag = true;
		}
		if (npc.type == 244)
		{
			flag = true;
			npc.ai[0] += 2f;
		}
		if (npc.type == 147 && Utils.NextBool(Main.rand, 10))
		{
			((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
			int num7 = Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 76, 0f, 0f, 0, default(Color), 1f);
			Main.dust[num7].noGravity = true;
			Dust obj3 = Main.dust[num7];
			obj3.velocity *= 0.1f;
			((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
		}
		if (npc.type == 667)
		{
			Color color = default(Color);
			((Color)(ref color))._002Ector(204, 181, 72, 255);
			Lighting.AddLight((int)(((Entity)npc).Center.X / 16f), (int)(((Entity)npc).Center.Y / 16f), (float)(int)((Color)(ref color)).R / 255f * 1.1f, (float)(int)((Color)(ref color)).G / 255f * 1.1f, (float)(int)((Color)(ref color)).B / 255f * 1.1f);
			if (((Vector2)(ref ((Entity)npc).velocity)).Length() > 1f || !Utils.NextBool(Main.rand, 4))
			{
				int num8 = 8;
				Vector2 val = ((Entity)npc).position + new Vector2((float)(-num8), (float)(-num8));
				int num9 = ((Entity)npc).width + num8 * 2;
				int num10 = ((Entity)npc).height + num8 * 2;
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				int num11 = Dust.NewDust(val, num9, num10, 246, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num11].noGravity = true;
				Main.dust[num11].noLightEmittence = true;
				Dust obj4 = Main.dust[num11];
				obj4.velocity *= 0.2f;
				Main.dust[num11].scale = 1.5f;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		if (npc.type == 676)
		{
			Lighting.AddLight(((Entity)npc).Center, 23);
			if ((((Vector2)(ref ((Entity)npc).velocity)).Length() > 1f && Utils.NextBool(Main.rand, 3)) || Utils.NextBool(Main.rand, 5))
			{
				Dust dust2 = Dust.NewDustPerfect(Utils.NextVector2FromRectangle(Main.rand, ((Entity)npc).Hitbox), 306, (Vector2?)null, 0, default(Color), 1f);
				dust2.noGravity = true;
				dust2.noLightEmittence = true;
				dust2.alpha = 127;
				dust2.color = Main.hslToRgb(((float)Main.timeForVisualEffects / 300f + Utils.NextFloat(Main.rand) * 0.1f) % 1f, 1f, 0.65f, byte.MaxValue);
				((Color)(ref dust2.color)).A = 0;
				dust2.velocity = dust2.position - ((Entity)npc).Center;
				dust2.velocity *= 0.1f;
				dust2.velocity.X *= 0.25f;
				if (dust2.velocity.Y > 0f)
				{
					dust2.velocity.Y *= -1f;
				}
				dust2.scale = Utils.NextFloat(Main.rand) * 0.3f + 0.5f;
				dust2.fadeIn = 0.9f;
				dust2.position += npc.netOffset;
			}
		}
		if (npc.type == 184)
		{
			if (Utils.NextBool(Main.rand, 8))
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				int num12 = Dust.NewDust(((Entity)npc).position - ((Entity)npc).velocity, ((Entity)npc).width, ((Entity)npc).height, 76, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num12].noGravity = true;
				Dust obj5 = Main.dust[num12];
				obj5.velocity *= 0.15f;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
			flag = true;
			if (npc.localAI[0] > 0f)
			{
				npc.localAI[0] -= 1f;
			}
			if (!((Entity)npc).wet && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				Vector2 vector2 = default(Vector2);
				((Vector2)(ref vector2))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
				float num13 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector2.X;
				float num14 = ((Entity)Main.player[npc.target]).position.Y - vector2.Y;
				float num15 = (float)Math.Sqrt(num13 * num13 + num14 * num14);
				if (Main.expertMode && num15 < 120f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						Vector2 vector3 = default(Vector2);
						for (int i = 0; i < 5; i++)
						{
							((Vector2)(ref vector3))._002Ector((float)(i - 2), -4f);
							vector3.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							vector3.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							((Vector2)(ref vector3)).Normalize();
							vector3 *= 4f + (float)Main.rand.Next(-50, 51) * 0.01f;
							int attackDamage_ForProjectiles = npc.GetAttackDamage_ForProjectiles(9f, 9f);
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector2.X, vector2.Y, vector3.X, vector3.Y, 174, attackDamage_ForProjectiles, 0f, Main.myPlayer, 0f, 0f, 0f);
							npc.localAI[0] = 30f;
						}
					}
				}
				else if (num15 < 200f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						num14 = ((Entity)Main.player[npc.target]).position.Y - vector2.Y - (float)Main.rand.Next(0, 200);
						num15 = (float)Math.Sqrt(num13 * num13 + num14 * num14);
						num15 = 4.5f / num15;
						num13 *= num15;
						num14 *= num15;
						npc.localAI[0] = 50f;
						Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector2.X, vector2.Y, num13, num14, 174, 9, 0f, Main.myPlayer, 0f, 0f, 0f);
					}
				}
			}
		}
		if (npc.type == 535)
		{
			flag = true;
			if (npc.localAI[0] > 0f)
			{
				npc.localAI[0] -= 1f;
			}
			if (!((Entity)npc).wet && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				Vector2 vector4 = default(Vector2);
				((Vector2)(ref vector4))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
				float num16 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector4.X;
				float num17 = ((Entity)Main.player[npc.target]).position.Y - vector4.Y;
				float num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
				if (Main.expertMode && num18 < 120f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						Vector2 vector5 = default(Vector2);
						for (int j = 0; j < 5; j++)
						{
							((Vector2)(ref vector5))._002Ector((float)(j - 2), -4f);
							vector5.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							vector5.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							((Vector2)(ref vector5)).Normalize();
							vector5 *= 4f + (float)Main.rand.Next(-50, 51) * 0.01f;
							int attackDamage_ForProjectiles2 = npc.GetAttackDamage_ForProjectiles(9f, 9f);
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector4.X, vector4.Y, vector5.X, vector5.Y, 605, attackDamage_ForProjectiles2, 0f, Main.myPlayer, 0f, 0f, 0f);
							npc.localAI[0] = 30f;
						}
					}
				}
				else if (num18 < 200f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						num17 = ((Entity)Main.player[npc.target]).position.Y - vector4.Y - (float)Main.rand.Next(0, 200);
						num18 = (float)Math.Sqrt(num16 * num16 + num17 * num17);
						num18 = 4.5f / num18;
						num16 *= num18;
						num17 *= num18;
						npc.localAI[0] = 50f;
						Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector4.X, vector4.Y, num16, num17, 605, 9, 0f, Main.myPlayer, 0f, 0f, 0f);
					}
				}
			}
		}
		if (npc.type == 658)
		{
			flag = true;
			if (npc.localAI[0] > 0f)
			{
				npc.localAI[0] -= 1f;
			}
			if (!((Entity)npc).wet && ((Entity)Main.player[npc.target]).active && !Main.player[npc.target].dead && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				Player obj6 = Main.player[npc.target];
				Vector2 center = ((Entity)npc).Center;
				float num19 = ((Entity)obj6).Center.X - center.X;
				float num20 = ((Entity)obj6).Center.Y - center.Y;
				float num21 = (float)Math.Sqrt(num19 * num19 + num20 * num20);
				int num22 = NPC.CountNPCS(658);
				if (Main.expertMode && num22 < 5 && Math.Abs(num19) < 500f && Math.Abs(num20) < 550f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						Vector2 vector6 = default(Vector2);
						for (int k = 0; k < 3; k++)
						{
							((Vector2)(ref vector6))._002Ector((float)(k - 1), -4f);
							vector6.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							vector6.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.005f;
							((Vector2)(ref vector6)).Normalize();
							vector6 *= 6f + (float)Main.rand.Next(-50, 51) * 0.01f;
							if (num21 > 350f)
							{
								vector6 *= 2f;
							}
							else if (num21 > 250f)
							{
								vector6 *= 1.5f;
							}
							int attackDamage_ForProjectiles_MultiLerp = npc.GetAttackDamage_ForProjectiles_MultiLerp(15f, 17f, 20f);
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), center.X, center.Y, vector6.X, vector6.Y, 920, attackDamage_ForProjectiles_MultiLerp, 0f, Main.myPlayer, 0f, 0f, 0f);
							npc.localAI[0] = 25f;
							if (num22 > 4)
							{
								break;
							}
						}
					}
				}
				else if (Math.Abs(num19) < 500f && Math.Abs(num20) < 550f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					float num23 = num21;
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						num20 = ((Entity)Main.player[npc.target]).position.Y - center.Y - (float)Main.rand.Next(0, 200);
						num21 = (float)Math.Sqrt(num19 * num19 + num20 * num20);
						num21 = 4.5f / num21;
						num21 *= 2f;
						if (num23 > 350f)
						{
							num21 *= 2f;
						}
						else if (num23 > 250f)
						{
							num21 *= 1.5f;
						}
						num19 *= num21;
						num20 *= num21;
						npc.localAI[0] = 50f;
						int attackDamage_ForProjectiles_MultiLerp2 = npc.GetAttackDamage_ForProjectiles_MultiLerp(15f, 17f, 20f);
						Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), center.X, center.Y, num19, num20, 920, attackDamage_ForProjectiles_MultiLerp2, 0f, Main.myPlayer, 0f, 0f, 0f);
					}
				}
			}
		}
		if (npc.type == 659)
		{
			flag = true;
			if (npc.localAI[0] > 0f)
			{
				npc.localAI[0] -= 1f;
			}
			if (!((Entity)npc).wet && ((Entity)Main.player[npc.target]).active && !Main.player[npc.target].dead && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				Player obj7 = Main.player[npc.target];
				Vector2 center2 = ((Entity)npc).Center;
				float num24 = ((Entity)obj7).Center.X - center2.X;
				float num25 = ((Entity)obj7).Center.Y - center2.Y;
				float num26 = (float)Math.Sqrt(num24 * num24 + num25 * num25);
				float num27 = num26;
				if (Math.Abs(num24) < 500f && Math.Abs(num25) < 550f && Collision.CanHit(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						num25 = ((Entity)Main.player[npc.target]).position.Y - center2.Y - (float)Main.rand.Next(0, 200);
						num26 = (float)Math.Sqrt(num24 * num24 + num25 * num25);
						num26 = 4.5f / num26;
						num26 *= 2f;
						if (num27 > 350f)
						{
							num26 *= 1.75f;
						}
						else if (num27 > 250f)
						{
							num26 *= 1.25f;
						}
						num24 *= num26;
						num25 *= num26;
						npc.localAI[0] = 40f;
						if (Main.expertMode)
						{
							npc.localAI[0] = 30f;
						}
						int attackDamage_ForProjectiles_MultiLerp3 = npc.GetAttackDamage_ForProjectiles_MultiLerp(15f, 17f, 20f);
						Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), center2.X, center2.Y, num24, num25, 921, attackDamage_ForProjectiles_MultiLerp3, 0f, Main.myPlayer, 0f, 0f, 0f);
					}
				}
			}
		}
		if (npc.type == 204)
		{
			flag = true;
			if (npc.localAI[0] > 0f)
			{
				npc.localAI[0] -= 1f;
			}
			if (!((Entity)npc).wet && !Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				Vector2 vector7 = default(Vector2);
				((Vector2)(ref vector7))._002Ector(((Entity)npc).position.X + (float)((Entity)npc).width * 0.5f, ((Entity)npc).position.Y + (float)((Entity)npc).height * 0.5f);
				float num28 = ((Entity)Main.player[npc.target]).position.X + (float)((Entity)Main.player[npc.target]).width * 0.5f - vector7.X;
				float num29 = ((Entity)Main.player[npc.target]).position.Y - vector7.Y;
				float num30 = (float)Math.Sqrt(num28 * num28 + num29 * num29);
				if (Main.expertMode && num30 < 200f && Collision.CanHit(new Vector2(((Entity)npc).position.X, ((Entity)npc).position.Y - 20f), ((Entity)npc).width, ((Entity)npc).height + 20, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -40f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						Vector2 vector8 = default(Vector2);
						for (int l = 0; l < 5; l++)
						{
							((Vector2)(ref vector8))._002Ector((float)(l - 2), -2f);
							vector8.X *= 1f + (float)Main.rand.Next(-50, 51) * 0.02f;
							vector8.Y *= 1f + (float)Main.rand.Next(-50, 51) * 0.02f;
							((Vector2)(ref vector8)).Normalize();
							vector8 *= 3f + (float)Main.rand.Next(-50, 51) * 0.01f;
							int attackDamage_ForProjectiles3 = npc.GetAttackDamage_ForProjectiles(13f, 13f);
							Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector7.X, vector7.Y, vector8.X, vector8.Y, 176, attackDamage_ForProjectiles3, 0f, Main.myPlayer, 0f, 0f, 0f);
							npc.localAI[0] = 80f;
						}
					}
				}
				if (num30 < 400f && Collision.CanHit(new Vector2(((Entity)npc).position.X, ((Entity)npc).position.Y - 20f), ((Entity)npc).width, ((Entity)npc).height + 20, ((Entity)Main.player[npc.target]).position, ((Entity)Main.player[npc.target]).width, ((Entity)Main.player[npc.target]).height) && ((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] = -80f;
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity.X *= 0.9f;
					}
					if (Main.netMode != 1 && npc.localAI[0] == 0f)
					{
						num29 = ((Entity)Main.player[npc.target]).position.Y - vector7.Y - (float)Main.rand.Next(-30, 20);
						num29 -= num30 * 0.05f;
						num28 = ((Entity)Main.player[npc.target]).position.X - vector7.X - (float)Main.rand.Next(-20, 20);
						num30 = (float)Math.Sqrt(num28 * num28 + num29 * num29);
						num30 = 7f / num30;
						num28 *= num30;
						num29 *= num30;
						npc.localAI[0] = 65f;
						Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), vector7.X, vector7.Y, num28, num29, 176, 13, 0f, Main.myPlayer, 0f, 0f, 0f);
					}
				}
			}
		}
		if (npc.type == 59)
		{
			((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
			Lighting.AddLight((int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f), (int)((((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f), 1f, 0.3f, 0.1f);
			int num31 = Dust.NewDust(new Vector2(((Entity)npc).position.X, ((Entity)npc).position.Y), ((Entity)npc).width, ((Entity)npc).height, 6, ((Entity)npc).velocity.X * 0.2f, ((Entity)npc).velocity.Y * 0.2f, 100, default(Color), 1.7f);
			Main.dust[num31].noGravity = true;
			((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
		}
		if (npc.ai[2] > 1f)
		{
			npc.ai[2] -= 1f;
		}
		if (((Entity)npc).wet)
		{
			if (npc.collideY)
			{
				((Entity)npc).velocity.Y = -2f;
			}
			if (((Entity)npc).velocity.Y < 0f && npc.ai[3] == ((Entity)npc).position.X)
			{
				((Entity)npc).direction = ((Entity)npc).direction * -1;
				npc.ai[2] = 200f;
			}
			if (((Entity)npc).velocity.Y > 0f)
			{
				npc.ai[3] = ((Entity)npc).position.X;
			}
			if (npc.type == 59 && !Main.remixWorld)
			{
				if (((Entity)npc).velocity.Y > 2f)
				{
					((Entity)npc).velocity.Y *= 0.9f;
				}
				else if (npc.directionY < 0)
				{
					((Entity)npc).velocity.Y -= 0.8f;
				}
				((Entity)npc).velocity.Y -= 0.5f;
				if (((Entity)npc).velocity.Y < -10f)
				{
					((Entity)npc).velocity.Y = -10f;
				}
			}
			else
			{
				if (((Entity)npc).velocity.Y > 2f)
				{
					((Entity)npc).velocity.Y *= 0.9f;
				}
				((Entity)npc).velocity.Y -= 0.5f;
				if (((Entity)npc).velocity.Y < -4f)
				{
					((Entity)npc).velocity.Y = -4f;
				}
			}
			if (npc.ai[2] == 1f && flag)
			{
				npc.TargetClosest(true);
			}
		}
		npc.aiAction = 0;
		if (npc.ai[2] == 0f)
		{
			npc.ai[0] = -100f;
			npc.ai[2] = 1f;
			npc.TargetClosest(true);
		}
		if (((Entity)npc).velocity.Y == 0f)
		{
			if (npc.collideY && ((Entity)npc).oldVelocity.Y != 0f && Collision.SolidCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height))
			{
				((Entity)npc).position.X -= ((Entity)npc).velocity.X + (float)((Entity)npc).direction;
			}
			if (npc.ai[3] == ((Entity)npc).position.X)
			{
				((Entity)npc).direction = ((Entity)npc).direction * -1;
				npc.ai[2] = 200f;
			}
			npc.ai[3] = 0f;
			((Entity)npc).velocity.X *= 0.8f;
			if ((double)((Entity)npc).velocity.X > -0.1 && (double)((Entity)npc).velocity.X < 0.1)
			{
				((Entity)npc).velocity.X = 0f;
			}
			if (flag)
			{
				npc.ai[0] += 1f;
			}
			npc.ai[0] += 1f;
			if (npc.type == 59 && !Main.remixWorld)
			{
				npc.ai[0] += 2f;
			}
			if (npc.type == 71)
			{
				npc.ai[0] += 3f;
			}
			if (npc.type == 667)
			{
				npc.ai[0] += 3f;
			}
			if (npc.type == 138)
			{
				npc.ai[0] += 2f;
			}
			if (npc.type == 183)
			{
				npc.ai[0] += 1f;
			}
			if (npc.type == 658)
			{
				npc.ai[0] += 5f;
			}
			if (npc.type == 659)
			{
				npc.ai[0] += 3f;
			}
			if (npc.type == 304)
			{
				float num32 = (1 - npc.life / npc.lifeMax) * 10;
				npc.ai[0] += num32;
			}
			if (npc.type == 81)
			{
				if (npc.scale >= 0f)
				{
					npc.ai[0] += 4f;
				}
				else
				{
					npc.ai[0] += 1f;
				}
			}
			npc.AsSlime().TimeSinceLastJump++;
			if (npc.AsSlime().TimeSinceLastJump >= npc.AsSlime().JumpDelayBase + Main.rand.Next(npc.AsSlime().JumpDelayExtra.Min, npc.AsSlime().JumpDelayExtra.Max + 1))
			{
				npc.netUpdate = true;
				if (flag && npc.ai[2] == 1f)
				{
					npc.TargetClosest(true);
				}
				SlimeNPC slimeNPC = npc.AsSlime();
				StatModifier val2 = npc.AsSlime().JumpXSpeedModifier;
				float num33 = ((StatModifier)(ref val2)).ApplyTo(npc.AsSlime().JumpSpeed.X);
				val2 = npc.AsSlime().JumpYSpeedModifier;
				slimeNPC.JumpSpeed = new Vector2(num33, ((StatModifier)(ref val2)).ApplyTo(npc.AsSlime().JumpSpeed.Y));
				if (npc.AsSlime().OccasionalHighJumps)
				{
					if (npc.AsSlime().JumpsUntilNextHighJump <= 0)
					{
						ref float x = ref ((Entity)npc).velocity.X;
						float num34 = x;
						val2 = npc.AsSlime().HighJumpXModifier;
						x = num34 + ((StatModifier)(ref val2)).ApplyTo(npc.AsSlime().JumpSpeed.X) * (float)((Entity)npc).direction / movementModifier;
						ref Vector2 velocity = ref ((Entity)npc).velocity;
						val2 = npc.AsSlime().HighJumpYModifier;
						velocity.Y = (0f - ((StatModifier)(ref val2)).ApplyTo(npc.AsSlime().JumpSpeed.Y)) / movementModifier;
						npc.AsSlime().JumpsUntilNextHighJump = npc.AsSlime().HighJumpFrequency;
						npc.AsSlime().TimeSinceLastJump = 0;
						npc.ai[3] = ((Entity)npc).position.X;
					}
					else
					{
						((Entity)npc).velocity.X += npc.AsSlime().JumpSpeed.X * (float)((Entity)npc).direction / movementModifier;
						((Entity)npc).velocity.Y = (0f - npc.AsSlime().JumpSpeed.Y) / movementModifier;
						npc.AsSlime().JumpsUntilNextHighJump--;
						npc.AsSlime().TimeSinceLastJump = 0;
						npc.ai[3] = ((Entity)npc).position.X;
					}
				}
				else
				{
					((Entity)npc).velocity.X += npc.AsSlime().JumpSpeed.X * (float)((Entity)npc).direction / movementModifier;
					((Entity)npc).velocity.Y = (0f - npc.AsSlime().JumpSpeed.Y) / movementModifier;
					npc.AsSlime().TimeSinceLastJump = 0;
				}
			}
			else if (npc.AsSlime().TimeSinceLastJump >= npc.AsSlime().JumpDelayBase - 20)
			{
				npc.aiAction = 1;
			}
		}
		else if (npc.target < 255 && ((((Entity)npc).direction == 1 && ((Entity)npc).velocity.X < 3f) || (((Entity)npc).direction == -1 && ((Entity)npc).velocity.X > -3f)))
		{
			if (npc.collideX && Math.Abs(((Entity)npc).velocity.X) == 0.2f)
			{
				((Entity)npc).position.X -= 1.4f * (float)((Entity)npc).direction;
			}
			if (npc.collideY && ((Entity)npc).oldVelocity.Y != 0f && Collision.SolidCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height))
			{
				((Entity)npc).position.X -= ((Entity)npc).velocity.X + (float)((Entity)npc).direction;
			}
			if ((((Entity)npc).direction == -1 && (double)((Entity)npc).velocity.X < 0.01) || (((Entity)npc).direction == 1 && (double)((Entity)npc).velocity.X > -0.01))
			{
				((Entity)npc).velocity.X += 0.2f * (float)((Entity)npc).direction;
			}
			else
			{
				((Entity)npc).velocity.X *= 0.93f;
			}
		}
		return false;
	}

	public static int DetermineSlimeBonusItem(int slimeType, bool isBallooned)
	{
		int num = Main.rand.Next(4);
		if (isBallooned)
		{
			switch (Main.rand.Next(13))
			{
			default:
				return 4367;
			case 1:
				return 4368;
			case 2:
				return 4369;
			case 3:
				return 4370;
			case 4:
				return 4371;
			case 5:
				return 4612;
			case 6:
				return 4674;
			case 7:
			case 8:
			case 9:
				return 4343;
			case 10:
			case 11:
			case 12:
				return 4344;
			}
		}
		switch (num)
		{
		case 0:
			switch (Main.rand.Next(7))
			{
			case 0:
				return 290;
			case 1:
				return 292;
			case 2:
				return 296;
			case 3:
				return 2322;
			default:
				if (Main.netMode != 0 && Utils.NextBool(Main.rand, 2))
				{
					return 2997;
				}
				return 2350;
			}
		case 1:
			return Main.rand.Next(4) switch
			{
				0 => 8, 
				1 => 166, 
				2 => 965, 
				_ => 58, 
			};
		case 2:
			return Utils.Next<int>(Main.rand, (IList<int>)Sets.OreDropsFromSlime.Keys.ToList());
		default:
			return Main.rand.Next(3) switch
			{
				0 => 71, 
				1 => 72, 
				_ => 73, 
			};
		}
	}
}
