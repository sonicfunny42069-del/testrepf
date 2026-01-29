using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.CheatItems;

public class VenomizeousGaze : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.CheatItems.VenomDevItem");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.CheatItems.VenomDevItem.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 0;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = -13;
		((ModItem)this).Item.value = 0;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		player.AsPred().Rose = true;
		player.AsPred().Venomizeous = true;
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 0f;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.CheatItems.VenomDevItem", new { });
	}
}
