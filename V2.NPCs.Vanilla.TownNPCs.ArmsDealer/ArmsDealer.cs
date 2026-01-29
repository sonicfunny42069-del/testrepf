using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.NPCs.Vanilla.TownNPCs.ArmsDealer;

public class ArmsDealer : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
	{
		return entity.type == 19;
	}

	public override void SetDefaults(NPC npc)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		npc.AsV2NPC().Gender = EntityGender.Male;
		npc.AsV2NPC().GetNewDialogue = GetArmsDealerChat;
		npc.AsFood().DefinedBaseSize = 1.04;
		npc.AsPred().WeightGainRatio = 0.035;
		npc.AsPred().MaxStomachCapacity = 1.75;
		npc.AsPred().BaseStomachacheMeterCapacity = 115.0;
		npc.AsPred().SmallGulps = Gulps.Short;
		npc.AsPred().SmallGulpThreshold = 0.6;
		npc.AsPred().BigGulps = Gulps.Standard;
		npc.AsPred().CanBeForceFed = CanArmsDealerBeForceFed;
		npc.AsPred().OnForceFed = OnArmsDealerForceFed;
		npc.AsPred().DigestionType = EntityDigestionType.Acidic;
		npc.AsPred().GetDigestionTickRate = GetDigestionTickRate;
		npc.AsPred().GetDigestionTickDamage = GetDigestionTickDamage;
		npc.AsPred().OnDigestionKill = null;
		npc.AsPred().MouthSoundRawOffset = ((Entity)(object)npc).TrueCenter() + new Vector2((float)((Entity)npc).direction * 8f, -14f);
		npc.AsPred().SmallBurps = Burps.Humanoid.Small;
		npc.AsPred().SmallBurpThreshold = 0.6;
		npc.AsPred().StandardBurps = Burps.Humanoid.Standard;
		npc.AsPred().GetAdditionalDigestedPlayerMessages = GetDigestedPlayerAdditionalDeathMessages;
		npc.AsPred().GetPreyAbsorptionRate = GetPreyAbsorptionRate;
		npc.AsPred().GetVisualBellySize = GetVisualBellySize;
	}

	public override ITownNPCProfile ModifyTownNPCProfile(NPC npc)
	{
		return (ITownNPCProfile)(object)ArmsDealerStuff.PredArmsDealerProfile;
	}

	public static List<string> GetArmsDealerChat(NPC npc, Player player)
	{
		int npcsWithinHouse;
		int npcsWithinVillage;
		NPC helloNurse = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage).FirstOrDefault((NPC x) => x.type == 18);
		List<string> armsDealerChatPool = new List<string>();
		V2Utils.FigureOutWhatTimeItIs(out var _, out var _, out var _, out var _, out var _);
		PredNPC.GetCurrentBellyWeight(npc);
		if (player.IsFoodFor((Entity)(object)npc, out var playerWasAlreadyDigested) && !playerWasAlreadyDigested)
		{
			bool noDigest = false;
			if (Main.bloodMoon)
			{
				armsDealerChatPool.AddRange(new List<string> { "KEEP IT THE HELL DOWN! Fuckin' douche, throwin' off my aim...I'M TRYIN' TO SNIPE A CROW OUT HERE!" });
			}
			else
			{
				armsDealerChatPool.AddRange(new List<string> { "Heh...not all that much about the hunt that's better than what comes after; your prey sittin' in your gut, completely at your mercy." });
				if (noDigest)
				{
					armsDealerChatPool.AddRange(new List<string>());
				}
				else
				{
					armsDealerChatPool.AddRange(new List<string> { "Ugh...quit movin' around in there so much, you're throwin' off my aim!", "Keep it down and melt. Gonna make you into a fresh new protein boost so I get even MORE ripped!" });
				}
			}
		}
		else if (Main.bloodMoon)
		{
			armsDealerChatPool.AddRange(new List<string> { "You come anywhere NEAR me right now, I'll put a hundred holes in you and cram what's left down my throat.", "I swear, you BETTER be here to buy something. The ammo costs extra, ESPECIALLY on nights like tonight.", "Awful good night to keep outta everybody's hair, eh? Best hope you figured mine's included. Buy somethin' or get lost." });
		}
		else
		{
			armsDealerChatPool.AddRange(new List<string> { "Keep your hands off the merchandise, pal. That means none o' me and none o' the guns...unless, of course, you've got somethin' to give me for the guns.", "You know, I've got a bit of an unbeatable knack for huntin' down all sorts of prey. Sure, you can't tranq 'em with a sniper rifle or a shotgun, but who cares when you can get 'em down your throat while they're still reelin' from the first shot?", "...heh. See you're eyeballin' the Minishark. Trust me, you, ah...you REALLY don't wanna know how those things are made. It's a helluva process.", "Don't even get me started. For the last time, gold is NOT a good material for bullets. Frankly, I don't even know why people use it.", "Hey, buddy, this ain't an action movie. Ammo costs extra." });
			if (helloNurse != null)
			{
				if (helloNurse.IsFoodFor((Entity)(object)player))
				{
					if (player.AsPred().SafeStomach)
					{
						armsDealerChatPool.AddRange(new List<string> { "...really? You're not even going to digest her? I swear, you're just TAUNTIN' me at this point...anywho, what are you lookin' for?" });
					}
					else
					{
						armsDealerChatPool.AddRange(new List<string> { "[c/BFBFBF:<" + npc.GivenName + " catches a glance at your midsection, then looks the other way with a disgruntled look on his face. He seems...almost jealous of you.>]\n...well, let's get this over with. What do you want?" });
					}
				}
				else if (helloNurse.IsFoodFor((Entity)(object)npc))
				{
					armsDealerChatPool.AddRange(new List<string>
					{
						"...huh? Oh, yeah, I've got " + helloNurse.GivenName + " with me. She's a real delicacy, too. So, then! Full gut, full house, what can I do ya for?",
						"Lookin' to really impress a lady? Gotta get her on the inside of your gut like I've got lil' ol' " + helloNurse.GivenName + " here. Fastest way to somebody's heart...\n[c/BFBFBF:<Judging from the embarassed groan you hear from someone in " + npc.GivenName + "'s gut, it's probably safe to assume this isn't entirely what has her hooked on him.>]"
					});
				}
				else
				{
					armsDealerChatPool.AddRange(new List<string>
					{
						"Make it quick, will ya? Got a date with " + helloNurse.GivenName + " pretty soon here, and I wouldn't want you, ah...we'll go with \"gettin' in the way\".",
						"Don't know about you, but I want what " + helloNurse.GivenName + "'s sellin'.\n\n...whaddaya mean, she doesn't sell anything? She sells stuff just fine!"
					});
				}
			}
			if (Main.IsItAHappyWindyDay)
			{
				armsDealerChatPool.AddRange(new List<string> { "Sheesh, it's real windy today! Haven't been able to keep on-target for test firin' at all!", "Sprayin' and prayin' is real fun, don't get me wrong, but maybe keep the shots OUT of my face in this wind." });
			}
			if (Main.IsItRaining)
			{
				armsDealerChatPool.AddRange(new List<string> { "You call 'em flyin' fish. I call 'em target practice." });
				if (Main.hardMode)
				{
					armsDealerChatPool.AddRange(new List<string> { "You know, there's somethin' REAL sinister about the clouds right now...no, really. They're LITERALLY out to getcha. Shoot a few holes in 'em for me." });
				}
			}
			if (Main.IsItStorming)
			{
				armsDealerChatPool.AddRange(new List<string> { "Y'know, if you time your shots right, thunder acts as a natural muffler for almost any gun.", "A lightning gun?...nah, I ain't got time for that! Don't need anything but me and my bullets!" });
			}
		}
		return armsDealerChatPool;
	}

	public static bool CanArmsDealerBeForceFed(NPC npc)
	{
		return true;
	}

	public static void OnArmsDealerForceFed(NPC npc, Player player)
	{
		PredNPC.SetChatboxText(npc, player, "[c/7F7F7F:<" + npc.GivenName + "'s stomach gurgles ominously as he intercepts your attempt to force-feed him and wolfs you down with ease, grinning as he slaps his gut full of you.>]\nEasiest prey of my life. Didn't even hafta shoot at ya for it! Be sure not to leave much behind...the girls like a fit fella like me without too much chub.");
	}

	public static void GetDigestedPlayerAdditionalDeathMessages(NPC npc, Player player, List<string> deathReasonKeyList)
	{
		deathReasonKeyList.AddHumanoidPredMessages();
		deathReasonKeyList.AddRange(new List<string> { "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.ArmsDealer.1", "Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.ArmsDealer.2" });
		if (player.difficulty == 2)
		{
			deathReasonKeyList.Clear();
			deathReasonKeyList.Add("Mods.V2.Death.DigestedPlayer.SpecificNPC.Townsfolk.ArmsDealer.Hardcore");
		}
	}

	public override void PostAI(NPC npc)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null || PredNPC.GetStomachTracker(npc)?.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 18) != null || Main.GameUpdateCount % 60 != 0)
		{
			return;
		}
		int npcsWithinHouse;
		int npcsWithinVillage;
		NPC helloNurse = npc.GetNearbyResidentNPCs(out npcsWithinHouse, out npcsWithinVillage).FirstOrDefault((NPC x) => x.type == 18);
		bool snackOnCrush = false;
		RollForRandomGulp(ref snackOnCrush);
		RollForRandomGulp(ref snackOnCrush);
		RollForRandomGulp(ref snackOnCrush);
		if (helloNurse != null && ((Entity)helloNurse).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && snackOnCrush)
		{
			PredNPC.Swallow(npc, (Entity)(object)helloNurse);
		}
		if (ModContent.GetInstance<V2ServerConfig>().RandomGulpsAgainstPlayers && ((Entity)Main.CurrentPlayer).active && !Main.CurrentPlayer.dead && !(((Entity)Main.CurrentPlayer).Distance(((Entity)npc).Center) > npc.AsPred().MaxSwallowRange) && ((Entity)(object)Main.CurrentPlayer).CurrentCaptor() == null)
		{
			bool decideToHuntPlayer = false;
			RollForRandomGulp(ref decideToHuntPlayer);
			if (Main.netMode != 2 && ((Entity)Main.CurrentPlayer).whoAmI == Main.myPlayer && ((Entity)Main.CurrentPlayer).Distance(((Entity)npc).Center) <= npc.AsPred().MaxSwallowRange && decideToHuntPlayer)
			{
				List<string> potentialRandomGulpLines = new List<string> { "...next time, don't hang around a seasoned hunter so long unless you WANNA end up their next meal.", "Surest shot I've taken all day. Thanks for the snack...now keep it down while I test out my guns." };
				PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<" + npc.GivenName + "'s stomach growls for only a split second before he crams you into his mouth, wolfing you down before you have the chance to react.>]\n" + Utils.NextFromCollection<string>(Main.rand, potentialRandomGulpLines));
			}
		}
		static void RollForRandomGulp(ref bool gulp)
		{
			gulp |= Utils.NextBool(Main.rand, 7, 200);
		}
	}

	public static double GetDigestionTickRate(NPC npc, PreyData prey)
	{
		if (!Main.bloodMoon)
		{
			return 1.6;
		}
		return 2.4;
	}

	public static double GetDigestionTickDamage(NPC npc, PreyData prey)
	{
		return 32.5;
	}

	public static void OnDigestionKill(NPC npc, PreyData digestedPrey)
	{
	}

	public static double GetPreyAbsorptionRate(NPC npc)
	{
		return 1.0 / (double)V2Utils.SensibleTime(0, 2);
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
		return Math.Min((int)Math.Floor(5.0 * Math.Sqrt(PredNPC.GetCurrentBellyWeight(npc))), 4);
	}
}
