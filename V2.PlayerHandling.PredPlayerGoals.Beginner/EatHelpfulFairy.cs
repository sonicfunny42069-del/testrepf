using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatHelpfulFairy : PredPlayerGoal
{
	public override string InternalName => "EatHelpfulFairy";

	public override int StatPointsFromCompletion => 7;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatHelpfulFairy.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatHelpfulFairy.Description";
	}
}
