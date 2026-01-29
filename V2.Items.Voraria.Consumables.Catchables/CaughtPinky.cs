using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs.Vanilla.Forest;

namespace V2.Items.Voraria.Consumables.Catchables;

public class CaughtPinky : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.Catchables.Pinky");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.Catchables.Pinky.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		((ModItem)this).Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.DefaultToCapturedCritter(1);
		((ModItem)this).Item.AsAnItem().ReleasedNPCNetID = -4;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.alpha = 100;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 1, 25, 0);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.Catchables.Pinky", new
		{
			PinkyEatHeal = Pinky.DigestedHeal,
			PinkyEatHappyLength = ((double)Pinky.EatenHappyLength / 60.0).CastToDecimalPlaces(2),
			PinkyEatRegenLength = ((double)Pinky.DigestedRegenTime / 60.0).CastToDecimalPlaces(2)
		});
	}
}
