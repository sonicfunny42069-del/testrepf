using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Accessories;

public class ShroomNecklace : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Accessories.ShroomNecklace");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Accessories.ShroomNecklace.Short");

	public override string Texture => "V2/Items/UnspritedItem";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		DrawAnimationVertical anim = new DrawAnimationVertical(6, 12, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
	}

	public override void HoldStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 18f * (float)((Entity)player).direction;
		player.itemLocation.Y += 14f;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.scale = 0.75f;
		((ModItem)this).Item.rare = 7;
		((ModItem)this).Item.value = Item.sellPrice(0, 10, 0, 0);
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient(1158, 1).AddIngredient(183, 100)
			.AddIngredient(ModContent.ItemType<MushroomToken>(), 1)
			.AddTile(16)
			.Register();
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.AsV2Player().ShroomNecklace = true;
		player.maxMinions++;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Accessories.ShroomNecklace", new { });
	}
}
