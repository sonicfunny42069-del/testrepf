using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace V2.Items.Voraria.Weapons.Ranged;

internal class DinnerBlaster : ModItem
{
	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.DefaultToRangedWeapon(ModContent.ProjectileType<Burger>(), AmmoID.None, 20, 14f, true);
		((ModItem)this).Item.DamageType = DamageClass.Generic;
		((ModItem)this).Item.damage = -1;
		((Entity)((ModItem)this).Item).width = 42;
		((Entity)((ModItem)this).Item).height = 26;
		((ModItem)this).Item.rare = 7;
		((ModItem)this).Item.value = Item.buyPrice(0, 35, 0, 0);
		((ModItem)this).Item.UseSound = SoundID.Item61;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Lighting.AddLight(((Entity)player).Center + new Vector2((float)(16 * ((Entity)player).direction), 0f), new Vector3(255f, 255f, 255f) * 0.003f);
		return true;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.DinnerBlaster", new { });
	}
}
