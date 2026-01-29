using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class MushroomHairpin : ModItem
{
	public static LocalizedText SetBonusText => Language.GetText("Mods.V2.ItemTooltip.Voraria.Armor.FungalFairySetBonus");

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.MushroomHairpin");

	public static int GLPBonus => 7;

	public static int ABSBonus => 7;

	public override void SetStaticDefaults()
	{
		Sets.DrawFullHair[((ModItem)this).Item.headSlot] = true;
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 24;
		((Entity)((ModItem)this).Item).height = 24;
		((ModItem)this).Item.value = Item.sellPrice(0, 5, 75, 0);
		((ModItem)this).Item.rare = 1;
		((ModItem)this).Item.defense = 6;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		return body.type == ModContent.ItemType<FungalDress>();
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = SetBonusText.Value;
		player.AsPred().FungalFairySetBonus = true;
	}

	public override void UpdateEquip(Player player)
	{
		player.AsPred().GLP.Extra += GLPBonus;
		player.AsPred().ABS.Extra += ABSBonus;
		player.maxMinions++;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.MushroomHairpin", new { });
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient<MushroomToken>(1).AddIngredient(183, 1)
			.AddIngredient(194, 10)
			.AddTile(16)
			.Register();
	}
}
