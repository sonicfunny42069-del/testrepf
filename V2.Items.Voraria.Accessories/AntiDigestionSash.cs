using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Accessories;

public class AntiDigestionSash : ModItem
{
	public static float DigestionDefenseBonus => 4f;

	public static float SoftenedBuildupReduction => 0.25f;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Accessories.AntiDigestionSash");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Accessories.AntiDigestionSash.Short");

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
		((ModItem)this).Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.AsFood().MaxHealth = 350;
		((ModItem)this).Item.AsFood().Size = 0.37;
		((ModItem)this).Item.AsFood().AcidResistTier = 1;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 1;
		((ModItem)this).Item.value = Item.buyPrice(0, 1, 0, 0);
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		player.AsFood().TakenDigestionDamageModifier.Flat -= DigestionDefenseBonus;
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.SoftenedDigestionDamageModifier *= 1f - SoftenedBuildupReduction;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Accessories.AntiDigestionSash", new
		{
			AntiDigestionSashDigestionDefenseBonus = DigestionDefenseBonus,
			AntiDigestionSashSoftenedBuildupReduction = SoftenedBuildupReduction.ToPercentage(2)
		});
	}
}
