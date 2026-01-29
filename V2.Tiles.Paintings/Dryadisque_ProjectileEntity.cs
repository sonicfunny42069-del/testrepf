using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.Projectiles;
using V2.Sounds.Vore;

namespace V2.Tiles.Paintings;

public class Dryadisque_ProjectileEntity : ModProjectile
{
	public override string Texture => "V2/Tiles/Paintings/InvisibleImage";

	public override void SetDefaults()
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		((ModProjectile)this).Projectile.friendly = true;
		((Entity)((ModProjectile)this).Projectile).width = 96;
		((Entity)((ModProjectile)this).Projectile).height = 64;
		((ModProjectile)this).Projectile.aiStyle = -1;
		((ModProjectile)this).Projectile.damage = 0;
		((ModProjectile)this).Projectile.timeLeft = 6000;
		((ModProjectile)this).Projectile.tileCollide = false;
		((ModProjectile)this).Projectile.AsFood().CannotBeEatenDueToShenanigans = true;
		((ModProjectile)this).Projectile.AsFood().DefinedSize = 24.0;
		((ModProjectile)this).Projectile.AsPred().WeightGainRatio = 0.0;
		((ModProjectile)this).Projectile.AsPred().MaxStomachCapacity = 9.0;
		((ModProjectile)this).Projectile.AsPred().BaseStomachacheMeterCapacity = 750.0;
		((ModProjectile)this).Projectile.AsPred().CanSwallowBosses = false;
		((ModProjectile)this).Projectile.AsFood().MaxHealth = 7500.0;
		((ModProjectile)this).Projectile.AsFood().Health = 7500.0;
		((ModProjectile)this).Projectile.AsPred().MouthSoundRawOffset = new Vector2(0f, -14f);
		((ModProjectile)this).Projectile.AsPred().SmallGulps = Gulps.Short;
		((ModProjectile)this).Projectile.AsPred().SmallGulpThreshold = 0.1;
		((ModProjectile)this).Projectile.AsPred().BigGulps = Gulps.Standard;
		((ModProjectile)this).Projectile.AsPred().CanBeForceFed = CanPaintingBeForceFed;
		((ModProjectile)this).Projectile.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(12.5);
		((ModProjectile)this).Projectile.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModProjectile)this).Projectile.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModProjectile)this).Projectile.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModProjectile)this).Projectile.AsPred().SmallBurps = Burps.Humanoid.Small;
		((ModProjectile)this).Projectile.AsPred().StandardBurps = Burps.Humanoid.Standard;
		((ModProjectile)this).Projectile.AsPred().BurpPitchOffset = 0f;
		((ModProjectile)this).Projectile.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModProjectile)this).Projectile.AsPred().GetVisualBellySize = GetVisualBellySize;
		((ModProjectile)this).Projectile.AsPred().GetVisualWeightStage = GetVisualWeightStage;
	}

	public override bool? CanHitNPC(NPC target)
	{
		return false;
	}

	public override bool CanHitPlayer(Player target)
	{
		return false;
	}

	public override bool CanHitPvp(Player target)
	{
		return false;
	}

	public static bool CanPaintingBeForceFed(Projectile projectile)
	{
		return true;
	}

	public override void AI()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		((ModProjectile)this).Projectile.ai[0] -= 1f;
		if (((ModProjectile)this).Projectile.ai[0] <= 0f)
		{
			((ModProjectile)this).Projectile.ai[0] = Main.rand.Next(300, 600);
		}
		((ModProjectile)this).Projectile.timeLeft = 6000;
		((Entity)((ModProjectile)this).Projectile).velocity = Vector2.Zero;
		Tile Painting = ((Tilemap)(ref Main.tile))[Utils.ToTileCoordinates(((Entity)((ModProjectile)this).Projectile).position)];
		if (!((Tile)(ref Painting)).HasTile || ((Tile)(ref Painting)).TileType != ModContent.TileType<Dryadisque>())
		{
			((Entity)((ModProjectile)this).Projectile).active = false;
		}
		if (Utils.NextBool(Main.rand, 100))
		{
			((ModProjectile)this).Projectile.DoContactGulpage();
		}
	}

	public override void PostAI()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModProjectile)this).Projectile).velocity = Vector2.Zero;
	}

	public static int GetVisualBellySize(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(3.0 * Math.Sqrt(PredProjectile.GetCurrentBellyWeight(projectile))), 7);
	}

	public static int GetVisualWeightStage(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(2.0 * Math.Sqrt(projectile.AsPred().ExtraWeight)), 0);
	}

	public static double GetDigestionTickDamage(Projectile projectile, PreyData prey)
	{
		return 22.0;
	}

	public static double GetDigestionTickRate(Projectile projectile, PreyData prey)
	{
		return 1.2;
	}

	public static double GetPreyAbsorptionRate(Projectile projectile)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 0, 45);
	}
}
