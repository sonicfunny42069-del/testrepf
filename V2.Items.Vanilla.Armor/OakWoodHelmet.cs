using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace V2.Items.Vanilla.Armor;

public class OakWoodHelmet : GlobalItem
{
	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 727;
	}

	public override void SetDefaults(Item item)
	{
		item.AsAnItem().ArmorEffectCode = OakWoodHelmetEffect;
		item.AsFood().MaxHealth = 120;
		item.AsFood().Size = 0.3;
		item.defense = 1;
		PreyItem preyItem = item.AsFood();
		preyItem.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
	}

	public static void OakWoodHelmetEffect(Item item, Player player)
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
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Armor.OakWood.Head", new { });
	}
}
