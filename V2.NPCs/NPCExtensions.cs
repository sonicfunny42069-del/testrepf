using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling;
using V2.Projectiles;
using V2.StatusEffects.Voraria.Debuffs;

namespace V2.NPCs;

public static class NPCExtensions
{
	public static bool IsFoodFor(this NPC npc, Entity pred)
	{
		if (((Entity)(object)npc).CurrentCaptor() == null)
		{
			return false;
		}
		NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
		if (predNPC != null)
		{
			if (PredNPC.GetStomachTracker(predNPC) == null)
			{
				return false;
			}
			return ((Entity)(object)npc).CurrentCaptor() == PredNPC.GetStomachTracker(predNPC);
		}
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			if (predPlayer.AsPred().StomachTracker == null)
			{
				return false;
			}
			return ((Entity)(object)npc).CurrentCaptor() == predPlayer.AsPred().StomachTracker;
		}
		Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
		if (predProjectile != null)
		{
			if (PredProjectile.GetStomachTracker(predProjectile) == null)
			{
				return false;
			}
			return ((Entity)(object)npc).CurrentCaptor() == PredProjectile.GetStomachTracker(predProjectile);
		}
		return false;
	}

	public static void SwitchToPattern<T>(this NPC npc, Entity target) where T : NPCBehaviorPattern, new()
	{
		npc.AsV2NPC().BehaviorPattern = new T();
		npc.AsV2NPC().BehaviorPattern.DoBehavior(npc, target);
	}

	public static void TryFindNewTarget(this NPC npc, List<(TargetType, int, TargetPriorityLevel)> specificWhitelistInput = null)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		List<(TargetType, int, TargetPriorityLevel)> specificWhitelist = null;
		if (specificWhitelistInput != null)
		{
			specificWhitelist = new List<(TargetType, int, TargetPriorityLevel)>(specificWhitelistInput);
			if (V2.BlacklistsActive)
			{
				specificWhitelist.RemoveAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.NPC && V2.VoreNPCBlacklist.Contains(x.ID));
				specificWhitelist.RemoveAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.Projectile && V2.VoreProjectileBlacklist.Contains(x.ID));
			}
		}
		List<(int index, TargetType type, int aggro, float dist, TargetPriorityLevel priority)> targetList = new List<(int, TargetType, int, float, TargetPriorityLevel)>();
		Enumerator<Player> enumerator = Main.ActivePlayers.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Player targetPlayer = enumerator.Current;
			if (targetPlayer.dead || targetPlayer.npcTypeNoAggro[npc.type] || targetPlayer.aggro <= -1000)
			{
				continue;
			}
			TargetPriorityLevel priority = TargetPriorityLevel.Neutral;
			bool inSpecificWhitelist = false;
			if (specificWhitelist != null)
			{
				foreach (var (type, _, priorityLevel) in specificWhitelist)
				{
					if (type == TargetType.Player)
					{
						inSpecificWhitelist = true;
						priority = priorityLevel;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist = true;
			}
			if (inSpecificWhitelist)
			{
				float distanceToTarget = ((Entity)npc).Distance(((Entity)(object)targetPlayer).TrueCenter());
				float negativeAggroDistMult = 1f;
				if (targetPlayer.aggro < 0)
				{
					negativeAggroDistMult -= (float)Math.Abs(targetPlayer.aggro) / 1000f;
				}
				bool canTarget = distanceToTarget <= npc.AsV2NPC().TargetRange * negativeAggroDistMult;
				if (npc.AsV2NPC().TargetRequiresLineOfSight)
				{
					canTarget &= Collision.CanHitLine(((Entity)(object)npc).TrueCenter(), ((Entity)npc).width, ((Entity)npc).height, ((Entity)(object)targetPlayer).TrueCenter(), ((Entity)targetPlayer).width, ((Entity)targetPlayer).height);
				}
				if (canTarget)
				{
					targetList.Add((((Entity)targetPlayer).whoAmI, TargetType.Player, targetPlayer.aggro, distanceToTarget, priority));
				}
			}
		}
		Enumerator<NPC> enumerator3 = Main.ActiveNPCs.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			NPC targetNPC = enumerator3.Current;
			if (targetNPC.life <= 0 || targetNPC.AsV2NPC().Aggro <= -1000)
			{
				continue;
			}
			TargetPriorityLevel priority2 = TargetPriorityLevel.Neutral;
			bool inSpecificWhitelist2 = false;
			if (specificWhitelist != null)
			{
				foreach (var (type2, ID, priorityLevel2) in specificWhitelist)
				{
					if (type2 == TargetType.NPC && (ID == targetNPC.type || ID == targetNPC.netID))
					{
						inSpecificWhitelist2 = true;
						priority2 = priorityLevel2;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist2 = true;
			}
			if (inSpecificWhitelist2)
			{
				float distanceToTarget2 = ((Entity)npc).Distance(((Entity)(object)targetNPC).TrueCenter());
				float negativeAggroDistMult2 = 1f;
				if (targetNPC.AsV2NPC().Aggro < 0)
				{
					negativeAggroDistMult2 -= (float)Math.Abs(targetNPC.AsV2NPC().Aggro) / 1000f;
				}
				bool canTarget2 = distanceToTarget2 <= npc.AsV2NPC().TargetRange * negativeAggroDistMult2;
				if (npc.AsV2NPC().TargetRequiresLineOfSight)
				{
					canTarget2 &= Collision.CanHitLine(((Entity)(object)npc).TrueCenter(), ((Entity)npc).width, ((Entity)npc).height, ((Entity)(object)targetNPC).TrueCenter(), ((Entity)targetNPC).width, ((Entity)targetNPC).height);
				}
				if (canTarget2)
				{
					targetList.Add((((Entity)targetNPC).whoAmI, TargetType.NPC, targetNPC.AsV2NPC().Aggro, distanceToTarget2, priority2));
				}
			}
		}
		Enumerator<Projectile> enumerator4 = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator4.MoveNext())
		{
			Projectile targetProjectile = enumerator4.Current;
			if (targetProjectile.AsFood().Health <= 0.0 || targetProjectile.AsV2Proj().Aggro <= -1000)
			{
				continue;
			}
			TargetPriorityLevel priority3 = TargetPriorityLevel.Neutral;
			bool inSpecificWhitelist3 = false;
			if (specificWhitelist != null)
			{
				foreach (var (type3, ID2, priorityLevel3) in specificWhitelist)
				{
					if (type3 == TargetType.Projectile && ID2 == targetProjectile.type)
					{
						inSpecificWhitelist3 = true;
						priority3 = priorityLevel3;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist3 = true;
			}
			if (inSpecificWhitelist3)
			{
				float distanceToTarget3 = ((Entity)npc).Distance(((Entity)(object)targetProjectile).TrueCenter());
				float negativeAggroDistMult3 = 1f;
				if (targetProjectile.AsV2Proj().Aggro < 0)
				{
					negativeAggroDistMult3 -= (float)Math.Abs(targetProjectile.AsV2Proj().Aggro) / 1000f;
				}
				bool canTarget3 = distanceToTarget3 <= npc.AsV2NPC().TargetRange * negativeAggroDistMult3;
				if (npc.AsV2NPC().TargetRequiresLineOfSight)
				{
					canTarget3 &= Collision.CanHitLine(((Entity)(object)npc).TrueCenter(), ((Entity)npc).width, ((Entity)npc).height, ((Entity)(object)targetProjectile).TrueCenter(), ((Entity)targetProjectile).width, ((Entity)targetProjectile).height);
				}
				if (canTarget3)
				{
					targetList.Add((((Entity)targetProjectile).whoAmI, TargetType.Projectile, targetProjectile.AsV2Proj().Aggro, distanceToTarget3, priority3));
				}
			}
		}
		if (targetList.Count <= 0)
		{
			return;
		}
		bool currentlyTargetingSomething = npc.target != -1 && npc.AsV2NPC().TargetType != TargetType.None && npc.AsV2NPC().TargetPriority != TargetPriorityLevel.None;
		targetList = new List<(int, TargetType, int, float, TargetPriorityLevel)>(targetList.OrderByDescending(((int index, TargetType type, int aggro, float dist, TargetPriorityLevel priority) x) => x.priority));
		if (currentlyTargetingSomething && npc.AsV2NPC().TargetPriority >= targetList[0].priority)
		{
			return;
		}
		targetList.RemoveAll(((int index, TargetType type, int aggro, float dist, TargetPriorityLevel priority) x) => x.priority < targetList[0].priority);
		targetList = new List<(int, TargetType, int, float, TargetPriorityLevel)>(targetList.OrderByDescending(((int index, TargetType type, int aggro, float dist, TargetPriorityLevel priority) x) => x.aggro));
		if (currentlyTargetingSomething)
		{
			switch (npc.AsV2NPC().TargetType)
			{
			case TargetType.Player:
				if (Main.player[npc.target].aggro >= targetList[0].aggro)
				{
					return;
				}
				break;
			case TargetType.NPC:
				if (Main.npc[npc.target].AsV2NPC().Aggro >= targetList[0].aggro)
				{
					return;
				}
				break;
			case TargetType.Projectile:
				if (Main.projectile[npc.target].AsV2Proj().Aggro >= targetList[0].aggro)
				{
					return;
				}
				break;
			}
		}
		targetList.RemoveAll(((int index, TargetType type, int aggro, float dist, TargetPriorityLevel priority) x) => x.aggro < targetList[0].aggro);
		targetList = new List<(int, TargetType, int, float, TargetPriorityLevel)>(targetList.OrderBy(((int index, TargetType type, int aggro, float dist, TargetPriorityLevel priority) x) => x.dist));
		npc.target = targetList[0].index;
		npc.AsV2NPC().TargetType = targetList[0].type;
		npc.AsV2NPC().TargetPriority = targetList[0].priority;
	}

	public static void TryVerifyRemainingTarget(this NPC npc, List<(TargetType, int, TargetPriorityLevel)> specificWhitelistInput = null)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		List<(TargetType, int, TargetPriorityLevel)> specificWhitelist = null;
		if (specificWhitelistInput != null)
		{
			specificWhitelist = new List<(TargetType, int, TargetPriorityLevel)>(specificWhitelistInput);
			if (V2.BlacklistsActive)
			{
				specificWhitelist.RemoveAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.NPC && V2.VoreNPCBlacklist.Contains(x.ID));
				specificWhitelist.RemoveAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.Projectile && V2.VoreProjectileBlacklist.Contains(x.ID));
			}
		}
		if (npc.target == -1)
		{
			return;
		}
		switch (npc.AsV2NPC().TargetType)
		{
		case TargetType.Player:
		{
			Player targetPlayer = Main.player[npc.target];
			if (!((Entity)targetPlayer).active || targetPlayer.dead || ((Entity)(object)targetPlayer).CurrentCaptor() != null || (npc.AsV2NPC().TargetRequiresLineOfSight && !Collision.CanHitLine(((Entity)(object)npc).TrueCenter(), ((Entity)npc).width, ((Entity)npc).height, ((Entity)(object)targetPlayer).TrueCenter(), ((Entity)targetPlayer).width, ((Entity)targetPlayer).height)) || specificWhitelist.FindAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.Player).Count == 0)
			{
				npc.AsV2NPC().TargetType = TargetType.None;
				npc.target = -1;
				npc.AsV2NPC().TargetPriority = TargetPriorityLevel.None;
			}
			break;
		}
		case TargetType.NPC:
		{
			NPC targetNPC = Main.npc[npc.target];
			if (!((Entity)targetNPC).active || targetNPC.life <= 0 || ((Entity)(object)targetNPC).CurrentCaptor() != null || (npc.AsV2NPC().TargetRequiresLineOfSight && !Collision.CanHitLine(((Entity)(object)npc).TrueCenter(), ((Entity)npc).width, ((Entity)npc).height, ((Entity)(object)targetNPC).TrueCenter(), ((Entity)targetNPC).width, ((Entity)targetNPC).height)) || specificWhitelist.FindAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.NPC && x.ID == targetNPC.netID).Count == 0)
			{
				npc.AsV2NPC().TargetType = TargetType.None;
				npc.target = -1;
				npc.AsV2NPC().TargetPriority = TargetPriorityLevel.None;
			}
			break;
		}
		case TargetType.Projectile:
		{
			Projectile targetProjectile = Main.projectile[npc.target];
			if (!((Entity)targetProjectile).active || targetProjectile.AsFood().Health <= 0.0 || ((Entity)(object)targetProjectile).CurrentCaptor() != null || (npc.AsV2NPC().TargetRequiresLineOfSight && !Collision.CanHitLine(((Entity)(object)npc).TrueCenter(), ((Entity)npc).width, ((Entity)npc).height, ((Entity)(object)targetProjectile).TrueCenter(), ((Entity)targetProjectile).width, ((Entity)targetProjectile).height)) || specificWhitelist.FindAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.Projectile && x.ID == targetProjectile.type).Count == 0)
			{
				npc.AsV2NPC().TargetType = TargetType.None;
				npc.target = -1;
				npc.AsV2NPC().TargetPriority = TargetPriorityLevel.None;
			}
			break;
		}
		case TargetType.None:
		case TargetType.Other:
			break;
		}
	}

	public static List<NPC> GetNearbyResidentNPCs(this NPC npc, out int npcsWithinHouse, out int npcsWithinVillage)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		List<NPC> list = new List<NPC>();
		npcsWithinHouse = 0;
		npcsWithinVillage = 0;
		Vector2 value = default(Vector2);
		((Vector2)(ref value))._002Ector((float)npc.homeTileX, (float)npc.homeTileY);
		if (npc.homeless)
		{
			((Vector2)(ref value))._002Ector(((Entity)npc).Center.X / 16f, ((Entity)npc).Center.Y / 16f);
		}
		Vector2 value2 = default(Vector2);
		for (int i = 0; i < 200; i++)
		{
			if (i == ((Entity)npc).whoAmI)
			{
				continue;
			}
			NPC nPC = Main.npc[i];
			if (((Entity)nPC).active && nPC.townNPC && !npc.IsNotReallyTownNPC() && !WorldGen.TownManager.CanNPCsLiveWithEachOther_ShopHelper(npc, nPC))
			{
				((Vector2)(ref value2))._002Ector((float)nPC.homeTileX, (float)nPC.homeTileY);
				if (nPC.homeless)
				{
					value2 = ((Entity)nPC).Center / 16f;
				}
				float num = Vector2.Distance(value, value2);
				if (num < 25f)
				{
					list.Add(nPC);
					npcsWithinHouse++;
				}
				else if (num < 120f)
				{
					npcsWithinVillage++;
				}
			}
		}
		return list;
	}

	public static bool IsNotReallyTownNPC(this NPC npc)
	{
		int type = npc.type;
		if (type == 37 || type == 368 || Sets.ActsLikeTownNPC[type])
		{
			return true;
		}
		return false;
	}

	public static void DoContactGulpage(this NPC npc, List<(TargetType, int, TargetPriorityLevel)> specificWhitelistInput = null)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			return;
		}
		List<(TargetType, int, TargetPriorityLevel)> specificWhitelist = null;
		if (specificWhitelistInput != null)
		{
			specificWhitelist = new List<(TargetType, int, TargetPriorityLevel)>(specificWhitelistInput);
			if (V2.BlacklistsActive)
			{
				specificWhitelist.RemoveAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.NPC && V2.VoreNPCBlacklist.Contains(x.ID));
				specificWhitelist.RemoveAll(((TargetType Type, int ID, TargetPriorityLevel PriorityLevel) x) => x.Type == TargetType.Projectile && V2.VoreProjectileBlacklist.Contains(x.ID));
			}
		}
		Rectangle hitbox;
		for (int i = 0; i < Main.maxNPCs; i++)
		{
			NPC preyNPC = Main.npc[i];
			if (!((Entity)preyNPC).active || preyNPC.life <= 0 || ((Entity)preyNPC).whoAmI == ((Entity)npc).whoAmI)
			{
				continue;
			}
			bool inSpecificWhitelist = false;
			if (specificWhitelist != null)
			{
				foreach (var (type, ID, _) in specificWhitelist)
				{
					if (type == TargetType.NPC && ID == preyNPC.netID)
					{
						inSpecificWhitelist = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist = true;
			}
			if (!inSpecificWhitelist)
			{
				continue;
			}
			hitbox = ((Entity)npc).Hitbox;
			if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyNPC).Hitbox))
			{
				bool empressGetsGulped = preyNPC.type == 208;
				if (ModContent.GetInstance<V2ServerConfig>().EasilyEdibleEmpress)
				{
					empressGetsGulped |= new List<int> { 20, 353, 536, 661 }.Contains(preyNPC.type);
				}
				if (npc.type == 636 && empressGetsGulped)
				{
					PredNPC.Swallow(preyNPC, (Entity)(object)npc);
				}
				else
				{
					PredNPC.Swallow(npc, (Entity)(object)preyNPC);
				}
			}
		}
		for (int i2 = 0; i2 < 255; i2++)
		{
			Player preyPlayer = Main.player[i2];
			if (!((Entity)preyPlayer).active || preyPlayer.dead)
			{
				continue;
			}
			bool inSpecificWhitelist2 = false;
			if (specificWhitelist != null)
			{
				foreach (var item in specificWhitelist)
				{
					TargetType type2 = item.Item1;
					if (type2 == TargetType.Player)
					{
						inSpecificWhitelist2 = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist2 = true;
			}
			if (inSpecificWhitelist2)
			{
				hitbox = ((Entity)npc).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyPlayer).Hitbox))
				{
					PredNPC.Swallow(npc, (Entity)(object)preyPlayer);
				}
			}
		}
		for (int i3 = 0; i3 < Main.maxProjectiles; i3++)
		{
			Projectile preyProjectile = Main.projectile[i3];
			if (!((Entity)preyProjectile).active)
			{
				continue;
			}
			bool inSpecificWhitelist3 = false;
			if (specificWhitelist != null)
			{
				foreach (var (type3, ID2, _) in specificWhitelist)
				{
					if (type3 == TargetType.Projectile && ID2 == preyProjectile.type)
					{
						inSpecificWhitelist3 = true;
						break;
					}
				}
			}
			else
			{
				inSpecificWhitelist3 = true;
			}
			if (inSpecificWhitelist3)
			{
				hitbox = ((Entity)npc).Hitbox;
				if (((Rectangle)(ref hitbox)).Intersects(((Entity)preyProjectile).Hitbox))
				{
					PredNPC.Swallow(npc, (Entity)(object)preyProjectile);
				}
			}
		}
	}

	public static int SoftenedStacks(this NPC npc)
	{
		return Math.Min(Softened.MaxStacks, (int)Math.Floor(npc.AsFood().SoftenedDigestionDamageTaken / ((double)npc.lifeMax * Softened.MaxHealthDigestedForOneStack)));
	}

	public static bool CanItemsBeThievedBy(this NPC npc, Entity pred)
	{
		Player playerPred = (Player)(object)((pred is Player) ? pred : null);
		if (playerPred != null && playerPred.AsPred().charmStealPreyLoot)
		{
			return true;
		}
		return false;
	}
}
