using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Placeables.Woods;

public class OakWood : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 9;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 14;
		item.AsFood().Size = 0.08;
	}
}
