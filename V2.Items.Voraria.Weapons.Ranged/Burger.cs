using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Skilled;
using V2.Projectiles;

namespace V2.Items.Voraria.Weapons.Ranged;

internal class Burger : ModProjectile
{
	public override void SetDefaults()
	{
		((Entity)((ModProjectile)this).Projectile).width = 26;
		((Entity)((ModProjectile)this).Projectile).height = 26;
		((ModProjectile)this).Projectile.aiStyle = 1;
		((ModProjectile)this).Projectile.friendly = true;
		((ModProjectile)this).Projectile.hostile = false;
		((ModProjectile)this).Projectile.DamageType = DamageClass.Generic;
		((ModProjectile)this).Projectile.penetrate = -1;
		((ModProjectile)this).Projectile.timeLeft = 600;
		((ModProjectile)this).AIType = 14;
		((ModProjectile)this).Projectile.AsFood().DefinedSize = 0.3;
		((ModProjectile)this).Projectile.AsFood().MaxHealth = 25.0;
		((ModProjectile)this).Projectile.AsFood().Health = 25.0;
		PreyProjectile preyProjectile = ((ModProjectile)this).Projectile.AsFood();
		preyProjectile.OnSwallowedBy = (PreyProjectile.DelegateOnSwallowedBy)Delegate.Combine(preyProjectile.OnSwallowedBy, new PreyProjectile.DelegateOnSwallowedBy(OnSwallowedByPlayer_GiveInfFoodGoal));
	}

	public override bool? CanDamage()
	{
		return false;
	}

	public override void AI()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
		Rectangle hitbox;
		while (enumerator.MoveNext())
		{
			NPC item = enumerator.Current;
			if (((ModProjectile)this).Projectile != null && ((Entity)((ModProjectile)this).Projectile).active && ((Entity)(object)((ModProjectile)this).Projectile).CurrentCaptor() == null && ((Entity)item).active && ((Entity)(object)item).CurrentCaptor() == null && item.AsPred().CanBeForceFed(item))
			{
				hitbox = ((Entity)((ModProjectile)this).Projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)item).Hitbox))
				{
					PredNPC.Swallow(item, (Entity)(object)((ModProjectile)this).Projectile);
				}
			}
		}
		Enumerator<Projectile> enumerator2 = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Projectile item2 = enumerator2.Current;
			if (((ModProjectile)this).Projectile != null && ((Entity)((ModProjectile)this).Projectile).active && ((Entity)(object)((ModProjectile)this).Projectile).CurrentCaptor() == null && ((Entity)item2).active && ((Entity)(object)item2).CurrentCaptor() == null && item2.AsPred().CanBeForceFed(item2))
			{
				hitbox = ((Entity)((ModProjectile)this).Projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)item2).Hitbox))
				{
					PredProjectile.Swallow(item2, (Entity)(object)((ModProjectile)this).Projectile);
				}
			}
		}
		Enumerator<Player> enumerator3 = Main.ActivePlayers.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			Player item3 = enumerator3.Current;
			if (((ModProjectile)this).Projectile != null && ((Entity)((ModProjectile)this).Projectile).active && ((Entity)(object)((ModProjectile)this).Projectile).CurrentCaptor() == null && ((Entity)item3).active && Main.player[((ModProjectile)this).Projectile.owner] != item3 && ((Entity)(object)item3).CurrentCaptor() == null)
			{
				hitbox = ((Entity)((ModProjectile)this).Projectile).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)item3).Hitbox))
				{
					PredPlayer.Swallow(item3, (Entity)(object)((ModProjectile)this).Projectile);
				}
			}
		}
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(255, 160, 43), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(255, 160, 43), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(255, 160, 43), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(255, 160, 43), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(255, 160, 43), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(194, 0, 0), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(128, 49, 0), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(128, 49, 0), 1f);
		Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).position, 28, 28, 143, oldVelocity.X * -0.1f, oldVelocity.Y * -0.1f, 0, new Color(48, 99, 31), 1f);
		return true;
	}

	public static void OnSwallowedByPlayer_GiveInfFoodGoal(Projectile projectile, Entity pred)
	{
		Player owner = Main.player[projectile.owner];
		if (owner != null && (object)owner == pred)
		{
			ModContent.GetInstance<BlasterLoophole>().TrySetCompletion(owner);
		}
	}
}
