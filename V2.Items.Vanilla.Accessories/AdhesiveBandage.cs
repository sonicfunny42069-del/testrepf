using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Vanilla.Accessories;

public class AdhesiveBandage : GlobalItem
{
	public static float SoftenedBuildupReduction => 0.075f;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 885;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 90;
		item.AsFood().Size = 0.07;
		item.AsFood().AcidResistTier = 0;
		GeneralItem generalItem = item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateAdhesiveBandage));
		PreyItem preyItem = item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static void UpdateAdhesiveBandage(Item item, Player player, bool hideVisual)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		player.buffImmune[30] = true;
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.SoftenedDigestionDamageModifier *= 1f - SoftenedBuildupReduction;
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		return true;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.player[Main.myPlayer];
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Accessories.AdhesiveBandage", new
		{
			AdhesiveBandageSoftenedBuildupReduction = SoftenedBuildupReduction.ToPercentage(2)
		});
	}
}
