using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class CloverStockings : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.CloverStockings");

	public static float StruggleBonus => 0.75f;

	public static int CritBonus => 7;

	public static float MoveSpeedBonus => 0.2f;

	public static float StomachWeightReduction => 0.15f;

	public override void SetStaticDefaults()
	{
		Sets.HidesBottomSkin[((ModItem)this).Item.legSlot] = true;
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 24;
		((ModItem)this).Item.value = Item.buyPrice(0, 7, 7, 7);
		((ModItem)this).Item.rare = 7;
		((ModItem)this).Item.defense = 7;
	}

	public override void UpdateEquip(Player player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.StruggleStrengthModifier += StruggleBonus;
		player.moveSpeed += MoveSpeedBonus;
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 1f - StomachWeightReduction;
		player.GetCritChance(DamageClass.Generic) += CritBonus;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.CloverStockings", new { });
	}
}
