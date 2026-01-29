using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling.PredPlayerGoals.Starter;

namespace V2.PlayerHandling.PredPlayerGoals;

public class BeginnerStage : ProgressionStage
{
	public override string DisplayName => Language.GetTextValue("Mods.V2.PredPlayerGoals.Beginner.Name");

	public override string DisplaySubtitle => Language.GetTextValue("Mods.V2.PredPlayerGoals.Beginner.Subtitle");

	public override string Description => Language.GetTextValue("Mods.V2.PredPlayerGoals.Beginner.Description");

	public override string FooterAdvice => Language.GetTextValue("Mods.V2.PredPlayerGoals.Beginner.FooterAdvice");

	public override string UnlockCondition => Language.GetTextValue("Mods.V2.PredPlayerGoals.Beginner.UnlockCondition");

	public override double Order => 1.0;

	public override bool Available(Player pred)
	{
		if (ModContent.GetInstance<FirstLivePrey>().Complete(pred) && ModContent.GetInstance<FirstItemEaten>().Complete(pred))
		{
			return ModContent.GetInstance<FirstDrink>().Complete(pred);
		}
		return false;
	}
}
