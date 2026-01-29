using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals;

public abstract class ProgressionStage : ModType
{
	public abstract string DisplayName { get; }

	public abstract string DisplaySubtitle { get; }

	public abstract string Description { get; }

	public abstract string FooterAdvice { get; }

	public abstract string UnlockCondition { get; }

	public abstract double Order { get; }

	protected sealed override void Register()
	{
		ModTypeLookup<ProgressionStage>.Register(this);
		PredPlayerGoalLoader.ProgressionStages.Add(this);
	}

	public abstract bool Available(Player pred);
}
