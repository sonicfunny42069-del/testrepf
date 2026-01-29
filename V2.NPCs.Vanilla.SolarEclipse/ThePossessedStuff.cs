using System;
using Terraria;

namespace V2.NPCs.Vanilla.SolarEclipse;

public static class ThePossessedStuff
{
	public static ThePossessed AsThePossessed(this NPC npc)
	{
		ThePossessed lacewing = default(ThePossessed);
		if (!npc.TryGetGlobalNPC<ThePossessed>(ref lacewing))
		{
			throw new Exception("this instance of a The Possessed, supposedly, doesn't exist");
		}
		return lacewing;
	}
}
