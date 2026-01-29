using Terraria;
using Terraria.ModLoader;
using V2.Tiles.Vanilla;

namespace V2.Items.Vanilla.Placeables.Plants;

internal class Sunflower : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 63;
	}

	public override void SetDefaults(Item entity)
	{
		entity.DefaultToPlaceableTile(ModContent.TileType<global::V2.Tiles.Vanilla.Sunflower>(), 0);
	}
}
