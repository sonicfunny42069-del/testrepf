using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Consumables.PermanentUpgrades.Jujus;

public class BlankJuju : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.PermanentUpgrades.Jujus.BlankJuju");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.PermanentUpgrades.Jujus.BlankJuju");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		((ModItem)this).Item.ResearchUnlockCount = 1;
		DrawAnimationVertical anim = new DrawAnimationVertical(8, 2, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
		Sets.ShimmerTransformToItem[((ModItem)this).Type] = ModContent.ItemType<ShimmerJuju>();
	}

	public override void PostUpdate()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Lighting.AddLight(((Entity)((ModItem)this).Item).Center, new Vector3(255f, 255f, 255f) * 0.005f);
	}

	public override void SetDefaults()
	{
		((Entity)((ModItem)this).Item).width = 32;
		((Entity)((ModItem)this).Item).height = 32;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.value = Item.buyPrice(0, 2, 50, 0);
		((ModItem)this).Item.rare = 3;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		_ = Main.LocalPlayer;
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.PermanentUpgrades.Jujus.BlankJuju", new { });
	}
}
