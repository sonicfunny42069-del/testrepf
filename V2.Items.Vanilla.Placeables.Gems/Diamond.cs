using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Placeables.Gems;

public class Diamond : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 182;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 1200;
		item.AsFood().Size = 0.0325;
		item.AsFood().AcidResistTier = 2;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Placeables.Gems.Diamond", new { });
	}
}
