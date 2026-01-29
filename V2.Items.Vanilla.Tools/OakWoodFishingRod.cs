using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Tools;

public class OakWoodFishingRod : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 2289;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 58;
		item.AsFood().Size = 0.28;
	}
}
