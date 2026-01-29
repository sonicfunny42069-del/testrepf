using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals;

public abstract class PredPlayerGoal : ModType
{
	public static Rectangle TextureBounds => new Rectangle(0, 0, 52, 52);

	public virtual Texture2D IncompleteTexture => ModContent.Request<Texture2D>("V2/PlayerHandling/PredPlayerGoals/PlaceholderIncomplete", (AssetRequestMode)2).Value;

	public virtual Texture2D CompleteTexture => ModContent.Request<Texture2D>("V2/PlayerHandling/PredPlayerGoals/PlaceholderComplete", (AssetRequestMode)2).Value;

	public abstract string InternalName { get; }

	public abstract int StatPointsFromCompletion { get; }

	public abstract ProgressionStage Stage { get; }

	protected sealed override void Register()
	{
		ModTypeLookup<PredPlayerGoal>.Register(this);
		PredPlayerGoalLoader.PredPlayerGoals.Add(this);
	}

	public abstract string DisplayName(Player pred);

	public virtual Color DisplayNameColor(Player pred)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (!Complete(pred))
		{
			return Color.Red;
		}
		return Color.LimeGreen;
	}

	public abstract string Description(Player pred);

	public virtual bool Available(Player pred)
	{
		return true;
	}

	public void TrySetCompletion(Player pred, bool intendedCompletionState = true)
	{
		if (!pred.AsPred().GoalsCompleted.ContainsKey(InternalName))
		{
			pred.AsPred().GoalsCompleted.Add(InternalName, !intendedCompletionState);
		}
		if (pred.AsPred().GoalsCompleted[InternalName] != intendedCompletionState)
		{
			pred.AsPred().GoalsCompleted[InternalName] = intendedCompletionState;
		}
	}

	public bool Complete(Player pred)
	{
		if (!pred.AsPred().GoalsCompleted.ContainsKey(InternalName))
		{
			pred.AsPred().GoalsCompleted.Add(InternalName, value: false);
		}
		return pred.AsPred().GoalsCompleted[InternalName];
	}
}
