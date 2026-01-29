using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace V2.Projectiles.Voraria.Weapons.Summon;

public class ShroomFairyDust : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		dust.noGravity = true;
		dust.frame = new Rectangle(0, 0, 8, 6);
	}

	public override bool PreDraw(Dust dust)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Main.spriteBatch.Draw(((ModDust)this).Texture2D.Value, dust.position - Main.screenPosition, (Rectangle?)dust.frame, Color.FromNonPremultiplied(255, 255, 255, 255 - dust.alpha), dust.rotation, new Vector2(4f, 3f), dust.scale, (SpriteEffects)0, 0f);
		return false;
	}

	public override bool Update(Dust dust)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		dust.position += dust.velocity;
		dust.rotation = Utils.ToRotation(dust.velocity);
		dust.scale *= 0.98f;
		dust.velocity *= 0.95f;
		float light = dust.scale;
		Lighting.AddLight(dust.position, new Vector3(0.35f * light, 0.25f * light, light));
		if (dust.scale < 0.15f)
		{
			dust.active = false;
		}
		return false;
	}
}
