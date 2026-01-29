using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling;
using V2.UI;

namespace V2.Items;

public class GeneralItem : GlobalItem
{
	public delegate void DelegateArmorEffectCode(Item item, Player player);

	public delegate void DelegateAccessoryEffectCode(Item item, Player player, bool hideVisual);

	public delegate void DelegateAccessoryVanityEffectCode(Item item, Player player);

	public DelegateHeldItemDrawingUI heldItemUIDrawMethod;

	public int ReleasedNPCNetID;

	public DelegateArmorEffectCode ArmorEffectCode { get; internal set; }

	public DelegateAccessoryEffectCode AccessoryEffectCode { get; internal set; }

	public DelegateAccessoryVanityEffectCode AccessoryVanityEffectCode { get; internal set; }

	public override bool InstancePerEntity => true;

	public GeneralItem()
	{
		heldItemUIDrawMethod = null;
		ReleasedNPCNetID = 0;
	}

	public override void HorizontalWingSpeeds(Item item, Player player, ref float speed, ref float acceleration)
	{
		float weightMovementMult = (float)Math.Min(1.0, 1.0 / (player.AsPred().StomachWeight + 1.0));
		acceleration *= weightMovementMult;
	}

	public override void VerticalWingSpeeds(Item item, Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
	{
		float weightMovementMult = (float)Math.Min(1.0, 1.0 / (player.AsPred().StomachWeight + 1.0));
		ascentWhenFalling *= weightMovementMult;
		ascentWhenRising *= weightMovementMult;
		maxCanAscendMultiplier *= weightMovementMult;
		maxAscentMultiplier *= weightMovementMult;
		constantAscend *= weightMovementMult;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		Player player = Main.LocalPlayer;
		if (item.wornArmor && player.AsV2Player().setBonusActive)
		{
			tooltips.FirstOrDefault((TooltipLine x) => x.Name == "SetBonus").Hide();
			if (player.AsV2Player().setBonusShouldBeDisplayed && V2Utils.FindFirstTooltipLineThatIsOrComesAfterFlavorText(tooltips, out var newSetBonusLineDestination))
			{
				tooltips.Insert(tooltips.IndexOf(newSetBonusLineDestination) + 1, new TooltipLine(((ModType)this).Mod, "V2SetBonus", player.setBonus)
				{
					OverrideColor = Color.Gold
				});
			}
		}
	}
}
