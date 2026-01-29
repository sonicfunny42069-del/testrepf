using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Items.Voraria;

public class ObserverPupil : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.ObserverPupil");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.ObserverPupil.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((Entity)((ModItem)this).Item).width = 16;
		((Entity)((ModItem)this).Item).height = 16;
		((ModItem)this).Item.rare = 0;
		((ModItem)this).Item.value = Item.buyPrice(0, 0, 50, 0);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.ObserverPupil", new { });
	}
}
