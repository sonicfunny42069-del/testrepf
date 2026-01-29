using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Intermediate;

public class EatIceGolem : PredPlayerGoal
{
	public override string InternalName => "EatIceGolem";

	public override int StatPointsFromCompletion => 20;

	public override ProgressionStage Stage => ModContent.GetInstance<IntermediateStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatIceGolem.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Intermediate.EatIceGolem.Description";
	}

	public override bool Available(Player pred)
	{
		if (!Main.hardMode || !pred.AsV2Player().HasVisitedLocation("snowing"))
		{
			return Complete(pred);
		}
		return true;
	}
}
