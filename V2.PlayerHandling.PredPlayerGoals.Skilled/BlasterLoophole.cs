using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Skilled;

public class BlasterLoophole : PredPlayerGoal
{
	public override string InternalName => "BlasterLoophole";

	public override int StatPointsFromCompletion => 3;

	public override ProgressionStage Stage => ModContent.GetInstance<SkilledStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Skilled.BlasterLoophole.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Skilled.BlasterLoophole.Description";
	}
}
