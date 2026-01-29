using System;
using Terraria;

namespace V2.NPCs.Vanilla.BloodMoon;

public static class TheBrideStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule WeddingVeil => new ItemTheftRule((NPC npc, Entity pred) => 3478, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule WeddingDress => new ItemTheftRule((NPC npc, Entity pred) => 3479, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);
	}

	public static TheBride AsTheBride(this NPC npc)
	{
		TheBride hungryZombieWife = default(TheBride);
		if (!npc.TryGetGlobalNPC<TheBride>(ref hungryZombieWife))
		{
			throw new Exception("this instance of The Bride, supposedly, doesn't exist");
		}
		return hungryZombieWife;
	}
}
