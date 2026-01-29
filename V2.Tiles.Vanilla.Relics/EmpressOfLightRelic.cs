using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace V2.Tiles.Vanilla.Relics;

public class EmpressOfLightRelic : ModTile
{
	public const int FrameWidth = 54;

	public const int FrameHeight = 72;

	public const int HorizontalFrames = 1;

	public const int VerticalFrames = 1;

	public Asset<Texture2D> RelicTexture;

	public virtual string RelicTextureName => "V2/Tiles/Vanilla/Relics/EmpressOfLightRelic_SpriteSheet";

	public override string Texture => "V2/Tiles/Vanilla/Relics/RelicPedestal";

	public override void Load()
	{
		if (!Main.dedServ)
		{
			RelicTexture = ModContent.Request<Texture2D>(RelicTextureName, (AssetRequestMode)2);
		}
	}

	public override void Unload()
	{
		RelicTexture = null;
	}

	public override void SetStaticDefaults()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		Main.tileShine[((ModBlockType)this).Type] = 400;
		Main.tileFrameImportant[((ModBlockType)this).Type] = true;
		TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.DrawYOffset = 2;
		TileObjectData.newTile.Direction = (TileObjectDirection)1;
		TileObjectData.newTile.StyleHorizontal = false;
		TileObjectData.newTile.StyleWrapLimitVisualOverride = 2;
		TileObjectData.newTile.StyleMultiplier = 2;
		TileObjectData.newTile.StyleWrapLimit = 2;
		TileObjectData.newTile.styleLineSkipVisualOverride = 0;
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook((Func<int, int, int, int, int, int, int>)((ModTileEntity)ModContent.GetInstance<EmpressOfLightRelic_TileEntity>()).Hook_AfterPlacement, -1, 0, true);
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
		TileObjectData.newAlternate.Direction = (TileObjectDirection)2;
		TileObjectData.addAlternate(1);
		TileObjectData.addTile((int)((ModBlockType)this).Type);
		((ModTile)this).AddMapEntry(new Color(233, 207, 94), Language.GetText("MapObject.Relic"));
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY)
	{
		((ModTileEntity)ModContent.GetInstance<EmpressOfLightRelic_TileEntity>()).Kill(i, j);
	}

	public override bool CreateDust(int i, int j, ref int type)
	{
		return false;
	}

	public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
	{
		tileFrameX %= 54;
		tileFrameY %= 144;
	}

	public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
	{
	}

	public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		Tile tile = ((Tilemap)(ref Main.tile))[i, j];
		if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out var tileEntity) && tileEntity is EmpressOfLightRelic_TileEntity)
		{
			Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
			Point p = default(Point);
			Rectangle rectangle = default(Rectangle);
			while (enumerator.MoveNext())
			{
				Projectile npc = enumerator.Current;
				if (((Entity)npc).active && Utils.Distance(((Entity)npc).position / 16f, Utils.ToVector2(tileEntity.Position)) < 2f && npc.type == ModContent.ProjectileType<EmpressOfLightRelic_ProjectileEntity>())
				{
					((Point)(ref p))._002Ector(i, j);
					Texture2D value = RelicTexture.Value;
					_ = ((Tile)(ref tile)).TileFrameX / 54;
					bool num = ((Tile)(ref tile)).TileFrameY / 72 != 0;
					int tumSize = EmpressOfLightRelic_ProjectileEntity.GetVisualBellySize(npc);
					((Rectangle)(ref rectangle))._002Ector(0, 88 * tumSize, 88, 84);
					Vector2 val = Utils.ToWorldCoordinates(p, 24f, 64f);
					float num3 = (float)Math.Sin(Main.GlobalTimeWrappedHourly * ((float)Math.PI * 2f) / 5f);
					Vector2 vector2 = val + new Vector2(148f, 124f) + new Vector2(0f, num3 * 4f);
					Color color = Lighting.GetColor(p.X, p.Y);
					SpriteEffects effects = (SpriteEffects)(num ? 1 : 0);
					Main.spriteBatch.Draw(value, vector2 - Main.screenPosition, (Rectangle?)rectangle, color, 0f, default(Vector2), 1f, effects, 0f);
					float num4 = (float)Math.Sin(Main.GlobalTimeWrappedHourly * ((float)Math.PI * 2f) / 2f) * 0.3f + 0.7f;
					Color color2 = color;
					((Color)(ref color2)).A = 0;
					color2 = color2 * 0.1f * num4;
					for (float num5 = 0f; num5 < 1f; num5 += 1f / 6f)
					{
						Main.spriteBatch.Draw(value, vector2 - Main.screenPosition + Utils.ToRotationVector2((float)Math.PI * 2f * num5) * (6f + num3 * 2f), (Rectangle?)rectangle, color2, 0f, default(Vector2), 1f, effects, 0f);
					}
				}
			}
		}
		return true;
	}
}
