using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class DrinkHoney : PredPlayerGoal
{
	public override string InternalName => "DrinkHoney";

	public override int StatPointsFromCompletion => 2;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.DrinkHoney.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.DrinkHoney.Description";
	}
}
