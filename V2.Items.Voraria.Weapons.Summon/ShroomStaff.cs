using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Projectiles.Voraria.Weapons.Summon;

namespace V2.Items.Voraria.Weapons.Summon;

public class ShroomStaff : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Weapons.Summon.ShroomFairySummon");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Weapons.Summon.ShroomFairySummon.Short");

	public override void SetStaticDefaults()
	{
		Sets.GamepadWholeScreenUseRange[((ModItem)this).Item.type] = true;
		Sets.LockOnIgnoresCollision[((ModItem)this).Item.type] = true;
		Sets.StaffMinionSlotsRequired[((ModItem)this).Type] = 1.5f;
		Sets.ShimmerTransformToItem[((ModItem)this).Type] = 1309;
	}

	public override void SetDefaults()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.knockBack = 3f;
		((ModItem)this).Item.mana = 10;
		((Entity)((ModItem)this).Item).width = 46;
		((Entity)((ModItem)this).Item).height = 46;
		((ModItem)this).Item.useTime = 36;
		((ModItem)this).Item.useAnimation = 36;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.value = Item.sellPrice(0, 2, 0, 0);
		((ModItem)this).Item.rare = 6;
		((ModItem)this).Item.UseSound = SoundID.Item44;
		((ModItem)this).Item.noMelee = true;
		((ModItem)this).Item.DamageType = DamageClass.Summon;
		((ModItem)this).Item.buffType = ModContent.BuffType<ShroomFairyBuff>();
		((ModItem)this).Item.shoot = ModContent.ProjectileType<ShroomFairy>();
	}

	public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		position = Main.MouseWorld;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		player.AddBuff(((ModItem)this).Item.buffType, 2, true, false);
		Projectile.NewProjectileDirect((IEntitySource)(object)source, position, velocity, type, 0, 0f, Main.myPlayer, 0f, 0f, 0f).originalDamage = 0;
		return false;
	}

	public override void AddRecipes()
	{
		((ModItem)this).CreateRecipe(1).AddIngredient(1552, 2).AddIngredient(183, 35)
			.AddIngredient(501, 25)
			.AddTile(247)
			.Register();
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Weapons.Summon.ShroomFairySummon", new { });
	}
}
