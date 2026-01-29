using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatAngyFlower : PredPlayerGoal
{
	public override string InternalName => "EatAngyFlower";

	public override int StatPointsFromCompletion => 3;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatAngyFlower.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatAngyFlower.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("windy_day"))
		{
			return Complete(pred);
		}
		return true;
	}
}
