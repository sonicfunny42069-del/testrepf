using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.Projectiles.Voraria;

public class CLOVERPUNCH : ModProjectile
{
	public float CollisionWidth => 36f * ((ModProjectile)this).Projectile.scale;

	public int Timer
	{
		get
		{
			return (int)((ModProjectile)this).Projectile.ai[0];
		}
		set
		{
			((ModProjectile)this).Projectile.ai[0] = value;
		}
	}

	public override void SetDefaults()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModProjectile)this).Projectile).Size = new Vector2(18f);
		((ModProjectile)this).Projectile.friendly = true;
		((ModProjectile)this).Projectile.penetrate = -1;
		((ModProjectile)this).Projectile.tileCollide = false;
		((ModProjectile)this).Projectile.scale = 1f;
		((ModProjectile)this).Projectile.DamageType = DamageClass.Generic;
		((ModProjectile)this).Projectile.ownerHitCheck = true;
		((ModProjectile)this).Projectile.timeLeft = 8;
		((ModProjectile)this).Projectile.hide = true;
		((ModProjectile)this).AIType = 14;
	}

	public override void OnHitNPC(NPC target, HitInfo hit, int damageDone)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref SoundID.Item175, (Vector2?)((Entity)target).position, (SoundUpdateCallback)null);
	}
}
