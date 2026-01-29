using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.Painter;

public static class PainterStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule PaintballGun => new ItemTheftRule((NPC npc, Entity pred) => 3350, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => 1.0);

		public static ItemTheftRule JimsCap => new ItemTheftRule((NPC npc, Entity pred) => 5290, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => (!(npc.GivenName == "Jim")) ? 0.0 : 1.0);
	}

	public static PainterProfile PredPainterProfile => new PainterProfile();

	public static Painter AsPainter(this NPC npc)
	{
		Painter predPainter = default(Painter);
		if (!npc.TryGetGlobalNPC<Painter>(ref predPainter))
		{
			throw new Exception("this instance of the Painter can't be pred or prey");
		}
		return predPainter;
	}
}
