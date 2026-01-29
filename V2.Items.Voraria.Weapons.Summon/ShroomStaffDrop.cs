using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Weapons.Summon;

public class ShroomStaffDrop : GlobalNPC
{
	public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
	{
		if (npc.type == 634 || npc.type == 254 || npc.type == 255 || npc.type == 635)
		{
			((NPCLoot)(ref npcLoot)).Add(ItemDropRule.Common(ModContent.ItemType<ShroomStaff>(), 90, 1, 1));
		}
		else if (npc.type == 257 || npc.type == 258 || npc.type == 256 || npc.type == 259 || npc.type == 260)
		{
			((NPCLoot)(ref npcLoot)).Add(ItemDropRule.Common(ModContent.ItemType<ShroomStaff>(), 50, 1, 1));
		}
	}
}
