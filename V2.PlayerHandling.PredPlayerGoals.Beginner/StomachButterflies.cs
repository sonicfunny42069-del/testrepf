using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class StomachButterflies : PredPlayerGoal
{
	public override string InternalName => "StomachButterflies";

	public override int StatPointsFromCompletion => 2;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.StomachButterflies.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.StomachButterflies.Description";
	}
}
