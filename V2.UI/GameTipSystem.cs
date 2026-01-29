using System.Collections.Generic;
using Terraria.ModLoader;

namespace V2.UI;

public class GameTipSystem : ModSystem
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void ModifyGameTipVisibility(IReadOnlyList<GameTipData> gameTips)
	{
		gameTips[GameTipID.MagicMirror].Hide();
		gameTips[GameTipID.LavaAndObsidianSkinPotion].Hide();
		gameTips[GameTipID.WiresFromMechanic].Hide();
		gameTips[GameTipID.PartyGirlNeedsOtherNPCsToMoveIn].Hide();
	}
}
