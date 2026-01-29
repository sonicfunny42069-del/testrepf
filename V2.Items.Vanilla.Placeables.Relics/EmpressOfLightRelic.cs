using Terraria;
using Terraria.ModLoader;
using V2.Tiles.Vanilla.Relics;

namespace V2.Items.Vanilla.Placeables.Relics;

internal class EmpressOfLightRelic : GlobalItem
{
	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 4949;
	}

	public override void SetDefaults(Item entity)
	{
		entity.DefaultToPlaceableTile(ModContent.TileType<global::V2.Tiles.Vanilla.Relics.EmpressOfLightRelic>(), 0);
	}
}
