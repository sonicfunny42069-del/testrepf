using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatFirstLifeCrystal : PredPlayerGoal
{
	public override string InternalName => "EatFirstLifeCrystal";

	public override int StatPointsFromCompletion => 1;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatFirstLifeCrystal.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatFirstLifeCrystal.Description";
	}
}
