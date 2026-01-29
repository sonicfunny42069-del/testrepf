using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Armor;

public class OakWoodBreastplate : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 728;
	}

	public override void SetDefaults(Item item)
	{
		item.AsAnItem().ArmorEffectCode = OakWoodBreastplateEffect;
		item.AsFood().MaxHealth = 200;
		item.AsFood().Size = 0.5;
		item.defense = 1;
		PreyItem preyItem = item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static void OakWoodBreastplateEffect(Item item, Player player)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if ((double)((Entity)player).position.Y < Main.worldSurface && player.behindBackWall && Main.dayTime)
		{
			player.statDefense = DefenseStat.op_Increment(player.statDefense);
		}
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		return direct;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Armor.OakWood.Chest", new { });
	}
}
