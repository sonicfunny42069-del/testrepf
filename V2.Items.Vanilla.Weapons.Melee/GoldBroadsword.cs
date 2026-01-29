using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class GoldBroadsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3520;
	}

	public override void SetDefaults(Item entity)
	{
		entity.AsFood().MaxHealth = 312;
		entity.AsFood().Size = 0.54;
		entity.AsFood().AcidResistTier = 2;
		entity.AsTaggable().Broadsword = true;
	}
}
