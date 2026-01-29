using V2.Core;
using V2.StatusEffects.Vanilla.Buffs;

namespace V2.Items.Vanilla.Consumables.Potions;

public class SwiftnessPotion : PotionTemplate
{
	public override string TooltipTranslationKey => "Vanilla.Consumables.Potions.Swiftness";

	public override int DigestedPotionEffectID => 3;

	public override int DigestedPotionEffectDuration => V2Utils.SensibleTime(0, 8);

	public override int AppliesToPotionItem => 290;

	public override dynamic TooltipVariables()
	{
		return new
		{
			SwiftnessPotionMoveSpeedBonus = SwiftnessBuff.MoveSpeedBonus.ToPercentage(2),
			SwiftnessPotionStomachWeightReduction = SwiftnessBuff.StomachWeightReduction.ToPercentage(2)
		};
	}
}
