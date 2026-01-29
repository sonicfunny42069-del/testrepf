using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla;

public class VanillaHarpyFeather : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 320;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 12;
		item.AsFood().Size = 0.008;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Feather", new { });
	}
}
