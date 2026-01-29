using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Projectiles;

public static class ProjectileExtensions
{
	public static GeneralProjectile AsV2Proj(this Projectile projectile, bool risky = false)
	{
		GeneralProjectile V2Projectile = default(GeneralProjectile);
		if (!projectile.TryGetGlobalProjectile<GeneralProjectile>(ref V2Projectile))
		{
			if (risky)
			{
				return null;
			}
			throw new Exception("this projectile hasn't been properly recognized by Voraria: Second Course! oh no! anyway");
		}
		return V2Projectile;
	}

	public static PredProjectile AsPred(this Projectile projectile)
	{
		return projectile.GetGlobalProjectile<PredProjectile>();
	}

	public static PreyProjectile AsFood(this Projectile projectile, bool risky = false)
	{
		PreyProjectile preyProjectile = default(PreyProjectile);
		if (!projectile.TryGetGlobalProjectile<PreyProjectile>(ref preyProjectile))
		{
			if (risky)
			{
				return null;
			}
			throw new Exception("this projectile can't be eaten, and thus, doesn't have a PreyProjectile global attached to them. look for your favorite snack elsewhere");
		}
		return preyProjectile;
	}

	public static bool TakeDigestionDamage(this Projectile projectile, Entity pred, double digestionDamage)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		int trueDigestionDamage = Main.DamageVar((float)digestionDamage, 0f);
		projectile.AsFood().Health -= trueDigestionDamage;
		switch (Main.netMode)
		{
		case 0:
			if (ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
			{
				CombatText obj = Main.combatText[CombatText.NewText(((Entity)projectile).Hitbox, Color.DarkGreen, trueDigestionDamage, false, true)];
				obj.position.X = pred.Center.X + (float)(pred.direction * 28);
				obj.position.Y = ((Entity)projectile).Center.Y + (float)((Entity)projectile).height / 5f;
				obj.velocity.X = (float)pred.direction * 2.5f;
				obj.velocity.Y = -4f;
			}
			break;
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)7);
			((BinaryWriter)(object)packet).Write(((Entity)projectile).whoAmI);
			((BinaryWriter)(object)packet).Write(trueDigestionDamage);
			((BinaryWriter)(object)packet).Write(pred.Center.X + (float)(pred.direction * 28));
			((BinaryWriter)(object)packet).Write(((Entity)projectile).Center.Y + (float)((Entity)projectile).height / 5f);
			((BinaryWriter)(object)packet).Write((float)pred.direction * 2.5f);
			((BinaryWriter)(object)packet).Write(-4f);
			packet.Send(-1, -1);
			break;
		}
		}
		if (projectile.AsFood().Health <= 0.0)
		{
			projectile.AsFood().OnKilledByDigestion?.Invoke(projectile, pred);
			projectile.AsFood().Digested = true;
			projectile.Kill();
			return true;
		}
		return false;
	}

	public static void DoContactGulpage(this Projectile projectile, List<(PreyType, int)> specificWhitelist = null)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)projectile).CurrentCaptor() != null)
		{
			return;
		}
		Rectangle hitbox;
		for (int i = 0; i < Main.maxNPCs; i++)
		{
			NPC preyNPC = Main.npc[i];
			if (!((Entity)preyNPC).active || preyNPC.life <= 0)
			{
				continue;
			}
			bool inSpecificWhitelist = false;
			if (specificWhitelist != null)
			{
				foreach (var (type, ID) in specificWhitelist)
				{
					if (type == PreyType.NPC && ID == preyNPC.type)
					{
						inSpecificWhitelist = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist = true;
			}
			if (inSpecificWhitelist)
			{
				hitbox = ((Entity)projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyNPC).Hitbox) && PredProjectile.CanSwallow(projectile, (Entity)(object)preyNPC))
				{
					PredProjectile.Swallow(projectile, (Entity)(object)preyNPC);
				}
			}
		}
		for (int j = 0; j < 255; j++)
		{
			Player preyPlayer = Main.player[j];
			if (!((Entity)preyPlayer).active || preyPlayer.dead)
			{
				continue;
			}
			bool inSpecificWhitelist2 = false;
			if (specificWhitelist != null)
			{
				foreach (var item in specificWhitelist)
				{
					if (item.Item1 == PreyType.Player)
					{
						inSpecificWhitelist2 = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist2 = true;
			}
			if (inSpecificWhitelist2)
			{
				hitbox = ((Entity)projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyPlayer).Hitbox) && PredProjectile.CanSwallow(projectile, (Entity)(object)preyPlayer))
				{
					PredProjectile.Swallow(projectile, (Entity)(object)preyPlayer);
				}
			}
		}
		for (int k = 0; k < Main.maxProjectiles; k++)
		{
			Projectile preyProjectile = Main.projectile[k];
			if (!((Entity)preyProjectile).active)
			{
				continue;
			}
			bool inSpecificWhitelist3 = false;
			if (specificWhitelist != null)
			{
				foreach (var (type2, ID2) in specificWhitelist)
				{
					if (type2 == PreyType.Projectile && ID2 == preyProjectile.type)
					{
						inSpecificWhitelist3 = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist3 = true;
			}
			if (inSpecificWhitelist3)
			{
				hitbox = ((Entity)projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyProjectile).Hitbox) && PredProjectile.CanSwallow(projectile, (Entity)(object)preyProjectile))
				{
					PredProjectile.Swallow(projectile, (Entity)(object)preyProjectile);
				}
			}
		}
		for (int l = 0; l < Main.maxItems; l++)
		{
			Item preyItem = Main.item[l];
			if (!((Entity)preyItem).active)
			{
				continue;
			}
			bool inSpecificWhitelist4 = false;
			if (specificWhitelist != null)
			{
				foreach (var (type3, ID3) in specificWhitelist)
				{
					if (type3 == PreyType.Item && ID3 == preyItem.type)
					{
						inSpecificWhitelist4 = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist4 = true;
			}
			if (inSpecificWhitelist4)
			{
				hitbox = ((Entity)projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyItem).Hitbox) && PredProjectile.CanSwallow(projectile, (Entity)(object)preyItem))
				{
					PredProjectile.Swallow(projectile, (Entity)(object)preyItem);
				}
			}
		}
	}
}
