using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Consumables;

public class GhostBallDust : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		dust.noGravity = true;
		dust.frame = new Rectangle(0, 0, 8, 8);
		dust.customData = 1f;
		dust.alpha = 0;
		if (Utils.NextBool(Main.rand, 2))
		{
			dust.customData = -1f;
		}
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
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		dust.position += dust.velocity;
		dust.rotation += (float)dust.customData / 5f;
		dust.alpha += 5;
		dust.scale *= 0.98f;
		dust.velocity.X *= 0.97f;
		dust.velocity.Y *= 0.97f;
		dust.velocity.Y -= 0.02f;
		float light = 0.01f * (float)(255 - dust.alpha);
		Lighting.AddLight(dust.position, new Vector3(0.3f * light, 0.8f * light, light));
		if (dust.alpha >= 255)
		{
			dust.active = false;
		}
		return false;
	}
}
