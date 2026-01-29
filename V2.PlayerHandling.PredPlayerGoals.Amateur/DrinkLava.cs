using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class DrinkLava : PredPlayerGoal
{
	public override string InternalName => "DrinkLava";

	public override int StatPointsFromCompletion => 9;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.DrinkLava.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.DrinkLava.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("hell") && !pred.HasItemInInventoryOrOpenVoidBag(207) && pred.lavaMax <= 0)
		{
			return Complete(pred);
		}
		return true;
	}
}
