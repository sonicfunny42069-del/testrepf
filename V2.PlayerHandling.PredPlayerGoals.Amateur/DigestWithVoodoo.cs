using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Amateur;

public class DigestWithVoodoo : PredPlayerGoal
{
	public override string InternalName => "DigestWithVoodoo";

	public override int StatPointsFromCompletion => 10;

	public override ProgressionStage Stage => ModContent.GetInstance<AmateurStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.DigestWithVoodoo.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Amateur.DigestWithVoodoo.Description";
	}

	public override bool Available(Player pred)
	{
		if (!pred.AsV2Player().HasVisitedLocation("hell") && !pred.HasItemInInventoryOrOpenVoidBag(267) && !pred.AsV2Player().HasVisitedLocation("dungeon") && !pred.HasItemInInventoryOrOpenVoidBag(1307))
		{
			return Complete(pred);
		}
		return true;
	}
}
