using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class FungalDress : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.FungalDress");

	public static int TUMBonus => 9;

	public static float StomachWeightReduction => 0.2f;

	public override void SetStaticDefaults()
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		DrawAnimationVertical anim = new DrawAnimationVertical(6, 12, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.value = Item.sellPrice(0, 5, 95, 0);
		((ModItem)this).Item.rare = 1;
		((ModItem)this).Item.defense = 7;
	}

	public override void UpdateEquip(Player player)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		player.AsPred().TUM.Extra += TUMBonus;
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 1f - StomachWeightReduction;
		player.maxMinions++;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.FungalDress", new { });
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient<MushroomToken>(1).AddIngredient(183, 15)
			.AddIngredient(194, 4)
			.AddIngredient(225, 8)
			.AddTile(86)
			.Register();
	}
}
