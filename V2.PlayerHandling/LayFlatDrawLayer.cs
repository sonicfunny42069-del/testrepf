using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace V2.PlayerHandling;

public class LayFlatDrawLayer : PlayerDrawLayer
{
	public override Position GetDefaultPosition()
	{
		return (Position)(object)PlayerDrawLayers.BeforeFirstVanillaLayer;
	}

	protected override void Draw(ref PlayerDrawSet drawInfo)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		if (drawInfo.drawPlayer.AsPred().IsLayingOnTum && drawInfo.drawPlayer.AsPred().Venomizeous)
		{
			drawInfo.Position.X += 20f;
			drawInfo.rotationOrigin = ((Entity)drawInfo.drawPlayer).Size / 2f;
			drawInfo.rotation += (float)((Entity)drawInfo.drawPlayer).direction * ((float)Math.PI / 2f);
			drawInfo.Position.Y += 4f;
			if (((Entity)drawInfo.drawPlayer).direction == 1)
			{
				drawInfo.Position.X -= (float)((Entity)drawInfo.drawPlayer).height / 2f;
			}
			else
			{
				drawInfo.Position.X -= ((Entity)drawInfo.drawPlayer).height;
				drawInfo.Position.X += (float)((Entity)drawInfo.drawPlayer).height / 2f;
			}
			drawInfo.Position.Y -= BellyDrawLayer.LayingBelly.RestingHeight;
			drawInfo.Position.Y += (BellyDrawLayer.LayingBelly.RestingHeight - BellyDrawLayer.LayingBelly.OffsetHeight) * 2;
			drawInfo.Position.Y -= 1f;
			drawInfo.Position.X -= 1f;
			V2Utils.DebugPointMarker(drawInfo.Position - Main.screenPosition);
		}
	}
}
