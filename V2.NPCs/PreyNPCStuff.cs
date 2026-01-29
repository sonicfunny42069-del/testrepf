using System;
using Terraria;

namespace V2.NPCs;

public static class PreyNPCStuff
{
	public static PreyNPC AsFood(this NPC npc, bool risky = false)
	{
		PreyNPC preyNPC = default(PreyNPC);
		if (!npc.TryGetGlobalNPC<PreyNPC>(ref preyNPC))
		{
			if (risky)
			{
				return null;
			}
			throw new Exception("this NPC can't be eaten, and thus, doesn't have a PreyNPC global attached to them. look for your favorite food elsewhere");
		}
		return preyNPC;
	}
}
