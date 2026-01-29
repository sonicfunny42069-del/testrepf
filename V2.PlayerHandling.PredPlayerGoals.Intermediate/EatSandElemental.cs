using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Intermediate;

public class EatSandElemental : PredPlayerGoal
{
	public override string InternalName => "EatSandElemental";

	public override int StatPointsFromCompletion => 20;

	public override ProgressionStage Stage => ModContent.GetInstance<IntermediateStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatSandElemental.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatSandElemental.Description";
	}

	public override bool Available(Player pred)
	{
		if (!Main.hardMode || !pred.AsV2Player().HasVisitedLocation("sandstorm"))
		{
			return Complete(pred);
		}
		return true;
	}
}
