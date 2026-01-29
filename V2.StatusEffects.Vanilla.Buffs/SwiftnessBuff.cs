using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class SwiftnessBuff : GlobalBuff
{
	public static float MoveSpeedBonus => 0.25f;

	public static float StomachWeightReduction => 0.05f;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(3, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 3;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (type == 117)
		{
			player.moveSpeed += MoveSpeedBonus;
			PredPlayer predPlayer = player.AsPred();
			predPlayer.StomachWeightModifier *= 1f - StomachWeightReduction;
		}
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 117)
		{
			rare = 10;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.Swiftness.Description", (object)new
			{
				SwiftnessBuffMoveSpeedBonus = MoveSpeedBonus.ToPercentage(2),
				SwiftnessBuffStomachWeightReduction = StomachWeightReduction.ToPercentage(2)
			});
		}
	}
}
