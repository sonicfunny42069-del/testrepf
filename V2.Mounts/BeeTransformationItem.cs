using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Mounts;

[AutoloadEquip(/*Could not decode attribute arguments.*/)]
public class BeeTransformationItem : ModItem
{
	public static int MaxTumSize => 4;

	public static double WeightGainRatio => 0.005;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Mounts.BeeTransformationItem");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Mounts.BeeTransformationItem.Short");

	public override string Texture => "V2/Items/UnspritedItem";

	public static int GetVisualWeightStage(Player player)
	{
		return Math.Min((int)Math.Floor(0.8 * Math.Sqrt(player.AsPred().BeeTransformation_ExtraWeight)), 1);
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		Sets.Stats[((ModItem)this).Item.wingSlot] = new WingStats(220, 0.8f, 0.8f, false, -1f, 1f);
		DrawAnimationVertical anim = new DrawAnimationVertical(6, 12, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 8;
		((ModItem)this).Item.value = Item.sellPrice(0, 3, 15, 0);
	}

	public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
	{
		speed = 4f;
		acceleration = 0.3f;
	}

	public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
	{
		ascentWhenFalling = 0.85f;
		ascentWhenRising = 0.15f;
		maxCanAscendMultiplier = 1f;
		maxAscentMultiplier = 2f;
		constantAscend = 0.135f;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.AsV2Player().BeeTransformation = true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Mounts.BeeTransformationItem", new { });
	}
}
