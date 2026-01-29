using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class IronShortsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 6;
	}

	public override void SetDefaults(Item entity)
	{
		entity.AsFood().MaxHealth = 165;
		entity.AsFood().Size = 0.18;
		entity.AsFood().AcidResistTier = 2;
		entity.AsTaggable().Shortsword = true;
	}
}
