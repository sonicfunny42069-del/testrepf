using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using V2.Core;
using V2.Sounds.MuffledSounds;
using V2.Sounds.Vore;

namespace V2.Items.Vanilla.Consumables.Potions;

public abstract class PotionTemplate : GlobalItem
{
	public override bool InstancePerEntity => true;

	public abstract string TooltipTranslationKey { get; }

	public abstract int DigestedPotionEffectID { get; }

	public abstract int DigestedPotionEffectDuration { get; }

	public abstract int AppliesToPotionItem { get; }

	public virtual int PotionDurability => 250;

	public virtual double PotionSize => 0.15;

	public override bool AppliesToEntity(Item entity, bool lateInstantiation)
	{
		return entity.type == AppliesToPotionItem;
	}

	public override void SetDefaults(Item item)
	{
		item.AsFood().MaxHealth = PotionDurability;
		item.AsFood().Size = PotionSize;
		PreyItem preyItem = item.AsFood();
		preyItem.UpdateInStomach = (PreyData.DelegateUpdateInStomach)Delegate.Combine(preyItem.UpdateInStomach, new PreyData.DelegateUpdateInStomach(UpdateInStomach));
		PreyItem preyItem2 = item.AsFood();
		preyItem2.OnBreak = (PreyItem.DelegateOnBreak)Delegate.Combine(preyItem2.OnBreak, new PreyItem.DelegateOnBreak(OnBreak));
		item.AsFood().EdibleOnUse = true;
		item.AsFood().AlwaysEatenByUse = true;
	}

	private bool OnBreak(Item item, Entity pred, bool direct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		SoundEngine.PlaySound(ref MuffledMiscSounds.Shatter, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)pred.Center, (SoundUpdateCallback)null);
		return true;
	}

	private void UpdateInStomach(Entity prey, Entity pred, bool dead)
	{
		if (dead)
		{
			pred.AddStatus(DigestedPotionEffectID, DigestedPotionEffectDuration, fromDigestingSomething: true);
		}
	}

	public abstract dynamic TooltipVariables();

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip(TooltipTranslationKey, (object)TooltipVariables());
		tooltips.FirstOrDefault((TooltipLine x) => x.Name == "BuffTime").Hide();
	}
}
