using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Vanilla.Consumables;

public class ManaCrystalPlayer : ModPlayer
{
	public override void PreUpdateBuffs()
	{
		((ModPlayer)this).Player.AsPred().ABS.Base += ((ModPlayer)this).Player.ConsumedManaCrystals;
	}
}
