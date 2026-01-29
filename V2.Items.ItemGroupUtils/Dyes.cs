using Terraria;
using Terraria.ModLoader;

namespace V2.Items.ItemGroupUtils;

public class Dyes : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return V2Utils.ItemIDSets.Dyes.Contains(entity.type);
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().Size = 0.1;
		item.AsFood().MaxHealth = 85;
	}
}
