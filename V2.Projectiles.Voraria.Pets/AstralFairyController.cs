using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;

namespace V2.Projectiles.Voraria.Pets;

public class AstralFairyController : ModItem
{
	public override void SetDefaults()
	{
		((ModItem)this).Item.useStyle = 5;
		((ModItem)this).Item.useAnimation = 10;
		((ModItem)this).Item.useTime = 10;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 34;
		((ModItem)this).Item.rare = 11;
		((ModItem)this).Item.value = Item.sellPrice(1, 0, 0, 0);
	}

	public static void OnUse(Player player)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)player).whoAmI != Main.myPlayer)
		{
			return;
		}
		Vector2 position = Main.MouseWorld;
		Projectile astralFairy = null;
		Enumerator<Projectile> enumerator = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Projectile proj = enumerator.Current;
			if (((Entity)proj).active && proj.type == ModContent.ProjectileType<AstralFairy>() && Main.player[proj.owner] == player)
			{
				astralFairy = proj;
			}
		}
		if (astralFairy == null)
		{
			return;
		}
		Rectangle hitbox = default(Rectangle);
		((Rectangle)(ref hitbox))._002Ector((int)position.X - 16, (int)position.Y - 16, 32, 32);
		Enumerator<Item> enumerator2 = Main.ActiveItems.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Item item = enumerator2.Current;
			if (((Entity)item).active && ((Entity)(object)item).CurrentCaptor() == null && ((Rectangle)(ref hitbox)).Intersects(((Entity)item).Hitbox))
			{
				PredProjectile.Swallow(astralFairy, (Entity)(object)item);
			}
		}
		Enumerator<NPC> enumerator3 = Main.ActiveNPCs.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			NPC item2 = enumerator3.Current;
			if (((Entity)item2).active && ((Entity)(object)item2).CurrentCaptor() == null && ((Rectangle)(ref hitbox)).Intersects(((Entity)item2).Hitbox))
			{
				PredProjectile.Swallow(astralFairy, (Entity)(object)item2);
			}
		}
		enumerator = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Projectile item3 = enumerator.Current;
			if (((Entity)item3).active && ((Entity)(object)item3).CurrentCaptor() == null && ((Rectangle)(ref hitbox)).Intersects(((Entity)item3).Hitbox) && item3.type != ModContent.ProjectileType<AstralFairy>())
			{
				PredProjectile.Swallow(astralFairy, (Entity)(object)item3);
			}
		}
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.AstralFairyController", new { });
	}

	public override bool? UseItem(Player player)
	{
		OnUse(player);
		return true;
	}
}
