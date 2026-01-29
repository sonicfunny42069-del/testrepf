using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class WrathBuff : GlobalBuff
{
	public static float DamageBonus => 0.1f;

	public static int TUMBonus => 5;

	public static int ACIBonus => 5;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(117, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 117;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (type == 117)
		{
			ref StatModifier damage = ref player.GetDamage(DamageClass.Generic);
			damage += DamageBonus;
			player.AsPred().TUM.Extra += TUMBonus;
			player.AsPred().ACI.Extra += ACIBonus;
		}
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 117)
		{
			rare = 10;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.Wrath.Description", (object)new
			{
				WrathDamageBonus = DamageBonus.ToPercentage(2),
				WrathTUMBonus = TUMBonus,
				WrathACIBonus = ACIBonus
			});
		}
	}
}
