using V2.Core;
using V2.StatusEffects.Vanilla.Buffs;

namespace V2.Items.Vanilla.Consumables.Potions;

public class WrathPotion : PotionTemplate
{
	public override string TooltipTranslationKey => "Vanilla.Consumables.Potions.Wrath";

	public override int DigestedPotionEffectID => 117;

	public override int DigestedPotionEffectDuration => V2Utils.SensibleTime(0, 3);

	public override int AppliesToPotionItem => 2349;

	public override dynamic TooltipVariables()
	{
		return new
		{
			WrathPotionDamageBoost = WrathBuff.DamageBonus.ToPercentage(2),
			WrathPotionTUMBoost = WrathBuff.TUMBonus,
			WrathPotionACIBoost = WrathBuff.ACIBonus
		};
	}
}
