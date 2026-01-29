using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Skilled;

public class EatObserver : PredPlayerGoal
{
	public override string InternalName => "EatObserver";

	public override int StatPointsFromCompletion => 21;

	public override ProgressionStage Stage => ModContent.GetInstance<SkilledStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Skilled.EatObserver.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Skilled.EatObserver.Description";
	}
}
