using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class RegenerationBuff : GlobalBuff
{
	public static double HealthRegenFlat => 2.0;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(2, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 2;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 2)
		{
			player.AddHealthRegenEffect(HealthRegenFlat);
		}
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 2)
		{
			rare = 4;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.Regeneration.Description", (object)new
			{
				RegenPotionRegenFlat = HealthRegenFlat.CastToDecimalPlaces(2)
			});
		}
	}
}
