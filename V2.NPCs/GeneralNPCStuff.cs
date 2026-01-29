using System;
using Terraria;

namespace V2.NPCs;

public static class GeneralNPCStuff
{
	public static GeneralNPC AsV2NPC(this NPC npc, bool risky = false)
	{
		GeneralNPC generalNPC = default(GeneralNPC);
		if (!npc.TryGetGlobalNPC<GeneralNPC>(ref generalNPC))
		{
			if (risky)
			{
				return null;
			}
			throw new Exception("this NPC, somehow, has been (possibly) completely untouched by VSC. how?");
		}
		return generalNPC;
	}
}
