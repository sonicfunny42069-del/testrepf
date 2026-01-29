using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Projectiles.Voraria.Weapons.Ranged.Throwables;

namespace V2.Items.Voraria.Weapons.Ranged.Throwables;

public class ThrowableHoneyBottle : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Weapons.Ranged.Throwables.FragileBottles.Honey");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Weapons.Ranged.Throwables.FragileBottles.Honey.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
	}

	public override void SetDefaults()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.damage = 15;
		((Entity)((ModItem)this).Item).width = 38;
		((Entity)((ModItem)this).Item).height = 38;
		((ModItem)this).Item.useTime = 8;
		((ModItem)this).Item.useAnimation = 8;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.noMelee = true;
		((ModItem)this).Item.noUseGraphic = true;
		((ModItem)this).Item.knockBack = 1.5f;
		Item item = ((ModItem)this).Item;
		SoundStyle item2 = SoundID.Item106;
		((SoundStyle)(ref item2)).Pitch = 0.4f;
		item.UseSound = item2;
		((ModItem)this).Item.shoot = ModContent.ProjectileType<ThrowableHoneyBottleProjectile>();
		((ModItem)this).Item.shootSpeed = 10f;
		((ModItem)this).Item.DamageType = DamageClass.Ranged;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.value = Item.buyPrice(0, 0, 75, 0);
		((ModItem)this).Item.rare = 2;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Weapons.Ranged.Throwables.FragileBottles.Honey", new
		{
			ThrowableBottleCondimentName = ThrowableHoneyDetails.CondimentName,
			ThrowableBottleLowercaseCondimentName = ThrowableHoneyDetails.CondimentName.ToLower()
		});
	}
}
