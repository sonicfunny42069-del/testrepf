using BetterDialogue.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Voraria.TownNPCs.Enigma.ChatButtons;

public class CloverFreeButton : ChatButton
{
	public override double Priority => 3.4;

	public override string Text(NPC npc, Player player)
	{
		return Language.GetTextValue("Mods.V2.NPCs.Clover.FreeButton.DisplayName");
	}

	public override bool IsActive(NPC npc, Player player)
	{
		return npc.type == ModContent.NPCType<CloverBound>();
	}

	public override void OnClick(NPC npc, Player player)
	{
		ModContent.GetInstance<V2MasterSystem>().freedEnigma = true;
		npc.AI_000_TransformBoundNPC(((Entity)Main.CurrentPlayer).whoAmI, ModContent.NPCType<Clover>());
		Main.npcChatText = "Oh you actually got me down. Uh, hi? What do i do now exactly?";
	}
}
