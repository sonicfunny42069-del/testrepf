using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class ShroomiteDress : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.ShroomiteDress");

	public static int TUMBonus => 22;

	public static int ACIBonus => 6;

	public static float StomachWeightReduction => 0.4f;

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
		((ModItem)this).Item.value = Item.sellPrice(0, 7, 50, 0);
		((ModItem)this).Item.rare = 8;
		((ModItem)this).Item.defense = 12;
	}

	public override void UpdateEquip(Player player)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		player.AsPred().TUM.Extra += TUMBonus;
		player.AsPred().ACI.Extra += ACIBonus;
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 1f - StomachWeightReduction;
		player.maxMinions += 2;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.ShroomiteDress", new { });
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient<FungalDress>(1).AddIngredient(1552, 5)
			.AddIngredient(1508, 2)
			.AddTile(247)
			.Register();
	}
}
