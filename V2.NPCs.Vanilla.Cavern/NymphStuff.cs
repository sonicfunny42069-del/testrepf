using System;
using Terraria;
using Terraria.ModLoader;
using V2.Items.Voraria;
using V2.Items.Voraria.Charms;

namespace V2.NPCs.Vanilla.Cavern;

public static class NymphStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule NymphHairStrands => new ItemTheftRule((NPC npc, Entity pred) => ModContent.ItemType<NymphHairStrand>(), (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 2, 
			1 => Main.rand.Next(1, 3), 
			_ => 1, 
		}, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule MetalDetector => new ItemTheftRule((NPC npc, Entity pred) => 3102, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 0.175, 
			1 => 0.15, 
			_ => 0.1, 
		});

		public static ItemTheftRule FatassCharm => new ItemTheftRule((NPC npc, Entity pred) => ModContent.ItemType<CharmFatass>(), (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => Main.GameMode switch
		{
			2 => 1.0, 
			1 => 0.875, 
			_ => 0.75, 
		});
	}

	public static Nymph AsNymph(this NPC npc)
	{
		Nymph cuteGirlLure = default(Nymph);
		if (!npc.TryGetGlobalNPC<Nymph>(ref cuteGirlLure))
		{
			throw new Exception("this instance of a Nymph, supposedly, doesn't exist");
		}
		return cuteGirlLure;
	}
}
