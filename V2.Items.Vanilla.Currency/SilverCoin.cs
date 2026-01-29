using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Currency;

public class SilverCoin : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 72;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 16;
		item.AsFood().Size = 1.0 / 320.0;
		item.AsFood().AcidResistTier = 1;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Currency.Coins.SilverCoin", new { });
	}
}
