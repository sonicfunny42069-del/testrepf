using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.NPCs.Voraria.TownNPCs.Ghost;

[AutoloadHead]
public class Echo : ModNPC
{
	public override string Texture => "V2/NPCs/Voraria/TownNPCs/Ghost/Echo_Weight0";

	public override string HeadTexture => "V2/NPCs/Voraria/TownNPCs/Ghost/Echo_Head";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		Main.npcFrameCount[((ModNPC)this).NPC.type] = 4;
		Sets.IsTownPet[((ModNPC)this).NPC.type] = true;
		Sets.ImmuneToRegularBuffs[((ModNPC)this).NPC.type] = true;
		Sets.IsPetSmallForPetting[((ModNPC)this).NPC.type] = true;
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.Velocity = 1f;
		val.Direction = -1;
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		bestiaryEntry.Info.AddRange((IEnumerable<IBestiaryInfoElement>)(object)new IBestiaryInfoElement[2]
		{
			(IBestiaryInfoElement)Times.NightTime,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.TownNPCs.Ghost")
		});
	}

	public override void SetDefaults()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.townNPC = true;
		((ModNPC)this).NPC.friendly = true;
		((Entity)((ModNPC)this).NPC).width = 22;
		((Entity)((ModNPC)this).NPC).height = 48;
		((ModNPC)this).NPC.aiStyle = 7;
		((ModNPC)this).NPC.lifeMax = 500;
		((ModNPC)this).NPC.damage = 35;
		((ModNPC)this).NPC.defense = 38;
		((ModNPC)this).NPC.knockBackResist = 0.5f;
		((ModNPC)this).NPC.housingCategory = 1;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).NPC.dontTakeDamageFromHostiles = true;
		((ModNPC)this).NPC.AsV2NPC().GetNewDialogue = GetGhostChat;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 1.3;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.07;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 2.8;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 400.0;
		((ModNPC)this).NPC.AsPred().SmallGulps = Gulps.Short;
		((ModNPC)this).NPC.AsPred().SmallGulpThreshold = 0.45;
		((ModNPC)this).NPC.AsPred().BigGulps = Gulps.Standard;
		((ModNPC)this).NPC.AsPred().CanBeForceFed = CanGhostBeForceFed;
		((ModNPC)this).NPC.AsPred().OnForceFed = OnGhostForceFed;
		((ModNPC)this).NPC.AsPred().DigestionType = EntityDigestionType.Acidic;
		((ModNPC)this).NPC.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		((ModNPC)this).NPC.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		((ModNPC)this).NPC.AsPred().OnDigestionKill = null;
		((ModNPC)this).NPC.AsPred().MouthSoundRawOffset = ((Entity)(object)((ModNPC)this).NPC).TrueCenter() + new Vector2((float)((Entity)((ModNPC)this).NPC).direction * 8f, -14f);
		((ModNPC)this).NPC.AsPred().SmallBurps = Burps.Humanoid.Small;
		((ModNPC)this).NPC.AsPred().SmallBurpThreshold = 0.75;
		((ModNPC)this).NPC.AsPred().StandardBurps = Burps.Humanoid.Standard;
		((ModNPC)this).NPC.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		((ModNPC)this).NPC.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		((ModNPC)this).NPC.AsPred().GetVisualBellySize = GetVisualBellySize;
		((ModNPC)this).NPC.AsFood().OnDigestedBy = PreyNPC.OnKilledByDigestion_GrantLivePreyGoal;
	}

	public override void ModifyTypeName(ref string typeName)
	{
		typeName = "Ghost";
	}

	public override ITownNPCProfile TownNPCProfile()
	{
		return (ITownNPCProfile)(object)GhostStuff.GhostProfile;
	}

	public static List<string> GetGhostChat(NPC npc, Player player)
	{
		List<string> GhostChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		bool playerWasAlreadyDigested;
		bool num = player.IsFoodFor((Entity)(object)npc, out playerWasAlreadyDigested);
		npc.IsFoodFor((Entity)(object)player);
		if (num && !playerWasAlreadyDigested)
		{
			GhostChatPool.AddRange(new List<string> { ";>", ";)", ";D" });
		}
		else
		{
			GhostChatPool.AddRange(new List<string> { ":>", ":?", ":D", ":)", "C:", ":P" });
		}
		return GhostChatPool;
	}

	public static bool CanGhostBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnGhostForceFed(NPC npc, Player player)
	{
		PredNPC.SwallowWithTextIfApplicable(npc, player, "[c/7F7F7F:<Your body. Echo's mouth. Make it happen... And so you do.>]\n" + Utils.NextFromCollection<string>(Main.rand, new List<string> { "0_0" }));
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
	}

	public override bool CanGoToStatue(bool toKingStatue)
	{
		return !toKingStatue;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 1.8;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 6.0;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 1) * (1.0 + (double)GetVisualWeightStage(npc) / 10.0);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 6);
	}

	public static int GetVisualWeightStage(NPC npc)
	{
		return Math.Min((int)Math.Floor(3.0 * Math.Sqrt(npc.AsPred().ExtraWeight)), 7);
	}

	public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		boundingBox = new Rectangle((int)((Entity)((ModNPC)this).NPC).Center.X - 22, (int)((Entity)((ModNPC)this).NPC).Center.Y - 50, 44, 70);
	}

	public override void PostAI()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		Vector2 center = ((Entity)((ModNPC)this).NPC).Center;
		Color skyBlue = Color.SkyBlue;
		Lighting.AddLight(center, ((Color)(ref skyBlue)).ToVector3());
		GhostStuff.GhostProfile.frameWait++;
		if (GhostStuff.GhostProfile.frameWait >= GhostStuff.GhostProfile.frameDelay)
		{
			GhostStuff.GhostProfile.frameWait = 0;
			GhostStuff.GhostProfile.currentFrame++;
			if (GhostStuff.GhostProfile.currentFrame >= 4)
			{
				GhostStuff.GhostProfile.currentFrame = 0;
			}
		}
		switch (GetVisualBellySize(((ModNPC)this).NPC))
		{
		case 0:
		case 1:
			Sets.PlayerDistanceWhilePetting[((ModNPC)this).NPC.type] = 22;
			break;
		case 2:
			Sets.PlayerDistanceWhilePetting[((ModNPC)this).NPC.type] = 24;
			break;
		case 3:
			Sets.PlayerDistanceWhilePetting[((ModNPC)this).NPC.type] = 28;
			break;
		case 4:
			Sets.PlayerDistanceWhilePetting[((ModNPC)this).NPC.type] = 34;
			break;
		case 5:
			Sets.PlayerDistanceWhilePetting[((ModNPC)this).NPC.type] = 42;
			break;
		case 6:
			Sets.PlayerDistanceWhilePetting[((ModNPC)this).NPC.type] = 54;
			break;
		}
		switch (GetVisualWeightStage(((ModNPC)this).NPC))
		{
		case 2:
			((Entity)((ModNPC)this).NPC).velocity.X *= 0.99f;
			break;
		case 3:
			((Entity)((ModNPC)this).NPC).velocity.X *= 0.97f;
			break;
		case 4:
			((Entity)((ModNPC)this).NPC).velocity.X *= 0.94f;
			break;
		case 5:
			((Entity)((ModNPC)this).NPC).velocity.X *= 0.9f;
			break;
		default:
			((Entity)((ModNPC)this).NPC).velocity.X *= 0.15f;
			break;
		case 0:
		case 1:
			break;
		}
	}

	public void ExtraMainSpriteSize(int weight, out Vector2 SpriteSize, out Vector2 SpriteOffset)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		SpriteSize = new Vector2(44f, 72f);
		SpriteOffset = Vector2.Zero;
		switch (weight)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			SpriteSize = new Vector2(44f, 72f);
			SpriteOffset = Vector2.Zero;
			break;
		case 4:
			SpriteSize = new Vector2(50f, 72f);
			SpriteOffset = Vector2.Zero;
			break;
		case 5:
			SpriteSize = new Vector2(60f, 72f);
			SpriteOffset = new Vector2(4f, 0f);
			break;
		case 6:
			SpriteSize = new Vector2(78f, 72f);
			SpriteOffset = new Vector2(8f, 0f);
			break;
		case 7:
			SpriteSize = new Vector2(96f, 72f);
			SpriteOffset = new Vector2(12f, 0f);
			break;
		}
	}

	public void ExtraTumSpriteSize(int weight, out Vector2 SpriteSize, out Vector2 SpriteOffsetRight, out Vector2 SpriteOffsetLeft)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		SpriteSize = new Vector2(54f, 34f);
		SpriteOffsetRight = new Vector2(14f, 28f);
		SpriteOffsetLeft = new Vector2(-28f, 28f);
		switch (weight)
		{
		case 0:
		case 1:
			SpriteSize = new Vector2(54f, 34f);
			SpriteOffsetRight = new Vector2(14f, 28f);
			SpriteOffsetLeft = new Vector2(-28f, 28f);
			((Entity)((ModNPC)this).NPC).width = 22;
			break;
		case 2:
		case 3:
			SpriteSize = new Vector2(60f, 46f);
			SpriteOffsetRight = new Vector2(10f, 16f);
			SpriteOffsetLeft = new Vector2(-30f, 16f);
			((Entity)((ModNPC)this).NPC).width = 26;
			break;
		case 4:
			SpriteSize = new Vector2(60f, 46f);
			SpriteOffsetRight = new Vector2(8f, 16f);
			SpriteOffsetLeft = new Vector2(-22f, 16f);
			((Entity)((ModNPC)this).NPC).width = 30;
			break;
		case 5:
			SpriteSize = new Vector2(62f, 46f);
			SpriteOffsetRight = new Vector2(12f, 16f);
			SpriteOffsetLeft = new Vector2(-18f, 16f);
			((Entity)((ModNPC)this).NPC).width = 34;
			break;
		case 6:
			SpriteSize = new Vector2(64f, 46f);
			SpriteOffsetRight = new Vector2(20f, 16f);
			SpriteOffsetLeft = new Vector2(-10f, 16f);
			((Entity)((ModNPC)this).NPC).width = 38;
			break;
		case 7:
			SpriteSize = new Vector2(64f, 46f);
			SpriteOffsetRight = new Vector2(28f, 16f);
			SpriteOffsetLeft = new Vector2(-2f, 16f);
			((Entity)((ModNPC)this).NPC).width = 42;
			break;
		}
	}

	public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		SpriteEffects spriteEffects = (SpriteEffects)(((Entity)((ModNPC)this).NPC).direction == -1);
		string Folder = "V2/NPCs/Voraria/TownNPCs/Ghost/";
		int weightStage = GetVisualWeightStage(((ModNPC)this).NPC);
		int tumSize = GetVisualBellySize(((ModNPC)this).NPC);
		ExtraMainSpriteSize(weightStage, out var SpriteSize, out var SpriteOffset);
		Rectangle sourceRect = default(Rectangle);
		((Rectangle)(ref sourceRect))._002Ector(0, GhostStuff.GhostProfile.currentFrame * (int)SpriteSize.Y, (int)SpriteSize.X, (int)SpriteSize.Y);
		Texture2D spriteMain = ModContent.Request<Texture2D>(Folder + "Echo_Weight" + weightStage, (AssetRequestMode)2).Value;
		spriteBatch.Draw(spriteMain, ((Entity)((ModNPC)this).NPC).position - Main.screenPosition + new Vector2((float)(-12 - (int)SpriteOffset.X), (float)(-20 - (int)SpriteOffset.Y)), (Rectangle?)sourceRect, new Color(255, 255, 255), ((ModNPC)this).NPC.rotation, new Vector2(0f, 0f), 1f, spriteEffects, 0f);
		if (tumSize > 0)
		{
			ExtraTumSpriteSize(weightStage, out var SpriteSize2, out var SpriteOffset2R, out var SpriteOffset2L);
			Rectangle sourceRect2 = default(Rectangle);
			((Rectangle)(ref sourceRect2))._002Ector(0, (int)SpriteSize2.Y * (tumSize - 1), (int)SpriteSize2.X, (int)SpriteSize2.Y);
			Vector2 TumOffset = default(Vector2);
			((Vector2)(ref TumOffset))._002Ector((float)(int)SpriteOffset2R.X, (float)(int)SpriteOffset2R.Y);
			if (((Entity)((ModNPC)this).NPC).direction == -1)
			{
				((Vector2)(ref TumOffset))._002Ector((float)(int)SpriteOffset2L.X, (float)(int)SpriteOffset2L.Y);
			}
			TumOffset -= SpriteOffset;
			Texture2D spriteTum = ModContent.Request<Texture2D>(Folder + "EchoTum_Weight" + weightStage, (AssetRequestMode)2).Value;
			spriteBatch.Draw(spriteTum, ((Entity)((ModNPC)this).NPC).position - Main.screenPosition + TumOffset, (Rectangle?)sourceRect2, new Color(255, 255, 255), ((ModNPC)this).NPC.rotation, new Vector2(10f, 10f), 1f, spriteEffects, 0f);
		}
		return false;
	}
}
