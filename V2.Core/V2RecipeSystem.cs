using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Items.Voraria;
using V2.Items.Voraria.Accessories;
using V2.Items.Voraria.Accessories.Informational;
using V2.Items.Voraria.Accessories.Vanity;
using V2.Items.Voraria.Consumables;
using V2.Items.Voraria.Consumables.Potions;
using V2.Items.Voraria.Weapons.Ranged.Throwables;
using V2.Items.Voraria.Weapons.Summon;

namespace V2.Core;

public class V2RecipeSystem : ModSystem
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void AddRecipes()
	{
	}

	public override void PostAddRecipes()
	{
		EstablishRecipeCollection();
	}

	public override void AddRecipeGroups()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		RecipeGroup group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Evil Wood"), new int[2] { 619, 911 });
		RecipeGroup.RegisterGroup("V2:EvilWood", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Ordinary Fish"), new int[5] { 2290, 2300, 2297, 2298, 2299 });
		RecipeGroup.RegisterGroup("V2:Fish", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Copper Bar"), new int[2] { 703, 20 });
		RecipeGroup.RegisterGroup("V2:Copper", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Silver Bar"), new int[2] { 21, 705 });
		RecipeGroup.RegisterGroup("V2:Silver", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Gold Bar"), new int[2] { 19, 706 });
		RecipeGroup.RegisterGroup("V2:Gold", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Ice"), new int[4] { 664, 833, 835, 834 });
		RecipeGroup.RegisterGroup("V2:Ice", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Sand"), new int[4] { 169, 370, 1246, 408 });
		RecipeGroup.RegisterGroup("V2:Sand", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Dungeon Brick"), new int[3] { 139, 137, 134 });
		RecipeGroup.RegisterGroup("V2:DungeonBrick", group);
		group = new RecipeGroup((Func<string>)(() => "Cobalt or Palladium Bars"), new int[2] { 381, 1184 });
		RecipeGroup.RegisterGroup("V2:T1AltarMetals", group);
		group = new RecipeGroup((Func<string>)(() => "Mythril or Orichalcum Bars"), new int[2] { 382, 1191 });
		RecipeGroup.RegisterGroup("V2:T2AltarMetals", group);
		group = new RecipeGroup((Func<string>)(() => "Titanium or Adamantite Bars"), new int[2] { 1198, 391 });
		RecipeGroup.RegisterGroup("V2:T3AltarMetals", group);
		group = new RecipeGroup((Func<string>)(() => Language.GetTextValue("LegacyMisc.37") + " Hardmode Anvil"), new int[2] { 525, 1220 });
		RecipeGroup.RegisterGroup("V2:HMAnvils", group);
	}

	public static void RemoveExistingRecipesForItem(int type)
	{
		for (int i = 0; i < Recipe.numRecipes; i++)
		{
			Recipe recipe = Main.recipe[i];
			if (recipe.HasResult(type))
			{
				recipe.DisableRecipe();
			}
		}
	}

	public static void RemoveItemFromExistingRecipes(int type)
	{
		for (int i = 0; i < Main.recipe.Length; i++)
		{
			Main.recipe[i].requiredItem.RemoveAll((Item x) => x.type == type);
		}
	}

	public static void EstablishRecipeCollection()
	{
		RemoveExistingRecipesForItem(885);
		Recipe.Create(1014, 3).AddIngredient(ModContent.ItemType<NymphHairStrand>(), 1).AddTile(228)
			.Register();
		RemoveExistingRecipesForItem(ModContent.ItemType<MealSizeScanner>());
		RemoveExistingRecipesForItem(ModContent.ItemType<PredCapacityScanner>());
		RemoveExistingRecipesForItem(ModContent.ItemType<BalloonBelly>());
		RemoveExistingRecipesForItem(ModContent.ItemType<AntiDigestionSash>());
		Recipe.Create(ModContent.ItemType<AntiDigestionSash>(), 1).AddIngredient(259, 12).AddIngredient(320, 12)
			.AddIngredient(225, 12)
			.AddTile(86)
			.Register();
		RemoveExistingRecipesForItem(ModContent.ItemType<NymphHairScarf>());
		Recipe.Create(ModContent.ItemType<NymphHairScarf>(), 1).AddIngredient(ModContent.ItemType<NymphHairStrand>(), 5).AddIngredient(75, 7)
			.AddIngredient(177, 3)
			.AddTile(86)
			.Register();
		RemoveExistingRecipesForItem(ModContent.ItemType<FastDigestionPotion>());
		RemoveExistingRecipesForItem(ModContent.ItemType<StomachCapacityPotion>());
		Recipe.Create(ModContent.ItemType<StomachCapacityPotion>(), 2).AddIngredient(1134, 2).AddIngredient(2311, 1)
			.AddIngredient(2313, 1)
			.AddTile(13)
			.Register();
		RemoveExistingRecipesForItem(ModContent.ItemType<StomachacheMeterCapacityPotion>());
		RemoveExistingRecipesForItem(ModContent.ItemType<FeatherDuster>());
		Recipe.Create(ModContent.ItemType<FeatherDuster>(), 3).AddIngredient(320, 5).AddIngredient(9, 12)
			.AddTile(86)
			.AddTile(305)
			.Register();
		RemoveExistingRecipesForItem(ModContent.ItemType<ThrowableHoneyBottle>());
		Recipe.Create(ModContent.ItemType<ThrowableHoneyBottle>(), 1).AddIngredient(1125, 4).AddIngredient(170, 8)
			.AddIngredient(9, 3)
			.AddTile(302)
			.Register();
		Recipe.Create(ModContent.ItemType<ThrowableHoneyBottle>(), 1).AddIngredient(170, 8).AddIngredient(9, 3)
			.AddTile(302)
			.AddTile(308)
			.Register();
		RemoveExistingRecipesForItem(ModContent.ItemType<ThrowableHotSauceBottle>());
		RemoveExistingRecipesForItem(ModContent.ItemType<PaperMaidSummon>());
		RemoveExistingRecipesForItem(ModContent.ItemType<NymphHairStrand>());
	}
}
