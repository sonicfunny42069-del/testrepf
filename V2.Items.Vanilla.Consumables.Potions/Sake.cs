namespace V2.Items.Vanilla.Consumables.Potions;

public class Sake : PotionTemplate
{
	public override string TooltipTranslationKey => "Vanilla.Consumables.Potions.Sake";

	public override int DigestedPotionEffectID => 25;

	public override int DigestedPotionEffectDuration => V2Utils.SensibleTime(0, 3);

	public override int AppliesToPotionItem => 2266;

	public override dynamic TooltipVariables()
	{
		return new { };
	}
}
