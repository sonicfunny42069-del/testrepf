using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace V2.Tiles.Paintings;

public class DoNotEatTheVileMushroom : ModTile
{
	public override void SetStaticDefaults()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		Main.tileFrameImportant[((ModBlockType)this).Type] = true;
		Main.tileLavaDeath[((ModBlockType)this).Type] = true;
		Sets.FramesOnKillWall[((ModBlockType)this).Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
		TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 16 };
		TileObjectData.newTile.Width = 6;
		TileObjectData.newTile.Height = 4;
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook((Func<int, int, int, int, int, int, int>)((ModTileEntity)ModContent.GetInstance<DoNotEatTheVileMushroom_TileEntity>()).Hook_AfterPlacement, -1, 0, true);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.addTile((int)((ModBlockType)this).Type);
		((ModTile)this).AddMapEntry(new Color(120, 85, 60), Language.GetText("MapObject.Painting"));
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		((ModTileEntity)ModContent.GetInstance<DoNotEatTheVileMushroom_TileEntity>()).Kill(i, j);
	}

	public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		_ = ((Tilemap)(ref Main.tile))[i, j];
		if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var tileEntity) && tileEntity is DoNotEatTheVileMushroom_TileEntity)
		{
			Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
			Rectangle sourceRect = default(Rectangle);
			while (enumerator.MoveNext())
			{
				Projectile npc = enumerator.Current;
				if (((Entity)npc).active && Utils.Distance(((Entity)npc).position / 16f, Utils.ToVector2(tileEntity.Position)) < 2f && npc.type == ModContent.ProjectileType<DoNotEatTheVileMushroom_ProjectileEntity>())
				{
					int XOffset = 0;
					int YSize = 64;
					if (npc.ai[0] <= 6f)
					{
						XOffset = 192;
					}
					else if (npc.ai[0] <= 12f)
					{
						XOffset = 96;
					}
					int tumSize = DoNotEatTheVileMushroom_ProjectileEntity.GetVisualBellySize(npc);
					if (tumSize == 7)
					{
						YSize = 74;
					}
					Texture2D texture = ModContent.Request<Texture2D>("V2/Tiles/Paintings/DoNotEatTheVileMushroom_SpriteSheet", (AssetRequestMode)2).Value;
					((Rectangle)(ref sourceRect))._002Ector(XOffset, 64 * tumSize, 96, YSize);
					Vector2 zero = (Vector2)(Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange));
					spriteBatch.Draw(texture, new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, (Rectangle?)sourceRect, Lighting.GetColor(i, j), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
				}
			}
		}
		return false;
	}
}
