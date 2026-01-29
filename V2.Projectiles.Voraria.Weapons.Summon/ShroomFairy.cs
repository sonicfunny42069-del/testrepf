using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.Projectiles.Voraria.Weapons.Summon;

public class ShroomFairy : ModProjectile
{
	public (Projectile, NPC) target = (null, null);

	public override void SetStaticDefaults()
	{
		Main.projFrames[((ModProjectile)this).Projectile.type] = 4;
		Sets.MinionTargettingFeature[((ModProjectile)this).Projectile.type] = true;
		Main.projPet[((ModProjectile)this).Projectile.type] = true;
		Sets.MinionSacrificable[((ModProjectile)this).Projectile.type] = true;
	}

	public sealed override void SetDefaults()
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModProjectile)this).Projectile).width = 32;
		((Entity)((ModProjectile)this).Projectile).height = 52;
		((ModProjectile)this).Projectile.tileCollide = false;
		((ModProjectile)this).Projectile.friendly = true;
		((ModProjectile)this).Projectile.minion = true;
		((ModProjectile)this).Projectile.DamageType = DamageClass.Summon;
		((ModProjectile)this).Projectile.minionSlots = 1.5f;
		((ModProjectile)this).Projectile.penetrate = -1;
		((ModProjectile)this).Projectile.AsV2Proj().Gender = EntityGender.Female;
		((ModProjectile)this).Projectile.AsPred().MaxStomachCapacity = ShroomFairyStuff.MaxStomachCapacity;
		((ModProjectile)this).Projectile.AsPred().BaseStomachacheMeterCapacity = ShroomFairyStuff.Stomachache;
		((ModProjectile)this).Projectile.AsPred().CanSwallowBosses = false;
		((ModProjectile)this).Projectile.AsFood().DefinedSize = ShroomFairyStuff.Size;
		((ModProjectile)this).Projectile.AsFood().MaxHealth = ShroomFairyStuff.MaxHealth;
		((ModProjectile)this).Projectile.AsFood().Health = ShroomFairyStuff.MaxHealth;
		((ModProjectile)this).Projectile.AsPred().MouthSoundRawOffset = new Vector2(0f, -14f);
		((ModProjectile)this).Projectile.AsPred().SmallGulps = Gulps.Short;
		((ModProjectile)this).Projectile.AsPred().SmallGulpThreshold = 0.1;
		((ModProjectile)this).Projectile.AsPred().BigGulps = Gulps.Standard;
		((ModProjectile)this).Projectile.AsPred().CanBeForceFed = CanShroomFairyBeForceFed;
		((ModProjectile)this).Projectile.AsPred().OnForceFed = OnShroomFairyForceFed;
		((ModProjectile)this).Projectile.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(12.5);
		((ModProjectile)this).Projectile.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModProjectile)this).Projectile.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModProjectile)this).Projectile.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModProjectile)this).Projectile.AsPred().SmallBurps = Burps.Humanoid.Small;
		((ModProjectile)this).Projectile.AsPred().StandardBurps = Burps.Humanoid.Standard;
		((ModProjectile)this).Projectile.AsPred().BurpPitchOffset = 0.4f;
		((ModProjectile)this).Projectile.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModProjectile)this).Projectile.AsPred().GetVisualBellySize = GetVisualBellySize;
		((ModProjectile)this).Projectile.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		PreyProjectile preyProjectile = ((ModProjectile)this).Projectile.AsFood();
		preyProjectile.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(PreyProjectile.OnKilledByDigestion_GrantLivePreyGoal));
		PreyProjectile preyProjectile2 = ((ModProjectile)this).Projectile.AsFood();
		preyProjectile2.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile2.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(OnKilledByDigestion));
	}

	public static bool CanShroomFairyBeForceFed(Projectile projectile)
	{
		return true;
	}

	public static void OnShroomFairyForceFed(Projectile projectile, Player player)
	{
	}

	public static void OnKilledByDigestion(Projectile projectile, Entity pred)
	{
		Player ownerPlayer = Main.player[projectile.owner];
		if (ownerPlayer.ownedProjectileCounts[projectile.type] <= 1)
		{
			ownerPlayer.ClearBuff(ModContent.BuffType<ShroomFairyBuff>());
		}
	}

	public static int GetVisualBellySize(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(3.0 * Math.Sqrt(PredProjectile.GetCurrentBellyWeight(projectile))), 3 + GetVisualWeightStage(projectile));
	}

	public static int GetVisualWeightStage(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(1.4 * Math.Sqrt(projectile.AsPred().ExtraWeight)), 8);
	}

	public static double GetDigestionTickDamage(Projectile projectile, PreyData prey)
	{
		double digestDamage = ShroomFairyStuff.DigestDamage;
		if (IsFairyAtMaxCapacity(projectile))
		{
			digestDamage *= 2.0;
		}
		return digestDamage;
	}

	public static double GetDigestionTickRate(Projectile projectile, PreyData prey)
	{
		double digestRate = ShroomFairyStuff.DigestRate;
		if (IsFairyAtMaxCapacity(projectile))
		{
			digestRate *= 2.0;
		}
		Player ownerPlayer = Main.player[projectile.owner];
		if (!ownerPlayer.dead && ((PlayerSleepingHelper)(ref ownerPlayer.sleeping)).FullyFallenAsleep)
		{
			digestRate *= 1.25;
			if (CurrentFrameFlags.SleepingPlayersCount == CurrentFrameFlags.ActivePlayersCount && CurrentFrameFlags.SleepingPlayersCount > 0)
			{
				digestRate *= (double)(float)Main.dayRate;
			}
		}
		return digestRate;
	}

	public static double GetPreyAbsorptionRate(Projectile projectile)
	{
		double absorbRate = ShroomFairyStuff.AbsorbRate * (1.0 + (double)GetVisualWeightStage(projectile) / 1.5);
		Player ownerPlayer = Main.player[projectile.owner];
		if (IsFairyAtMaxCapacity(projectile))
		{
			absorbRate *= 2.0;
		}
		if (!ownerPlayer.dead && ((PlayerSleepingHelper)(ref ownerPlayer.sleeping)).FullyFallenAsleep)
		{
			absorbRate *= 1.75;
			if (CurrentFrameFlags.SleepingPlayersCount == CurrentFrameFlags.ActivePlayersCount && CurrentFrameFlags.SleepingPlayersCount > 0)
			{
				absorbRate *= (double)(float)Main.dayRate;
			}
		}
		if (ownerPlayer.AsV2Player().ShroomNecklace)
		{
			absorbRate *= 1.350000023841858;
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

	public override void OnSpawn(IEntitySource source)
	{
		DustEffect(((ModProjectile)this).Projectile);
	}

	public static void DustEffect(Projectile projectile)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), 0f, 2f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), 1.5f, 1.5f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), 2f, 0f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), 1.5f, -1.5f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), 0f, -2f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), -1.5f, -1.5f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), -2f, 0f, 0, default(Color), 1f);
		Dust.NewDustDirect(((Entity)projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), -1.5f, 1.5f, 0, default(Color), 1f);
		Dust.NewDustPerfect(((Entity)projectile).Center, ModContent.DustType<ShroomFairyDust2>(), (Vector2?)Vector2.Zero, 0, default(Color), 1f);
	}

	public static Vector2 AnglePosition(int Count, int TotalCount)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		Vector2 Angle = default(Vector2);
		((Vector2)(ref Angle))._002Ector(0f, -1f);
		if (TotalCount > 1)
		{
			float multiplier = (float)Count / (float)(TotalCount - 1);
			((Vector2)(ref Angle))._002Ector(-1f, 0f);
			Angle = Utils.RotatedBy(Angle, (double)(180f * multiplier) * Math.PI / 180.0, default(Vector2));
			return Angle;
		}
		return Angle;
	}

	public static void GetIdlePosition(Projectile projectile, out int thisProjectilePosition, out int totalFairyCount)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		thisProjectilePosition = 0;
		totalFairyCount = 0;
		Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Projectile proj = enumerator.Current;
			if (((Entity)proj).active && proj.owner == projectile.owner && proj.type == ModContent.ProjectileType<ShroomFairy>())
			{
				totalFairyCount++;
				if (((Entity)proj).whoAmI < ((Entity)projectile).whoAmI)
				{
					thisProjectilePosition++;
				}
			}
		}
	}

	public static bool IsFairyAtMaxCapacity(Projectile projectile)
	{
		return GetVisualBellySize(projectile) >= 3 + GetVisualWeightStage(projectile);
	}

	public override void AI()
	{
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		Player owner = Main.player[((ModProjectile)this).Projectile.owner];
		PredProjectile.GetStomachTracker(((ModProjectile)this).Projectile);
		((ModProjectile)this).Projectile.ai[2] += GetVisualBellySize(((ModProjectile)this).Projectile);
		CheckForSpore(owner);
		if (owner.IsFoodFor((Entity)(object)((ModProjectile)this).Projectile, out var _))
		{
			((ModProjectile)this).Projectile.timeLeft = 2;
		}
		if (!CheckActive(owner))
		{
			WaitOut(owner, SetSpeedMulti());
			return;
		}
		if (IsFairyAtMaxCapacity(((ModProjectile)this).Projectile))
		{
			WaitOut(owner, SetSpeedMulti());
			return;
		}
		if (((ModProjectile)this).Projectile.ai[1] > 0f)
		{
			((ModProjectile)this).Projectile.ai[1] -= 1f;
		}
		target = (null, null);
		FindTarget(owner);
		if (target.Item1 != null && ((ModProjectile)this).Projectile.ai[1] <= 0f)
		{
			CHARGE(owner, (Entity)(object)target.Item1, SetSpeedMulti());
		}
		else if (target.Item2 != null && ((ModProjectile)this).Projectile.ai[1] <= 0f)
		{
			CHARGE(owner, (Entity)(object)target.Item2, SetSpeedMulti());
		}
		else
		{
			Chill(owner, SetSpeedMulti());
		}
		if (((ModProjectile)this).Projectile.ai[0] == 0f && GetVisualWeightStage(((ModProjectile)this).Projectile) == 8)
		{
			((ModProjectile)this).Projectile.ai[0] = 1f;
			if (Main.netMode != 1)
			{
				Item.NewItem(((Entity)((ModProjectile)this).Projectile).GetSource_FromAI((string)null), new Vector2(((Entity)((ModProjectile)this).Projectile).Center.X, ((Entity)((ModProjectile)this).Projectile).Center.Y), Vector2.One, ModContent.ItemType<MushroomToken>(), 1, false, 0, false, false);
			}
		}
	}

	public override void PostAI()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		((ModProjectile)this).Projectile.rotation = ((Entity)((ModProjectile)this).Projectile).velocity.X * 0.04f;
		int framerate = 5;
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
		Vector2 center = ((Entity)((ModProjectile)this).Projectile).Center;
		Color blue = Color.Blue;
		Lighting.AddLight(center, ((Color)(ref blue)).ToVector3() * 0.7f);
	}

	public float SetSpeedMulti()
	{
		float num = 1f;
		if (Main.player[((ModProjectile)this).Projectile.owner].AsV2Player().ShroomNecklace)
		{
			return 1f * Math.Max(1f - (float)GetVisualWeightStage(((ModProjectile)this).Projectile) / 24f, 0.05f) * Math.Max(1f - (float)GetVisualBellySize(((ModProjectile)this).Projectile) / 24f, 0.05f);
		}
		return 1f * Math.Max(1f - (float)GetVisualWeightStage(((ModProjectile)this).Projectile) / 12f, 0.05f) * Math.Max(1f - (float)GetVisualBellySize(((ModProjectile)this).Projectile) / 12f, 0.05f);
	}

	public void FindTarget(Player owner)
	{
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		Projectile closestProj = null;
		NPC closestNPC = null;
		float projDistance = 99999f;
		float npcDistance = 99999f;
		int num = 11;
		List<(PreyType, int)> list = new List<(PreyType, int)>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<(PreyType, int)> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = (PreyType.Projectile, 632);
		num2++;
		span[num2] = (PreyType.Projectile, 238);
		num2++;
		span[num2] = (PreyType.Projectile, 237);
		num2++;
		span[num2] = (PreyType.Projectile, 244);
		num2++;
		span[num2] = (PreyType.Projectile, 243);
		num2++;
		span[num2] = (PreyType.Projectile, 250);
		num2++;
		span[num2] = (PreyType.Projectile, 356);
		num2++;
		span[num2] = (PreyType.Projectile, 298);
		num2++;
		span[num2] = (PreyType.Projectile, 604);
		num2++;
		span[num2] = (PreyType.Projectile, 254);
		num2++;
		span[num2] = (PreyType.Projectile, 307);
		num2++;
		List<(PreyType, int)> IgnoreThese = list;
		num2 = 12;
		List<(PreyType, int)> list2 = new List<(PreyType, int)>(num2);
		CollectionsMarshal.SetCount(list2, num2);
		span = CollectionsMarshal.AsSpan(list2);
		num = 0;
		span[num] = (PreyType.NPC, 33);
		num++;
		span[num] = (PreyType.NPC, 30);
		num++;
		span[num] = (PreyType.NPC, 665);
		num++;
		span[num] = (PreyType.NPC, 25);
		num++;
		span[num] = (PreyType.NPC, 112);
		num++;
		span[num] = (PreyType.NPC, 666);
		num++;
		span[num] = (PreyType.NPC, 388);
		num++;
		span[num] = (PreyType.NPC, 265);
		num++;
		span[num] = (PreyType.NPC, 261);
		num++;
		span[num] = (PreyType.NPC, 72);
		num++;
		span[num] = (PreyType.NPC, 70);
		num++;
		span[num] = (PreyType.NPC, 378);
		num++;
		Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			NPC npc = enumerator.Current;
			if (((Entity)(object)npc).CurrentCaptor() == null && (npc.type == 33 || npc.type == 30 || npc.type == 665 || npc.type == 25 || npc.type == 112 || npc.type == 666))
			{
				float distance = Utils.Distance(((Entity)npc).position, ((Entity)owner).position);
				if (distance < npcDistance)
				{
					closestNPC = npc;
					npcDistance = distance;
				}
			}
		}
		Enumerator<Projectile> enumerator2 = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Projectile proj = enumerator2.Current;
			if (((Entity)(object)proj).CurrentCaptor() != null || (proj.friendly && !proj.hostile) || proj.damage <= 0 || proj.IsMinionOrSentryRelated)
			{
				continue;
			}
			bool shouldIgnore = false;
			foreach (var item in IgnoreThese)
			{
				if (item.Item2 == proj.type)
				{
					shouldIgnore = true;
				}
			}
			if (!shouldIgnore)
			{
				float distance2 = Utils.Distance(((Entity)proj).position, ((Entity)owner).position);
				if (distance2 < projDistance)
				{
					closestProj = proj;
					projDistance = distance2;
				}
			}
		}
		if (projDistance > 320f)
		{
			closestProj = null;
		}
		if (npcDistance > 320f)
		{
			closestNPC = null;
		}
		if (projDistance <= npcDistance)
		{
			closestNPC = null;
		}
		else
		{
			closestProj = null;
		}
		target = (closestProj, closestNPC);
	}

	public bool CheckActive(Player owner)
	{
		if (owner.dead || !((Entity)owner).active)
		{
			owner.ClearBuff(ModContent.BuffType<ShroomFairyBuff>());
			return false;
		}
		if (owner.HasBuff(ModContent.BuffType<ShroomFairyBuff>()))
		{
			((ModProjectile)this).Projectile.timeLeft = 2;
		}
		return true;
	}

	public void Chill(Player owner, float SpeedMulti)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		bool churnedOwner;
		bool num = owner.IsFoodFor((Entity)(object)((ModProjectile)this).Projectile, out churnedOwner);
		Vector2 idlePosition = ((Entity)owner).Center;
		idlePosition.Y -= 50f;
		GetIdlePosition(((ModProjectile)this).Projectile, out var count, out var totalcount);
		Vector2 Extra = AnglePosition(count, totalcount);
		idlePosition += Extra * 125f;
		Vector2 vectorToIdlePosition = idlePosition - ((Entity)((ModProjectile)this).Projectile).Center;
		float distanceToIdlePosition = ((Vector2)(ref vectorToIdlePosition)).Length();
		bool atPos = false;
		if (Main.myPlayer == ((Entity)owner).whoAmI && distanceToIdlePosition > 2000f)
		{
			((Entity)((ModProjectile)this).Projectile).position = idlePosition;
			Projectile projectile = ((ModProjectile)this).Projectile;
			((Entity)projectile).velocity = ((Entity)projectile).velocity * 0.1f;
			((ModProjectile)this).Projectile.netUpdate = true;
			DustEffect(((ModProjectile)this).Projectile);
		}
		if (!num)
		{
			float speed = 10f;
			float inertia = 20f;
			if (distanceToIdlePosition > 600f)
			{
				speed = 18f;
				inertia = 60f;
			}
			else if (distanceToIdlePosition < 80f)
			{
				speed = 4f;
				inertia = 80f;
				atPos = true;
			}
			if (distanceToIdlePosition > 20f)
			{
				((Vector2)(ref vectorToIdlePosition)).Normalize();
				vectorToIdlePosition *= speed;
				if (!atPos)
				{
					vectorToIdlePosition.X *= SpeedMulti;
					if (vectorToIdlePosition.Y < 0f)
					{
						vectorToIdlePosition.Y *= SpeedMulti;
						vectorToIdlePosition.Y *= (SpeedMulti + 2f) / 3f;
					}
				}
				((Entity)((ModProjectile)this).Projectile).velocity = (((Entity)((ModProjectile)this).Projectile).velocity * (inertia - 1f) + vectorToIdlePosition) / inertia;
				if (!CheckForSolidFloor())
				{
					((Entity)((ModProjectile)this).Projectile).velocity.Y -= 0.1667f + (0f - SpeedMulti) / 6f;
				}
			}
			else if (((Entity)((ModProjectile)this).Projectile).velocity == Vector2.Zero)
			{
				((Entity)((ModProjectile)this).Projectile).velocity.X = -0.15f;
				((Entity)((ModProjectile)this).Projectile).velocity.Y = -0.05f;
			}
		}
		else
		{
			Projectile projectile2 = ((ModProjectile)this).Projectile;
			((Entity)projectile2).velocity = ((Entity)projectile2).velocity * 0.9f;
		}
		((Entity)((ModProjectile)this).Projectile).velocity.X = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.X, -12f, 12f);
		if (!CheckForSolidFloor())
		{
			((Entity)((ModProjectile)this).Projectile).velocity.Y = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.Y, -12f, 12f) + (0.2f + (0f - SpeedMulti) / 5f);
		}
		else
		{
			((Entity)((ModProjectile)this).Projectile).velocity.Y = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.Y, -12f, 12f);
		}
	}

	public void CHARGE(Player owner, Entity target, float SpeedMulti)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		if (!target.active)
		{
			return;
		}
		float speed = 25f;
		float inertia = 25f;
		Vector2 direction = Utils.DirectionTo(((Entity)((ModProjectile)this).Projectile).position, target.position);
		((Vector2)(ref direction)).Normalize();
		Vector2 direction2 = direction * 10f;
		if (Utils.Distance(((Entity)((ModProjectile)this).Projectile).position, target.position) <= 180f)
		{
			DustEffect(((ModProjectile)this).Projectile);
			Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), direction2.X, direction2.Y, 0, default(Color), 1f);
			Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), direction2.X, direction2.Y, 0, default(Color), 1.25f);
			Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), direction2.X, direction2.Y, 0, default(Color), 1.5f);
			Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), direction2.X, direction2.Y, 0, default(Color), 1.75f);
			Dust.NewDustDirect(((Entity)((ModProjectile)this).Projectile).Center - new Vector2(8f, 8f), 32, 32, ModContent.DustType<ShroomFairyDust>(), direction2.X, direction2.Y, 0, default(Color), 2f);
			((ModProjectile)this).Projectile.ai[1] = 8f / SpeedMulti;
			((Entity)((ModProjectile)this).Projectile).position = target.position;
			PredProjectile.Swallow(((ModProjectile)this).Projectile, target);
			DustEffect(((ModProjectile)this).Projectile);
			return;
		}
		direction *= speed;
		direction.X *= SpeedMulti;
		if (direction.Y < 0f)
		{
			direction.Y *= SpeedMulti;
			direction.Y *= (SpeedMulti + 2f) / 3f;
		}
		((Entity)((ModProjectile)this).Projectile).velocity = (((Entity)((ModProjectile)this).Projectile).velocity * (inertia - 1f) + direction) / inertia;
		((Entity)((ModProjectile)this).Projectile).velocity.X = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.X, -18f, 18f);
		if (!CheckForSolidFloor())
		{
			((Entity)((ModProjectile)this).Projectile).velocity.Y = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.Y, -18f, 18f) + (0.2f + (0f - SpeedMulti) / 5f);
		}
		else
		{
			((Entity)((ModProjectile)this).Projectile).velocity.Y = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.Y, -18f, 18f);
		}
	}

	public void WaitOut(Player owner, float SpeedMulti)
	{
		if (CheckForSolidFloor())
		{
			((Entity)((ModProjectile)this).Projectile).velocity.X *= 0.9f;
			((Entity)((ModProjectile)this).Projectile).velocity.Y *= 0.8f;
			return;
		}
		((Entity)((ModProjectile)this).Projectile).velocity.X *= 0.9f;
		if (((Entity)((ModProjectile)this).Projectile).velocity.Y < 0f)
		{
			((Entity)((ModProjectile)this).Projectile).velocity.Y *= 0.9f;
		}
		((Entity)((ModProjectile)this).Projectile).velocity.X = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.X, -12f, 12f);
		((Entity)((ModProjectile)this).Projectile).velocity.Y = Math.Clamp(((Entity)((ModProjectile)this).Projectile).velocity.Y, -12f, 12f) + (0.05f + (0f - SpeedMulti) / 50f);
	}

	public bool CheckForSolidFloor()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		int WeightOffset = 0;
		switch (GetVisualWeightStage(((ModProjectile)this).Projectile))
		{
		case 0:
		case 1:
		case 2:
		case 3:
			WeightOffset = 0;
			break;
		case 4:
			WeightOffset = 10;
			break;
		case 5:
			WeightOffset = 20;
			break;
		case 6:
			WeightOffset = 30;
			break;
		case 7:
			WeightOffset = 40;
			break;
		case 8:
			WeightOffset = 50;
			break;
		}
		if (Collision.SolidTiles(((Entity)((ModProjectile)this).Projectile).position, ((Entity)((ModProjectile)this).Projectile).width, ((Entity)((ModProjectile)this).Projectile).height * 2 + WeightOffset, true))
		{
			return true;
		}
		return false;
	}

	public void CheckForSpore(Player owner)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		if (((ModProjectile)this).Projectile.ai[2] >= 1500f)
		{
			((ModProjectile)this).Projectile.ai[2] -= 1500f;
			Projectile.NewProjectile(((Entity)((ModProjectile)this).Projectile).GetSource_FromThis((string)null), ((Entity)((ModProjectile)this).Projectile).Center, Vector2.Zero, ModContent.ProjectileType<ShroomFairySpore>(), 0, 0f, ((Entity)owner).whoAmI, 0f, 0f, 0f);
		}
	}

	public override bool PreDraw(ref Color lightColor)
	{
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		string text = "V2/Projectiles/Voraria/Weapons/Summon/ShroomFairy";
		int TumSize = GetVisualBellySize(((ModProjectile)this).Projectile);
		int FairySize = GetVisualWeightStage(((ModProjectile)this).Projectile);
		int frameSize = 60;
		switch (FairySize)
		{
		case 1:
		case 2:
			text = text + "_" + FairySize;
			frameSize = 80;
			break;
		case 3:
			text = text + "_" + FairySize;
			frameSize = 96;
			break;
		case 4:
			text = text + "_" + FairySize;
			frameSize = 108;
			break;
		case 5:
		case 6:
		case 7:
			text = text + "_" + FairySize;
			frameSize = 148;
			break;
		case 8:
			text = text + "_" + FairySize;
			frameSize = 164;
			break;
		}
		Vector2 Offset = default(Vector2);
		((Vector2)(ref Offset))._002Ector(-10f, 0f);
		if (((Entity)((ModProjectile)this).Projectile).direction == -1)
		{
			((Vector2)(ref Offset))._002Ector((float)(-10 - (frameSize - 50)), 0f);
		}
		Texture2D value = ModContent.Request<Texture2D>(text, (AssetRequestMode)2).Value;
		SpriteEffects spriteEffects = (SpriteEffects)(((Entity)((ModProjectile)this).Projectile).direction == -1);
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(frameSize * TumSize, frameSize * ((ModProjectile)this).Projectile.frame, frameSize, frameSize);
		Main.EntitySpriteDraw(value, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition + new Vector2(Offset.X, Offset.Y), (Rectangle?)sourceRect, lightColor, ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		Main.EntitySpriteDraw(ModContent.Request<Texture2D>(text + "_Fullbright", (AssetRequestMode)2).Value, ((Entity)((ModProjectile)this).Projectile).position - Main.screenPosition + new Vector2(Offset.X, Offset.Y), (Rectangle?)sourceRect, new Color(255, 255, 255), ((ModProjectile)this).Projectile.rotation, Vector2.Zero, 1f, spriteEffects, 0f);
		return false;
	}
}
