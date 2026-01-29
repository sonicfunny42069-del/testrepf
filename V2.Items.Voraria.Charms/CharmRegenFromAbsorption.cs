using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Charms;

public class CharmRegenFromAbsorption : ModItem
{
	public static double HealthRegenerationRatio => 1.5;

	public static double ManaRegenerationRatio => 4.25;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Charms.RegenFromAbsorption");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Charms.RegenFromAbsorption.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.AsCharm().IsCharm = true;
		GeneralItem generalItem = ((ModItem)this).Item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateCharmRegenFromAbsorption));
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 1;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
	}

	public static void UpdateCharmRegenFromAbsorption(Item item, Player player, bool hideVisual)
	{
		VoreTracker stomachTracker = player.AsPred().StomachTracker;
		if (stomachTracker != null && stomachTracker.Prey.Count > 0)
		{
			double effectiveness = (double)(player.AsPred().StomachTracker?.Prey.FindAll((PreyData x) => x.NoHealth).Count).Value / (double)(player.AsPred().StomachTracker?.Prey.Count).Value;
			player.AddHealthRegenEffect(HealthRegenerationRatio * player.AsPred().PreyAbsorptionRatePerSecond * effectiveness, natural: true);
			player.AsPred().specialManaRegenCount += ManaRegenerationRatio * player.AsPred().PreyAbsorptionRatePerSecond * effectiveness;
		}
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		Player player = Main.LocalPlayer;
		double regenEffectiveness = 0.0;
		VoreTracker stomachTracker = player.AsPred().StomachTracker;
		if (stomachTracker != null && stomachTracker.Prey.Count > 0)
		{
			regenEffectiveness = (double)(player.AsPred().StomachTracker?.Prey.FindAll((PreyData x) => x.NoHealth).Count).Value / (double)(player.AsPred().StomachTracker?.Prey.Count).Value;
		}
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Charms.RegenFromAbsorption", new
		{
			HealthRegenerationRatio = HealthRegenerationRatio.ToPercentage(),
			ManaRegenerationRatio = ManaRegenerationRatio.ToPercentage(),
			RegenEffectiveness = regenEffectiveness.ToPercentage(2),
			LivePreyRemaining = (player.AsPred().StomachTracker?.Prey.FindAll((PreyData x) => !x.NoHealth).Count ?? 0),
			PreyRemaining = (player.AsPred().StomachTracker?.Prey.Count ?? 0),
			CurrentHealthRegen = ((regenEffectiveness > 0.0) ? (HealthRegenerationRatio * player.AsPred().PreyAbsorptionRate * regenEffectiveness) : 0.0).CastToDecimalPlaces(2),
			CurrentManaRegen = ((regenEffectiveness > 0.0) ? (ManaRegenerationRatio * player.AsPred().PreyAbsorptionRate * regenEffectiveness) : 0.0).CastToDecimalPlaces(2)
		});
	}
}
