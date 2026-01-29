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
using V2.Items.Voraria.Charms;
using V2.Items.Voraria.Consumables.PermanentUpgrades;
using V2.Items.Voraria.Consumables.Potions;
using V2.Items.Voraria.Weapons.Ranged.Throwables;
using V2.NPCs.Voraria.TownNPCs.Succubus.ChatButtons;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.NPCs.Voraria.TownNPCs.Succubus;

[AutoloadHead]
public class Lucinda : ModNPC
{
	private const int BaseTownNPC = 20;

	public override string Texture => "V2/NPCs/Voraria/TownNPCs/Succubus/Lucinda_WeightBase_BellyBase";

	public override string HeadTexture => "V2/NPCs/Voraria/TownNPCs/Succubus/Lucinda_Head";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		Main.npcFrameCount[((ModNPC)this).NPC.type] = Main.npcFrameCount[20];
		Sets.ExtraFramesCount[((ModNPC)this).NPC.type] = Sets.ExtraFramesCount[20];
		Sets.AttackFrameCount[((ModNPC)this).NPC.type] = Sets.AttackFrameCount[20];
		Sets.DangerDetectRange[((ModNPC)this).NPC.type] = Sets.DangerDetectRange[20];
		Sets.AttackType[((ModNPC)this).NPC.type] = Sets.AttackType[20];
		Sets.AttackTime[((ModNPC)this).NPC.type] = 60;
		Sets.AttackAverageChance[((ModNPC)this).NPC.type] = Sets.AttackAverageChance[20];
		Sets.HatOffsetY[((ModNPC)this).NPC.type] = Sets.HatOffsetY[20];
		NPCBestiaryDrawModifiers val = default(NPCBestiaryDrawModifiers);
		((NPCBestiaryDrawModifiers)(ref val))._002Ector();
		val.Velocity = 1f;
		val.Direction = -1;
		NPCBestiaryDrawModifiers drawModifiers = val;
		Sets.NPCBestiaryDrawOffset.Add(((ModNPC)this).Type, drawModifiers);
		NPCHappiness val2 = ((ModNPC)this).NPC.Happiness;
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(633, (AffectionLevel)100);
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(18, (AffectionLevel)50);
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(22, (AffectionLevel)50);
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(353, (AffectionLevel)(-50));
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(663, (AffectionLevel)(-50));
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(369, (AffectionLevel)(-100));
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(441, (AffectionLevel)(-100));
		val2 = ((NPCHappiness)(ref val2)).SetNPCAffection(20, (AffectionLevel)(-100));
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<OceanBiome>((AffectionLevel)100);
		val2 = ((NPCHappiness)(ref val2)).SetBiomeAffection<DesertBiome>((AffectionLevel)50);
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
			(IBestiaryInfoElement)Biomes.Ocean,
			(IBestiaryInfoElement)new FlavorTextBestiaryInfoElement("Mods.V2.Bestiary.TownNPCs.Succubus")
		});
	}

	public override void SetDefaults()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		((ModNPC)this).NPC.townNPC = true;
		((ModNPC)this).NPC.friendly = true;
		((Entity)((ModNPC)this).NPC).width = 18;
		((Entity)((ModNPC)this).NPC).height = 40;
		((ModNPC)this).NPC.aiStyle = 7;
		((ModNPC)this).NPC.lifeMax = 700;
		((ModNPC)this).NPC.damage = 35;
		((ModNPC)this).NPC.defense = 22;
		((ModNPC)this).NPC.knockBackResist = 0.5f;
		((ModNPC)this).NPC.HitSound = SoundID.NPCHit1;
		((ModNPC)this).AnimationType = 20;
		((ModNPC)this).NPC.AsV2NPC().GetNewDialogue = GetSuccubusChat;
		((ModNPC)this).NPC.AsFood().DefinedBaseSize = 1.15;
		((ModNPC)this).NPC.AsPred().WeightGainRatio = 0.125;
		((ModNPC)this).NPC.AsPred().MaxStomachCapacity = 2.2;
		((ModNPC)this).NPC.AsPred().BaseStomachacheMeterCapacity = 155.0;
		((ModNPC)this).NPC.AsPred().SmallGulps = Gulps.Short;
		((ModNPC)this).NPC.AsPred().SmallGulpThreshold = 0.45;
		((ModNPC)this).NPC.AsPred().BigGulps = Gulps.Standard;
		((ModNPC)this).NPC.AsPred().CanBeForceFed = CanSuccubusBeForceFed;
		((ModNPC)this).NPC.AsPred().OnForceFed = OnSuccubusForceFed;
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
		((ModNPC)this).NPC.buffImmune[24] = true;
		((ModNPC)this).NPC.buffImmune[323] = true;
		((ModNPC)this).NPC.buffImmune[67] = true;
		((ModNPC)this).NPC.buffImmune[153] = true;
		((ModNPC)this).NPC.lavaImmune = true;
	}

	public override void ModifyTypeName(ref string typeName)
	{
		typeName = "Succubus";
	}

	public override bool CanTownNPCSpawn(int numTownNPCs)
	{
		return ModContent.GetInstance<V2MasterSystem>().freedSucc;
	}

	public override ITownNPCProfile TownNPCProfile()
	{
		return (ITownNPCProfile)(object)SuccubusStuff.SuccubusProfile;
	}

	public static List<string> GetSuccubusChat(NPC npc, Player player)
	{
		LucindaHelpButton.HelpIndex = 0;
		npc.GetNearbyResidentNPCs(out var _, out var _).FirstOrDefault((NPC x) => x.type == 353);
		List<string> succubusChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		bool playerWasAlreadyDigested;
		bool playerIsFood = player.IsFoodFor((Entity)(object)npc, out playerWasAlreadyDigested);
		npc.IsFoodFor((Entity)(object)player);
		if (playerIsFood && !playerWasAlreadyDigested)
		{
			if (Main.bloodMoon)
			{
				succubusChatPool.AddRange(new List<string> { "I warned you not to get in my way, didn't I? Now quiet down like the helpless gut fodder you are." });
			}
			else
			{
				succubusChatPool.AddRange(new List<string> { "Finally got you right where I want you: ready to plump up my demonic derrière even more.", "Getting cozy in there? I know I'm loving having you in there; hope you don't mind being demon fat.", "I wonder how much you'll bulk up my breasts...maybe they'll finally burst this old shirt. I know a few people who'd love that.", "I can't wait to see how much better my thighs look with a few dozen pounds of you draped over them, gutmeat.", "Comfy in there, lunch? I'd hope so...'cause the only place you're goin' from where you are right now is right downstairs to my ass and my thighs. Maybe a little for the rack, too..." });
			}
		}
		else if (Main.bloodMoon)
		{
			succubusChatPool.AddRange(new List<string> { "Get outta my face, before I stuff you right into it. I'm REALLY hangry right now.", "These blood moons always get me so FUCKIN' MAD...leave me alone, or I'll digest you!", "Just- could you just...agh, get in my belly or get lost!", "I need to scream! After that, I'm gonna eat anything in my sight, you included!", "Whaddaya want, gut-meat-to-be? Can't you see I'm pissed!?", "I'm in the worst mood possible tonight, meat. Stay outta my way, or you won't stay outta my stomach!" });
			if (PredNPC.GetStomachTracker(npc) != null)
			{
				succubusChatPool.AddRange(new List<string> { "You think I'm full? You and those CHUMPS back home don't know SHIT about bein' full! Get me more or get in my gut, meatsack!", "Me? Content? I'll have eaten the rest of the WORLD before I'm satisfied, startin' with you if you don't scram!" });
				if (playerIsFood && playerWasAlreadyDigested)
				{
					succubusChatPool.AddRange(new List<string> { "How are you already-...y'know what, WHATEVER! Just get in my gut already!...again!" });
				}
			}
		}
		else if (PredNPC.GetStomachTracker(npc) != null)
		{
			switch (GetVisualBellySize(npc))
			{
			default:
				succubusChatPool.AddRange(new List<string> { "I can't figure out if my gut is or isn't empty. How about you give me a little help solvin' that problem?", "The worst kind of food is the kind that doesn't bloat up your gut. Howzabout you be a better brunch than whatever's currently in or out of mine?" });
				break;
			case 1:
				succubusChatPool.AddRange(new List<string> { "Hey. Don't mind the- [c/00BB00:*urp!*] -rumbles from my waist. Just ate a little appetizer.", "Hm? Oh, this? Well, a day's always better with a good snack! Now, why don't you help turn that into a decent meal?", "Oh, this? Just had a light snack, that's all. Think you'll wanna add to that?", "Hey. Just had a- [c/00FF00:*hic!*] -little treat for myself. Don't mind me." });
				break;
			case 2:
				succubusChatPool.AddRange(new List<string> { "[c/00BB00:*belch!*]\nAhhh, that's the good stuff. Nothing like a bloated little belly to make a better day. Definitely want some more, though.", "Just finished up a good appetizer here. Could go for a lot more, though...you offerin'?", "Huh? Oh, this. Just a nice little- [c/00BB00:*burp!*] -snack to tide me over until lunch. Don't worry about it, lunch.", "Finally got the starts of a good meal goin' here. Mind if I make it a little better with you as the next course?", "Hey there, f-[c/00BB00:*oourp.*]- ...food. Care to help me fix up my post-snack munchies a little better?" });
				break;
			case 3:
				succubusChatPool.AddRange(new List<string> { "[c/00BB00:*BWORP!*]\nTHERE we go...that's some good eats right in there, though I'll go for a little more, I think. Got any recommendations, such as yourself?", "Nice day, yeah? Even better now that I've got a good-sized meal in my gut. Then again...could always use a second course.", "Huh? Yeah, I could go for more. I've still got a TON of room in this gut for morsels like you, just you wait!" });
				break;
			case 4:
				succubusChatPool.AddRange(new List<string> { "[c/00BB00:*BWOOOURRP!*]\nNow THAT's a good meal. Almost makes me not wanna eatcha...almost. You free to be food?", "Huh? Yeah, I could go for more! Just...takin' a minute before I do. Don't wanna eat too fast and get hiccups.", "You know, if you're lookin' for a way to do this sorta thing yourself, the dragonfruit vine tells me there's a heavenly little treat that frequents our planet who'd just LOVE to cram herself down your throat...unless you'd rather I get to her first.", "What's the matter, hotshot? Jealous of my big, food-filled belly? You should be, because I'm just- [c/00FF00:*hic!*] -...er...j- just gettin' started." });
				break;
			}
		}
		else
		{
			succubusChatPool.AddRange(new List<string> { "Hey. Looking to spend some time on the waistline of an incredible pred like me?", "Huh? Am I hungry? I'm ALWAYS hungry, morsel. Hungry for SNACKS like you! YEAH!", "Not lookin' to head back home, at least for the moment, so maybe keep some good food around, yeah?", "Got any rowdy townsfolk you need taken care of? I'll be sure to put 'em to REAL good- ...what do you mean, you don't?", "Yeah, I'm an apex pred. I eat chumps like YOU for breakfast, lunch, AND dinner, EVERY DAY. Got a problem with that?" });
			if (Main.dayTime)
			{
				succubusChatPool.AddRange(new List<string> { "All those slimes goin' around are...honestly, exceptionally mediocre prey. I prefer my meals with some MEAT to them, if you know what I mean.", "Every so often, a small, pink slime'll show up in the forests. Might wanna munch on it when you see it...I hear it tastes REALLY good.", "Tried to grill a slime earlier...the damn thing just burned right up, right in front of me! So much for grilled gel...those things wouldn't last 5 seconds back home." });
				if (Main.IsItAHappyWindyDay)
				{
					succubusChatPool.AddRange(new List<string> { "Damn, just take a look at this wind! Bet you could calm some rowdy prey down REAL quick with gusts like this knockin' 'em around in ya!", "These sorts of days are always great. Plenty of opportunities for some good prey to blow right on into my mouth." });
				}
			}
			else
			{
				succubusChatPool.AddRange(new List<string> { "Those zombies that always shamble around at these hours are really annoyin'. They're not even good food...you'll just get food poisonin' if you try.", "I feel like those eyes flyin' around all the time at night could really be good for my eyesight. Maybe yours, too, if you're hungry enough.", "Might go out and gulp down a few dozen of those little fairies I sometimes see when the moon's at its peak. Hear they're real good at gettin' preds into their prime." });
			}
			if (Main.IsItRaining)
			{
				succubusChatPool.AddRange(new List<string> { "...well, this sure never happened back home. I'm not gonna, like...melt into a puddle or anything else dumb if I touch the rain, right?", "The sounds this rain makes against the roof...they kinda remind me of fingers, happily drummin' on a calm, full gut. It's...weirdly relaxin'. Could listen to it for a while." });
			}
			if (Main.IsItStorming)
			{
				succubusChatPool.AddRange(new List<string> { "HAH! LOOK at all that lightning! HEAR all that thunder! That's the heavens above, SCARED of me and my gut! I'll eat every last angel up there one day, y'hear!?", "One of these days, I'M gonna eat one of those HUGE stormclouds, and I'm gonna melt it RIGHT down into fat for my breasts and my backside, to show that I'm the BEST pred there is. Just you wait, morsel." });
			}
		}
		return succubusChatPool;
	}

	public override void AddShops()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		NPCShop val = new NPCShop(((ModNPC)this).NPC.type, "Shop");
		val.Add<CharmBetterDigestion>(Array.Empty<Condition>());
		val.Add<CharmRegenFromAbsorption>(Array.Empty<Condition>());
		val.Add<ThrowableHotSauceBottle>(Array.Empty<Condition>());
		((AbstractNPCShop)val).Register();
		NPCShop nurseShop = new NPCShop(18, "Shop");
		nurseShop.Add(28, (Condition[])(object)new Condition[1] { Condition.NotDownedEowOrBoc });
		nurseShop.Add(188, (Condition[])(object)new Condition[2]
		{
			Condition.DownedEowOrBoc,
			Condition.NotDownedMechBossAny
		});
		nurseShop.Add(499, (Condition[])(object)new Condition[2]
		{
			Condition.DownedMechBossAny,
			Condition.NotDownedMoonLord
		});
		nurseShop.Add(3544, (Condition[])(object)new Condition[1] { Condition.DownedMoonLord });
		nurseShop.Add(885, Array.Empty<Condition>());
		nurseShop.Add<FastDigestionPotion>(Array.Empty<Condition>());
		nurseShop.Add<StomachacheMeterCapacityPotion>((Condition[])(object)new Condition[1] { Condition.DownedEowOrBoc });
		nurseShop.Add(new Item(29, 1, 0)
		{
			shopCustomPrice = Item.buyPrice(0, 20, 0, 0)
		}, (Condition[])(object)new Condition[1] { Condition.DownedSkeletron });
		nurseShop.Add<PureSwallowBoost1>(Array.Empty<Condition>());
		((AbstractNPCShop)nurseShop).Register();
	}

	public override void PostAI()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)((ModNPC)this).NPC).CurrentCaptor() != null || Main.GameUpdateCount % 60 != 0)
		{
			return;
		}
		int npcsWithinHouse;
		int npcsWithinVillage;
		List<NPC> nearbyResidentNPCs = ((ModNPC)this).NPC.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage);
		NPC guide = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 22);
		bool shouldSnackOnGuide = false;
		RollForRandomGulp(ref shouldSnackOnGuide);
		RollForRandomGulp(ref shouldSnackOnGuide);
		if (guide != null && ((Entity)guide).Distance(((Entity)((ModNPC)this).NPC).Center) <= ((ModNPC)this).NPC.AsPred().MaxSwallowRange && shouldSnackOnGuide)
		{
			PredNPC.Swallow(((ModNPC)this).NPC, (Entity)(object)guide);
		}
		NPC foxBimbo = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 633);
		bool shouldSnackOnFoxBimbo = false;
		RollForRandomGulp(ref shouldSnackOnFoxBimbo);
		RollForRandomGulp(ref shouldSnackOnFoxBimbo);
		if (foxBimbo != null && ((Entity)foxBimbo).Distance(((Entity)((ModNPC)this).NPC).Center) <= ((ModNPC)this).NPC.AsPred().MaxSwallowRange && shouldSnackOnFoxBimbo)
		{
			PredNPC.Swallow(((ModNPC)this).NPC, (Entity)(object)foxBimbo);
		}
		NPC nurse = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 18);
		bool shouldSnackOnNurse = false;
		RollForRandomGulp(ref shouldSnackOnNurse);
		RollForRandomGulp(ref shouldSnackOnNurse);
		if (nurse != null && ((Entity)nurse).Distance(((Entity)((ModNPC)this).NPC).Center) <= ((ModNPC)this).NPC.AsPred().MaxSwallowRange && shouldSnackOnNurse)
		{
			PredNPC.Swallow(((ModNPC)this).NPC, (Entity)(object)nurse);
		}
		NPC salad = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 20);
		bool shouldSnackOnSalad = false;
		RollForRandomGulp(ref shouldSnackOnSalad);
		RollForRandomGulp(ref shouldSnackOnSalad);
		RollForRandomGulp(ref shouldSnackOnSalad);
		if (salad != null && ((Entity)salad).Distance(((Entity)((ModNPC)this).NPC).Center) <= ((ModNPC)this).NPC.AsPred().MaxSwallowRange && shouldSnackOnSalad)
		{
			PredNPC.Swallow(((ModNPC)this).NPC, (Entity)(object)salad);
		}
		NPC scrooge = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 441);
		bool shouldSnackOnScrooge = false;
		RollForRandomGulp(ref shouldSnackOnScrooge);
		RollForRandomGulp(ref shouldSnackOnScrooge);
		RollForRandomGulp(ref shouldSnackOnScrooge);
		if (scrooge != null && ((Entity)scrooge).Distance(((Entity)((ModNPC)this).NPC).Center) <= ((ModNPC)this).NPC.AsPred().MaxSwallowRange && shouldSnackOnScrooge)
		{
			PredNPC.Swallow(((ModNPC)this).NPC, (Entity)(object)scrooge);
		}
		if (ModContent.GetInstance<V2ServerConfig>().RandomGulpsAgainstPlayers && ((Entity)Main.CurrentPlayer).active && !Main.CurrentPlayer.dead && !(((Entity)Main.CurrentPlayer).Distance(((Entity)((ModNPC)this).NPC).Center) > ((ModNPC)this).NPC.AsPred().MaxSwallowRange) && ((Entity)(object)Main.CurrentPlayer).CurrentCaptor() == null)
		{
			bool shouldSnackOnPlayer = false;
			RollForRandomGulp(ref shouldSnackOnPlayer);
			if (shouldSnackOnPlayer)
			{
				PredNPC.SwallowWithTextIfApplicable(((ModNPC)this).NPC, Main.CurrentPlayer, "[c/7F7F7F:<Suddenly, with a sly glint in her eyes, " + ((ModNPC)this).NPC.GivenName + " starts stuffing you down her throat. By the time you can process what's happened, she's already packed you away in her gut>]\nAhhh...always feels good to catch my prey unaware. Better get comfy in there, meat, 'cause you're on a one-way trip STRAIGHT to my waistline.");
			}
		}
		static void RollForRandomGulp(ref bool gulp)
		{
			gulp |= Utils.NextBool(Main.rand, 8, 100);
		}
	}

	public static bool CanSuccubusBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnSuccubusForceFed(NPC npc, Player player)
	{
		PredNPC.SwallowWithTextIfApplicable(npc, player, "[c/7F7F7F:<Catching you as you start to cram yourself down her throat, " + npc.GivenName + " guides you to your destination: one very eager demon tum, belonging to one very eager demon.>]\n" + Utils.NextFromCollection<string>(Main.rand, new List<string> { "Ahhh...that's the good stuff. Always love a meal that knows where they belong: meltin' in my gut.", "There. That gets you all tucked away, gutmeat. Now, don't you start tryin' to get out...but, by all means, thrash around as much as you like.", "You know, I'm not usually given willing prey on a platter, so to speak...but you really just look too tasty to say no to." }));
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Succubus.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Succubus.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Succubus.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Succubus.4", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Succubus.5" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Succubus.Hardcore");
		}
	}

	public override bool CanGoToStatue(bool toKingStatue)
	{
		return !toKingStatue;
	}

	public override void TownNPCAttackStrength(ref int damage, ref float knockback)
	{
		damage = 20;
		knockback = 4f;
	}

	public override void TownNPCAttackMagic(ref float auraLightMultiplier)
	{
		auraLightMultiplier = 1f;
	}

	public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
	{
		projType = 45;
		attackDelay = 40;
	}

	public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
	{
		multiplier = 12f;
		randomOffset = 0f;
	}

	public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
	{
		itemWidth = 40;
		itemHeight = 40;
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		if (!Main.bloodMoon)
		{
			return 1.8;
		}
		return 3.6;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 20.0;
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
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 4);
	}

	public override void FindFrame(int frameHeight)
	{
		((ModNPC)this).NPC.frame.Width = 96;
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
