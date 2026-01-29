using V2.StatusEffects.Vanilla.Buffs;

namespace V2.Items.Vanilla.Consumables.Potions;

public class RegenerationPotion : PotionTemplate
{
	public override string TooltipTranslationKey => "Vanilla.Consumables.Potions.Regeneration";

	public override int DigestedPotionEffectID => 2;

	public override int DigestedPotionEffectDuration => V2Utils.SensibleTime(0, 6);

	public override int AppliesToPotionItem => 289;

	public override dynamic TooltipVariables()
	{
		return new
		{
			RegenPotionRegenFlat = RegenerationBuff.HealthRegenFlat
		};
	}
}
