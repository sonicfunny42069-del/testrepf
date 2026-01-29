using System;
using Terraria;

namespace V2.NPCs.Vanilla.Crimson;

public static class CrimsonAxeStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule Crimtane => new ItemTheftRule((NPC npc, Entity pred) => 880, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => Main.rand.Next(15, 26), 
			1 => Main.rand.Next(12, 21), 
			_ => Main.rand.Next(9, 16), 
		}, (NPC npc, Entity pred) => 1.0);
	}

	public static CrimsonAxe AsCrimsonAxe(this NPC npc)
	{
		CrimsonAxe fatFuckAxe = default(CrimsonAxe);
		if (!npc.TryGetGlobalNPC<CrimsonAxe>(ref fatFuckAxe))
		{
			throw new Exception("this instance of a Crimson Axe, supposedly, doesn't exist");
		}
		return fatFuckAxe;
	}
}
