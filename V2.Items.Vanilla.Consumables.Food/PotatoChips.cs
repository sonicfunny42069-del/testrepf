using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Consumables.Food;

public class PotatoChips : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return false;
	}

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 4030;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 453;
		item.AsFood().Size = 0.165;
		item.buffType = 0;
		item.buffTime = 0;
		item.AsFood().EdibleOnUse = true;
		item.AsFood().AlwaysEatenByUse = true;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Consumables.Food.PotatoChips", new { });
	}
}
