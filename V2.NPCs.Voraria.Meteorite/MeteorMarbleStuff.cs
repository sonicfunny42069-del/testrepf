using Terraria;

namespace V2.NPCs.Voraria.Meteorite;

public static class MeteorMarbleStuff
{
	public static int BaseOrbitalCount
	{
		get
		{
			if (Main.masterMode)
			{
				return 6;
			}
			if (Main.expertMode)
			{
				return 5;
			}
			return 4;
		}
	}
}
