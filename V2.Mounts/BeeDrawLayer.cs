using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Mounts;

public class BeeDrawLayer : PlayerDrawLayer
{
	public override Position GetDefaultPosition()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		return (Position)new Between(PlayerDrawLayers.MountBack, PlayerDrawLayers.Carpet);
	}

	protected override void Draw(ref PlayerDrawSet drawInfo)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		Player player = drawInfo.drawPlayer;
		int walkFrame = (int)(Main.GlobalTimeWrappedHourly * 6f) % 2;
		walkFrame = ((walkFrame == 1) ? 1 : 2);
		bool isActuallyMoving = player.IsAirborne() || ((Entity)player).velocity.X != 0f;
		if (player.AsV2Player().BeeTransformation)
		{
			int tumSize = Math.Min((int)Math.Floor((float)player.AsPred().StomachSize / 2f), BeeTransformationItem.MaxTumSize);
			int weightSize = BeeTransformationItem.GetVisualWeightStage(player);
			Vector2 pos = default(Vector2);
			((Vector2)(ref pos))._002Ector((float)(int)(drawInfo.Position.X - Main.screenPosition.X - 20f), (float)(int)(drawInfo.Position.Y - Main.screenPosition.Y - 14f));
			Texture2D BeeBody = ModContent.Request<Texture2D>("V2/Mounts/BeeBody_Weight" + weightSize, (AssetRequestMode)2).Value;
			Rectangle sourceRect = Rectangle.Empty;
			if (isActuallyMoving)
			{
				((Rectangle)(ref sourceRect))._002Ector(tumSize * BeeBody.Width / 5, BeeBody.Height / 3 * walkFrame, BeeBody.Width / 5, BeeBody.Height / 3);
			}
			else
			{
				((Rectangle)(ref sourceRect))._002Ector(tumSize * BeeBody.Width / 5, 0, BeeBody.Width / 5, BeeBody.Height / 3);
			}
			DrawData actualDraw = default(DrawData);
			((DrawData)(ref actualDraw))._002Ector(BeeBody, pos, (Rectangle?)sourceRect, drawInfo.colorMount, player.bodyRotation, Vector2.Zero, 1f, drawInfo.playerEffect, 0f);
			actualDraw.shader = player.cMount;
			drawInfo.DrawDataCache.Add(actualDraw);
		}
	}
}
