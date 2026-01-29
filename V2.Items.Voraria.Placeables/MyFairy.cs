using Terraria;
using Terraria.ModLoader;
using V2.Tiles.Paintings;

namespace V2.Items.Voraria.Placeables;

public class MyFairy : ModItem
{
	public override void SetDefaults()
	{
		((ModItem)this).Item.DefaultToPlaceableTile(ModContent.TileType<global::V2.Tiles.Paintings.MyFairy>(), 0);
		((Entity)((ModItem)this).Item).width = 32;
		((Entity)((ModItem)this).Item).height = 32;
		((ModItem)this).Item.rare = 11;
		((ModItem)this).Item.value = Item.buyPrice(1, 0, 0, 0);
	}
}
