using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using BetterDialogue;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.RuntimeDetour;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Biomes;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using V2.Compat;
using V2.Core;
using V2.Core.MainDetours;
using V2.Core.StruggleSystem;
using V2.Core.WorldGeneration;
using V2.Items;
using V2.NPCs;
using V2.NPCs.Vanilla.TownNPCs.TravellingMerchant;
using V2.NPCs.Voraria.TownNPCs.Enigma;
using V2.NPCs.Voraria.TownNPCs.Succubus;
using V2.PlayerHandling;
using V2.Projectiles;
using V2.UI.PredStatsMenu;

namespace V2;

public class V2 : Mod
{
	private delegate void orig_NPCAI(NPC npc);

	private delegate void orig_ProjectileAI(Projectile projectile);

	internal enum MessageType : byte
	{
		Dull,
		RequestSwallowPrey,
		SyncSwallowPrey,
		RequestPlayerPredStatSync,
		DeliverPlayerPredStatSync,
		SyncDigestionCombatTextForPreyNPC,
		SyncDigestionCombatTextForPreyPlayer,
		SyncDigestionCombatTextForPreyProjectile,
		RequestRegurgitatePrey,
		SyncRegurgitatePrey
	}

	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static hook_DoDeathEvents_DropBossPotionsAndHearts _003C0_003E__NoPotionsOrHeartsIfDigested;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<orig_NPCAI, NPC> _003C_003E9__77_0;

		public static Action<orig_ProjectileAI, Projectile> _003C_003E9__77_1;

		public static hook_SetupTravelShop_GetItem _003C_003E9__77_2;

		public static hook_UpdateAudio_DecideOnNewMusic _003C_003E9__77_3;

		public static hook_DrawInterface_36_Cursor _003C_003E9__77_4;

		public static hook_CanBeChasedBy _003C_003E9__77_5;

		public static hook_checkDead _003C_003E9__77_6;

		public static hook_NPCLoot_DropHeals _003C_003E9__77_7;

		public static hook_NPCLoot_DropMoney _003C_003E9__77_8;

		public static hook_NPCLoot_DropItems _003C_003E9__77_9;

		public static hook_DoDeathEvents_CelebrateBossDeath _003C_003E9__77_10;

		public static hook_CheckDrowning _003C_003E9__77_11;

		public static hook_KillMe _003C_003E9__77_12;

		public static hook_GrantArmorBenefits _003C_003E9__77_13;

		public static hook_ApplyEquipFunctional _003C_003E9__77_14;

		public static hook_UpdateArmorSets _003C_003E9__77_15;

		public static hook_UpdateLifeRegen _003C_003E9__77_16;

		public static hook_UpdateBuffs _003C_003E9__77_17;

		public static hook_DashMovement _003C_003E9__77_18;

		public static hook_ItemCheck_ReleaseCritter _003C_003E9__77_19;

		public static hook_ToggleInv _003C_003E9__77_20;

		public static hook_TurnGoldChestIntoDeadMansChest _003C_003E9__77_21;

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_0(orig_NPCAI orig, NPC npc)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			GeneralNPC npcAsV2NPC = npc.AsV2NPC(risky: true);
			PreyNPC npcAsPrey = npc.AsFood(risky: true);
			if (npcAsV2NPC == null || npcAsPrey == null)
			{
				orig(npc);
			}
			else if (((Entity)(object)npc).CurrentCaptor() != null)
			{
				((Entity)npc).velocity = Vector2.Zero;
				((Entity)npc).position = ((Entity)(object)npc).CurrentCaptor().Predator.position;
				npcAsPrey.SpecialPreyAI?.Invoke(npc, ((Entity)(object)npc).CurrentCaptor().Predator);
			}
			else if (npcAsV2NPC.NewAIMethod != null)
			{
				if (npcAsV2NPC.FirstFrame && npcAsV2NPC.FirstFramePreAIMethod != null)
				{
					npcAsV2NPC.FirstFrame = false;
					npcAsV2NPC.FirstFramePreAIMethod(npc);
				}
				npcAsV2NPC.CustomSprite?.Advance();
				if (npcAsV2NPC.NewAIMethod(npc))
				{
					orig(npc);
				}
				else
				{
					NPCLoader.PostAI(npc);
				}
			}
			else
			{
				orig(npc);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_1(orig_ProjectileAI orig, Projectile projectile)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			GeneralProjectile projectileAsV2Projectile = projectile.AsV2Proj(risky: true);
			PreyProjectile projectileAsPrey = projectile.AsFood(risky: true);
			if (projectileAsV2Projectile == null || projectileAsPrey == null)
			{
				orig(projectile);
				return;
			}
			PredProjectile.ResetEffects(projectile);
			if (((Entity)(object)projectile).CurrentCaptor() != null)
			{
				projectile.timeLeft++;
				((Entity)projectile).velocity = Vector2.Zero;
				((Entity)projectile).position = ((Entity)(object)projectile).CurrentCaptor().Predator.position;
				projectileAsPrey.SpecialPreyAI?.Invoke(projectile, ((Entity)(object)projectile).CurrentCaptor().Predator);
			}
			else if (projectileAsV2Projectile.NewAIMethod != null)
			{
				projectileAsV2Projectile.CustomSprite?.Advance();
				if (projectileAsV2Projectile.NewAIMethod(projectile))
				{
					orig(projectile);
				}
				else
				{
					ProjectileLoader.PostAI(projectile);
				}
			}
			else
			{
				orig(projectile);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_2(orig_SetupTravelShop_GetItem orig, Player playerWithHighestLuck, int[] rarity, ref int it, int minimumRarity)
		{
			TravellingMerchant.SetupTravelShop_GetItem(playerWithHighestLuck, rarity, ref it, minimumRarity);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_3(orig_UpdateAudio_DecideOnNewMusic orig, Main instance)
		{
			MainDetours.UpdateAudio_DecideOnNewMusic();
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_4(orig_DrawInterface_36_Cursor orig)
		{
			int mouthState = PredStatsMenuMouthUI.MouthState;
			if ((mouthState != 2 && mouthState != 4) || 1 == 0)
			{
				orig.Invoke();
			}
		}

		internal bool _003CEngageVoraciousGameFuckery_003Eb__77_5(orig_CanBeChasedBy orig, NPC npc, object attacker, bool ignoreDontTakeDamage)
		{
			if (((Entity)npc).active && ((Entity)(object)npc).CurrentCaptor() != null)
			{
				return false;
			}
			return orig.Invoke(npc, attacker, ignoreDontTakeDamage);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_6(orig_checkDead orig, NPC npc)
		{
			NPCDetours.CheckDead(npc);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_7(orig_NPCLoot_DropHeals orig, NPC npc, Player closestPlayer)
		{
			if (!npc.AsFood().Digested)
			{
				orig.Invoke(npc, closestPlayer);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_8(orig_NPCLoot_DropMoney orig, NPC npc, Player closestPlayer)
		{
			if (!npc.AsFood().Digested)
			{
				orig.Invoke(npc, closestPlayer);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_9(orig_NPCLoot_DropItems orig, NPC npc, Player closestPlayer)
		{
			if (!npc.AsFood().Digested)
			{
				orig.Invoke(npc, closestPlayer);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_10(orig_DoDeathEvents_CelebrateBossDeath orig, NPC npc, string typeName)
		{
			NPCDetours.DoDeathEvents_CelebrateBossDeath(npc, typeName);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_11(orig_CheckDrowning orig, Player player)
		{
			if (((Entity)(object)player).CurrentCaptor() == null)
			{
				orig.Invoke(player);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_12(orig_KillMe orig, Player player, PlayerDeathReason damageSource, double dmg, int hitDirection, bool pvp)
		{
			PlayerDetours.KillMe(player, damageSource, dmg, hitDirection, pvp);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_13(orig_GrantArmorBenefits orig, Player player, Item armorPiece)
		{
			V2Player.GrantArmorBenefits(player, armorPiece);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_14(orig_ApplyEquipFunctional orig, Player player, Item item, bool hideVisual)
		{
			if (!item.IsAir && (!item.expertOnly || Main.expertMode) && (!item.masterOnly || Main.masterMode) && (item.AsFood().MaxHealth == -1 || item.AsFood().Health > 0))
			{
				if (item.AsAnItem() != null && item.AsAnItem().AccessoryEffectCode != null)
				{
					item.AsAnItem().AccessoryEffectCode(item, player, hideVisual);
				}
				else
				{
					orig.Invoke(player, item, hideVisual);
				}
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_15(orig_UpdateArmorSets orig, Player player, int i)
		{
			if (ArmorSetHandler.CheckDefinedArmorSets(player))
			{
				player.ApplyArmorSoundAndDustChanges();
			}
			else
			{
				orig.Invoke(player, i);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_16(orig_UpdateLifeRegen orig, Player player)
		{
			PlayerDetours.Detour_UpdateLifeRegen(player);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_17(orig_UpdateBuffs orig, Player player, int i)
		{
			PlayerDetours.Detour_UpdateBuffs(player);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_18(orig_DashMovement orig, Player player)
		{
			if (((Entity)(object)player).CurrentCaptor() == null)
			{
				orig.Invoke(player);
				return;
			}
			player.dashDelay = 60;
			player.dashTime = 0;
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_19(orig_ItemCheck_ReleaseCritter orig, Player player, Item item)
		{
			PlayerDetours.ItemCheck_ReleaseCritter(player, item);
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_20(orig_ToggleInv orig, Player player)
		{
			if (!player.AsPred().InPredStatsMenu || Main.gamePaused)
			{
				orig.Invoke(player);
			}
		}

		internal void _003CEngageVoraciousGameFuckery_003Eb__77_21(orig_TurnGoldChestIntoDeadMansChest orig, DeadMansChestBiome instance, Point position)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			WorldGenDetours.TurnGoldChestIntoDeadMansChest(position);
		}
	}

	internal static V2 Instance;

	internal static Hook NPCLoader_NPCAI_Hook;

	private static readonly MethodInfo NPCLoader_NPCAI_MethodInfo = typeof(Main).Assembly.GetType("Terraria.ModLoader.NPCLoader").GetMethod("NPCAI", BindingFlags.Static | BindingFlags.Public);

	internal static Hook ProjectileLoader_ProjectileAI_Hook;

	private static readonly MethodInfo ProjectileLoader_ProjectileAI_MethodInfo = typeof(Main).Assembly.GetType("Terraria.ModLoader.ProjectileLoader").GetMethod("ProjectileAI", BindingFlags.Static | BindingFlags.Public);

	public static ModKeybind SwallowHotkey { get; set; }

	public static ModKeybind RegurgitateHotkey { get; set; }

	public static ModKeybind FeedHotkey { get; set; }

	public static ModKeybind ItemGulpHotkey { get; set; }

	public static ModKeybind StruggleUpHotkey { get; set; }

	public static ModKeybind StruggleLeftHotkey { get; set; }

	public static ModKeybind StruggleRightHotkey { get; set; }

	public static ModKeybind StruggleDownHotkey { get; set; }

	public static ModKeybind StruggleSpecialHotkey { get; set; }

	public static ModKeybind LayOnBellyHotkey { get; set; }

	public static ModKeybind RespawnAfterDigestionHotkey { get; set; }

	public static bool BlacklistsActive { get; set; }

	public static List<int> VoreNPCBlacklist { get; set; }

	public static List<int> VoreProjectileBlacklist { get; set; }

	public static bool GetFooled { get; set; }

	public static List<ResourcePack> EnabledResourcePacks => Main.AssetSourceController.ActiveResourcePackList.EnabledPacks.ToList();

	public static Dictionary<int, GlobalBuff> ModifiedStatusEffects { get; set; }

	public V2()
	{
		Instance = this;
		BlacklistsActive = true;
		GetFooled = false;
		ModifiedStatusEffects = new Dictionary<int, GlobalBuff>();
	}

	public override void Load()
	{
		SwallowHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "Swallow", "V");
		RegurgitateHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "Regurgitate", "X");
		FeedHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "Feed", "G");
		ItemGulpHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "EatItems", "RightShift");
		StruggleUpHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "StruggleUp", "Up");
		StruggleLeftHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "StruggleLeft", "Left");
		StruggleRightHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "StruggleRight", "Right");
		StruggleDownHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "StruggleDown", "Down");
		StruggleSpecialHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "StruggleSpecial", "Space");
		LayOnBellyHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "LayOnBelly", "L");
		RespawnAfterDigestionHotkey = KeybindLoader.RegisterKeybind((Mod)(object)this, "RespawnAfterDigestion", "LeftShift");
		BetterDialogue.SupportedNPCs.Add(ModContent.NPCType<Lucinda>());
		BetterDialogue.SupportedNPCs.Add(ModContent.NPCType<LucindaBound>());
		BetterDialogue.SupportedNPCs.Add(ModContent.NPCType<Clover>());
		BetterDialogue.SupportedNPCs.Add(ModContent.NPCType<CloverBound>());
		BetterDialogue.RegisterShoppableNPC(18);
		BetterDialogue.RegisterShoppableNPC(ModContent.NPCType<Lucinda>());
		BetterDialogue.RegisterShoppableNPC(ModContent.NPCType<Clover>());
		StruggleChartLoader.Load();
		EngageVoraciousGameFuckery();
	}

	public override void PostSetupContent()
	{
		VoreNPCBlacklist = new List<int> { 369, 376, 663 };
		ModNPC Deviantt = default(ModNPC);
		if (ModContent.TryFind<ModNPC>("Fargowiltas", "Deviantt", ref Deviantt))
		{
			VoreNPCBlacklist.Add(Deviantt.Type);
		}
		VoreProjectileBlacklist = new List<int>();
		if (!BlacklistsActive || GetFooled)
		{
			VoreNPCBlacklist.Clear();
			VoreProjectileBlacklist.Clear();
		}
		Mod munchies = default(Mod);
		if (ModLoader.TryGetMod("munchies", ref munchies))
		{
			new V2MunchiesCompat(munchies).ApplyCompatibility();
		}
		Mod armamentdisplay = default(Mod);
		if (ModLoader.TryGetMod("WeaponDisplay", ref armamentdisplay))
		{
			new V2WeaponDisplay(armamentdisplay).ApplyCompatibility();
		}
	}

	public override void Unload()
	{
		VoreNPCBlacklist = null;
		VoreProjectileBlacklist = null;
		StruggleChartLoader.Unload();
		DisengageVoraciousGameFuckery();
		for (int i = 0; i < NPCID.Count; i++)
		{
			TextureAssets.Npc[i] = ModContent.Request<Texture2D>("Terraria/Images/NPC_" + i, (AssetRequestMode)2);
		}
		for (int j = 0; j < ProjectileID.Count; j++)
		{
			TextureAssets.Projectile[j] = ModContent.Request<Texture2D>("Terraria/Images/Projectile_" + j, (AssetRequestMode)2);
		}
	}

	public static void EngageVoraciousGameFuckery()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		NPCLoader_NPCAI_Hook = new Hook((MethodBase)NPCLoader_NPCAI_MethodInfo, (Delegate)(Action<orig_NPCAI, NPC>)delegate(orig_NPCAI orig, NPC npc)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			GeneralNPC generalNPC = npc.AsV2NPC(risky: true);
			PreyNPC preyNPC = npc.AsFood(risky: true);
			if (generalNPC == null || preyNPC == null)
			{
				orig(npc);
			}
			else if (((Entity)(object)npc).CurrentCaptor() != null)
			{
				((Entity)npc).velocity = Vector2.Zero;
				((Entity)npc).position = ((Entity)(object)npc).CurrentCaptor().Predator.position;
				preyNPC.SpecialPreyAI?.Invoke(npc, ((Entity)(object)npc).CurrentCaptor().Predator);
			}
			else if (generalNPC.NewAIMethod != null)
			{
				if (generalNPC.FirstFrame && generalNPC.FirstFramePreAIMethod != null)
				{
					generalNPC.FirstFrame = false;
					generalNPC.FirstFramePreAIMethod(npc);
				}
				generalNPC.CustomSprite?.Advance();
				if (generalNPC.NewAIMethod(npc))
				{
					orig(npc);
				}
				else
				{
					NPCLoader.PostAI(npc);
				}
			}
			else
			{
				orig(npc);
			}
		});
		NPCLoader_NPCAI_Hook.Apply();
		ProjectileLoader_ProjectileAI_Hook = new Hook((MethodBase)ProjectileLoader_ProjectileAI_MethodInfo, (Delegate)(Action<orig_ProjectileAI, Projectile>)delegate(orig_ProjectileAI orig, Projectile projectile)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			GeneralProjectile generalProjectile = projectile.AsV2Proj(risky: true);
			PreyProjectile preyProjectile = projectile.AsFood(risky: true);
			if (generalProjectile == null || preyProjectile == null)
			{
				orig(projectile);
			}
			else
			{
				PredProjectile.ResetEffects(projectile);
				if (((Entity)(object)projectile).CurrentCaptor() != null)
				{
					projectile.timeLeft++;
					((Entity)projectile).velocity = Vector2.Zero;
					((Entity)projectile).position = ((Entity)(object)projectile).CurrentCaptor().Predator.position;
					preyProjectile.SpecialPreyAI?.Invoke(projectile, ((Entity)(object)projectile).CurrentCaptor().Predator);
				}
				else if (generalProjectile.NewAIMethod != null)
				{
					generalProjectile.CustomSprite?.Advance();
					if (generalProjectile.NewAIMethod(projectile))
					{
						orig(projectile);
					}
					else
					{
						ProjectileLoader.PostAI(projectile);
					}
				}
				else
				{
					orig(projectile);
				}
			}
		});
		ProjectileLoader_ProjectileAI_Hook.Apply();
		object obj = _003C_003Ec._003C_003E9__77_2;
		if (obj == null)
		{
			hook_SetupTravelShop_GetItem val = delegate(orig_SetupTravelShop_GetItem orig, Player playerWithHighestLuck, int[] rarity, ref int it, int minimumRarity)
			{
				TravellingMerchant.SetupTravelShop_GetItem(playerWithHighestLuck, rarity, ref it, minimumRarity);
			};
			_003C_003Ec._003C_003E9__77_2 = val;
			obj = (object)val;
		}
		On_Chest.SetupTravelShop_GetItem += (hook_SetupTravelShop_GetItem)obj;
		object obj2 = _003C_003Ec._003C_003E9__77_3;
		if (obj2 == null)
		{
			hook_UpdateAudio_DecideOnNewMusic val2 = delegate
			{
				MainDetours.UpdateAudio_DecideOnNewMusic();
			};
			_003C_003Ec._003C_003E9__77_3 = val2;
			obj2 = (object)val2;
		}
		On_Main.UpdateAudio_DecideOnNewMusic += (hook_UpdateAudio_DecideOnNewMusic)obj2;
		object obj3 = _003C_003Ec._003C_003E9__77_4;
		if (obj3 == null)
		{
			hook_DrawInterface_36_Cursor val3 = delegate(orig_DrawInterface_36_Cursor orig)
			{
				int mouthState = PredStatsMenuMouthUI.MouthState;
				if ((mouthState != 2 && mouthState != 4) || 1 == 0)
				{
					orig.Invoke();
				}
			};
			_003C_003Ec._003C_003E9__77_4 = val3;
			obj3 = (object)val3;
		}
		On_Main.DrawInterface_36_Cursor += (hook_DrawInterface_36_Cursor)obj3;
		object obj4 = _003C_003Ec._003C_003E9__77_5;
		if (obj4 == null)
		{
			hook_CanBeChasedBy val4 = (orig_CanBeChasedBy orig, NPC npc, object attacker, bool ignoreDontTakeDamage) => (!((Entity)npc).active || ((Entity)(object)npc).CurrentCaptor() == null) && orig.Invoke(npc, attacker, ignoreDontTakeDamage);
			_003C_003Ec._003C_003E9__77_5 = val4;
			obj4 = (object)val4;
		}
		On_NPC.CanBeChasedBy += (hook_CanBeChasedBy)obj4;
		object obj5 = _003C_003Ec._003C_003E9__77_6;
		if (obj5 == null)
		{
			hook_checkDead val5 = delegate(orig_checkDead orig, NPC npc)
			{
				NPCDetours.CheckDead(npc);
			};
			_003C_003Ec._003C_003E9__77_6 = val5;
			obj5 = (object)val5;
		}
		On_NPC.checkDead += (hook_checkDead)obj5;
		object obj6 = _003C_003Ec._003C_003E9__77_7;
		if (obj6 == null)
		{
			hook_NPCLoot_DropHeals val6 = delegate(orig_NPCLoot_DropHeals orig, NPC npc, Player closestPlayer)
			{
				if (!npc.AsFood().Digested)
				{
					orig.Invoke(npc, closestPlayer);
				}
			};
			_003C_003Ec._003C_003E9__77_7 = val6;
			obj6 = (object)val6;
		}
		On_NPC.NPCLoot_DropHeals += (hook_NPCLoot_DropHeals)obj6;
		object obj7 = _003C_003Ec._003C_003E9__77_8;
		if (obj7 == null)
		{
			hook_NPCLoot_DropMoney val7 = delegate(orig_NPCLoot_DropMoney orig, NPC npc, Player closestPlayer)
			{
				if (!npc.AsFood().Digested)
				{
					orig.Invoke(npc, closestPlayer);
				}
			};
			_003C_003Ec._003C_003E9__77_8 = val7;
			obj7 = (object)val7;
		}
		On_NPC.NPCLoot_DropMoney += (hook_NPCLoot_DropMoney)obj7;
		object obj8 = _003C_003Ec._003C_003E9__77_9;
		if (obj8 == null)
		{
			hook_NPCLoot_DropItems val8 = delegate(orig_NPCLoot_DropItems orig, NPC npc, Player closestPlayer)
			{
				if (!npc.AsFood().Digested)
				{
					orig.Invoke(npc, closestPlayer);
				}
			};
			_003C_003Ec._003C_003E9__77_9 = val8;
			obj8 = (object)val8;
		}
		On_NPC.NPCLoot_DropItems += (hook_NPCLoot_DropItems)obj8;
		object obj9 = _003C_003EO._003C0_003E__NoPotionsOrHeartsIfDigested;
		if (obj9 == null)
		{
			hook_DoDeathEvents_DropBossPotionsAndHearts val9 = NoPotionsOrHeartsIfDigested;
			_003C_003EO._003C0_003E__NoPotionsOrHeartsIfDigested = val9;
			obj9 = (object)val9;
		}
		On_NPC.DoDeathEvents_DropBossPotionsAndHearts += (hook_DoDeathEvents_DropBossPotionsAndHearts)obj9;
		object obj10 = _003C_003Ec._003C_003E9__77_10;
		if (obj10 == null)
		{
			hook_DoDeathEvents_CelebrateBossDeath val10 = delegate(orig_DoDeathEvents_CelebrateBossDeath orig, NPC npc, string typeName)
			{
				NPCDetours.DoDeathEvents_CelebrateBossDeath(npc, typeName);
			};
			_003C_003Ec._003C_003E9__77_10 = val10;
			obj10 = (object)val10;
		}
		On_NPC.DoDeathEvents_CelebrateBossDeath += (hook_DoDeathEvents_CelebrateBossDeath)obj10;
		object obj11 = _003C_003Ec._003C_003E9__77_11;
		if (obj11 == null)
		{
			hook_CheckDrowning val11 = delegate(orig_CheckDrowning orig, Player player)
			{
				if (((Entity)(object)player).CurrentCaptor() == null)
				{
					orig.Invoke(player);
				}
			};
			_003C_003Ec._003C_003E9__77_11 = val11;
			obj11 = (object)val11;
		}
		On_Player.CheckDrowning += (hook_CheckDrowning)obj11;
		object obj12 = _003C_003Ec._003C_003E9__77_12;
		if (obj12 == null)
		{
			hook_KillMe val12 = delegate(orig_KillMe orig, Player player, PlayerDeathReason damageSource, double dmg, int hitDirection, bool pvp)
			{
				PlayerDetours.KillMe(player, damageSource, dmg, hitDirection, pvp);
			};
			_003C_003Ec._003C_003E9__77_12 = val12;
			obj12 = (object)val12;
		}
		On_Player.KillMe += (hook_KillMe)obj12;
		object obj13 = _003C_003Ec._003C_003E9__77_13;
		if (obj13 == null)
		{
			hook_GrantArmorBenefits val13 = delegate(orig_GrantArmorBenefits orig, Player player, Item armorPiece)
			{
				V2Player.GrantArmorBenefits(player, armorPiece);
			};
			_003C_003Ec._003C_003E9__77_13 = val13;
			obj13 = (object)val13;
		}
		On_Player.GrantArmorBenefits += (hook_GrantArmorBenefits)obj13;
		object obj14 = _003C_003Ec._003C_003E9__77_14;
		if (obj14 == null)
		{
			hook_ApplyEquipFunctional val14 = delegate(orig_ApplyEquipFunctional orig, Player player, Item item, bool hideVisual)
			{
				if (!item.IsAir && (!item.expertOnly || Main.expertMode) && (!item.masterOnly || Main.masterMode) && (item.AsFood().MaxHealth == -1 || item.AsFood().Health > 0))
				{
					if (item.AsAnItem() != null && item.AsAnItem().AccessoryEffectCode != null)
					{
						item.AsAnItem().AccessoryEffectCode(item, player, hideVisual);
					}
					else
					{
						orig.Invoke(player, item, hideVisual);
					}
				}
			};
			_003C_003Ec._003C_003E9__77_14 = val14;
			obj14 = (object)val14;
		}
		On_Player.ApplyEquipFunctional += (hook_ApplyEquipFunctional)obj14;
		object obj15 = _003C_003Ec._003C_003E9__77_15;
		if (obj15 == null)
		{
			hook_UpdateArmorSets val15 = delegate(orig_UpdateArmorSets orig, Player player, int i)
			{
				if (ArmorSetHandler.CheckDefinedArmorSets(player))
				{
					player.ApplyArmorSoundAndDustChanges();
				}
				else
				{
					orig.Invoke(player, i);
				}
			};
			_003C_003Ec._003C_003E9__77_15 = val15;
			obj15 = (object)val15;
		}
		On_Player.UpdateArmorSets += (hook_UpdateArmorSets)obj15;
		object obj16 = _003C_003Ec._003C_003E9__77_16;
		if (obj16 == null)
		{
			hook_UpdateLifeRegen val16 = delegate(orig_UpdateLifeRegen orig, Player player)
			{
				PlayerDetours.Detour_UpdateLifeRegen(player);
			};
			_003C_003Ec._003C_003E9__77_16 = val16;
			obj16 = (object)val16;
		}
		On_Player.UpdateLifeRegen += (hook_UpdateLifeRegen)obj16;
		object obj17 = _003C_003Ec._003C_003E9__77_17;
		if (obj17 == null)
		{
			hook_UpdateBuffs val17 = delegate(orig_UpdateBuffs orig, Player player, int i)
			{
				PlayerDetours.Detour_UpdateBuffs(player);
			};
			_003C_003Ec._003C_003E9__77_17 = val17;
			obj17 = (object)val17;
		}
		On_Player.UpdateBuffs += (hook_UpdateBuffs)obj17;
		object obj18 = _003C_003Ec._003C_003E9__77_18;
		if (obj18 == null)
		{
			hook_DashMovement val18 = delegate(orig_DashMovement orig, Player player)
			{
				if (((Entity)(object)player).CurrentCaptor() == null)
				{
					orig.Invoke(player);
				}
				else
				{
					player.dashDelay = 60;
					player.dashTime = 0;
				}
			};
			_003C_003Ec._003C_003E9__77_18 = val18;
			obj18 = (object)val18;
		}
		On_Player.DashMovement += (hook_DashMovement)obj18;
		object obj19 = _003C_003Ec._003C_003E9__77_19;
		if (obj19 == null)
		{
			hook_ItemCheck_ReleaseCritter val19 = delegate(orig_ItemCheck_ReleaseCritter orig, Player player, Item item)
			{
				PlayerDetours.ItemCheck_ReleaseCritter(player, item);
			};
			_003C_003Ec._003C_003E9__77_19 = val19;
			obj19 = (object)val19;
		}
		On_Player.ItemCheck_ReleaseCritter += (hook_ItemCheck_ReleaseCritter)obj19;
		object obj20 = _003C_003Ec._003C_003E9__77_20;
		if (obj20 == null)
		{
			hook_ToggleInv val20 = delegate(orig_ToggleInv orig, Player player)
			{
				if (!player.AsPred().InPredStatsMenu || Main.gamePaused)
				{
					orig.Invoke(player);
				}
			};
			_003C_003Ec._003C_003E9__77_20 = val20;
			obj20 = (object)val20;
		}
		On_Player.ToggleInv += (hook_ToggleInv)obj20;
		object obj21 = _003C_003Ec._003C_003E9__77_21;
		if (obj21 == null)
		{
			hook_TurnGoldChestIntoDeadMansChest val21 = delegate(orig_TurnGoldChestIntoDeadMansChest orig, DeadMansChestBiome instance, Point position)
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				WorldGenDetours.TurnGoldChestIntoDeadMansChest(position);
			};
			_003C_003Ec._003C_003E9__77_21 = val21;
			obj21 = (object)val21;
		}
		On_DeadMansChestBiome.TurnGoldChestIntoDeadMansChest += (hook_TurnGoldChestIntoDeadMansChest)obj21;
	}

	public static void DisengageVoraciousGameFuckery()
	{
		if (NPCLoader_NPCAI_Hook != null)
		{
			NPCLoader_NPCAI_Hook.Undo();
			NPCLoader_NPCAI_Hook = null;
		}
		if (ProjectileLoader_ProjectileAI_Hook != null)
		{
			ProjectileLoader_ProjectileAI_Hook.Undo();
			ProjectileLoader_ProjectileAI_Hook = null;
		}
	}

	private static void NoPotionsOrHeartsIfDigested(orig_DoDeathEvents_DropBossPotionsAndHearts orig, NPC npc, ref string typeName)
	{
		if (!npc.AsFood().Digested)
		{
			orig.Invoke(npc, ref typeName);
		}
	}

	public override void HandlePacket(BinaryReader reader, int whoAmI)
	{
		MessageType msgType = (MessageType)reader.ReadByte();
		switch (msgType)
		{
		case MessageType.Dull:
			((Mod)this).Logger.WarnFormat(".     .   .\nyour message is too boring !!!\nsuper bland and basically a small crumb pile to my hungry tummy :c\ni need seconds of whatever your next tasty packet is to make up for it !\n-rose", (object)msgType);
			break;
		case MessageType.RequestSwallowPrey:
			HandlePacket_RequestSwallowPrey(reader, whoAmI);
			break;
		case MessageType.SyncSwallowPrey:
			HandlePacket_SyncSwallowPrey(reader, whoAmI);
			break;
		case MessageType.RequestPlayerPredStatSync:
			HandlePacket_RequestPlayerPredStatSync(reader, whoAmI);
			break;
		case MessageType.DeliverPlayerPredStatSync:
			HandlePacket_DeliverPlayerPredStatSync(reader, whoAmI);
			break;
		case MessageType.SyncDigestionCombatTextForPreyNPC:
			HandlePacket_SyncDigestionCombatTextForPreyNPC(reader, whoAmI);
			break;
		case MessageType.SyncDigestionCombatTextForPreyPlayer:
			HandlePacket_SyncDigestionCombatTextForPreyPlayer(reader, whoAmI);
			break;
		case MessageType.SyncDigestionCombatTextForPreyProjectile:
			HandlePacket_SyncDigestionCombatTextForPreyProjectile(reader, whoAmI);
			break;
		case MessageType.RequestRegurgitatePrey:
			HandlePacket_RequestRegurgitatePrey(reader, whoAmI);
			break;
		case MessageType.SyncRegurgitatePrey:
			HandlePacket_SyncRegurgitatePrey(reader, whoAmI);
			break;
		default:
			((Mod)this).Logger.WarnFormat("hi !!\nthomas says your net work message doesnt make sense\ni think it was fine tho!\ntasted good and made my tummy make happy sounds c:\n-rose", Array.Empty<object>());
			break;
		}
	}

	public void InformOfIncorrectPacketRecipe()
	{
		((Mod)this).Logger.WarnFormat("hi !!\nyour packet wasnt a very good snack\nlook over your recipe and try again with a new one\nmaybe next time youll make something yummier\n-rose", Array.Empty<object>());
	}

	public void HandlePacket_RequestSwallowPrey(BinaryReader reader, int whoAmI)
	{
		if (Main.netMode == 2)
		{
			Entity pred = (Entity)(reader.ReadByte() switch
			{
				0 => Main.player[reader.ReadInt32()], 
				1 => Main.npc[reader.ReadInt32()], 
				2 => Main.projectile[reader.ReadInt32()], 
				_ => null, 
			});
			if (pred != null)
			{
				PreyType preyType = (PreyType)reader.ReadByte();
				PreyData newData = preyType switch
				{
					PreyType.Player => PreyData.NewData((Entity)(object)Main.player[reader.ReadInt32()]), 
					PreyType.NPC => PreyData.NewData((Entity)(object)Main.npc[reader.ReadInt32()]), 
					PreyType.Projectile => PreyData.NewData((Entity)(object)Main.projectile[reader.ReadInt32()]), 
					PreyType.Item => PreyData.NewData((Entity)(object)Main.item[reader.ReadInt32()]), 
					PreyType.Liquid => PreyData.NewLiquidData(reader.ReadInt32(), reader.ReadDouble()), 
					PreyType.Custom => null, 
					PreyType.Undefined => null, 
					_ => null, 
				};
				if (newData != null)
				{
					int originalClientWhoAmI = reader.ReadInt32();
					Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
					if (predPlayer != null)
					{
						if (preyType == PreyType.Liquid)
						{
							PredPlayer.Drink(predPlayer, -1, -1, newData, 2, originalClientWhoAmI);
						}
						PredPlayer.Swallow(predPlayer, newData.Instance, 2, originalClientWhoAmI);
						return;
					}
					NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
					if (predNPC != null)
					{
						PredNPC.Swallow(predNPC, newData.Instance, 2, originalClientWhoAmI);
						return;
					}
					Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
					if (predProjectile != null)
					{
						PredProjectile.Swallow(predProjectile, newData.Instance, 2, originalClientWhoAmI);
					}
					return;
				}
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_SyncSwallowPrey(BinaryReader reader, int whoAmI)
	{
		if (Main.netMode == 1)
		{
			Entity pred = (Entity)(reader.ReadByte() switch
			{
				0 => Main.player[reader.ReadInt32()], 
				1 => Main.npc[reader.ReadInt32()], 
				2 => Main.projectile[reader.ReadInt32()], 
				_ => null, 
			});
			if (pred != null)
			{
				PreyType preyType = (PreyType)reader.ReadByte();
				PreyData newData = preyType switch
				{
					PreyType.Player => PreyData.NewData((Entity)(object)Main.player[reader.ReadInt32()]), 
					PreyType.NPC => PreyData.NewData((Entity)(object)Main.npc[reader.ReadInt32()]), 
					PreyType.Projectile => PreyData.NewData((Entity)(object)Main.projectile[reader.ReadInt32()]), 
					PreyType.Item => PreyData.NewData((Entity)(object)Main.item[reader.ReadInt32()]), 
					PreyType.Liquid => PreyData.NewLiquidData(reader.ReadInt32(), reader.ReadDouble()), 
					PreyType.Custom => null, 
					PreyType.Undefined => null, 
					_ => null, 
				};
				if (newData != null)
				{
					int originalClientWhoAmI = reader.ReadInt32();
					Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
					if (predPlayer != null)
					{
						if (preyType == PreyType.Liquid)
						{
							PredPlayer.Drink(predPlayer, -1, -1, newData, 3, originalClientWhoAmI);
						}
						PredPlayer.Swallow(predPlayer, newData.Instance, 3, originalClientWhoAmI);
						return;
					}
					NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
					if (predNPC != null)
					{
						PredNPC.Swallow(predNPC, newData.Instance, 3, originalClientWhoAmI);
						return;
					}
					Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
					if (predProjectile != null)
					{
						PredProjectile.Swallow(predProjectile, newData.Instance, 3, originalClientWhoAmI);
					}
					return;
				}
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_RequestPlayerPredStatSync(BinaryReader reader, int whoAmI)
	{
		if (Main.netMode == 2)
		{
			int originalPlayerWhoAmI = reader.ReadByte();
			if (originalPlayerWhoAmI >= 0 && originalPlayerWhoAmI <= 255)
			{
				Player player = Main.player[originalPlayerWhoAmI];
				player.AsPred().GLP.Spent = reader.ReadInt32();
				player.AsPred().TUM.Spent = reader.ReadInt32();
				player.AsPred().ACI.Spent = reader.ReadInt32();
				player.AsPred().ABS.Spent = reader.ReadInt32();
				ModPacket packet = ((Mod)this).GetPacket(256);
				((BinaryWriter)(object)packet).Write((byte)4);
				((BinaryWriter)(object)packet).Write((byte)originalPlayerWhoAmI);
				((BinaryWriter)(object)packet).Write(player.AsPred().GLP.Spent);
				((BinaryWriter)(object)packet).Write(player.AsPred().TUM.Spent);
				((BinaryWriter)(object)packet).Write(player.AsPred().ACI.Spent);
				((BinaryWriter)(object)packet).Write(player.AsPred().ABS.Spent);
				packet.Send(-1, originalPlayerWhoAmI);
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_DeliverPlayerPredStatSync(BinaryReader reader, int whoAmI)
	{
		if (Main.netMode == 1)
		{
			int originalPlayerWhoAmI = reader.ReadByte();
			if (originalPlayerWhoAmI >= 0 && originalPlayerWhoAmI <= 255)
			{
				Player player = Main.player[originalPlayerWhoAmI];
				player.AsPred().GLP.Spent = reader.ReadInt32();
				player.AsPred().TUM.Spent = reader.ReadInt32();
				player.AsPred().ACI.Spent = reader.ReadInt32();
				player.AsPred().ABS.Spent = reader.ReadInt32();
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_SyncDigestionCombatTextForPreyNPC(BinaryReader reader, int whoAmI)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode == 1)
		{
			int npcWhoAmI = reader.ReadInt32();
			if (npcWhoAmI >= 0 && npcWhoAmI <= Main.maxNPCs)
			{
				if (ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
				{
					NPC npc = Main.npc[npcWhoAmI];
					CombatText obj = Main.combatText[CombatText.NewText(((Entity)npc).Hitbox, npc.friendly ? Color.DarkGreen : Color.LimeGreen, reader.ReadInt32(), false, true)];
					obj.position.X = reader.ReadSingle();
					obj.position.Y = reader.ReadSingle();
					obj.velocity.X = reader.ReadSingle();
					obj.velocity.Y = reader.ReadSingle();
				}
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_SyncDigestionCombatTextForPreyPlayer(BinaryReader reader, int whoAmI)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode == 1)
		{
			int playerWhoAmI = reader.ReadInt32();
			if (playerWhoAmI >= 0 && playerWhoAmI <= 255)
			{
				if (ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
				{
					Player player = Main.player[playerWhoAmI];
					CombatText obj = Main.combatText[CombatText.NewText(((Entity)player).Hitbox, Color.DarkGreen, reader.ReadInt32(), false, true)];
					obj.position.X = reader.ReadSingle();
					obj.position.Y = reader.ReadSingle();
					obj.velocity.X = reader.ReadSingle();
					obj.velocity.Y = reader.ReadSingle();
				}
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_SyncDigestionCombatTextForPreyProjectile(BinaryReader reader, int whoAmI)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (Main.netMode == 1)
		{
			int projectileWhoAmI = reader.ReadInt32();
			if (projectileWhoAmI >= 0 && projectileWhoAmI <= Main.maxProjectiles)
			{
				if (ModContent.GetInstance<V2ClientConfig>().ShowChurnDamageNumbers)
				{
					Projectile projectile = Main.projectile[projectileWhoAmI];
					CombatText obj = Main.combatText[CombatText.NewText(((Entity)projectile).Hitbox, Color.DarkGreen, reader.ReadInt32(), false, true)];
					obj.position.X = reader.ReadSingle();
					obj.position.Y = reader.ReadSingle();
					obj.velocity.X = reader.ReadSingle();
					obj.velocity.Y = reader.ReadSingle();
				}
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_RequestRegurgitatePrey(BinaryReader reader, int whoAmI)
	{
		if (Main.netMode == 2)
		{
			Entity pred = (Entity)(reader.ReadByte() switch
			{
				0 => Main.player[reader.ReadInt32()], 
				1 => Main.npc[reader.ReadInt32()], 
				2 => Main.projectile[reader.ReadInt32()], 
				_ => null, 
			});
			if (pred != null)
			{
				int preyIndex = reader.ReadInt32();
				int originalClientWhoAmI = reader.ReadInt32();
				Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
				if (predPlayer != null)
				{
					PredPlayer.Regurgitate(predPlayer, preyIndex, 2, originalClientWhoAmI);
					return;
				}
				NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
				if (predNPC != null)
				{
					PredNPC.Regurgitate(predNPC, preyIndex, 2, originalClientWhoAmI);
					return;
				}
				Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
				if (predProjectile != null)
				{
					PredProjectile.Regurgitate(predProjectile, preyIndex, 2, originalClientWhoAmI);
				}
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}

	public void HandlePacket_SyncRegurgitatePrey(BinaryReader reader, int whoAmI)
	{
		if (Main.netMode == 1)
		{
			Entity pred = (Entity)(reader.ReadByte() switch
			{
				0 => Main.player[reader.ReadInt32()], 
				1 => Main.npc[reader.ReadInt32()], 
				2 => Main.projectile[reader.ReadInt32()], 
				_ => null, 
			});
			if (pred != null)
			{
				int preyIndex = reader.ReadInt32();
				int originalClientWhoAmI = reader.ReadInt32();
				Player predPlayer = (Player)(object)((pred is Player) ? pred : null);
				if (predPlayer != null)
				{
					PredPlayer.Regurgitate(predPlayer, preyIndex, 3, originalClientWhoAmI);
					return;
				}
				NPC predNPC = (NPC)(object)((pred is NPC) ? pred : null);
				if (predNPC != null)
				{
					PredNPC.Regurgitate(predNPC, preyIndex, 3, originalClientWhoAmI);
					return;
				}
				Projectile predProjectile = (Projectile)(object)((pred is Projectile) ? pred : null);
				if (predProjectile != null)
				{
					PredProjectile.Regurgitate(predProjectile, preyIndex, 3, originalClientWhoAmI);
				}
				return;
			}
		}
		InformOfIncorrectPacketRecipe();
	}
}
