using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Weapons.Summon;

public class SlimeStaff : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 1309;
	}

	public override void SetStaticDefaults()
	{
		Sets.ShimmerTransformToItem[1309] = ModContent.ItemType<ShroomStaff>();
	}
}
