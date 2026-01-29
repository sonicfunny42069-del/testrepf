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
using V2.NPCs.Voraria.TownNPCs.Ghost;

namespace V2.Items.Voraria.Consumables;

public class GhostBallProjectile : ModProjectile
{
	public override string Texture => "V2/Items/Voraria/Consumables/GhostBall";

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ProjectileName.Voraria.GhostBall");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModProjectile)this).Projectile.friendly = true;
		((ModProjectile)this).Projectile.tileCollide = true;
		((Entity)((ModProjectile)this).Projectile).width = 16;
		((Entity)((ModProjectile)this).Projectile).height = 16;
	}

	public override void AI()
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		((ModProjectile)this).Projectile.ai[0] += 1f;
		if (((ModProjectile)this).Projectile.ai[0] > 20f)
		{
			((Entity)((ModProjectile)this).Projectile).velocity.X *= 0.998f;
			((Entity)((ModProjectile)this).Projectile).velocity.Y += 0.1f;
		}
		Projectile projectile = ((ModProjectile)this).Projectile;
		projectile.rotation += MathHelper.ToRadians(50f) * (float)Math.Sign(((Entity)((ModProjectile)this).Projectile).velocity.X);
		if (((ModProjectile)this).Projectile.ai[0] % 2f == 0f)
		{
			float degrees = (float)Main.rand.Next(-17, 17) / 100f;
			Dust.NewDustPerfect(((Entity)((ModProjectile)this).Projectile).Center, ModContent.DustType<GhostBallDust>(), (Vector2?)Utils.RotatedByRandom(((Entity)((ModProjectile)this).Projectile).velocity * 0.8f, (double)degrees), 0, default(Color), 1f);
		}
	}

	public override void OnKill(int timeLeft)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		int condimentDustCount = 32;
		float degreesPerCondimentDust = MathHelper.ToRadians(360f / (float)condimentDustCount);
		for (int i = 0; i < condimentDustCount; i++)
		{
			float scale = Main.rand.Next(50, 200);
			float speed = (float)Main.rand.Next(50, 200) / 100f;
			Dust.NewDustPerfect(((Entity)(object)((ModProjectile)this).Projectile).TrueCenter(), ModContent.DustType<GhostBallDust>(), (Vector2?)Utils.RotatedByRandom(Utils.RotatedBy(new Vector2(0f, 4f * speed), (double)(degreesPerCondimentDust * (float)i), default(Vector2)), (double)(degreesPerCondimentDust / 5f)), 0, default(Color), scale / 100f);
		}
		SoundStyle item = SoundID.Item103;
		((SoundStyle)(ref item)).Pitch = 0.25f;
		SoundEngine.PlaySound(ref item, (Vector2?)((Entity)((ModProjectile)this).Projectile).position, (SoundUpdateCallback)null);
		if (!NPC.AnyNPCs(ModContent.NPCType<Echo>()))
		{
			NPC.NewNPCDirect(((Entity)((ModProjectile)this).Projectile).GetSource_FromAI((string)null), (int)((Entity)((ModProjectile)this).Projectile).Center.X, (int)((Entity)((ModProjectile)this).Projectile).Center.Y - 16, ModContent.NPCType<Echo>(), 0, 0f, 0f, 0f, 0f, 255).netUpdate = true;
		}
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
