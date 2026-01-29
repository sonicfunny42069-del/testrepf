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

namespace V2.Tiles.Vanilla;

public class Sunflower : ModTile
{
	public override void SetStaticDefaults()
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		Main.tileFrameImportant[((ModBlockType)this).Type] = true;
		Main.tileLavaDeath[((ModBlockType)this).Type] = true;
		Sets.FramesOnKillWall[((ModBlockType)this).Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
		TileObjectData.newTile.CoordinateHeights = new int[4] { 16, 16, 16, 16 };
		TileObjectData.newTile.Width = 2;
		TileObjectData.newTile.Height = 4;
		TileObjectData.newTile.AnchorValidTiles = new int[6] { 2, 23, 109, 199, 477, 492 };
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook((Func<int, int, int, int, int, int, int>)((ModTileEntity)ModContent.GetInstance<Sunflower_TileEntity>()).Hook_AfterPlacement, -1, 0, true);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.addTile((int)((ModBlockType)this).Type);
		((ModTile)this).AddMapEntry(new Color(220, 200, 10), Language.GetText("Sunflower"));
		((ModBlockType)this).DustType = 2;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		((ModTileEntity)ModContent.GetInstance<Sunflower_TileEntity>()).Kill(i, j);
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
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		_ = ((Tilemap)(ref Main.tile))[i, j];
		if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var tileEntity) && tileEntity is Sunflower_TileEntity)
		{
			Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
			Rectangle sourceRect = default(Rectangle);
			Rectangle sourceRectGlow = default(Rectangle);
			while (enumerator.MoveNext())
			{
				Projectile npc = enumerator.Current;
				if (((Entity)npc).active && Utils.Distance(((Entity)npc).position / 16f, Utils.ToVector2(tileEntity.Position)) < 2f && npc.type == ModContent.ProjectileType<Sunflower_ProjectileEntity>())
				{
					int tumSize = Sunflower_ProjectileEntity.GetVisualBellySize(npc);
					Sunflower_ProjectileEntity.GetVisualWeightStage(npc);
					Texture2D texture = ModContent.Request<Texture2D>("V2/Tiles/Vanilla/Sunflower_SpriteSheet", (AssetRequestMode)2).Value;
					((Rectangle)(ref sourceRect))._002Ector(32 * (int)npc.ai[0], 64 * tumSize + 2 * tumSize, 32, 66);
					Vector2 zero = (Vector2)(Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange));
					spriteBatch.Draw(texture, new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, (Rectangle?)sourceRect, Lighting.GetColor(i, j), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
					Texture2D textureGlow = ModContent.Request<Texture2D>("V2/Tiles/Vanilla/Sunflower_Glowmask", (AssetRequestMode)2).Value;
					((Rectangle)(ref sourceRectGlow))._002Ector(32 * (int)npc.ai[0], 0, 32, 66);
					spriteBatch.Draw(textureGlow, new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, (Rectangle?)sourceRectGlow, Color.White);
				}
			}
		}
		return false;
	}

	public override void NearbyEffects(int i, int j, bool closer)
	{
		if (!closer)
		{
			Main.SceneMetrics.HasSunflower = true;
		}
	}
}
