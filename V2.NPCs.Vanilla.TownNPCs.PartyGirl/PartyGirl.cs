using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using V2.Core;
using V2.Items.Voraria.Accessories.Vanity;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.TownNPCs.PartyGirl;

public class PartyGirl : GlobalNPC
{
	public int SpecialGutFrameCounter;

	public int SpecialGutFrame;

	public int SpecialGutFrames;

	public override bool InstancePerEntity => true;

	public static List<string> GetPartyGirlChat(NPC npc, Player player)
	{
		int npcsWithinHouse;
		int npcsWithinVillage;
		List<NPC> nearbyResidentNPCs = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage);
		nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == ModContent.NPCType<Lucinda>());
		nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 353);
		List<string> partyGirlChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		if (player.IsFoodFor((Entity)(object)npc, out var playerWasAlreadyDigested) && !playerWasAlreadyDigested)
		{
			partyGirlChatPool.AddRange(new List<string>
			{
				"Mmmf, you filled me up so well, " + player.name + "! I feel like a big ol' water balloon...and I'm ready to party the night away!",
				"Hmmm...  [c/00BB00:*urp!*]\nY'know, you made a really nice " + (BirthdayParty.PartyIsUp ? "mid-party" : "pre-party") + " meal! Even tastier than all those cakes I eat...",
				"Yeesh, you really filled me up like a birthday balloon...better hope I don't pop, hehee!\n...aww, don't get upset. I'm just jokin'! It'll take a lot more than one snack to pop open THIS piñata!"
			});
			if (false)
			{
				partyGirlChatPool.AddRange(new List<string> { "Ooo, I feel like a freshly-filled piñata...filled to the brim with food! You don't even hafta worry about bein' digested! Just gotta wait 'til somebody comes to getcha out!", "Don'tcha worry about the juices in there. As long as I'm not hungry enough to gurgle ya, you can stay in there rent-free! Consider it a belly party JUST for you!", "So, you feelin' excited in there? Want me to gulp down some party favors to help ya get in the party mood? Gotta have you pumped up for my next party, after all, whether you're in me or not!" });
			}
			else
			{
				partyGirlChatPool.AddRange(new List<string> { "Ooo, I feel like a freshly-filled piñata...filled to the brim with food! Of course, my belly can digest much more than a piñata can...", "Yeah, that's right, party it up in there! Don't worry about the cleanup afterwards, either! My belly always makes sure none of the leftovers go to waste...", "Oof, you're really havin' fun in there, aren'tcha? Thanks again for the gift; you made a great appetizer! Of course, the party cake'll be the main course..." });
			}
		}
		else if (PredNPC.GetStomachTracker(npc) != null)
		{
			PreyData sprinkles = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
			if (sprinkles != null && GetEmpressDigestionStage(npc) > 0)
			{
				partyGirlChatPool.AddRange(new List<string>
				{
					"Huh? What happened to the candy fairy's crown? I'm savin' it for later! Duh! After all, I don't really have room for dessert with all this dinner in me...ah, just kiddin'! I'm just enjoyin' the candy fairy right now.",
					"Hey, you know what'd go REALLY well with this massive mountain of sprinkles? Some ice cream. Shouldn't have sprinkles without some ice cream to put 'em on, after all!",
					"[c/7F7F7F:<" + npc.GivenName + " gleefully and absentmindedly hums, her feet kicking behind her, as her gut continues to melt the Empress. She seems to be in a state of bliss.>]",
					"You know, while I'm stuck here, meltin' down this gutful of sprinkles, I wanted to ask you something.\nDo you ever wonder if people, out there somewhere, would wanna be in the spot that this so-called \"Empress\" is in right now?\n\nI don't, because I already know they'd love it! I'm the best belly party hostess around, after all!"
				});
				if (!sprinkles.NoHealth)
				{
					partyGirlChatPool.AddRange(new List<string>
					{
						"Mmmmm~mmm! That fairy was- [c/00BB00:OURP!*] -JUST what I needed! Thanks for the meal, " + player.name + "!",
						"Y'know, I never knew sprinkles could be so fat...then again-\n[c/7F7F7F:<As if on cue, an enraged screech can be heard from within " + ((npc.GivenName.Last().ToString() == "s") ? (npc.GivenName + "'") : (npc.GivenName + "'s")) + " gut.>]\nAw, COME ON! You know those thunder thighs of yours were too juicy and jiggly to NOT chow down on! Ugh...I swear, some candy is just so RUDE...anyway, what were you sayin'?",
						"Eep! Easy there...! Sorry, " + player.name + ", that candy fairy's REALLY not in the mood to be food...but I WON'T- [c/00FF00:*hic-][c/00BB00:OURP!*] -GIVE UP! She's MY candy, and ONLY mine!"
					});
				}
				else
				{
					switch (GetEmpressDigestionStage(npc))
					{
					case 1:
						partyGirlChatPool.AddRange(new List<string>
						{
							"Ahh...feels great to finally have that candy fairy all calmed down! Proooobably gonna take me a while to digest her, but hey! I got what I wanted! :D",
							"I've gotta hand it to ya, " + player.name + ": you REALLY know how to make a gal the life of the party! Nobody'll EVER keep outta the celebration ever again while I've got a gut like this!",
							"[c/00BB00:BWWOOOOOUUUUURRRRRP!*]\n...what? You KNOW you're supposed to say \"bless you!\" when somebody lets a good burp rip like that, right? It's a sign they liked their meal, and I sure loved mine!"
						});
						break;
					case 2:
					case 3:
						partyGirlChatPool.AddRange(new List<string> { "Hmmhmm...oh, hey! Still just workin' hard on that big ol' bag of sprinkles...finally got her to start softenin' up. Guess she's settlin' in fine after all!", "Mmmm...I always love candy like this. What good is candy if it's NOT the size of your livin' room?" });
						break;
					case 4:
					case 5:
						partyGirlChatPool.AddRange(new List<string> { "Seems that candy fairy's finally startin' to REALLY digest...can't wait for her to make my belly all big and soft!", "Hey, can you pass me some soda? I think there's still something or other from that sprinkle cake that's not sittin' all that well...a quick burp or two oughta get it loose." });
						break;
					}
				}
			}
			else
			{
				switch (GetVisualBellySize(npc))
				{
				default:
					partyGirlChatPool.AddRange(new List<string> { "H- hey, don't poke my tum! I don't wanna let out all the burpiness before the burpin' contest I'm havin' with myself later!", "What? Think I'm gonna get all antsy over some good food? Nah...I just really like to eat!" });
					break;
				case 1:
					partyGirlChatPool.AddRange(new List<string> { "Huh? My belly? Aw, I'm just havin' a pre-party snack! Can't set up a party on an empty belly, now, can ya?", "Yeah...there are a few cupcakes or so in there, I think. Can't really remember...but hey, it keeps the tum-tum quiet!" });
					goto default;
				case 2:
					partyGirlChatPool.AddRange(new List<string> { "Yeah, just had some good treats to tide me over 'til the next party. Shouldn't be too hard to make this last!", "This? Ah, this is nothin'! Catch me the next time I gulp down a bunch of party favors, THEN I'll show ya a good gut!" });
					break;
				case 3:
					partyGirlChatPool.AddRange(new List<string>
					{
						"Hey! Just workin' on a nice buncha treats for myself! You can rub it, if you want! Just don't get me all burpy for no reason. Always hate that.",
						"[c/7F7F7F:<" + npc.GivenName + " gleefully swings from side to side, watching her bloated belly rock back and forth. She seems to be having fun.>]\n\n...o- oh! Hey! Whatcha up to?"
					});
					break;
				case 4:
					partyGirlChatPool.AddRange(new List<string> { "W- wow, I REALLY ate a lot...NAH, just kiddin'! This is just a TASTE of what I can pack away!", "Impressed that I can eat this much without breakin' a sweat? Most people are! Then again, they've got NO idea what I'm REALLY capable of, hehee!" });
					break;
				case 5:
					partyGirlChatPool.AddRange(new List<string> { "Mmm...now THAT's a good snack. Plenty of food to fill out the tum-tum and keep 'er quiet while I figure out what the next big thing on my pre-party prep list is.", "Hey, pass the soda, will you? Need something to chase all this down, and get ready for the contest I'm havin' with myself later..." });
					break;
				}
				PreyData scroogeAsPrey = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 441 && !x.NoHealth);
				if (scroogeAsPrey != null)
				{
					Entity instance = scroogeAsPrey.Instance;
					NPC scrooge = (NPC)(object)((instance is NPC) ? instance : null);
					partyGirlChatPool.AddRange(new List<string>
					{
						"What? You know as well as I do he never liked my parties! It's only fair that I FORCE him to be part of 'em, by bein' part of me! I do NOT throw \"frivolous\" or \"childish\" parties, and I'm PERFECTLY responsible! HMPH! >:(",
						"Huh? What ABOUT grumpy old " + scrooge.GivenName + "!? He hates parties, hates fun, hates colors, and hates me! He's WAY better off as my " + (BirthdayParty.PartyIsUp ? "mid-party" : "pre-party") + " lunch than he is skulking in the corner all the time!"
					});
				}
				PreyData harryWizardAsPrey = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 108 && !x.NoHealth);
				if (harryWizardAsPrey != null)
				{
					Entity instance2 = harryWizardAsPrey.Instance;
					NPC harryWizard = (NPC)(object)((instance2 is NPC) ? instance2 : null);
					partyGirlChatPool.AddRange(new List<string>
					{
						"Huh? Why'd I eat that wizard guy, " + harryWizard.GivenName + "? Well, it's honestly really simple. He makes really cool sparkly effects at my parties, so I figured I might be able to get those for myself sometime soon if he's in there long enough!",
						"Don't worry about the magic guy! He's havin' a grand old time in my belly, and I'll make sure he keeps havin' a good time!"
					});
				}
				PreyData furryAsPrey = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 633 && !x.NoHealth);
				if (furryAsPrey != null)
				{
					Entity instance3 = furryAsPrey.Instance;
					NPC furry = (NPC)(object)((instance3 is NPC) ? instance3 : null);
					partyGirlChatPool.AddRange(new List<string>
					{
						"Mmmm...y'know, " + furry.GivenName + " isn't just great at parties. She's also a great belly filler! Of course, she knows I don't mean anything bad by it...I was just in the mood for a snack, and she didn't mind!",
						"The foxgal in my gut once asked me if I've ever eaten any cute little things...\n\n...don't tell her I said this, but I've eaten a LOT of different animals before. I think the \"cute little things\" she's talking about fit into that, pretty extensively."
					});
				}
			}
		}
		else if (NPC.AnyNPCs(636))
		{
			partyGirlChatPool.AddRange(new List<string> { "...I NEED her...I REALLY NEED HER. Give me that big candy fairy, NOW.", "My belly's screaming out for that big bag of sprinkles, and I don't blame it. Gimme her.", "Just LOOK at that big fairy food cake, flying around outside me...I NEED it, yesterday.", "I have NEVER wanted sprinkles so badly in my life as I do that fairy that's basically MADE of 'em. Pass her here...please?" });
		}
		else
		{
			partyGirlChatPool.AddRange(new List<string> { "I can't decide what I like more: normal parties, afterparties, or belly parties. You got any input on that?", "I once went to this really cool kingdom. It had lots of cake, and not just the sweet kind, either. They partied REALLY good there; why aren't you like that?", "We hafta talk. It's...it's about parties. Moreso, it's about the fact that I haven't hosted a belly party in a while.", "I should set up an eatin' contest as a party. Would be a great way to get all the preds in town up and at 'em for some good snacks! Winner gets to eat ME, obviously!", "Yeah, I'm a bit of a master at plannin' parties. Just ask all the people that had one in my belly! None of 'em ever complained!" });
			if (Main.IsItRaining)
			{
				partyGirlChatPool.AddRange(new List<string> { "I panicked 'cause I thought there was a crash of thunder at the disco for a sec!...and then I realized it was just the ol' tum-tum.", "Come on, let's dance! We'll eat our fill, and shake our full bellies to the beat of the sky!", "Sometimes, I just wanna go gulp down a lightning bolt. Always gives me a bunch more energy, and you GOTTA have a bunch of energy to host a party!" });
			}
			if (Main.IsItStorming)
			{
				partyGirlChatPool.AddRange(new List<string> { "I panicked 'cause I thought there was a crash of thunder at the disco for a sec!...and then, I realized it was just the ol' tum-tum.", "Come on, let's dance! We'll eat our fill, and shake our full bellies to the beat of the sky!", "Sometimes, I just wanna go gulp down a lightning bolt. Always gives me a bunch more energy, and you GOTTA have a bunch of energy to host a party!" });
			}
			if (Main.IsItAHappyWindyDay)
			{
				partyGirlChatPool.AddRange(new List<string> { "Wow, it's super windy today! I can blow my belly- [c/00BB00:*urp!*] -like a balloon with this much hot air going around!", "Oh, just LOOK at that- [c/00BB00:*belch!*] -breeze outside! This is the perfect day to go sip some good wind! It feels REAL nice goin' down- [c/00BB00:*burp!*] -and it feels nice in your gut, too...", "These kinds of days always get me really- [c/00BB00:bworp!*] -burpy...probably 'cause I keep gobblin' up all the strong gusts that blow my way, hehee! Not MY fault they wanna end up comin' back- [c/00BB00:*urp!*]" });
			}
			if (player.ZoneGraveyard)
			{
				partyGirlChatPool.AddRange(new List<string> { "Woo, let's-...hey, why's nobody movin'? There's a party just WAITIN' to be held here!", "Ever wanted to know how to party loud enough to LITERALLY wake the dead? Here, I'll teach ya!" });
			}
			if (DD2Event.DownedInvasionAnyDifficulty)
			{
				partyGirlChatPool.AddRange(new List<string> { "Have you seen an ogre yet? I wanna ride on the back of one!...maybe not in its gut, though. They don't seem all that fun to be in..." });
			}
			if (BirthdayParty.PartyIsUp)
			{
				if (NPC.freeCake)
				{
					partyGirlChatPool.AddRange(new List<string>
					{
						"Where've you been? There's a total party goin' on! Here, take a slice of cake! I'll letcha in on a little secret...I already ate the rest, and it's totally awesome!",
						"Shhh! Here! It's a piece of the cake that was made for today! Don't tell ANYONE I gave you it! It's a party surprise!...alongside the fact that I'm gonna gorge myself on the rest later.",
						"Party up! You're TOTALLY in charge of the cake, " + player.name + "! Just...if anyone asks, I did NOT eat half the sweets baked for today."
					});
				}
				else
				{
					partyGirlChatPool.AddRange(new List<string> { "MY TIME HAS COME!...and my belly's, too! What, you think I'm NOT gonna stuff myself silly with party food?", "Huh? Oh, nothing special today...HA, just kiddin'! It's party time, afterparty time, and belly party time, all at once! YEAH!" });
				}
			}
			if (player.AsPred().StomachTracker?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 441 && !x.NoHealth) != null)
			{
				partyGirlChatPool.AddRange(new List<string> { "FINALLY! Can't believe that guy went this long without gettin' ate. He was always rainin' on my party parade. Happy to see you've got him in the gut rave groove!", "...well? How was he? Hope you really give him a piece of your mind. That'll teach him to grump about at MY parties..." });
			}
		}
		return partyGirlChatPool;
	}

	public static bool CanPartyGirlBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnPartyGirlForceFed(NPC npc, Player player)
	{
		if (GetEmpressDigestionStage(npc) > 0)
		{
			PredNPC.SetChatboxText(npc, player, Utils.NextFromCollection<string>(Main.rand, new List<string> { "Huh? Well, that bag of sprinkles DID fill me up pretty good...but I can never say no to a little dessert!", "Do I want a second course? Well, not really a second course, but a quick post-dinner snack is fine! Come on in!", "You wanna join the fairy? Well, I guess I can squeeze you in! Just hold still and lemme get you settled in!" }) + "\n[c/7F7F7F:<Preparing herself briefly before reaching over her gut and picking you up, " + npc.GivenName + " nonchalantly tosses you down her suddenly-cavernous throat all at once, humming with glee as you end up joining the Empress inside her titanic tum.>]");
		}
		else
		{
			PredNPC.SetChatboxText(npc, player, Utils.NextFromCollection<string>(Main.rand, new List<string> { "You want me to eatcha?...eh, probably a good change of pace from all the balloons and party favors I eat. Come on in!", "You wanna be a cake for me? Aww...how can I say no to that? Get over here and get in my belly, hehee!", "A pre-party snack? Hmm...well, I guess we'll be the life of the party with you inside me! Besides, I can't host a party on an empty tum!" }) + "\n[c/7F7F7F:<Before you can even BEGIN to force yourself into her, " + npc.GivenName + " happily crams your entire body into her mouth at once, gulping down your form in full to fill out her gut in a single, smooth swallow. She happily pats her newly-filled gut with a hum of gratitude.>]");
		}
	}

	public static void PlayerPreyChat(NPC npc, Player player, ref List<string> chatPool)
	{
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.4", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.5", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.6" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.PartyGirl.Hardcore");
		}
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 208;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.lifeMax = 400;
		npc.AsV2NPC().NewAIMethod = V2PartyGirlAI;
		npc.AsV2NPC().GetNewDialogue = GetPartyGirlChat;
		npc.AsFood().DefinedBaseSize = 1.0;
		npc.AsPred().WeightGainRatio = 0.28;
		npc.AsPred().MaxStomachCapacity = 9999999.0;
		npc.AsPred().BaseStomachacheMeterCapacity = 9999999.0;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().CanSwallowBosses = true;
		npc.AsPred().CanBeForceFed = CanPartyGirlBeForceFed;
		npc.AsPred().OnForceFed = OnPartyGirlForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().OnDigestionKill = OnDigestionKill;
		npc.AsPred().MouthSoundRawOffset = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 8f, -14f);
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
	}

	public override ITownNPCProfile ModifyTownNPCProfile(NPC npc)
	{
		return (ITownNPCProfile)(object)PartyGirlStuff.PartyGirlPredProfile;
	}

	public static bool V2PartyGirlAI(NPC npc)
	{
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		VoreTracker tracker = PredNPC.GetStomachTracker(npc);
		if (tracker != null)
		{
			PreyData candyFairy = null;
			PreyData sprinkles = tracker.Prey.FirstOrDefault((PreyData preyData) => preyData.Type == PreyType.NPC && preyData.ExactType == 636);
			if (sprinkles != null && sprinkles.WeightLeftToDigest > 4.0)
			{
				candyFairy = sprinkles;
			}
			PreyData sprinklesQueue = tracker.PreyQueue.FirstOrDefault((PreyData preyData) => preyData.Type == PreyType.NPC && preyData.ExactType == 636);
			if (sprinklesQueue != null && sprinklesQueue.WeightLeftToDigest > 4.0)
			{
				candyFairy = sprinklesQueue;
			}
			if (tracker != null && candyFairy != null)
			{
				if (((Entity)npc).width == 18 && ((Entity)npc).height == 40)
				{
					((Entity)npc).width = 110;
					((Entity)npc).height = 64;
					((Entity)npc).position.X -= 48f;
					((Entity)npc).position.Y -= 18f;
				}
				((Entity)npc).velocity.X = 0f;
				npc.AsPartyGirl().SpecialGutFrames = 10;
				npc.AsPartyGirl().SpecialGutFrameCounter++;
				if (npc.AsPartyGirl().SpecialGutFrameCounter >= 9)
				{
					npc.AsPartyGirl().SpecialGutFrameCounter = 0;
					npc.AsPartyGirl().SpecialGutFrame++;
					npc.AsPartyGirl().SpecialGutFrame %= npc.AsPartyGirl().SpecialGutFrames;
				}
				if (!candyFairy.NoHealth)
				{
					for (int y = (int)Math.Round(((Entity)(object)npc).TrueCenter().Y) - 5; y < (int)Math.Round(((Entity)(object)npc).TrueCenter().Y); y++)
					{
						for (int x = (int)Math.Round(((Entity)(object)npc).TrueCenter().X) - 4; x < (int)Math.Round(((Entity)(object)npc).TrueCenter().X) + 4; x++)
						{
							WorldGen.KillTile(x, y, false, false, false);
						}
					}
				}
				return false;
			}
		}
		((Entity)npc).width = 18;
		((Entity)npc).height = 40;
		npc.AsPartyGirl().SpecialGutFrames = 0;
		npc.AsPartyGirl().SpecialGutFrame = 0;
		npc.AsPartyGirl().SpecialGutFrameCounter = 0;
		return true;
	}

	public override void ModifyShop(NPCShop shop)
	{
		if (((AbstractNPCShop)shop).NpcType == 208)
		{
			shop.Add(ModContent.ItemType<BalloonBelly>(), (Condition[])(object)new Condition[1] { V2ShopConditions.BeginnerStatPoints });
		}
	}

	public override void PostAI(NPC npc)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null || GetEmpressDigestionStage(npc) > 0 || Main.GameUpdateCount % 60 != 0)
		{
			return;
		}
		int npcsWithinHouse;
		int npcsWithinVillage;
		List<NPC> nearbyResidentNPCs = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage);
		NPC foxBimbo = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 633);
		bool shouldSnackOnFoxBimbo = false;
		RollForRandomGulp(ref shouldSnackOnFoxBimbo);
		if (foxBimbo != null && ((Entity)foxBimbo).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnFoxBimbo)
		{
			PredNPC.Swallow(npc, (Entity)(object)foxBimbo);
		}
		NPC nurse = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 18);
		bool shouldSnackOnNurse = false;
		RollForRandomGulp(ref shouldSnackOnNurse);
		RollForRandomGulp(ref shouldSnackOnNurse);
		RollForRandomGulp(ref shouldSnackOnNurse);
		if (nurse != null && ((Entity)nurse).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnNurse)
		{
			PredNPC.Swallow(npc, (Entity)(object)nurse);
		}
		bool haveRoutineCheckUpWithNurse = false;
		RollForRandomGulp(ref haveRoutineCheckUpWithNurse);
		if (nurse != null && ((Entity)nurse).Distance(((Entity)npc).Center) <= nurse.AsPred().MaxSwallowRange && haveRoutineCheckUpWithNurse)
		{
			PredNPC.Swallow(nurse, (Entity)(object)npc);
		}
		NPC bestGirl = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 353);
		bool spendQualityTimeInAmber = false;
		RollForRandomGulp(ref spendQualityTimeInAmber);
		RollForRandomGulp(ref spendQualityTimeInAmber);
		if (bestGirl != null && ((Entity)bestGirl).Distance(((Entity)npc).Center) <= bestGirl.AsPred().MaxSwallowRange && spendQualityTimeInAmber)
		{
			PredNPC.Swallow(bestGirl, (Entity)(object)npc);
		}
		NPC wizard = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 108);
		bool shouldSnackOnWizard = false;
		RollForRandomGulp(ref shouldSnackOnWizard);
		if (wizard != null && ((Entity)wizard).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnWizard)
		{
			PredNPC.Swallow(npc, (Entity)(object)wizard);
		}
		NPC scrooge = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 441);
		bool shouldSnackOnScrooge = false;
		RollForRandomGulp(ref shouldSnackOnScrooge);
		RollForRandomGulp(ref shouldSnackOnScrooge);
		RollForRandomGulp(ref shouldSnackOnScrooge);
		RollForRandomGulp(ref shouldSnackOnScrooge);
		RollForRandomGulp(ref shouldSnackOnScrooge);
		if (scrooge != null && ((Entity)scrooge).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnScrooge)
		{
			PredNPC.Swallow(npc, (Entity)(object)scrooge);
		}
		if (ModContent.GetInstance<V2ServerConfig>().RandomGulpsAgainstPlayers && ((Entity)Main.CurrentPlayer).active && !Main.CurrentPlayer.dead && !(((Entity)Main.CurrentPlayer).Distance(((Entity)npc).Center) > npc.AsPred().MaxSwallowRange) && ((Entity)(object)Main.CurrentPlayer).CurrentCaptor() == null)
		{
			bool shouldHostGutParty = false;
			RollForRandomGulp(ref shouldHostGutParty);
			if (shouldHostGutParty)
			{
				PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<Out of nowhere, " + npc.GivenName + " stuffs your entire body into her mouth, gulping you down in a single, smooth swallow. She giggles as your form rockets into her all-too-eager stomach.>]\nThere we go! Sorry if I scared ya a bit...I needed a little pre-party snack, and that cake did just the trick! Thanks for the treat! :D");
			}
		}
		static void RollForRandomGulp(ref bool gulp)
		{
			gulp |= Utils.NextBool(Main.rand, 4, 100);
		}
	}

	public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref HitModifiers modifiers)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		int type = projectile.type;
		if (((uint)(type - 871) <= 2u || type == 919 || (uint)(type - 923) <= 1u) ? true : false)
		{
			ref StatModifier finalDamage = ref modifiers.FinalDamage;
			finalDamage *= 0.25f;
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		double tickRate = 1.25;
		if (prey.Type == PreyType.NPC)
		{
			Entity instance = prey.Instance;
			if (((NPC)((instance is NPC) ? instance : null)).type == 636)
			{
				return 4.0;
			}
		}
		if (BirthdayParty.PartyIsUp)
		{
			tickRate *= 0.4;
		}
		bool flag = prey.Type == PreyType.NPC;
		if (flag)
		{
			Entity instance2 = prey.Instance;
			int type = ((NPC)((instance2 is NPC) ? instance2 : null)).type;
			bool flag2 = ((type == 108 || type == 633) ? true : false);
			flag = flag2;
		}
		if (flag)
		{
			tickRate *= 0.5;
		}
		if (prey.Type == PreyType.NPC)
		{
			Entity instance3 = prey.Instance;
			if (((NPC)((instance3 is NPC) ? instance3 : null)).type == 441)
			{
				tickRate *= 1.5;
			}
		}
		return tickRate;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		double digestionDamage = 15.0;
		if (prey.Type == PreyType.NPC)
		{
			Entity instance = prey.Instance;
			if (((NPC)((instance is NPC) ? instance : null)).type == 441)
			{
				digestionDamage += 10.0;
			}
		}
		if (prey.Type == PreyType.NPC)
		{
			Entity instance2 = prey.Instance;
			if (((NPC)((instance2 is NPC) ? instance2 : null)).type == 636)
			{
				digestionDamage += 85.0;
			}
		}
		return digestionDamage;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 1, 10);
	}

	public static int GetEmpressDigestionStage(NPC npc)
	{
		if (PredNPC.GetStomachTracker(npc) == null)
		{
			return 0;
		}
		PreyData candyFairy = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
		if (candyFairy == null || candyFairy.WeightLeftToDigest < 5.0)
		{
			return 0;
		}
		if (!candyFairy.NoHealth)
		{
			return 1;
		}
		if (candyFairy.WeightLeftToDigest > 37.0)
		{
			return 1;
		}
		if (candyFairy.WeightLeftToDigest > 34.0 && candyFairy.WeightLeftToDigest <= 37.0)
		{
			return 2;
		}
		if (candyFairy.WeightLeftToDigest > 31.5 && candyFairy.WeightLeftToDigest <= 34.0)
		{
			return 3;
		}
		if (candyFairy.WeightLeftToDigest > 29.0 && candyFairy.WeightLeftToDigest <= 31.5)
		{
			return 4;
		}
		if (candyFairy.WeightLeftToDigest > 4.0)
		{
			return 5;
		}
		return 0;
	}

	public static int GetVisualBellySize(NPC npc)
	{
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 5);
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		npc.frame.Width = 160;
	}

	public override void ModifyHoverBoundingBox(NPC npc, ref Rectangle boundingBox)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (GetEmpressDigestionStage(npc) > 0)
		{
			boundingBox = new Rectangle((int)((Entity)npc).Center.X - 55, (int)((Entity)npc).Center.Y - 32, 110, 66);
		}
		else
		{
			boundingBox = new Rectangle((int)((Entity)npc).Center.X - 18, (int)((Entity)npc).Center.Y - 27, 36, 54);
		}
	}

	public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return false;
		}
		if (GetEmpressDigestionStage(npc) > 0)
		{
			SpriteEffects val = ((((Entity)npc).direction != -1) ? ((SpriteEffects)1) : ((SpriteEffects)0));
			SpriteEffects spriteEffects = val;
			string weightString = "_WeightBase";
			string text = "V2/NPCs/Vanilla/TownNPCs/PartyGirl/PartyGirl" + weightString;
			npc.AsPred().GetVisualBellySize(npc);
			string bellyString = "_BossBelly_EmpressOfLight_DigestionStage" + GetEmpressDigestionStage(npc);
			Texture2D texture = ModContent.Request<Texture2D>(text + bellyString, (AssetRequestMode)1).Value;
			Rectangle sourceRect = default(Rectangle);
			((Rectangle)(ref sourceRect))._002Ector(0, npc.AsPartyGirl().SpecialGutFrame * 68, 110, 68);
			spriteBatch.Draw(texture, ((Entity)npc).Center - screenPos + new Vector2(0f, npc.gfxOffY), (Rectangle?)sourceRect, drawColor, npc.rotation, Utils.Size(sourceRect) / 2f, 1f, spriteEffects, 0f);
			return false;
		}
		return true;
	}
}
