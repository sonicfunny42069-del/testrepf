using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Tools;

public class OakWoodHammer : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 196;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 165;
		item.AsFood().Size = 0.45;
	}
}
