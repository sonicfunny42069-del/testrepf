using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace V2.PlayerHandling;

public class LayFlatHeadLayer : PlayerDrawLayer
{
	public override Position GetDefaultPosition()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		return (Position)new BeforeParent(PlayerDrawLayers.Head);
	}

	protected override void Draw(ref PlayerDrawSet drawInfo)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (drawInfo.drawPlayer.AsPred().IsLayingOnTum)
		{
			drawInfo.drawPlayer.headRotation = 0f - drawInfo.rotation + Utils.AngleTo(drawInfo.Position - Main.screenPosition, Main.MouseScreen);
			drawInfo.drawPlayer.headPosition.X = -4f;
			drawInfo.drawPlayer.headPosition.Y = -2f;
			drawInfo.compositeFrontArmRotation = 0f - MathHelper.ToRadians(75f);
			drawInfo.drawPlayer.legRotation = 0f - MathHelper.ToRadians(15f);
		}
	}
}
