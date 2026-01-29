using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.Projectiles.Vanilla.Summons.Pets;

public class FairyPrincess : GlobalProjectile
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static TileActionAttempt _003C0_003E__CastLightOpen;

		public static GeneralProjectile.DelegateNewAI _003C1_003E__MiniCandyFairyAI;

		public static PredProjectile.DelegateCanBeForceFed _003C2_003E__CanMiniCandyFairyBeForceFed;

		public static PredProjectile.DelegateOnForceFed _003C3_003E__OnMiniCandyFairyForceFed;

		public static PredProjectile.DelegateGetDigestionTickDamage _003C4_003E__GetDigestionTickDamage;

		public static PredProjectile.DelegateGetDigestionTickRate _003C5_003E__GetDigestionTickRate;

		public static PredProjectile.DelegateOnDigestionKill _003C6_003E__OnDigestionKill;

		public static PredProjectile.DelegateGetDigestedPlayerAdditionalDeathMessages _003C7_003E__GetDigestedPlayerAdditionalDeathMessages;

		public static PredProjectile.DelegateGetPreyAbsorptionRate _003C8_003E__GetPreyAbsorptionRate;

		public static PredProjectile.DelegateGetVisualBellySize _003C9_003E__GetVisualBellySize;

		public static PredProjectile.DelegateGetVisualWeightStage _003C10_003E__GetVisualWeightStage;

		public static PreyProjectile.DelegateOnKilledByDigestion _003C11_003E__OnKilledByDigestion_GrantLivePreyGoal;

		public static PreyProjectile.DelegateOnKilledByDigestion _003C12_003E__OnKilledByDigestion;
	}

	public bool WaitingForChurnedOwner { get; set; }

	public override bool InstancePerEntity => true;

	public static bool MiniCandyFairyAI(Projectile projectile)
	{
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		Player ownerPlayer = Main.player[projectile.owner];
		bool churnedOwner;
		bool ateOwner = ownerPlayer.IsFoodFor((Entity)(object)projectile, out churnedOwner);
		VoreTracker fairyPrincessTummy = PredProjectile.GetStomachTracker(projectile);
		if (fairyPrincessTummy != null)
		{
			foreach (PreyData newFood in fairyPrincessTummy.PreyQueue)
			{
				if (!newFood.NoHealth)
				{
					ateOwner |= ownerPlayer.IsFoodFor(newFood.Instance, out var foodChurnedOwner);
					churnedOwner = churnedOwner || foodChurnedOwner;
				}
			}
			foreach (PreyData food in fairyPrincessTummy.Prey)
			{
				if (!food.NoHealth)
				{
					ateOwner |= ownerPlayer.IsFoodFor(food.Instance, out var foodChurnedOwner2);
					churnedOwner = churnedOwner || foodChurnedOwner2;
				}
			}
		}
		if (!projectile.AsFairyPrincess().WaitingForChurnedOwner)
		{
			projectile.AsFairyPrincess().WaitingForChurnedOwner = ateOwner;
		}
		float xOffset = V2Utils.TileCountAsPixelCount(2.0);
		float yOffset = -V2Utils.TileCountAsPixelCount(4.5);
		Vector2 offsetFromOwner = default(Vector2);
		((Vector2)(ref offsetFromOwner))._002Ector((float)((Entity)ownerPlayer).direction * xOffset, yOffset);
		Vector2 intendedLocation = ownerPlayer.MountedCenter + offsetFromOwner;
		float distanceToIntendedLocation = Vector2.Distance(((Entity)projectile).Center, intendedLocation);
		if (projectile.AsFairyPrincess().WaitingForChurnedOwner)
		{
			projectile.timeLeft = 2;
		}
		else if (!ateOwner)
		{
			if (ownerPlayer.dead)
			{
				projectile.Kill();
				return false;
			}
			if (ownerPlayer.petFlagFairyQueenPet)
			{
				projectile.timeLeft = 2;
			}
			if (distanceToIntendedLocation > 1000f)
			{
				((Entity)projectile).Center = ((Entity)ownerPlayer).Center + offsetFromOwner;
			}
		}
		else
		{
			projectile.AsFairyPrincess().WaitingForChurnedOwner = true;
			projectile.timeLeft = 2;
		}
		VoreTracker tracker = PredProjectile.GetStomachTracker(projectile);
		if (tracker != null)
		{
			PreyData candyFairy = null;
			PreyData sprinkles = tracker.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
			if (sprinkles != null && sprinkles.WeightLeftToDigest > 4.0)
			{
				candyFairy = sprinkles;
			}
			PreyData sprinklesQueue = tracker.PreyQueue.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
			if (sprinklesQueue != null && sprinklesQueue.WeightLeftToDigest > 4.0)
			{
				candyFairy = sprinklesQueue;
			}
			if (tracker != null && candyFairy != null)
			{
				if (((Entity)projectile).width == 18 && ((Entity)projectile).height == 40)
				{
					((Entity)projectile).width = 86;
					((Entity)projectile).height = 148;
					((Entity)projectile).position.X -= 68f;
					((Entity)projectile).position.Y -= 108f;
				}
				((Entity)projectile).velocity.X = 0f;
				if (!candyFairy.NoHealth)
				{
					_ = candyFairy.Instance;
					if (projectile.AsV2Proj().CustomSprite == null)
					{
						projectile.AsV2Proj().CustomSprite = new FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.Alive();
					}
				}
				else if (projectile.AsV2Proj().CustomSprite == null)
				{
					projectile.AsV2Proj().CustomSprite = new FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.Alive();
				}
				else if (projectile.AsV2Proj().CustomSprite is FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.Alive && projectile.AsV2Proj().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(projectile) >= 2)
				{
					projectile.AsV2Proj().CustomSprite = new FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.DigestStage1();
				}
				else if (projectile.AsV2Proj().CustomSprite is FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.DigestStage1 && projectile.AsV2Proj().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(projectile) >= 3)
				{
					projectile.AsV2Proj().CustomSprite = new FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.DigestStage2();
				}
				else if (projectile.AsV2Proj().CustomSprite is FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.DigestStage2 && projectile.AsV2Proj().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(projectile) >= 4)
				{
					projectile.AsV2Proj().CustomSprite = new FairyPrincessStuff.Animations.BaseWeight.OVHerOwnFuckingMother.DigestStage3();
				}
				goto IL_03eb;
			}
		}
		if (projectile.AsV2Proj().CustomSprite != null)
		{
			projectile.AsV2Proj().CustomSprite = null;
		}
		goto IL_03eb;
		IL_03eb:
		if (!MiniCandyFairyAI_TryFindNewFood(projectile))
		{
			if (projectile.AsFairyPrincess().WaitingForChurnedOwner)
			{
				((Entity)projectile).velocity = ((Entity)projectile).velocity * 0.925f;
				if (((Entity)ownerPlayer).active && !ownerPlayer.dead && ((Entity)(object)ownerPlayer).CurrentCaptor() == null && distanceToIntendedLocation <= (float)V2Utils.TileCountAsPixelCount(20.0))
				{
					projectile.AsFairyPrincess().WaitingForChurnedOwner = false;
					MiniCandyFairyAI_HandleOwnerFollowing(projectile, ownerPlayer, intendedLocation);
				}
			}
			else if ((!ateOwner || churnedOwner) && distanceToIntendedLocation <= (float)V2Utils.TileCountAsPixelCount(20.0))
			{
				MiniCandyFairyAI_HandleOwnerFollowing(projectile, ownerPlayer, intendedLocation);
			}
			else
			{
				((Entity)projectile).velocity = ((Entity)projectile).velocity * 0.925f;
			}
		}
		if (((Vector2)(ref ((Entity)projectile).velocity)).Length() > 6f)
		{
			float rotationSpeed = ((Entity)projectile).velocity.X * 0.1f;
			if (Math.Abs(projectile.rotation - rotationSpeed) >= (float)Math.PI)
			{
				if (rotationSpeed < projectile.rotation)
				{
					projectile.rotation -= (float)Math.PI * 2f;
				}
				else
				{
					projectile.rotation += (float)Math.PI * 2f;
				}
			}
			float rotationInertia = 12f;
			projectile.rotation = (projectile.rotation * (rotationInertia - 1f) + rotationSpeed) / rotationInertia;
			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
			if (projectile.frameCounter == 0 || Utils.NextBool(Main.rand, 15))
			{
				int num974 = Dust.NewDust(((Entity)projectile).position, ((Entity)projectile).width, ((Entity)projectile).height, Utils.NextFromCollection<int>(Main.rand, new List<int> { 242, 242, 59, 64 }), 0f, 0f, 50, default(Color), 2f);
				Main.dust[num974].noGravity = true;
			}
		}
		else
		{
			if (projectile.rotation > (float)Math.PI)
			{
				projectile.rotation -= (float)Math.PI * 2f;
			}
			if (projectile.rotation > -0.005f && projectile.rotation < 0.005f)
			{
				projectile.rotation = 0f;
			}
			else
			{
				projectile.rotation *= 0.96f;
			}
			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
		}
		return false;
	}

	public static void MiniCandyFairyAI_HandleOwnerFollowing(Projectile projectile, Player ownerPlayer, Vector2 intendedLocation)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		((Entity)projectile).direction = (projectile.spriteDirection = ((Entity)ownerPlayer).direction);
		float num = Vector2.Distance(((Entity)projectile).Center, intendedLocation);
		Vector3 val = new Vector3(1f, 0.6f, 1f) * 1.5f;
		DelegateMethods.v3_1 = val * 0.75f;
		Vector2 center = ((Entity)ownerPlayer).Center;
		Vector2 val2 = ((Entity)ownerPlayer).Center + ((Entity)ownerPlayer).velocity * 6f;
		object obj = _003C_003EO._003C0_003E__CastLightOpen;
		if (obj == null)
		{
			TileActionAttempt val3 = DelegateMethods.CastLightOpen;
			_003C_003EO._003C0_003E__CastLightOpen = val3;
			obj = (object)val3;
		}
		Utils.PlotTileLine(center, val2, 40f, (TileActionAttempt)obj);
		Vector2 left = ((Entity)ownerPlayer).Left;
		Vector2 right = ((Entity)ownerPlayer).Right;
		object obj2 = _003C_003EO._003C0_003E__CastLightOpen;
		if (obj2 == null)
		{
			TileActionAttempt val4 = DelegateMethods.CastLightOpen;
			_003C_003EO._003C0_003E__CastLightOpen = val4;
			obj2 = (object)val4;
		}
		Utils.PlotTileLine(left, right, 40f, (TileActionAttempt)obj2);
		DelegateMethods.v3_1 = val * 1.5f;
		Vector2 center2 = ((Entity)projectile).Center;
		Vector2 val5 = ((Entity)projectile).Center + ((Entity)projectile).velocity * 6f;
		object obj3 = _003C_003EO._003C0_003E__CastLightOpen;
		if (obj3 == null)
		{
			TileActionAttempt val6 = DelegateMethods.CastLightOpen;
			_003C_003EO._003C0_003E__CastLightOpen = val6;
			obj3 = (object)val6;
		}
		Utils.PlotTileLine(center2, val5, 30f, (TileActionAttempt)obj3);
		Vector2 left2 = ((Entity)projectile).Left;
		Vector2 right2 = ((Entity)projectile).Right;
		object obj4 = _003C_003EO._003C0_003E__CastLightOpen;
		if (obj4 == null)
		{
			TileActionAttempt val7 = DelegateMethods.CastLightOpen;
			_003C_003EO._003C0_003E__CastLightOpen = val7;
			obj4 = (object)val7;
		}
		Utils.PlotTileLine(left2, right2, 20f, (TileActionAttempt)obj4);
		Vector2 distanceFromIntendedLocation = intendedLocation - ((Entity)projectile).Center;
		float lockInDistance = 10f;
		if (num < lockInDistance)
		{
			((Entity)projectile).velocity = ((Entity)projectile).velocity * 0.85f;
		}
		if (distanceFromIntendedLocation != Vector2.Zero)
		{
			float maxSpeed = 15f;
			((Entity)projectile).velocity = distanceFromIntendedLocation * 0.1f;
			if (((Vector2)(ref ((Entity)projectile).velocity)).Length() > maxSpeed)
			{
				((Vector2)(ref ((Entity)projectile).velocity)).Normalize();
				((Entity)projectile).velocity = ((Entity)projectile).velocity * maxSpeed;
			}
		}
		if (num > 50f)
		{
			((Entity)projectile).direction = (projectile.spriteDirection = 1);
			if (((Entity)projectile).velocity.X < 0f)
			{
				((Entity)projectile).direction = (projectile.spriteDirection = -1);
			}
		}
	}

	public static bool MiniCandyFairyAI_TryFindNewFood(Projectile projectile)
	{
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Unknown result type (might be due to invalid IL or missing references)
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0962: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_098b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		Player ownerPlayer = Main.player[projectile.owner];
		int num = 55;
		List<(PreyType, int)> list = new List<(PreyType, int)>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<(PreyType, int)> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = (PreyType.NPC, 585);
		num2++;
		span[num2] = (PreyType.NPC, 584);
		num2++;
		span[num2] = (PreyType.NPC, 583);
		num2++;
		span[num2] = (PreyType.NPC, 442);
		num2++;
		span[num2] = (PreyType.NPC, 443);
		num2++;
		span[num2] = (PreyType.NPC, 444);
		num2++;
		span[num2] = (PreyType.NPC, 601);
		num2++;
		span[num2] = (PreyType.NPC, 667);
		num2++;
		span[num2] = (PreyType.NPC, 445);
		num2++;
		span[num2] = (PreyType.NPC, 592);
		num2++;
		span[num2] = (PreyType.NPC, 593);
		num2++;
		span[num2] = (PreyType.NPC, 446);
		num2++;
		span[num2] = (PreyType.NPC, 605);
		num2++;
		span[num2] = (PreyType.NPC, 447);
		num2++;
		span[num2] = (PreyType.NPC, 627);
		num2++;
		span[num2] = (PreyType.NPC, 539);
		num2++;
		span[num2] = (PreyType.NPC, 613);
		num2++;
		span[num2] = (PreyType.NPC, 448);
		num2++;
		span[num2] = (PreyType.NPC, 484);
		num2++;
		span[num2] = (PreyType.NPC, 652);
		num2++;
		span[num2] = (PreyType.NPC, 646);
		num2++;
		span[num2] = (PreyType.NPC, 651);
		num2++;
		span[num2] = (PreyType.NPC, 649);
		num2++;
		span[num2] = (PreyType.NPC, 650);
		num2++;
		span[num2] = (PreyType.NPC, 648);
		num2++;
		span[num2] = (PreyType.NPC, 647);
		num2++;
		span[num2] = (PreyType.NPC, 645);
		num2++;
		span[num2] = (PreyType.NPC, 639);
		num2++;
		span[num2] = (PreyType.NPC, 644);
		num2++;
		span[num2] = (PreyType.NPC, 642);
		num2++;
		span[num2] = (PreyType.NPC, 643);
		num2++;
		span[num2] = (PreyType.NPC, 641);
		num2++;
		span[num2] = (PreyType.NPC, 640);
		num2++;
		span[num2] = (PreyType.NPC, 50);
		num2++;
		span[num2] = (PreyType.NPC, 75);
		num2++;
		span[num2] = (PreyType.NPC, 86);
		num2++;
		span[num2] = (PreyType.NPC, 244);
		num2++;
		span[num2] = (PreyType.NPC, 122);
		num2++;
		span[num2] = (PreyType.NPC, 222);
		num2++;
		span[num2] = (PreyType.NPC, 657);
		num2++;
		span[num2] = (PreyType.NPC, 658);
		num2++;
		span[num2] = (PreyType.NPC, 660);
		num2++;
		span[num2] = (PreyType.NPC, 659);
		num2++;
		span[num2] = (PreyType.NPC, 84);
		num2++;
		span[num2] = (PreyType.NPC, 475);
		num2++;
		span[num2] = (PreyType.NPC, 545);
		num2++;
		span[num2] = (PreyType.NPC, 661);
		num2++;
		span[num2] = (PreyType.NPC, 636);
		num2++;
		span[num2] = (PreyType.NPC, 345);
		num2++;
		span[num2] = (PreyType.NPC, 426);
		num2++;
		span[num2] = (PreyType.NPC, 676);
		num2++;
		span[num2] = (PreyType.NPC, 677);
		num2++;
		span[num2] = (PreyType.Projectile, 881);
		num2++;
		span[num2] = (PreyType.Projectile, 934);
		num2++;
		span[num2] = (PreyType.Projectile, 898);
		num2++;
		List<(PreyType, int)> diet = list;
		if (!V2.BlacklistsActive)
		{
			diet.Add((PreyType.NPC, 663));
		}
		PreyType targetPreyType = PreyType.Undefined;
		int targetPreyIndex = -1;
		double maxPreyDistanceFromFairy = V2Utils.TileCountAsPixelCount(25.0);
		double maxPreyDistanceFromOwner = V2Utils.TileCountAsPixelCount(40.0);
		Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			NPC potentialPrey = enumerator.Current;
			if (potentialPrey.life <= 0 || ((Entity)(object)potentialPrey).CurrentCaptor() != null)
			{
				continue;
			}
			bool partOfDiet = false;
			foreach (var (type, ID) in diet)
			{
				if (type == PreyType.NPC && ID == potentialPrey.type)
				{
					partOfDiet = true;
				}
			}
			if (partOfDiet)
			{
				float distanceToPotentialPrey = ((Entity)projectile).Distance(((Entity)(object)potentialPrey).TrueCenter());
				float distanceToPotentialPreyFromOwner = ((Entity)ownerPlayer).Distance(((Entity)(object)potentialPrey).TrueCenter());
				if ((double)distanceToPotentialPrey <= maxPreyDistanceFromFairy && (double)distanceToPotentialPreyFromOwner <= maxPreyDistanceFromOwner)
				{
					targetPreyType = PreyType.NPC;
					targetPreyIndex = ((Entity)potentialPrey).whoAmI;
					maxPreyDistanceFromFairy = distanceToPotentialPrey;
					maxPreyDistanceFromOwner = distanceToPotentialPreyFromOwner;
				}
			}
		}
		Enumerator<Projectile> enumerator3 = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			Projectile potentialPrey2 = enumerator3.Current;
			if (potentialPrey2.AsFood().Health <= 0.0 || ((Entity)(object)potentialPrey2).CurrentCaptor() != null)
			{
				continue;
			}
			bool partOfDiet2 = false;
			foreach (var (type2, ID2) in diet)
			{
				if (type2 == PreyType.Projectile && ID2 == potentialPrey2.type)
				{
					partOfDiet2 = true;
				}
			}
			if (partOfDiet2)
			{
				float distanceToPotentialPrey2 = ((Entity)projectile).Distance(((Entity)(object)potentialPrey2).TrueCenter());
				float distanceToPotentialPreyFromOwner2 = ((Entity)ownerPlayer).Distance(((Entity)(object)potentialPrey2).TrueCenter());
				if ((double)distanceToPotentialPrey2 <= maxPreyDistanceFromFairy && (double)distanceToPotentialPreyFromOwner2 <= maxPreyDistanceFromOwner)
				{
					targetPreyType = PreyType.Projectile;
					targetPreyIndex = ((Entity)potentialPrey2).whoAmI;
					maxPreyDistanceFromFairy = distanceToPotentialPrey2;
					maxPreyDistanceFromOwner = distanceToPotentialPreyFromOwner2;
				}
			}
		}
		if (targetPreyType != PreyType.Undefined && targetPreyIndex != -1)
		{
			object entity = targetPreyType switch
			{
				PreyType.Player => Main.player[targetPreyIndex], 
				PreyType.NPC => Main.npc[targetPreyIndex], 
				PreyType.Projectile => Main.projectile[targetPreyIndex], 
				_ => null, 
			};
			float speed = 8.75f;
			float inertia = 10f;
			projectile.ai[1] += 0.05f;
			if (projectile.ai[1] > 7f)
			{
				projectile.ai[1] = 7f;
			}
			Vector2 direction = ((Entity)entity).TrueCenter() - ((Entity)(object)projectile).TrueCenter();
			((Vector2)(ref direction)).Normalize();
			direction *= speed;
			((Entity)projectile).velocity = (((Entity)projectile).velocity * (inertia - 1f) + direction) / inertia;
			projectile.netUpdate = true;
			((Entity)projectile).direction = (projectile.spriteDirection = 1);
			if (((Entity)projectile).velocity.X < 0f)
			{
				((Entity)projectile).direction = (projectile.spriteDirection = -1);
			}
			projectile.DoContactGulpage(diet);
			return true;
		}
		return false;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		return entity.type == 895;
	}

	public override void SetDefaults(Projectile projectile)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		projectile.Name = Language.GetTextValue("Mods.V2.Projectiles.DisplayName.Vanilla.Summons.Pets.FairyPrincess");
		projectile.AsV2Proj().Gender = EntityGender.Female;
		projectile.AsV2Proj().NewAIMethod = MiniCandyFairyAI;
		projectile.AsPred().MaxStomachCapacity = FairyPrincessStuff.MaxStomachCapacity;
		projectile.AsPred().BaseStomachacheMeterCapacity = -1.0;
		projectile.AsPred().CanSwallowBosses = true;
		projectile.AsFood().DefinedSize = FairyPrincessStuff.Size;
		projectile.AsFood().MaxHealth = FairyPrincessStuff.MaxHealth;
		projectile.AsFood().Health = FairyPrincessStuff.MaxHealth;
		projectile.AsPred().MouthSoundRawOffset = new Vector2(2f, -14f);
		projectile.AsPred().SmallGulps = Gulps.Short;
		projectile.AsPred().SmallGulpThreshold = 0.1;
		projectile.AsPred().BigGulps = Gulps.Standard;
		projectile.AsPred().CanBeForceFed = CanMiniCandyFairyBeForceFed;
		projectile.AsPred().OnForceFed = OnMiniCandyFairyForceFed;
		projectile.AsPred().MaxSwallowRange = V2Utils.TileCountAsPixelCount(12.5);
		projectile.AsPred().DigestionType = EntityDigestionType.Acidic;
		projectile.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		projectile.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		projectile.AsPred().OnDigestionKill = OnDigestionKill;
		projectile.AsPred().SmallBurps = Burps.Humanoid.Small;
		projectile.AsPred().StandardBurps = Burps.Humanoid.Standard;
		projectile.AsPred().BurpPitchOffset = 0.285f;
		projectile.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		projectile.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		projectile.AsPred().GetVisualBellySize = GetVisualBellySize;
		projectile.AsPred().GetVisualWeightStage = GetVisualWeightStage;
		PreyProjectile preyProjectile = projectile.AsFood();
		preyProjectile.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(PreyProjectile.OnKilledByDigestion_GrantLivePreyGoal));
		PreyProjectile preyProjectile2 = projectile.AsFood();
		preyProjectile2.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile2.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(OnKilledByDigestion));
	}

	public static bool CanMiniCandyFairyBeForceFed(Projectile projectile)
	{
		return true;
	}

	public static void OnMiniCandyFairyForceFed(Projectile projectile, Player player)
	{
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(Projectile projectile, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificProjectile.Summons.Pets.MiniCandyFairy.1", "Mods.V2.Death.DigestedPlayer.SpecificProjectile.Summons.Pets.MiniCandyFairy.2", "Mods.V2.Death.DigestedPlayer.SpecificProjectile.Summons.Pets.MiniCandyFairy.3", "Mods.V2.Death.DigestedPlayer.SpecificProjectile.Summons.Pets.MiniCandyFairy.4" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificProjectile.Summons.Pets.MiniCandyFairy.Hardcore");
		}
	}

	public static double GetDigestionTickDamage(Projectile projectile, PreyData prey)
	{
		double digestDamage = FairyPrincessStuff.DigestDamage;
		if (Main.dayTime)
		{
			digestDamage *= 2.0;
		}
		else if (Main.bloodMoon)
		{
			digestDamage *= 1.5;
		}
		return digestDamage;
	}

	public static double GetDigestionTickRate(Projectile projectile, PreyData prey)
	{
		double digestRate = FairyPrincessStuff.DigestRate;
		if (Main.dayTime)
		{
			digestRate *= 2.0;
		}
		else if (Main.bloodMoon)
		{
			digestRate *= 1.5;
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

	public static void OnDigestionKill(Projectile projectile, PreyData digestedPrey)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		int dustCount = 4 + (int)Math.Floor(10.5 * Math.Sqrt(digestedPrey.WeightLeftToDigest));
		int spawnedDustCount = 0;
		for (int i = 0; i < dustCount; i++)
		{
			Dust obj = Dust.NewDustPerfect(((Entity)(object)projectile).TrueCenter() + PredProjectile.MouthSoundOffset(projectile), Utils.NextFromCollection<int>(Main.rand, new List<int> { 61, 61, 242, 59, 64 }), (Vector2?)new Vector2((float)((Entity)projectile).direction * 2.5f, -0.5f), 50, default(Color), Utils.NextFloat(Main.rand, 2.25f, 2.75f));
			obj.position += Utils.RotatedByRandom(new Vector2(Utils.NextFloat(Main.rand, 2f), 0f), (double)MathHelper.ToRadians(360f));
			obj.velocity *= Utils.NextFloat(Main.rand, 0.85f, 1.15f);
			obj.velocity = Utils.RotatedByRandom(obj.velocity, (double)MathHelper.ToRadians(18f));
			obj.noGravity = true;
			spawnedDustCount++;
		}
		if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
		{
			string debugText = "Trying to spawn dusts for the Heiress' post-digestion-kill belch...\n";
			debugText = ((spawnedDustCount != dustCount) ? (debugText + "ERROR: Only " + spawnedDustCount + " out of " + dustCount + " dusts were spawned.") : (debugText + "All " + dustCount + " dusts were successfully spawned!"));
			if (Main.netMode == 0)
			{
				Main.NewText((object)debugText, (Color?)Color.PaleVioletRed);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(debugText), Color.PaleVioletRed, -1);
			}
		}
	}

	public static double GetPreyAbsorptionRate(Projectile projectile)
	{
		double absorbRate = FairyPrincessStuff.AbsorbRate;
		if (Main.dayTime)
		{
			absorbRate *= 3.0;
		}
		Player ownerPlayer = Main.player[projectile.owner];
		if (!ownerPlayer.dead && ((PlayerSleepingHelper)(ref ownerPlayer.sleeping)).FullyFallenAsleep)
		{
			absorbRate *= 1.25;
			if (CurrentFrameFlags.SleepingPlayersCount == CurrentFrameFlags.ActivePlayersCount && CurrentFrameFlags.SleepingPlayersCount > 0)
			{
				absorbRate *= (double)(float)Main.dayRate;
			}
		}
		return absorbRate;
	}

	public static int GetVisualBellySize(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(4.0 * Math.Sqrt(PredProjectile.GetCurrentBellyWeight(projectile))), 8);
	}

	public static int GetVisualWeightStage(Projectile projectile)
	{
		return Math.Min((int)Math.Floor(1.4 * Math.Sqrt(projectile.AsPred().ExtraWeight)), 0);
	}

	public static int GetEmpressDigestionStage(Projectile projectile)
	{
		if (PredProjectile.GetStomachTracker(projectile) == null)
		{
			return 0;
		}
		PreyData candyFairy = PredProjectile.GetStomachTracker(projectile).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
		if (candyFairy == null || candyFairy.WeightLeftToDigest < 6.0)
		{
			return 0;
		}
		if (!candyFairy.NoHealth)
		{
			return 1;
		}
		if (candyFairy.WeightLeftToDigest > 34.0)
		{
			return 1;
		}
		if (candyFairy.WeightLeftToDigest > 28.0)
		{
			return 2;
		}
		if (candyFairy.WeightLeftToDigest > 16.0)
		{
			return 3;
		}
		if (candyFairy.WeightLeftToDigest > 6.0)
		{
			return 4;
		}
		return 0;
	}

	public static void OnKilledByDigestion(Projectile projectile, Entity pred)
	{
		Main.player[projectile.owner].ClearBuff(298);
	}

	public override void OnKill(Projectile projectile, int timeLeft)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		int particleCount = 10;
		MathHelper.ToRadians(360f / (float)particleCount);
		for (int i = 0; i < particleCount; i++)
		{
			int num974 = Dust.NewDust(((Entity)projectile).position, ((Entity)projectile).width, ((Entity)projectile).height, Utils.NextFromCollection<int>(Main.rand, new List<int> { 242, 242, 59, 64 }), 0f, 0f, 50, default(Color), 2f);
			Main.dust[num974].noGravity = true;
		}
	}

	public override bool PreDraw(Projectile projectile, ref Color lightColor)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)projectile).CurrentCaptor() != null)
		{
			return false;
		}
		if (projectile.AsV2Proj().CustomSprite != null)
		{
			return true;
		}
		SpriteEffects val = ((((Entity)projectile).direction != -1) ? ((SpriteEffects)0) : ((SpriteEffects)1));
		SpriteEffects spriteEffects = val;
		int weightStage = projectile.AsPred().GetVisualWeightStage(projectile);
		string weightString = "_Weight" + ((weightStage == 0) ? "Base" : ((object)weightStage));
		string text = "V2/Projectiles/Vanilla/Summons/Pets/FairyPrincess" + weightString;
		int bellySize = projectile.AsPred().GetVisualBellySize(projectile);
		string bellyString = "_Belly" + ((bellySize == 0) ? "Base" : ((object)bellySize));
		Texture2D value = ModContent.Request<Texture2D>(text + bellyString, (AssetRequestMode)1).Value;
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(0, projectile.frame * 74, 64, 74);
		Main.EntitySpriteDraw(value, ((Entity)projectile).Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), (Rectangle?)sourceRect, lightColor, projectile.rotation, new Vector2(28f, 28f), 1f, spriteEffects, 0f);
		return false;
	}
}
