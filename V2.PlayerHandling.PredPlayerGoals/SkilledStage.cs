using Terraria;
using Terraria.Localization;

namespace V2.PlayerHandling.PredPlayerGoals;

public class SkilledStage : ProgressionStage
{
	public override string DisplayName => Language.GetTextValue("Mods.V2.PredPlayerGoals.Skilled.Name");

	public override string DisplaySubtitle => Language.GetTextValue("Mods.V2.PredPlayerGoals.Skilled.Subtitle");

	public override string Description => Language.GetTextValue("Mods.V2.PredPlayerGoals.Skilled.Description");

	public override string FooterAdvice => Language.GetTextValue("Mods.V2.PredPlayerGoals.Skilled.FooterAdvice");

	public override string UnlockCondition => Language.GetTextValue("Mods.V2.PredPlayerGoals.Skilled.UnlockCondition");

	public override double Order => 4.0;

	public override bool Available(Player pred)
	{
		return NPC.downedMechBossAny;
	}
}
