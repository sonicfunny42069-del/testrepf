using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class CopperShortsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3507;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 145;
		item.AsFood().Size = 0.18;
		item.AsFood().AcidResistTier = 2;
		item.AsTaggable().Shortsword = true;
	}
}
