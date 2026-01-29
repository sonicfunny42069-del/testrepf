using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Items.Vanilla.Weapons.Melee;

public class FruitcakeChakram : GlobalItem
{
	public static int SwallowDamageToPred => 40;

	public static int PoisonTime => V2Utils.SensibleTime(0, 0, 5);

	public static int WrathTime => V2Utils.SensibleTime(0, 0, 5);

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 1918;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 444;
		item.AsFood().Size = 0.82;
		item.AsFood().MealSizeTextOverride = "Despite its size, it makes for a terrible meal";
		item.AsFood().OnSwallowDamage = 40;
		item.AsFood().OnSwallowDeathReason = "{0} thought fruitcake was a good idea to eat. Ever.";
		item.AsFood().OnSwallowSoreThroatTime = V2Utils.SensibleTime(0, 0, 10);
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
	}

	public static void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		pred.AddStatus(20, PoisonTime, fromDigestingSomething: true);
		pred.AddStatus(117, WrathTime, fromDigestingSomething: true);
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Weapons.Melee.FruitcakeChakram", new
		{
			FruitcakeChakramSwallowDamage = item.AsFood().OnSwallowDamage,
			FruitcakeChakramSoreThroatTime = ((double)item.AsFood().OnSwallowSoreThroatTime / 60.0).CastToDecimalPlaces(2),
			FruitcakeChakramPoisonTime = ((double)PoisonTime / 60.0).CastToDecimalPlaces(2),
			FruitcakeChakramWrathTime = ((double)WrathTime / 60.0).CastToDecimalPlaces(2)
		});
	}
}
