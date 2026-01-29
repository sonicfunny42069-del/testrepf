using System;
using Terraria;

namespace V2.NPCs.Vanilla.Graveyard;

public static class GhostStuff
{
	public static Ghost AsGhost(this NPC npc)
	{
		Ghost Ghost = default(Ghost);
		if (!npc.TryGetGlobalNPC<Ghost>(ref Ghost))
		{
			throw new Exception("this instance of a Ghost, supposedly, doesn't exist");
		}
		return Ghost;
	}
}
