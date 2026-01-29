using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class TooFull : PredPlayerGoal
{
	public static double FullnessThreshold => 0.9;

	public static int TimeThreshold => V2Utils.SensibleTime(0, 1);

	public override string InternalName => "TooFull";

	public override int StatPointsFromCompletion => 1;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.TooFull.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.TooFull.Description";
	}
}
