using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Weapons.Melee;

public class TungstenShortsword : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3489;
	}

	public override void SetDefaults(Item entity)
	{
		entity.AsFood().MaxHealth = 274;
		entity.AsFood().Size = 0.18;
		entity.AsTaggable().Shortsword = true;
	}
}
