using System;
using Terraria;

namespace V2.NPCs.Vanilla.Jungle;

public static class JungleSlimeStuff
{
	public static JungleSlime AsJungleSlime(this NPC npc)
	{
		JungleSlime JungleSlime = default(JungleSlime);
		if (!npc.TryGetGlobalNPC<JungleSlime>(ref JungleSlime))
		{
			throw new Exception("this instance of a Black Slime, supposedly, doesn't exist");
		}
		return JungleSlime;
	}
}
