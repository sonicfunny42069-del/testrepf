using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Placeables.Gems;

public class Topaz : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 180;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 332;
		item.AsFood().Size = 0.03;
		item.AsFood().AcidResistTier = 1;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Placeables.Gems.Topaz", new { });
	}
}
