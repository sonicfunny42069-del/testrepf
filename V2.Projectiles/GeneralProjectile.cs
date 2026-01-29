using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Projectiles;

public class GeneralProjectile : GlobalProjectile
{
	public delegate bool DelegateNewAI(Projectile projectile);

	public delegate List<string> DelegateGetChat(Projectile projectile, Player player);

	public EntityGender Gender { get; set; }

	public SpriteAnimation CustomSprite { get; set; }

	public DelegateNewAI NewAIMethod { get; set; }

	public DelegateGetChat GetChat { get; set; }

	public int Aggro { get; set; }

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		return true;
	}

	public GeneralProjectile()
	{
		Gender = EntityGender.Other;
		NewAIMethod = null;
		GetChat = null;
		Aggro = 0;
	}

	public override bool PreDraw(Projectile projectile, ref Color lightColor)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)projectile).CurrentCaptor() != null)
		{
			return false;
		}
		if (projectile.AsV2Proj().CustomSprite != null)
		{
			SpriteEffects val = ((((Entity)projectile).direction != -1) ? ((SpriteEffects)0) : ((SpriteEffects)1));
			SpriteEffects spriteEffects = val;
			Texture2D texture = ModContent.Request<Texture2D>(((ModTexturedType)projectile.AsV2Proj().CustomSprite).Texture, (AssetRequestMode)1).Value;
			Rectangle sourceRect = (Rectangle)(((_003F?)projectile.AsV2Proj().CustomSprite.DecideFrame()) ?? texture.Bounds);
			Main.spriteBatch.Draw(texture, ((Entity)projectile).Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), (Rectangle?)sourceRect, lightColor, projectile.rotation, Utils.Size(sourceRect) / 2f, 1f, spriteEffects, 0f);
			return false;
		}
		return true;
	}
}
