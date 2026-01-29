using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Items.Voraria.Charms;

namespace V2.Core.WorldGeneration;

public static class WorldGenDetours
{
	public static void TurnGoldChestIntoDeadMansChest(Point position)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				int num = position.X + i;
				int num2 = position.Y + j;
				Tile tile = ((Tilemap)(ref Main.tile))[num, num2];
				((Tile)(ref tile)).TileType = 467;
				((Tile)(ref tile)).TileFrameX = (short)(144 + i * 18);
				((Tile)(ref tile)).TileFrameY = (short)(j * 18);
			}
		}
		int num3 = Chest.FindChest(position.X, position.Y);
		if (num3 <= -1)
		{
			return;
		}
		Item[] item = Main.chest[num3].item;
		if (Utils.NextBool(WorldGen.genRand, 3))
		{
			for (int num4 = item.Length - 2; num4 > 0; num4--)
			{
				Item item2 = item[num4];
				if (item2.stack != 0)
				{
					item[num4 + 1] = item2.Clone();
				}
			}
			item[1] = new Item();
			item[1].SetDefaults(5007);
			Main.chest[num3].item = item;
		}
		if (Utils.NextBool(WorldGen.genRand, 4))
		{
			return;
		}
		for (int num5 = item.Length - 2; num5 > 0; num5--)
		{
			Item item3 = item[num5];
			if (item3.stack != 0)
			{
				item[num5 + 1] = item3.Clone();
			}
		}
		item[1] = new Item();
		item[1].SetDefaults(ModContent.ItemType<CharmPreyItemTheft>());
		Main.chest[num3].item = item;
	}
}
