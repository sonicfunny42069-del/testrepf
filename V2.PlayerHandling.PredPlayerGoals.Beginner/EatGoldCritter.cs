using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatGoldCritter : PredPlayerGoal
{
	public override string InternalName => "EatGoldCritter";

	public override int StatPointsFromCompletion => 3;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatGoldCritter.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatGoldCritter.Description";
	}
}
