using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.NPCs;

public class FatFuckMethods
{
	public static string FatassDeathReason(NPC npc, Player victim)
	{
		int num = 7;
		List<string> list = new List<string>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<string> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.1";
		num2++;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.2";
		num2++;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.3";
		num2++;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.4";
		num2++;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.5";
		num2++;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.6";
		num2++;
		span[num2] = "Mods.V2.Death.FlattenedByAFatAss.Universal.7";
		num2++;
		List<string> deathMessageKeyList = list;
		return Language.GetTextValueWith(Utils.NextFromCollection<string>(Main.rand, deathMessageKeyList), (object)new
		{
			Player = victim.name,
			NPC = npc.TypeName
		});
	}

	public static void DamageTiles(NPC npc, Rectangle Hitbox, int power = 0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		if (power < 25)
		{
			return;
		}
		List<Point> tiles = Collision.GetTilesIn(Utils.BottomLeft(Hitbox) - new Vector2(2f, -2f), Utils.BottomRight(Hitbox) + new Vector2(2f, 10f));
		double tileCount = 0.0;
		foreach (Point item in tiles)
		{
			Tile tile = Framing.GetTileSafely(item);
			if (((Tile)(ref tile)).HasTile)
			{
				tileCount += 1.0;
				if (((Tile)(ref tile)).TileType == 19 || ((Tile)(ref tile)).TileType == 54)
				{
					tileCount -= 0.33;
				}
			}
		}
		if (tileCount == 0.0)
		{
			return;
		}
		int breakChance = Math.Max((int)(50.0 * (tileCount / 4.0)) - power / 8, 0);
		if (breakChance > 200)
		{
			return;
		}
		foreach (Point point in tiles)
		{
			Tile tile2 = Framing.GetTileSafely(point);
			int chance = Main.rand.Next(breakChance);
			if (chance == 0)
			{
				Tile tileBelow = Framing.GetTileSafely(point + new Point(0, 1));
				Tile extraTile = Framing.GetTileSafely(point + new Point(0, 2));
				if ((!((Tile)(ref tile2)).HasTile || !((Tile)(ref tileBelow)).HasTile || !((Tile)(ref extraTile)).HasTile) && (!((Tile)(ref tileBelow)).HasTile || Main.rand.Next(breakChance) <= breakChance / 5))
				{
					WorldGen.KillTile(point.X, point.Y, false, false, false);
				}
			}
			else if (chance <= 33)
			{
				Tile tileBelow2 = Framing.GetTileSafely(point + new Point(0, 1));
				Tile extraTile2 = Framing.GetTileSafely(point + new Point(0, 2));
				if ((!((Tile)(ref tile2)).HasTile || !((Tile)(ref tileBelow2)).HasTile || !((Tile)(ref extraTile2)).HasTile) && (!((Tile)(ref tileBelow2)).HasTile || Main.rand.Next(breakChance) <= breakChance / 5))
				{
					WorldGen.KillTile(point.X, point.Y, true, true, false);
				}
			}
		}
	}

	public static void PushPlayers(NPC npc, int heightsize = 0, int heightoffset = 0, int fallDamage = 0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		Rectangle Hitbox = ((Entity)npc).Hitbox;
		Hitbox.Height += heightsize;
		((Rectangle)(ref Hitbox)).Offset(0, -heightsize + heightoffset);
		fallDamage = (Hitbox.Height + Hitbox.Width) / 3;
		Vector2 Center = Utils.Center(Hitbox);
		int Width = Hitbox.Width;
		int Height = Hitbox.Height;
		Enumerator<Player> enumerator = Main.ActivePlayers.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Player player = enumerator.Current;
			if (!((Rectangle)(ref Hitbox)).Intersects(((Entity)player).Hitbox) || player.dead)
			{
				continue;
			}
			if (((Entity)player).Center.Y < Center.Y - (float)(Height / 8) && (double)((Entity)player).Center.X < (double)Center.X + (double)Width / 1.25 && (double)((Entity)player).Center.X > (double)Center.X - (double)Width / 1.25)
			{
				player.RefreshMovementAbilities(true);
				if (((Entity)player).velocity.Y > 2f)
				{
					((Entity)player).velocity.Y = ((Entity)player).velocity.Y * -0.95f;
				}
				else
				{
					((Entity)player).velocity.Y = -2f;
				}
			}
			else if (((Entity)player).Center.Y >= Center.Y + (float)(Height / 3) && (double)((Entity)player).Center.X < (double)Center.X + (double)Width / 2.25 && (double)((Entity)player).Center.X > (double)Center.X - (double)Width / 2.25)
			{
				((Entity)player).position.Y = Center.Y + (float)(Height / 2);
				if (((Entity)player).velocity.Y < 2f)
				{
					((Entity)player).velocity.Y = ((Entity)player).velocity.Y * -0.95f;
				}
				else
				{
					((Entity)player).velocity.Y = 2f;
				}
			}
			if (((Entity)player).Center.X < Center.X - 1f && ((Entity)player).Center.Y > Center.Y - (float)(Height / 2) && ((Entity)player).Center.Y < Center.Y + (float)(Height / 2))
			{
				if (((Entity)player).velocity.X > 2f)
				{
					((Entity)player).velocity.X = ((Entity)player).velocity.X * -0.95f;
				}
				else
				{
					((Entity)player).velocity.X = -2f;
				}
			}
			else if (((Entity)player).Center.X >= Center.X + 1f && ((Entity)player).Center.Y > Center.Y - (float)(Height / 2) && ((Entity)player).Center.Y < Center.Y + (float)(Height / 2))
			{
				if (((Entity)player).velocity.X < -2f)
				{
					((Entity)player).velocity.X = ((Entity)player).velocity.X * -0.95f;
				}
				else
				{
					((Entity)player).velocity.X = 2f;
				}
			}
			if (fallDamage > 0 && ((Entity)npc).velocity.Y > 1.5f && ((Entity)player).Center.Y >= Center.Y + (float)(Height / 3))
			{
				player.Hurt(PlayerDeathReason.ByCustomReason(FatassDeathReason(npc, player)), (int)((float)fallDamage * (((Entity)npc).velocity.Y - 1.5f)), 0, false, false, -1, false, 0f, 0f, 4.5f);
			}
		}
		Enumerator<NPC> enumerator2 = Main.ActiveNPCs.GetEnumerator();
		HitInfo hitinfo = default(HitInfo);
		while (enumerator2.MoveNext())
		{
			NPC othernpc = enumerator2.Current;
			if (((Entity)othernpc).whoAmI == ((Entity)npc).whoAmI || !((Rectangle)(ref Hitbox)).Intersects(((Entity)othernpc).Hitbox))
			{
				continue;
			}
			if (!othernpc.noTileCollide)
			{
				if (((Entity)othernpc).Center.Y < Center.Y + (float)(Height / 16) && (double)((Entity)othernpc).Center.X < (double)Center.X + (double)Width / 1.25 && (double)((Entity)othernpc).Center.X > (double)Center.X - (double)Width / 1.25)
				{
					if (((Entity)othernpc).velocity.Y > 2f)
					{
						((Entity)othernpc).velocity.Y = ((Entity)othernpc).velocity.Y * -0.95f;
					}
					else
					{
						((Entity)othernpc).velocity.Y = -2f;
					}
				}
				else if (((Entity)othernpc).Center.Y >= Center.Y + (float)(Height / 3) && (double)((Entity)othernpc).Center.X < (double)Center.X + (double)Width / 2.25 && (double)((Entity)othernpc).Center.X > (double)Center.X - (double)Width / 2.25)
				{
					((Entity)othernpc).position.Y = Center.Y + (float)(Height / 2);
					if (((Entity)othernpc).velocity.Y < 2f)
					{
						((Entity)othernpc).velocity.Y = ((Entity)othernpc).velocity.Y * -0.95f;
					}
					else
					{
						((Entity)othernpc).velocity.Y = 2f;
					}
				}
				if (((Entity)othernpc).Center.X < Center.X - 1f && ((Entity)othernpc).Center.Y > Center.Y - (float)(Height / 2) && ((Entity)othernpc).Center.Y < Center.Y + (float)(Height / 2))
				{
					if (((Entity)othernpc).velocity.X > 2f)
					{
						((Entity)othernpc).velocity.X = ((Entity)othernpc).velocity.X * -0.95f;
					}
					else
					{
						((Entity)othernpc).velocity.X = -2f;
					}
				}
				else if (((Entity)othernpc).Center.X >= Center.X + 1f && ((Entity)othernpc).Center.Y > Center.Y - (float)(Height / 2) && ((Entity)othernpc).Center.Y < Center.Y + (float)(Height / 2))
				{
					if (((Entity)othernpc).velocity.X < -2f)
					{
						((Entity)othernpc).velocity.X = ((Entity)othernpc).velocity.X * -0.95f;
					}
					else
					{
						((Entity)othernpc).velocity.X = 2f;
					}
				}
			}
			if (fallDamage > 0 && ((Entity)npc).velocity.Y > 2f && ((Entity)othernpc).Center.Y >= Center.Y + (float)(Height / 3))
			{
				((HitInfo)(ref hitinfo))._002Ector();
				((HitInfo)(ref hitinfo)).Damage = (int)((float)fallDamage * (((Entity)npc).velocity.Y - 1.5f));
				othernpc.StrikeNPC(hitinfo, false, false);
				NetMessage.SendStrikeNPC(othernpc, ref hitinfo, -1);
			}
		}
		if (ModContent.GetInstance<V2ServerConfig>().FatAssesBreakTiles && npc.AsPred().FloorBreakCounter >= 60)
		{
			npc.AsPred().FloorBreakCounter = 0;
			DamageTiles(npc, Hitbox, fallDamage);
		}
	}

	public static void OnUpdate(NPC npc)
	{
		if (!IsAirborne(npc))
		{
			npc.AsPred().FloorBreakCounter++;
		}
		else
		{
			npc.AsPred().FloorBreakCounter = 0;
		}
	}

	public static bool IsAirborne(Player player)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return !Collision.SolidCollision(((Entity)player).BottomLeft, ((Entity)player).width, 6);
	}

	public static bool IsAirborne(NPC player)
	{
		return !player.collideY;
	}
}
