using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class Eat3DifferentSlimes : PredPlayerGoal
{
	public override string InternalName => "Eat3DifferentSlimes";

	public override int StatPointsFromCompletion => 5;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.Eat3DifferentSlimes.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.Eat3DifferentSlimes.Description";
	}
}
