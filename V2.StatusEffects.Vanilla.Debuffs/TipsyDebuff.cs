using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Debuffs;

public class TipsyDebuff : GlobalBuff
{
	public static float MeleeDamageBoost => 0.1f;

	public static float MeleeCritChanceBoost => 0.02f;

	public static float MeleeAttackSpeedBoost => 0.1f;

	public static int DefensePenalty => 5;

	public static int FishPowerBoost => 5;

	public static float CollectiveCapacityBoost => 0.1f;

	public static float CollectiveChurnRatePenalty => 0.1f;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(25, (GlobalBuff)(object)this);
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		if (type == 25)
		{
			player.tipsy = true;
			ref StatModifier damage = ref player.GetDamage(DamageClass.Melee);
			damage += MeleeDamageBoost;
			player.GetCritChance(DamageClass.Melee) += MeleeCritChanceBoost * 100f;
			player.GetAttackSpeed(DamageClass.Melee) += MeleeAttackSpeedBoost;
			player.statDefense -= DefensePenalty;
			PredPlayer predPlayer = player.AsPred();
			predPlayer.SwallowCapacityModifier += CollectiveCapacityBoost;
			PredPlayer predPlayer2 = player.AsPred();
			predPlayer2.StomachCapacityModifier += CollectiveCapacityBoost;
			PredPlayer predPlayer3 = player.AsPred();
			predPlayer3.DigestionTickRateModifier *= 1f - CollectiveChurnRatePenalty;
			PredPlayer predPlayer4 = player.AsPred();
			predPlayer4.PreyAbsorptionRateModifier *= 1f - CollectiveChurnRatePenalty;
		}
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 25)
		{
			rare = 4;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Debuffs.Tipsy.Description", (object)new
			{
				TipsyMeleeDamageBonus = MeleeDamageBoost.ToPercentage(2),
				TipsyMeleeCritChanceBonus = MeleeCritChanceBoost.ToPercentage(2),
				TipsyMeleeAttackSpeedBonus = MeleeAttackSpeedBoost.ToPercentage(2),
				TipsyDefenseCut = DefensePenalty,
				TipsyFishPowerBonus = FishPowerBoost,
				TipsyCapacityBonus = CollectiveCapacityBoost.ToPercentage(2),
				TipsyChurnRateCut = CollectiveChurnRatePenalty.ToPercentage(2)
			});
		}
	}
}
