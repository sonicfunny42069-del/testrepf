using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.Items;
using V2.Items.Voraria.Consumables.PermanentUpgrades;
using V2.Items.Voraria.Consumables.PermanentUpgrades.Jujus;
using V2.Mounts;
using V2.NPCs;
using V2.PlayerHandling.PredPlayerGoals;
using V2.PlayerHandling.PredPlayerGoals.Amateur;
using V2.PlayerHandling.PredPlayerGoals.Beginner;
using V2.PlayerHandling.PredPlayerGoals.Starter;
using V2.Projectiles;
using V2.Sounds.Vore;
using V2.StatusEffects.Voraria.Buffs;
using V2.StatusEffects.Voraria.Debuffs;

namespace V2.PlayerHandling;

public class PredPlayer : ModPlayer
{
	private double _stomachache;

	public StatModifier SwallowCapacityModifier;

	public StatModifier LiquidSwallowSizeModifier;

	public StatModifier StruggleGraceTimeModifier;

	public StatModifier StomachCapacityModifier;

	public StatModifier StomachacheMeterCapacityModifier;

	public StatModifier StomachacheDefense;

	public StatModifier DigestionTickDamageModifier;

	public StatModifier DigestionTickRateModifier;

	public StatModifier PreyAbsorptionRateModifier;

	public StatModifier BuffExtensionTimeModifier;

	public StatModifier DebuffDisextensionTimeModifier;

	public bool charmBracelet;

	public bool charmNoDigest;

	public bool charmNoAirDrain;

	public bool charmStealPreyLoot;

	private bool endoToggle;

	public string lastEntitySwallowed;

	public string lastEntitySwallowedMod;

	public Dictionary<string, int> mealCount;

	public bool lastSwallowWasDrinking;

	public string lastLiquidDrank;

	public string lastLiquidDrankMod;

	public Dictionary<string, int> drinkCount;

	public double StomachWeightAtSleepStart;

	public int OverfullTime;

	public double specialManaRegenCount;

	public StatModifier StomachWeightModifier;

	public bool SyncRequired_PredPoints { get; set; }

	public VoreTracker StomachTracker
	{
		get
		{
			if (Main.gameMenu)
			{
				return null;
			}
			return ModContent.GetInstance<V2MasterSystem>().VoreTrackers.FirstOrDefault(delegate(VoreTracker x)
			{
				Entity predator = x.Predator;
				Player val = (Player)(object)((predator is Player) ? predator : null);
				return val != null && ((Entity)val).whoAmI == ((Entity)((ModPlayer)this).Player).whoAmI;
			});
		}
	}

	public bool IsLayingOnTum { get; set; }

	public double Stomachache
	{
		get
		{
			return _stomachache;
		}
		set
		{
			_stomachache = Math.Max(0.0, value);
		}
	}

	public bool InPredStatsMenu { get; set; }

	public Dictionary<string, bool> GoalsCompleted { get; set; }

	public bool CheatedStatPointsWork => Rose;

	public int CheatedStatPoints { get; set; }

	public int LegitStatPoints
	{
		get
		{
			int points = 0;
			foreach (PredPlayerGoal goal in PredPlayerGoalLoader.PredPlayerGoals)
			{
				GoalsCompleted.TryAdd(goal.InternalName, value: false);
				if (GoalsCompleted[goal.InternalName])
				{
					points += goal.StatPointsFromCompletion;
				}
			}
			return points;
		}
	}

	public int TotalStatPoints
	{
		get
		{
			if (!CheatedStatPointsWork)
			{
				return LegitStatPoints;
			}
			return LegitStatPoints + CheatedStatPoints;
		}
	}

	public int AllocatedStatPoints => GLP.Spent + TUM.Spent + ACI.Spent + ABS.Spent;

	public int AvailableStatPoints => TotalStatPoints - AllocatedStatPoints;

	public PredStat GLP { get; set; }

	public static double BaseSwallowSize => 0.75;

	public static double SwallowSizePerLevel => 0.05;

	public double SwallowCapacity
	{
		get
		{
			if (V2.GetFooled)
			{
				return -1.0;
			}
			if (Rose)
			{
				return -1.0;
			}
			double baseSwallowSize = BaseSwallowSize;
			baseSwallowSize += SwallowSizePerLevel * (double)GLP.Total;
			return ((StatModifier)(ref SwallowCapacityModifier)).ApplyTo((float)baseSwallowSize);
		}
	}

	public static int BaseLiquidSwallowSize => 5;

	public static int LiquidSwallowSizePer5Levels => 1;

	public int LiquidSwallowSize
	{
		get
		{
			int baseLiquidSwallowSize = BaseLiquidSwallowSize;
			baseLiquidSwallowSize += LiquidSwallowSizePer5Levels * (int)Math.Floor((double)GLP.Total / 5.0);
			return (int)Math.Round(((StatModifier)(ref LiquidSwallowSizeModifier)).ApplyTo((float)baseLiquidSwallowSize));
		}
	}

	public static int LiquidSwallowDelay => 3;

	public static double LiquidSwallowRatePerMinute => 60.0 / (double)LiquidSwallowDelay;

	public static double BaseStruggleGraceTime => 0.8;

	public static double StruggleGraceTimePer5Levels => 0.1;

	public double StruggleGraceTime
	{
		get
		{
			if (V2.GetFooled)
			{
				return 0.0;
			}
			double baseGracePeriod = BaseStruggleGraceTime;
			baseGracePeriod += StruggleGraceTimePer5Levels * Math.Floor((double)GLP.Total / 5.0);
			return ((StatModifier)(ref StruggleGraceTimeModifier)).ApplyTo((float)baseGracePeriod);
		}
	}

	public string StruggleGraceTimeReadable
	{
		get
		{
			double seconds = StruggleGraceTime.CastToDecimalPlaces(2);
			int hours = 0;
			int minutes = 0;
			while (seconds > 3600.0)
			{
				hours++;
				seconds -= 60.0;
			}
			while (seconds > 60.0)
			{
				minutes++;
				seconds -= 60.0;
			}
			string readableTime = seconds + "sec";
			if (minutes > 0)
			{
				readableTime = minutes + "min" + readableTime;
			}
			if (hours > 0)
			{
				readableTime = hours + "hr" + readableTime;
			}
			return readableTime;
		}
	}

	public PredStat TUM { get; set; }

	public static double BaseStomachCapacity => 1.2;

	public static double StomachCapacityPerLevel => 0.08;

	public double StomachCapacity
	{
		get
		{
			if (V2.GetFooled)
			{
				return -1.0;
			}
			if (Rose)
			{
				return -1.0;
			}
			double baseStomachCapacity = BaseStomachCapacity;
			baseStomachCapacity += StomachCapacityPerLevel * (double)TUM.Total;
			return ((StatModifier)(ref StomachCapacityModifier)).ApplyTo((float)baseStomachCapacity);
		}
	}

	public static double BaseStomachacheMeterCapacity => 250.0;

	public static double StomachacheMeterCapacityPer5Levels => 25.0;

	public double StomachacheMeterCapacity
	{
		get
		{
			if (V2.GetFooled)
			{
				return -1.0;
			}
			if (Rose)
			{
				return -1.0;
			}
			double baseStomachacheMeterCapacity = BaseStomachacheMeterCapacity;
			baseStomachacheMeterCapacity += StomachacheMeterCapacityPer5Levels * Math.Floor((double)TUM.Total / 5.0);
			return ((StatModifier)(ref StomachacheMeterCapacityModifier)).ApplyTo((float)baseStomachacheMeterCapacity);
		}
	}

	public PredStat ACI { get; set; }

	public int AcidTier
	{
		get
		{
			if (Rose)
			{
				return 888;
			}
			if (V2.GetFooled)
			{
				return 100;
			}
			if (PermanentUpgradesGained.TryGetValue("AcidTier2", out var acidTier2Acquired) && acidTier2Acquired)
			{
				return 2;
			}
			if (((ModPlayer)this).Player.HasBuff(ModContent.BuffType<FastDigestionPotionBuff>()))
			{
				return 2;
			}
			if (PermanentUpgradesGained.TryGetValue("AcidTier1", out var acidTier1Acquired) && acidTier1Acquired)
			{
				return 1;
			}
			return 0;
		}
	}

	public static double BaseDigestionTickDamage => 10.0;

	public static double DigestionTickDamagePerLevel => 1.0;

	public double DigestionTickDamage
	{
		get
		{
			if (V2.GetFooled)
			{
				return 10.0;
			}
			double baseDigestionDamage = BaseDigestionTickDamage;
			baseDigestionDamage += DigestionTickDamagePerLevel * (double)ACI.Total;
			return ((StatModifier)(ref DigestionTickDamageModifier)).ApplyTo((float)baseDigestionDamage);
		}
	}

	public static double BaseDigestionTickRate => 1.0;

	public static double DigestionTickRatePer5Levels => 0.005;

	public double DigestionTickRate
	{
		get
		{
			if (V2.GetFooled)
			{
				return 30.0;
			}
			double baseDigestionRate = BaseDigestionTickRate;
			baseDigestionRate += DigestionTickRatePer5Levels * Math.Floor((double)ACI.Total / 5.0);
			if (Rose)
			{
				baseDigestionRate *= 4.0;
			}
			return ((StatModifier)(ref DigestionTickRateModifier)).ApplyTo((float)baseDigestionRate);
		}
	}

	public PredStat ABS { get; set; }

	public static double BasePreyAbsorptionRate => 0.4;

	public static double PreyAbsorptionRatePerLevel => 0.03;

	public double PreyAbsorptionRate
	{
		get
		{
			if (V2.GetFooled)
			{
				return 5.0;
			}
			double basePreyAbsorptionRate = BasePreyAbsorptionRate;
			basePreyAbsorptionRate += PreyAbsorptionRatePerLevel * (double)ABS.Total;
			if (Rose)
			{
				basePreyAbsorptionRate *= 8.0;
			}
			return ((StatModifier)(ref PreyAbsorptionRateModifier)).ApplyTo((float)basePreyAbsorptionRate);
		}
	}

	public double PreyAbsorptionRatePerTick => PreyAbsorptionRate / (double)V2Utils.SensibleTime(0, 1);

	public double PreyAbsorptionRatePerSecond => PreyAbsorptionRate / (double)V2Utils.SensibleTime(0, 0, 1);

	public static double BuffExtensionTimePer5Levels => 0.06;

	public double BuffExtensionFactor
	{
		get
		{
			if (V2.GetFooled)
			{
				return 1.0;
			}
			double baseBuffExtensionTime = BuffExtensionTimePer5Levels * Math.Floor((double)ABS.Total / 5.0);
			return 1.0 + (double)((StatModifier)(ref BuffExtensionTimeModifier)).ApplyTo((float)baseBuffExtensionTime);
		}
	}

	public static double DebuffDisextensionTimePer5Levels => 0.06;

	public double DebuffDisextensionFactor
	{
		get
		{
			if (V2.GetFooled)
			{
				return 1.0;
			}
			double baseDebuffDisextensionTime = DebuffDisextensionTimePer5Levels * Math.Floor((double)ABS.Total / 5.0);
			return 1.0 + (double)((StatModifier)(ref DebuffDisextensionTimeModifier)).ApplyTo((float)baseDebuffDisextensionTime);
		}
	}

	public SoundStyle SmallBurps { get; set; }

	public SoundStyle StandardBurps { get; set; }

	public SoundStyle BigBurps { get; set; }

	public SoundStyle SmallGulps { get; set; }

	public SoundStyle BigGulps { get; set; }

	public SlotId BellySlosh { get; set; }

	public int CharmBraceletSlots => 1;

	public Dictionary<string, bool> PermanentUpgradesGained { get; set; }

	public bool EndoToggleUnlocked { get; set; }

	public bool SafeStomach
	{
		get
		{
			if (!charmNoDigest || !charmNoAirDrain)
			{
				if (EndoToggleUnlocked)
				{
					return endoToggle;
				}
				return false;
			}
			return true;
		}
		set
		{
			if (EndoToggleUnlocked)
			{
				endoToggle = value;
			}
		}
	}

	public int TotalMeals
	{
		get
		{
			if (mealCount.Count <= 0)
			{
				return 0;
			}
			int meals = 0;
			foreach (KeyValuePair<string, int> item in mealCount)
			{
				meals += item.Value;
			}
			return meals;
		}
	}

	public bool CanDrinkLavaSafe
	{
		get
		{
			if (((ModPlayer)this).Player.lavaImmune)
			{
				return true;
			}
			if (((ModPlayer)this).Player.lavaTime > 0)
			{
				return true;
			}
			return false;
		}
	}

	public bool MoltenTummy => ((ModPlayer)this).Player.HasBuff(ModContent.BuffType<MoltenStomach>());

	public bool CanDrinkShimmerSafe
	{
		get
		{
			for (int i = 3; i < 10; i++)
			{
				if (!((ModPlayer)this).Player.armor[i].IsAir && ((ModPlayer)this).Player.armor[i].type == 5355)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool PrimedForShimmerStomachDeath { get; set; }

	public bool ShimmeringTummy
	{
		get
		{
			return ((ModPlayer)this).Player.HasBuff(ModContent.BuffType<ShimmeringStomach>());
		}
		set
		{
			if (value)
			{
				if (!((ModPlayer)this).Player.HasBuff(ModContent.BuffType<ShimmeringStomach>()))
				{
					((ModPlayer)this).Player.AddBuff(ModContent.BuffType<ShimmeringStomach>(), V2Utils.SensibleTime(0, 0, 5), true, false);
				}
			}
			else if (!((ModPlayer)this).Player.HasBuff(ModContent.BuffType<ShimmeringStomach>()))
			{
				((ModPlayer)this).Player.ClearBuff(ModContent.BuffType<ShimmeringStomach>());
			}
		}
	}

	public bool BlockSwallowAttempts
	{
		get
		{
			if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null)
			{
				return true;
			}
			if (((ModPlayer)this).Player.HasBuff(ModContent.BuffType<SoreThroat>()))
			{
				return true;
			}
			return false;
		}
	}

	public SlotId ActiveStomachNoises { get; set; }

	public double StomachFullness
	{
		get
		{
			double totalBellyWeight = 0.0;
			if (StomachTracker != null)
			{
				foreach (PreyData prey in StomachTracker.Prey)
				{
					totalBellyWeight += prey.WeightLeftToDigest;
					if (!prey.NoHealth)
					{
						switch (prey.Type)
						{
						case PreyType.Player:
						{
							Entity instance3 = prey.Instance;
							Player preyPredPlayer = (Player)(object)((instance3 is Player) ? instance3 : null);
							totalBellyWeight += preyPredPlayer.AsPred().StomachFullness;
							break;
						}
						case PreyType.NPC:
						{
							Entity instance2 = prey.Instance;
							NPC preyPredNPC = (NPC)(object)((instance2 is NPC) ? instance2 : null);
							totalBellyWeight += preyPredNPC.AsPred().ExtraWeight;
							totalBellyWeight += PredNPC.GetCurrentBellyWeight(preyPredNPC);
							break;
						}
						case PreyType.Projectile:
						{
							Entity instance = prey.Instance;
							Projectile preyPredProjectile = (Projectile)(object)((instance is Projectile) ? instance : null);
							totalBellyWeight += preyPredProjectile.AsPred().ExtraWeight;
							totalBellyWeight += PredProjectile.GetCurrentBellyWeight(preyPredProjectile);
							break;
						}
						}
					}
				}
			}
			return totalBellyWeight;
		}
	}

	public double KickyStomachFullness
	{
		get
		{
			double totalBellyWeight = 0.0;
			if (StomachTracker != null)
			{
				foreach (PreyData prey in StomachTracker.Prey)
				{
					if (!prey.NoHealth)
					{
						totalBellyWeight += prey.WeightLeftToDigest;
						switch (prey.Type)
						{
						case PreyType.Player:
						{
							Entity instance3 = prey.Instance;
							Player preyPredPlayer = (Player)(object)((instance3 is Player) ? instance3 : null);
							totalBellyWeight += preyPredPlayer.AsPred().StomachFullness;
							break;
						}
						case PreyType.NPC:
						{
							Entity instance2 = prey.Instance;
							NPC preyPredNPC = (NPC)(object)((instance2 is NPC) ? instance2 : null);
							totalBellyWeight += preyPredNPC.AsPred().ExtraWeight;
							totalBellyWeight += PredNPC.GetCurrentBellyWeight(preyPredNPC);
							break;
						}
						case PreyType.Projectile:
						{
							Entity instance = prey.Instance;
							Projectile preyPredProjectile = (Projectile)(object)((instance is Projectile) ? instance : null);
							totalBellyWeight += preyPredProjectile.AsPred().ExtraWeight;
							totalBellyWeight += PredProjectile.GetCurrentBellyWeight(preyPredProjectile);
							break;
						}
						}
					}
				}
			}
			return totalBellyWeight;
		}
	}

	public double StomachWeight
	{
		get
		{
			double totalBellyWeight = 0.0;
			if (StomachTracker != null)
			{
				foreach (PreyData prey in StomachTracker.Prey)
				{
					totalBellyWeight += prey.WeightLeftToDigest;
					if (!prey.NoHealth)
					{
						switch (prey.Type)
						{
						case PreyType.Player:
						{
							Entity instance3 = prey.Instance;
							Player preyPredPlayer = (Player)(object)((instance3 is Player) ? instance3 : null);
							totalBellyWeight += preyPredPlayer.AsPred().StomachWeight;
							break;
						}
						case PreyType.NPC:
						{
							Entity instance2 = prey.Instance;
							NPC preyPredNPC = (NPC)(object)((instance2 is NPC) ? instance2 : null);
							totalBellyWeight += preyPredNPC.AsPred().ExtraWeight;
							totalBellyWeight += PredNPC.GetCurrentBellyWeight(preyPredNPC);
							break;
						}
						case PreyType.Projectile:
						{
							Entity instance = prey.Instance;
							Projectile preyPredProjectile = (Projectile)(object)((instance is Projectile) ? instance : null);
							totalBellyWeight += preyPredProjectile.AsPred().ExtraWeight;
							totalBellyWeight += PredProjectile.GetCurrentBellyWeight(preyPredProjectile);
							break;
						}
						}
					}
				}
			}
			return ((StatModifier)(ref StomachWeightModifier)).ApplyTo((float)totalBellyWeight);
		}
	}

	public double KickyStomachWeight
	{
		get
		{
			double totalBellyWeight = 0.0;
			if (StomachTracker != null)
			{
				foreach (PreyData prey in StomachTracker.Prey)
				{
					if (!prey.NoHealth)
					{
						totalBellyWeight += prey.WeightLeftToDigest;
						switch (prey.Type)
						{
						case PreyType.Player:
						{
							Entity instance3 = prey.Instance;
							Player preyPredPlayer = (Player)(object)((instance3 is Player) ? instance3 : null);
							totalBellyWeight += preyPredPlayer.AsPred().StomachWeight;
							break;
						}
						case PreyType.NPC:
						{
							Entity instance2 = prey.Instance;
							NPC preyPredNPC = (NPC)(object)((instance2 is NPC) ? instance2 : null);
							totalBellyWeight += preyPredNPC.AsPred().ExtraWeight;
							totalBellyWeight += PredNPC.GetCurrentBellyWeight(preyPredNPC);
							break;
						}
						case PreyType.Projectile:
						{
							Entity instance = prey.Instance;
							Projectile preyPredProjectile = (Projectile)(object)((instance is Projectile) ? instance : null);
							totalBellyWeight += preyPredProjectile.AsPred().ExtraWeight;
							totalBellyWeight += PredProjectile.GetCurrentBellyWeight(preyPredProjectile);
							break;
						}
						}
					}
				}
			}
			return ((StatModifier)(ref StomachWeightModifier)).ApplyTo((float)totalBellyWeight);
		}
	}

	public double PercentBellySizeModifier { get; set; }

	public int FlatBellySizeModifier { get; set; }

	public int StomachSize => Math.Min((int)Math.Round((double)(int)Math.Floor(5.0 * Math.Sqrt(StomachFullness)) * PercentBellySizeModifier) + FlatBellySizeModifier, BellyDrawLayer.RegularBelly.StandardBellies.Count);

	public bool SizeScanner { get; set; }

	public bool Rose { get; set; }

	public bool Venomizeous { get; set; }

	public double BeeTransformation_ExtraWeight { get; set; }

	public bool FungalFairySetBonus { get; set; }

	public double EffectiveLiquidSwallowSize(int liquidType)
	{
		double effectiveBaseLiquidSwallowSize = (double)LiquidSwallowSize / 255.0;
		return liquidType switch
		{
			1 => effectiveBaseLiquidSwallowSize * 4.0, 
			2 => effectiveBaseLiquidSwallowSize * 1.5, 
			3 => effectiveBaseLiquidSwallowSize * 0.75, 
			_ => effectiveBaseLiquidSwallowSize, 
		};
	}

	public override void Initialize()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		SmallGulps = Gulps.Short;
		BigGulps = Gulps.Standard;
		SmallBurps = Burps.Humanoid.Small;
		StandardBurps = Burps.Humanoid.Standard;
		if (V2.GetFooled)
		{
			SmallGulps = Gulps.AprilFools;
			BigGulps = Gulps.AprilFools;
			SmallBurps = Burps.AprilFools;
			StandardBurps = Burps.AprilFools;
		}
		GLP = new PredStat();
		ACI = new PredStat();
		TUM = new PredStat();
		ABS = new PredStat();
		Stomachache = 0.0;
		charmNoDigest = false;
		charmNoAirDrain = false;
		charmStealPreyLoot = false;
		EndoToggleUnlocked = false;
		endoToggle = false;
		lastEntitySwallowed = null;
		lastEntitySwallowedMod = null;
		mealCount = new Dictionary<string, int>();
		lastSwallowWasDrinking = false;
		lastLiquidDrank = null;
		lastLiquidDrankMod = null;
		drinkCount = new Dictionary<string, int>();
		PrimedForShimmerStomachDeath = false;
		PercentBellySizeModifier = 1.0;
		FlatBellySizeModifier = 0;
		PermanentUpgradesGained = new Dictionary<string, bool>();
		GoalsCompleted = new Dictionary<string, bool>();
		foreach (PredPlayerGoal goal in PredPlayerGoalLoader.PredPlayerGoals)
		{
			GoalsCompleted.Add(goal.InternalName, value: false);
		}
		InPredStatsMenu = false;
		StomachWeightAtSleepStart = 0.0;
		OverfullTime = 0;
		BeeTransformation_ExtraWeight = 0.0;
	}

	public override void ResetEffects()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		SyncRequired_PredPoints = false;
		charmNoDigest = false;
		charmNoAirDrain = false;
		charmStealPreyLoot = false;
		FungalFairySetBonus = false;
		GLP.Base = 0;
		GLP.Extra = 0;
		SwallowCapacityModifier = StatModifier.Default;
		LiquidSwallowSizeModifier = StatModifier.Default;
		StruggleGraceTimeModifier = StatModifier.Default;
		TUM.Base = 0;
		TUM.Extra = 0;
		if (StomachacheMeterCapacity != -1.0)
		{
			double stomachacheQuellPerTick = StomachacheMeterCapacity * (0.05 / (double)V2Utils.SensibleTime(0, 0, 1));
			if (StomachTracker != null && KickyStomachFullness > 0.0)
			{
				stomachacheQuellPerTick *= 0.1;
			}
			Stomachache -= stomachacheQuellPerTick;
		}
		StomachCapacityModifier = StatModifier.Default;
		StomachacheMeterCapacityModifier = StatModifier.Default;
		StomachacheDefense = StatModifier.Default;
		ACI.Base = 0;
		ACI.Extra = 0;
		DigestionTickDamageModifier = StatModifier.Default;
		DigestionTickRateModifier = StatModifier.Default;
		ABS.Base = 0;
		ABS.Extra = 0;
		PreyAbsorptionRateModifier = StatModifier.Default;
		BuffExtensionTimeModifier = StatModifier.Default;
		DebuffDisextensionTimeModifier = StatModifier.Default;
		StomachWeightModifier = StatModifier.Default;
		if (V2.GetFooled)
		{
			StomachWeightModifier *= 0f;
		}
		PercentBellySizeModifier = 1.0;
		FlatBellySizeModifier = 0;
		SizeScanner = false;
		UpdatePredStatPointsFromPermUpgrades();
		Rose = false;
		Venomizeous = false;
		if (((PlayerSleepingHelper)(ref ((ModPlayer)this).Player.sleeping)).FullyFallenAsleep)
		{
			PredPlayer predPlayer = ((ModPlayer)this).Player.AsPred();
			predPlayer.DigestionTickRateModifier += 0.25f;
			PredPlayer predPlayer2 = ((ModPlayer)this).Player.AsPred();
			predPlayer2.PreyAbsorptionRateModifier += 0.25f;
			if (CurrentFrameFlags.SleepingPlayersCount == CurrentFrameFlags.ActivePlayersCount && CurrentFrameFlags.SleepingPlayersCount > 0)
			{
				PredPlayer predPlayer3 = ((ModPlayer)this).Player.AsPred();
				predPlayer3.DigestionTickRateModifier *= (float)Main.dayRate;
				PredPlayer predPlayer4 = ((ModPlayer)this).Player.AsPred();
				predPlayer4.PreyAbsorptionRateModifier *= (float)Main.dayRate;
			}
		}
	}

	public void UpdatePredStatPointsFromPermUpgrades()
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		if (PermanentUpgradesGained.TryGetValue("PureSwallow1", out var swallowStimsEaten) && swallowStimsEaten)
		{
			GLP.Base += PureSwallowBoost1.GLPBonus;
		}
		if (PermanentUpgradesGained.TryGetValue("BiomeJujuForest", out var eatenForestJuju) && eatenForestJuju)
		{
			TUM.Base += BiomeJujuForest.PermTUMBonus;
			ABS.Base += BiomeJujuForest.PermABSBonus;
		}
		if (PermanentUpgradesGained.TryGetValue("BiomeJujuDesert", out var eatenDesertJuju) && eatenDesertJuju)
		{
			ACI.Base += BiomeJujuDesert.PermACIBonus;
			PreyPlayer preyPlayer = ((ModPlayer)this).Player.AsFood();
			preyPlayer.StruggleStrengthModifier += BiomeJujuDesert.PermStruggleBonus;
		}
		if (PermanentUpgradesGained.TryGetValue("BiomeJujuSnow", out var eatenSnowJuju) && eatenSnowJuju)
		{
			GLP.Base += BiomeJujuSnow.PermGLPBonus;
			ABS.Base += BiomeJujuSnow.PermABSBonus;
		}
		if (PermanentUpgradesGained.TryGetValue("BiomeJujuJungle", out var eatenJungleJuju) && eatenJungleJuju)
		{
			TUM.Base += BiomeJujuJungle.PermTUMBonus;
		}
		if (PermanentUpgradesGained.TryGetValue("BiomeJujuSky", out var eatenSkyJuju) && eatenSkyJuju)
		{
			StomachWeightModifier *= 1f - BiomeJujuSky.PermStomachWeight;
		}
		if (PermanentUpgradesGained.TryGetValue("ShimmerJuju", out var eatenShimmerJuju) && eatenShimmerJuju)
		{
			GLP.Base += ShimmerJuju.PermAllBonus;
			TUM.Base += ShimmerJuju.PermAllBonus;
			ACI.Base += ShimmerJuju.PermAllBonus;
			ABS.Base += ShimmerJuju.PermAllBonus;
		}
	}

	public override bool HoverSlot(Item[] inventory, int context, int slot)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		if (inventory.Length == 59 && ((Entity)((ModPlayer)this).Player).whoAmI == Main.myPlayer && (V2.ItemGulpHotkey.JustPressed || (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160) && V2.ItemGulpHotkey.Current && Main.GameUpdateCount % 20 == 0)))
		{
			if (inventory[slot].IsAir)
			{
				return true;
			}
			int origStack = inventory[slot].stack;
			inventory[slot].stack = 1;
			if (CanSwallow(((ModPlayer)this).Player, (Entity)(object)inventory[slot]))
			{
				if (origStack > 1)
				{
					Item eatenItem = new Item();
					eatenItem.SetDefaults(inventory[slot].type);
					eatenItem.stack = 1;
					((ModPlayer)this).Player.ForceDropItem(((Entity)((ModPlayer)this).Player).Center, ref eatenItem, out var itemDrop);
					Swallow(((ModPlayer)this).Player, (Entity)(object)itemDrop);
					inventory[slot].stack = origStack - 1;
				}
				else
				{
					((ModPlayer)this).Player.ForceDropItem(((Entity)((ModPlayer)this).Player).Center, ref inventory[slot], out var itemDrop2);
					Swallow(((ModPlayer)this).Player, (Entity)(object)itemDrop2);
				}
				ModContent.GetInstance<FirstItemEaten>().TrySetCompletion(((ModPlayer)this).Player);
			}
			else
			{
				inventory[slot].stack = origStack;
			}
		}
		return false;
	}

	public override void UpdateBadLifeRegen()
	{
		if (((ModPlayer)this).Player.AsPred().MoltenTummy)
		{
			if (((ModPlayer)this).Player.lifeRegen > 0)
			{
				((ModPlayer)this).Player.lifeRegen = 0;
			}
			Player player = ((ModPlayer)this).Player;
			player.lifeRegen -= 75;
			((ModPlayer)this).Player.lifeRegenTime = 0f;
		}
	}

	public override void PostUpdateMiscEffects()
	{
		while (specialManaRegenCount >= 60.0)
		{
			specialManaRegenCount -= 60.0;
			Player player = ((ModPlayer)this).Player;
			player.statMana++;
			if (((ModPlayer)this).Player.statMana > ((ModPlayer)this).Player.statManaMax2)
			{
				((ModPlayer)this).Player.statMana = ((ModPlayer)this).Player.statManaMax2;
			}
		}
	}

	public override void ProcessTriggers(TriggersSet triggersSet)
	{
	}

	public override void ModifyHitByProjectile(Projectile proj, ref HurtModifiers modifiers)
	{
		if (((ModPlayer)this).Player.AsPred().FungalFairySetBonus && CanSwallow(((ModPlayer)this).Player, (Entity)(object)proj))
		{
			Swallow(((ModPlayer)this).Player, (Entity)(object)proj);
			((HurtModifiers)(ref modifiers)).Cancel();
		}
	}

	public override void PostUpdateRunSpeeds()
	{
		if (!((ModPlayer)this).Player.mount.Active)
		{
			float weightMovementMult = 1f / (float)Math.Max(1.0, ((ModPlayer)this).Player.AsPred().StomachWeight + 1.0);
			if (((ModPlayer)this).Player.AsV2Player().BeeTransformation)
			{
				weightMovementMult += (float)((ModPlayer)this).Player.AsPred().BeeTransformation_ExtraWeight;
			}
			Player player = ((ModPlayer)this).Player;
			player.runAcceleration *= weightMovementMult;
			Player.jumpSpeed *= weightMovementMult;
			Player.jumpHeight = (int)Math.Round((float)Player.jumpHeight * weightMovementMult);
			Player player2 = ((ModPlayer)this).Player;
			player2.gravity /= (2f + weightMovementMult) / 3f;
			Player player3 = ((ModPlayer)this).Player;
			player3.maxFallSpeed /= weightMovementMult;
			float weightSpeedMult = 1f / (float)Math.Max(1.0, (((ModPlayer)this).Player.AsPred().StomachWeight - 0.5) / 2.0 + 1.0);
			Player player4 = ((ModPlayer)this).Player;
			player4.maxRunSpeed *= weightSpeedMult;
			Player player5 = ((ModPlayer)this).Player;
			player5.accRunSpeed *= weightSpeedMult;
		}
		if (IsLayingOnTum)
		{
			Player player6 = ((ModPlayer)this).Player;
			player6.maxRunSpeed *= 0f;
			Player player7 = ((ModPlayer)this).Player;
			player7.runAcceleration *= 0f;
		}
	}

	public override void PostItemCheck()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode != 2 && ((Entity)((ModPlayer)this).Player).whoAmI == Main.myPlayer && !((ModPlayer)this).Player.AsPred().BlockSwallowAttempts)
		{
			if (V2.SwallowHotkey.JustPressed)
			{
				string mealType = "none";
				int mealIndex = -1;
				Vector2 playerLocation = ((ModPlayer)this).Player.MountedCenter;
				Vector2 cursorLocation = Main.MouseWorld;
				double maxDistanceFromPlayer = V2Utils.TileCountAsPixelCount(4.25);
				double maxDistanceFromCursor = 2000.0;
				for (int npcIndex = 0; npcIndex < Main.maxNPCs; npcIndex++)
				{
					NPC potentialMeal = Main.npc[npcIndex];
					if (((Entity)potentialMeal).active && (potentialMeal.realLife == -1 || potentialMeal.realLife == ((Entity)potentialMeal).whoAmI) && ((Entity)(object)potentialMeal).CurrentCaptor() == null && Collision.CanHit(((Entity)(object)((ModPlayer)this).Player).TrueCenter(), 1, 1, ((Entity)(object)potentialMeal).TrueCenter(), 1, 1) && !((double)((Entity)potentialMeal).Distance(playerLocation) >= maxDistanceFromPlayer) && (double)((Entity)potentialMeal).Distance(cursorLocation) < maxDistanceFromCursor)
					{
						mealIndex = npcIndex;
						mealType = "NPC";
						maxDistanceFromCursor = ((Entity)potentialMeal).Distance(cursorLocation);
					}
				}
				for (int projIndex = 0; projIndex < Main.maxProjectiles; projIndex++)
				{
					Projectile potentialMeal2 = Main.projectile[projIndex];
					if (((Entity)potentialMeal2).active && ((Entity)(object)potentialMeal2).CurrentCaptor() == null && Collision.CanHit(((Entity)(object)((ModPlayer)this).Player).TrueCenter(), 1, 1, ((Entity)(object)potentialMeal2).TrueCenter(), 1, 1) && !((double)((Entity)potentialMeal2).Distance(playerLocation) >= maxDistanceFromPlayer) && (double)((Entity)potentialMeal2).Distance(cursorLocation) < maxDistanceFromCursor)
					{
						mealIndex = projIndex;
						mealType = "projectile";
						maxDistanceFromCursor = ((Entity)potentialMeal2).Distance(cursorLocation);
					}
				}
				for (int playerIndex = 0; playerIndex < 255; playerIndex++)
				{
					Player potentialMeal3 = Main.player[playerIndex];
					if (((Entity)potentialMeal3).active && !potentialMeal3.dead && ((Entity)potentialMeal3).whoAmI != ((Entity)((ModPlayer)this).Player).whoAmI && ((Entity)(object)potentialMeal3).CurrentCaptor() == null && Collision.CanHit(((Entity)(object)((ModPlayer)this).Player).TrueCenter(), 1, 1, ((Entity)(object)potentialMeal3).TrueCenter(), 1, 1) && !((double)((Entity)potentialMeal3).Distance(playerLocation) >= maxDistanceFromPlayer) && (double)((Entity)potentialMeal3).Distance(cursorLocation) < maxDistanceFromCursor)
					{
						mealIndex = playerIndex;
						mealType = "player";
						maxDistanceFromCursor = ((Entity)potentialMeal3).Distance(cursorLocation);
					}
				}
				if (mealType != "none" && mealIndex != -1)
				{
					switch (mealType)
					{
					case "NPC":
						Swallow(((ModPlayer)this).Player, (Entity)(object)Main.npc[mealIndex]);
						((ModPlayer)this).Player.lastCreatureHit = Item.NPCtoBanner(Main.npc[mealIndex].BannerID());
						break;
					case "projectile":
						Swallow(((ModPlayer)this).Player, (Entity)(object)Main.projectile[mealIndex]);
						break;
					case "player":
						Swallow(((ModPlayer)this).Player, (Entity)(object)Main.player[mealIndex]);
						break;
					}
				}
			}
			bool inAnyLiquid = ((Entity)((ModPlayer)this).Player).wet || ((Entity)((ModPlayer)this).Player).lavaWet || ((Entity)((ModPlayer)this).Player).honeyWet || ((Entity)((ModPlayer)this).Player).shimmerWet;
			if (V2.SwallowHotkey.Current && inAnyLiquid && Main.GameUpdateCount % LiquidSwallowDelay == 0L && !V2.GetFooled)
			{
				Point playerTileLocation = Utils.ToTileCoordinates(((Entity)((ModPlayer)this).Player).Center + new Vector2(0f, -10f));
				Tile tile = ((Tilemap)(ref Main.tile))[playerTileLocation];
				if (((Tile)(ref tile)).LiquidAmount > 0 && (((ModPlayer)this).Player.AsPred().Rose || ((ModPlayer)this).Player.AsPred().StomachCapacity - ((ModPlayer)this).Player.AsPred().StomachFullness >= ((ModPlayer)this).Player.AsPred().EffectiveLiquidSwallowSize(((Tile)(ref tile)).LiquidType)))
				{
					int liquidToDrink = ((((Tile)(ref tile)).LiquidAmount > ((ModPlayer)this).Player.AsPred().LiquidSwallowSize) ? ((ModPlayer)this).Player.AsPred().LiquidSwallowSize : ((Tile)(ref tile)).LiquidAmount);
					Drink(((ModPlayer)this).Player, ((Tile)(ref tile)).LiquidType, liquidToDrink);
					if (((Tile)(ref tile)).LiquidAmount <= (byte)((ModPlayer)this).Player.AsPred().LiquidSwallowSize)
					{
						((Tile)(ref tile)).LiquidAmount = 0;
						((Tile)(ref tile)).LiquidType = 0;
					}
					else
					{
						((Tile)(ref tile)).LiquidAmount -= (byte)((ModPlayer)this).Player.AsPred().LiquidSwallowSize;
					}
					WorldGen.SquareTileFrame(playerTileLocation.X, playerTileLocation.Y, true);
					if (Main.netMode == 1)
					{
						NetMessage.SendTileSquare(-1, playerTileLocation.X, playerTileLocation.Y, (TileChangeType)0);
					}
					if (Main.GameUpdateCount % 60 == 0)
					{
						SoundStyle smallGulps = ((ModPlayer)this).Player.AsPred().SmallGulps;
						((SoundStyle)(ref smallGulps)).Volume = 0.45f;
						((SoundStyle)(ref smallGulps)).Pitch = 0.25f;
						SoundEngine.PlaySound(ref smallGulps, (Vector2?)(((Entity)((ModPlayer)this).Player).position + new Vector2(0f, -10f)), (SoundUpdateCallback)null);
					}
				}
			}
			if (V2.RegurgitateHotkey.JustPressed)
			{
				VoreTracker stomachTracker = ((ModPlayer)this).Player.AsPred().StomachTracker;
				if (stomachTracker != null && stomachTracker.Prey.Count > 0)
				{
					PreyData prey = ((ModPlayer)this).Player.AsPred().StomachTracker.Prey.FindLast((PreyData x) => !x.NoHealth && x.Type != PreyType.Liquid);
					if (prey != null)
					{
						Regurgitate(((ModPlayer)this).Player, ((ModPlayer)this).Player.AsPred().StomachTracker.Prey.IndexOf(prey));
					}
				}
			}
		}
		UpdateGeneralPredGoalsLogic(((ModPlayer)this).Player);
	}

	public static bool CanSwallow(Player pred, Entity prey)
	{
		if (pred.AsPred().BlockSwallowAttempts)
		{
			return false;
		}
		switch (ModContent.GetInstance<V2ServerConfig>().GenderBlacklist)
		{
		case "No Male":
			if (pred.Male)
			{
				return false;
			}
			break;
		case "No Female":
			if (!pred.Male)
			{
				return false;
			}
			break;
		case "No M or F...but why?":
			return false;
		}
		if (prey.CurrentCaptor() != null)
		{
			return false;
		}
		Player preyPlayer = (Player)(object)((prey is Player) ? prey : null);
		if (preyPlayer != null)
		{
			if (preyPlayer.AsFood().PerfectMeal)
			{
				return true;
			}
		}
		else
		{
			NPC preyNPC = (NPC)(object)((prey is NPC) ? prey : null);
			if (preyNPC != null)
			{
				if (preyNPC.AsFood().CannotBeEatenDueToShenanigans)
				{
					return false;
				}
				if (V2.VoreNPCBlacklist != null && V2.VoreNPCBlacklist.Count > 0 && V2.VoreNPCBlacklist.Contains(preyNPC.type))
				{
					return false;
				}
				if (preyNPC.type == 636 && ModContent.GetInstance<V2ServerConfig>().EasilyEdibleEmpress)
				{
					return true;
				}
				if ((preyNPC.boss || (preyNPC.type >= 13 && preyNPC.type <= 15)) && !pred.AsPred().Rose)
				{
					return false;
				}
			}
			else
			{
				Projectile preyProjectile = (Projectile)(object)((prey is Projectile) ? prey : null);
				if (preyProjectile != null)
				{
					if (preyProjectile.AsFood().CannotBeEatenDueToShenanigans)
					{
						return false;
					}
					if (V2.VoreNPCBlacklist != null && V2.VoreProjectileBlacklist.Count > 0 && V2.VoreProjectileBlacklist.Contains(preyProjectile.type))
					{
						return false;
					}
					if (preyProjectile.AsFood().MaxHealth == -1.0 && !pred.AsPred().FungalFairySetBonus)
					{
						return false;
					}
				}
				else
				{
					Item preyItem = (Item)(object)((prey is Item) ? prey : null);
					if (preyItem != null)
					{
						if (preyItem.AsFood().MaxHealth == -1)
						{
							return false;
						}
						if (preyItem.favorited)
						{
							return false;
						}
					}
				}
			}
		}
		if (pred.AsPred().SwallowCapacity != -1.0 && PreyData.GetPreySize(prey) > pred.AsPred().SwallowCapacity && !pred.AsPred().Rose)
		{
			return false;
		}
		if (pred.AsPred().StomachCapacity != -1.0 && PreyData.GetPreySize(prey) > pred.AsPred().StomachCapacity - pred.AsPred().StomachFullness && !pred.AsPred().Rose)
		{
			return false;
		}
		if (pred.AsPred().Stomachache >= pred.AsPred().StomachacheMeterCapacity && !pred.AsPred().Rose)
		{
			return false;
		}
		return true;
	}

	public static void Swallow(Player pred, Entity prey, int MPstate = 0, int MPwhoAmI = -1, bool skipRealLifeCheck = false)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if (!CanSwallow(pred, prey))
		{
			return;
		}
		if (MPstate == 0 && Main.netMode == 1)
		{
			MPstate = 1;
			MPwhoAmI = Main.myPlayer;
		}
		PreyData food = PreyData.NewData(prey);
		NPC preyNPC = (NPC)(object)((prey is NPC) ? prey : null);
		if (preyNPC == null || preyNPC.realLife == -1)
		{
			SoundStyle val = ((food.WeightLeftToDigest <= 0.3) ? pred.AsPred().SmallGulps : pred.AsPred().BigGulps);
			SoundEngine.PlaySound(ref val, (Vector2?)((Entity)pred).Center, (SoundUpdateCallback)null);
		}
		pred.AsPred().lastSwallowWasDrinking = false;
		switch (food.Type)
		{
		case PreyType.Player:
			((Player)(object)((prey is Player) ? prey : null)).AsFood().TotalTimesSwallowed++;
			pred.AsPred().lastEntitySwallowed = "Player";
			pred.AsPred().lastEntitySwallowedMod = "Terraria";
			break;
		case PreyType.NPC:
		{
			NPC npc = (NPC)(object)((prey is NPC) ? prey : null);
			npc.AsFood().OnSwallowedBy?.Invoke(npc, (Entity)(object)pred);
			if (!skipRealLifeCheck)
			{
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					if (i != ((Entity)npc).whoAmI && Main.npc[i].realLife != -1 && Main.npc[i].realLife == ((Entity)npc).whoAmI)
					{
						Swallow(pred, (Entity)(object)Main.npc[i], MPstate, MPwhoAmI, skipRealLifeCheck: true);
					}
				}
			}
			pred.AsPred().lastEntitySwallowed = npc.TypeName;
			pred.AsPred().lastEntitySwallowedMod = ((npc.ModNPC != null) ? ((ModType)npc.ModNPC).Mod.DisplayName : "Terraria");
			break;
		}
		case PreyType.Projectile:
		{
			Projectile projectile = (Projectile)(object)((prey is Projectile) ? prey : null);
			if (projectile.AsFood().MaxHealth == -1.0)
			{
				food = PreyData.NewData(PreyType.Projectile, projectile.type, projectile.Name, PreyData.GetPreySize((Entity)(object)projectile));
				((Entity)projectile).active = false;
			}
			else
			{
				projectile.AsFood().OnSwallowedBy?.Invoke(projectile, (Entity)(object)pred);
				pred.AsPred().lastEntitySwallowed = projectile.Name;
				pred.AsPred().lastEntitySwallowedMod = ((projectile.ModProjectile != null) ? ((ModType)projectile.ModProjectile).Mod.DisplayName : "Terraria");
			}
			break;
		}
		case PreyType.Item:
		{
			Item item = (Item)(object)((prey is Item) ? prey : null);
			pred.AsPred().lastEntitySwallowed = item.Name;
			pred.AsPred().lastEntitySwallowedMod = ((item.ModItem != null) ? ((ModType)item.ModItem).Mod.DisplayName : "Terraria");
			item.AsFood().OnSwallow?.Invoke(item, (Entity)(object)pred);
			if (item.AsFood().OnSwallowDamage > 0 && item.AsFood().OnSwallowDeathReason != null)
			{
				pred.Hurt(PlayerDeathReason.ByCustomReason(item.AsFood().OnSwallowDeathReason), item.AsFood().OnSwallowDamage, 0, false, false, -1, false, 0f, 1f, 4.5f);
			}
			if (item.AsFood().OnSwallowSoreThroatTime > 0)
			{
				pred.AddBuff(ModContent.BuffType<SoreThroat>(), item.AsFood().OnSwallowSoreThroatTime, true, false);
			}
			break;
		}
		}
		AddNewPrey(pred, food);
		switch (MPstate)
		{
		case 1:
		{
			ModPacket packet2 = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet2).Write((byte)1);
			((BinaryWriter)(object)packet2).Write((byte)0);
			((BinaryWriter)(object)packet2).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet2).Write((byte)food.Type);
			((BinaryWriter)(object)packet2).Write(prey.whoAmI);
			((BinaryWriter)(object)packet2).Write(MPwhoAmI);
			packet2.Send(-1, -1);
			break;
		}
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)2);
			((BinaryWriter)(object)packet).Write((byte)0);
			((BinaryWriter)(object)packet).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet).Write((byte)food.Type);
			((BinaryWriter)(object)packet).Write(prey.whoAmI);
			((BinaryWriter)(object)packet).Write(MPwhoAmI);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
	}

	public static void Drink(Player pred, int liquidType = -1, int liquidAmount = -1, PreyData newDrink = null, int MPstate = 0, int MPwhoAmI = -1)
	{
		PredPlayer predPlayer = pred.AsPred();
		predPlayer.lastLiquidDrank = liquidType switch
		{
			0 => "Water", 
			1 => "Lava", 
			2 => "Honey", 
			3 => "Shimmer", 
			_ => "Some other liquid", 
		};
		if (liquidType == 0 && liquidAmount == 0 && newDrink == null)
		{
			throw new ArgumentException("you're supposed to make sure either the PreyData instance provided or the liquid type and amount provided are valid for PredPlayer.Drink. try again");
		}
		if (newDrink == null)
		{
			newDrink = new PreyData(liquidType, liquidAmount);
		}
		if (liquidType == -1 && liquidAmount == -1)
		{
			liquidType = newDrink.ExactType;
			double weightLeftToDigest = newDrink.WeightLeftToDigest;
			liquidAmount = (int)Math.Round(weightLeftToDigest / liquidType switch
			{
				1 => 4.0, 
				2 => 1.5, 
				3 => 0.75, 
				_ => 1.0, 
			} * 256.0);
		}
		if (pred.AsPred().StomachTracker != null)
		{
			PreyData existingDrink = pred.AsPred().StomachTracker.Prey.FirstOrDefault((PreyData x) => x.Type == PreyType.Liquid && x.ExactType == liquidType);
			if (existingDrink != null)
			{
				existingDrink.WeightLeftToDigest += newDrink.WeightLeftToDigest;
				goto IL_019e;
			}
		}
		AddNewPrey(pred, newDrink);
		goto IL_019e;
		IL_019e:
		switch (liquidType)
		{
		case 0:
			AddVanillaDrinkCount();
			if (VanillaDrinkCountHas(255))
			{
				ModContent.GetInstance<FirstDrink>().TrySetCompletion(pred);
			}
			break;
		case 1:
			if (pred.AsPred().CanDrinkLavaSafe)
			{
				AddVanillaDrinkCount();
				if (VanillaDrinkCountHas(255))
				{
					ModContent.GetInstance<DrinkLava>().TrySetCompletion(pred);
				}
			}
			break;
		case 2:
			AddVanillaDrinkCount();
			if (VanillaDrinkCountHas(255))
			{
				ModContent.GetInstance<DrinkHoney>().TrySetCompletion(pred);
			}
			break;
		case 3:
			if (!pred.AsPred().CanDrinkShimmerSafe && !pred.AsPred().PrimedForShimmerStomachDeath)
			{
				pred.AddBuff(ModContent.BuffType<ShimmeringStomach>(), 300, true, false);
				pred.AsPred().PrimedForShimmerStomachDeath = true;
			}
			else if (pred.AsPred().CanDrinkShimmerSafe)
			{
				AddVanillaDrinkCount();
			}
			break;
		}
		switch (MPstate)
		{
		case 1:
		{
			ModPacket packet2 = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet2).Write((byte)1);
			((BinaryWriter)(object)packet2).Write((byte)0);
			((BinaryWriter)(object)packet2).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet2).Write((byte)4);
			((BinaryWriter)(object)packet2).Write(liquidType);
			((BinaryWriter)(object)packet2).Write(liquidAmount);
			((BinaryWriter)(object)packet2).Write(MPwhoAmI);
			packet2.Send(-1, -1);
			break;
		}
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)2);
			((BinaryWriter)(object)packet).Write((byte)0);
			((BinaryWriter)(object)packet).Write(((Entity)pred).whoAmI);
			((BinaryWriter)(object)packet).Write((byte)4);
			((BinaryWriter)(object)packet).Write(liquidType);
			((BinaryWriter)(object)packet).Write(liquidAmount);
			((BinaryWriter)(object)packet).Write(MPwhoAmI);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
		void AddVanillaDrinkCount()
		{
			pred.AsPred().lastLiquidDrankMod = "Terraria";
			if (!pred.AsPred().drinkCount.ContainsKey(pred.AsPred().lastLiquidDrankMod + ": " + pred.AsPred().lastLiquidDrank))
			{
				pred.AsPred().drinkCount.Add(pred.AsPred().lastLiquidDrankMod + ": " + pred.AsPred().lastLiquidDrank, 0);
			}
			pred.AsPred().drinkCount[pred.AsPred().lastLiquidDrankMod + ": " + pred.AsPred().lastLiquidDrank] += liquidAmount;
			pred.AsPred().lastSwallowWasDrinking = true;
		}
		bool VanillaDrinkCountHas(int req)
		{
			return pred.AsPred().drinkCount[pred.AsPred().lastLiquidDrankMod + ": " + pred.AsPred().lastLiquidDrank] >= req;
		}
	}

	public static void Regurgitate(Player pred, int index = -1, int MPstate = 0, int MPwhoAmI = -1)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if (MPstate == 0 && Main.netMode == 1)
		{
			MPstate = 1;
			MPwhoAmI = Main.myPlayer;
		}
		double totalRegurgiweight = 0.0;
		if (index == -1)
		{
			foreach (PreyData prey in pred.AsPred().StomachTracker.Prey)
			{
				Regurgitate_Inner(pred, prey);
			}
			pred.AsPred().StomachTracker.Prey.Clear();
			pred.AsPred().StomachTracker.RefreshStruggleChartList();
		}
		else
		{
			PreyData prey2 = pred.AsPred().StomachTracker.Prey[index];
			Regurgitate_Inner(pred, prey2);
			pred.AsPred().StomachTracker.Prey.Remove(prey2);
		}
		SoundStyle val = ((totalRegurgiweight <= 0.3) ? pred.AsPred().SmallBurps : pred.AsPred().StandardBurps);
		SoundEngine.PlaySound(ref val, (Vector2?)(((Entity)(object)pred).TrueCenter() + new Vector2((float)((Entity)pred).direction * 8f, -14f)), (SoundUpdateCallback)null);
		switch (MPstate)
		{
		case 1:
		{
			ModPacket packet2 = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet2).Write((byte)8);
			((BinaryWriter)(object)packet2).Write((byte)0);
			((BinaryWriter)(object)packet2).Write(Main.myPlayer);
			((BinaryWriter)(object)packet2).Write(index);
			((BinaryWriter)(object)packet2).Write(Main.myPlayer);
			packet2.Send(-1, -1);
			break;
		}
		case 2:
		{
			ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
			((BinaryWriter)(object)packet).Write((byte)9);
			((BinaryWriter)(object)packet).Write((byte)0);
			((BinaryWriter)(object)packet).Write(Main.myPlayer);
			((BinaryWriter)(object)packet).Write(index);
			((BinaryWriter)(object)packet).Write(Main.myPlayer);
			packet.Send(-1, MPwhoAmI);
			break;
		}
		}
		void Regurgitate_Inner(Player val3, PreyData preyData)
		{
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			if (preyData.Instance != null && !preyData.NoHealth)
			{
				Entity val2;
				switch (preyData.Type)
				{
				case PreyType.Player:
				{
					Entity instance4 = preyData.Instance;
					val2 = ((instance4 is Player) ? instance4 : null);
					break;
				}
				case PreyType.NPC:
				{
					Entity instance3 = preyData.Instance;
					val2 = ((instance3 is NPC) ? instance3 : null);
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance2 = preyData.Instance;
					val2 = ((instance2 is Projectile) ? instance2 : null);
					break;
				}
				case PreyType.Item:
				{
					Entity instance = preyData.Instance;
					val2 = ((instance is Item) ? instance : null);
					break;
				}
				default:
					throw new NotImplementedException();
				}
				Entity realPrey = val2;
				realPrey.position = ((Entity)(object)val3).TrueCenter() + new Vector2((float)((Entity)val3).direction * 8f, -14f);
				realPrey.velocity = new Vector2((float)((Entity)val3).direction * 10f, -2.5f);
				NPC realPreyNPC = (NPC)(object)((realPrey is NPC) ? realPrey : null);
				if (realPreyNPC != null)
				{
					realPreyNPC.AsFood().EatenSafetyFrames = 20;
				}
				else if (!(realPrey is Projectile) && !(realPrey is Player))
				{
					Item realPreyItem = (Item)(object)((realPrey is Item) ? realPrey : null);
					if (realPreyItem != null)
					{
						realPreyItem.noGrabDelay = 60;
					}
				}
				totalRegurgiweight += preyData.WeightLeftToDigest;
			}
		}
	}

	public static void AddNewPrey(Player pred, PreyData prey)
	{
		if (pred.AsPred().StomachTracker == null)
		{
			int num = 1;
			List<PreyData> list = new List<PreyData>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<PreyData> span = CollectionsMarshal.AsSpan(list);
			int num2 = 0;
			span[num2] = prey;
			num2++;
			VoreTracker.NewTracker((Entity)(object)pred, list);
		}
		else
		{
			pred.AsPred().StomachTracker.QueueNewPrey(prey);
		}
	}

	public static void UpdatePrey(Player pred)
	{
		//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_0980: Unknown result type (might be due to invalid IL or missing references)
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a49: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		if (pred.AsPred().StomachacheMeterCapacity > 0.0 && pred.AsPred().Stomachache >= pred.AsPred().StomachacheMeterCapacity && pred.AsPred().StomachTracker != null && pred.AsPred().StomachTracker.Prey.Count > 0)
		{
			Regurgitate(pred);
			return;
		}
		SoundStyle val;
		foreach (PreyData prey in pred.AsPred().StomachTracker.Prey)
		{
			if (!prey.NoHealth)
			{
				prey.UpdateInStomach?.Invoke(prey.Instance, (Entity)(object)pred, dead: false);
				switch (prey.Type)
				{
				case PreyType.Player:
				{
					Entity instance3 = prey.Instance;
					Entity obj2 = ((instance3 is Player) ? instance3 : null);
					obj2.velocity = Vector2.Zero;
					obj2.position = ((Entity)pred).position;
					break;
				}
				case PreyType.NPC:
				{
					Entity instance2 = prey.Instance;
					Entity obj = ((instance2 is NPC) ? instance2 : null);
					obj.velocity = Vector2.Zero;
					obj.position = ((Entity)pred).position;
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance4 = prey.Instance;
					Projectile preyProjectile = (Projectile)(object)((instance4 is Projectile) ? instance4 : null);
					if (((Entity)preyProjectile).active)
					{
						((Entity)preyProjectile).velocity = Vector2.Zero;
					}
					((Entity)preyProjectile).position = ((Entity)pred).position;
					break;
				}
				case PreyType.Item:
				{
					Entity instance = prey.Instance;
					Item preyItem = (Item)(object)((instance is Item) ? instance : null);
					preyItem.AsFood().UpdateInStomach?.Invoke((Entity)(object)preyItem, (Entity)(object)pred, prey.NoHealth);
					((Entity)preyItem).position = ((Entity)pred).position;
					break;
				}
				}
				double digestionDamage = pred.AsPred().DigestionTickDamage;
				double digestionRate = pred.AsPred().DigestionTickRate;
				if (digestionRate <= 0.0)
				{
					digestionRate = 1.0;
				}
				int digestionFrameRate = (int)Math.Round(60.0 / digestionRate);
				if (prey.timeSpentInStomach % digestionFrameRate != 0)
				{
					continue;
				}
				switch (prey.Type)
				{
				case PreyType.Player:
				{
					Entity instance7 = prey.Instance;
					Player preyPlayer = (Player)(object)((instance7 is Player) ? instance7 : null);
					if (!pred.AsPred().SafeStomach)
					{
						prey.NoHealth = preyPlayer.AsFood().TakeDigestionDamage((Entity)(object)pred, digestionDamage);
						if (prey.NoHealth)
						{
							pred.AsPred().mealCount.TryAdd("Terraria: Player", 0);
							pred.AsPred().mealCount["Terraria: Player"]++;
							val = pred.AsPred().StandardBurps;
							SoundEngine.PlaySound(ref val, (Vector2?)(((Entity)(object)pred).TrueCenter() + new Vector2((float)((Entity)pred).direction * 8f, -14f)), (SoundUpdateCallback)null);
						}
					}
					break;
				}
				case PreyType.NPC:
				{
					Entity instance6 = prey.Instance;
					NPC preyNPC = (NPC)(object)((instance6 is NPC) ? instance6 : null);
					if (!pred.AsPred().SafeStomach)
					{
						if (preyNPC.type == 636 && ModContent.GetInstance<V2ServerConfig>().EasilyEdibleEmpress)
						{
							digestionDamage *= 20.0;
						}
						prey.NoHealth = PreyNPC.TakeDigestionDamage(preyNPC, (Entity)(object)pred, digestionDamage);
						if (prey.NoHealth)
						{
							prey.Instance = null;
							string preyNPCMod = ((preyNPC.ModNPC != null) ? ((ModType)preyNPC.ModNPC).Mod.DisplayName : "Terraria");
							pred.AsPred().mealCount.TryAdd(preyNPCMod + ": " + preyNPC.TypeName, 0);
							pred.AsPred().mealCount[preyNPCMod + ": " + preyNPC.TypeName]++;
							val = ((prey.WeightLeftToDigest < 0.3) ? pred.AsPred().SmallBurps : pred.AsPred().StandardBurps);
							SoundEngine.PlaySound(ref val, (Vector2?)(((Entity)(object)pred).TrueCenter() + new Vector2((float)((Entity)pred).direction * 8f, -14f)), (SoundUpdateCallback)null);
						}
					}
					break;
				}
				case PreyType.Projectile:
				{
					Entity instance8 = prey.Instance;
					Projectile preyProjectile2 = (Projectile)(object)((instance8 is Projectile) ? instance8 : null);
					if (true)
					{
						prey.NoHealth = preyProjectile2.TakeDigestionDamage((Entity)(object)pred, digestionDamage);
						preyProjectile2.netUpdate = true;
						if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
						{
							Main.NewText("Successfully dealt digestion damage to prey: " + preyProjectile2.Name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						}
						else if (ModContent.GetInstance<V2ServerConfig>().DebugChatMessages)
						{
							Main.NewText("Failed to deal digestion damage to prey: " + preyProjectile2.Name, byte.MaxValue, byte.MaxValue, byte.MaxValue);
						}
						if (prey.NoHealth)
						{
							prey.Instance = null;
							string preyProjectileMod = ((preyProjectile2.ModProjectile != null) ? ((ModType)preyProjectile2.ModProjectile).Mod.DisplayName : "Terraria");
							pred.AsPred().mealCount.TryAdd(preyProjectileMod + ": " + preyProjectile2.Name, 0);
							pred.AsPred().mealCount[preyProjectileMod + ": " + preyProjectile2.Name]++;
							val = ((prey.WeightLeftToDigest < 0.3) ? pred.AsPred().SmallBurps : pred.AsPred().StandardBurps);
							SoundEngine.PlaySound(ref val, (Vector2?)(((Entity)(object)pred).TrueCenter() + new Vector2((float)((Entity)pred).direction * 8f, -14f)), (SoundUpdateCallback)null);
						}
					}
					break;
				}
				case PreyType.Item:
				{
					Entity instance5 = prey.Instance;
					Item preyItem2 = (Item)(object)((instance5 is Item) ? instance5 : null);
					if (preyItem2.IsAir || !(!pred.AsPred().SafeStomach & (pred.AsPred().AcidTier >= preyItem2.AsFood().AcidResistTier)))
					{
						break;
					}
					prey.NoHealth = preyItem2.TakeDigestionDamage((Entity)(object)pred, digestionDamage);
					if (prey.NoHealth)
					{
						string preyItemMod = ((preyItem2.ModItem != null) ? ((ModType)preyItem2.ModItem).Mod.DisplayName : "Terraria");
						if (!pred.AsPred().mealCount.ContainsKey(preyItemMod + ": " + preyItem2.Name))
						{
							pred.AsPred().mealCount.Add(preyItemMod + ": " + preyItem2.Name, 0);
						}
						pred.AsPred().mealCount[preyItemMod + ": " + preyItem2.Name] += preyItem2.stack;
						val = ((prey.WeightLeftToDigest < 0.3) ? pred.AsPred().SmallBurps : pred.AsPred().StandardBurps);
						SoundEngine.PlaySound(ref val, (Vector2?)(((Entity)(object)pred).TrueCenter() + new Vector2((float)((Entity)pred).direction * 8f, -14f)), (SoundUpdateCallback)null);
					}
					break;
				}
				}
				continue;
			}
			prey.UpdateInStomach?.Invoke(null, (Entity)(object)pred, dead: true);
			double absorptionRate = pred.AsPred().PreyAbsorptionRatePerTick / (double)(pred.AsPred().StomachTracker?.Prey.Count).Value;
			if (prey.WeightLeftToDigest <= absorptionRate)
			{
				if (pred.AsV2Player().BeeTransformation)
				{
					double effectiveSize = 1.0 + pred.AsPred().BeeTransformation_ExtraWeight;
					pred.AsPred().BeeTransformation_ExtraWeight += prey.WeightLeftToDigest * BeeTransformationItem.WeightGainRatio * (1.0 / effectiveSize);
				}
				prey.WeightLeftToDigest = 0.0;
			}
			else
			{
				if (pred.AsV2Player().BeeTransformation)
				{
					double effectiveSize2 = 1.0 + pred.AsPred().BeeTransformation_ExtraWeight;
					pred.AsPred().BeeTransformation_ExtraWeight += prey.WeightLeftToDigest * BeeTransformationItem.WeightGainRatio * (1.0 / effectiveSize2);
				}
				prey.WeightLeftToDigest -= absorptionRate;
			}
			if (prey.Type != PreyType.Liquid)
			{
				continue;
			}
			switch (prey.ExactType)
			{
			case 1:
				if (!pred.AsPred().CanDrinkLavaSafe)
				{
					pred.AddBuff(ModContent.BuffType<MoltenStomach>(), 3, true, false);
				}
				break;
			case 3:
				if (!pred.AsPred().CanDrinkShimmerSafe)
				{
					if (!pred.AsPred().PrimedForShimmerStomachDeath)
					{
						pred.AsPred().PrimedForShimmerStomachDeath = true;
						pred.AddBuff(ModContent.BuffType<ShimmeringStomach>(), 300, true, false);
					}
					else if (!pred.AsPred().ShimmeringTummy)
					{
						pred.AsPred().PrimedForShimmerStomachDeath = false;
						pred.KillMe(PlayerDeathReason.ByCustomReason(Language.GetTextValueWith(Utils.NextFromCollection<string>(Main.rand, new List<string> { "Mods.V2.Death.OverlyHungryPlayer.UnsafeShimmerDrink.1", "Mods.V2.Death.OverlyHungryPlayer.UnsafeShimmerDrink.2", "Mods.V2.Death.OverlyHungryPlayer.UnsafeShimmerDrink.3" }), (object)new
						{
							Player = pred.name
						})), 9999.0, 0, false);
					}
				}
				break;
			}
		}
		if (((Entity)(object)pred).CurrentCaptor() != null)
		{
			return;
		}
		if (((Vector2)(ref ((Entity)pred).velocity)).LengthSquared() > 0f)
		{
			ActiveSound slosh = default(ActiveSound);
			if (!SoundEngine.TryGetActiveSound(pred.AsPred().BellySlosh, ref slosh))
			{
				PredPlayer predPlayer = pred.AsPred();
				val = Sloshes.Humanoid.Standard;
				((SoundStyle)(ref val)).Volume = (float)pred.AsPred().StomachSize * 0.75f;
				predPlayer.BellySlosh = SoundEngine.PlaySound(ref val, (Vector2?)((Entity)(object)pred).TrueCenter(), (SoundUpdateCallback)null);
				SoundEngine.TryGetActiveSound(pred.AsPred().BellySlosh, ref slosh);
			}
			slosh.Position = ((Entity)(object)pred).TrueCenter();
			slosh.Volume = (float)pred.AsPred().StomachFullness * 0.75f;
		}
		ActiveSound stomachNoises = default(ActiveSound);
		if (!SoundEngine.TryGetActiveSound(pred.AsPred().ActiveStomachNoises, ref stomachNoises))
		{
			PredPlayer predPlayer2 = pred.AsPred();
			val = (V2.GetFooled ? StomachNoises.AprilFools : StomachNoises.Muffled);
			((SoundStyle)(ref val)).Volume = 0.25f + 0.2f * (float)pred.AsPred().StomachSize;
			predPlayer2.ActiveStomachNoises = SoundEngine.PlaySound(ref val, (Vector2?)((Entity)(object)pred).TrueCenter(), (SoundUpdateCallback)null);
			SoundEngine.TryGetActiveSound(pred.AsPred().ActiveStomachNoises, ref stomachNoises);
		}
		if (stomachNoises != null)
		{
			stomachNoises.Position = ((Entity)(object)pred).TrueCenter();
			stomachNoises.Volume = 0.25f;
			ActiveSound obj3 = stomachNoises;
			obj3.Volume += 0.2f * (float)pred.AsPred().StomachSize;
		}
	}

	public static void UpdateGeneralPredGoalsLogic(Player pred)
	{
		if (((PlayerSleepingHelper)(ref pred.sleeping)).FullyFallenAsleep)
		{
			if (pred.AsPred().StomachWeightAtSleepStart == -1.0)
			{
				pred.AsPred().StomachWeightAtSleepStart = pred.AsPred().StomachWeight;
			}
			if (pred.AsPred().StomachWeight == 0.0 && pred.AsPred().StomachWeightAtSleepStart > 0.0 && pred.AsPred().StomachWeightAtSleepStart >= SleepSpeedsDigestion.FlatFullnessThreshold)
			{
				ModContent.GetInstance<SleepSpeedsDigestion>().TrySetCompletion(pred);
			}
		}
		else
		{
			pred.AsPred().StomachWeightAtSleepStart = -1.0;
		}
		if (pred.AsPred().StomachFullness / pred.AsPred().StomachCapacity > TooFull.FullnessThreshold)
		{
			pred.AsPred().OverfullTime++;
			if (pred.AsPred().OverfullTime >= TooFull.TimeThreshold)
			{
				ModContent.GetInstance<TooFull>().TrySetCompletion(pred);
			}
		}
		else
		{
			pred.AsPred().OverfullTime = 0;
		}
	}

	public static string GetDigestedPlayerDeathReason(Player player, Player prey)
	{
		if (((Entity)player).whoAmI == ((Entity)prey).whoAmI)
		{
			return Language.GetTextValueWith("Mods.V2.Death.DigestedPlayer.Paradox", (object)new
			{
				Player = prey.name
			});
		}
		int num = 22;
		List<string> list = new List<string>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<string> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.1";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.2";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.3";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.4";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.5";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.6";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.7";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.8";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.9";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.10";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.11";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.12";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.13";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.14";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.15";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.16";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.17";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.18";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.19";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.20";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.21";
		num2++;
		span[num2] = "Mods.V2.Death.DigestedPlayer.Universal.22";
		num2++;
		List<string> deathMessageKeyList = list;
		if (player.difficulty == 2)
		{
			deathMessageKeyList.AddRange(new _003C_003Ez__ReadOnlyArray<string>(new string[4] { "Mods.V2.Death.DigestedPlayer.Hardcore.1", "Mods.V2.Death.DigestedPlayer.Hardcore.2", "Mods.V2.Death.DigestedPlayer.Hardcore.3", "Mods.V2.Death.DigestedPlayer.Hardcore.4" }));
		}
		return Language.GetTextValueWith(Utils.NextFromCollection<string>(Main.rand, deathMessageKeyList), (object)new
		{
			Player = prey.name,
			Pred = player.name
		});
	}

	public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
	{
		if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() == null && ((ModPlayer)this).Player.AsPred().MoltenTummy)
		{
			damageSource = PlayerDeathReason.ByCustomReason(Language.GetTextValueWith(Utils.NextFromCollection<string>(Main.rand, new List<string> { "Mods.V2.Death.OverlyHungryPlayer.UnsafeLavaDrink.1", "Mods.V2.Death.OverlyHungryPlayer.UnsafeLavaDrink.2", "Mods.V2.Death.OverlyHungryPlayer.UnsafeLavaDrink.3" }), (object)new
			{
				Player = ((ModPlayer)this).Player.name
			}));
		}
		return true;
	}

	public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
	{
		if (StomachTracker != null)
		{
			if (((Entity)(object)((ModPlayer)this).Player).CurrentCaptor() != null)
			{
				foreach (PreyData prey in StomachTracker.Prey)
				{
					((Entity)(object)((ModPlayer)this).Player).CurrentCaptor().QueueNewPrey(prey);
				}
			}
			StomachTracker.Prey.Clear();
		}
		InPredStatsMenu = false;
	}

	public override void UpdateDead()
	{
		((ModPlayer)this).Player.AsPred().PrimedForShimmerStomachDeath = false;
		((ModPlayer)this).Player.AsPred().Stomachache = 0.0;
	}

	public override void OnRespawn()
	{
		if (((ModPlayer)this).Player.SpawnX != -1 && Utils.NextBool(Main.rand, 7, 1000000))
		{
			Swallow(((ModPlayer)this).Player, (Entity)(object)((ModPlayer)this).Player);
		}
	}

	public static void CountDigestionKillForBannersAndDropThem(Player player, NPC npc)
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		int num = Item.NPCtoBanner(npc.BannerID());
		if (num <= 0 || npc.ExcludedFromDeathTally())
		{
			return;
		}
		NPC.killCount[num]++;
		if (Main.netMode == 2)
		{
			NetMessage.SendData(83, -1, -1, (NetworkText)null, num, 0f, 0f, 0f, 0, 0, 0);
		}
		int num2 = Sets.KillsToBanner[Item.BannerToItem(num)];
		if (NPC.killCount[num] % num2 == 0 && num > 0)
		{
			int npcID = Item.BannerToNPC(num);
			int num4 = npc.lastInteraction;
			if (!((Entity)Main.player[num4]).active || Main.player[num4].dead)
			{
				num4 = npc.FindClosestPlayer();
			}
			NetworkText networkText = NetworkText.FromLiteral(Language.GetTextValueWith("Mods.V2.Death.DigestedEnemiesAnnouncement", (object)new
			{
				Pred = player.name,
				Number = NPC.killCount[num],
				Prey = NetworkText.FromKey(Lang.GetNPCName(npcID).Key, Array.Empty<object>())
			}));
			if (Main.netMode == 0)
			{
				Main.NewText(((object)networkText).ToString(), (byte)250, (byte)250, (byte)0);
			}
			else if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(networkText, new Color(250, 250, 0), -1);
			}
			int num5 = Item.BannerToItem(num);
			Vector2 vector = ((Entity)npc).position;
			if (num4 >= 0 && num4 < 255)
			{
				vector = ((Entity)Main.player[num4]).position;
			}
			Item.NewItem(((Entity)npc).GetSource_Loot((string)null), (int)vector.X, (int)vector.Y, ((Entity)npc).width, ((Entity)npc).height, num5, 1, false, 0, false, false);
		}
	}

	public override void SaveData(TagCompound tag)
	{
		tag.Add("GLPSpent", (object)GLP.Spent);
		tag.Add("TUMSpent", (object)TUM.Spent);
		tag.Add("ACISpent", (object)ACI.Spent);
		tag.Add("ABSSpent", (object)ABS.Spent);
		foreach (KeyValuePair<string, bool> keyValuePair in ((ModPlayer)this).Player.AsPred().PermanentUpgradesGained)
		{
			tag.Add("[PERM UPGRADES] " + keyValuePair.Key, (object)keyValuePair.Value);
		}
		foreach (KeyValuePair<string, int> keyValuePair2 in ((ModPlayer)this).Player.AsPred().mealCount)
		{
			tag.Add("[DIGESTED] " + keyValuePair2.Key, (object)keyValuePair2.Value);
		}
		foreach (KeyValuePair<string, int> keyValuePair3 in ((ModPlayer)this).Player.AsPred().drinkCount)
		{
			tag.Add("[DRANK] " + keyValuePair3.Key, (object)keyValuePair3.Value);
		}
		foreach (KeyValuePair<string, bool> keyValuePair4 in ((ModPlayer)this).Player.AsPred().GoalsCompleted)
		{
			tag.Add("[GOAL] " + keyValuePair4.Key, (object)keyValuePair4.Value);
		}
	}

	public override void LoadData(TagCompound tag)
	{
		GLP.Spent = tag.GetInt("GLPSpent");
		TUM.Spent = tag.GetInt("TUMSpent");
		ACI.Spent = tag.GetInt("ACISpent");
		ABS.Spent = tag.GetInt("ABSSpent");
		PermanentUpgradesGained = new Dictionary<string, bool>();
		mealCount = new Dictionary<string, int>();
		drinkCount = new Dictionary<string, int>();
		GoalsCompleted = new Dictionary<string, bool>();
		foreach (KeyValuePair<string, object> keyValuePair in tag)
		{
			if (keyValuePair.Key.StartsWith("[PERM UPGRADES] "))
			{
				string realKey = keyValuePair.Key.Remove(0, 16);
				bool permUpgradeUsed = tag.GetBool(keyValuePair.Key);
				PermanentUpgradesGained.Add(realKey, permUpgradeUsed);
			}
			else if (keyValuePair.Key.StartsWith("[DIGESTED] "))
			{
				string realKey2 = keyValuePair.Key.Remove(0, 11);
				int specificMealCount = tag.GetInt(keyValuePair.Key);
				mealCount.Add(realKey2, specificMealCount);
			}
			else if (keyValuePair.Key.StartsWith("[DRANK] "))
			{
				string realKey3 = keyValuePair.Key.Remove(0, 8);
				int specificDrinkCount = tag.GetInt(keyValuePair.Key);
				drinkCount.Add(realKey3, specificDrinkCount);
			}
			else if (keyValuePair.Key.StartsWith("[GOAL] "))
			{
				string realKey4 = keyValuePair.Key.Remove(0, 7);
				bool completeState = tag.GetBool(keyValuePair.Key);
				GoalsCompleted.Add(realKey4, completeState);
			}
		}
	}
}
