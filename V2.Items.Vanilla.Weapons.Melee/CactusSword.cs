using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Items.Vanilla.Weapons.Melee;

public class CactusSword : GlobalItem
{
	public static int ThornsBuffTime => V2Utils.SensibleTime(0, 0, 10);

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 881;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 151;
		item.AsFood().Size = 0.52;
		item.AsFood().OnSwallowDamage = 6;
		item.AsFood().OnSwallowDeathReason = "{0} tried to deepthroat a cactus.";
		item.AsFood().OnSwallowSoreThroatTime = V2Utils.SensibleTime(0, 0, 3, 30);
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		item.AsTaggable().Broadsword = true;
	}

	public static void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		if (dead)
		{
			pred.AddStatus(14, ThornsBuffTime, fromDigestingSomething: true);
		}
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Weapons.Melee.CactusSword", new
		{
			CactusSwordSwallowDamage = item.AsFood().OnSwallowDamage,
			CactusSwordSoreThroatTime = ((double)item.AsFood().OnSwallowSoreThroatTime / 60.0).CastToDecimalPlaces(2),
			CactusSwordThornsTime = ((double)ThornsBuffTime / 60.0).CastToDecimalPlaces(2)
		});
	}
}
