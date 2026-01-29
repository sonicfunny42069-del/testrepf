using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.StatusEffects.Voraria.Debuffs;

namespace V2.Projectiles.Voraria.Weapons.Ranged.Throwables;

public class ThrowableHoneyBottleProjectile : ModProjectile
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ProjectileName.Voraria.Weapons.Ranged.Throwables.FragileBottles.Honey");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModProjectile)this).Projectile.friendly = true;
		((ModProjectile)this).Projectile.hostile = true;
		((ModProjectile)this).Projectile.tileCollide = true;
		((Entity)((ModProjectile)this).Projectile).width = 38;
		((Entity)((ModProjectile)this).Projectile).height = 38;
		((ModProjectile)this).Projectile.scale = 0.5f;
	}

	public override void AI()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		((ModProjectile)this).Projectile.ai[0] += 1f;
		if (((ModProjectile)this).Projectile.ai[0] > 20f)
		{
			((Entity)((ModProjectile)this).Projectile).velocity.X *= 0.995f;
			((Entity)((ModProjectile)this).Projectile).velocity.Y += 0.265f;
		}
		Projectile projectile = ((ModProjectile)this).Projectile;
		projectile.rotation += MathHelper.ToRadians(50f) * (float)Math.Sign(((Entity)((ModProjectile)this).Projectile).velocity.X);
		if (Utils.NextBool(Main.rand, 8) || ((ModProjectile)this).Projectile.ai[0] % 8f == 0f)
		{
			Dust.NewDustPerfect(new Vector2(((Entity)(object)((ModProjectile)this).Projectile).TrueCenter().X + Utils.NextFloat(Main.rand, (float)(-((Entity)((ModProjectile)this).Projectile).width) * ((ModProjectile)this).Projectile.scale, (float)((Entity)((ModProjectile)this).Projectile).width * ((ModProjectile)this).Projectile.scale), ((Entity)(object)((ModProjectile)this).Projectile).TrueCenter().Y + Utils.NextFloat(Main.rand, (float)(-((Entity)((ModProjectile)this).Projectile).height) * ((ModProjectile)this).Projectile.scale, (float)((Entity)((ModProjectile)this).Projectile).height * ((ModProjectile)this).Projectile.scale)), Utils.NextBool(Main.rand) ? 152 : 153, (Vector2?)(((Entity)((ModProjectile)this).Projectile).velocity * 0.1f), 0, default(Color), 1.25f);
		}
	}

	public override bool CanHitPlayer(Player target)
	{
		return ((Entity)target).whoAmI != ((ModProjectile)this).Projectile.owner;
	}

	public override void OnHitNPC(NPC target, HitInfo hit, int damageDone)
	{
		target.AddBuff(ModContent.BuffType<TastySweet>(), V2Utils.SensibleTime(0, 0, 20), false);
	}

	public override void OnKill(int timeLeft)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		int condimentDustCount = 32;
		float degreesPerCondimentDust = MathHelper.ToRadians(360f / (float)condimentDustCount);
		for (int i = 0; i < condimentDustCount; i++)
		{
			Dust.NewDustPerfect(((Entity)(object)((ModProjectile)this).Projectile).TrueCenter(), Utils.NextBool(Main.rand) ? 152 : 153, (Vector2?)Utils.RotatedByRandom(Utils.RotatedBy(new Vector2(0f, 4f), (double)(degreesPerCondimentDust * (float)i), default(Vector2)), (double)(degreesPerCondimentDust / 5f)), 0, default(Color), 1.25f);
		}
		int glassDustCount = 4 + Main.rand.Next(5);
		for (int j = 0; j < glassDustCount; j++)
		{
			Dust.NewDustPerfect(((Entity)(object)((ModProjectile)this).Projectile).TrueCenter(), 13, (Vector2?)Utils.RotatedByRandom(new Vector2(0f, 3f), (double)MathHelper.ToRadians(360f)), 0, default(Color), 1.5f);
		}
		SoundStyle item = SoundID.Item107;
		((SoundStyle)(ref item)).Pitch = 0.2f;
		SoundEngine.PlaySound(ref item, (Vector2?)((Entity)((ModProjectile)this).Projectile).position, (SoundUpdateCallback)null);
	}

	public override bool PreDraw(ref Color lightColor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		SpriteEffects spriteEffects = (SpriteEffects)0;
		Texture2D texture = TextureAssets.Projectile[((ModProjectile)this).Projectile.type].Value;
		Rectangle sourceRectangle = default(Rectangle);
		((Rectangle)(ref sourceRectangle))._002Ector(0, 0, texture.Width, texture.Height);
		Vector2 origin = Utils.Size(sourceRectangle) / 2f;
		Color drawColor = ((ModProjectile)this).Projectile.GetAlpha(lightColor);
		Main.spriteBatch.Draw(texture, ((Entity)((ModProjectile)this).Projectile).Center - Main.screenPosition + new Vector2(0f, ((ModProjectile)this).Projectile.gfxOffY), (Rectangle?)sourceRectangle, drawColor, ((ModProjectile)this).Projectile.rotation, origin, ((ModProjectile)this).Projectile.scale, spriteEffects, 0f);
		return false;
	}
}
