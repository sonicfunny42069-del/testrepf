using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.IO;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.TownNPCs.Dryad;

public class Dryad : GlobalNPC
{
	public string SpecialGutAnim;

	public List<(int frame, int rawDelay)> SpecialGutAnimFrames;

	public int SpecialGutAnimFrameDictPos;

	public int SpecialGutAnimFrame;

	public int SpecialGutAnimFrameDelay;

	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 20;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Female;
		npc.lifeMax = 350;
		npc.AsV2NPC().NewAIMethod = V2DryadAI;
		npc.AsV2NPC().GetNewDialogue = GetDryadChat;
		npc.AsFood().DefinedBaseSize = 1.118;
		npc.AsPred().WeightGainRatio = 0.12;
		npc.AsPred().MaxStomachCapacity = 12.5;
		npc.AsPred().BaseStomachacheMeterCapacity = 450.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.35;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().CanBeForceFed = CanDryadBeForceFed;
		npc.AsPred().OnForceFed = OnDryadForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().OnDigestionKill = null;
		npc.AsPred().MouthSoundRawOffset = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 8f, -14f);
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 0.35;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
		PreyNPC preyNPC = npc.AsFood();
		int num = 2;
		List<ItemTheftRule> list = new List<ItemTheftRule>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<ItemTheftRule> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = DryadStuff.ItemTheftRules.ClothingTop;
		num2++;
		span[num2] = DryadStuff.ItemTheftRules.ClothingBottom;
		num2++;
		preyNPC.ItemTheftRules = list;
	}

	public override ITownNPCProfile ModifyTownNPCProfile(NPC npc)
	{
		return (ITownNPCProfile)(object)DryadStuff.DryadPredProfile;
	}

	public static bool V2DryadAI(NPC npc)
	{
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
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
					((Entity)npc).width = 86;
					((Entity)npc).height = 142;
					((Entity)npc).position.X -= 68f;
					((Entity)npc).position.Y -= 108f;
				}
				((Entity)npc).velocity.X = 0f;
				if (!candyFairy.NoHealth)
				{
					Entity instance = candyFairy.Instance;
					NPC realCandyFairy = (NPC)(object)((instance is NPC) ? instance : null);
					if (npc.AsV2NPC().CustomSprite == null)
					{
						npc.AsV2NPC().CustomSprite = ((realCandyFairy.life < realCandyFairy.lifeMax / 2) ? ((SpriteAnimation)new DryadStuff.Animations.AVEmpressOfLight.PhaseTransition()) : ((SpriteAnimation)new DryadStuff.Animations.AVEmpressOfLight.PhaseOne()));
					}
					else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.PhaseOne && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim && realCandyFairy.life < realCandyFairy.lifeMax / 2)
					{
						npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.PhaseTransition();
					}
					else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.PhaseTransition && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim)
					{
						npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.PhaseTwo();
					}
					for (int y = (int)Math.Round(((Entity)(object)npc).TrueCenter().Y) - 5; y < (int)Math.Round(((Entity)(object)npc).TrueCenter().Y); y++)
					{
						for (int x = (int)Math.Round(((Entity)(object)npc).TrueCenter().X) - 4; x < (int)Math.Round(((Entity)(object)npc).TrueCenter().X) + 4; x++)
						{
							WorldGen.KillTile(x, y, false, false, false);
						}
					}
				}
				else if (npc.AsV2NPC().CustomSprite == null)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.PhaseTransition();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.PhaseTransition && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.PhaseTwo();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.PhaseTwo && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.EmpressGetsChurned();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.EmpressGetsChurned && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.DigestStage1();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.DigestStage1 && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(npc) >= 2)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.DigestStage2();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.DigestStage2 && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(npc) >= 3)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.DigestStage3();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.DigestStage3 && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(npc) >= 4)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.DigestStage4();
				}
				else if (npc.AsV2NPC().CustomSprite is DryadStuff.Animations.AVEmpressOfLight.DigestStage4 && npc.AsV2NPC().CustomSprite.CanTransitionToNewAnim && GetEmpressDigestionStage(npc) >= 5)
				{
					npc.AsV2NPC().CustomSprite = new DryadStuff.Animations.AVEmpressOfLight.DigestStage5();
				}
				return false;
			}
		}
		if (npc.AsV2NPC().CustomSprite != null)
		{
			npc.AsV2NPC().CustomSprite = null;
		}
		if (((Entity)npc).width != 18)
		{
			((Entity)npc).width = 18;
		}
		if (((Entity)npc).height != 40)
		{
			((Entity)npc).height = 40;
		}
		return true;
	}

	public static List<string> GetDryadChat(NPC npc, Player player)
	{
		npc.GetNearbyResidentNPCs(out var _, out var _).FirstOrDefault((NPC x) => x.type == ModContent.NPCType<Lucinda>());
		List<string> dryadChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		if (player.IsFoodFor((Entity)(object)npc, out var playerWasAlreadyDigested) && !playerWasAlreadyDigested)
		{
			bool noDigest = false;
			if (Main.bloodMoon)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "A [c/FF0000:pitiful] fate, albeit [c/FF0000:the only suitable one,] for a whelp like you. You should be thankful you're melting inside a [c/FF0000:greater being] such as I.", "My body will cleanse you down to your very soul and leave only that soul when it is done. [c/FF0000:Be grateful I dare not digest that soul as well.]" }));
				if (PredNPC.GetStomachTracker(npc).Prey.Count > 1)
				{
					dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Do not think for but a moment I am too full to reduce you to naught but a [c/FF0000:purified, nutritional sludge.]", "The meal currently digesting within me was simply too weak to challenge me, and thought they were not. If you want to come out of this night as anything more than [c/FF0000:padding for my rear end], do not make the same mistake." }));
				}
			}
			else
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Do not move too strongly within my stomach. The less you do, the more easily I am able to keep you locked away in there.", "As an envoy to nature, allow me to express that nature and I, alike, find you quite satisfying as food." }));
				if (noDigest)
				{
					dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Yes...relax yourself. Allow your body to remain safe within my innermost sanctum of purity: my all-cleansing stomach.", "My insides tell me you are still alive and well. This is good. I do not wish to digest you...at the moment, at least." }));
				}
				else
				{
					dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[8]
					{
						"Mmm...now THIS is the kind of meal I need to have more often if I'm to properly rid the world of the evils that continue to blight it.",
						"Yes, my prey. Allow yourself to be cleansed by my body...and promptly added to it.",
						"That's it, melt...let my acids burn away the vile darkness within you, and append your form to my own.",
						"What a wonderful little meal...I can feel your every cell being purified by the second. Truly, the most efficient way of purging the unclean.",
						"I really must do this more frequently...I could use more variety in my diet. The foul creatures of the " + (WorldGen.crimson ? "Crimson" : "Corruption") + " never taste very good, and they aren't very nutritious at all, either...",
						"Yes, that's it. Let your soul be rid of impurity, and your body transformed into more padding for a more suitable savior of this world.",
						"What was that about me being called a salad? I sure hope you're not too upset about being melted into MORE of this salad...",
						"You may not be aging very gracefully, but you certainly taste like a fine wine. Delectable."
					}));
					if (Main.LocalPlayer.ZoneSnow)
					{
						dryadChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("It feels lovely to be able to combat the snowy chill of this region by digesting a heavy, thrashing meal like you into nutrients to better fasten my roots and insulate my stem."));
					}
				}
				if (Main.LocalPlayer.ZoneSnow)
				{
					dryadChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("There is nothing quite like a pleasantly heavy stomach and some nice cocoa to help hibernate through the winter months."));
				}
			}
		}
		else if (Main.bloodMoon)
		{
			dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[5] { "What could someone as insignificant as you POSSIBLY want from me? I am currently busy trying to fend off the adversities of tonight.", "Why must you pull me away from my thoughts on a night such as tonight?", "Continue to bother me, and you will be purified. I have given you fair warning.", "This fury consumes my very soul...how am I supposed to save our world in a frenzied state such as this!?", "The great mother of nature has had her ire drawn to this world this night. Do not dare to anger her further, or you shall contend with me." }));
			if (Main.IsItStorming)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Our mother casts doom upon [c/FF0000:whelps such as thee] tonight. Should you value your life, I would not recommend going outside at all. Perhaps a purpose [c/FF0000:better served by filling my stomach.]", "The crack of the roaring skies sends many a beast whimpering into their dens, yet draws out the ire of even more. You would do well to hide away somewhere...[c/FF0000:or perhaps in someONE.]" }));
			}
			else if (Main.IsItRaining)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "Nature casts a [c/FF0000:bloodied sorrow] upon lesser beings this night, downtrodden at how [c/FF0000:frail] many of the creatures have become with time.", "[c/FF0000:Fish are not meant to fly,] and the wings of any fish that reasonably could should be dampened by the rain.\nWhy, then, do the mysterious sea creatures dancing about the skies care so little for the red-tinted torrent from above?" }));
			}
		}
		else
		{
			dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[4] { "You may believe that Terraria needs you. The truth could not be farther from whence this notion comes...but it can be pleasant to make yourself believe you are necessary.", "Some people say I am all bark and no bite. Needless to say, they very quickly learn that there is no bark lining my stomach.", "I really need to travel out and hunt more, I should think. Just as a flower cannot grow and bloom without sunlight, I cannot grow stronger without food.", "The sands of time, as they are to most humans, don't seem to have been particularly kind to you. Your aging is not as...graceful as it ought to be." }));
			if (Main.LocalPlayer.ZoneForest)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "The wildlife here is fairly diverse, though nothing to be ecstatic over...and much of it is quite calming. I believe I could learn to like staying here.", "Listening to birds chirp their morning songs and squabbles alike as the grass warms to the sun is an experience one does not get often in the jungles I so often prefer to stay in. It is a welcome shift of scenery." }));
			}
			if (Main.LocalPlayer.ZoneRockLayerHeight && !Main.LocalPlayer.ZoneJungle)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "I must admit, I do not entirely like being this far down, yet being able to see the roots of our world and the flora and fauna that reside within them is fascinating in a way that I...do not believe you would understand.", "I have witnessed many beings which, on a first glance, look similar to myself...yet, when their prey draws close enough, they will don their more...personal form and devour their target alive, without a second thought. Exercise caution if you wish to stay out of a nymph's digestive tracct." }));
			}
			if (Main.LocalPlayer.ZoneJungle)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "This is perhaps the greatest sort of region our planet has to offer. The diverse flora and close connection to nature itself give me a great amount of pleasant comfort.", "My fellow plants in this area are not without their appetites, and are only sparingly against devouring the first prey they see. An unfortunate reality for an adventurer such as you...", "Be wary of the great swathes of oceanic wildlife here. Many of them are just as ravenous as the plants themselves, and will have no trouble turning you from a mercenary into a meal." }));
				if (Main.LocalPlayer.ZoneRockLayerHeight)
				{
					dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Within these depths lie many creatures, floral or otherwise, who will not hesitate to swallow you like a light snack. Tread carefully if you value your continued existence.", "Many insect hives found this deep in the jungle's roots can be quite large, and home to equally large, territorial, and predatorial bees. Do not intrude upon these nests lightly.", "While I cannot stop you from getting eaten by the wildlife here, I feel the need to warn you of a great being within the depths of this jungle. With three minds in one body, they can rarely ever agree...save for one thing: that all this jungle's wildlife is but a feast for them." }));
				}
			}
			if (Main.LocalPlayer.ZoneDesert)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "The searing heat and sparse moisture in this region would singe many plants I am most familiar with, and rather few are allowed to flourish in their place. I...do not believe I am comfortable here.", "I must be careful not to spend too long in this scorchingly hot sunlight. Even a greater bloom such as myself could wilt if left in this heat for too long...and it is rather easy to do so.", "There are some who have found these sorts of regions hospitable, with many techniques for bodily coordination and strength originating from them...but I am afraid I cannot fathom the same." }));
			}
			if (Main.LocalPlayer.ZoneSnow)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "This region could freeze many of my fellow plants to the roots, yet...despite the colder temperatures, the abundant, if frozen, moisture allows a uniquely diverse set of flora to thrive here. Perhaps I could as well, with enough time...", "The icy chill here is best remedied with the warmth and comfort of a full stomach, digesting a heavy, thrashing meal into nutrients to better fasten your roots and insulate your stem." }));
				if (PredNPC.GetCurrentBellyWeight(npc) > 1.25)
				{
					dryadChatPool.AddRange(new _003C_003Ez__ReadOnlySingleElementList<string>("There is nothing quite like a pleasantly heavy stomach and some nice cocoa to help hibernate through the winter months."));
				}
			}
			if (Main.IsItAHappyWindyDay)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "The wind... it is nature's way of sweeping the dust from the land. The larger impurities, of course, require more...permanent solutions.", "Nature's fury strips the leaves from the trees this day, well into the waiting maws of plant-eaters. Be wary you do not meet a similar fate.", "On occasion, parts of some flowers may find themselves drifting through the air as a result of a day like this. These are almost always a show of good fortune, granted by the mother of nature herself." }));
			}
			if (Main.IsItStorming)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Some believe that a being known as the \"Grand Botanist\" has entered a fury in times like these. I more correctly believe it simply the fury of nature itself.", "It is unwise to traverse openly beneath the skies currently. The seething, flashing strikes from above will broil you in but an instant.", "Be wary you do not mistake the crack of the frenzied skies for the roar of a hungering beast. One is only a danger if the beast ensnares you; the other cares none." }));
			}
			else if (Main.IsItRaining)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2]
				{
					"Nature provides rains such as these to wash away the mud in the streams and grant much-needed rain to the plants unfortunate enough to not subsist on live prey.",
					"A mysterious sort of fish becomes prevalent on " + (Main.dayTime ? "days" : "nights") + " like these, flying through the rain with nary a care in the world."
				}));
			}
			if (Main.LocalPlayer.ZoneGraveyard)
			{
				dryadChatPool.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[2] { "The evils of this world are easily detained and digested, but this...the vile air of death in this location almost makes one feel like wilting.", "This place...nature cries at and for the fallen here, even with the knowledge that many of these gravestones are most likely for bodies which no longer exist as themselves." }));
			}
		}
		return dryadChatPool;
	}

	public static bool CanDryadBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnDryadForceFed(NPC npc, Player player)
	{
		PredNPC.SetChatboxText(npc, player, Utils.NextFromCollection<string>(Main.rand, new List<string> { "So, you're in need of purification? Very well, then. Allow me to cleanse your body with the strength of my own.", "Mm...well, I AM rather hungry, as us dryads always are, and it is difficult to purify this world on an empty stomach. You will fix both of these issues perfectly, I should think.", "Look at that. Another unclean soul begs me to devour them. Ah, well. More power to me, I suppose.", "If you are that certain that eating you will rid your body of evil, then I am happy to add you to my pure form.", "Offering yourself to me to aid in the cleansing of the world? Well...I suppose it would be rude to reject free food." }) + "\n[c/7F7F7F:<As you attempt to get into her mouth, " + npc.GivenName + " shakes her head; instead, she smiles slyly and hops on top of you, sitting atop your head...only for it, shortly followed by the rest of you, to vanish through the back door and into her waiting gut. As she stands on the ground again, gently pushing your feet into her booty to join the rest of you, she fixes her thong and pats her gut before walking off as if you were never there.>]");
	}

	public override void PostAI(NPC npc)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return;
		}
		VoreTracker stomachTracker = PredNPC.GetStomachTracker(npc);
		if ((stomachTracker != null && stomachTracker.Prey.Count > 0) || Main.GameUpdateCount % 60 != 0)
		{
			return;
		}
		int npcsWithinHouse;
		int npcsWithinVillage;
		List<NPC> nearbyResidentNPCs = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage);
		NPC FORE = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 588);
		bool shouldSnackOnGolfer = false;
		RollForRandomGulp(ref shouldSnackOnGolfer);
		if (FORE != null && ((Entity)FORE).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnGolfer)
		{
			PredNPC.Swallow(npc, (Entity)(object)FORE);
		}
		NPC pudgyPaintBoy = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 227);
		bool shouldSnackOnPudgyPaintBoy = false;
		RollForRandomGulp(ref shouldSnackOnPudgyPaintBoy);
		if (FORE != null && ((Entity)FORE).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnPudgyPaintBoy)
		{
			PredNPC.Swallow(npc, (Entity)(object)pudgyPaintBoy);
		}
		NPC gadgetGal = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 124);
		bool shouldSnackOnGadgetGal = false;
		RollForRandomGulp(ref shouldSnackOnGadgetGal);
		RollForRandomGulp(ref shouldSnackOnGadgetGal);
		if (FORE != null && ((Entity)FORE).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnGadgetGal)
		{
			PredNPC.Swallow(npc, (Entity)(object)gadgetGal);
		}
		NPC steamLass = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 178);
		bool shouldSnackOnSteamLass = false;
		RollForRandomGulp(ref shouldSnackOnSteamLass);
		RollForRandomGulp(ref shouldSnackOnSteamLass);
		if (FORE != null && ((Entity)FORE).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnSteamLass)
		{
			PredNPC.Swallow(npc, (Entity)(object)steamLass);
		}
		NPC funnyShroom = nearbyResidentNPCs.FirstOrDefault((NPC x) => x.type == 160);
		bool shouldSnackOnShroom = false;
		RollForRandomGulp(ref shouldSnackOnShroom);
		RollForRandomGulp(ref shouldSnackOnShroom);
		RollForRandomGulp(ref shouldSnackOnShroom);
		RollForRandomGulp(ref shouldSnackOnShroom);
		RollForRandomGulp(ref shouldSnackOnShroom);
		if (funnyShroom != null && ((Entity)funnyShroom).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && shouldSnackOnShroom)
		{
			PredNPC.Swallow(npc, (Entity)(object)funnyShroom);
		}
		if (!ModContent.GetInstance<V2ServerConfig>().RandomGulpsAgainstPlayers || !((Entity)Main.CurrentPlayer).active || Main.CurrentPlayer.dead || ((Entity)Main.CurrentPlayer).Distance(((Entity)npc).Center) > npc.AsPred().MaxSwallowRange || ((Entity)(object)Main.CurrentPlayer).CurrentCaptor() != null)
		{
			return;
		}
		bool shouldPurifyPlayer = false;
		int worldTaint = WorldGen.tEvil + WorldGen.tBlood + WorldGen.tGood;
		if (worldTaint > 0)
		{
			RollForRandomGulp(ref shouldPurifyPlayer);
		}
		if (worldTaint > 3)
		{
			RollForRandomGulp(ref shouldPurifyPlayer);
		}
		if (worldTaint > 10)
		{
			RollForRandomGulp(ref shouldPurifyPlayer);
		}
		if (worldTaint > 25)
		{
			RollForRandomGulp(ref shouldPurifyPlayer);
		}
		if (worldTaint > 50)
		{
			RollForRandomGulp(ref shouldPurifyPlayer);
			RollForRandomGulp(ref shouldPurifyPlayer);
		}
		if (worldTaint > 80)
		{
			RollForRandomGulp(ref shouldPurifyPlayer);
			RollForRandomGulp(ref shouldPurifyPlayer);
			RollForRandomGulp(ref shouldPurifyPlayer);
			RollForRandomGulp(ref shouldPurifyPlayer);
		}
		if (!shouldPurifyPlayer)
		{
			return;
		}
		int i = worldTaint;
		if (i == 0)
		{
			if (PredNPC.GetStomachTracker(npc) == null)
			{
				PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<A calm, patient smile crosses " + npc.GivenName + "'s face as she very slowly guides you down her throat headfirst rather than shoving you into her ass. Her stomach seems completely inert, possibly for this exact reason.>]\nTo think...you have managed to cleanse this patch of all evils...you have done a great service to this land, indeed. Allow me to provide you with a comfortable place to rest after all your hard work. Let me know if you'd like to get out...or to NOT get out, of course. If you were to want to be purified badly enough, I would not dare to refuse the request of a valued hero like yourself...");
			}
			return;
		}
		int i2 = i;
		if (i2 > 0 && i2 <= 3)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<A calm, patient look crosses " + npc.GivenName + "'s facce as she picks you up and gently pushes your head into her behind, pleasantly sitting atop you and letting your body slide into her little by little. She lets out a rather plain, though satisfied, belch once your feet pass into her ass.>]\nTo think that the world has been almost entirely cleansed of evils. A shame that, as one of the last remaining vestiges of corruption...you, too, must be cleansed by my pure system.\n\n...or, more accurately, I must make sure there isn't any stowing away on your body. My stomach will ensure your cleanliness as you enter the final stretch of your effort.");
			return;
		}
		int i3 = i;
		if (i3 > 3 && i3 <= 10)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<As a mostly-calm, though faintly upset look crosses her face, " + npc.GivenName + " picks you up and slightly-slowly guides you into her backside headfirst, letting out a rather plain, though somewhat satisfied, belch from the internal activity of getting your body into her gut once your feet have well past entered her rear.>]\nThe world has certainly become a more hospitable place in the sense that the evils that plague it have been pushed back so far...yet there still lies a substantial amount. That said, you are making tangible progress. When you are done digesting, continue making such progress.");
			return;
		}
		int i4 = i;
		if (i4 > 10 && i4 <= 25)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<As a mildly-frustrated frown crosses her face, " + npc.GivenName + " picks you up and nigh-effortlessly pushes you into her ass headfirst, letting out a rather plain belch once your feet disappear into her booty as her belly fills out with her latest buttsnack.>]\nYou have, perhaps, done a decent deal in pushing back the encroachment of the poisons of our world...yet you have still failed to cleanse so much. Perform better.");
			return;
		}
		int i5 = i;
		if (i5 > 25 && i5 <= 50)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<As a frustrated scowl crosses her face, " + npc.GivenName + " picks you up and effortlessly guides you into her backside headfirst, letting out a lightly bassy belch once your feet pass into her.>]\nOur stretch of this world has become so tainted...I fail to see this as the fault of anyone other than yourself. I'm beginning to believe you will do a greater service on my hips and hind end than by healing the planet...");
			return;
		}
		int i6 = i;
		if (i6 > 50 && i6 <= 80)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<As an angered scowl crosses her face, " + npc.GivenName + " picks you up and rather roughly forces you up her ass headfirst, letting out a rather rough and bassy belch once your feet vanish into her.>]\nYou are nearing the point of no return, both from the onset of evils and from the onset of my appetite. If, and [c/FF0000:ONLY] if, that is your goal, continue as you are. Otherwise...I'd recommend learning to purify the world more effectively, lest you end up fertilizer, PERMANENTLY.");
		}
		else if (i > 80)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<As an infuriated scowl crosses her face, " + npc.GivenName + " picks you up, forcefully curls you into a ball, and unceremoniously shoves you face-first into her ass all at once, mercilessly sending you rocketing through her intestinal tract and forcing you into an uncomfortable ball in her stomach as she adjusts her planty attire. A mighty belch is forced up from the activity in her stomach, but she seems to care none as it erupts from her maw.>]\nYou have [c/FF0000:FAILED]. Any semblance of use you had will be far surpassed by your new purpose as fertilizer for a woman stronger and more capable than yourself...I've no care to let you bother with your failed mockery of a cleansing. [c/FF0000:Melt, food, and become a part of the buttocks that swallowed you whole and showed you your place on the pecking order.]");
		}
		static void RollForRandomGulp(ref bool purify)
		{
			purify |= Utils.NextBool(Main.rand, 4, 100);
		}
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[4] { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.3", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.4" }));
		if ((double)(WorldGen.tEvil + WorldGen.tBlood + WorldGen.tGood) > 0.25)
		{
			deathReasonKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[3] { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.TaintedWorld.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.TaintedWorld.2", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.TaintedWorld.3" }));
		}
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.Dryad.Hardcore");
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		if (!Main.bloodMoon)
		{
			return 1.375;
		}
		return 2.75;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 29.0;
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 4, 10);
	}

	public static int GetEmpressDigestionStage(NPC npc)
	{
		if (PredNPC.GetStomachTracker(npc) == null)
		{
			return 0;
		}
		PreyData candyFairy = PredNPC.GetStomachTracker(npc).Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 636);
		if (candyFairy == null || candyFairy.WeightLeftToDigest < 4.0)
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
		if (candyFairy.WeightLeftToDigest > 28.5 && candyFairy.WeightLeftToDigest <= 34.0)
		{
			return 3;
		}
		if (candyFairy.WeightLeftToDigest > 21.0 && candyFairy.WeightLeftToDigest <= 28.5)
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
		return Math.Min((int)Math.Floor(4.75 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 6);
	}

	public override void FindFrame(NPC npc, int frameHeight)
	{
		npc.frame.Width = 160;
	}

	public override void ModifyHoverBoundingBox(NPC npc, ref Rectangle boundingBox)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		foreach (ResourcePack enabledResourcePack in V2.EnabledResourcePacks)
		{
			if (enabledResourcePack.Name == "True Dryad Fan")
			{
				if (GetEmpressDigestionStage(npc) > 0)
				{
					boundingBox = new Rectangle((int)((Entity)npc).Left.X, (int)((Entity)npc).Bottom.X - 90, 80, 90);
				}
				else
				{
					boundingBox = new Rectangle((int)((Entity)npc).Center.X - 20, (int)((Entity)npc).Center.Y - 27, 40, 54);
				}
				return;
			}
		}
		if (GetEmpressDigestionStage(npc) > 0)
		{
			boundingBox = new Rectangle((int)((Entity)npc).Left.X, (int)((Entity)npc).Bottom.X - 90, 80, 90);
		}
		else
		{
			boundingBox = new Rectangle((int)((Entity)npc).Center.X - 18, (int)((Entity)npc).Center.Y - 27, 36, 54);
		}
	}
}
