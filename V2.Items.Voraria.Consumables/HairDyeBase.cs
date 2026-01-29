using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Consumables;

public abstract class HairDyeBase : ModItem
{
	public virtual bool UsesLegacyShader => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public virtual Color LegacyShaderMethod(Player player, Color newColor, ref bool lighting)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return newColor;
	}

	public override void SetStaticDefaults()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (!Main.dedServ && UsesLegacyShader)
		{
			GameShaders.Hair.BindShader<LegacyHairShaderData>(((ModItem)this).Type, new LegacyHairShaderData().UseLegacyMethod(new ColorProcessingMethod(LegacyShaderMethod)));
		}
	}

	public override void SetDefaults()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		((Entity)((ModItem)this).Item).width = 20;
		((Entity)((ModItem)this).Item).height = 26;
		((ModItem)this).Item.maxStack = Item.CommonMaxStack;
		((ModItem)this).Item.UseSound = SoundID.Item3;
		((ModItem)this).Item.useStyle = 9;
		((ModItem)this).Item.useTurn = true;
		((ModItem)this).Item.useAnimation = 17;
		((ModItem)this).Item.useTime = 17;
		((ModItem)this).Item.consumable = true;
		((ModItem)this).Item.value = Item.sellPrice(0, 1, 0, 0);
		((ModItem)this).Item.rare = 2;
	}
}
