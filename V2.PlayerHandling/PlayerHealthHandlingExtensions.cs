using Terraria;
using V2.Core;

namespace V2.PlayerHandling;

public static class PlayerHealthHandlingExtensions
{
	public static void AddHealthRegenEffect(this Player player, DelegateHealthRegenPerSecond healthPerSecond, bool natural = false, DelegateHealthRegenModifyHealthRegenTime modifyHealthRegenTimeMethod = null, DelegateHealthRegenModifyTotalHealthRegen modifyTotalHealthRegenMethod = null, DelegateHealthRegenOnHealthAdjustment onHealthAdjustmentMethod = null)
	{
		player.AsV2Player().HealthRegenEffects.Add(new HealthRegenEffect(healthPerSecond, natural, modifyHealthRegenTimeMethod, modifyTotalHealthRegenMethod, onHealthAdjustmentMethod));
	}

	public static void AddHealthRegenEffect(this Player player, double healthPerSecond, bool natural = false, DelegateHealthRegenModifyHealthRegenTime modifyHealthRegenTimeMethod = null, DelegateHealthRegenModifyTotalHealthRegen modifyTotalHealthRegenMethod = null, DelegateHealthRegenOnHealthAdjustment onHealthAdjustmentMethod = null)
	{
		player.AsV2Player().HealthRegenEffects.Add(new HealthRegenEffect(healthPerSecond, natural, modifyHealthRegenTimeMethod, modifyTotalHealthRegenMethod, onHealthAdjustmentMethod));
	}
}
