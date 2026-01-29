using System;
using Terraria;

namespace V2.NPCs.Vanilla.BloodMoon;

public static class TheGroomStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule TopHat => new ItemTheftRule((NPC npc, Entity pred) => 239, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule TuxedoShirt => new ItemTheftRule((NPC npc, Entity pred) => 240, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 1.0, 
			1 => 0.8, 
			_ => 2.0 / 3.0, 
		});

		public static ItemTheftRule TuxedoPants => new ItemTheftRule((NPC npc, Entity pred) => 241, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 1.0, 
			1 => 0.8, 
			_ => 2.0 / 3.0, 
		});
	}

	public static TheGroom AsTheGroom(this NPC npc)
	{
		TheGroom hungryZombieWife = default(TheGroom);
		if (!npc.TryGetGlobalNPC<TheGroom>(ref hungryZombieWife))
		{
			throw new Exception("this instance of The Bride, supposedly, doesn't exist");
		}
		return hungryZombieWife;
	}
}
