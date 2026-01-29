using BetterDialogue.UI;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;

namespace V2.NPCs.Voraria.TownNPCs.Succubus.ChatButtons;

public class LucindaFreeButton : ChatButton
{
	public override double Priority => 3.4;

	public override string Text(NPC npc, Player player)
	{
		return Language.GetTextValue("Mods.V2.NPCs.Lucinda.FreeButton.DisplayName");
	}

	public override bool IsActive(NPC npc, Player player)
	{
		return npc.type == ModContent.NPCType<LucindaBound>();
	}

	public override void OnClick(NPC npc, Player player)
	{
		ModContent.GetInstance<V2MasterSystem>().freedSucc = true;
		npc.AI_000_TransformBoundNPC(((Entity)Main.CurrentPlayer).whoAmI, ModContent.NPCType<Lucinda>());
		Main.npcChatText = "There ya go! Wasn't that hard. Now, c'mere so I can reward you with some time in my gut...or, y'know, just some old trinkets from your ol' pal Lucinda to help you be a great pred just like me.";
	}
}
