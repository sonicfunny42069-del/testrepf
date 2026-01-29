using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace V2.PlayerHandling.PredPlayerGoals.Beginner;

public class EatPinky : PredPlayerGoal
{
	public override string InternalName => "EatPinky";

	public override Texture2D IncompleteTexture => ModContent.Request<Texture2D>("V2/PlayerHandling/PredPlayerGoals/Beginner/EatPinky_Incomplete", (AssetRequestMode)2).Value;

	public override Texture2D CompleteTexture => ModContent.Request<Texture2D>("V2/PlayerHandling/PredPlayerGoals/Beginner/EatPinky_Complete", (AssetRequestMode)2).Value;

	public override int StatPointsFromCompletion => 2;

	public override ProgressionStage Stage => ModContent.GetInstance<BeginnerStage>();

	public override string DisplayName(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatPinky.Name";
	}

	public override string Description(Player pred)
	{
		return "Mods.V2.PredPlayerGoals.Beginner.EatPinky.Description";
	}
}
