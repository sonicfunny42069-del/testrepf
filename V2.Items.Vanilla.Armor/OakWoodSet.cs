using Terraria;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Vanilla.Armor;

public class OakWoodSet : ArmorSetDefinition
{
	public override (int? head, int? body, int? legs) RequiredEquipment => (head: 727, body: 728, legs: 729);

	public override string SetBonusDescriptionKey => "Vanilla.Armor.OakWood.SetBonus";

	public override object SetBonusDescriptionVariables => new { };

	public override void ApplySetBonus(Player player)
	{
		player.AddHealthRegenEffect(0.0, natural: false, null, ModifyTotalHealthRegen);
	}

	public static void ModifyTotalHealthRegen(Player player, ref double naturalRegenAdditive, ref double naturalRegenMultiplicative, ref double artificialRegenAdditive, ref double artificialRegenMultiplicative)
	{
		naturalRegenAdditive += 0.05000000074505806;
		if ((double)((Entity)player).position.Y < Main.worldSurface && player.behindBackWall && Main.dayTime)
		{
			naturalRegenAdditive += 0.05000000074505806;
		}
	}
}
