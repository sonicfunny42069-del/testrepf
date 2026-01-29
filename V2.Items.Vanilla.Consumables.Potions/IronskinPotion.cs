namespace V2.Items.Vanilla.Consumables.Potions;

public class IronskinPotion : PotionTemplate
{
	public override string TooltipTranslationKey => "Vanilla.Consumables.Potions.Ironskin";

	public override int DigestedPotionEffectID => 5;

	public override int DigestedPotionEffectDuration => V2Utils.SensibleTime(0, 8);

	public override int AppliesToPotionItem => 292;

	public override dynamic TooltipVariables()
	{
		return new
		{
			IronskinPotionDefenseValue = 8
		};
	}
}
