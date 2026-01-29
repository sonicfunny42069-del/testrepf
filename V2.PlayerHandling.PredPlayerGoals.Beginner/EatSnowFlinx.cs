using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatSnowFlinx : PredPlayerGoal
{
	public override string InternalName => "EatSnowFlinx";

	public override int StatPointsFromCompletion => 2;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatSnowFlinx.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatSnowFlinx.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("underground_tundra"))
		{
			return Complete(pred);
		}
		return true;
	}
}
