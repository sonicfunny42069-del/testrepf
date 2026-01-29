using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Charms;

public class CharmBetterDigestion : ModItem
{
	public static int AcidStrengthBonus => 12;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Charms.BetterDigestion");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Charms.BetterDigestion.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.AsCharm().IsCharm = true;
		GeneralItem generalItem = ((ModItem)this).Item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateCharmBetterDigestion));
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 1;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
	}

	public static void UpdateCharmBetterDigestion(Item item, Player player, bool hideVisual)
	{
		player.AsPred().ACI.Extra += AcidStrengthBonus;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Charms.BetterDigestion", new { AcidStrengthBonus });
	}
}
