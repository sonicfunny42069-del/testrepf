using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Intermediate;

public class HoardGemCritters : PredPlayerGoal
{
	public override string InternalName => "HoardGemCritters";

	public override int StatPointsFromCompletion => 11;

	public override ProgressionStage Stage => ModContent.GetInstance<IntermediateStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.HoardGemCritters.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.HoardGemCritters.Description";
	}
}
