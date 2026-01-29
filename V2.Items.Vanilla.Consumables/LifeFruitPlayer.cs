using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Vanilla.Consumables;

public class LifeFruitPlayer : ModPlayer
{
	public override void PreUpdateBuffs()
	{
		((ModPlayer)this).Player.AsPred().TUM.Base += LifeFruit.StomachStrengthBonus * ((ModPlayer)this).Player.ConsumedLifeFruit;
		((ModPlayer)this).Player.AsPred().ACI.Base += LifeFruit.AcidStrengthBonus * ((ModPlayer)this).Player.ConsumedLifeFruit;
	}
}
