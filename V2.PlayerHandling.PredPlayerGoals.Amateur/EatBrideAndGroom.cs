using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class EatBrideAndGroom : PredPlayerGoal
{
	public override string InternalName => "EatBrideAndGroom";

	public override int StatPointsFromCompletion => 13;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.EatBrideAndGroom.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.EatBrideAndGroom.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("blood_moon"))
		{
			return Complete(pred);
		}
		return true;
	}
}
