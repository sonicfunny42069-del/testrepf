using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Accessories.Informational;

public class MealSizeScanner : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Accessories.Informational.MealSizeScanner");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Accessories.Informational.MealSizeScanner.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 1;
		Sets.ShimmerTransformToItem[((ModItem)this).Type] = ModContent.ItemType<PredCapacityScanner>();
	}

	public override void HoldStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 18f * (float)((Entity)player).direction;
		player.itemLocation.Y += 14f;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 16;
		((Entity)((ModItem)this).Item).height = 16;
		((ModItem)this).Item.scale = 0.75f;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
		((ModItem)this).Item.holdStyle = 1;
		((ModItem)this).Item.AsFood().Size = 0.26;
		((ModItem)this).Item.AsFood().MaxHealth = 120;
	}

	public override void UpdateInventory(Player player)
	{
		player.AsPred().SizeScanner = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.AsPred().SizeScanner = true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Accessories.Informational.MealSizeScanner", new { });
	}
}
