using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Placeables.Gems;

public class Amber : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 999;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 777;
		item.AsFood().Size = 0.1;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Placeables.Gems.Amber", new { });
	}
}
