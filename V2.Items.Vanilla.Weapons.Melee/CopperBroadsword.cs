using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class CopperBroadsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3508;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 435;
		item.AsFood().Size = 0.54;
		item.AsFood().AcidResistTier = 2;
		item.AsTaggable().Broadsword = true;
	}
}
