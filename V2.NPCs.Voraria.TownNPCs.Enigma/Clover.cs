using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Armor;
using V2.Items.Voraria.Consumables;
using V2.Items.Voraria.Consumables.PermanentUpgrades.Jujus;
using V2.Items.Voraria.Placeables;
using V2.Items.Voraria.Weapons.Ranged;
using V2.PlayerHandling;
using V2.Projectiles.Voraria;
using V2.Sounds.Vore;

namespace V2.NPCs.Voraria.TownNPCs.Enigma;

[AutoloadHead]
public class Clover : ModNPC
{
	private const int BaseTownNPC = 20;

	public override string Texture => "V2/NPCs/Voraria/TownNPCs/Enigma/Clover_WeightBase_BellyBase";

	public override string HeadTexture => "V2/NPCs/Voraria/TownNPCs/Enigma/Clover_Head";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		Main.npcFrameCount[((ModNPC)this).NPC.type] = 23;
		Sets.ExtraFramesCount[((ModNPC)this).NPC.type] = 9;
		Sets.AttackFrameCount[((ModNPC)this).NPC.type] = 4;
		Sets.DangerDetectRange[((ModNPC)this).NPC.type] = 62;
		Sets.AttackType[((ModNPC)this).NPC.type] = 0;
		Sets.AttackTime[((ModNPC)this).NPC.type] = 30;
		Sets.AttackAverageChance[((ModNPC)this).NPC.type] = 1;
		Sets.HatOffsetY[((ModNPC)this).NPC.type] = Sets.HatOffsetY[20];
		Sets.ImmuneToRegularBuffs[((ModNPC)this).NPC.type] = true;
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.Velocity = 1f;
		val.Direction = -1;
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
		NPCHappiness val2 = ((ModNPC)this).NPC.Happiness;
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(160, (AffectionLevel)100);
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(663, (AffectionLevel)50);
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(369, (AffectionLevel)50);
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(441, (AffectionLevel)(-100));
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<MushroomBiome>((AffectionLevel)100);
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<HallowBiome>((AffectionLevel)50);
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<JungleBiome>((AffectionLevel)50);
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<DesertBiome>((AffectionLevel)(-50));
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<SnowBiome>((AffectionLevel)(-50));
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<CorruptionBiome>((AffectionLevel)(-100));
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<CrimsonBiome>((AffectionLevel)(-100));
		((NPCHappiness)(ref val2)).SetBiomeAffection<DungeonBiome>((AffectionLevel)(-100));
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		bestiaryEntry.Info.AddRange((IEnumerable<IBestiaryInfoElement>)(object)new IBestiaryInfoElement[2]
		{
			(IBestiaryInfoElement)Biomes.SurfaceMushroom,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.TownNPCs.Enigma")
		});
	}

	public override void SetDefaults()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.townNPC = true;
		((ModNPC)this).NPC.friendly = true;
		((Entity)((ModNPC)this).NPC).width = 18;
		((Entity)((ModNPC)this).NPC).height = 40;
		((ModNPC)this).NPC.aiStyle = 7;
		((ModNPC)this).NPC.lifeMax = 500;
		((ModNPC)this).NPC.damage = 35;
		((ModNPC)this).NPC.defense = 38;
		((ModNPC)this).NPC.knockBackResist = 0.5f;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).AnimationType = 20;
		((ModNPC)this).NPC.AsV2NPC().GetNewDialogue = GetEnigmaChat;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 1.15;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.125;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 2.2;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 90.0;
		((ModNPC)this).NPC.AsFood().StruggleEffectiveness = 1;
		((ModNPC)this).NPC.AsPred().SmallGulps = Gulps.Short;
		((ModNPC)this).NPC.AsPred().SmallGulpThreshold = 0.45;
		((ModNPC)this).NPC.AsPred().BigGulps = Gulps.Standard;
		((ModNPC)this).NPC.AsPred().CanBeForceFed = CanEnigmaBeForceFed;
		((ModNPC)this).NPC.AsPred().OnForceFed = OnEnigmaForceFed;
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
		typeName = "Enigma";
	}

	public override bool CanTownNPCSpawn(int numTownNPCs)
	{
		return ModContent.GetInstance<V2MasterSystem>().freedEnigma;
	}

	public override ITownNPCProfile TownNPCProfile()
	{
		return (ITownNPCProfile)(object)EnigmaStuff.EnigmaProfile;
	}

	public static List<string> GetEnigmaChat(NPC npc, Player player)
	{
		npc.GetNearbyResidentNPCs(out var _, out var _).FirstOrDefault((NPC x) => x.type == 353);
		List<string> EnigmaChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		bool playerWasAlreadyDigested;
		bool num = player.IsFoodFor((Entity)(object)npc, out playerWasAlreadyDigested);
		npc.IsFoodFor((Entity)(object)player);
		if (num && !playerWasAlreadyDigested)
		{
			EnigmaChatPool.AddRange(new List<string> { "So...uh...how long are you going to stay there?", "Hmm... I mean, I don't dislike this, I suppose.", "Well, I hope you're having fun doing your...thing?" });
		}
		else
		{
			EnigmaChatPool.AddRange(new List<string> { "Sup.", "Hey!", "Hello!", "AH! Hi, I didn't notice you!" });
			if (Main.dayTime)
			{
				EnigmaChatPool.AddRange(new List<string> { "Sure is bright today! Uh... Yeah. What's up?" });
				if (Main.IsItAHappyWindyDay)
				{
					EnigmaChatPool.AddRange(new List<string> { "Agh, so windy! I don't wanna lose my hat!! Oh, hey there!" });
				}
			}
			else
			{
				EnigmaChatPool.AddRange(new List<string> { "Ah, the cool breeze during nights feels so nice. Oh, 'sup." });
			}
			if (Main.IsItRaining)
			{
				EnigmaChatPool.AddRange(new List<string> { "Do you ever think about what a rain cloud would taste like?" });
			}
			if (Main.IsItStorming)
			{
				EnigmaChatPool.AddRange(new List<string> { "Augh, the damn lightning! ...wait, do you think, if I got struck by lightning, my magic would become stronger? Never mind, that's stupid." });
			}
		}
		return EnigmaChatPool;
	}

	public override void AddShops()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		NPCShop EnigmaShop = new NPCShop(((ModNPC)this).NPC.type, "Shop");
		EnigmaShop.Add<CloverHeadAccessories>(Array.Empty<Condition>());
		EnigmaShop.Add<CloverSweater>(Array.Empty<Condition>());
		EnigmaShop.Add<CloverStockings>(Array.Empty<Condition>());
		EnigmaShop.Add<BlankJuju>(Array.Empty<Condition>());
		EnigmaShop.Add<DemonCandy>(Array.Empty<Condition>());
		EnigmaShop.Add<GhostBall>(Array.Empty<Condition>());
		EnigmaShop.Add<MyFairy>((Condition[])(object)new Condition[1] { Condition.InGlowshroom });
		EnigmaShop.Add<DinnerBlaster>((Condition[])(object)new Condition[1] { Condition.NpcIsPresent(209) });
		((AbstractNPCShop)EnigmaShop).Register();
	}

	public static bool CanEnigmaBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnEnigmaForceFed(NPC npc, Player player)
	{
		PredNPC.SwallowWithTextIfApplicable(npc, player, "[c/7F7F7F:<After a quick glance at Clover, you jump into her mouth without warning, rocketing almost cartoonishly down her throat as she's left hacking and coughing for a moment in an attempt to recover some air (and general throat control) forced out of her by the sudden snack.>]\n" + Utils.NextFromCollection<string>(Main.rand, new List<string> { "[c/7F7F8F:*cough*] What!? Uh, wait, I... Well, I guess I don't have to make dinner for myself now? If you do plan on staying there, that is??", "Oh. Well, I hope this won't have any consequences on m- [c/00BF00:*hic!*] -...me.", "...what? On purpose? Jeez, the people here can be so weird sometimes..." }));
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
	}

	public override bool UsesPartyHat()
	{
		return false;
	}

	public override bool CanGoToStatue(bool toKingStatue)
	{
		return !toKingStatue;
	}

	public override void TownNPCAttackStrength(ref int damage, ref float knockback)
	{
		damage = 47;
		knockback = 28f;
	}

	public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
	{
		cooldown = 2;
		randExtraCooldown = 1;
	}

	public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
	{
		projType = ModContent.ProjectileType<CLOVERPUNCH>();
		attackDelay = 4;
	}

	public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
	{
		multiplier = 5f;
		randomOffset = 0f;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		return 1.8;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 6.0;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 1, 5);
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 0);
	}

	public override void FindFrame(int frameHeight)
	{
		((ModNPC)this).NPC.frame.Width = 194;
	}

	public override void ModifyHoverBoundingBox(ref Rectangle boundingBox)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		boundingBox = new Rectangle((int)((Entity)((ModNPC)this).NPC).Center.X - 16, (int)((Entity)((ModNPC)this).NPC).Center.Y - 18, 32, 44);
	}
}
