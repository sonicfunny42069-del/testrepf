using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class RapidHealingBuff : GlobalBuff
{
	public static double HealthRegenFlat => 2.5;

	public static double NaturalRegenTimeBonus => 0.15;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(58, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 58;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 58)
		{
			player.AddHealthRegenEffect(HealthRegenFlat, natural: false, ModifyHealthRegenTime);
		}
	}

	public static void ModifyHealthRegenTime(Player player, ref double healthRegenTime)
	{
		healthRegenTime += NaturalRegenTimeBonus;
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 58)
		{
			rare = 3;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.RapidHealing.Description", (object)new
			{
				RapidHealingRegenFlat = HealthRegenFlat.CastToDecimalPlaces(2),
				RapidHealingNaturalRegenBuildupSpeed = NaturalRegenTimeBonus.ToPercentage(2)
			});
		}
	}
}
