using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace V2.UI;

public class UIHoverImageButton : UIImageButton
{
	internal string HoverText;

	public UIHoverImageButton(Asset<Texture2D> texture, string hoverText)
		: base(texture)
	{
		HoverText = hoverText;
	}

	protected override void DrawSelf(SpriteBatch spriteBatch)
	{
		((UIImageButton)this).DrawSelf(spriteBatch);
		if (((UIElement)this).IsMouseHovering)
		{
			Main.hoverItemName = HoverText;
		}
	}
}
