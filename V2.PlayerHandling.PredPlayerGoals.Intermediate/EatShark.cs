using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Intermediate;

public class EatShark : PredPlayerGoal
{
	public override string InternalName => "EatShark";

	public override int StatPointsFromCompletion => 7;

	public override ProgressionStage Stage => ModContent.GetInstance<IntermediateStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatShark.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatShark.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("beach"))
		{
			return Complete(pred);
		}
		return true;
	}
}
