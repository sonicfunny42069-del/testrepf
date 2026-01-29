using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Accessories;

public class NymphHairScarf : ModItem
{
	public static float MoveSpeedBonus => 0.12f;

	public static float StomachWeightReduction => 0.12f;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Accessories.NymphHairScarf");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Accessories.NymphHairScarf.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 4;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		player.moveSpeed += MoveSpeedBonus;
		PredPlayer predPlayer = player.AsPred();
		predPlayer.StomachWeightModifier *= 1f - StomachWeightReduction;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Accessories.NymphHairScarf", new
		{
			NymphScarfMoveSpeedBuff = MoveSpeedBonus.ToPercentage(2),
			NymphScarfWeightReduction = StomachWeightReduction.ToPercentage(2)
		});
	}
}
