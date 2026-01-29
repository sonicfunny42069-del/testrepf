using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatFlyingFish : PredPlayerGoal
{
	public override string InternalName => "EatFlyingFish";

	public override int StatPointsFromCompletion => 2;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatFlyingFish.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatFlyingFish.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("raining"))
		{
			return Complete(pred);
		}
		return true;
	}
}
