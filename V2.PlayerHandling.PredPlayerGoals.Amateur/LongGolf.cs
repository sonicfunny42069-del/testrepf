using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class LongGolf : PredPlayerGoal
{
	public override string InternalName => "LongGolf";

	public override int StatPointsFromCompletion => 5;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.LongGolf.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.LongGolf.Description";
	}
}
