using BetterDialogue.UI;
using Terraria;
using V2.PlayerHandling;

namespace V2.NPCs.Vanilla.TownNPCs.Stylist.ChatButtons;

public class HairStyleButtonModification : GlobalChatButton
{
	public override bool PreClick(ChatButton chatButton, NPC npc, Player player)
	{
		if ((object)chatButton != ChatButton.StyistHaircut || npc.type != 353)
		{
			return true;
		}
		if (player.IsFoodFor((Entity)(object)npc, out var pastTense) && !pastTense)
		{
			Main.npcChatText = (Main.bloodMoon ? "My gut's a better haircut than anything you'll ever think up, dummy. Just shut up and let it do what it does best; turn rowdy meals into a better style." : "You're already getting a haircut in there, hun! My gut'll do any haircut you want, for free!...as long as you don't mind being a snack after the fact...");
			return false;
		}
		if (Main.bloodMoon)
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "[c/7F7F7F:<Without warning, " + npc.GivenName + " stuffs you down her throat, headfirst. As you quickly settle in thereafter, you find that her acids have already worked away at your hair.>]\nThere. That gives you your haircut, and gives me a good meal to make me less hungry for a while. Now, quiet down and digest.");
			return false;
		}
		if (Utils.NextBool(Main.rand, 5, 100))
		{
			PredNPC.SwallowWithTextIfApplicable(npc, Main.CurrentPlayer, "Actually, while you're asking about a haircut...I'm really hungry, and I know just the thing that'll solve both our problems at once!\n[c/7F7F7F:<With little warning, " + npc.GivenName + " stuffs you down her throat, headfirst. She gives a pleasant hum as you settle into her stomach.>]\nThere! Now you can get my signature Gut Cut experience; it'll shave off exactly as much as you could ever want, give you a snazzy new acid-worn style, AND keep me from being hungry! Hope you like it, because there's a STRICT no-refund policy.");
			return false;
		}
		return true;
	}
}
