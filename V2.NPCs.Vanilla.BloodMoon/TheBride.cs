using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Voraria.TownNPCs.Enigma;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Amateur;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.BloodMoon;

public class TheBride : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public static bool V2TheBrideAI(NPC npc)
	{
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Unknown result type (might be due to invalid IL or missing references)
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		//IL_085e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		//IL_114e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1193: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)Main.player[npc.target]).position.Y + (float)((Entity)Main.player[npc.target]).height == ((Entity)npc).position.Y + (float)((Entity)npc).height)
		{
			npc.directionY = -1;
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
		bool flag8 = true;
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
		float acceleration = 0.07f;
		float maxWalkSpeed = 1f;
		acceleration /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
		maxWalkSpeed /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
		if (((Entity)npc).velocity.X < 0f - maxWalkSpeed || ((Entity)npc).velocity.X > maxWalkSpeed)
		{
			if (((Entity)npc).velocity.Y == 0f)
			{
				((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
			}
		}
		else if (((Entity)npc).velocity.X < maxWalkSpeed && ((Entity)npc).direction == 1)
		{
			((Entity)npc).velocity.X += acceleration;
			if (((Entity)npc).velocity.X > maxWalkSpeed)
			{
				((Entity)npc).velocity.X = maxWalkSpeed;
			}
		}
		else if (((Entity)npc).velocity.X > 0f - maxWalkSpeed && ((Entity)npc).direction == -1)
		{
			((Entity)npc).velocity.X -= acceleration;
			if (((Entity)npc).velocity.X < 0f - maxWalkSpeed)
			{
				((Entity)npc).velocity.X = 0f - maxWalkSpeed;
			}
		}
		Tile val;
		if (((Entity)npc).velocity.Y == 0f || flag)
		{
			int num181 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 7f) / 16;
			int num182 = (int)(((Entity)npc).position.Y - 9f) / 16;
			int num183 = (int)((Entity)npc).position.X / 16;
			int num184 = (int)(((Entity)npc).position.X + (float)((Entity)npc).width) / 16;
			int num185 = (int)(((Entity)npc).position.X + 8f) / 16;
			int num186 = (int)(((Entity)npc).position.X + (float)((Entity)npc).width - 8f) / 16;
			bool flag22 = false;
			for (int i = num185; i <= num186; i++)
			{
				if (i >= num183 && i <= num184 && ((Tilemap)(ref Main.tile))[i, num181] == (ArgumentException)null)
				{
					flag22 = true;
					continue;
				}
				if (((Tilemap)(ref Main.tile))[i, num182] != (ArgumentException)null)
				{
					val = ((Tilemap)(ref Main.tile))[i, num182];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[i, num182];
						if (tileSolid[((Tile)(ref val)).TileType])
						{
							flag5 = false;
							break;
						}
					}
				}
				if (flag22 || i < num183 || i > num184)
				{
					continue;
				}
				val = ((Tilemap)(ref Main.tile))[i, num181];
				if (((Tile)(ref val)).HasUnactuatedTile)
				{
					bool[] tileSolid2 = Main.tileSolid;
					val = ((Tilemap)(ref Main.tile))[i, num181];
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
		if (((Entity)npc).velocity.Y >= 0f && npc.directionY != 1)
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
									goto IL_0786;
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
						goto IL_0786;
					}
				}
			}
		}
		goto IL_0a55;
		IL_1014:
		if (flag8)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
		goto IL_1032;
		IL_1032:
		if (((Entity)npc).velocity.Y == 0f && flag6 && npc.ai[3] == 1f)
		{
			((Entity)npc).velocity.Y = -5f;
			((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
		}
		if (((Entity)npc).velocity.Y == 0f && Main.expertMode && ((Entity)Main.player[npc.target]).Bottom.Y < ((Entity)npc).Top.Y && Math.Abs(((Entity)npc).Center.X - ((Entity)Main.player[npc.target]).Center.X) < (float)(((Entity)Main.player[npc.target]).width * 3) && Collision.CanHit((Entity)(object)npc, (Entity)(object)Main.player[npc.target]) && ((Entity)npc).velocity.Y == 0f)
		{
			int num200 = 6;
			if (((Entity)Main.player[npc.target]).Bottom.Y > ((Entity)npc).Top.Y - (float)(num200 * 16))
			{
				((Entity)npc).velocity.Y = -7.9f;
				((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
			}
			else
			{
				int num201 = (int)(((Entity)npc).Center.X / 16f);
				int num202 = (int)(((Entity)npc).Bottom.Y / 16f) - 1;
				for (int num203 = num202; num203 > num202 - num200; num203--)
				{
					val = ((Tilemap)(ref Main.tile))[num201, num203];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] platforms = Sets.Platforms;
						val = ((Tilemap)(ref Main.tile))[num201, num203];
						if (platforms[((Tile)(ref val)).TileType])
						{
							((Entity)npc).velocity.Y = -7.9f;
							((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
							break;
						}
					}
				}
			}
		}
		goto IL_1258;
		IL_0786:
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid4 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
			if (tileSolid4[((Tile)(ref val)).TileType])
			{
				bool[] tileSolidTop2 = Main.tileSolidTop;
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
				if (!tileSolidTop2[((Tile)(ref val)).TileType])
				{
					val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
					if (!((Tile)(ref val)).IsHalfBlock)
					{
						goto IL_0a55;
					}
					val = ((Tilemap)(ref Main.tile))[num189, num190 - 4];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid5 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num189, num190 - 4];
						if (tileSolid5[((Tile)(ref val)).TileType])
						{
							bool[] tileSolidTop3 = Main.tileSolidTop;
							val = ((Tilemap)(ref Main.tile))[num189, num190 - 4];
							if (!tileSolidTop3[((Tile)(ref val)).TileType])
							{
								goto IL_0a55;
							}
						}
					}
				}
			}
		}
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 2];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid6 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189, num190 - 2];
			if (tileSolid6[((Tile)(ref val)).TileType])
			{
				bool[] tileSolidTop4 = Main.tileSolidTop;
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 2];
				if (!tileSolidTop4[((Tile)(ref val)).TileType])
				{
					goto IL_0a55;
				}
			}
		}
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 3];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid7 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189, num190 - 3];
			if (tileSolid7[((Tile)(ref val)).TileType])
			{
				bool[] tileSolidTop5 = Main.tileSolidTop;
				val = ((Tilemap)(ref Main.tile))[num189, num190 - 3];
				if (!tileSolidTop5[((Tile)(ref val)).TileType])
				{
					goto IL_0a55;
				}
			}
		}
		val = ((Tilemap)(ref Main.tile))[num189 - num188, num190 - 3];
		if (((Tile)(ref val)).HasUnactuatedTile)
		{
			bool[] tileSolid8 = Main.tileSolid;
			val = ((Tilemap)(ref Main.tile))[num189 - num188, num190 - 3];
			if (tileSolid8[((Tile)(ref val)).TileType])
			{
				goto IL_0a55;
			}
		}
		float num204 = num190 * 16;
		val = ((Tilemap)(ref Main.tile))[num189, num190];
		if (((Tile)(ref val)).IsHalfBlock)
		{
			num204 += 8f;
		}
		val = ((Tilemap)(ref Main.tile))[num189, num190 - 1];
		if (((Tile)(ref val)).IsHalfBlock)
		{
			num204 -= 8f;
		}
		if (num204 < vector39.Y + (float)((Entity)npc).height)
		{
			float num205 = vector39.Y + (float)((Entity)npc).height - num204;
			float num206 = 16.1f;
			if (num205 <= num206)
			{
				npc.gfxOffY += ((Entity)npc).position.Y + (float)((Entity)npc).height - num204;
				((Entity)npc).position.Y = num204 - (float)((Entity)npc).height;
				if (num205 < 9f)
				{
					npc.stepSpeed = 1f;
				}
				else
				{
					npc.stepSpeed = 2f;
				}
			}
		}
		goto IL_0a55;
		IL_1258:
		return false;
		IL_0a55:
		if (flag5)
		{
			int num207 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
			int num208 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 15f) / 16f);
			Tile tile = ((Tilemap)(ref Main.tile))[num207, num208 + 1];
			((Tile)(ref tile)).IsHalfBlock = false;
			val = ((Tilemap)(ref Main.tile))[num207, num208 - 1];
			int num209;
			if (((Tile)(ref val)).HasUnactuatedTile)
			{
				if (!TileLoader.IsClosedDoor(((Tilemap)(ref Main.tile))[num207, num208 - 1]))
				{
					val = ((Tilemap)(ref Main.tile))[num207, num208 - 1];
					num209 = ((((Tile)(ref val)).TileType == 388) ? 1 : 0);
				}
				else
				{
					num209 = 1;
				}
			}
			else
			{
				num209 = 0;
			}
			if (((uint)num209 & (flag8 ? 1u : 0u)) != 0)
			{
				npc.ai[2] += 1f;
				npc.ai[3] = 0f;
				if (npc.ai[2] >= 60f)
				{
					((Entity)npc).velocity.X = 0.5f * (float)(-((Entity)npc).direction);
					int num210 = 5;
					val = ((Tilemap)(ref Main.tile))[num207, num208 - 1];
					if (((Tile)(ref val)).TileType == 388)
					{
						num210 = 2;
					}
					npc.ai[1] += num210;
					npc.ai[2] = 0f;
					bool flag25 = false;
					if (npc.ai[1] >= 10f)
					{
						flag25 = true;
						npc.ai[1] = 10f;
					}
					WorldGen.KillTile(num207, num208 - 1, true, false, false);
					if (flag25 && Main.netMode != 1)
					{
						if (TileLoader.IsClosedDoor(((Tilemap)(ref Main.tile))[num207, num208 - 1]))
						{
							bool flag26 = WorldGen.OpenDoor(num207, num208 - 1, ((Entity)npc).direction);
							if (!flag26)
							{
								npc.ai[3] = num56;
								npc.netUpdate = true;
							}
							if (Main.netMode == 2 && flag26)
							{
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 0, (float)num207, (float)(num208 - 1), (float)((Entity)npc).direction, 0, 0, 0);
							}
						}
						val = ((Tilemap)(ref Main.tile))[num207, num208 - 1];
						if (((Tile)(ref val)).TileType == 388)
						{
							bool flag27 = WorldGen.ShiftTallGate(num207, num208 - 1, false, false);
							if (!flag27)
							{
								npc.ai[3] = num56;
								npc.netUpdate = true;
							}
							if (Main.netMode == 2 && flag27)
							{
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 4, (float)num207, (float)(num208 - 1), 0f, 0, 0, 0);
							}
						}
					}
				}
			}
			else
			{
				int num211 = npc.spriteDirection;
				if ((((Entity)npc).velocity.X < 0f && num211 == -1) || (((Entity)npc).velocity.X > 0f && num211 == 1))
				{
					if (((Entity)npc).height >= 32)
					{
						val = ((Tilemap)(ref Main.tile))[num207, num208 - 2];
						if (((Tile)(ref val)).HasUnactuatedTile)
						{
							bool[] tileSolid9 = Main.tileSolid;
							val = ((Tilemap)(ref Main.tile))[num207, num208 - 2];
							if (tileSolid9[((Tile)(ref val)).TileType])
							{
								val = ((Tilemap)(ref Main.tile))[num207, num208 - 3];
								if (((Tile)(ref val)).HasUnactuatedTile)
								{
									bool[] tileSolid10 = Main.tileSolid;
									val = ((Tilemap)(ref Main.tile))[num207, num208 - 3];
									if (tileSolid10[((Tile)(ref val)).TileType])
									{
										((Entity)npc).velocity.Y = -8f;
										((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
										npc.netUpdate = true;
										goto IL_1032;
									}
								}
								((Entity)npc).velocity.Y = -7f;
								((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
								npc.netUpdate = true;
								goto IL_1032;
							}
						}
					}
					val = ((Tilemap)(ref Main.tile))[num207, num208 - 1];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid11 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num207, num208 - 1];
						if (tileSolid11[((Tile)(ref val)).TileType])
						{
							((Entity)npc).velocity.Y = -6f;
							((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
							npc.netUpdate = true;
							goto IL_1032;
						}
					}
					if (((Entity)npc).position.Y + (float)((Entity)npc).height - (float)(num208 * 16) > 20f)
					{
						val = ((Tilemap)(ref Main.tile))[num207, num208];
						if (((Tile)(ref val)).HasUnactuatedTile)
						{
							val = ((Tilemap)(ref Main.tile))[num207, num208];
							if (!((Tile)(ref val)).TopSlope)
							{
								bool[] tileSolid12 = Main.tileSolid;
								val = ((Tilemap)(ref Main.tile))[num207, num208];
								if (tileSolid12[((Tile)(ref val)).TileType])
								{
									((Entity)npc).velocity.Y = -5f;
									((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
									npc.netUpdate = true;
									goto IL_1032;
								}
							}
						}
					}
					if (npc.directionY >= 0)
					{
						goto IL_1014;
					}
					val = ((Tilemap)(ref Main.tile))[num207, num208 + 1];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid13 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num207, num208 + 1];
						if (tileSolid13[((Tile)(ref val)).TileType])
						{
							goto IL_1014;
						}
					}
					val = ((Tilemap)(ref Main.tile))[num207 + ((Entity)npc).direction, num208 + 1];
					if (((Tile)(ref val)).HasUnactuatedTile)
					{
						bool[] tileSolid14 = Main.tileSolid;
						val = ((Tilemap)(ref Main.tile))[num207 + ((Entity)npc).direction, num208 + 1];
						if (tileSolid14[((Tile)(ref val)).TileType])
						{
							goto IL_1014;
						}
					}
					((Entity)npc).velocity.Y = -8f;
					((Entity)npc).velocity.Y /= 1f + (float)PredNPC.GetCurrentBellyWeight(npc);
					((Entity)npc).velocity.X *= 1.5f;
					npc.netUpdate = true;
					goto IL_1032;
				}
			}
		}
		else if (flag8)
		{
			npc.ai[1] = 0f;
			npc.ai[2] = 0f;
		}
		goto IL_1258;
	}

	public override void PostAI(NPC npc)
	{
		int num = 41;
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
		span[num2] = (TargetType.NPC, ModContent.NPCType<CloverBound>(), TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, ModContent.NPCType<Clover>(), TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 441, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 229, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 178, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 663, TargetPriorityLevel.Neutral);
		num2++;
		span[num2] = (TargetType.NPC, 209, TargetPriorityLevel.Neutral);
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
		span[num2] = (TargetType.Player, -1, TargetPriorityLevel.Neutral);
		num2++;
		List<(TargetType, int, TargetPriorityLevel)> diet = list;
		npc.DoContactGulpage(diet);
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 536;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.AsV2NPC().NewAIMethod = V2TheBrideAI;
		npc.AsFood().DefinedBaseSize = 1.04;
		npc.AsPred().MaxStomachCapacity = 1.7;
		npc.AsPred().BaseStomachacheMeterCapacity = 120.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.5;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(4.7);
		npc.AsPred().CanBeForceFed = CanTheBrideBeForceFed;
		npc.AsPred().OnForceFed = OnTheBrideForceFed;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		npc.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().StandardBurps = Burps.Humanoid.Zombie.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantBrideAndGroomGoal));
		npc.AsFood().ItemTheftRules = new List<ItemTheftRule>
		{
			TheBrideStuff.ItemTheftRules.WeddingVeil,
			TheBrideStuff.ItemTheftRules.WeddingDress
		};
	}

	public static bool CanTheBrideBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnTheBrideForceFed(NPC npc, Player player)
	{
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Forest.Zombie.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Forest.Zombie.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Forest.Zombie.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.BloodMoon.GroomAndBride.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.BloodMoon.GroomAndBride.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.BloodMoon.GroomAndBride.TheBride.1" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.BloodMoon.GroomAndBride.TheBride.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 0.8;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 17.0;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 12);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 4);
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(0.2 * Math.Sqrt(npc.AsPred().ExtraWeight)), 0);
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		npc.frame.Width = 150;
	}

	public override void ModifyHoverBoundingBox(NPC npc, ref Rectangle boundingBox)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		boundingBox = new Rectangle((int)((Entity)npc).Center.X - 17, (int)((Entity)npc).Center.Y - 25, 34, 50);
	}

	public static void OnKilledByDigestion_GrantBrideAndGroomGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null && predPlayer.AsPred().mealCount.ContainsKey("Terraria: The Groom") && predPlayer.AsPred().mealCount["Terraria: The Groom"] > 0)
		{
			ModContent.GetInstance<EatBrideAndGroom>().TrySetCompletion(predPlayer);
		}
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		int weightStage = npc.AsPred().GetVisualWeightStage(npc);
		string weightString = "_Weight" + ((weightStage == 0) ? "Base" : ((object)weightStage));
		int bellySize = npc.AsPred().GetVisualBellySize(npc);
		string bellyString = "_Belly" + ((bellySize == 0) ? "Base" : ((object)bellySize));
		string exactMainBodyTexture = "V2/NPCs/Vanilla/BloodMoon/TheBride" + weightString + bellyString;
		TextureAssets.Npc[536] = ModContent.Request<Texture2D>(exactMainBodyTexture, (AssetRequestMode)1);
		return true;
	}
}
