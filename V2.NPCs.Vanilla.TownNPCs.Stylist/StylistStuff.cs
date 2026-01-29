using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.Stylist;

public static class StylistStuff
{
	public static StylistPredProfile StylistPredProfile => new StylistPredProfile();

	public static Stylist AsStylist(this NPC npc)
	{
		Stylist predStylist = default(Stylist);
		if (!npc.TryGetGlobalNPC<Stylist>(ref predStylist))
		{
			throw new Exception("this instance of the Stylist can't be pred or prey. best girl's best gut will have to wait, unfortunately");
		}
		return predStylist;
	}
}
