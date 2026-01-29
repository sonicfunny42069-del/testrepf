using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.NPCs;
using V2.PlayerHandling;
using V2.Projectiles;

namespace V2.Core;

public static class EntityExtensions
{
	public static Vector2 TrueCenter(this Entity entity)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		return new Vector2(entity.position.X + (float)entity.width / 2f, entity.position.Y + (float)entity.height / 2f);
	}

	public static double GetBellySize(this Entity entity)
	{
		Player player = (Player)(object)((entity is Player) ? entity : null);
		if (player != null)
		{
			return player.AsPred().StomachSize;
		}
		NPC npc = (NPC)(object)((entity is NPC) ? entity : null);
		if (npc != null)
		{
			return npc.AsPred().GetVisualBellySize(npc);
		}
		return 0.0;
	}

	public static void AddStatus(this Entity entity, int statusID, int intendedTime, bool fromDigestingSomething = false)
	{
		intendedTime++;
		Player playerPred = (Player)(object)((entity is Player) ? entity : null);
		if (playerPred != null)
		{
			if (fromDigestingSomething)
			{
				intendedTime = ((!Main.debuff[statusID]) ? ((int)Math.Round((double)intendedTime * playerPred.AsPred().BuffExtensionFactor)) : ((int)Math.Round((double)intendedTime / playerPred.AsPred().DebuffDisextensionFactor)));
			}
			playerPred.AddBuff(statusID, intendedTime, true, false);
		}
		else
		{
			NPC NPCPred = (NPC)(object)((entity is NPC) ? entity : null);
			if (NPCPred != null)
			{
				NPCPred.AddBuff(statusID, intendedTime, false);
			}
		}
	}

	public static VoreTracker CurrentCaptor(this Entity entity)
	{
		Player player = (Player)(object)((entity is Player) ? entity : null);
		if (player != null)
		{
			VoreTracker tracker = ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault((VoreTracker x) => x.Prey.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					Player val = (Player)(object)((instance is Player) ? instance : null);
					if (val != null)
					{
						return ((Entity)val).whoAmI == ((Entity)player).whoAmI;
					}
				}
				return false;
			}) || x.PreyQueue.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					Player val = (Player)(object)((instance is Player) ? instance : null);
					if (val != null)
					{
						return ((Entity)val).whoAmI == ((Entity)player).whoAmI;
					}
				}
				return false;
			}));
			if (tracker != null)
			{
				return tracker;
			}
			return null;
		}
		NPC npc = (NPC)(object)((entity is NPC) ? entity : null);
		if (npc != null)
		{
			VoreTracker tracker2 = ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault((VoreTracker x) => x.Prey.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					NPC val = (NPC)(object)((instance is NPC) ? instance : null);
					if (val != null)
					{
						return ((Entity)val).whoAmI == ((Entity)npc).whoAmI;
					}
				}
				return false;
			}) || x.PreyQueue.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					NPC val = (NPC)(object)((instance is NPC) ? instance : null);
					if (val != null)
					{
						return ((Entity)val).whoAmI == ((Entity)npc).whoAmI;
					}
				}
				return false;
			}));
			if (tracker2 != null)
			{
				return tracker2;
			}
			return null;
		}
		Projectile projectile = (Projectile)(object)((entity is Projectile) ? entity : null);
		if (projectile != null)
		{
			VoreTracker tracker3 = ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault((VoreTracker x) => x.Prey.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					Projectile val = (Projectile)(object)((instance is Projectile) ? instance : null);
					if (val != null)
					{
						return ((Entity)val).whoAmI == ((Entity)projectile).whoAmI;
					}
				}
				return false;
			}) || x.PreyQueue.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					Projectile val = (Projectile)(object)((instance is Projectile) ? instance : null);
					if (val != null)
					{
						return ((Entity)val).whoAmI == ((Entity)projectile).whoAmI;
					}
				}
				return false;
			}));
			if (tracker3 != null)
			{
				return tracker3;
			}
			return null;
		}
		Item item = (Item)(object)((entity is Item) ? entity : null);
		if (item != null)
		{
			VoreTracker tracker4 = ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault((VoreTracker x) => x.Prey.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					Item val = (Item)(object)((instance is Item) ? instance : null);
					if (val != null && val.type == item.type && val.stack == item.stack)
					{
						return val == item;
					}
				}
				return false;
			}) || x.PreyQueue.Any(delegate(PreyData y)
			{
				if (!y.NoHealth)
				{
					Entity instance = y.Instance;
					Item val = (Item)(object)((instance is Item) ? instance : null);
					if (val != null && val.type == item.type && val.stack == item.stack)
					{
						return val == item;
					}
				}
				return false;
			}));
			if (tracker4 != null)
			{
				return tracker4;
			}
			return null;
		}
		return null;
	}

	public static int GetPredStat(this Entity entity, string predStat)
	{
		Player player = (Player)(object)((entity is Player) ? entity : null);
		if (player != null)
		{
			return predStat switch
			{
				"GLP" => player.AsPred().GLP.Total, 
				"TUM" => player.AsPred().TUM.Total, 
				"ACI" => player.AsPred().ACI.Total, 
				"ABS" => player.AsPred().ABS.Total, 
				_ => 0, 
			};
		}
		NPC npc = (NPC)(object)((entity is NPC) ? entity : null);
		if (npc != null)
		{
			return (int)Math.Max(0.0, Math.Floor(Math.Max(npc.AsPred().MaxStomachCapacity - 0.8, 0.0) / 0.04));
		}
		Projectile projectile = (Projectile)(object)((entity is Projectile) ? entity : null);
		if (projectile != null)
		{
			return (int)Math.Max(0.0, Math.Floor(Math.Max(projectile.AsPred().MaxStomachCapacity - 0.8, 0.0) / 0.04));
		}
		return 0;
	}

	public static double StruggleStrength(this Entity entity)
	{
		return ((Player)(object)((entity is Player) ? entity : null))?.AsFood().StruggleStrength ?? ((NPC)(object)((entity is NPC) ? entity : null))?.AsFood().StruggleStrength ?? ((Projectile)(object)((entity is Projectile) ? entity : null))?.AsFood().StruggleStrength ?? 0.0;
	}
}
