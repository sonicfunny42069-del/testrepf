using Terraria;
using Terraria.Localization;

namespace V2.PlayerHandling.PredPlayerGoals;

public class StarterStage : ProgressionStage
{
	public override string DisplayName => Language.GetTextValue("Mods.V2.PredPlayerGoals.Starter.Name");

	public override string DisplaySubtitle => Language.GetTextValue("Mods.V2.PredPlayerGoals.Starter.Subtitle");

	public override string Description => Language.GetTextValue("Mods.V2.PredPlayerGoals.Starter.Description");

	public override string FooterAdvice => Language.GetTextValue("Mods.V2.PredPlayerGoals.Starter.FooterAdvice");

	public override string UnlockCondition => Language.GetTextValue("Mods.V2.PredPlayerGoals.Starter.UnlockCondition");

	public override double Order => 0.0;

	public override bool Available(Player pred)
	{
		return true;
	}
}
