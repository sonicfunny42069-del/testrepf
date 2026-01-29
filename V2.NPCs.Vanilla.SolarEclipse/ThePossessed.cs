using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Voraria.TownNPCs.Enigma;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.SolarEclipse;

public class ThePossessed : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public static bool V2ThePossessedAI(NPC npc)
	{
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d90: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_098b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e16: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1005: Unknown result type (might be due to invalid IL or missing references)
		//IL_100a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_10dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_110d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1171: Unknown result type (might be due to invalid IL or missing references)
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b38: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1200: Unknown result type (might be due to invalid IL or missing references)
		npc.damage = npc.defDamage;
		if (((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height == ((Entity)npc).position.Y + (float)((Entity)npc).height)
		{
			npc.directionY = -1;
		}
		if (PredNPC.GetCurrentBellyWeight(npc) > 0.0)
		{
			npc.ai[2] = 0f;
			((Entity)npc).velocity.X *= 0.9f;
			npc.damage = (int)Math.Round((float)npc.defDamage / 2f);
			return false;
		}
		bool flag = false;
		bool flag5 = false;
		bool flag6 = false;
		if (((Entity)npc).velocity.X == 0f)
		{
			flag6 = true;
		}
		if (npc.justHit)
		{
			flag6 = false;
		}
		int num56 = 60;
		bool flag7 = false;
		if (((Entity)npc).velocity.Y == 0f && ((((Entity)npc).velocity.X > 0f && ((Entity)npc).direction < 0) || (((Entity)npc).velocity.X < 0f && ((Entity)npc).direction > 0)))
		{
			flag7 = true;
		}
		if (((Entity)npc).position.X == ((Entity)npc).oldPosition.X || npc.ai[3] >= (float)num56 || flag7)
		{
			npc.ai[3] += 1f;
		}
		else if ((double)Math.Abs(((Entity)npc).velocity.X) > 0.9 && npc.ai[3] > 0f)
		{
			npc.ai[3] -= 1f;
		}
		if (npc.ai[3] > (float)(num56 * 10))
		{
			npc.ai[3] = 0f;
		}
		if (npc.justHit)
		{
			npc.ai[3] = 0f;
		}
		if (npc.ai[3] == (float)num56)
		{
			npc.netUpdate = true;
		}
		Rectangle hitbox = ((Entity)Main.player[npc.target]).Hitbox;
		if (((Rectangle)(ref hitbox)).Intersects(((Entity)npc).Hitbox))
		{
			npc.ai[3] = 0f;
		}
		GameModeData gameModeInfo = Main.GameModeInfo;
		npc.knockBackResist = 0.45f * ((GameModeData)(ref gameModeInfo)).KnockbackToEnemiesMultiplier;
		if (npc.ai[2] == 1f)
		{
			npc.knockBackResist = 0f;
		}
		bool flag11 = false;
		int num75 = (int)((Entity)npc).Center.X / 16;
		int num76 = (int)((Entity)npc).Center.Y / 16;
		Tile val;
		for (int i = num75 - 1; i <= num75 + 1; i++)
		{
			for (int j = num76 - 1; j <= num76 + 1; j++)
			{
				val = ((Tilemap)(ref Main.tile))[i, j];
				if (((Tile)(ref val)).WallType > 0)
				{
					flag11 = true;
					break;
				}
			}
			if (flag11)
			{
				break;
			}
		}
		if (npc.ai[2] == 0f && flag11)
		{
			if (((Entity)npc).velocity.Y == 0f)
			{
				flag = true;
				((Entity)npc).velocity.Y = -4.6f;
				((Entity)npc).velocity.X *= 1.3f;
			}
			else if (((Entity)npc).velocity.Y > 0f && !Main.player[npc.target].dead)
			{
				npc.ai[2] = 1f;
			}
		}
		if (flag11 && npc.ai[2] == 1f && !Main.player[npc.target].dead && Collision.CanHit(((Entity)npc).Center, 1, 1, ((Entity)Main.player[npc.target]).Center, 1, 1))
		{
			Vector2 vector23 = ((Entity)Main.player[npc.target]).Center - ((Entity)npc).Center;
			float num79 = ((Vector2)(ref vector23)).Length();
			((Vector2)(ref vector23)).Normalize();
			vector23 *= 4.5f + num79 / 300f;
			((Entity)npc).velocity = (((Entity)npc).velocity * 29f + vector23) / 30f;
			npc.noGravity = true;
			npc.ai[2] = 1f;
			return false;
		}
		npc.noGravity = false;
		npc.ai[2] = 0f;
		if (npc.ai[3] < (float)num56 && NPC.DespawnEncouragement_AIStyle3_Fighters_NotDiscouraged(npc.type, ((Entity)npc).position, npc))
		{
			npc.TargetClosest(true);
			if (npc.directionY > 0 && ((Entity)Main.player[npc.target]).Center.Y <= ((Entity)npc).Bottom.Y)
			{
				npc.directionY = -1;
			}
		}
		else if (!(npc.ai[2] > 0f) || !NPC.DespawnEncouragement_AIStyle3_Fighters_CanBeBusyWithAction(npc.type))
		{
			if (Main.IsItDay() && (double)(((Entity)npc).position.Y / 16f) < Main.worldSurface)
			{
				npc.EncourageDespawn(10);
			}
			if (((Entity)npc).velocity.X == 0f)
			{
				if (((Entity)npc).velocity.Y == 0f)
				{
					npc.ai[0] += 1f;
					if (npc.ai[0] >= 2f)
					{
						((Entity)npc).direction = ((Entity)npc).direction * -1;
						npc.spriteDirection = ((Entity)npc).direction;
						npc.ai[0] = 0f;
					}
				}
			}
			else
			{
				npc.ai[0] = 0f;
			}
			if (((Entity)npc).direction == 0)
			{
				((Entity)npc).direction = 1;
			}
		}
		float maxSpeed = 3.25f;
		gameModeInfo = Main.GameModeInfo;
		if (((GameModeData)(ref gameModeInfo)).IsMasterMode)
		{
			maxSpeed *= 1.3f;
		}
		else
		{
			gameModeInfo = Main.GameModeInfo;
			if (((GameModeData)(ref gameModeInfo)).IsExpertMode)
			{
				maxSpeed *= 1.15f;
			}
		}
		float accel = 0.075f;
		gameModeInfo = Main.GameModeInfo;
		if (((GameModeData)(ref gameModeInfo)).IsMasterMode)
		{
			accel *= 1.5f;
		}
		else
		{
			gameModeInfo = Main.GameModeInfo;
			if (((GameModeData)(ref gameModeInfo)).IsExpertMode)
			{
				accel *= 1.25f;
			}
		}
		float decel = 0.8f;
		gameModeInfo = Main.GameModeInfo;
		if (((GameModeData)(ref gameModeInfo)).IsMasterMode)
		{
			decel = 0.75f;
		}
		else
		{
			gameModeInfo = Main.GameModeInfo;
			if (((GameModeData)(ref gameModeInfo)).IsExpertMode)
			{
				decel = 0.7f;
			}
		}
		if (((Entity)npc).velocity.X < 0f - maxSpeed || ((Entity)npc).velocity.X > maxSpeed)
		{
			if (((Entity)npc).velocity.Y == 0f)
			{
				((Entity)npc).velocity = ((Entity)npc).velocity * decel;
			}
		}
		else if (((Entity)npc).velocity.X < maxSpeed && ((Entity)npc).direction == 1)
		{
			((Entity)npc).velocity.X += accel;
			if (((Entity)npc).velocity.X > maxSpeed)
			{
				((Entity)npc).velocity.X = maxSpeed;
			}
		}
		else if (((Entity)npc).velocity.X > 0f - maxSpeed && ((Entity)npc).direction == -1)
		{
			((Entity)npc).velocity.X -= accel;
			if (((Entity)npc).velocity.X < 0f - maxSpeed)
			{
				((Entity)npc).velocity.X = 0f - maxSpeed;
			}
		}
		if (((Entity)npc).velocity.Y == 0f || flag)
		{
			int num181 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 7f) / 16;
			int num182 = (int)(((Entity)npc).position.Y - 9f) / 16;
			int num183 = (int)((Entity)npc).position.X / 16;
			int num184 = (int)(((Entity)npc).position.X + (float)((Entity)npc).width) / 16;
			int num185 = (int)(((Entity)npc).position.X + 8f) / 16;
			int num186 = (int)(((Entity)npc).position.X + (float)((Entity)npc).width - 8f) / 16;
			bool flag22 = false;
			for (int k = num185; k <= num186; k++)
			{
				if (k >= num183 && k <= num184 && ((Tilemap)(ref Main.tile))[k, num181] == (ArgumentException)null)
				{
					flag22 = true;
					continue;
				}
				if (((Tilemap)(ref Main.tile))[k, num182] != (ArgumentException)null)
				{
					val = ((Tilemap)(ref Main.tile))[k, num182];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[k, num182];
						if (tileSolid[((Tile)(ref val)).TileType])
						{
							flag5 = false;
							break;
						}
					}
				}
				if (flag22 || k < num183 || k > num184)
				{
					continue;
				}
				val = ((Tilemap)(ref Main.tile))[k, num181];
				if (((Tile)(ref val)).HasUnactuatedTile)
				{
					bool[] tileSolid2 = Main.tileSolid;
					val = ((Tilemap)(ref Main.tile))[k, num181];
					if (tileSolid2[((Tile)(ref val)).TileType])
					{
						flag5 = true;
					}
				}
			}
			if (!flag5 && ((Entity)npc).velocity.Y < 0f)
			{
				((Entity)npc).velocity.Y = 0f;
			}
			if (flag22)
			{
				return false;
			}
		}
		int num188;
		Vector2 vector39;
		int num189;
		int num190;
		if (((Entity)npc).velocity.Y >= 0f)
		{
			num188 = 0;
			if (((Entity)npc).velocity.X < 0f)
			{
				num188 = -1;
			}
			if (((Entity)npc).velocity.X > 0f)
			{
				num188 = 1;
			}
			vector39 = ((Entity)npc).position;
			vector39.X += ((Entity)npc).velocity.X;
			num189 = (int)((vector39.X + (float)(((Entity)npc).width / 2) + (float)((((Entity)npc).width / 2 + 1) * num188)) / 16f);
			num190 = (int)((vector39.Y + (float)((Entity)npc).height - 1f) / 16f);
			if (WorldGen.InWorld(num189, num190, 4) && (float)(num189 * 16) < vector39.X + (float)((Entity)npc).width && (float)(num189 * 16 + 16) > vector39.X)
			{
				val = ((Tilemap)(ref Main.tile))[num189, num190];
				if (((Tile)(ref val)).HasUnactuatedTile)
				{
					val = ((Tilemap)(ref Main.tile))[num189, num190];
					if (!((Tile)(ref val)).TopSlope)
					{
						val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
						if (!((Tile)(ref val)).TopSlope)
						{
							bool[] tileSolid3 = Main.tileSolid;
							val = ((Tilemap)(ref Main.tile))[num189, num190];
							if (tileSolid3[((Tile)(ref val)).TileType])
							{
								bool[] tileSolidTop = Main.tileSolidTop;
								val = ((Tilemap)(ref Main.tile))[num189, num190];
								if (!tileSolidTop[((Tile)(ref val)).TileType])
								{
									goto IL_0a60;
								}
							}
						}
					}
				}
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
				if (((Tile)(ref val)).IsHalfBlock)
				{
					val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						goto IL_0a60;
					}
				}
			}
		}
		goto IL_0d2f;
		IL_122e:
		return false;
		IL_0d2f:
		if (flag5)
		{
			int num194 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
			int num195 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 15f) / 16f);
			Tile tile = ((Tilemap)(ref Main.tile))[num194, num195 + 1];
			((Tile)(ref tile)).IsHalfBlock = false;
			int num197 = npc.spriteDirection;
			if ((((Entity)npc).velocity.X < 0f && num197 == -1) || (((Entity)npc).velocity.X > 0f && num197 == 1))
			{
				if (((Entity)npc).height >= 32)
				{
					val = ((Tilemap)(ref Main.tile))[num194, num195 - 2];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid4 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num194, num195 - 2];
						if (tileSolid4[((Tile)(ref val)).TileType])
						{
							val = ((Tilemap)(ref Main.tile))[num194, num195 - 3];
							if (((Tile)(ref val)).HasUnactuatedTile)
							{
								bool[] tileSolid5 = Main.tileSolid;
								val = ((Tilemap)(ref Main.tile))[num194, num195 - 3];
								if (tileSolid5[((Tile)(ref val)).TileType])
								{
									((Entity)npc).velocity.Y = -8f;
									npc.netUpdate = true;
									goto IL_107c;
								}
							}
							((Entity)npc).velocity.Y = -7f;
							npc.netUpdate = true;
							goto IL_107c;
						}
					}
				}
				val = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
				if (((Tile)(ref val)).HasUnactuatedTile)
				{
					bool[] tileSolid6 = Main.tileSolid;
					val = ((Tilemap)(ref Main.tile))[num194, num195 - 1];
					if (tileSolid6[((Tile)(ref val)).TileType])
					{
						((Entity)npc).velocity.Y = -6f;
						npc.netUpdate = true;
						goto IL_107c;
					}
				}
				if (((Entity)npc).position.Y + (float)((Entity)npc).height - (float)(num195 * 16) > 20f)
				{
					val = ((Tilemap)(ref Main.tile))[num194, num195];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						val = ((Tilemap)(ref Main.tile))[num194, num195];
						if (!((Tile)(ref val)).TopSlope)
						{
							bool[] tileSolid7 = Main.tileSolid;
							val = ((Tilemap)(ref Main.tile))[num194, num195];
							if (tileSolid7[((Tile)(ref val)).TileType])
							{
								((Entity)npc).velocity.Y = -5f;
								npc.netUpdate = true;
								goto IL_107c;
							}
						}
					}
				}
				if (npc.directionY < 0)
				{
					val = ((Tilemap)(ref Main.tile))[num194, num195 + 1];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid8 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num194, num195 + 1];
						if (tileSolid8[((Tile)(ref val)).TileType])
						{
							goto IL_107c;
						}
					}
					val = ((Tilemap)(ref Main.tile))[num194 + ((Entity)npc).direction, num195 + 1];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid9 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num194 + ((Entity)npc).direction, num195 + 1];
						if (tileSolid9[((Tile)(ref val)).TileType])
						{
							goto IL_107c;
						}
					}
					((Entity)npc).velocity.Y = -8f;
					((Entity)npc).velocity.X *= 1.5f;
					if (((Entity)npc).velocity.X > maxSpeed)
					{
						((Entity)npc).velocity.X = maxSpeed;
					}
					if (((Entity)npc).velocity.X < 0f - maxSpeed)
					{
						((Entity)npc).velocity.X = 0f - maxSpeed;
					}
					npc.netUpdate = true;
				}
				goto IL_107c;
			}
		}
		goto IL_122e;
		IL_0a60:
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid10 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
			if (tileSolid10[((Tile)(ref val)).TileType])
			{
				bool[] tileSolidTop2 = Main.tileSolidTop;
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
				if (!tileSolidTop2[((Tile)(ref val)).TileType])
				{
					val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
					if (!((Tile)(ref val)).IsHalfBlock)
					{
						goto IL_0d2f;
					}
					val = ((Tilemap)(ref Main.tile))[num189, num190 - 4];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid11 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num189, num190 - 4];
						if (tileSolid11[((Tile)(ref val)).TileType])
						{
							bool[] tileSolidTop3 = Main.tileSolidTop;
							val = ((Tilemap)(ref Main.tile))[num189, num190 - 4];
							if (!tileSolidTop3[((Tile)(ref val)).TileType])
							{
								goto IL_0d2f;
							}
						}
					}
				}
			}
		}
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 2];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid12 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189, num190 - 2];
			if (tileSolid12[((Tile)(ref val)).TileType])
			{
				bool[] tileSolidTop4 = Main.tileSolidTop;
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 2];
				if (!tileSolidTop4[((Tile)(ref val)).TileType])
				{
					goto IL_0d2f;
				}
			}
		}
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 3];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid13 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189, num190 - 3];
			if (tileSolid13[((Tile)(ref val)).TileType])
			{
				bool[] tileSolidTop5 = Main.tileSolidTop;
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 3];
				if (!tileSolidTop5[((Tile)(ref val)).TileType])
				{
					goto IL_0d2f;
				}
			}
		}
		val = ((Tilemap)(ref Main.tile))[num189 - num188, num190 - 3];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid14 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189 - num188, num190 - 3];
			if (tileSolid14[((Tile)(ref val)).TileType])
			{
				goto IL_0d2f;
			}
		}
		float num198 = num190 * 16;
		val = ((Tilemap)(ref Main.tile))[num189, num190];
		if (((Tile)(ref val)).IsHalfBlock)
		{
			num198 += 8f;
		}
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
		if (((Tile)(ref val)).IsHalfBlock)
		{
			num198 -= 8f;
		}
		if (num198 < vector39.Y + (float)((Entity)npc).height)
		{
			float num199 = vector39.Y + (float)((Entity)npc).height - num198;
			float num200 = 16.1f;
			if (num199 <= num200)
			{
				npc.gfxOffY += ((Entity)npc).position.Y + (float)((Entity)npc).height - num198;
				((Entity)npc).position.Y = num198 - (float)((Entity)npc).height;
				if (num199 < 9f)
				{
					npc.stepSpeed = 1f;
				}
				else
				{
					npc.stepSpeed = 2f;
				}
			}
		}
		goto IL_0d2f;
		IL_107c:
		if (((Entity)npc).velocity.Y == 0f && flag6 && npc.ai[3] == 1f)
		{
			((Entity)npc).velocity.Y = -5f;
		}
		if (((Entity)npc).velocity.Y == 0f && Main.expertMode && ((Entity)Main.player[npc.target]).Bottom.Y < ((Entity)npc).Top.Y && Math.Abs(((Entity)npc).Center.X - ((Entity)Main.player[npc.target]).Center.X) < (float)(((Entity)Main.player[npc.target]).width * 3) && Collision.CanHit((Entity)(object)npc, (Entity)(object)Main.player[npc.target]) && ((Entity)npc).velocity.Y == 0f)
		{
			int num201 = 6;
			if (((Entity)Main.player[npc.target]).Bottom.Y > ((Entity)npc).Top.Y - (float)(num201 * 16))
			{
				((Entity)npc).velocity.Y = -7.9f;
			}
			else
			{
				int num202 = (int)(((Entity)npc).Center.X / 16f);
				int num203 = (int)(((Entity)npc).Bottom.Y / 16f) - 1;
				for (int num204 = num203; num204 > num203 - num201; num204--)
				{
					val = ((Tilemap)(ref Main.tile))[num202, num204];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] platforms = Sets.Platforms;
						val = ((Tilemap)(ref Main.tile))[num202, num204];
						if (platforms[((Tile)(ref val)).TileType])
						{
							((Entity)npc).velocity.Y = -7.9f;
							break;
						}
					}
				}
			}
		}
		goto IL_122e;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 469;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Other;
		npc.AsV2NPC().NewAIMethod = V2ThePossessedAI;
		npc.AsFood().DefinedBaseSize = 1.1;
		npc.AsPred().MaxStomachCapacity = 4.44;
		npc.AsPred().BaseStomachacheMeterCapacity = 800.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.4;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().CanBeForceFed = CanPossessedBeForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 0.4;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		npc.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		npc.AsFood().OnDigestedBy = PreyNPC.OnKilledByDigestion_GrantLivePreyGoal;
	}

	public static bool CanPossessedBeForceFed(NPC npc)
	{
		return true;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Mods.V2.Death.DigestedPlayer.SpecificNPC.SolarEclipse.ThePossessed.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.SolarEclipse.ThePossessed.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.SolarEclipse.ThePossessed.3" }));
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.SolarEclipse.ThePossessed.Hardcore");
		}
	}

	public override void PostAI(NPC npc)
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
		span[num2] = (TargetType.NPC, 18, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 38, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 207, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 633, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 20, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, ModContent.NPCType<LucindaBound>(), TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, ModContent.NPCType<Lucinda>(), TargetPriorityLevel.Neutral);
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
		span[num2] = (TargetType.NPC, 354, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 353, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 54, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 123, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 124, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 208, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 106, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 108, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 441, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 229, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 178, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, ModContent.NPCType<CloverBound>(), TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, ModContent.NPCType<Clover>(), TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 663, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 209, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 48, TargetPriorityLevel.Neutral);
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
		span[num2] = (TargetType.NPC, 195, TargetPriorityLevel.High);
		num2++;
		span[num2] = (TargetType.NPC, 196, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.Player, -1, TargetPriorityLevel.High);
		num2++;
		List<(TargetType, int, TargetPriorityLevel)> diet = list;
		if (PredNPC.GetCurrentBellyWeight(npc) < npc.AsPred().MaxStomachCapacity * 0.800000011920929)
		{
			npc.DoContactGulpage(diet);
		}
	}

	public override void ModifyHitNPC(NPC npc, NPC target, ref HitModifiers modifiers)
	{
		((GlobalNPC)this).ModifyHitNPC(npc, target, ref modifiers);
	}

	public override void ModifyHitPlayer(NPC npc, Player target, ref HurtModifiers modifiers)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		double fullnessRatio = PredNPC.GetCurrentBellyWeight(npc) / npc.AsPred().MaxStomachCapacity;
		ref StatModifier finalDamage = ref modifiers.FinalDamage;
		finalDamage *= 0.2f + Math.Max(0.8f - (float)fullnessRatio, 0f);
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 2.5;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 24.0;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 2);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.375 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 10);
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(4.0 * Math.Sqrt(npc.AsPred().ExtraWeight)), 0);
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

	public override void ModifyHoverBoundingBox(NPC npc, ref Rectangle boundingBox)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		if (PredNPC.GetCurrentBellyWeight(npc) > 0.0)
		{
			int num = (int)((Entity)npc).Center.X;
			int num2 = num - npc.AsPred().GetVisualBellySize(npc) switch
			{
				0 => 21, 
				1 => 21, 
				2 => 21, 
				3 => 21, 
				4 => 21, 
				5 => 21, 
				6 => 22, 
				7 => 25, 
				8 => 28, 
				9 => 31, 
				10 => 34, 
				_ => 21, 
			};
			int num3 = (int)((Entity)npc).Center.Y;
			int num4 = num3 - npc.AsPred().GetVisualBellySize(npc) switch
			{
				0 => 16, 
				1 => 16, 
				2 => 16, 
				3 => 18, 
				4 => 19, 
				5 => 20, 
				6 => 22, 
				7 => 24, 
				8 => 26, 
				9 => 30, 
				10 => 32, 
				_ => 16, 
			};
			boundingBox = new Rectangle(num2, num4, npc.AsPred().GetVisualBellySize(npc) switch
			{
				0 => 42, 
				1 => 42, 
				2 => 42, 
				3 => 42, 
				4 => 42, 
				5 => 42, 
				6 => 44, 
				7 => 50, 
				8 => 56, 
				9 => 62, 
				10 => 66, 
				_ => 42, 
			}, npc.AsPred().GetVisualBellySize(npc) switch
			{
				0 => 32, 
				1 => 32, 
				2 => 32, 
				3 => 36, 
				4 => 38, 
				5 => 40, 
				6 => 44, 
				7 => 48, 
				8 => 52, 
				9 => 60, 
				10 => 64, 
				_ => 32, 
			});
		}
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		if (PredNPC.GetCurrentBellyWeight(npc) > 0.0)
		{
			string possessedGluttonTummyTypeString = "_BasicBellySheet";
			string possessedGluttonWeightStageString = ((GetVisualWeightStage(npc) > 0) ? ("_WeightGain" + GetVisualWeightStage(npc)) : "_BaseWeight");
			string text = "V2/NPCs/Vanilla/SolarEclipse/ThePossessed" + possessedGluttonWeightStageString + possessedGluttonTummyTypeString;
			SpriteEffects val = ((((Entity)npc).direction != -1) ? ((SpriteEffects)1) : ((SpriteEffects)0));
			SpriteEffects spriteEffects = val;
			Texture2D texture = ModContent.Request<Texture2D>(text, (AssetRequestMode)1).Value;
			Rectangle sourceRectangle = default(Rectangle);
			((Rectangle)(ref sourceRectangle))._002Ector(72 * npc.AsPred().GetVisualBellySize(npc), 0, 70, 70);
			Vector2 origin = default(Vector2);
			((Vector2)(ref origin))._002Ector(35f, 55f);
			spriteBatch.Draw(texture, ((Entity)npc).Center - screenPos + new Vector2(0f, npc.gfxOffY), (Rectangle?)sourceRectangle, drawColor, npc.rotation, origin, 1f, spriteEffects, 0f);
			return false;
		}
		return true;
	}
}
