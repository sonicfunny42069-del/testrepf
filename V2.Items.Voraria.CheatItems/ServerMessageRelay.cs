using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Items.Voraria.CheatItems;

public class ServerMessageRelay : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.CheatItems.ServerMessageRelay");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.CheatItems.ServerMessageRelay.Short");

	public override string Texture => "V2/Items/UnspritedItem";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		DrawAnimationVertical anim = new DrawAnimationVertical(6, 12, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
		((ModItem)this).Item.ResearchUnlockCount = 0;
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = -13;
		((ModItem)this).Item.value = 0;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.CheatItems.ServerMessageRelay", new { });
	}
}
