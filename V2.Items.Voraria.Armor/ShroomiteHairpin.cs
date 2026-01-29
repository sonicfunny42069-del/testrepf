using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class ShroomiteHairpin : ModItem
{
	public static LocalizedText SetBonusText => Language.GetText("Mods.V2.ItemTooltip.Voraria.Armor.FungalFairySetBonus");

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.ShroomiteHairpin");

	public static int GLPBonus => 19;

	public static int ABSBonus => 19;

	public static int ACIBonus => 6;

	public override void SetStaticDefaults()
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		DrawAnimationVertical anim = new DrawAnimationVertical(6, 12, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
		Sets.DrawFullHair[((ModItem)this).Item.headSlot] = true;
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.value = Item.sellPrice(0, 7, 0, 0);
		((ModItem)this).Item.rare = 8;
		((ModItem)this).Item.defense = 10;
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
		player.AsPred().ACI.Extra += ACIBonus;
		player.maxMinions += 3;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.ShroomiteHairpin", new { });
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient<MushroomHairpin>(1).AddIngredient(1552, 2)
			.AddIngredient(1508, 5)
			.AddTile(247)
			.Register();
	}
}
