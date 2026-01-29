using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.Steampunker;

public static class SteampunkerStuff
{
	public static SteampunkerProfile PredSteampunkerProfile = new SteampunkerProfile();

	public static Steampunker AsSteampunker(this NPC npc)
	{
		Steampunker predSteampunker = default(Steampunker);
		if (!npc.TryGetGlobalNPC<Steampunker>(ref predSteampunker))
		{
			throw new Exception("this instance of the Steampunker can't be pred or prey");
		}
		return predSteampunker;
	}
}
