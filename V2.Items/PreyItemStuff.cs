using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using V2.Core;
using V2.NPCs;

namespace V2.Items;

public static class PreyItemStuff
{
	public static PreyItem AsFood(this Item item)
	{
		if (item.IsAir)
		{
			return null;
		}
		PreyItem result = default(PreyItem);
		if (item.TryGetGlobalItem<PreyItem>(ref result))
		{
			return result;
		}
		return null;
	}

	public static bool TakeDigestionDamage(this Item item, Entity pred, double digestionDamage, bool direct = true, int indirectWhoAmI = -1)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		int trueDigestionDamage = Main.DamageVar((float)digestionDamage, 0f);
		if (ModContent.GetInstance<V2ServerConfig>().DefenseInDigestionCalcs)
		{
			trueDigestionDamage -= item.defense / 2;
		}
		if (trueDigestionDamage < 1)
		{
			trueDigestionDamage = 1;
		}
		item.AsFood().Health -= trueDigestionDamage;
		if (item.type == 267)
		{
			Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				NPC npc = enumerator.Current;
				if (npc.type == 22)
				{
					PreyNPC.TakeDigestionDamage(npc, pred, digestionDamage);
					break;
				}
			}
		}
		if (item.type == 1307)
		{
			Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				NPC npc2 = enumerator.Current;
				if (npc2.type == 54)
				{
					PreyNPC.TakeDigestionDamage(npc2, pred, digestionDamage);
					break;
				}
			}
		}
		if (Main.netMode == 0 && ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
		{
			CombatText digestionText = Main.combatText[CombatText.NewText(((Entity)item).Hitbox, Color.DarkGreen, trueDigestionDamage, false, true)];
			digestionText.position.X = pred.Center.X;
			digestionText.position.X += pred.direction * 14;
			if (pred.direction == -1)
			{
				digestionText.position.X -= ChatManager.GetStringSize(FontAssets.CombatText[0].Value, digestionText.text, new Vector2(digestionText.scale), -1f).X;
			}
			digestionText.position.Y = ((Entity)item).Center.Y;
			digestionText.position.Y += (float)((Entity)item).height / 5f;
			digestionText.velocity.X = (float)pred.direction * 2.5f;
			digestionText.velocity.Y = -4f;
		}
		if (item.AsFood().Health <= 0)
		{
			item.AsFood().Health = 0;
			bool? churnable = item.AsFood().OnBreak?.Invoke(item, pred, direct);
			if (!direct && indirectWhoAmI != -1)
			{
				Player player = Main.player[indirectWhoAmI];
				byte difficulty = player.difficulty;
				bool flag = (uint)(difficulty - 1) <= 1u;
				if (flag || ModContent.GetInstance<V2ServerConfig>().PermaChurnableEquipment)
				{
					((Entity)(object)player).CurrentCaptor().QueueNewPrey(PreyData.NewData(PreyType.Item, item.type, item.AffixName(), item.CalculateSnackSize()));
					return true;
				}
				return false;
			}
			if (churnable.HasValue && !churnable.Value)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static double CalculateSnackSize(this Item item)
	{
		return item.AsFood().Size * (double)item.stack;
	}
}
