using System;
using Terraria;

namespace V2.NPCs.Vanilla.Forest;

public static class AngryDandelionStuff
{
	public static AngryDandelion AsAngryDandelion(this NPC npc)
	{
		AngryDandelion angryDandelion = default(AngryDandelion);
		if (!npc.TryGetGlobalNPC<AngryDandelion>(ref angryDandelion))
		{
			throw new Exception("this instance of an Angry Dandelion, supposedly, doesn't exist");
		}
		return angryDandelion;
	}
}
