using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Starter;

public class FirstDrink : PredPlayerGoal
{
	public override string InternalName => "FirstDrink";

	public override int StatPointsFromCompletion => 1;

	public override ProgressionStage Stage => ModContent.GetInstance<StarterStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Starter.FirstDrink.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Starter.FirstDrink.Description";
	}
}
