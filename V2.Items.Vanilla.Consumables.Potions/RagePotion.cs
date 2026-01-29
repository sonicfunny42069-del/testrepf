using V2.Core;
using V2.StatusEffects.Vanilla.Buffs;

namespace V2.Items.Vanilla.Consumables.Potions;

public class RagePotion : PotionTemplate
{
	public override string TooltipTranslationKey => "Vanilla.Consumables.Potions.Rage";

	public override int DigestedPotionEffectID => 115;

	public override int DigestedPotionEffectDuration => V2Utils.SensibleTime(0, 3);

	public override int AppliesToPotionItem => 2347;

	public override dynamic TooltipVariables()
	{
		return new
		{
			RagePotionCritChanceBoost = RageBuff.CritChanceBonus.ToPercentage(2),
			RagePotionGLPBoost = RageBuff.GLPBonus,
			RagePotionABSBoost = RageBuff.ABSBonus
		};
	}
}
