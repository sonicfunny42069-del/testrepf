using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Consumables;

public class GhostBall : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.GhostBall");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.GhostBall");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.consumable = true;
		((Entity)((ModItem)this).Item).width = 16;
		((Entity)((ModItem)this).Item).height = 16;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.useTime = 8;
		((ModItem)this).Item.useAnimation = 8;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.noMelee = true;
		((ModItem)this).Item.noUseGraphic = true;
		((ModItem)this).Item.shoot = ModContent.ProjectileType<GhostBallProjectile>();
		((ModItem)this).Item.shootSpeed = 11f;
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.value = Item.buyPrice(0, 12, 0, 0);
		((ModItem)this).Item.rare = 9;
		((ModItem)this).Item.AsFood().MaxHealth = 100;
		((ModItem)this).Item.AsFood().Size = 0.15;
		((ModItem)this).Item.AsFood().EdibleOnUse = true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.GhostBall", new { });
	}
}
