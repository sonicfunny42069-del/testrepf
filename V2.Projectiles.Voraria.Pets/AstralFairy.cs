using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.Projectiles.Voraria.Pets;

public class AstralFairy : ModProjectile
{
	public (Projectile, NPC) target = (null, null);

	public override void SetStaticDefaults()
	{
		Main.projFrames[((ModProjectile)this).Projectile.type] = 4;
		Sets.MinionTargettingFeature[((ModProjectile)this).Projectile.type] = true;
		Main.projPet[((ModProjectile)this).Projectile.type] = true;
	}

	public sealed override void SetDefaults()
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		((ModProjectile)this).Projectile.CloneDefaults(882);
		((ModProjectile)this).Projectile.aiStyle = -1;
		((Entity)((ModProjectile)this).Projectile).width = 50;
		((Entity)((ModProjectile)this).Projectile).height = 182;
		((ModProjectile)this).Projectile.AsV2Proj().Gender = EntityGender.Female;
		((ModProjectile)this).Projectile.AsPred().MaxStomachCapacity = AstralFairyStuff.MaxStomachCapacity;
		((ModProjectile)this).Projectile.AsPred().BaseStomachacheMeterCapacity = AstralFairyStuff.Stomachache;
		((ModProjectile)this).Projectile.AsPred().CanSwallowBosses = true;
		((ModProjectile)this).Projectile.AsFood().DefinedSize = AstralFairyStuff.Size;
		((ModProjectile)this).Projectile.AsFood().MaxHealth = AstralFairyStuff.MaxHealth;
		((ModProjectile)this).Projectile.AsFood().Health = AstralFairyStuff.MaxHealth;
		((ModProjectile)this).Projectile.AsPred().MouthSoundRawOffset = new Vector2(0f, -14f);
		((ModProjectile)this).Projectile.AsPred().SmallGulps = Gulps.Short;
		((ModProjectile)this).Projectile.AsPred().SmallGulpThreshold = 0.1;
		((ModProjectile)this).Projectile.AsPred().BigGulps = Gulps.Standard;
		((ModProjectile)this).Projectile.AsPred().CanBeForceFed = CanAstralFairyBeForceFed;
		((ModProjectile)this).Projectile.AsPred().OnForceFed = OnAstralFairyForceFed;
		((ModProjectile)this).Projectile.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(12.5);
		((ModProjectile)this).Projectile.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModProjectile)this).Projectile.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModProjectile)this).Projectile.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModProjectile)this).Projectile.AsPred().SmallBurps = Burps.Humanoid.Small;
		((ModProjectile)this).Projectile.AsPred().StandardBurps = Burps.Humanoid.Standard;
		((ModProjectile)this).Projectile.AsPred().BurpPitchOffset = -0.1f;
		((ModProjectile)this).Projectile.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModProjectile)this).Projectile.AsPred().GetVisualBellySize = GetVisualBellySize;
		((ModProjectile)this).Projectile.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		PreyProjectile preyProjectile = ((ModProjectile)this).Projectile.AsFood();
		preyProjectile.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(PreyProjectile.OnKilledByDigestion_GrantLivePreyGoal));
		PreyProjectile preyProjectile2 = ((ModProjectile)this).Projectile.AsFood();
		preyProjectile2.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile2.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(OnKilledByDigestion));
	}

	public static bool CanAstralFairyBeForceFed(Projectile projectile)
	{
		return true;
	}

	public static void OnAstralFairyForceFed(Projectile projectile, Player player)
	{
	}

	public static void OnKilledByDigestion(Projectile projectile, Entity pred)
	{
		Player ownerPlayer = Main.player[projectile.owner];
		if (ownerPlayer.ownedProjectileCounts[projectile.type] <= 1)
		{
			ownerPlayer.ClearBuff(ModContent.BuffType<AstralFairyBuff>());
		}
	}

	public static int GetVisualBellySize(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(4.0 * Math.Sqrt(PredProjectile.GetCurrentBellyWeight(projectile))), 4);
	}

	public static int GetVisualWeightStage(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(1.4 * Math.Sqrt(projectile.AsPred().ExtraWeight)), 0);
	}

	public static double GetDigestionTickDamage(Projectile projectile, PreyData prey)
	{
		return AstralFairyStuff.DigestDamage;
	}

	public static double GetDigestionTickRate(Projectile projectile, PreyData prey)
	{
		double digestRate = AstralFairyStuff.DigestRate;
		Player ownerPlayer = Main.player[projectile.owner];
		if (!ownerPlayer.dead && ((PlayerSleepingHelper)(ref ownerPlayer.sleeping)).FullyFallenAsleep)
		{
			digestRate *= 1.5;
			if (CurrentFrameFlags.SleepingPlayersCount == CurrentFrameFlags.ActivePlayersCount && CurrentFrameFlags.SleepingPlayersCount > 0)
			{
				digestRate *= (double)(float)Main.dayRate;
			}
		}
		return digestRate;
	}

	public static double GetPreyAbsorptionRate(Projectile projectile)
	{
		double absorbRate = AstralFairyStuff.AbsorbRate;
		Player ownerPlayer = Main.player[projectile.owner];
		if (!ownerPlayer.dead && ((PlayerSleepingHelper)(ref ownerPlayer.sleeping)).FullyFallenAsleep)
		{
			absorbRate *= 3.0;
			if (CurrentFrameFlags.SleepingPlayersCount == CurrentFrameFlags.ActivePlayersCount && CurrentFrameFlags.SleepingPlayersCount > 0)
			{
				absorbRate *= (double)(float)Main.dayRate;
			}
		}
		return absorbRate;
	}

	public override bool? CanCutTiles()
	{
		return false;
	}

	public override bool MinionContactDamage()
	{
		return false;
	}

	public override void AI()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		Player owner = Main.player[((ModProjectile)this).Projectile.owner];
		bool churnedOwner;
		bool num = owner.IsFoodFor((Entity)(object)((ModProjectile)this).Projectile, out churnedOwner);
		PredProjectile.GetStomachTracker(((ModProjectile)this).Projectile);
		CheckActive(owner);
		if ((num && !churnedOwner) || owner.dead)
		{
			Projectile projectile = ((ModProjectile)this).Projectile;
			((Entity)projectile).velocity = ((Entity)projectile).velocity * 0.9f;
			return;
		}
		Vector2 sitPosition = ((Entity)owner).Center + new Vector2(0f, -160f);
		((Entity)((ModProjectile)this).Projectile).velocity = Utils.DirectionTo(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) * (Utils.Distance(((Entity)((ModProjectile)this).Projectile).position, sitPosition) / 32f);
		if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 1f)
		{
			Projectile projectile2 = ((ModProjectile)this).Projectile;
			((Entity)projectile2).velocity = ((Entity)projectile2).velocity * 0f;
		}
		else if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 5f)
		{
			Projectile projectile3 = ((ModProjectile)this).Projectile;
			((Entity)projectile3).velocity = ((Entity)projectile3).velocity * 0.1f;
		}
		else if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 15f)
		{
			Projectile projectile4 = ((ModProjectile)this).Projectile;
			((Entity)projectile4).velocity = ((Entity)projectile4).velocity * 0.25f;
		}
		else if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 25f)
		{
			Projectile projectile5 = ((ModProjectile)this).Projectile;
			((Entity)projectile5).velocity = ((Entity)projectile5).velocity * 0.4f;
		}
		else if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 35f)
		{
			Projectile projectile6 = ((ModProjectile)this).Projectile;
			((Entity)projectile6).velocity = ((Entity)projectile6).velocity * 0.55f;
		}
		else if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 45f)
		{
			Projectile projectile7 = ((ModProjectile)this).Projectile;
			((Entity)projectile7).velocity = ((Entity)projectile7).velocity * 0.7f;
		}
		else if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).Center, sitPosition) < 55f)
		{
			Projectile projectile8 = ((ModProjectile)this).Projectile;
			((Entity)projectile8).velocity = ((Entity)projectile8).velocity * 0.85f;
		}
	}

	public static Rectangle TumBounds(int size, out int YOffset, out int XOffset)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		Rectangle bounds = default(Rectangle);
		((Rectangle)(ref bounds))._002Ector(0, 0, 38, 28);
		YOffset = 0;
		XOffset = 0;
		switch (size)
		{
		case 0:
			((Rectangle)(ref bounds))._002Ector(0, 0, 38, 28);
			break;
		case 1:
			((Rectangle)(ref bounds))._002Ector(0, 30, 38, 32);
			break;
		case 2:
			((Rectangle)(ref bounds))._002Ector(0, 64, 38, 36);
			break;
		case 3:
			((Rectangle)(ref bounds))._002Ector(0, 102, 42, 40);
			break;
		case 4:
			((Rectangle)(ref bounds))._002Ector(0, 144, 46, 48);
			break;
		}
		XOffset = -(bounds.Width - 38) / 2;
		return bounds;
	}

	public override void PostAI()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		int framerate = 12;
		Projectile projectile = ((ModProjectile)this).Projectile;
		projectile.frameCounter++;
		if (((ModProjectile)this).Projectile.frameCounter >= framerate)
		{
			((ModProjectile)this).Projectile.frameCounter = 0;
			Projectile projectile2 = ((ModProjectile)this).Projectile;
			projectile2.frame++;
			if (((ModProjectile)this).Projectile.frame >= Main.projFrames[((ModProjectile)this).Projectile.type])
			{
				((ModProjectile)this).Projectile.frame = 0;
			}
		}
		Lighting.AddLight(((Entity)((ModProjectile)this).Projectile).Center, new Vector3(111f, 0f, 255f) * 0.005f);
	}

	public void CheckActive(Player player)
	{
		if (player.HasBuff(ModContent.BuffType<AstralFairyBuff>()))
		{
			((ModProjectile)this).Projectile.timeLeft = 2;
		}
	}

	public override bool PreDraw(ref Color lightColor)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		SpriteEffects spriteEffects = (SpriteEffects)(((Entity)((ModProjectile)this).Projectile).direction == -1);
		Vector2 ExtraOffset = default(Vector2);
		((Vector2)(ref ExtraOffset))._002Ector(-32f, -14f);
		Texture2D value = ModContent.Request<Texture2D>("V2/Projectiles/Voraria/Pets/AstralFairyWings", (AssetRequestMode)2).Value;
		Rectangle sourceRectWings = default(Rectangle);
		((Rectangle)(ref sourceRectWings))._002Ector(0, 212 * ((ModProjectile)this).Projectile.frame, 114, 212);
		Main.EntitySpriteDraw(value, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition + ExtraOffset + new Vector2(0f, ((ModProjectile)this).Projectile.gfxOffY), (Rectangle?)sourceRectWings, lightColor, ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		int bodyFrame = ((ModProjectile)this).Projectile.frame % 2;
		Texture2D value2 = ModContent.Request<Texture2D>("V2/Projectiles/Voraria/Pets/AstralFairy", (AssetRequestMode)2).Value;
		Rectangle sourceRectBody = default(Rectangle);
		((Rectangle)(ref sourceRectBody))._002Ector(0, 212 * bodyFrame, 114, 212);
		Main.EntitySpriteDraw(value2, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition + ExtraOffset + new Vector2(0f, ((ModProjectile)this).Projectile.gfxOffY), (Rectangle?)sourceRectBody, lightColor, ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		int YOffset;
		int XOffset;
		Rectangle TumBox = TumBounds(GetVisualBellySize(((ModProjectile)this).Projectile), out YOffset, out XOffset);
		Vector2 TumOffset = default(Vector2);
		((Vector2)(ref TumOffset))._002Ector(38f, 82f);
		Main.EntitySpriteDraw(ModContent.Request<Texture2D>("V2/Projectiles/Voraria/Pets/AstralFairyTums", (AssetRequestMode)2).Value, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition + ExtraOffset + TumOffset + new Vector2(0f, ((ModProjectile)this).Projectile.gfxOffY) + new Vector2((float)XOffset, (float)YOffset), (Rectangle?)TumBox, lightColor, ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		return false;
	}
}
