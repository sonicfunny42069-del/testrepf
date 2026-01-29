using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.CheatItems;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class RoseFlower : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.CheatItems.RoseFlower");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.CheatItems.RoseFlower.Short");

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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		player.AsPred().Rose = true;
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 0f;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.CheatItems.RoseFlower", new { });
	}
}
