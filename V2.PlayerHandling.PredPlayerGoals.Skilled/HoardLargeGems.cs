using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Skilled;

public class HoardLargeGems : PredPlayerGoal
{
	public override string InternalName => "HoardLargeGems";

	public override int StatPointsFromCompletion => 24;

	public override ProgressionStage Stage => ModContent.GetInstance<SkilledStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Skilled.HoardLargeGems.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Skilled.HoardLargeGems.Description";
	}
}
