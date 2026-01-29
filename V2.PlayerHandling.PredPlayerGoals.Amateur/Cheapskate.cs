using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class Cheapskate : PredPlayerGoal
{
	public override string InternalName => "Cheapskate";

	public override int StatPointsFromCompletion => 4;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.Cheapskate.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.Cheapskate.Description";
	}

	public override bool Available(Player pred)
	{
		if (!NPC.AnyNPCs(18))
		{
			return Complete(pred);
		}
		return true;
	}
}
