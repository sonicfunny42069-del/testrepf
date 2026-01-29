using System;
using Terraria;
using Terraria.ModLoader;
using V2.Items.Voraria.Accessories.Informational;

namespace V2.NPCs.Vanilla.TownNPCs.Mechanic;

public static class MechanicStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule CombatWrench => new ItemTheftRule((NPC npc, Entity pred) => 4818, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 2.0 / 3.0, 
			1 => 0.5, 
			_ => 1.0 / 3.0, 
		});

		public static ItemTheftRule MealSizeScanner => new ItemTheftRule((NPC npc, Entity pred) => ModContent.ItemType<MealSizeScanner>(), (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.175, 
			1 => 0.15, 
			_ => 0.1, 
		});
	}

	public static MechanicProfile PredMechanicProfile = new MechanicProfile();

	public static Mechanic AsMechanic(this NPC npc)
	{
		Mechanic predMechanic = default(Mechanic);
		if (!npc.TryGetGlobalNPC<Mechanic>(ref predMechanic))
		{
			throw new Exception("this instance of the Mechanic can't be pred or prey");
		}
		return predMechanic;
	}
}
