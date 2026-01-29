using Terraria;
using Terraria.Localization;

namespace V2.PlayerHandling.PredPlayerGoals;

public class AmateurStage : ProgressionStage
{
	public override string DisplayName => Language.GetTextValue("Mods.V2.PredPlayerGoals.Amateur.Name");

	public override string DisplaySubtitle => Language.GetTextValue("Mods.V2.PredPlayerGoals.Amateur.Subtitle");

	public override string Description => Language.GetTextValue("Mods.V2.PredPlayerGoals.Amateur.Description");

	public override string FooterAdvice => Language.GetTextValue("Mods.V2.PredPlayerGoals.Amateur.FooterAdvice");

	public override string UnlockCondition => Language.GetTextValue("Mods.V2.PredPlayerGoals.Amateur.UnlockCondition");

	public override double Order => 2.0;

	public override bool Available(Player pred)
	{
		if (!NPC.downedSlimeKing)
		{
			return NPC.downedBoss1;
		}
		return true;
	}
}
