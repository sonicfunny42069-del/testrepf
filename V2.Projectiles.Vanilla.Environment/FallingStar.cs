using System;
using Terraria;
using Terraria.ModLoader;
using V2.PlayerHandling.PredPlayerGoals.Amateur;

namespace V2.Projectiles.Vanilla.Environment;

public class FallingStar : GlobalProjectile
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		return entity.type == 12;
	}

	public override void SetDefaults(Projectile projectile)
	{
		projectile.AsFood().DefinedSize = 0.63;
		projectile.AsFood().MaxHealth = 100.0;
		projectile.AsFood().Health = 100.0;
		PreyProjectile preyProjectile = projectile.AsFood();
		preyProjectile.OnSwallowedBy = (PreyProjectile.DelegateOnSwallowedBy)Delegate.Combine(preyProjectile.OnSwallowedBy, new PreyProjectile.DelegateOnSwallowedBy(OnSwallowedByPlayer_GiveFallingStarGoal));
	}

	public static void OnSwallowedByPlayer_GiveFallingStarGoal(Projectile projectile, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<CatchFallingStar>().TrySetCompletion(predPlayer);
		}
	}
}
