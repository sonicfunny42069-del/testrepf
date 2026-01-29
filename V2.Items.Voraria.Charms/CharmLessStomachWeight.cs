using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Charms;

public class CharmLessStomachWeight : ModItem
{
	public static double MaxWeightReduction => 0.4;

	public static double FullnessEffectivenessLossThreshold => 0.7;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Charms.LessStomachWeight");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Charms.LessStomachWeight.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public static double WeightReductionEffectiveness(Player player)
	{
		double stomachCapacityPercent = player.AsPred().StomachFullness / player.AsPred().StomachCapacity;
		return Math.Min(1.0 - stomachCapacityPercent, 1.0 - FullnessEffectivenessLossThreshold) / (1.0 - FullnessEffectivenessLossThreshold);
	}

	public override void SetStaticDefaults()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		DrawAnimationVertical anim = new DrawAnimationVertical(9, 10, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.AsCharm().IsCharm = true;
		GeneralItem generalItem = ((ModItem)this).Item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateCharmLessStomachWeight));
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 16, 20, 0);
	}

	public static void UpdateCharmLessStomachWeight(Item item, Player player, bool hideVisual)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 1f - (float)(MaxWeightReduction * WeightReductionEffectiveness(player));
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Charms.LessStomachWeight", new
		{
			WeightReduction = MaxWeightReduction.ToPercentage(2),
			FullnessEffectivenessLossThreshold = FullnessEffectivenessLossThreshold.ToPercentage(2),
			CurrentWeightReduction = (MaxWeightReduction * WeightReductionEffectiveness(Main.LocalPlayer)).ToPercentage(2)
		});
	}
}
