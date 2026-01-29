using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Currency;

public class PlatinumCoin : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 74;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 256;
		item.AsFood().Size = 0.005;
		item.AsFood().AcidResistTier = 1;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Currency.Coins.PlatinumCoin", new { });
	}
}
