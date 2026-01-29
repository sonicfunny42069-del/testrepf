using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Ranged;

public class BorealWoodBow : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 2747;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 65;
		item.AsFood().Size = 0.25;
		item.AsTaggable().Broadsword = true;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Weapons.Ranged.BorealWoodBow", new { });
	}
}
