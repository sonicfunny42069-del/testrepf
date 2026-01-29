using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Items.Voraria;

public class NymphHairStrand : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.NymphHairStrand");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.NymphHairStrand.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 25;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((Entity)((ModItem)this).Item).width = 26;
		((Entity)((ModItem)this).Item).height = 26;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 1, 50, 0);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.NymphHairStrand", new { });
	}
}
