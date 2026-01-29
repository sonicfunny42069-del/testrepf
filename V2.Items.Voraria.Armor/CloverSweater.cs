using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Armor;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class CloverSweater : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Armor.CloverSweater");

	public static float StruggleBonus => 1f;

	public static int TUMBonus => 8;

	public static int ABSBonus => 6;

	public static int CritBonus => 7;

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 34;
		((Entity)((ModItem)this).Item).height = 34;
		((ModItem)this).Item.value = Item.buyPrice(0, 7, 7, 7);
		((ModItem)this).Item.rare = 7;
		((ModItem)this).Item.defense = 7;
	}

	public override void UpdateEquip(Player player)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.StruggleStrengthModifier += StruggleBonus;
		player.AsPred().TUM.Extra += TUMBonus;
		player.AsPred().ABS.Extra += ABSBonus;
		player.GetCritChance(DamageClass.Generic) += CritBonus;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Armor.CloverSweater", new { });
	}
}
