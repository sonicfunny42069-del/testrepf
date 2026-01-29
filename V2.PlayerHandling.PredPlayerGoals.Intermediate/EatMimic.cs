using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Intermediate;

public class EatMimic : PredPlayerGoal
{
	public override string InternalName => "EatMimic";

	public override int StatPointsFromCompletion => 12;

	public override ProgressionStage Stage => ModContent.GetInstance<IntermediateStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatMimic.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatMimic.Description";
	}

	public override bool Available(Player pred)
	{
		if (!Main.hardMode)
		{
			return Complete(pred);
		}
		return true;
	}
}
