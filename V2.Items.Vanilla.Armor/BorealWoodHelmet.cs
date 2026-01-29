using System;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Armor;

public class BorealWoodHelmet : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 2509;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 120;
		item.AsFood().Size = 0.3;
		PreyItem preyItem = item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		return direct;
	}
}
