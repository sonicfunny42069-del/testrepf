using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2.Projectiles.Vanilla.Summons.Pets;

public class MiniIceQueen : GlobalProjectile
{
	public override bool InstancePerEntity => true;

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		return entity.type == 898;
	}

	public override void SetDefaults(Projectile projectile)
	{
		projectile.Name = Language.GetTextValue("Mods.V2.Projectiles.DisplayName.Vanilla.Summons.Pets.MiniIceQueen");
		projectile.AsFood().DefinedSize = 0.85;
		projectile.AsFood().MaxHealth = 2500.0;
		projectile.AsFood().Health = 2500.0;
		PreyProjectile preyProjectile = projectile.AsFood();
		preyProjectile.OnKilledByDigestion = (PreyProjectile.DelegateOnKilledByDigestion)Delegate.Combine(preyProjectile.OnKilledByDigestion, new PreyProjectile.DelegateOnKilledByDigestion(PreyProjectile.OnKilledByDigestion_GrantLivePreyGoal));
	}
}
