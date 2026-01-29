using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using V2.Core;
using V2.NPCs;
using V2.Projectiles;

namespace V2.PlayerHandling;

public static class PlayerExtensions
{
	public static V2Player AsV2Player(this Player player)
	{
		return player.GetModPlayer<V2Player>();
	}

	public static PredPlayer AsPred(this Player player)
	{
		return player.GetModPlayer<PredPlayer>();
	}

	public static PreyPlayer AsFood(this Player player)
	{
		return player.GetModPlayer<PreyPlayer>();
	}

	public static bool IsFoodFor(this Player player, Entity entity, out bool pastTense)
	{
		pastTense = false;
		NPC predNPC = (NPC)(object)((entity is NPC) ? entity : null);
		if (predNPC != null)
		{
			if (PredNPC.GetStomachTracker(predNPC) == null)
			{
				return false;
			}
			List<PreyData> playerAsPreyList = PredNPC.GetStomachTracker(predNPC).Prey.FindAll((PreyData x) => x.Type == PreyType.Player && x.Instance.whoAmI == ((Entity)player).whoAmI);
			if (playerAsPreyList != null && playerAsPreyList.Count > 0)
			{
				if (playerAsPreyList.FirstOrDefault((PreyData x) => !x.NoHealth) == null)
				{
					pastTense = true;
				}
				return true;
			}
		}
		else
		{
			Player predPlayer = (Player)(object)((entity is Player) ? entity : null);
			if (predPlayer != null)
			{
				List<PreyData> playerAsPreyList2 = predPlayer.AsPred().StomachTracker?.Prey.FindAll((PreyData x) => x.Type == PreyType.Player && x.Instance.whoAmI == ((Entity)player).whoAmI);
				if (playerAsPreyList2 != null && playerAsPreyList2.Count > 0)
				{
					if (playerAsPreyList2.FirstOrDefault((PreyData x) => !x.NoHealth) == null)
					{
						pastTense = true;
					}
					return true;
				}
			}
			else
			{
				Projectile predProjectile = (Projectile)(object)((entity is Projectile) ? entity : null);
				if (predProjectile != null)
				{
					if (PredProjectile.GetStomachTracker(predProjectile) == null)
					{
						return false;
					}
					List<PreyData> playerAsPreyList3 = PredProjectile.GetStomachTracker(predProjectile)?.Prey.FindAll((PreyData x) => x.Type == PreyType.Player && x.Instance.whoAmI == ((Entity)player).whoAmI);
					if (playerAsPreyList3 != null && playerAsPreyList3.Count > 0)
					{
						if (playerAsPreyList3.FirstOrDefault((PreyData x) => !x.NoHealth) == null)
						{
							pastTense = true;
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	public static bool HasEaten(this Player player, string entity, out int howManyTimes)
	{
		howManyTimes = 0;
		if (!player.AsPred().mealCount.ContainsKey(entity))
		{
			return false;
		}
		if (player.AsPred().mealCount[entity] <= 0)
		{
			return false;
		}
		howManyTimes = player.AsPred().mealCount[entity];
		return true;
	}

	public static Vector2 TrueMountedCenter(this Player player)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		return new Vector2(((Entity)player).position.X + (float)((Entity)player).width / 2f, ((Entity)player).position.Y + 21f + player.HeightOffsetHitboxCenter);
	}

	public static bool IsAirborne(this Player player)
	{
		if (player.mount.Active)
		{
			return !Sets.Cart[player.mount.Type];
		}
		if (((Entity)player).velocity.Y == 0f)
		{
			return false;
		}
		if (((Entity)(object)player).CurrentCaptor() != null)
		{
			return false;
		}
		return true;
	}

	public static void ForceDropItem(this Player player, Vector2 position, ref Item item, out Item itemDrop)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		itemDrop = null;
		if (!item.IsAir && !item.favorited)
		{
			int itemDropId = Item.NewItem(((Entity)player).GetSource_Misc("ThrowItem"), (int)position.X, (int)position.Y, ((Entity)player).width, ((Entity)player).height, item, false, false, false);
			itemDrop = Main.item[itemDropId];
			((Entity)itemDrop).velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
			((Entity)itemDrop).velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
			itemDrop.noGrabDelay = 100;
			itemDrop.newAndShiny = false;
			if (Main.netMode == 1)
			{
				NetMessage.SendData(21, -1, -1, (NetworkText)null, itemDropId, 0f, 0f, 0f, 0, 0, 0);
			}
			item.TurnToAir(false);
		}
	}
}
