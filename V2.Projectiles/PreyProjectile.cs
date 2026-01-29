using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using V2.Core;
using V2.PlayerHandling.PredPlayerGoals.Starter;

namespace V2.Projectiles;

public class PreyProjectile : GlobalProjectile
{
	public delegate void DelegateOnSwallowedBy(Projectile projectile, Entity pred);

	public delegate void DelegatePreyAI(Projectile projectile, Entity pred);

	public delegate void DelegateOnKilledByDigestion(Projectile projectile, Entity pred);

	public SoundStyle? DigestingHitSound;

	public SoundStyle? DigestedDeathSound;

	public bool CannotBeEatenDueToShenanigans { get; set; }

	public int EatenSafetyFrames { get; set; }

	public bool Digested { get; set; }

	public double DefinedSize { get; set; }

	public double MaxHealth { get; set; }

	public double Health { get; set; }

	public DelegateOnSwallowedBy OnSwallowedBy { get; set; }

	public DelegatePreyAI SpecialPreyAI { get; set; }

	public int STR { get; set; }

	public int StruggleEffectiveness { get; set; }

	public StatModifier StruggleStrengthModifier { get; set; }

	public double StruggleStrength
	{
		get
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			double baseStruggleStrength = 1.5;
			baseStruggleStrength += 0.3 * (double)STR;
			StatModifier struggleStrengthModifier = StruggleStrengthModifier;
			return ((StatModifier)(ref struggleStrengthModifier)).ApplyTo((float)baseStruggleStrength);
		}
	}

	public DelegateOnKilledByDigestion OnKilledByDigestion { get; set; }

	public StatModifier TakenDigestionDamageModifier { get; set; }

	public double SoftenedDigestionDamageTaken { get; set; }

	public StatModifier SoftenedDigestionDamageModifier { get; set; }

	public int SoftenedWearoffDelay { get; set; }

	public static int SoftenedWearoffMaxDelay => V2Utils.SensibleTime(0, 0, 2, 30);

	public StatModifier SoftenedWearoffRateModifier { get; set; }

	public override bool InstancePerEntity => true;

	public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
	{
		return true;
	}

	public PreyProjectile()
	{
		DefinedSize = 0.0;
		MaxHealth = -1.0;
		Health = -1.0;
		OnSwallowedBy = null;
		SpecialPreyAI = null;
		STR = 0;
		StruggleEffectiveness = 5;
		OnKilledByDigestion = null;
		DigestingHitSound = null;
		DigestedDeathSound = null;
	}

	public override bool PreKill(Projectile projectile, int timeLeft)
	{
		if (projectile.AsFood().Digested)
		{
			return false;
		}
		return true;
	}

	public override bool PreDraw(Projectile projectile, ref Color lightColor)
	{
		if (((Entity)(object)projectile).CurrentCaptor() != null || projectile.AsFood().Digested)
		{
			return false;
		}
		return true;
	}

	public static void OnKilledByDigestion_GrantLivePreyGoal(Projectile projectile, Entity pred)
	{
		Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
		if (predPlayer != null)
		{
			ModContent.GetInstance<FirstLivePrey>().TrySetCompletion(predPlayer);
		}
	}
}
