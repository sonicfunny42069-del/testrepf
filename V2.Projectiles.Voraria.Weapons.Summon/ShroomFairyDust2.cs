using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace V2.Projectiles.Voraria.Weapons.Summon;

public class ShroomFairyDust2 : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		dust.noGravity = true;
		dust.noLight = false;
		dust.frame = new Rectangle(0, 0, 18, 18);
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
		Main.spriteBatch.Draw(((ModDust)this).Texture2D.Value, dust.position - Main.screenPosition, (Rectangle?)dust.frame, Color.FromNonPremultiplied(255, 255, 255, 255 - dust.alpha), dust.rotation, new Vector2(9f, 9f), 1f, (SpriteEffects)0, 0f);
		return false;
	}

	public override bool Update(Dust dust)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		dust.position += dust.velocity;
		dust.rotation += (float)dust.customData / 5f;
		dust.alpha += 5;
		dust.velocity *= 0.1f;
		dust.customData = (float)dust.customData * 0.95f;
		float light = 0.01f * (float)(255 - dust.alpha);
		Lighting.AddLight(dust.position, new Vector3(0.3f * light, 0.4f * light, light));
		if (dust.alpha >= 255)
		{
			dust.active = false;
		}
		return false;
	}
}
