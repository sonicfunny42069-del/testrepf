using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class CampfireBuff : GlobalBuff
{
	public static double HealthRegenerationPerSecond => 2.0;

	public static double NaturalHealthRegenerationBuildSpeedIncrease => 0.2;

	public static float DigestionRateIncrease => 0.15f;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(87, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 87;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		if (type == 87)
		{
			player.AddHealthRegenEffect(HealthRegenerationPerSecond, natural: true, CampfireModifyHealthRegenTime);
			PredPlayer predPlayer = player.AsPred();
			predPlayer.DigestionTickRateModifier += DigestionRateIncrease;
		}
	}

	public static void CampfireModifyHealthRegenTime(Player player, ref double healthRegenTime)
	{
		healthRegenTime += NaturalHealthRegenerationBuildSpeedIncrease;
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 87)
		{
			rare = 3;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.Campfire.Description", (object)new
			{
				CampfireRegenFlat = HealthRegenerationPerSecond.CastToDecimalPlaces(2),
				CampfireNaturalRegenBuildupSpeed = NaturalHealthRegenerationBuildSpeedIncrease.ToPercentage(2),
				CampfireDigestionSpeedBonus = DigestionRateIncrease.ToPercentage(2)
			});
		}
	}
}
