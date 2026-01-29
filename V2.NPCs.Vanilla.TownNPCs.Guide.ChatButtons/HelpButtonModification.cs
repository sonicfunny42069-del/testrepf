using BetterDialogue.UI;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.Guide.ChatButtons;

public class HelpButtonModification : GlobalChatButton
{
	public override bool PreClick(ChatButton chatButton, NPC npc, Player player)
	{
		if ((object)chatButton != ChatButton.GuideProgressHelp)
		{
			return true;
		}
		if (Main.hardMode)
		{
			Main.chatText = "Nope. Not anymore. You're on your own.";
			return false;
		}
		return true;
	}
}
