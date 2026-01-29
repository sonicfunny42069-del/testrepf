using System;
using Terraria;

namespace V2.NPCs.Vanilla.Ocean;

public static class SharkStuff
{
	public static Shark AsShark(this NPC npc)
	{
		Shark shark = default(Shark);
		if (!npc.TryGetGlobalNPC<Shark>(ref shark))
		{
			throw new Exception("this instance of a Shark, supposedly, doesn't exist");
		}
		return shark;
	}
}
