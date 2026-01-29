using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.PartyGirl;

public static class PartyGirlStuff
{
	public static PartyGirlPredProfile PartyGirlPredProfile => new PartyGirlPredProfile();

	public static PartyGirl AsPartyGirl(this NPC npc)
	{
		PartyGirl bellyPartyGirl = default(PartyGirl);
		if (!npc.TryGetGlobalNPC<PartyGirl>(ref bellyPartyGirl))
		{
			throw new Exception("this instance of the Party Girl can't be pred or prey. that gut party you wanted to throw'll need to be rescheduled");
		}
		return bellyPartyGirl;
	}
}
