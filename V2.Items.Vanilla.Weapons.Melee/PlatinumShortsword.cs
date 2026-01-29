using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class PlatinumShortsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3483;
	}

	public override void SetDefaults(Item entity)
	{
		entity.AsFood().MaxHealth = 248;
		entity.AsFood().Size = 0.18;
		entity.AsFood().AcidResistTier = 2;
		entity.AsTaggable().Shortsword = true;
	}
}
