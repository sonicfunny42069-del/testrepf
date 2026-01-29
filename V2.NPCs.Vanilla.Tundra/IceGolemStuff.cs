using System;
using Terraria;

namespace V2.NPCs.Vanilla.Tundra;

public static class IceGolemStuff
{
	public static IceGolem AsIceGolem(this NPC npc)
	{
		IceGolem IceGolem = default(IceGolem);
		if (!npc.TryGetGlobalNPC<IceGolem>(ref IceGolem))
		{
			throw new Exception("this instance of a Snow Flinx, supposedly, doesn't exist");
		}
		return IceGolem;
	}
}
