using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Amateur;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.TownNPCs.Nurse;

public class Nurse : GlobalNPC
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static TileActionAttempt _003C0_003E__SearchAvoidedByNPCs;

		public static GeneralNPC.DelegateNewAI _003C1_003E__V2NurseAI;

		public static PredNPC.DelegateCanBeForceFed _003C2_003E__CanNurseBeForceFed;

		public static PredNPC.DelegateOnForceFed _003C3_003E__OnNurseForceFed;

		public static PredNPC.DelegateGetDigestionTickRate _003C4_003E__GetDigestionTickRate;

		public static PredNPC.DelegateGetDigestionTickDamage _003C5_003E__GetDigestionTickDamage;

		public static PredNPC.DelegateGetDigestedPlayerAdditionalDeathMessages _003C6_003E__GetDigestedPlayerAdditionalDeathMessages;

		public static PredNPC.DelegateGetPreyAbsorptionRate _003C7_003E__GetPreyAbsorptionRate;

		public static PredNPC.DelegateGetVisualBellySize _003C8_003E__GetVisualBellySize;

		public static PreyNPC.DelegateOnKilledByDigestion _003C9_003E__OnKilledByDigestion_GrantCheapskateGoal;
	}

	public bool randomGutHeal;

	public bool healTypeChoice;

	public int originalHealPrice;

	public int healOvertime;

	public bool digestScamPatient;

	public int healPlayerIndex;

	public int armsDealerHealTime;

	public static int ArmsDealerMaxHealTime => V2Utils.SensibleTime(0, 6);

	public override bool InstancePerEntity => true;

	public static bool V2NurseAI(NPC npc)
	{
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_142a: Unknown result type (might be due to invalid IL or missing references)
		//IL_142f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_15af: Unknown result type (might be due to invalid IL or missing references)
		//IL_1186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b86: Unknown result type (might be due to invalid IL or missing references)
		//IL_233a: Unknown result type (might be due to invalid IL or missing references)
		//IL_233f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2349: Unknown result type (might be due to invalid IL or missing references)
		//IL_234e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2353: Unknown result type (might be due to invalid IL or missing references)
		//IL_2358: Unknown result type (might be due to invalid IL or missing references)
		//IL_235f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2366: Unknown result type (might be due to invalid IL or missing references)
		//IL_236d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2372: Unknown result type (might be due to invalid IL or missing references)
		//IL_1822: Unknown result type (might be due to invalid IL or missing references)
		//IL_182c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1831: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_239e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_252c: Unknown result type (might be due to invalid IL or missing references)
		//IL_253e: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2501: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_2699: Unknown result type (might be due to invalid IL or missing references)
		//IL_269e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3628: Unknown result type (might be due to invalid IL or missing references)
		//IL_362e: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_33f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_33fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3402: Unknown result type (might be due to invalid IL or missing references)
		//IL_3407: Unknown result type (might be due to invalid IL or missing references)
		//IL_340c: Unknown result type (might be due to invalid IL or missing references)
		//IL_340e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3415: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_270c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2711: Unknown result type (might be due to invalid IL or missing references)
		//IL_2716: Unknown result type (might be due to invalid IL or missing references)
		//IL_364a: Unknown result type (might be due to invalid IL or missing references)
		//IL_364f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3655: Expected O, but got Unknown
		//IL_3313: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3660: Unknown result type (might be due to invalid IL or missing references)
		//IL_3674: Unknown result type (might be due to invalid IL or missing references)
		//IL_3679: Unknown result type (might be due to invalid IL or missing references)
		//IL_367e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3683: Unknown result type (might be due to invalid IL or missing references)
		//IL_3685: Unknown result type (might be due to invalid IL or missing references)
		//IL_368c: Unknown result type (might be due to invalid IL or missing references)
		//IL_351d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3524: Unknown result type (might be due to invalid IL or missing references)
		//IL_352b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3530: Unknown result type (might be due to invalid IL or missing references)
		//IL_3323: Unknown result type (might be due to invalid IL or missing references)
		//IL_332c: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a78: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_369f: Unknown result type (might be due to invalid IL or missing references)
		//IL_36a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_31b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_31bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_27eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2734: Unknown result type (might be due to invalid IL or missing references)
		//IL_274f: Unknown result type (might be due to invalid IL or missing references)
		//IL_276c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2771: Unknown result type (might be due to invalid IL or missing references)
		//IL_2776: Unknown result type (might be due to invalid IL or missing references)
		//IL_277b: Unknown result type (might be due to invalid IL or missing references)
		//IL_36fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_35a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_35ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_35c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2812: Unknown result type (might be due to invalid IL or missing references)
		//IL_2816: Unknown result type (might be due to invalid IL or missing references)
		//IL_281b: Unknown result type (might be due to invalid IL or missing references)
		//IL_281d: Unknown result type (might be due to invalid IL or missing references)
		//IL_282e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2833: Unknown result type (might be due to invalid IL or missing references)
		//IL_2838: Unknown result type (might be due to invalid IL or missing references)
		//IL_2849: Unknown result type (might be due to invalid IL or missing references)
		//IL_285f: Unknown result type (might be due to invalid IL or missing references)
		//IL_286f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2876: Unknown result type (might be due to invalid IL or missing references)
		//IL_2799: Unknown result type (might be due to invalid IL or missing references)
		//IL_27b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27db: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db7: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_38fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_347c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3481: Unknown result type (might be due to invalid IL or missing references)
		//IL_348b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3490: Unknown result type (might be due to invalid IL or missing references)
		//IL_3495: Unknown result type (might be due to invalid IL or missing references)
		//IL_349a: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_34f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3911: Unknown result type (might be due to invalid IL or missing references)
		//IL_3920: Unknown result type (might be due to invalid IL or missing references)
		//IL_37d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_37e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3801: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ffe: Unknown result type (might be due to invalid IL or missing references)
		NPC.ShimmeredTownNPCs[18] = npc.IsShimmerVariant;
		int num = 300;
		bool tryToStayInHouse = Main.raining;
		if (!Main.dayTime)
		{
			tryToStayInHouse = true;
		}
		if (Main.eclipse)
		{
			tryToStayInHouse = true;
		}
		if (Main.slimeRain)
		{
			tryToStayInHouse = true;
		}
		float damageMult = 1f;
		if (Main.masterMode)
		{
			npc.defense = (npc.dryadWard ? (npc.defDefense + 14) : npc.defDefense);
		}
		else if (Main.expertMode)
		{
			npc.defense = (npc.dryadWard ? (npc.defDefense + 10) : npc.defDefense);
		}
		else
		{
			npc.defense = (npc.dryadWard ? (npc.defDefense + 6) : npc.defDefense);
		}
		if (npc.isLikeATownNPC)
		{
			if (NPC.combatBookWasUsed)
			{
				damageMult += 0.2f;
				npc.defense += 6;
			}
			if (NPC.combatBookVolumeTwoWasUsed)
			{
				damageMult += 0.2f;
				npc.defense += 6;
			}
			if (NPC.downedBoss1)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (NPC.downedBoss2)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (NPC.downedBoss3)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (NPC.downedQueenBee)
			{
				damageMult += 0.1f;
				npc.defense += 3;
			}
			if (Main.hardMode)
			{
				damageMult += 0.4f;
				npc.defense += 12;
			}
			if (NPC.downedQueenSlime)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedMechBoss1)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedMechBoss2)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedMechBoss3)
			{
				damageMult += 0.15f;
				npc.defense += 6;
			}
			if (NPC.downedPlantBoss)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			if (NPC.downedEmpressOfLight)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			if (NPC.downedGolemBoss)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			if (NPC.downedAncientCultist)
			{
				damageMult += 0.15f;
				npc.defense += 8;
			}
			NPCLoader.BuffTownNPC(ref damageMult, ref npc.defense);
		}
		npc.dontTakeDamage = false;
		Color val;
		if (npc.ai[0] == 25f)
		{
			npc.dontTakeDamage = true;
			if (npc.ai[1] == 0f)
			{
				((Entity)npc).velocity.X = 0f;
			}
			((Entity)npc).shimmerWet = false;
			((Entity)npc).wet = false;
			((Entity)npc).lavaWet = false;
			((Entity)npc).honeyWet = false;
			if (npc.ai[1] == 0f && Main.netMode == 1)
			{
				return false;
			}
			if (npc.ai[1] == 0f && npc.ai[2] < 1f)
			{
				TownNPCAIReference.AI_007_TownEntities_Shimmer_TeleportToLandingSpot(npc);
			}
			if (npc.ai[2] > 0f)
			{
				npc.ai[2] -= 1f;
				if (npc.ai[2] <= 0f)
				{
					npc.ai[1] = 1f;
				}
				return false;
			}
			npc.ai[1] += 1f;
			if (npc.ai[1] >= 30f)
			{
				if (!Collision.WetCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height))
				{
					npc.shimmerTransparency = MathHelper.Clamp(npc.shimmerTransparency - 1f / 60f, 0f, 1f);
				}
				else
				{
					npc.ai[1] = 30f;
				}
				((Entity)npc).velocity = new Vector2(0f, -4f * npc.shimmerTransparency);
			}
			Rectangle hitbox = ((Entity)npc).Hitbox;
			hitbox.Y += 20;
			hitbox.Height -= 20;
			float num5 = Utils.NextFloatDirection(Main.rand);
			Vector2 center = ((Entity)npc).Center;
			val = Main.hslToRgb((float)Main.timeForVisualEffects / 360f % 1f, 0.6f, 0.65f, byte.MaxValue);
			Lighting.AddLight(center, ((Color)(ref val)).ToVector3() * Utils.Remap(npc.ai[1], 30f, 90f, 0f, 0.7f, true));
			if (Utils.NextFloat(Main.rand) > Utils.Remap(npc.ai[1], 30f, 60f, 1f, 0.5f, true))
			{
				Vector2 val2 = Utils.NextVector2FromRectangle(Main.rand, hitbox) + Utils.NextVector2Circular(Main.rand, 8f, 0f) + new Vector2(0f, 4f);
				Vector2? val3 = Utils.RotatedBy(new Vector2(0f, -2f), (double)(num5 * ((float)Math.PI * 2f) * 0.11f), default(Vector2));
				val = default(Color);
				Dust.NewDustPerfect(val2, 309, val3, 0, val, 1.7f - Math.Abs(num5) * 1.3f);
			}
			if (npc.ai[1] > 60f && Utils.NextBool(Main.rand, 15))
			{
				for (int i = 0; i < 3; i++)
				{
					Vector2 vector = Utils.NextVector2FromRectangle(Main.rand, ((Entity)npc).Hitbox);
					ParticleOrchestrator.RequestParticleSpawn(true, (ParticleOrchestraType)27, new ParticleOrchestraSettings
					{
						PositionInWorld = vector,
						MovementVector = Utils.RotatedBy(((Entity)npc).DirectionTo(vector), (double)((float)Math.PI * 9f / 20f * (float)(Main.rand.Next(2) * 2 - 1)), default(Vector2)) * Utils.NextFloat(Main.rand)
					}, (int?)null);
				}
			}
			npc.TargetClosest(true);
			NPCAimedTarget targetData = npc.GetTargetData(true);
			if (npc.ai[1] >= 75f && npc.shimmerTransparency <= 0f && Main.netMode != 1)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 0f;
				npc.ai[2] = 0f;
				npc.ai[3] = 0f;
				Math.Sign(((NPCAimedTarget)(ref targetData)).Center.X - ((Entity)npc).Center.X);
				((Entity)npc).velocity = new Vector2(0f, -4f);
				npc.localAI[0] = 0f;
				npc.localAI[1] = 0f;
				npc.localAI[2] = 0f;
				npc.localAI[3] = 0f;
				npc.netUpdate = true;
				npc.townNpcVariationIndex = ((npc.townNpcVariationIndex != 1) ? 1 : 0);
				NetMessage.SendData(56, -1, -1, (NetworkText)null, ((Entity)npc).whoAmI, 0f, 0f, 0f, 0, 0, 0);
				npc.Teleport(((Entity)npc).position, 12, 0);
				ParticleOrchestrator.BroadcastParticleSpawn((ParticleOrchestraType)31, new ParticleOrchestraSettings
				{
					PositionInWorld = ((Entity)npc).Center
				});
			}
			return false;
		}
		if (npc.homeTileX == -1 && npc.homeTileY == -1 && ((Entity)npc).velocity.Y == 0f && !npc.shimmering)
		{
			npc.UpdateHomeTileState(npc.homeless, (int)((Entity)npc).Center.X / 16, (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 4f) / 16);
		}
		bool flag3 = false;
		int num6 = (int)(((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16;
		int num7 = (int)(((Entity)npc).position.Y + (float)((Entity)npc).height + 1f) / 16;
		TownNPCAIReference.AI_007_FindGoodRestingSpot(npc, num6, num7, out var floorX, out var floorY);
		npc.directionY = -1;
		if (((Entity)npc).direction == 0)
		{
			((Entity)npc).direction = 1;
		}
		if (npc.ai[0] != 24f)
		{
			for (int j = 0; j < 255; j++)
			{
				if (((Entity)Main.player[j]).active && Main.player[j].talkNPC == ((Entity)npc).whoAmI)
				{
					flag3 = true;
					if (npc.ai[0] != 0f)
					{
						npc.netUpdate = true;
					}
					npc.ai[0] = 0f;
					npc.ai[1] = 300f;
					npc.localAI[3] = 100f;
					if (((Entity)Main.player[j]).position.X + (float)(((Entity)Main.player[j]).width / 2) < ((Entity)npc).position.X + (float)(((Entity)npc).width / 2))
					{
						((Entity)npc).direction = -1;
					}
					else
					{
						((Entity)npc).direction = 1;
					}
				}
			}
		}
		if (npc.ai[3] == 1f)
		{
			npc.life = -1;
			npc.HitEffect(0, 10.0, (bool?)null);
			((Entity)npc).active = false;
			npc.netUpdate = true;
			return false;
		}
		if (!WorldGen.InWorld(num6, num7, 0) || (Main.netMode == 1 && !Main.sectionManager.TileLoaded(num6, num7)))
		{
			return false;
		}
		if (!npc.homeless && Main.netMode != 1 && npc.townNPC && tryToStayInHouse && !TownNPCAIReference.AI_007_TownEntities_IsInAGoodRestingSpot(npc, num6, num7, floorX, floorY))
		{
			bool flag4 = true;
			Rectangle rectangle = default(Rectangle);
			for (int k = 0; k < 2; k++)
			{
				if (!flag4)
				{
					break;
				}
				((Rectangle)(ref rectangle))._002Ector((int)(((Entity)npc).position.X + (float)(((Entity)npc).width / 2) - (float)(NPC.sWidth / 2) - (float)NPC.safeRangeX), (int)(((Entity)npc).position.Y + (float)(((Entity)npc).height / 2) - (float)(NPC.sHeight / 2) - (float)NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
				if (k == 1)
				{
					((Rectangle)(ref rectangle))._002Ector(floorX * 16 + 8 - NPC.sWidth / 2 - NPC.safeRangeX, floorY * 16 + 8 - NPC.sHeight / 2 - NPC.safeRangeY, NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);
				}
				for (int l = 0; l < 255; l++)
				{
					if (((Entity)Main.player[l]).active)
					{
						Rectangle val4 = new Rectangle((int)((Entity)Main.player[l]).position.X, (int)((Entity)Main.player[l]).position.Y, ((Entity)Main.player[l]).width, ((Entity)Main.player[l]).height);
						if (((Rectangle)(ref val4)).Intersects(rectangle))
						{
							flag4 = false;
							break;
						}
					}
				}
			}
			if (flag4)
			{
				TownNPCAIReference.AI_007_TownEntities_TeleportToHome(npc, floorX, floorY);
			}
		}
		float num8 = 200f;
		if (Sets.DangerDetectRange[18] != -1)
		{
			num8 = Sets.DangerDetectRange[18];
		}
		bool flag13 = false;
		bool flag14 = false;
		float currentPrimaryTargetDistance = -1f;
		float currentSecondaryTargetDistance = -1f;
		int currentTargetDirection = 0;
		int currentPrimaryTarget = -1;
		int currentSecondaryTarget = -1;
		bool keepwalking;
		if (Main.netMode != 1 && !flag3)
		{
			for (int npcIterationIndex = 0; npcIterationIndex < 200; npcIterationIndex++)
			{
				if (!((Entity)Main.npc[npcIterationIndex]).active || Main.npc[npcIterationIndex].friendly || Main.npc[npcIterationIndex].damage <= 0 || !(((Entity)Main.npc[npcIterationIndex]).Distance(((Entity)npc).Center) < num8) || (!Main.npc[npcIterationIndex].noTileCollide && !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[npcIterationIndex]).Center, 0, 0)) || !NPCLoader.CanHitNPC(Main.npc[npcIterationIndex], npc))
				{
					continue;
				}
				bool canBeChasedByNurse = Main.npc[npcIterationIndex].CanBeChasedBy((object)npc, false);
				flag13 = true;
				float potentialTargetDistance = ((Entity)Main.npc[npcIterationIndex]).Center.X - ((Entity)npc).Center.X;
				if (potentialTargetDistance < 0f && (currentPrimaryTargetDistance == -1f || potentialTargetDistance > currentPrimaryTargetDistance))
				{
					currentPrimaryTargetDistance = potentialTargetDistance;
					if (canBeChasedByNurse)
					{
						currentPrimaryTarget = npcIterationIndex;
					}
				}
				if (potentialTargetDistance > 0f && (currentSecondaryTargetDistance == -1f || potentialTargetDistance < currentSecondaryTargetDistance))
				{
					currentSecondaryTargetDistance = potentialTargetDistance;
					if (canBeChasedByNurse)
					{
						currentSecondaryTarget = npcIterationIndex;
					}
				}
			}
			if (flag13)
			{
				currentTargetDirection = ((currentPrimaryTargetDistance == -1f) ? 1 : ((currentSecondaryTargetDistance != -1f) ? Utils.ToDirectionInt(currentSecondaryTargetDistance < 0f - currentPrimaryTargetDistance) : (-1)));
				float currentFinalizedTargetDistance = 0f;
				if (currentPrimaryTargetDistance != -1f)
				{
					currentFinalizedTargetDistance = 0f - currentPrimaryTargetDistance;
				}
				if (currentFinalizedTargetDistance == 0f || (currentSecondaryTargetDistance < currentFinalizedTargetDistance && currentSecondaryTargetDistance > 0f))
				{
					currentFinalizedTargetDistance = currentSecondaryTargetDistance;
				}
				if (npc.ai[0] == 8f)
				{
					if (((Entity)npc).direction == -currentTargetDirection)
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 300 + Main.rand.Next(300);
						npc.ai[2] = 0f;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
				else if (npc.ai[0] != 10f && npc.ai[0] != 12f && npc.ai[0] != 13f && npc.ai[0] != 14f && npc.ai[0] != 15f)
				{
					if (Sets.PrettySafe[18] != -1 && (float)Sets.PrettySafe[18] < currentFinalizedTargetDistance)
					{
						flag13 = false;
						flag14 = true;
					}
					else if (npc.ai[0] != 1f)
					{
						int tileX = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
						int tileY = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
						bool currentlyDrowning = ((Entity)npc).wet;
						TownNPCAIReference.AI_007_TownEntities_GetWalkPrediction(npc, num6, floorX, canBreathUnderWater: false, currentlyDrowning, tileX, tileY, out keepwalking, out var avoidFalling);
						if (!avoidFalling)
						{
							if (npc.ai[0] == 3f || npc.ai[0] == 4f || npc.ai[0] == 16f || npc.ai[0] == 17f)
							{
								NPC nPC = Main.npc[(int)npc.ai[2]];
								if (((Entity)nPC).active)
								{
									nPC.ai[0] = 1f;
									nPC.ai[1] = 120 + Main.rand.Next(120);
									nPC.ai[2] = 0f;
									nPC.localAI[3] = 0f;
									((Entity)nPC).direction = -currentTargetDirection;
									nPC.netUpdate = true;
								}
							}
							npc.ai[0] = 1f;
							npc.ai[1] = 120 + Main.rand.Next(120);
							npc.ai[2] = 0f;
							npc.localAI[3] = 0f;
							((Entity)npc).direction = -currentTargetDirection;
							npc.netUpdate = true;
						}
					}
					else if (npc.ai[0] == 1f && ((Entity)npc).direction != -currentTargetDirection)
					{
						((Entity)npc).direction = -currentTargetDirection;
						npc.netUpdate = true;
					}
				}
			}
		}
		if (npc.ai[0] == 0f)
		{
			if (npc.localAI[3] > 0f)
			{
				npc.localAI[3] -= 1f;
			}
			if (tryToStayInHouse && !flag3)
			{
				if (Main.netMode != 1)
				{
					if (num6 == floorX && num7 == floorY)
					{
						if (((Entity)npc).velocity.X != 0f)
						{
							npc.netUpdate = true;
						}
						if (((Entity)npc).velocity.X > 0.1f)
						{
							((Entity)npc).velocity.X -= 0.1f;
						}
						else if (((Entity)npc).velocity.X < -0.1f)
						{
							((Entity)npc).velocity.X += 0.1f;
						}
						else
						{
							((Entity)npc).velocity.X = 0f;
							TownNPCAIReference.AI_007_TryForcingSitting(npc, floorX, floorY);
						}
					}
					else
					{
						if (num6 > floorX)
						{
							((Entity)npc).direction = -1;
						}
						else
						{
							((Entity)npc).direction = 1;
						}
						npc.ai[0] = 1f;
						npc.ai[1] = 200 + Main.rand.Next(200);
						npc.ai[2] = 0f;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
			}
			else
			{
				if (((Entity)npc).velocity.X > 0.1f)
				{
					((Entity)npc).velocity.X -= 0.1f;
				}
				else if (((Entity)npc).velocity.X < -0.1f)
				{
					((Entity)npc).velocity.X += 0.1f;
				}
				else
				{
					((Entity)npc).velocity.X = 0f;
				}
				if (Main.netMode != 1)
				{
					if (npc.ai[1] > 0f)
					{
						npc.ai[1] -= 1f;
					}
					bool flag16 = true;
					int tileX2 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
					int tileY2 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
					bool currentlyDrowning2 = ((Entity)npc).wet;
					TownNPCAIReference.AI_007_TownEntities_GetWalkPrediction(npc, num6, floorX, canBreathUnderWater: false, currentlyDrowning2, tileX2, tileY2, out keepwalking, out var avoidFalling2);
					if (((Entity)npc).wet && Collision.DrownCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 1f, true))
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 200 + Main.rand.Next(300);
						npc.ai[2] = 0f;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
					if (avoidFalling2)
					{
						flag16 = false;
					}
					if (npc.ai[1] <= 0f)
					{
						if (flag16 && !avoidFalling2)
						{
							npc.ai[0] = 1f;
							npc.ai[1] = 200 + Main.rand.Next(300);
							npc.ai[2] = 0f;
							npc.localAI[3] = 0f;
							npc.netUpdate = true;
						}
						else
						{
							((Entity)npc).direction = ((Entity)npc).direction * -1;
							npc.ai[1] = 60 + Main.rand.Next(120);
							npc.netUpdate = true;
						}
					}
				}
			}
			if (Main.netMode != 1 && (!tryToStayInHouse || TownNPCAIReference.AI_007_TownEntities_IsInAGoodRestingSpot(npc, num6, num7, floorX, floorY)))
			{
				if (num6 < floorX - 25 || num6 > floorX + 25)
				{
					if (npc.localAI[3] == 0f)
					{
						if (num6 < floorX - 50 && ((Entity)npc).direction == -1)
						{
							((Entity)npc).direction = 1;
							npc.netUpdate = true;
						}
						else if (num6 > floorX + 50 && ((Entity)npc).direction == 1)
						{
							((Entity)npc).direction = -1;
							npc.netUpdate = true;
						}
					}
				}
				else if (Utils.NextBool(Main.rand, 80) && npc.localAI[3] == 0f)
				{
					npc.localAI[3] = 200f;
					((Entity)npc).direction = ((Entity)npc).direction * -1;
					npc.netUpdate = true;
				}
			}
		}
		else if (npc.ai[0] == 1f)
		{
			if (Main.netMode != 1 && tryToStayInHouse && TownNPCAIReference.AI_007_TownEntities_IsInAGoodRestingSpot(npc, num6, num7, floorX, floorY))
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 200 + Main.rand.Next(200);
				npc.localAI[3] = 60f;
				npc.netUpdate = true;
			}
			else
			{
				bool flag17 = Collision.DrownCollision(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, 1f, true);
				Tile val5;
				if (!flag17)
				{
					if (Main.netMode != 1 && !npc.homeless)
					{
						bool[] tileDungeon = Main.tileDungeon;
						val5 = ((Tilemap)(ref Main.tile))[num6, num7];
						if (!tileDungeon[((Tile)(ref val5)).TileType] && (num6 < floorX - 35 || num6 > floorX + 35))
						{
							if (((Entity)npc).position.X < (float)(floorX * 16) && ((Entity)npc).direction == -1)
							{
								npc.ai[1] -= 5f;
							}
							else if (((Entity)npc).position.X > (float)(floorX * 16) && ((Entity)npc).direction == 1)
							{
								npc.ai[1] -= 5f;
							}
						}
					}
					npc.ai[1] -= 1f;
				}
				if (npc.ai[1] <= 0f)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 300 + Main.rand.Next(300);
					npc.ai[2] = 0f;
					npc.ai[1] += Main.rand.Next(900);
					npc.localAI[3] = 60f;
					npc.netUpdate = true;
				}
				if (npc.closeDoor && ((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f > (float)(npc.doorX + 2) || (((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f < (float)(npc.doorX - 2)))
				{
					Tile tileSafely = Framing.GetTileSafely(npc.doorX, npc.doorY);
					if (TileLoader.CloseDoorID(tileSafely) >= 0)
					{
						if (WorldGen.CloseDoor(npc.doorX, npc.doorY, false))
						{
							npc.closeDoor = false;
							NetMessage.SendData(19, -1, -1, (NetworkText)null, 1, (float)npc.doorX, (float)npc.doorY, (float)((Entity)npc).direction, 0, 0, 0);
						}
						if ((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f > (float)(npc.doorX + 4) || (((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f < (float)(npc.doorX - 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f > (float)(npc.doorY + 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f < (float)(npc.doorY - 4))
						{
							npc.closeDoor = false;
						}
					}
					else if (((Tile)(ref tileSafely)).TileType == 389)
					{
						if (WorldGen.ShiftTallGate(npc.doorX, npc.doorY, true, false))
						{
							npc.closeDoor = false;
							NetMessage.SendData(19, -1, -1, (NetworkText)null, 5, (float)npc.doorX, (float)npc.doorY, 0f, 0, 0, 0);
						}
						if ((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f > (float)(npc.doorX + 4) || (((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f < (float)(npc.doorX - 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f > (float)(npc.doorY + 4) || (((Entity)npc).position.Y + (float)(((Entity)npc).height / 2)) / 16f < (float)(npc.doorY - 4))
						{
							npc.closeDoor = false;
						}
					}
					else
					{
						npc.closeDoor = false;
					}
				}
				float num17 = 1f;
				float num18 = 0.07f;
				if (npc.friendly && (flag13 || flag17))
				{
					num17 = 1.5f;
					float num19 = 1f - (float)npc.life / (float)npc.lifeMax;
					num17 += num19 * 0.9f;
					num18 = 0.1f;
				}
				if (((Entity)npc).velocity.X < 0f - num17 || ((Entity)npc).velocity.X > num17)
				{
					if (((Entity)npc).velocity.Y == 0f)
					{
						((Entity)npc).velocity = ((Entity)npc).velocity * 0.8f;
					}
				}
				else if (((Entity)npc).velocity.X < num17 && ((Entity)npc).direction == 1)
				{
					((Entity)npc).velocity.X += num18;
					if (((Entity)npc).velocity.X > num17)
					{
						((Entity)npc).velocity.X = num17;
					}
				}
				else if (((Entity)npc).velocity.X > 0f - num17 && ((Entity)npc).direction == -1)
				{
					((Entity)npc).velocity.X -= num18;
					if (((Entity)npc).velocity.X > num17)
					{
						((Entity)npc).velocity.X = num17;
					}
				}
				bool flag18 = true;
				if ((float)(npc.homeTileY * 16 - 32) > ((Entity)npc).position.Y)
				{
					flag18 = false;
				}
				if (!flag18 && ((Entity)npc).velocity.Y == 0f)
				{
					Collision.StepDown(ref ((Entity)npc).position, ref ((Entity)npc).velocity, ((Entity)npc).width, ((Entity)npc).height, ref npc.stepSpeed, ref npc.gfxOffY, 1, false);
				}
				if (((Entity)npc).velocity.Y >= 0f)
				{
					Collision.StepUp(ref ((Entity)npc).position, ref ((Entity)npc).velocity, ((Entity)npc).width, ((Entity)npc).height, ref npc.stepSpeed, ref npc.gfxOffY, 1, flag18, 1);
				}
				if (((Entity)npc).velocity.Y == 0f)
				{
					int num20 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2) + (float)(15 * ((Entity)npc).direction)) / 16f);
					int num21 = (int)((((Entity)npc).position.Y + (float)((Entity)npc).height - 16f) / 16f);
					int num22 = 180;
					TownNPCAIReference.AI_007_TownEntities_GetWalkPrediction(npc, num6, floorX, canBreathUnderWater: false, flag17, num20, num21, out var keepwalking3, out var avoidFalling3);
					bool flag19 = false;
					bool flag20 = false;
					if (((Entity)npc).wet && npc.townNPC && (flag20 = flag17) && npc.localAI[3] <= 0f)
					{
						avoidFalling3 = true;
						npc.localAI[3] = num22;
						int num23 = 0;
						for (int n = 0; n <= 10; n++)
						{
							val5 = Framing.GetTileSafely(num20 - ((Entity)npc).direction, num21 - n);
							if (((Tile)(ref val5)).LiquidAmount == 0)
							{
								break;
							}
							num23++;
						}
						float num24 = 0.3f;
						float num25 = (float)Math.Sqrt((float)(num23 * 16 + 16) * 2f * num24);
						if (num25 > 26f)
						{
							num25 = 26f;
						}
						((Entity)npc).velocity.Y = 0f - num25;
						npc.localAI[3] = ((Entity)npc).position.X;
						flag19 = true;
					}
					if (avoidFalling3 && !flag19)
					{
						int num26 = (int)((((Entity)npc).position.X + (float)(((Entity)npc).width / 2)) / 16f);
						int num27 = 0;
						for (int m = -1; m <= 1; m++)
						{
							Tile tileSafely2 = Framing.GetTileSafely(num26 + m, num21 + 1);
							if (((Tile)(ref tileSafely2)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely2)).TileType])
							{
								num27++;
							}
						}
						if (num27 <= 2)
						{
							if (((Entity)npc).velocity.X != 0f)
							{
								npc.netUpdate = true;
							}
							keepwalking3 = (avoidFalling3 = false);
							npc.ai[0] = 0f;
							npc.ai[1] = 50 + Main.rand.Next(50);
							npc.ai[2] = 0f;
							npc.localAI[3] = 40f;
						}
					}
					if (((Entity)npc).position.X == npc.localAI[3] && !flag19)
					{
						((Entity)npc).direction = ((Entity)npc).direction * -1;
						npc.netUpdate = true;
						npc.localAI[3] = num22;
					}
					if (flag17 && !flag19)
					{
						if (npc.localAI[3] > (float)num22)
						{
							npc.localAI[3] = num22;
						}
						if (npc.localAI[3] > 0f)
						{
							npc.localAI[3] -= 1f;
						}
					}
					else
					{
						npc.localAI[3] = -1f;
					}
					Tile tileSafely3 = Framing.GetTileSafely(num20, num21);
					Tile tileSafely4 = Framing.GetTileSafely(num20, num21 - 1);
					Tile tileSafely5 = Framing.GetTileSafely(num20, num21 - 2);
					bool flag21 = ((Entity)npc).height / 16 < 3;
					if ((npc.townNPC || Sets.AllowDoorInteraction[18]) && ((Tile)(ref tileSafely5)).HasUnactuatedTile && (TileLoader.IsClosedDoor(tileSafely5) || ((Tile)(ref tileSafely5)).TileType == 388) && (Utils.NextBool(Main.rand, 10) || tryToStayInHouse))
					{
						if (Main.netMode != 1)
						{
							if (WorldGen.OpenDoor(num20, num21 - 2, ((Entity)npc).direction))
							{
								npc.closeDoor = true;
								npc.doorX = num20;
								npc.doorY = num21 - 2;
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 0, (float)num20, (float)(num21 - 2), (float)((Entity)npc).direction, 0, 0, 0);
								npc.netUpdate = true;
								npc.ai[1] += 80f;
							}
							else if (WorldGen.OpenDoor(num20, num21 - 2, -((Entity)npc).direction))
							{
								npc.closeDoor = true;
								npc.doorX = num20;
								npc.doorY = num21 - 2;
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 0, (float)num20, (float)(num21 - 2), (float)(-((Entity)npc).direction), 0, 0, 0);
								npc.netUpdate = true;
								npc.ai[1] += 80f;
							}
							else if (WorldGen.ShiftTallGate(num20, num21 - 2, false, false))
							{
								npc.closeDoor = true;
								npc.doorX = num20;
								npc.doorY = num21 - 2;
								NetMessage.SendData(19, -1, -1, (NetworkText)null, 4, (float)num20, (float)(num21 - 2), 0f, 0, 0, 0);
								npc.netUpdate = true;
								npc.ai[1] += 80f;
							}
							else
							{
								((Entity)npc).direction = ((Entity)npc).direction * -1;
								npc.netUpdate = true;
							}
						}
					}
					else
					{
						if ((((Entity)npc).velocity.X < 0f && ((Entity)npc).direction == -1) || (((Entity)npc).velocity.X > 0f && ((Entity)npc).direction == 1))
						{
							bool flag22 = false;
							bool flag23 = false;
							if (((Tile)(ref tileSafely5)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely5)).TileType] && !Main.tileSolidTop[((Tile)(ref tileSafely5)).TileType] && (!flag21 || (((Tile)(ref tileSafely4)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely4)).TileType] && !Main.tileSolidTop[((Tile)(ref tileSafely4)).TileType])))
							{
								if (!Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20 - ((Entity)npc).direction, num21 - 5, num21 - 1) && !Collision.SolidTiles(num20, num20, num21 - 5, num21 - 3))
								{
									((Entity)npc).velocity.Y = -6f;
									npc.netUpdate = true;
								}
								else if (flag13)
								{
									flag23 = true;
									flag22 = true;
								}
								else if (!flag20)
								{
									flag22 = true;
								}
							}
							else if (((Tile)(ref tileSafely4)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely4)).TileType] && !Main.tileSolidTop[((Tile)(ref tileSafely4)).TileType])
							{
								if (!Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20 - ((Entity)npc).direction, num21 - 4, num21 - 1) && !Collision.SolidTiles(num20, num20, num21 - 4, num21 - 2))
								{
									((Entity)npc).velocity.Y = -5f;
									npc.netUpdate = true;
								}
								else if (flag13)
								{
									flag23 = true;
									flag22 = true;
								}
								else
								{
									flag22 = true;
								}
							}
							else if (((Entity)npc).position.Y + (float)((Entity)npc).height - (float)(num21 * 16) > 20f && ((Tile)(ref tileSafely3)).HasUnactuatedTile && Main.tileSolid[((Tile)(ref tileSafely3)).TileType] && !((Tile)(ref tileSafely3)).TopSlope)
							{
								if (!Collision.SolidTilesVersatile(num20 - ((Entity)npc).direction * 2, num20, num21 - 3, num21 - 1))
								{
									((Entity)npc).velocity.Y = -4.4f;
									npc.netUpdate = true;
								}
								else if (flag13)
								{
									flag23 = true;
									flag22 = true;
								}
								else
								{
									flag22 = true;
								}
							}
							else if (avoidFalling3)
							{
								if (!flag20)
								{
									flag22 = true;
								}
								if (flag13)
								{
									flag23 = true;
								}
							}
							if (flag23)
							{
								keepwalking3 = false;
								((Entity)npc).velocity.X = 0f;
								npc.ai[0] = 8f;
								npc.ai[1] = 240f;
								npc.netUpdate = true;
							}
							if (flag22)
							{
								((Entity)npc).direction = ((Entity)npc).direction * -1;
								((Entity)npc).velocity.X *= -1f;
								npc.netUpdate = true;
							}
							if (keepwalking3)
							{
								npc.ai[1] = 90f;
								npc.netUpdate = true;
							}
							if (((Entity)npc).velocity.Y < 0f)
							{
								npc.localAI[3] = ((Entity)npc).position.X;
							}
						}
						if (((Entity)npc).velocity.Y < 0f && ((Entity)npc).wet)
						{
							((Entity)npc).velocity.Y *= 1.2f;
						}
					}
				}
			}
		}
		else if (npc.ai[0] == 2f || npc.ai[0] == 11f)
		{
			if (Main.netMode != 1)
			{
				npc.localAI[3] -= 1f;
				if (Utils.NextBool(Main.rand, 60) && npc.localAI[3] == 0f)
				{
					npc.localAI[3] = 60f;
					((Entity)npc).direction = ((Entity)npc).direction * -1;
					npc.netUpdate = true;
				}
			}
			npc.ai[1] -= 1f;
			((Entity)npc).velocity.X *= 0.8f;
			if (npc.ai[1] <= 0f)
			{
				npc.localAI[3] = 40f;
				npc.ai[0] = 0f;
				npc.ai[1] = 60 + Main.rand.Next(60);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 3f || npc.ai[0] == 4f || npc.ai[0] == 5f || npc.ai[0] == 8f || npc.ai[0] == 9f || npc.ai[0] == 16f || npc.ai[0] == 17f || npc.ai[0] == 20f || npc.ai[0] == 21f || npc.ai[0] == 22f || npc.ai[0] == 23f)
		{
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			if (npc.ai[0] == 8f && npc.ai[1] < 60f && flag13)
			{
				npc.ai[1] = 180f;
				npc.netUpdate = true;
			}
			if (npc.ai[0] == 5f)
			{
				Point coords = Utils.ToTileCoordinates(((Entity)npc).Bottom + Vector2.UnitY * -2f);
				Tile tile = ((Tilemap)(ref Main.tile))[coords.X, coords.Y];
				if (!Sets.CanBeSatOnForNPCs[((Tile)(ref tile)).TileType])
				{
					npc.ai[1] = 0f;
				}
				else
				{
					Main.sittingManager.AddNPC(((Entity)npc).whoAmI, coords);
				}
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 60 + Main.rand.Next(60);
				npc.ai[2] = 0f;
				npc.localAI[3] = 30 + Main.rand.Next(60);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 6f || npc.ai[0] == 7f || npc.ai[0] == 18f || npc.ai[0] == 19f)
		{
			if (npc.ai[0] == 18f && (npc.localAI[3] < 1f || npc.localAI[3] > 2f))
			{
				npc.localAI[3] = 2f;
			}
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			int num34 = (int)npc.ai[2];
			if (num34 < 0 || num34 > 255 || !Main.player[num34].CanBeTalkedTo || ((Entity)Main.player[num34]).Distance(((Entity)npc).Center) > 200f || !Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)Main.player[num34]).Top, 0, 0))
			{
				npc.ai[1] = 0f;
			}
			if (npc.ai[1] > 0f)
			{
				int num35 = ((((Entity)npc).Center.X < ((Entity)Main.player[num34]).Center.X) ? 1 : (-1));
				if (num35 != ((Entity)npc).direction)
				{
					npc.netUpdate = true;
				}
				((Entity)npc).direction = num35;
			}
			else
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 60 + Main.rand.Next(60);
				npc.ai[2] = 0f;
				npc.localAI[3] = 30 + Main.rand.Next(60);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 10f)
		{
			int attackProjectileType = 0;
			int attackBaseDamage = 0;
			float attackKnockback = 0f;
			float attackProjectileSpeedMult = 0f;
			int attackProjectileDelay = 0;
			int attackCooldown = 0;
			int attackRandomExtraCooldown = 0;
			float attackProjectileGravityCorrection = 0f;
			float num42 = Sets.DangerDetectRange[18];
			float attackProjectileRandomOffset = 0f;
			if ((float)Sets.AttackTime[18] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
				npc.localAI[3] = 0f;
			}
			attackProjectileType = 583;
			attackProjectileSpeedMult = 8f;
			attackBaseDamage = 8;
			attackProjectileDelay = 1;
			attackCooldown = 15;
			attackRandomExtraCooldown = 10;
			attackKnockback = 2f;
			attackProjectileGravityCorrection = 10f;
			NPCLoader.TownNPCAttackStrength(npc, ref attackBaseDamage, ref attackKnockback);
			NPCLoader.TownNPCAttackCooldown(npc, ref attackCooldown, ref attackRandomExtraCooldown);
			NPCLoader.TownNPCAttackProj(npc, ref attackProjectileType, ref attackProjectileDelay);
			NPCLoader.TownNPCAttackProjSpeed(npc, ref attackProjectileSpeedMult, ref attackProjectileGravityCorrection, ref attackProjectileRandomOffset);
			if (Main.expertMode)
			{
				float num43 = attackBaseDamage;
				GameModeData gameModeInfo = Main.GameModeInfo;
				attackBaseDamage = (int)(num43 * ((GameModeData)(ref gameModeInfo)).TownNPCDamageMultiplier);
			}
			attackBaseDamage = (int)((float)attackBaseDamage * damageMult);
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			if (npc.localAI[3] == (float)attackProjectileDelay && Main.netMode != 1)
			{
				Vector2 attackProjectileSpeed = -Vector2.UnitY;
				if (currentTargetDirection == 1 && npc.spriteDirection == 1 && currentSecondaryTarget != -1)
				{
					attackProjectileSpeed = ((Entity)npc).DirectionTo(((Entity)Main.npc[currentSecondaryTarget]).Center + new Vector2(0f, (0f - attackProjectileGravityCorrection) * MathHelper.Clamp(((Entity)npc).Distance(((Entity)Main.npc[currentSecondaryTarget]).Center) / num42, 0f, 1f)));
				}
				if (currentTargetDirection == -1 && npc.spriteDirection == -1 && currentPrimaryTarget != -1)
				{
					attackProjectileSpeed = ((Entity)npc).DirectionTo(((Entity)Main.npc[currentPrimaryTarget]).Center + new Vector2(0f, (0f - attackProjectileGravityCorrection) * MathHelper.Clamp(((Entity)npc).Distance(((Entity)Main.npc[currentPrimaryTarget]).Center) / num42, 0f, 1f)));
				}
				if (Utils.HasNaNs(attackProjectileSpeed) || Math.Sign(attackProjectileSpeed.X) != npc.spriteDirection)
				{
					((Vector2)(ref attackProjectileSpeed))._002Ector((float)npc.spriteDirection, -1f);
				}
				attackProjectileSpeed *= attackProjectileSpeedMult;
				attackProjectileSpeed += Utils.RandomVector2(Main.rand, 0f - attackProjectileRandomOffset, attackProjectileRandomOffset);
				int num44 = 1000;
				num44 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, attackProjectileSpeed.X, attackProjectileSpeed.Y, attackProjectileType, attackBaseDamage, attackKnockback, Main.myPlayer, 0f, 0f, 0f);
				Main.projectile[num44].npcProj = true;
				Main.projectile[num44].noDropItem = true;
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = ((npc.localAI[2] == 8f && flag13) ? 8 : 0);
				npc.ai[1] = attackCooldown + Main.rand.Next(attackRandomExtraCooldown);
				npc.ai[2] = 0f;
				npc.localAI[1] = (npc.localAI[3] = attackCooldown / 2 + Main.rand.Next(attackRandomExtraCooldown));
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 13f)
		{
			((Entity)npc).velocity.X *= 0.8f;
			if ((float)Sets.AttackTime[18] == npc.ai[1])
			{
				npc.frameCounter = 0.0;
			}
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			if (npc.localAI[3] == 1f && Main.netMode != 1)
			{
				Vector2 vec3 = ((Entity)npc).DirectionTo(((Entity)Main.npc[(int)npc.ai[2]]).Center + new Vector2(0f, -20f));
				if (Utils.HasNaNs(vec3) || Math.Sign(vec3.X) == -npc.spriteDirection)
				{
					((Vector2)(ref vec3))._002Ector((float)npc.spriteDirection, -1f);
				}
				vec3 *= 8f;
				int num54 = Projectile.NewProjectile(((Entity)npc).GetSource_FromAI((string)null), ((Entity)npc).Center.X + (float)(npc.spriteDirection * 16), ((Entity)npc).Center.Y - 2f, vec3.X, vec3.Y, 584, 0, 0f, Main.myPlayer, npc.ai[2], 0f, 0f);
				Main.projectile[num54].npcProj = true;
				Main.projectile[num54].noDropItem = true;
			}
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 10 + Main.rand.Next(10);
				npc.ai[2] = 0f;
				npc.localAI[3] = 5 + Main.rand.Next(10);
				npc.netUpdate = true;
			}
		}
		else if (npc.ai[0] == 24f)
		{
			((Entity)npc).velocity.X *= 0.8f;
			npc.ai[1] -= 1f;
			npc.localAI[3] += 1f;
			((Entity)npc).direction = 1;
			npc.spriteDirection = 1;
			val = npc.GetMagicAuraColor();
			Vector3 vector7 = ((Color)(ref val)).ToVector3();
			Lighting.AddLight(((Entity)npc).Center, vector7.X, vector7.Y, vector7.Z);
			if (npc.ai[1] <= 0f)
			{
				npc.ai[0] = 0f;
				npc.ai[1] = 480f;
				npc.ai[2] = 0f;
				npc.localAI[1] = 480f;
				npc.netUpdate = true;
			}
		}
		if (Main.netMode != 1 && npc.isLikeATownNPC && !flag3)
		{
			bool flag26 = npc.ai[0] < 2f && !flag13 && !((Entity)npc).wet;
			bool flag27 = (npc.ai[0] < 2f || npc.ai[0] == 8f) && (flag13 || flag14);
			if (npc.localAI[1] > 0f)
			{
				npc.localAI[1] -= 1f;
			}
			if (npc.localAI[1] > 0f)
			{
				flag27 = false;
			}
			if (npc.CanTalk && flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 300))
			{
				int num90 = 420;
				num90 = ((!Utils.NextBool(Main.rand, 2)) ? (num90 * Main.rand.Next(1, 3)) : (num90 * Main.rand.Next(1, 4)));
				int num91 = 100;
				int num92 = 20;
				for (int num93 = 0; num93 < 200; num93++)
				{
					NPC nPC4 = Main.npc[num93];
					bool flag28 = (nPC4.ai[0] == 1f && nPC4.closeDoor) || (nPC4.ai[0] == 1f && nPC4.ai[1] > 200f) || nPC4.ai[0] > 1f || ((Entity)nPC4).wet;
					if (nPC4 != npc && ((Entity)nPC4).active && nPC4.CanBeTalkedTo && !flag28 && ((Entity)nPC4).Distance(((Entity)npc).Center) < (float)num91 && ((Entity)nPC4).Distance(((Entity)npc).Center) > (float)num92 && Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)nPC4).Center, 0, 0))
					{
						int num94 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)nPC4).position.X);
						npc.ai[0] = 3f;
						npc.ai[1] = num90;
						npc.ai[2] = num93;
						((Entity)npc).direction = num94;
						npc.netUpdate = true;
						nPC4.ai[0] = 4f;
						nPC4.ai[1] = num90;
						nPC4.ai[2] = ((Entity)npc).whoAmI;
						((Entity)nPC4).direction = -num94;
						nPC4.netUpdate = true;
						break;
					}
				}
			}
			else if (npc.CanTalk && flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1800))
			{
				int num95 = 420;
				num95 = ((!Utils.NextBool(Main.rand, 2)) ? (num95 * Main.rand.Next(1, 3)) : (num95 * Main.rand.Next(1, 4)));
				int num96 = 100;
				int num97 = 20;
				for (int num98 = 0; num98 < 200; num98++)
				{
					NPC nPC5 = Main.npc[num98];
					bool flag29 = (nPC5.ai[0] == 1f && nPC5.closeDoor) || (nPC5.ai[0] == 1f && nPC5.ai[1] > 200f) || nPC5.ai[0] > 1f || ((Entity)nPC5).wet;
					if (nPC5 != npc && ((Entity)nPC5).active && nPC5.CanBeTalkedTo && !Sets.IsTownPet[nPC5.type] && !flag29 && ((Entity)nPC5).Distance(((Entity)npc).Center) < (float)num96 && ((Entity)nPC5).Distance(((Entity)npc).Center) > (float)num97 && Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)nPC5).Center, 0, 0))
					{
						int num99 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)nPC5).position.X);
						npc.ai[0] = 16f;
						npc.ai[1] = num95;
						npc.ai[2] = num98;
						npc.localAI[2] = Main.rand.Next(4);
						npc.localAI[3] = Main.rand.Next(3 - (int)npc.localAI[2]);
						((Entity)npc).direction = num99;
						npc.netUpdate = true;
						nPC5.ai[0] = 17f;
						nPC5.ai[1] = num95;
						nPC5.ai[2] = ((Entity)npc).whoAmI;
						nPC5.localAI[2] = 0f;
						nPC5.localAI[3] = 0f;
						((Entity)nPC5).direction = -num99;
						nPC5.netUpdate = true;
						break;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1200) && BirthdayParty.PartyIsUp && Sets.AttackType[18] == Sets.AttackType[208])
			{
				int num100 = 300;
				int num101 = 150;
				for (int num102 = 0; num102 < 255; num102++)
				{
					Player player = Main.player[num102];
					if (((Entity)player).active && !player.dead && ((Entity)player).Distance(((Entity)npc).Center) < (float)num101 && Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)player).Top, 0, 0))
					{
						int num103 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)player).position.X);
						npc.ai[0] = 6f;
						npc.ai[1] = num100;
						npc.ai[2] = num102;
						((Entity)npc).direction = num103;
						npc.netUpdate = true;
						break;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1800))
			{
				npc.ai[0] = 2f;
				npc.ai[1] = 45 * Main.rand.Next(1, 2);
				npc.netUpdate = true;
			}
			else if (flag26 && npc.ai[0] == 0f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 1200))
			{
				int num108 = 220;
				int num109 = 150;
				for (int num110 = 0; num110 < 255; num110++)
				{
					Player player3 = Main.player[num110];
					if (player3.CanBeTalkedTo && ((Entity)player3).Distance(((Entity)npc).Center) < (float)num109 && Collision.CanHitLine(((Entity)npc).Top, 0, 0, ((Entity)player3).Top, 0, 0))
					{
						int num111 = Utils.ToDirectionInt(((Entity)npc).position.X < ((Entity)player3).position.X);
						npc.ai[0] = 7f;
						npc.ai[1] = num108;
						npc.ai[2] = num110;
						((Entity)npc).direction = num111;
						npc.netUpdate = true;
						break;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 1f && ((Entity)npc).velocity.Y == 0f && num > 0 && Utils.NextBool(Main.rand, num))
			{
				Point point = Utils.ToTileCoordinates(((Entity)npc).Bottom + Vector2.UnitY * -2f);
				bool flag30 = WorldGen.InWorld(point.X, point.Y, 1);
				if (flag30)
				{
					for (int num112 = 0; num112 < 200; num112++)
					{
						if (((Entity)Main.npc[num112]).active && Main.npc[num112].aiStyle == 7 && Main.npc[num112].townNPC && Main.npc[num112].ai[0] == 5f && Utils.ToTileCoordinates(((Entity)Main.npc[num112]).Bottom + Vector2.UnitY * -2f) == point)
						{
							flag30 = false;
							break;
						}
					}
					for (int num113 = 0; num113 < 255; num113++)
					{
						if (((Entity)Main.player[num113]).active && Main.player[num113].sitting.isSitting && Utils.ToTileCoordinates(((Entity)Main.player[num113]).Center) == point)
						{
							flag30 = false;
							break;
						}
					}
				}
				if (flag30)
				{
					Tile tile2 = ((Tilemap)(ref Main.tile))[point.X, point.Y];
					flag30 = Sets.CanBeSatOnForNPCs[((Tile)(ref tile2)).TileType];
					if (flag30 && ((Tile)(ref tile2)).TileType == 15 && ((Tile)(ref tile2)).TileFrameY >= 1080 && ((Tile)(ref tile2)).TileFrameY <= 1098)
					{
						flag30 = false;
					}
					if (flag30)
					{
						npc.ai[0] = 5f;
						npc.ai[1] = 900 + Main.rand.Next(10800);
						int targetDirection = default(int);
						Vector2 bottom = default(Vector2);
						npc.SitDown(point, ref targetDirection, ref bottom);
						((Entity)npc).direction = targetDirection;
						((Entity)npc).Bottom = bottom;
						((Entity)npc).velocity = Vector2.Zero;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
			}
			else if (flag26 && npc.ai[0] == 1f && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, 600))
			{
				Vector2 top = ((Entity)npc).Top;
				Vector2 bottom2 = ((Entity)npc).Bottom;
				float num114 = ((Entity)npc).width;
				object obj = _003C_003EO._003C0_003E__SearchAvoidedByNPCs;
				if (obj == null)
				{
					TileActionAttempt val6 = DelegateMethods.SearchAvoidedByNPCs;
					_003C_003EO._003C0_003E__SearchAvoidedByNPCs = val6;
					obj = (object)val6;
				}
				if (Utils.PlotTileLine(top, bottom2, num114, (TileActionAttempt)obj))
				{
					Point point2 = Utils.ToTileCoordinates(((Entity)npc).Center + new Vector2((float)(((Entity)npc).direction * 10), 0f));
					bool flag31 = WorldGen.InWorld(point2.X, point2.Y, 1);
					if (flag31)
					{
						Tile tileSafely7 = Framing.GetTileSafely(point2.X, point2.Y);
						if (!((Tile)(ref tileSafely7)).HasUnactuatedTile || !Sets.InteractibleByNPCs[((Tile)(ref tileSafely7)).TileType])
						{
							flag31 = false;
						}
					}
					if (flag31)
					{
						npc.ai[0] = 9f;
						npc.ai[1] = 40 + Main.rand.Next(90);
						((Entity)npc).velocity = Vector2.Zero;
						npc.localAI[3] = 0f;
						npc.netUpdate = true;
					}
				}
			}
			if (Main.netMode != 1 && npc.ai[0] < 2f && ((Entity)npc).velocity.Y == 0f && npc.breath > 0)
			{
				int num115 = -1;
				for (int num116 = 0; num116 < 200; num116++)
				{
					NPC nPC6 = Main.npc[num116];
					if (((Entity)(object)nPC6).CurrentCaptor() == null && ((Entity)nPC6).active && nPC6.townNPC && nPC6.life != nPC6.lifeMax && (num115 == -1 || nPC6.lifeMax - nPC6.life > Main.npc[num115].lifeMax - Main.npc[num115].life) && Collision.CanHitLine(((Entity)npc).position, ((Entity)npc).width, ((Entity)npc).height, ((Entity)nPC6).position, ((Entity)nPC6).width, ((Entity)nPC6).height) && ((Entity)npc).Distance(((Entity)nPC6).Center) < 500f)
					{
						num115 = num116;
					}
				}
				if (num115 != -1)
				{
					npc.ai[0] = 13f;
					npc.ai[1] = 34f;
					npc.ai[2] = num115;
					npc.localAI[3] = 0f;
					((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num115]).position.X) ? 1 : (-1));
					npc.netUpdate = true;
				}
			}
			if (flag27 && ((Entity)npc).velocity.Y == 0f && Utils.NextBool(Main.rand, Sets.AttackAverageChance[18] * 2))
			{
				int num117 = Sets.AttackTime[18];
				int num118 = ((currentTargetDirection == 1) ? currentSecondaryTarget : currentPrimaryTarget);
				int num119 = ((currentTargetDirection == 1) ? currentPrimaryTarget : currentSecondaryTarget);
				if (num118 != -1 && !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num118]).Center, 0, 0))
				{
					num118 = ((num119 == -1 || !Collision.CanHit(((Entity)npc).Center, 0, 0, ((Entity)Main.npc[num119]).Center, 0, 0)) ? (-1) : num119);
				}
				if (num118 != -1)
				{
					npc.localAI[2] = npc.ai[0];
					npc.ai[0] = 10f;
					npc.ai[1] = num117;
					npc.ai[2] = 0f;
					npc.localAI[3] = 0f;
					((Entity)npc).direction = ((((Entity)npc).position.X < ((Entity)Main.npc[num118]).position.X) ? 1 : (-1));
					npc.netUpdate = true;
				}
			}
		}
		return false;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 18;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.AsV2NPC().GetNewDialogue = GetNurseChat;
		npc.AsV2NPC().NewAIMethod = V2NurseAI;
		npc.AsFood().DefinedBaseSize = 1.1625;
		npc.AsPred().WeightGainRatio = 0.06;
		npc.AsPred().MaxStomachCapacity = 1.8;
		npc.AsPred().BaseStomachacheMeterCapacity = 180.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.65;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().CanBeForceFed = CanNurseBeForceFed;
		npc.AsPred().OnForceFed = OnNurseForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().OnDigestionKill = null;
		npc.AsPred().MouthSoundRawOffset = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 8f, -14f);
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 0.65;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		npc.AsNurse().randomGutHeal = false;
		npc.AsNurse().healOvertime = 0;
		npc.AsNurse().originalHealPrice = 0;
		npc.AsNurse().digestScamPatient = false;
		npc.AsNurse().healPlayerIndex = -1;
		npc.AsNurse().armsDealerHealTime = 0;
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.OnDigestedBy = (PreyNPC.DelegateOnKilledByDigestion)Delegate.Combine(preyNPC.OnDigestedBy, new PreyNPC.DelegateOnKilledByDigestion(OnKilledByDigestion_GrantCheapskateGoal));
		npc.AsFood().ItemTheftRules = new List<ItemTheftRule>
		{
			NurseStuff.ItemTheftRules.ClothingHat,
			NurseStuff.ItemTheftRules.ClothingTop,
			NurseStuff.ItemTheftRules.ClothingBottom
		};
	}

	public override void ResetEffects(NPC npc)
	{
		if (PredNPC.GetStomachTracker(npc) == null || PredNPC.GetStomachTracker(npc).Prey.FindAll((PreyData x) => x.Type == PreyType.Player).Count <= 0)
		{
			npc.AsNurse().healOvertime = 0;
			npc.AsNurse().digestScamPatient = false;
			npc.AsNurse().healPlayerIndex = -1;
			npc.AsNurse().armsDealerHealTime = 0;
		}
	}

	public override ITownNPCProfile ModifyTownNPCProfile(NPC npc)
	{
		return (ITownNPCProfile)(object)NurseStuff.PredNurseProfile;
	}

	public List<string> GetNurseChat(NPC npc, Player player)
	{
		npc.AsNurse().originalHealPrice = 0;
		npc.AsNurse().healTypeChoice = false;
		int npcsWithinHouse;
		int npcsWithinVillage;
		List<NPC> nearbyResidentNPCs = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage);
		NPC guide = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 22);
		NPC hopelessRomantic = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 19);
		NPC salad = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 20);
		NPC carefreeSwitch = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 208);
		NPC succubus = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == ModContent.NPCType<Lucinda>());
		List<string> nurseChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		if (player.IsFoodFor((Entity)(object)npc, out var playerWasAlreadyDigested) && !playerWasAlreadyDigested)
		{
			bool noDigest = (npc.AsNurse().randomGutHeal || npc.AsNurse().originalHealPrice > 0) && !npc.AsNurse().digestScamPatient && npc.AsNurse().healPlayerIndex != -1 && npc.AsNurse().healPlayerIndex == ((Entity)player).whoAmI;
			if (Main.bloodMoon)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Just shut up and melt into ass fat already. Seriously, I eat dozens of dipshits like you without a single inch added onto me while my chest weighs half a hundred kilograms because of you assholes, and other girls get basketball-sized cheeks for free after ONE good meal?", "God, you weigh WAY too much. All that MEAT hanging around without adding to my cheeks. As such, I'm prescribing you a one-way trip onto my BUTT so you start weighing IT down instead of ME!" }));
			}
			else
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "...just running a neuro assessment on you while you're in there...yup, full strength in all limbs.", "You know, I really wish the people I eat would stop sending themselves straight to my chest..." }));
				if (hopelessRomantic != null)
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("...I wonder if " + hopelessRomantic.GivenName + " would find me even more attractive like this...or, better yet, if he would want to be in your place..."));
				}
				if (noDigest)
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Hope you're healing up alright in there...mainly because I'd like to make sure you pay your dues once you're done. Maybe you'll even let me add a little bit of you to my ass as a bonus...", "I'd hope you're enjoying your time. Largely because I expect you to pay me once you're all healed up. Healthcare isn't free, even when it's inside a stomach like mine." }));
					if (npc.AsNurse().randomGutHeal)
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Don't worry, I got an order for this restraint. Now quit resisting or I'll make it tighter.", "Stop squirming so much. You looked ill, so I decided to give you my special treatment. The more you move around in there, the longer this is going to take...not that I mind...", "It's for your safety. You were a high fall risk!" }));
					}
				}
				else
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[6] { "Normally, I don't digest my patients, but since you were going to get yourself killed anyway, and the Hippocratic Oath says nothing about my stomach harming you, I'll make an exception.", "Still wanting to stay in there, or would you like to get out and have a lollipop for trying?...hah, I'm just kidding. You aren't getting out.", "As a word of warning, if eating you ends up making me catch some sort of illness, I'm including it in your next medical bill.", "Hmm...well, my stomach sounds perfectly healthy, and it feels perfectly healthy too. Seems you're just what the nurse ordered.", "You had better put all the fat you're about to give me onto my butt, instead of bumping me up a cup size like everyone else does. I am SO tired of people feigning sickness to fondle my breasts...", "Still wanting to stay in there, or would you like to get out and have a lollipop for trying?...hah, I'm just kidding. You aren't getting out." }));
					if (digestScamPatient)
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Oh, what's that? You wanted to be healed, not hurt? Well, you shouldn't have tried to undercut me, then. Enjoy being a nutrient soup and my future ass fat.", "Maybe next time, you'll pay me enough. If you couldn't pay your medical fees, then you shouldn't have asked me to eat you.", "Scamming prick...you BETTER add a new layer of fat to my ass, you hear me? You don't, I'll FORCE you down my throat and KEEP racking up your debt to me until you do." }));
					}
					else
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Well, if it hurts so much, I can offer you some tramadol.", "The more you fight it, the quicker you'll end up as a new cellulite deposit. Hopefully, on my butt..." }));
					}
				}
			}
		}
		else if (Main.bloodMoon)
		{
			int i = player.statLife;
			if (i > (int)((double)player.statLifeMax2 * 0.5))
			{
				int num = 5;
				List<string> list = new List<string>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<string> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = "I don't think I like your tone. Better keep that tongue to yourself before I cram it into my ass with the rest of you.";
				num2++;
				span[num2] = "If you're about to ask me to heal you for basically nothing, I swear, you're gonna be headed right to my ass...hopefully.";
				num2++;
				span[num2] = "Please don't tell me you went out and got a papercut or two just to be able to come in here...I'm already booked solid enough as is.";
				num2++;
				span[num2] = "If you get blood on my floor, you'll be BEGGING me to give you treatment by the time my stomach's done with you.";
				num2++;
				span[num2] = "If you're gonna die, do it either outside my house or inside my gut.";
				num2++;
				nurseChatPool = list;
			}
			else if (i < (int)((double)player.statLifeMax2 * 0.5))
			{
				if (PredNPC.CanSwallow(npc, (Entity)(object)player))
				{
					int num2 = 4;
					List<string> list2 = new List<string>(num2);
					CollectionsMarshal.SetCount(list2, num2);
					Span<string> span = CollectionsMarshal.AsSpan(list2);
					int num = 0;
					span[num] = "You were a high fall risk. This way, you won't be a high FALL risk; only a high FAT risk, which I'm willing to take if it means you'll ACTUALLY ADD TO MY ASS.";
					num++;
					span[num] = "Next time, don't come in here half-digested if you don't want me finishing the job, dumbass. Better add some meat to the glutes while you're melting in there.";
					num++;
					span[num] = "THERE! Now STAY put so you melt faster. You better make sure you take up PERMANENT residence on the cheeks in back, or I swear, you'll be in there OVER AND OVER UNTIL YOU DO.";
					num++;
					span[num] = "You were already about to DIE as it is. Might as well put your pathetic ass to good use trying to pad out mine...";
					num++;
					PredNPC.SwallowWithTextIfApplicable(npc, player, "[c/7F7F7F:<As soon as you open your mouth to ask a question, " + npc.GivenName + " grabs you and forcefully thrusts you headfirst into her mouth. Within what feels like a few seconds, you're crammed into her stomach, which is already beginning to pulverize you.>]\n" + list2);
				}
				return null;
			}
		}
		else
		{
			nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[4] { "You would think people would have a higher IQ than the pH of all the guts they keep jumping into. But considering what, and who, I've seen inside people's butts...well, after a while, you stop being surprised.", "Can I offer you a CHG bath? It's mint-flavo- I mean, mint-scented.", "Would you like a lollipop? Yeah? Too bad, you're getting an endoscope instead. Sit still long enough for me to examine your insides WITHOUT going into them, and you might get a reward.", "...I won't even bother reprimanding you. Yes, you can stare at them while I heal you, but don't touch. A woman as healthy as me has a VERY good metabolism." }));
			int i2 = player.statLife;
			if (i2 < player.statLifeMax2 && i2 > (int)((double)player.statLifeMax2 * 0.66))
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Staying healthy enough, I see. A few burns and scars, but nothing serious. They should heal up in a little while, as long as you don't do anything to worsen them.", "If you're about to ask me to heal you for basically nothing, I swear, you're gonna be headed right to my ass...hopefully.", "Please don't tell me you went out and got a papercut or two just to be able to come in here...I'm already booked solid enough as is." }));
			}
			else
			{
				int i3 = i2;
				if (i3 < (int)((double)player.statLifeMax2 * 0.66) && i3 > (int)((double)player.statLifeMax2 * 0.33))
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>((succubus != null) ? ("You look half-digested. Did you ask " + succubus.GivenName + " out to dinner again?") : "You look half-digested. Did you play around with a slime too long again?"));
				}
				else if (i2 < (int)((double)player.statLifeMax2 * 0.33))
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Looks like you left your arm at the door. Lemme just get that for you...I'm sure you don't mind if I cram it down my throat for a cleaning while I examine the rest of you.", "Sheesh, what melted off half YOUR face? If you're coming to me like this without payment, I might as well just put you in \"quarantine\" and finish the job..." }));
				}
			}
			VoreTracker stomachTracker = player.AsPred().StomachTracker;
			if (stomachTracker != null && stomachTracker.Prey.Count > 0)
			{
				if (player.AsPred().SafeStomach)
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("When I said I need you to sit still for the MRI, I meant both of you. Tell your contents to quit moving."));
				}
				else
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("Turn your head and cough...no, not burp, cough. No, I said- ugh, look, do you want my help or not?"));
				}
			}
			else
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Hunger pangs? Constant stomach growling? Desire to eat live creatures?...yes, those are all the signs of rising predatory needs. Perfectly normal. I recommend one or more healthy human-sized creatures per meal, no less frequently than 3 times a day.", "Hm. Your stomach hurts, you say? Well, there are two possibilities: either you're very hungry, or you have a stomachache. Do you feel hungry?" }));
			}
			if (guide != null)
			{
				if (guide.IsFoodFor((Entity)(object)player))
				{
					if (player.AsPred().SafeStomach)
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
						{
							"I can hear your gut wanting to digest him from here. You really shouldn't be trying to stave it off just to keep " + guide.GivenName + " alive in there, you know. It's not healthy.",
							"Alright, sit down...your \"patient\" might not be getting acid burns, but mine WILL be in a minute if you don't let me get your gut working on him again."
						}));
					}
					else
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
						{
							"I- ...oh, lemme guess. That's " + guide.GivenName + " in there.\n\n...well, at least that's one source of acid burns checked off the list...",
							"Alright, sit down...your notoriously heartburn-inducing \"patient\" should be well into your system by now, so I'm just going to conduct a quick examination to make sure he's digesting well."
						}));
					}
				}
				else if (guide.IsFoodFor((Entity)(object)npc))
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
					{
						"Eh, keep it quiet. At least with " + guide.GivenName + " in my gut, I know EXACTLY what can hurt him and what can't, and can examine him accordingly.",
						"Don't worry about " + guide.GivenName + "; I've tackled heartburn before, and I'll fight it off again. He'll...HOPEFULLY be adding to my glutes soon enough."
					}));
				}
				else
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
					{
						"I really need to have a talk with " + guide.GivenName + ". Just how many times a week can one guy come in with lava burns, acid burns, or both?",
						guide.GivenName + " has been connected to so many heartburn cases around here, I've lost count. Just how much of a fight could he possibly be putting up...?"
					}));
				}
			}
			if (hopelessRomantic != null)
			{
				if (hopelessRomantic.IsFoodFor((Entity)(object)player))
				{
					if (player.AsPred().SafeStomach)
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("...as much as I'd like to keep an eye on " + hopelessRomantic.GivenName + " by keeping him in MY gut instead of yours, I feel the need to remind you it's not healthy to prevent your stomach from digesting your meals."));
					}
					else
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "...at least let me have a taste again before you eat him next time...hmf.", "...alright, sit down. Let's hope you're not getting any metal poisoning from him. I know him to have quite the collection of bullets he keeps with him..." }));
					}
				}
				else if (hopelessRomantic.IsFoodFor((Entity)(object)npc))
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Mmmf...always nice to have him tucked away in there...o- oh. Hello there. Don't mind the stomach; just tending to a...particularly valued patient.", "Before you ask, no, my stomach is not available for healing. There's a very important patient in there right now." }));
				}
				else
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("Hey, has " + hopelessRomantic.GivenName + " mentioned needing a check-up lately?...n- no reason, of course. Just curious."));
				}
			}
			if (salad != null)
			{
				if (salad.IsFoodFor((Entity)(object)player))
				{
					if (player.AsPred().SafeStomach)
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
						{
							"...really? You're not even going to digest her? That's hardly a healthy way to eat a dryad...",
							"Whatever you did to make your system not digest " + salad.GivenName + ", un-do it. You're actively hurting your body...\n\n[c/BFBFBF:(...that, and you're looking more and more appetizing. Might cram you into me, write it off as a snack break...)]"
						}));
					}
					else
					{
						nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
						{
							"...god damnit, you got to her first...well, whatever. She's better off being gut fodder, anyway. Shady plant magic can't be trusted over tried and true medical practices.",
							"[c/7F7F7F:<" + npc.GivenName + " catches a glance at your midsection, then looks the other way with her arms crossed. She seems...almost jealous?>]\nWell, that's a healthy meal for you, at least. Dryads generally are a pretty nutritious choice, though the pickier preds I've seen don't like them much."
						}));
					}
				}
				else if (salad.IsFoodFor((Entity)(object)npc))
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Mmmm...now THAT'S a healthy lunch. Nice and active, too, so she should give my stomach a workout for the rest of the day. Now, do you need anything looked at?", "Huh? Oh, that dryad's currently busy being a meal for me. She's a healthy option, too. You should have her once she comes back, if you're looking for some healthy food that ISN'T me..." }));
				}
				else
				{
					nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("...oh, yeah, I'll be with you in just a moment.\n[c/BFBFBF:(I swear, " + salad.GivenName + " flaunts around that ass of hers much more, and I'll have to take a lunch break to see if I can add it to mine...)]"));
				}
			}
			if (carefreeSwitch != null)
			{
				if (carefreeSwitch.IsFoodFor((Entity)(object)player))
				{
					if (player.AsPred().SafeStomach)
					{
						nurseChatPool.AddRange(new List<string>
						{
							"...I see " + carefreeSwitch.GivenName + " gave you a lollipop of sorts. You...don't seem to be digesting her, either. I should probably give you a quick check-up...",
							"Hmm...no, your system's not responding to her the way it should. Is that something you just randomly decided to do for a while, or a medical condition I should be looking into?"
						});
					}
					else
					{
						nurseChatPool.AddRange(new List<string>
						{
							"...I see " + carefreeSwitch.GivenName + " gave you a lollipop of sorts. Must've felt like crashing in your gut. Be sure to check back in with me in a few hours. A girl that high in fat can clog up your system FAST if she doesn't digest well.",
							"Hmm...yeah, your system seems to be digesting that sweet tooth of hers just fine, at least for now. Still, keep an eye on your blood sugar and your fat levels, and give me a ring if you get any bad signs."
						});
					}
				}
				else if (carefreeSwitch.IsFoodFor((Entity)(object)npc))
				{
					nurseChatPool.AddRange(new List<string>
					{
						"[c/7F7F7F:<You feel the compulsion to ask where" + carefreeSwitch.GivenName + " is. " + npc.GivenName + " tries to keep quiet, but her bloated, squirmy belly and the belch she stifles with her left hand say all you need to know.>]",
						"Huh? Where'd " + carefreeSwitch.GivenName + " get off to?\n[c/7F7F7F:<" + npc.GivenName + " tries to keep down a burp...but fails, and sighs defeatedly.>]\nAlright, so I had an unhealthy meal. Sue me. I was hungry, and she likes to feed me when she's done her check-ups...at least, when she's not eating me instead."
					});
				}
				else
				{
					nurseChatPool.AddRange(new List<string>
					{
						"Make sure " + carefreeSwitch.GivenName + " keeps an eye on her sugar and comes in again soon, alright? She'll probably need another dosage of healthy food before long...",
						"Hey, while you're here: remind " + carefreeSwitch.GivenName + " that her next check-up's tonight, and you make sure she's taking her prescribed one apple a day!"
					});
				}
			}
			if (player.inventory[player.selectedItem].type == 4009)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("...that's an apple. What are you expecting? Apples are healthy, at least for younger people. For the older ones, you might need something a bit more filling..."));
			}
			if (player.AsPred().TotalMeals >= 50)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("No, you can't fit someone in a PEG tube. Stop asking."));
			}
			if (player.AsFood().TotalTimesDigested >= 5 && player.AsFood().TotalTimesDigested <= 25)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
				{
					"...maybe you should be the one to ask me to say \"ahh\" for a change?",
					"Hmm. You've already been mulched a total of...lemme check your chart..." + player.AsFood().TotalTimesDigested + " times. Be a bit more careful."
				}));
			}
			else if (player.AsFood().TotalTimesDigested > 25 && player.AsFood().TotalTimesDigested <= 100)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
				{
					"Shouldn't you be the one asking me to say \"ahh\"?",
					"The preds around this world have eaten you " + player.AsFood().TotalTimesDigested + " times already? Huh...wonder if any of them belched up a banner for you..."
				}));
			}
			else if (player.AsFood().TotalTimesDigested > 100)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
				{
					"Feels like you should be the one asking me to say \"ahh\". You've definitely gotten gurgled enough by now to make a gal believe you'd want that.",
					"Sheesh, you've been churned up " + player.AsFood().TotalTimesDigested + " times!? Ever consider a change of profession? Try some farming, perhaps? Maybe try moving in with someone who needs a dependable snack?"
				}));
			}
			if (Main.IsItAHappyWindyDay)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "I've been chasing my medical instruments all day. This gale is really keeping me fit!", "This breeze is really extra right now! Beware of flying needles and hungry predators, and don't get too full of air!" }));
			}
			if (Main.IsItRaining)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Great. Now my uniform's all wet...and now you won't stop staring. See, this is why I need to get more weight onto my ass instead...", "If you stay out there too long, you'll catch a cold. I suggest having some nice, warm meals and keeping out of the rain." }));
			}
			if (Main.IsItStorming)
			{
				nurseChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "I don't DO shock therapy. Go outside and sit under a tree if you need it that badly.", "I have had to treat SO many electrocuted patients today, it's not even funny. Just stay inside." }));
			}
		}
		return nurseChatPool;
	}

	public override void PostAI(NPC npc)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null || Main.GameUpdateCount % 60 != 0)
		{
			return;
		}
		PreyData crushAsPrey = PredNPC.GetStomachTracker(npc)?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 19);
		if (crushAsPrey != null)
		{
			Entity instance = crushAsPrey.Instance;
			NPC crush = (NPC)(object)((instance is NPC) ? instance : null);
			npc.AsNurse().armsDealerHealTime++;
			if (npc.AsNurse().armsDealerHealTime >= ArmsDealerMaxHealTime)
			{
				npc.AsNurse().armsDealerHealTime = 0;
				((Entity)crush).position = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 8f, -14f);
				((Entity)crush).velocity = new Vector2((float)((Entity)npc).direction * 12.5f, -2.5f);
				crush.AsFood().EatenSafetyFrames = 20;
				PredNPC.GetStomachTracker(npc).Prey.Remove(crushAsPrey);
				SoundStyle? standardBurps = npc.AsPred().StandardBurps;
				SoundEngine.PlaySound(ref standardBurps, (Vector2?)(((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 8f, -14f)), (SoundUpdateCallback)null);
			}
			else if (npc.AsNurse().armsDealerHealTime % 15 == 0 && crush.life < crush.lifeMax)
			{
				crush.life++;
			}
			return;
		}
		int npcsWithinHouse;
		int npcsWithinVillage;
		List<NPC> nearbyResidentNPCs = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage);
		NPC hopelessRomantic = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 19);
		bool gulpDownCrush = false;
		RollForRandomGulp(ref gulpDownCrush);
		RollForRandomGulp(ref gulpDownCrush);
		RollForRandomGulp(ref gulpDownCrush);
		int num;
		if (hopelessRomantic != null && ((Entity)hopelessRomantic).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange)
		{
			VoreTracker stomachTracker = PredNPC.GetStomachTracker(npc);
			num = ((stomachTracker != null && stomachTracker.Prey.Count == 0) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		if (((uint)num & (gulpDownCrush ? 1u : 0u)) != 0)
		{
			PredNPC.Swallow(npc, (Entity)(object)hopelessRomantic);
		}
		NPC guide = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 22);
		bool placeGuideInQuarantine = false;
		RollForRandomGulp(ref placeGuideInQuarantine);
		if (guide != null && ((Entity)guide).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && placeGuideInQuarantine)
		{
			PredNPC.Swallow(npc, (Entity)(object)guide);
		}
		NPC salad = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 20);
		bool tryToStealSaladAss = false;
		RollForRandomGulp(ref tryToStealSaladAss);
		RollForRandomGulp(ref tryToStealSaladAss);
		RollForRandomGulp(ref tryToStealSaladAss);
		if (salad != null && ((Entity)salad).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && tryToStealSaladAss)
		{
			PredNPC.Swallow(npc, (Entity)(object)salad);
		}
		NPC partyGirl = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 208);
		bool tryToConvertCakeLoverIntoCake = false;
		RollForRandomGulp(ref tryToConvertCakeLoverIntoCake);
		if (partyGirl != null && ((Entity)partyGirl).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && tryToConvertCakeLoverIntoCake)
		{
			PredNPC.Swallow(npc, (Entity)(object)partyGirl);
		}
		NPC bestGirl = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 353);
		bool tryToStealBestGirlAss = false;
		RollForRandomGulp(ref tryToStealBestGirlAss);
		RollForRandomGulp(ref tryToStealBestGirlAss);
		if (bestGirl != null && ((Entity)bestGirl).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && tryToStealBestGirlAss)
		{
			PredNPC.Swallow(npc, (Entity)(object)bestGirl);
		}
		if (!ModContent.GetInstance<V2ServerConfig>().RandomGulpsAgainstPlayers || !((Entity)Main.CurrentPlayer).active || Main.CurrentPlayer.dead || ((Entity)Main.CurrentPlayer).Distance(((Entity)npc).Center) > npc.AsPred().MaxSwallowRange || ((Entity)(object)Main.CurrentPlayer).CurrentCaptor() != null)
		{
			return;
		}
		bool shouldTryToAddPlayerToAss = false;
		RollForRandomGulp(ref shouldTryToAddPlayerToAss);
		if (Main.netMode != 2 && ((Entity)Main.CurrentPlayer).whoAmI == Main.myPlayer && ((Entity)Main.CurrentPlayer).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldTryToAddPlayerToAss)
		{
			if ((double)Main.CurrentPlayer.statLife < (double)Main.CurrentPlayer.statLifeMax2 / 2.0)
			{
				npc.AsNurse().randomGutHeal = true;
				npc.AsNurse().healTypeChoice = false;
				npc.AsNurse().healOvertime = 0;
				npc.AsNurse().digestScamPatient = false;
				List<string> potentialRandomGulpLines = new List<string> { "Just know that since your insurance won't cover it, you'll have to pay me once you're healed up.", "You're a high fall risk, and I'd rather keep you safe in my gut than out there getting hurt." };
				PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<" + npc.GivenName + "'s stomach growls softly; she proceeds to grab you and slowly guide you down her throat. As you settle in her middle, you find that there aren't any acids to be found, and the air is stunningly breathable.>]\nDon't worry, just putting you in quarantine before you ask. " + Utils.NextFromCollection<string>(Main.rand, potentialRandomGulpLines));
			}
			else
			{
				npc.AsNurse().randomGutHeal = false;
				npc.AsNurse().healTypeChoice = false;
				npc.AsNurse().healOvertime = 0;
				npc.AsNurse().digestScamPatient = false;
				List<string> potentialRandomGulpLines2 = new List<string> { "Let's hope your insurance will cover this...either that, or that you'll add a bit to my backside.", "I'm sure you don't mind a quick \"thorough examination\" of your body.", "After all, it’s easier to eat you than treat you, even if the two are pretty easily mixed up." };
				PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<" + npc.GivenName + "'s stomach growls impatiently; she proceeds to grab you and cram you down her throazat, doing her best to hurry you down so that her belly can get to work.>]\nDon't worry, just taking a quick lunch break. " + Utils.NextFromCollection<string>(Main.rand, potentialRandomGulpLines2));
			}
		}
		static void RollForRandomGulp(ref bool gulp)
		{
			gulp |= Utils.NextBool(Main.rand, 7, 200);
		}
	}

	public static bool CanNurseBeForceFed(NPC npc)
	{
		return PredNPC.GetStomachTracker(npc)?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 19) == null;
	}

	public static void OnNurseForceFed(NPC npc, Player player)
	{
		PredNPC.SetChatboxText(npc, player, "[c/7F7F7F:<" + npc.GivenName + "'s stomach growls with glee as you cram yourself into her mouth and throat; shrugging, she just gulps you down without a care and pats her gut once you're settled in.>]\nWell, that's one way to give me a lunch break, I guess. Make sure to add a little bit to the back, alright? It's the least you can do, if you want me to eat you that badly...");
		npc.AsNurse().healPlayerIndex = -1;
		npc.AsNurse().healOvertime = 0;
		npc.AsNurse().digestScamPatient = false;
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.4", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.5", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.6", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.7", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.8" });
		if (player.IsFoodFor((Entity)(object)npc, out var pastTense) && !pastTense && npc.AsNurse().healPlayerIndex != -1 && npc.AsNurse().healPlayerIndex == ((Entity)player).whoAmI && npc.AsNurse().digestScamPatient)
		{
			deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.NoFundsForHeal.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.NoFundsForHeal.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.NoFundsForHeal.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.NoFundsForHeal.4" });
		}
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Nurse.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		if (PredNPC.GetStomachTracker(npc)?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 19) != null && !Main.bloodMoon)
		{
			return 0.0;
		}
		if (!Main.bloodMoon)
		{
			return 1.15;
		}
		return 2.3;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 12.5;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
		if (npc.AsNurse().healPlayerIndex != -1 && digestedPrey.Type == PreyType.Player && digestedPrey.Instance.whoAmI == npc.AsNurse().healPlayerIndex)
		{
			npc.AsNurse().healPlayerIndex = -1;
		}
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 2, 30);
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		npc.frame.Width = 160;
	}

	public override void ModifyHoverBoundingBox(NPC npc, ref Rectangle boundingBox)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		boundingBox = new Rectangle((int)((Entity)npc).Center.X - 18, (int)((Entity)npc).Center.Y - 27, 36, 54);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 5);
	}

	public static void OnKilledByDigestion_GrantCheapskateGoal(NPC npc, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer == null)
		{
			return;
		}
		int num4 = predPlayer.statLifeMax2 - predPlayer.statLife;
		for (int j = 0; j < Player.MaxBuffs; j++)
		{
			int num5 = predPlayer.buffType[j];
			if (Main.debuff[num5] && predPlayer.buffTime[j] > 60 && (num5 < 0 || !Sets.NurseCannotRemoveDebuff[num5]))
			{
				num4 += 100;
			}
		}
		int health = predPlayer.statLifeMax2 - predPlayer.statLife;
		bool removeDebuffs = true;
		if (NPC.downedGolemBoss)
		{
			num4 *= 200;
		}
		else if (NPC.downedPlantBoss)
		{
			num4 *= 150;
		}
		else if (NPC.downedMechBossAny)
		{
			num4 *= 100;
		}
		else if (Main.hardMode)
		{
			num4 *= 60;
		}
		else if (NPC.downedBoss3 || NPC.downedQueenBee)
		{
			num4 *= 25;
		}
		else if (NPC.downedBoss2)
		{
			num4 *= 10;
		}
		else if (NPC.downedBoss1)
		{
			num4 *= 3;
		}
		if (Main.expertMode)
		{
			num4 *= 2;
		}
		int copperCoins = (int)((double)num4 * 1.2);
		if (copperCoins > 0 && copperCoins < 1)
		{
			copperCoins = 1;
		}
		int originalHealPrice = copperCoins;
		if (originalHealPrice < 0)
		{
			originalHealPrice = 0;
		}
		PlayerLoader.ModifyNursePrice(predPlayer, npc, health, removeDebuffs, ref originalHealPrice);
		if (originalHealPrice >= 20000)
		{
			ModContent.GetInstance<Cheapskate>().TrySetCompletion(predPlayer);
		}
	}
}
