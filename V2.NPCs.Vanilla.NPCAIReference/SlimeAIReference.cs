using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace V2.NPCs.Vanilla.NPCAIReference;

public static class SlimeAIReference
{
	public static bool AI_001_Slimes(NPC npc)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_091a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0883: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_107b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1252: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_125a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1264: Unknown result type (might be due to invalid IL or missing references)
		//IL_126e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1278: Unknown result type (might be due to invalid IL or missing references)
		//IL_1736: Unknown result type (might be due to invalid IL or missing references)
		//IL_173b: Unknown result type (might be due to invalid IL or missing references)
		//IL_173e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1748: Unknown result type (might be due to invalid IL or missing references)
		//IL_1752: Unknown result type (might be due to invalid IL or missing references)
		//IL_175c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1512: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_1183: Unknown result type (might be due to invalid IL or missing references)
		//IL_118a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d47: Unknown result type (might be due to invalid IL or missing references)
		//IL_2169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_186a: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c05: Unknown result type (might be due to invalid IL or missing references)
		//IL_2834: Unknown result type (might be due to invalid IL or missing references)
		//IL_1667: Unknown result type (might be due to invalid IL or missing references)
		//IL_166e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1923: Unknown result type (might be due to invalid IL or missing references)
		//IL_192a: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1413: Unknown result type (might be due to invalid IL or missing references)
		//IL_1418: Unknown result type (might be due to invalid IL or missing references)
		//IL_1423: Unknown result type (might be due to invalid IL or missing references)
		//IL_142a: Unknown result type (might be due to invalid IL or missing references)
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1468: Unknown result type (might be due to invalid IL or missing references)
		//IL_146f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1476: Unknown result type (might be due to invalid IL or missing references)
		//IL_147d: Unknown result type (might be due to invalid IL or missing references)
		//IL_143c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1443: Unknown result type (might be due to invalid IL or missing references)
		//IL_1448: Unknown result type (might be due to invalid IL or missing references)
		//IL_2702: Unknown result type (might be due to invalid IL or missing references)
		//IL_2714: Unknown result type (might be due to invalid IL or missing references)
		if (npc.type == 1 && (npc.ai[1] == 1f || npc.ai[1] == 2f || npc.ai[1] == 3f))
		{
			npc.ai[1] = -1f;
		}
		if (npc.type == 1 && npc.ai[1] == 75f)
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
		if (npc.type == 1 && npc.ai[1] == 0f && Main.netMode != 1 && npc.value > 0f)
		{
			npc.ai[1] = -1f;
			if (Main.remixWorld && npc.ai[0] != -999f && Utils.NextBool(Main.rand, 3))
			{
				npc.ai[1] = 75f;
				npc.netUpdate = true;
			}
			else if (Utils.NextBool(Main.rand, 20))
			{
				int num2 = DetermineSlimeBonusItem(npc.ai[0] == -999f);
				npc.ai[1] = num2;
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
			if (Main.rand.Next(30) == 0)
			{
				((Entity)npc).position = ((Entity)npc).position + npc.netOffset;
				int num6 = Dust.NewDust(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 14, 0f, 0f, npc.alpha, npc.color, 1f);
				Dust obj2 = Main.dust[num6];
				obj2.velocity *= 0.3f;
				((Entity)npc).position = ((Entity)npc).position - npc.netOffset;
			}
		}
		if ((npc.type == 377 || npc.type == 446) && npc.target != 255 && !Main.player[npc.target].dead && Vector2.Distance(((Entity)npc).Center, ((Entity)Main.player[npc.target]).Center) <= 200f && !((Entity)npc).wet)
		{
			flag = true;
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
		if (npc.type == 147 && Main.rand.Next(10) == 0)
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
			if (((Vector2)(ref ((Entity)npc).velocity)).Length() > 1f || Main.rand.Next(4) != 0)
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
			if ((((Vector2)(ref ((Entity)npc).velocity)).Length() > 1f && Main.rand.Next(3) == 0) || Main.rand.Next(5) == 0)
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
			if (Main.rand.Next(8) == 0)
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
		if (npc.type == 377 || npc.type == 446)
		{
			if (npc.localAI[2] < 90f)
			{
				npc.localAI[2] += 1f;
			}
			else
			{
				npc.friendly = false;
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
			if (npc.type == 377 || npc.type == 446)
			{
				npc.ai[0] += 3f;
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
			float num33 = -1000f;
			if (npc.type == 659)
			{
				num33 = -500f;
			}
			if (npc.type == 667)
			{
				num33 = -400f;
			}
			int num34 = 0;
			if (npc.ai[0] >= 0f)
			{
				num34 = 1;
			}
			if (npc.ai[0] >= num33 && npc.ai[0] <= num33 * 0.5f)
			{
				num34 = 2;
			}
			if (npc.ai[0] >= num33 * 2f && npc.ai[0] <= num33 * 1.5f)
			{
				num34 = 3;
			}
			if (num34 > 0)
			{
				npc.netUpdate = true;
				if (flag && npc.ai[2] == 1f)
				{
					npc.TargetClosest(true);
				}
				if (num34 == 3)
				{
					((Entity)npc).velocity.Y = -8f;
					if (npc.type == 59 && !Main.remixWorld)
					{
						((Entity)npc).velocity.Y -= 2f;
					}
					((Entity)npc).velocity.X += 3 * ((Entity)npc).direction;
					if (npc.type == 59 && !Main.remixWorld)
					{
						((Entity)npc).velocity.X += 0.5f * (float)((Entity)npc).direction;
					}
					npc.ai[0] = -200f;
					npc.ai[3] = ((Entity)npc).position.X;
				}
				else
				{
					((Entity)npc).velocity.Y = -6f;
					((Entity)npc).velocity.X += 2 * ((Entity)npc).direction;
					if (npc.type == 59 && !Main.remixWorld)
					{
						((Entity)npc).velocity.X += 2 * ((Entity)npc).direction;
					}
					npc.ai[0] = -120f;
					if (num34 == 1)
					{
						npc.ai[0] += num33;
					}
					else
					{
						npc.ai[0] += num33 * 2f;
					}
				}
				if (npc.type == 659)
				{
					((Entity)npc).velocity.Y *= 1.6f;
					((Entity)npc).velocity.X *= 1.2f;
				}
				if (npc.type == 685)
				{
					((Entity)npc).velocity.Y *= 0.5f;
					((Entity)npc).velocity.X *= 0.2f;
					if (Main.rand.Next(2) == 0)
					{
						((Entity)npc).direction = ((Entity)npc).direction * -1;
					}
				}
				if (npc.type == 141)
				{
					((Entity)npc).velocity.Y *= 1.3f;
					((Entity)npc).velocity.X *= 1.2f;
				}
				if (npc.type == 377 || npc.type == 446)
				{
					((Entity)npc).velocity.Y *= 0.9f;
					((Entity)npc).velocity.X *= 0.6f;
					if (flag)
					{
						((Entity)npc).direction = -((Entity)npc).direction;
						((Entity)npc).velocity.X *= -1f;
					}
					int num35 = (int)(((Entity)npc).Center.X / 16f);
					int j2 = (int)(((Entity)npc).Center.Y / 16f) - 1;
					if (WorldGen.SolidTile(num35, j2, false) && 0f - ((Entity)npc).velocity.Y + (float)((Entity)npc).height > 16f)
					{
						((Entity)npc).velocity.Y = -(16 - ((Entity)npc).height);
					}
				}
			}
			else if (npc.ai[0] >= -30f)
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

	public static int DetermineSlimeBonusItem(bool isBallooned)
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
