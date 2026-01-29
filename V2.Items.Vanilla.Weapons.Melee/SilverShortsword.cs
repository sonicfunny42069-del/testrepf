using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class SilverShortsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3513;
	}

	public override void SetDefaults(Item entity)
	{
		entity.AsFood().MaxHealth = 35;
		entity.AsFood().Size = 0.18;
		entity.AsTaggable().Shortsword = true;
	}
}
