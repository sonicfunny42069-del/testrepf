using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;

namespace V2.StatusEffects.Vanilla.Buffs;

public class HeartLanternBuff : GlobalBuff
{
	public static double HealthRegenerationBoost => 2.0;

	public override void SetStaticDefaults()
	{
		V2.ModifiedStatusEffects.Add(89, (GlobalBuff)(object)this);
	}

	public override bool RightClick(int type, int buffIndex)
	{
		return type != 89;
	}

	public override void Update(int type, Player player, ref int buffIndex)
	{
		if (type == 89)
		{
			player.AddHealthRegenEffect(HealthRegenerationBoost);
		}
	}

	public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
	{
		if (type == 89)
		{
			rare = 4;
			tip = Language.GetTextValueWith("Mods.V2.StatusEffects.Vanilla.Buffs.HeartLantern.Description", (object)new
			{
				HeartLanternRegenFlat = HealthRegenerationBoost.CastToDecimalPlaces(2)
			});
		}
	}
}
