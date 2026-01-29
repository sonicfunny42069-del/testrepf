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

public class GraniteLamp : ModTile
{
	public override void HitWire(int i, int j)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		Tile tile = ((Tilemap)(ref Main.tile))[i, j];
		int top = j;
		if (((Tile)(ref tile)).TileFrameY == 18)
		{
			top--;
		}
		else if (((Tile)(ref tile)).TileFrameY == 36)
		{
			top -= 2;
		}
		if (!TileEntity.ByPosition.TryGetValue(new Point16(i, top), out var tileEntity) || !(tileEntity is GraniteLamp_TileEntity))
		{
			return;
		}
		Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Projectile npc = enumerator.Current;
			if (((Entity)npc).active && Utils.Distance(((Entity)npc).position / 16f, Utils.ToVector2(tileEntity.Position)) < 1f && npc.type == ModContent.ProjectileType<GraniteLamp_ProjectileEntity>() && !npc.netUpdate)
			{
				if (npc.ai[0] == 0f)
				{
					npc.ai[0] = 1f;
				}
				else
				{
					npc.ai[0] = 0f;
				}
				npc.netUpdate = true;
			}
		}
	}

	public override void SetStaticDefaults()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		Main.tileFrameImportant[((ModBlockType)this).Type] = true;
		Main.tileLavaDeath[((ModBlockType)this).Type] = true;
		Sets.FramesOnKillWall[((ModBlockType)this).Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
		TileObjectData.newTile.CoordinateHeights = new int[3] { 16, 16, 16 };
		TileObjectData.newTile.Width = 1;
		TileObjectData.newTile.Height = 3;
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook((Func<int, int, int, int, int, int, int>)((ModTileEntity)ModContent.GetInstance<GraniteLamp_TileEntity>()).Hook_AfterPlacement, -1, 0, true);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.addTile((int)((ModBlockType)this).Type);
		((ModTile)this).AddMapEntry(new Color(220, 200, 10), Language.GetText("MapObject.FloorLamp"));
		((ModBlockType)this).DustType = 2;
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		((ModTileEntity)ModContent.GetInstance<GraniteLamp_TileEntity>()).Kill(i, j);
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
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		_ = ((Tilemap)(ref Main.tile))[i, j];
		if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var tileEntity) && tileEntity is GraniteLamp_TileEntity)
		{
			Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
			Rectangle sourceRect = default(Rectangle);
			while (enumerator.MoveNext())
			{
				Projectile npc = enumerator.Current;
				if (((Entity)npc).active && Utils.Distance(((Entity)npc).position / 16f, Utils.ToVector2(tileEntity.Position)) < 1f && npc.type == ModContent.ProjectileType<GraniteLamp_ProjectileEntity>())
				{
					int tumSize = GraniteLamp_ProjectileEntity.GetVisualBellySize(npc);
					int weightSize = GraniteLamp_ProjectileEntity.GetVisualWeightStage(npc);
					Texture2D texture = ModContent.Request<Texture2D>("V2/Tiles/Vanilla/GraniteLamp_SpriteSheet", (AssetRequestMode)2).Value;
					((Rectangle)(ref sourceRect))._002Ector(48 * (int)npc.ai[0] + 96 * weightSize, 64 * tumSize, 48, 64);
					Vector2 zero = (Vector2)(Main.drawToScreen ? Vector2.Zero : new Vector2((float)Main.offScreenRange));
					spriteBatch.Draw(texture, new Vector2((float)(i * 16 - (int)Main.screenPosition.X - 16), (float)(j * 16 - (int)Main.screenPosition.Y - 14)) + zero, (Rectangle?)sourceRect, Lighting.GetColor(i, j), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
				}
			}
		}
		return false;
	}
}
