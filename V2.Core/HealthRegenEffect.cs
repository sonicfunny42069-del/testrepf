using Terraria;

namespace V2.Core;

public struct HealthRegenEffect
{
	public DelegateHealthRegenPerSecond healthPerSecond;

	public bool natural;

	public DelegateHealthRegenModifyHealthRegenTime modifyHealthRegenTimeMethod;

	public DelegateHealthRegenModifyTotalHealthRegen modifyTotalHealthRegenMethod;

	public DelegateHealthRegenOnHealthAdjustment onHealthAdjustmentMethod;

	public HealthRegenEffect()
	{
		healthPerSecond = (Player player) => 0.0;
		natural = false;
		modifyHealthRegenTimeMethod = null;
		modifyTotalHealthRegenMethod = null;
		onHealthAdjustmentMethod = null;
	}

	public HealthRegenEffect(DelegateHealthRegenPerSecond healthPerSecond, bool natural = false, DelegateHealthRegenModifyHealthRegenTime modifyHealthRegenTimeMethod = null, DelegateHealthRegenModifyTotalHealthRegen modifyTotalHealthRegenMethod = null, DelegateHealthRegenOnHealthAdjustment onHealthAdjustmentMethod = null)
	{
		this.healthPerSecond = healthPerSecond;
		this.natural = natural;
		this.modifyHealthRegenTimeMethod = modifyHealthRegenTimeMethod;
		this.modifyTotalHealthRegenMethod = modifyTotalHealthRegenMethod;
		this.onHealthAdjustmentMethod = onHealthAdjustmentMethod;
	}

	public HealthRegenEffect(double healthPerSecond, bool natural = false, DelegateHealthRegenModifyHealthRegenTime modifyHealthRegenTimeMethod = null, DelegateHealthRegenModifyTotalHealthRegen modifyTotalHealthRegenMethod = null, DelegateHealthRegenOnHealthAdjustment onHealthAdjustmentMethod = null)
	{
		this.healthPerSecond = (Player player) => healthPerSecond;
		this.natural = natural;
		this.modifyHealthRegenTimeMethod = modifyHealthRegenTimeMethod;
		this.modifyTotalHealthRegenMethod = modifyTotalHealthRegenMethod;
		this.onHealthAdjustmentMethod = onHealthAdjustmentMethod;
	}
}
