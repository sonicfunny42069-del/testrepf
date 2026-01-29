using Terraria;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace V2.Tiles;

public static class TileUtils
{
	public static Point16 GetTopLeftTileInMultitile(int x, int y)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		Tile tile = ((Tilemap)(ref Main.tile))[x, y];
		int frameX = 0;
		int frameY = 0;
		if (((Tile)(ref tile)).HasTile)
		{
			int style = 0;
			int alt = 0;
			TileObjectData.GetTileInfo(tile, ref style, ref alt);
			TileObjectData data = TileObjectData.GetTileData((int)((Tile)(ref tile)).TileType, style, alt);
			if (data != null)
			{
				int size = 16 + data.CoordinatePadding;
				frameX = ((Tile)(ref tile)).TileFrameX % (size * data.Width) / size;
				frameY = ((Tile)(ref tile)).TileFrameY % (size * data.Height) / size;
			}
		}
		return new Point16(x - frameX, y - frameY);
	}

	public static bool TryGetTileEntityAs<T>(int i, int j, out T entity) where T : TileEntity
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		Point16 origin = GetTopLeftTileInMultitile(i, j);
		if (TileEntity.ByPosition.TryGetValue(origin, out var existing))
		{
			T existingAsT = (T)(object)((existing is T) ? existing : null);
			if (existingAsT != null)
			{
				entity = existingAsT;
				return true;
			}
		}
		entity = default(T);
		return false;
	}
}
