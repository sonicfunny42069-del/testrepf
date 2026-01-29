using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;
using V2.Items;
using V2.PlayerHandling;

namespace V2.UI;

public class HeldItemDrawingUI : UIState
{
	public static bool Visible;

	public override void Update(GameTime gameTime)
	{
		Player player = Main.LocalPlayer;
		Visible = false;
		if (!player.HeldItem.IsAir && player.HeldItem.AsAnItem().heldItemUIDrawMethod != null)
		{
			Visible = true;
		}
		if (player.AsV2Player().generalItemUIDrawMethods != null && player.AsV2Player().generalItemUIDrawMethods.Count > 0)
		{
			Visible = true;
		}
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		if (!Visible)
		{
			return;
		}
		Player player = Main.LocalPlayer;
		if (!player.HeldItem.IsAir && player.HeldItem.AsAnItem().heldItemUIDrawMethod != null)
		{
			player.HeldItem.AsAnItem().heldItemUIDrawMethod(player.HeldItem, player, spriteBatch);
		}
		if (player.AsV2Player().generalItemUIDrawMethods != null && player.AsV2Player().generalItemUIDrawMethods.Count > 0)
		{
			for (int i = 0; i < player.AsV2Player().generalItemUIDrawMethods.Count; i++)
			{
				player.AsV2Player().generalItemUIDrawMethods[i](player, spriteBatch);
			}
		}
	}
}
