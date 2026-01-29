using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.StatusEffects.Voraria.Buffs;

namespace V2.Items.Vanilla.Accessories;

public class HealthRegenAndPotionCooldownBand : GlobalItem
{
	public static double WornHealthRegenFlat => 1.0;

	public static double DigestingHealthRegenFlat => 2.0;

	public static int DigestingEffectTime => V2Utils.SensibleTime(0, 10);

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 860;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 1500;
		item.AsFood().Size = 0.08;
		item.AsFood().AcidResistTier = 1;
		GeneralItem generalItem = item.AsAnItem();
		generalItem.AccessoryEffectCode = (GeneralItem.DelegateAccessoryEffectCode)Delegate.Combine(generalItem.AccessoryEffectCode, new GeneralItem.DelegateAccessoryEffectCode(UpdateHealthRegenAndPotionCooldownBand));
		item.lifeRegen = 0;
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		PreyItem preyItem2 = item.AsFood();
		preyItem2.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem2.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static void UpdateHealthRegenAndPotionCooldownBand(Item item, Player player, bool hideVisual)
	{
		player.AddHealthRegenEffect(WornHealthRegenFlat);
		player.pStone = true;
	}

	public static void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		if (dead)
		{
			((pred is Player) ? pred : null)?.AddStatus(ModContent.BuffType<CharmofMythsChurnBuff>(), DigestingEffectTime, fromDigestingSomething: true);
		}
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		return direct;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		_ = Main.player[Main.myPlayer];
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Accessories.HealthRegenAndPotionCooldownBand", new
		{
			HealthRegenBandIIWornHealthRegen = WornHealthRegenFlat,
			HealthRegenBandIIEatenHealthRegen = DigestingHealthRegenFlat
		});
	}
}
