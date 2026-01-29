using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace BetterDialogue.UI.DefaultDialogueStyles;

public class Divine : DialogueStyle
{
	public override string DisplayName => "Divine";

	public override string Description => "A special sort of style, reserved for only the treasured inhabitants of the Divine Realm.";

	public override Texture2D DialogueBoxTileSheet => ModContent.Request<Texture2D>("V2/UI/DialogueStyles/Divine_MainBox", (AssetRequestMode)1).Value;

	public override bool CanBeSelected()
	{
		return false;
	}
}
