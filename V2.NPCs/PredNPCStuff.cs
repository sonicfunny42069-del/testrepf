using System;
using Terraria;

namespace V2.NPCs;

public static class PredNPCStuff
{
	public static PredNPC AsPred(this NPC npc, bool risky = false)
	{
		PredNPC predNPC = default(PredNPC);
		if (!npc.TryGetGlobalNPC<PredNPC>(ref predNPC))
		{
			if (risky)
			{
				return null;
			}
			throw new Exception("this NPC can't be a pred at all, as they don't have a PredNPC global attached to them. look for your favorite gut to sleep in elsewhere");
		}
		return predNPC;
	}
}
