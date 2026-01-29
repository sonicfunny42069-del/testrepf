using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class CatchFallingStar : PredPlayerGoal
{
	public override string InternalName => "CatchFallingStar";

	public override int StatPointsFromCompletion => 7;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.CatchFallingStar.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.CatchFallingStar.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("nighttime"))
		{
			return Complete(pred);
		}
		return true;
	}
}
