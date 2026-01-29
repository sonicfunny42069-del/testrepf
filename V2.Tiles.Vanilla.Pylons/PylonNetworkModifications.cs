using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.Map;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Tiles.Vanilla.Pylons;

public class PylonNetworkModifications : GlobalPylon
{
	public override bool PreDrawMapIcon(ref MapOverlayDrawContext context, ref string mouseOverText, ref TeleportPylonInfo pylonInfo, ref bool isNearPylon, ref Color drawColor, ref float deselectedScale, ref float selectedScale)
	{
		if (((Entity)(object)Main.CurrentPlayer).CurrentCaptor() != null)
		{
			isNearPylon = false;
		}
		return true;
	}

	public override bool? ValidTeleportCheck_PreAnyDanger(TeleportPylonInfo pylonInfo)
	{
		if (((Entity)(object)Main.CurrentPlayer).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}
}
