using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Accessories.Informational;

public class PredCapacityScanner : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Accessories.Informational.PredCapacityScanner");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Accessories.Informational.PredCapacityScanner.Short");

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
		((ModItem)this).Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
	}

	public override void UpdateInventory(Player player)
	{
		player.AsFood().PredScanner = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.AsFood().PredScanner = true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Accessories.Informational.PredCapacityScanner", new { });
	}
}
