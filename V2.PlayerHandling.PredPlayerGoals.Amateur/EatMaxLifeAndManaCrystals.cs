using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class EatMaxLifeAndManaCrystals : PredPlayerGoal
{
	public override string InternalName => "EatMaxLifeAndManaCrystals";

	public override int StatPointsFromCompletion => 4;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.EatMaxLifeAndManaCrystals.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.EatMaxLifeAndManaCrystals.Description";
	}

	public override bool Available(Player pred)
	{
		if (pred.ConsumedLifeCrystals <= 0 && pred.ConsumedManaCrystals <= 0)
		{
			return Complete(pred);
		}
		return true;
	}
}
