using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla;

public class VanillaGel : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 23;
	}

	public override void SetDefaults(Item entity)
	{
		entity.AsFood().MaxHealth = 6;
		entity.AsFood().Size = 0.006;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Gel", new { });
	}
}
