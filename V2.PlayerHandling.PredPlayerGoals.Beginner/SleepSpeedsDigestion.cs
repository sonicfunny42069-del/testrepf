using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class SleepSpeedsDigestion : PredPlayerGoal
{
	public static double FlatFullnessThreshold => 0.75;

	public override string InternalName => "SleepSpeedsDigestion";

	public override int StatPointsFromCompletion => 1;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.SleepSpeedsDigestion.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.SleepSpeedsDigestion.Description";
	}
}
