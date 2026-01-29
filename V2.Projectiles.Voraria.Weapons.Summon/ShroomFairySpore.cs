using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using V2.PlayerHandling;
using V2.StatusEffects.Voraria.Buffs;

namespace V2.Projectiles.Voraria.Weapons.Summon;

public class ShroomFairySpore : ModProjectile
{
	public override void SetStaticDefaults()
	{
		Main.projFrames[((ModProjectile)this).Projectile.type] = 3;
	}

	public sealed override void SetDefaults()
	{
		((Entity)((ModProjectile)this).Projectile).width = 18;
		((Entity)((ModProjectile)this).Projectile).height = 18;
		((ModProjectile)this).Projectile.tileCollide = false;
		((ModProjectile)this).Projectile.friendly = true;
		((ModProjectile)this).Projectile.DamageType = DamageClass.Generic;
		((ModProjectile)this).Projectile.penetrate = -1;
		((ModProjectile)this).Projectile.AsFood().DefinedSize = 0.12;
		((ModProjectile)this).Projectile.AsFood().MaxHealth = 5.0;
		((ModProjectile)this).Projectile.AsFood().Health = 5.0;
		PreyProjectile preyProjectile = ((ModProjectile)this).Projectile.AsFood();
		preyProjectile.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(OnKilledByDigestion));
	}

	public override void OnSpawn(IEntitySource source)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Dust.NewDustPerfect(((Entity)((ModProjectile)this).Projectile).Center, ModContent.DustType<ShroomFairyDust2>(), (Vector2?)Vector2.Zero, 0, default(Color), 1f);
	}

	public static void OnKilledByDigestion(Projectile projectile, Entity pred)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		if (pred is Player)
		{
			Player player = (Player)pred;
			player.Heal(15);
			if (Main.player[projectile.owner].AsV2Player().ShroomNecklace)
			{
				player.AddBuff(ModContent.BuffType<SporeRegen>(), V2Utils.SensibleTime(0, 0, 12), true, false);
			}
		}
	}

	public override bool? CanDamage()
	{
		return false;
	}

	public Player FindClosestPlayer()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Player plr = null;
		float Distance = 99999f;
		Enumerator<Player> enumerator = Main.ActivePlayers.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Player player = enumerator.Current;
			if (plr == null)
			{
				plr = player;
				Distance = Utils.Distance(((Entity)plr).position, ((Entity)((ModProjectile)this).Projectile).position);
				continue;
			}
			float distance2 = Utils.Distance(((Entity)plr).position, ((Entity)((ModProjectile)this).Projectile).position);
			if (distance2 < Distance)
			{
				plr = player;
				Distance = distance2;
			}
		}
		return plr;
	}

	public override void AI()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		Player target = FindClosestPlayer();
		if (target != null)
		{
			Vector2 direction = Utils.DirectionTo(((Entity)((ModProjectile)this).Projectile).position, ((Entity)target).position);
			((Vector2)(ref direction)).Normalize();
			Projectile projectile = ((ModProjectile)this).Projectile;
			((Entity)projectile).velocity = ((Entity)projectile).velocity + direction / 8f;
			((Entity)((ModProjectile)this).Projectile).velocity.X = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.X, -5f, 5f);
			((Entity)((ModProjectile)this).Projectile).velocity.Y = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.Y, -5f, 5f);
			if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, ((Entity)target).Center) <= 150f)
			{
				Projectile projectile2 = ((ModProjectile)this).Projectile;
				((Entity)projectile2).velocity = ((Entity)projectile2).velocity * 0.93f;
			}
			Rectangle hitbox = ((Entity)((ModProjectile)this).Projectile).Hitbox;
			if (((Rectangle)(ref hitbox)).Intersects(((Entity)target).Hitbox))
			{
				target.Heal(5);
				if (Main.player[((ModProjectile)this).Projectile.owner].AsV2Player().ShroomNecklace)
				{
					target.AddBuff(ModContent.BuffType<SporeRegen>(), V2Utils.SensibleTime(0, 0, 4), true, false);
				}
				ShroomFairy.DustEffect(((ModProjectile)this).Projectile);
				((ModProjectile)this).Projectile.Kill();
			}
		}
		((ModProjectile)this).Projectile.ai[0] += 1f;
	}

	public override void PostAI()
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if (((ModProjectile)this).Projectile.ai[0] >= 500f)
		{
			ShroomFairy.DustEffect(((ModProjectile)this).Projectile);
			((ModProjectile)this).Projectile.Kill();
		}
		((ModProjectile)this).Projectile.rotation = ((Entity)((ModProjectile)this).Projectile).velocity.X * 0.04f;
		int framerate = 5;
		Projectile projectile = ((ModProjectile)this).Projectile;
		projectile.frameCounter++;
		if (((ModProjectile)this).Projectile.frameCounter >= framerate)
		{
			((ModProjectile)this).Projectile.frameCounter = 0;
			Projectile projectile2 = ((ModProjectile)this).Projectile;
			projectile2.frame++;
			if (((ModProjectile)this).Projectile.frame >= Main.projFrames[((ModProjectile)this).Projectile.type])
			{
				((ModProjectile)this).Projectile.frame = 0;
			}
		}
		Vector2 center = ((Entity)((ModProjectile)this).Projectile).Center;
		Color blue = Color.Blue;
		Lighting.AddLight(center, ((Color)(ref blue)).ToVector3() * 0.7f);
	}

	public override bool PreDraw(ref Color lightColor)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(18 * ((ModProjectile)this).Projectile.frame, 0, 18, 18);
		SpriteEffects spriteEffects = (SpriteEffects)(((Entity)((ModProjectile)this).Projectile).direction == -1);
		Main.EntitySpriteDraw(ModContent.Request<Texture2D>("V2/Projectiles/Voraria/Weapons/Summon/ShroomFairySpore", (AssetRequestMode)2).Value, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition, (Rectangle?)sourceRect, lightColor, ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		Main.EntitySpriteDraw(ModContent.Request<Texture2D>("V2/Projectiles/Voraria/Weapons/Summon/ShroomFairySpore_Fullbright", (AssetRequestMode)2).Value, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition, (Rectangle?)sourceRect, new Color(255, 255, 255), ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		return false;
	}
}
