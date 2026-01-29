using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.Guide;

public static class GuideStuff
{
	public static class ItemTheftRules
	{
		public static ItemTheftRule GreenCap => new ItemTheftRule((NPC npc, Entity pred) => 867, (NPC npc, Entity pred) => 1, (NPC npc, Entity pred) => (!(npc.GivenName == "Andrew")) ? 0.0 : 1.0);
	}

	public static GuideProfile PredGuideProfile => new GuideProfile();

	public static Guide AsGuide(this NPC npc)
	{
		Guide predGuide = default(Guide);
		if (!npc.TryGetGlobalNPC<Guide>(ref predGuide))
		{
			throw new Exception("this instance of the Guide can't be pred or prey");
		}
		return predGuide;
	}
}
