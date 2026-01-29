using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class CloverHeadAccessories : ModItem
{
	public static LocalizedText SetBonusText => Language.GetText("Mods.V2.ItemTooltip.Voraria.Armor.CloverArmorSetBonus");

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.CloverHeadAccessories");

	public static float StruggleBonus => 0.75f;

	public static int GLPBonus => 5;

	public static int CritBonus => 7;

	public override void SetStaticDefaults()
	{
		Sets.DrawHatHair[((ModItem)this).Item.headSlot] = true;
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 34;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.value = Item.buyPrice(0, 7, 7, 7);
		((ModItem)this).Item.rare = 7;
		((ModItem)this).Item.defense = 7;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (body.type == ModContent.ItemType<CloverSweater>())
		{
			return legs.type == ModContent.ItemType<CloverStockings>();
		}
		return false;
	}

	public override void UpdateArmorSet(Player player)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		player.setBonus = SetBonusText.Value;
		player.statDefense += 7;
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.StruggleStrengthModifier += 1.5f;
	}

	public override void UpdateEquip(Player player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.StruggleStrengthModifier += StruggleBonus;
		player.AsPred().GLP.Extra += GLPBonus;
		player.GetCritChance(DamageClass.Generic) += CritBonus;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.CloverHeadAccessories", new { });
	}
}
