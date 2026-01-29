using System;
using Terraria;

namespace V2.NPCs.Vanilla.Forest;

public static class BlueSlimeStuff
{
	public static BlueSlime AsBlueSlime(this NPC npc)
	{
		BlueSlime blueSlime = default(BlueSlime);
		if (!npc.TryGetGlobalNPC<BlueSlime>(ref blueSlime))
		{
			throw new Exception("this instance of a Blue Slime, supposedly, doesn't exist");
		}
		return blueSlime;
	}
}
