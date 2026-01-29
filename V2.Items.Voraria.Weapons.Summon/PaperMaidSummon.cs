using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Items.Voraria.Weapons.Summon;

public class PaperMaidSummon : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Weapons.Summon.PaperMaidSummon");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Weapons.Summon.PaperMaidSummon.Short");

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
	}

	public override void SetDefaults()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.damage = 50;
		((ModItem)this).Item.mana = 200;
		((Entity)((ModItem)this).Item).width = 22;
		((Entity)((ModItem)this).Item).height = 38;
		((ModItem)this).Item.useTime = 19;
		((ModItem)this).Item.useAnimation = 19;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.noMelee = true;
		((ModItem)this).Item.knockBack = 5f;
		((ModItem)this).Item.UseSound = SoundID.Item15;
		((ModItem)this).Item.shootSpeed = 10f;
		((ModItem)this).Item.DamageType = DamageClass.Summon;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
		((ModItem)this).Item.rare = 1;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Weapons.Summon.PaperMaidSummon", new
		{
			Name = PaperMaidDetails.Name,
			NeededMinionSlots = PaperMaidDetails.NeededMinionSlots,
			PaperPlateDamage = PaperMaidDetails.PaperPlateDamage.ToPercentage(2),
			SilverwarePerDamage = PaperMaidDetails.SilverwarePerDamage.ToPercentage(2),
			ForkArmorPen = PaperMaidDetails.ForkArmorPen,
			SpoonInorganicDamageBonusPercent = PaperMaidDetails.SpoonInorganicDamageBonus.ToPercentage(2),
			KnifeBleedTime = (double)PaperMaidDetails.KnifeBleedProcDuration / 60.0,
			StomachCapacity = PaperMaidDetails.StomachCapacity,
			StomachacheMeterCapacity = PaperMaidDetails.StomachacheMeterCapacity,
			DigestionDamage = PaperMaidDetails.DigestionDamage.ToPercentage(2),
			DigestionRate = PaperMaidDetails.DigestionRate.ToPercentage(2),
			DigestionBleedRatio = PaperMaidDetails.DigestionBleedRatio.ToPercentage(2)
		});
	}
}
