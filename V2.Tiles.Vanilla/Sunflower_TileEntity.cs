using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Projectiles;

namespace V2.Tiles.Vanilla;

public class Sunflower_TileEntity : ModTileEntity
{
	public Projectile connectedNPC;

	public double WeightOnLoad;

	public override void Update()
	{
		if (connectedNPC == null)
		{
			Activate();
		}
		else if (!((Entity)connectedNPC).active || connectedNPC.type != ModContent.ProjectileType<Sunflower_ProjectileEntity>())
		{
			Activate();
		}
	}

	public void Activate()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Projectile npc = enumerator.Current;
			if (((Entity)npc).active && Utils.Distance(((Entity)npc).position / 16f, Utils.ToVector2(((TileEntity)this).Position)) < 1f && npc.type == ModContent.ProjectileType<Sunflower_ProjectileEntity>())
			{
				connectedNPC = npc;
				return;
			}
		}
		if (Main.netMode != 1)
		{
			int num = Projectile.NewProjectile((IEntitySource)new EntitySource_TileEntity((TileEntity)(object)this, (string)null), new Vector2((float)(((TileEntity)this).Position.X * 16 + 16), (float)(((TileEntity)this).Position.Y * 16 + 32)), Vector2.Zero, ModContent.ProjectileType<Sunflower_ProjectileEntity>(), 0, 0f, -1, 0f, 0f, 0f);
			connectedNPC = Main.projectile[num];
			connectedNPC.AsPred().ExtraWeight = WeightOnLoad;
			Main.projectile[num].netUpdate = true;
			if (Main.netMode != 0)
			{
				NetMessage.SendData(86, -1, -1, (NetworkText)null, ((TileEntity)this).ID, (float)((TileEntity)this).Position.X, (float)((TileEntity)this).Position.Y, 0f, 0, 0, 0);
			}
		}
	}

	public override bool IsTileValidForEntity(int x, int y)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Tile tile = ((Tilemap)(ref Main.tile))[x, y];
		if (((Tile)(ref tile)).HasTile)
		{
			return ((Tile)(ref tile)).TileType == ModContent.TileType<Sunflower>();
		}
		return false;
	}

	public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alternate)
	{
		if (Main.netMode == 1)
		{
			int width = 4;
			int height = 4;
			NetMessage.SendTileSquare(Main.myPlayer, i, j, width, height, (TileChangeType)0);
			NetMessage.SendData(87, -1, -1, (NetworkText)null, i, (float)j, (float)((ModTileEntity)this).Type, 0f, 0, 0, 0);
			return -1;
		}
		return ((ModTileEntity)this).Place(i, j);
	}

	public override void OnNetPlace()
	{
		if (Main.netMode == 2)
		{
			NetMessage.SendData(86, -1, -1, (NetworkText)null, ((TileEntity)this).ID, (float)((TileEntity)this).Position.X, (float)((TileEntity)this).Position.Y, 0f, 0, 0, 0);
		}
	}

	public override void SaveData(TagCompound tag)
	{
		tag.Add("ExtraWeight", (object)connectedNPC.AsPred().ExtraWeight);
	}

	public override void LoadData(TagCompound tag)
	{
		WeightOnLoad = tag.GetDouble("ExtraWeight");
	}
}
