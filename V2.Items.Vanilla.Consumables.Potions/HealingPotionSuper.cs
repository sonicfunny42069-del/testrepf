using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using V2.Core;
using V2.Sounds.MuffledSounds;
using V2.Sounds.Vore;

namespace V2.Items.Vanilla.Consumables.Potions;

public class HealingPotionSuper : GlobalItem
{
	public static int HealAmount => 200;

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == 3544;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = 50;
		item.AsFood().Size = 0.04;
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		PreyItem preyItem2 = item.AsFood();
		preyItem2.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem2.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
		item.AsFood().EdibleOnUse = true;
		item.AsFood().AlwaysEatenByUse = true;
	}

	public static void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		if (dead)
		{
			pred.AddStatus(21, V2Utils.SensibleTime(0, 1), fromDigestingSomething: true);
		}
	}

	public static bool OnBreak(Item item, Entity pred, bool direct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref MuffledMiscSounds.Shatter, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		Player playerPred = (Player)(object)((pred is Player) ? pred : null);
		if (playerPred != null && !playerPred.HasBuff(21))
		{
			playerPred.Heal(HealAmount);
		}
		return true;
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Vanilla.Consumables.Potions.Healing.Super", new
		{
			HealPotionSuperValue = HealAmount
		});
	}
}
