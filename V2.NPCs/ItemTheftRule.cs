using Terraria;

namespace V2.NPCs;

public struct ItemTheftRule
{
	public delegate int GetItemType(NPC npc, Entity pred);

	public delegate int GetItemAmount(NPC npc, Entity pred);

	public delegate double GetItemChance(NPC npc, Entity pred);

	public GetItemType ItemType { get; set; }

	public GetItemAmount ItemAmount { get; set; }

	public GetItemChance ItemChance { get; set; }

	public ItemTheftRule(GetItemType type, GetItemAmount amount, GetItemChance chance)
	{
		ItemType = type;
		ItemAmount = amount;
		ItemChance = chance;
	}
}
