using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.Localization;
using V2.PlayerHandling;

namespace V2.Core;

public static class ArmorSetHandler
{
	public static List<ArmorSetDefinition> ArmorSets { get; set; } = new List<ArmorSetDefinition>();

	public static void RegisterArmorSet(ArmorSetDefinition armorSet)
	{
		ArmorSets.Add(armorSet);
	}

	public static bool CheckDefinedArmorSets(Player player)
	{
		foreach (ArmorSetDefinition set in ArmorSets)
		{
			if (set.Active(player))
			{
				player.setBonus = (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160) ? ("SET BONUS:\n" + Language.GetTextValueWith("Mods.V2.ItemTooltip." + set.SetBonusDescriptionKey + ".Long", set.SetBonusDescriptionVariables)) : Language.GetTextValueWith("Mods.V2.ItemTooltip." + set.SetBonusDescriptionKey + ".Short", set.SetBonusDescriptionVariables));
				player.AsV2Player().setBonusActive = true;
				if (!((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160) || !((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162))
				{
					player.AsV2Player().setBonusShouldBeDisplayed = true;
				}
				set.ApplySetBonus(player);
				return true;
			}
		}
		return false;
	}
}
