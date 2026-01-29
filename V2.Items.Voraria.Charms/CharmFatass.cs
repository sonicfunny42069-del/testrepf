using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Charms;

public class CharmFatass : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Charms.Fatass");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Charms.Fatass.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.AsCharm().IsCharm = true;
		GeneralItem generalItem = ((ModItem)this).Item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateCharmFatass));
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 2;
		((ModItem)this).Item.value = Item.buyPrice(0, 20, 0, 0);
	}

	public static void UpdateCharmFatass(Item item, Player player, bool hideVisual)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		PredPlayer predPlayer = player.AsPred();
		predPlayer.SwallowCapacityModifier *= 2f;
		PredPlayer predPlayer2 = player.AsPred();
		predPlayer2.StomachCapacityModifier *= 2f;
		PredPlayer predPlayer3 = player.AsPred();
		predPlayer3.DigestionTickDamageModifier *= 0.5f;
		PredPlayer predPlayer4 = player.AsPred();
		predPlayer4.DigestionTickRateModifier *= 0.5f;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Charms.Fatass", new { });
	}
}
