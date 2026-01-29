using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Charms;

public class CharmPreyItemTheft : ModItem
{
	public static int AcidStrengthBonus => 12;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Charms.PreyItemTheft");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Charms.PreyItemTheft.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.AsCharm().IsCharm = true;
		GeneralItem generalItem = ((ModItem)this).Item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateCharmPreyItemTheft));
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 4;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
	}

	public static void UpdateCharmPreyItemTheft(Item item, Player player, bool hideVisual)
	{
		player.AsPred().charmStealPreyLoot = true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Charms.PreyItemTheft", new { });
	}
}
