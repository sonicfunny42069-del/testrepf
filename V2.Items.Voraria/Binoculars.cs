using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.Items.Voraria;

public class Binoculars : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 1299;
	}

	public override void AddRecipes()
	{
		Recipe.Create(1299, 1).AddRecipeGroup(RecipeGroupID.IronBar, 6).AddIngredient(38, 4)
			.AddIngredient<ObserverPupil>(4)
			.AddTile(16)
			.Register();
	}
}
