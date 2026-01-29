using System;
using Terraria;

namespace V2.NPCs.Vanilla.Cavern;

public static class BlackSlimeStuff
{
	public static BlackSlime AsBlackSlime(this NPC npc)
	{
		BlackSlime BlackSlime = default(BlackSlime);
		if (!npc.TryGetGlobalNPC<BlackSlime>(ref BlackSlime))
		{
			throw new Exception("this instance of a Black Slime, supposedly, doesn't exist");
		}
		return BlackSlime;
	}
}
