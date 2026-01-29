using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using V2.PlayerHandling;

namespace V2.UI;

public class MouseRestrictionDummyUI : UIState
{
	private static Asset<Texture2D> _predStatsMenuBackground = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Background", (AssetRequestMode)1);

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		if (!Main.LocalPlayer.AsPred().InPredStatsMenu)
		{
			return;
		}
		Vector2 backdropPos = default(Vector2);
		((Vector2)(ref backdropPos))._002Ector((float)((Main.screenWidth - _predStatsMenuBackground.Value.Width) / 2), (float)((Main.screenHeight - _predStatsMenuBackground.Value.Height) / 2));
		Rectangle backdropRect = _predStatsMenuBackground.Value.Bounds;
		backdropRect.X = (int)backdropPos.X;
		backdropRect.Y = (int)backdropPos.Y;
		backdropRect.X += 10;
		backdropRect.Y += 10;
		backdropRect.Width -= 20;
		backdropRect.Height -= 20;
		if (Main.hasFocus)
		{
			MouseState state = Mouse.GetState();
			int mouseX = ((MouseState)(ref state)).X;
			int mouseY = ((MouseState)(ref state)).Y;
			if (Main.MouseScreen.X <= (float)((Rectangle)(ref backdropRect)).Left)
			{
				mouseX = (int)((float)((Rectangle)(ref backdropRect)).Left * Main.UIScale);
			}
			if (Main.MouseScreen.X >= (float)((Rectangle)(ref backdropRect)).Right)
			{
				mouseX = (int)((float)((Rectangle)(ref backdropRect)).Right * Main.UIScale);
			}
			if (Main.MouseScreen.Y <= (float)((Rectangle)(ref backdropRect)).Top)
			{
				mouseY = (int)((float)((Rectangle)(ref backdropRect)).Top * Main.UIScale);
			}
			if (Main.MouseScreen.Y >= (float)((Rectangle)(ref backdropRect)).Bottom)
			{
				mouseY = (int)((float)((Rectangle)(ref backdropRect)).Bottom * Main.UIScale);
			}
			Mouse.SetPosition(mouseX, mouseY);
		}
	}
}
