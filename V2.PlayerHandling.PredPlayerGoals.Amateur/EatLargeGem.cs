using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class EatLargeGem : PredPlayerGoal
{
	public override string InternalName => "EatLargeGem";

	public override int StatPointsFromCompletion => 7;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.EatLargeGem.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.EatLargeGem.Description";
	}
}
