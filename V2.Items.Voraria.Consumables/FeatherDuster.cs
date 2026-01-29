using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Items.Voraria.Consumables;

public class FeatherDuster : ModItem
{
	public static double StruggleDamage => 500.0;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.FeatherDuster");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.FeatherDuster.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 99;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.useAnimation = 12;
		((ModItem)this).Item.useTime = 12;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.AsFood().Size = 0.15;
		((ModItem)this).Item.AsFood().MaxHealth = 115;
		((ModItem)this).Item.AsFood().AcidResistTier = 0;
		((ModItem)this).Item.AsFood().CanUseInStomach = CanUseInStomach;
		((ModItem)this).Item.AsFood().UseInStomach = UseInStomach;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 1;
		((ModItem)this).Item.value = Item.buyPrice(0, 0, 80, 0);
	}

	public override bool CanUseItem(Player player)
	{
		return ((Entity)(object)player).CurrentCaptor() != null;
	}

	public override void UseAnimation(Player player)
	{
	}

	public static bool CanUseInStomach(Item item, Player player, Entity pred)
	{
		return true;
	}

	public static void UseInStomach(Item item, Player player, Entity pred)
	{
		((Entity)(object)player).CurrentCaptor().ModifyPredStomachacheMeter(StruggleDamage);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.FeatherDuster", new
		{
			FeatherDusterStruggleDamage = StruggleDamage
		});
	}
}
