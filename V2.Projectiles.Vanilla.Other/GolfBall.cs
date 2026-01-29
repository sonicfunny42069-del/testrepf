using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals.Amateur;

namespace V2.Projectiles.Vanilla.Other;

public class GolfBall : GlobalProjectile
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		if (entity.type != 721 && entity.type != 739 && entity.type != 740 && entity.type != 741 && entity.type != 742 && entity.type != 743 && entity.type != 744 && entity.type != 745 && entity.type != 746 && entity.type != 747 && entity.type != 748 && entity.type != 749 && entity.type != 750 && entity.type != 751)
		{
			return entity.type == 752;
		}
		return true;
	}

	public override void SetDefaults(Projectile projectile)
	{
		projectile.AsFood().DefinedSize = 0.05;
		projectile.AsFood().MaxHealth = 70.0;
		projectile.AsFood().Health = 70.0;
		PreyProjectile preyProjectile = projectile.AsFood();
		preyProjectile.OnSwallowedBy = (PreyProjectile.DelegateOnSwallowedBy)Delegate.Combine(preyProjectile.OnSwallowedBy, new PreyProjectile.DelegateOnSwallowedBy(OnSwallowedByNPC_GiveGolfGoal));
	}

	public override void AI(Projectile projectile)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		if (!(((Vector2)(ref ((Entity)projectile).velocity)).Length() > 7f))
		{
			return;
		}
		Rectangle hitboxIGuess = ((Entity)projectile).Hitbox;
		hitboxIGuess.Y += 16;
		Enumerator<NPC> enumerator = Main.ActiveNPCs.GetEnumerator();
		while (enumerator.MoveNext())
		{
			NPC item = enumerator.Current;
			if (projectile != null && ((Entity)projectile).active && ((Entity)(object)projectile).CurrentCaptor() == null && ((Entity)item).active && ((Entity)(object)item).CurrentCaptor() == null && item.AsPred().CanBeForceFed(item) && ((Rectangle)(ref hitboxIGuess)).Intersects(((Entity)item).Hitbox))
			{
				PredNPC.Swallow(item, (Entity)(object)projectile);
			}
		}
		Enumerator<Projectile> enumerator2 = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			Projectile item2 = enumerator2.Current;
			if (projectile != null && ((Entity)projectile).active && ((Entity)(object)projectile).CurrentCaptor() == null && ((Entity)item2).active && ((Entity)(object)item2).CurrentCaptor() == null && item2.AsPred().CanBeForceFed(item2) && ((Rectangle)(ref hitboxIGuess)).Intersects(((Entity)item2).Hitbox))
			{
				PredProjectile.Swallow(item2, (Entity)(object)projectile);
			}
		}
		Enumerator<Player> enumerator3 = Main.ActivePlayers.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			Player item3 = enumerator3.Current;
			if (projectile != null && ((Entity)projectile).active && ((Entity)(object)projectile).CurrentCaptor() == null && ((Entity)item3).active && Main.player[projectile.owner] != item3 && ((Entity)(object)item3).CurrentCaptor() == null && ((Rectangle)(ref hitboxIGuess)).Intersects(((Entity)item3).Hitbox))
			{
				PredPlayer.Swallow(item3, (Entity)(object)projectile);
			}
		}
	}

	public static void OnSwallowedByNPC_GiveGolfGoal(Projectile projectile, Entity pred)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		Player owner = Main.player[projectile.owner];
		if (owner != null && !projectile.npcProj && Utils.Distance(((Entity)owner).Center, pred.Center) >= 2400f)
		{
			ModContent.GetInstance<LongGolf>().TrySetCompletion(owner);
		}
	}
}
