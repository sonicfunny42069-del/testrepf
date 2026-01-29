using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Vanilla.Consumables;

public class LifeCrystalPlayer : ModPlayer
{
	public override void PreUpdateBuffs()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		((ModPlayer)this).Player.AsPred().TUM.Base += ((ModPlayer)this).Player.ConsumedLifeCrystals;
		if (((ModPlayer)this).Player.ConsumedLifeCrystals == 15)
		{
			PredPlayer predPlayer = ((ModPlayer)this).Player.AsPred();
			predPlayer.StomachWeightModifier *= 1f - LifeCrystal.MaxEatenPermaWeightReduction;
		}
	}
}
