using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.Nurse;

public static class NurseStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule ClothingHat => new ItemTheftRule((NPC npc, Entity pred) => 1736, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule ClothingTop => new ItemTheftRule((NPC npc, Entity pred) => 1737, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule ClothingBottom => new ItemTheftRule((NPC npc, Entity pred) => 1738, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);
	}

	public static NurseProfile PredNurseProfile = new NurseProfile();

	public static Nurse AsNurse(this NPC npc)
	{
		Nurse predNurse = default(Nurse);
		if (!npc.TryGetGlobalNPC<Nurse>(ref predNurse))
		{
			throw new Exception("this instance of the Nurse can't be pred or prey");
		}
		return predNurse;
	}
}
