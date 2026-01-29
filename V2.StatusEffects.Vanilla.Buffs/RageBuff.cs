using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class RageBuff : GlobalBuff
{
	public static float CritChanceBonus => 0.1f;

	public static int GLPBonus => 5;

	public static int ABSBonus => 5;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(115, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 115;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 115)
		{
			player.GetCritChance(DamageClass.Generic) += CritChanceBonus;
			player.AsPred().GLP.Extra += GLPBonus;
			player.AsPred().ABS.Extra += ABSBonus;
		}
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 115)
		{
			rare = 10;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.Rage.Description", (object)new
			{
				RageCritChanceBonus = CritChanceBonus.ToPercentage(2),
				RageGLPBonus = GLPBonus,
				RageABSBonus = ABSBonus
			});
		}
	}
}
