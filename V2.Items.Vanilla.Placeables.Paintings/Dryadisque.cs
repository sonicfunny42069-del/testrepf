using Terraria;
using Terraria.ModLoader;
using V2.Tiles.Paintings;

namespace V2.Items.Vanilla.Placeables.Paintings;

internal class Dryadisque : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 1426;
	}

	public override void SetDefaults(Item entity)
	{
		entity.DefaultToPlaceableTile(ModContent.TileType<global::V2.Tiles.Paintings.Dryadisque>(), 0);
	}
}
