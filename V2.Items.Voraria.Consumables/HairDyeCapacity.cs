using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Consumables;

public class HairDyeCapacity : HairDyeBase
{
	public override bool UsesLegacyShader => true;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.HairDyeCapacity");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.HairDyeCapacity.Short");

	public override Color LegacyShaderMethod(Player player, Color newColor, ref bool lighting)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		if (player.AsPred().Rose)
		{
			return new Color(122, 0, 0);
		}
		double fullnessRatio = player.AsPred().StomachFullness / player.AsPred().StomachCapacity;
		return Color.Lerp(new Color(114, 0, 0), new Color(157, 224, 97), (float)fullnessRatio);
	}

	public override void SetStaticDefaults()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		base.SetStaticDefaults();
		DrawAnimationVertical anim = new DrawAnimationVertical(8, 10, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
		Sets.DrinkParticleColors[((ModItem)this).Type] = (Color[])(object)new Color[3]
		{
			new Color(157, 224, 97),
			new Color(157, 224, 97),
			new Color(157, 224, 97)
		};
	}

	public override void SetDefaults()
	{
		base.SetDefaults();
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.HairDyeCapacity", new { });
	}
}
