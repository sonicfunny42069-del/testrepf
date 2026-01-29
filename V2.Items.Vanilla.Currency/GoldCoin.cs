using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Currency;

public class GoldCoin : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 73;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 64;
		item.AsFood().Size = 3.0 / 800.0;
		item.AsFood().AcidResistTier = 1;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Currency.Coins.GoldCoin", new { });
	}
}
