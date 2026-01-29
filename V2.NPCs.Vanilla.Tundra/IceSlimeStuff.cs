using System;
using Terraria;

namespace V2.NPCs.Vanilla.Tundra;

public static class IceSlimeStuff
{
	public static IceSlime AsIceSlime(this NPC npc)
	{
		IceSlime IceSlime = default(IceSlime);
		if (!npc.TryGetGlobalNPC<IceSlime>(ref IceSlime))
		{
			throw new Exception("this instance of an Ice Slime, supposedly, doesn't exist");
		}
		return IceSlime;
	}
}
