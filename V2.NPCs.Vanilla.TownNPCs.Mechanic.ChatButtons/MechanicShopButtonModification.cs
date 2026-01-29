using BetterDialogue.UI;
using Terraria;
using V2.PlayerHandling;

namespace V2.NPCs.Vanilla.TownNPCs.Mechanic.ChatButtons;

public class MechanicShopButtonModification : GlobalChatButton
{
	public override bool PreClick(ChatButton chatButton, NPC npc, Player player)
	{
		if ((object)chatButton != ChatButton.Shop || npc.type != 124)
		{
			return true;
		}
		if (player.IsFoodFor((Entity)(object)npc, out var pastTense) && !pastTense)
		{
			Main.npcChatText = (Main.bloodMoon ? "Cessate your pointless, mind-numbing questions. Why should, or WOULD, I engage in commerce with any battery of mine?" : "Unfortunately, any attempt to retrieve money from my digestive system would result in failure, as it's efficient enough to melt down metal alongside meat like yourself.");
			return false;
		}
		return true;
	}
}
