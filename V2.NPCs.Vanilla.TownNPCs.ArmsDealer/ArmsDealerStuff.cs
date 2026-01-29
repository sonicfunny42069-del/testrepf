using System;
using Terraria;

namespace V2.NPCs.Vanilla.TownNPCs.ArmsDealer;

public static class ArmsDealerStuff
{
	public static ArmsDealerProfile PredArmsDealerProfile => new ArmsDealerProfile();

	public static ArmsDealer AsArmsDealer(this NPC npc)
	{
		ArmsDealer predArmsDealer = default(ArmsDealer);
		if (!npc.TryGetGlobalNPC<ArmsDealer>(ref predArmsDealer))
		{
			throw new Exception("this instance of the Arms Dealer can't be pred or prey");
		}
		return predArmsDealer;
	}
}
