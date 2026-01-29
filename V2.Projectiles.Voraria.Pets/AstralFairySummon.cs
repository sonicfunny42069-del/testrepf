using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace V2.Projectiles.Voraria.Pets;

public class AstralFairySummon : ModItem
{
	public override void SetDefaults()
	{
		((ModItem)this).Item.DefaultToVanitypet(ModContent.ProjectileType<AstralFairy>(), ModContent.BuffType<AstralFairyBuff>());
		((Entity)((ModItem)this).Item).width = 22;
		((Entity)((ModItem)this).Item).height = 32;
		((ModItem)this).Item.rare = 11;
		((ModItem)this).Item.value = Item.sellPrice(1, 0, 0, 0);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.AstralFairySummon", new { });
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		player.AddBuff(((ModItem)this).Item.buffType, 20, true, false);
		return false;
	}

	public override void OnCreated(ItemCreationContext context)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (context is RecipeItemCreationContext)
		{
			Item.NewItem(((Entity)Main.LocalPlayer).GetSource_Misc("ThrowItem"), new Vector2(((Entity)Main.LocalPlayer).position.X, ((Entity)Main.LocalPlayer).position.Y), new Vector2((float)((Entity)Main.LocalPlayer).width, (float)((Entity)Main.LocalPlayer).height), ModContent.ItemType<AstralFairyController>(), 1, false, 0, false, false);
		}
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient(3467, 3).AddIngredient(208, 1)
			.AddIngredient(501, 75)
			.AddTile(412)
			.Register();
	}
}
