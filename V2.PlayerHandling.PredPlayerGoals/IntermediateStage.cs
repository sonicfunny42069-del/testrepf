using Terraria;
using Terraria.Localization;

namespace V2.PlayerHandling.PredPlayerGoals;

public class IntermediateStage : ProgressionStage
{
	public override string DisplayName => Language.GetTextValue("Mods.V2.PredPlayerGoals.Intermediate.Name");

	public override string DisplaySubtitle => Language.GetTextValue("Mods.V2.PredPlayerGoals.Intermediate.Subtitle");

	public override string Description => Language.GetTextValue("Mods.V2.PredPlayerGoals.Intermediate.Description");

	public override string FooterAdvice => Language.GetTextValue("Mods.V2.PredPlayerGoals.Intermediate.FooterAdvice");

	public override string UnlockCondition => Language.GetTextValue("Mods.V2.PredPlayerGoals.Intermediate.UnlockCondition");

	public override double Order => 3.0;

	public override bool Available(Player pred)
	{
		return NPC.downedBoss3;
	}
}
