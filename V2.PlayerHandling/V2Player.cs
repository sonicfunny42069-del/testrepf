using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.Items;
using V2.Items.Voraria.Armor;
using V2.UI;

namespace V2.PlayerHandling;

public class V2Player : ModPlayer
{
	public List<DelegateGeneralItemDrawingUI> generalItemUIDrawMethods;

	public int GuideHelpText;

	public static List<NPC> _hallucinationCandidates = new List<NPC>();

	public bool setBonusActive;

	public bool setBonusShouldBeDisplayed;

	public (double baseRegen, double additiveRegenModifier, double multiplicativeRegenModifier, double flatRegenBonus) HealthRegenNatural;

	public (double baseRegen, double additiveRegenModifier, double multiplicativeRegenModifier, double flatRegenBonus) HealthRegenArtificial;

	public double healthRegenTime;

	public double healthRegenCount;

	public bool ShroomNecklace { get; set; }

	public bool BeeTransformation { get; set; }

	public Dictionary<string, bool> LocationsVisited { get; set; }

	public List<HealthRegenEffect> HealthRegenEffects { get; set; }

	public override void Initialize()
	{
		ResetHealthRegenTime();
		ResetHealthRegenEffectList();
		LocationsVisited = new Dictionary<string, bool>();
	}

	public override void ResetEffects()
	{
		generalItemUIDrawMethods = new List<DelegateGeneralItemDrawingUI>();
		setBonusActive = false;
		setBonusShouldBeDisplayed = false;
		ShroomNecklace = false;
		BeeTransformation = false;
		if (((Entity)((ModPlayer)this).Player).whoAmI == Main.myPlayer)
		{
			if (((ModPlayer)this).Player.talkNPC != -1 && ((Entity)(object)((ModPlayer)this).Player.TalkNPC).CurrentCaptor() != null)
			{
				Main.CloseNPCChatOrSign();
			}
			if (((ModPlayer)this).Player.AsV2Player().BeeTransformation)
			{
				((Entity)((ModPlayer)this).Player).width = 12;
			}
			else
			{
				((Entity)((ModPlayer)this).Player).width = 20;
			}
			ResetHealthRegenEffectList();
		}
	}

	public override void ModifyLuck(ref float luck)
	{
		if (((ModPlayer)this).Player.armor[0].type == ModContent.ItemType<CloverHeadAccessories>())
		{
			luck += 0.3f;
		}
		if (((ModPlayer)this).Player.armor[1].type == ModContent.ItemType<CloverSweater>())
		{
			luck += 0.1f;
		}
		if (((ModPlayer)this).Player.armor[2].type == ModContent.ItemType<CloverStockings>())
		{
			luck += 0.1f;
		}
	}

	public override void UpdateDead()
	{
		ResetHealthRegenTime();
		ResetHealthRegenEffectList();
	}

	public override void OnHitByNPC(NPC npc, HurtInfo hurtInfo)
	{
		ResetHealthRegenTime();
	}

	public override void OnHitByProjectile(Projectile proj, HurtInfo hurtInfo)
	{
		ResetHealthRegenTime();
	}

	public override void PostUpdateMiscEffects()
	{
		HandleSittingAndSleepingHealthRegenEffect();
		if (((ModPlayer)this).Player.ZoneSkyHeight)
		{
			AddLocationVisitMark("sky");
		}
		if (((ModPlayer)this).Player.ZoneForest)
		{
			AddLocationVisitMark("forest");
		}
		if (((ModPlayer)this).Player.ZoneDirtLayerHeight)
		{
			AddLocationVisitMark("underground");
		}
		if (((ModPlayer)this).Player.ZoneRockLayerHeight)
		{
			AddLocationVisitMark("cavern");
		}
		if (((ModPlayer)this).Player.ZoneUnderworldHeight)
		{
			AddLocationVisitMark("hell");
		}
		if (((ModPlayer)this).Player.ZoneSnow && ((ModPlayer)this).Player.ZoneOverworldHeight)
		{
			AddLocationVisitMark("tundra");
		}
		if (((ModPlayer)this).Player.ZoneSnow && (((ModPlayer)this).Player.ZoneDirtLayerHeight || ((ModPlayer)this).Player.ZoneRockLayerHeight))
		{
			AddLocationVisitMark("underground_tundra");
		}
		if (((ModPlayer)this).Player.ZoneDesert)
		{
			AddLocationVisitMark("desert");
		}
		if (((ModPlayer)this).Player.ZoneUndergroundDesert)
		{
			AddLocationVisitMark("underground_desert");
		}
		if (((ModPlayer)this).Player.ZoneCorrupt)
		{
			AddLocationVisitMark("corruption");
		}
		if (((ModPlayer)this).Player.ZoneCrimson)
		{
			AddLocationVisitMark("crimson");
		}
		if (((ModPlayer)this).Player.ZoneBeach)
		{
			AddLocationVisitMark("beach");
		}
		if (((ModPlayer)this).Player.ZoneJungle && ((ModPlayer)this).Player.ZoneOverworldHeight)
		{
			AddLocationVisitMark("jungle");
		}
		if (((ModPlayer)this).Player.ZoneJungle && (((ModPlayer)this).Player.ZoneDirtLayerHeight || ((ModPlayer)this).Player.ZoneRockLayerHeight))
		{
			AddLocationVisitMark("underground_jungle");
		}
		if (((ModPlayer)this).Player.ZoneGraveyard)
		{
			AddLocationVisitMark("graveyard");
		}
		if (((ModPlayer)this).Player.ZoneGranite)
		{
			AddLocationVisitMark("granite");
		}
		if (((ModPlayer)this).Player.ZoneMarble)
		{
			AddLocationVisitMark("marble");
		}
		if (((ModPlayer)this).Player.ZoneMeteor)
		{
			AddLocationVisitMark("meteorite");
		}
		if (((ModPlayer)this).Player.ZoneDungeon)
		{
			AddLocationVisitMark("dungeon");
		}
		if (((ModPlayer)this).Player.ZoneLihzhardTemple)
		{
			AddLocationVisitMark("temple");
		}
		if (!Main.dayTime)
		{
			AddLocationVisitMark("nighttime");
		}
		if (((ModPlayer)this).Player.ZoneSandstorm)
		{
			AddLocationVisitMark("sandstorm");
		}
		if (Main.IsItAHappyWindyDay)
		{
			AddLocationVisitMark("windy_day");
		}
		if (Main.IsItRaining && (((ModPlayer)this).Player.ZoneOverworldHeight || ((ModPlayer)this).Player.ZoneSkyHeight))
		{
			if (((ModPlayer)this).Player.ZoneSnow)
			{
				AddLocationVisitMark("snowing");
			}
			else if (Main.IsItStorming)
			{
				AddLocationVisitMark("thunderstorm");
			}
			else
			{
				AddLocationVisitMark("raining");
			}
		}
		if (Main.IsItAHappyWindyDay)
		{
			AddLocationVisitMark("windy_day");
		}
		if (Main.bloodMoon)
		{
			AddLocationVisitMark("blood_moon");
		}
		if (Main.eclipse)
		{
			AddLocationVisitMark("eclipse");
		}
		void AddLocationVisitMark(string place)
		{
			if (LocationsVisited.ContainsKey(place))
			{
				LocationsVisited[place] = true;
			}
			else
			{
				LocationsVisited.TryAdd(place, value: true);
			}
		}
	}

	public override void HideDrawLayers(PlayerDrawSet drawInfo)
	{
		foreach (PlayerDrawLayer drawLayer in PlayerDrawLayerLoader.Layers)
		{
			if (((ModPlayer)this).Player.AsV2Player().BeeTransformation && drawLayer != PlayerDrawLayers.HeldItem && ((ModType)drawLayer).Mod == null)
			{
				drawLayer.Hide();
			}
		}
	}

	public bool HasVisitedLocation(string place)
	{
		if (LocationsVisited.TryGetValue(place, out var value))
		{
			return value;
		}
		LocationsVisited.TryAdd(place, value: false);
		return false;
	}

	public override void SaveData(TagCompound tag)
	{
		Dictionary<string, bool> locationsVisited = LocationsVisited;
		if (locationsVisited == null || locationsVisited.Count <= 0)
		{
			return;
		}
		List<string> locationsVisited2 = new List<string>();
		foreach (KeyValuePair<string, bool> location in LocationsVisited)
		{
			if (location.Value)
			{
				locationsVisited2.Add(location.Key);
			}
		}
		tag["visitedLocations"] = locationsVisited2;
	}

	public override void LoadData(TagCompound tag)
	{
		List<string> locationsVisited = tag.GetList<string>("visitedLocations").ToList();
		if (locationsVisited.Count <= 0)
		{
			return;
		}
		LocationsVisited = new Dictionary<string, bool>();
		foreach (string location in locationsVisited)
		{
			LocationsVisited.Add(location, value: true);
		}
	}

	public static void GrantArmorBenefits(Player player, Item armorPiece)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0733: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Unknown result type (might be due to invalid IL or missing references)
		//IL_083d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_103c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1046: Unknown result type (might be due to invalid IL or missing references)
		//IL_104b: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_10af: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1118: Unknown result type (might be due to invalid IL or missing references)
		//IL_111d: Unknown result type (might be due to invalid IL or missing references)
		//IL_116e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_117d: Unknown result type (might be due to invalid IL or missing references)
		//IL_11af: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11be: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1240: Unknown result type (might be due to invalid IL or missing references)
		//IL_124a: Unknown result type (might be due to invalid IL or missing references)
		//IL_124f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1281: Unknown result type (might be due to invalid IL or missing references)
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1290: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_142d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1437: Unknown result type (might be due to invalid IL or missing references)
		//IL_143c: Unknown result type (might be due to invalid IL or missing references)
		//IL_146e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_147d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1509: Unknown result type (might be due to invalid IL or missing references)
		//IL_150e: Unknown result type (might be due to invalid IL or missing references)
		//IL_155f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1569: Unknown result type (might be due to invalid IL or missing references)
		//IL_156e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15da: Unknown result type (might be due to invalid IL or missing references)
		//IL_15df: Unknown result type (might be due to invalid IL or missing references)
		//IL_161e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1628: Unknown result type (might be due to invalid IL or missing references)
		//IL_162d: Unknown result type (might be due to invalid IL or missing references)
		//IL_166c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1676: Unknown result type (might be due to invalid IL or missing references)
		//IL_167b: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1754: Unknown result type (might be due to invalid IL or missing references)
		//IL_175e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1763: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1806: Unknown result type (might be due to invalid IL or missing references)
		//IL_180b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_185b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1860: Unknown result type (might be due to invalid IL or missing references)
		//IL_187e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1888: Unknown result type (might be due to invalid IL or missing references)
		//IL_188d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1913: Unknown result type (might be due to invalid IL or missing references)
		//IL_191d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1922: Unknown result type (might be due to invalid IL or missing references)
		//IL_1954: Unknown result type (might be due to invalid IL or missing references)
		//IL_195e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1963: Unknown result type (might be due to invalid IL or missing references)
		//IL_1995: Unknown result type (might be due to invalid IL or missing references)
		//IL_199f: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19de: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f73: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_200b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2015: Unknown result type (might be due to invalid IL or missing references)
		//IL_201a: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_213f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2149: Unknown result type (might be due to invalid IL or missing references)
		//IL_214e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2104: Unknown result type (might be due to invalid IL or missing references)
		//IL_210e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2113: Unknown result type (might be due to invalid IL or missing references)
		//IL_2196: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2270: Unknown result type (might be due to invalid IL or missing references)
		//IL_227a: Unknown result type (might be due to invalid IL or missing references)
		//IL_227f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2312: Unknown result type (might be due to invalid IL or missing references)
		//IL_231c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2321: Unknown result type (might be due to invalid IL or missing references)
		//IL_235a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2364: Unknown result type (might be due to invalid IL or missing references)
		//IL_2369: Unknown result type (might be due to invalid IL or missing references)
		//IL_239b: Unknown result type (might be due to invalid IL or missing references)
		//IL_23a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_23aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_240f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2419: Unknown result type (might be due to invalid IL or missing references)
		//IL_241e: Unknown result type (might be due to invalid IL or missing references)
		//IL_243c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2446: Unknown result type (might be due to invalid IL or missing references)
		//IL_244b: Unknown result type (might be due to invalid IL or missing references)
		//IL_248f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2499: Unknown result type (might be due to invalid IL or missing references)
		//IL_249e: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2505: Unknown result type (might be due to invalid IL or missing references)
		//IL_250f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2514: Unknown result type (might be due to invalid IL or missing references)
		//IL_2552: Unknown result type (might be due to invalid IL or missing references)
		//IL_255c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2561: Unknown result type (might be due to invalid IL or missing references)
		if (armorPiece.IsAir || (armorPiece.AsFood().MaxHealth != -1 && armorPiece.AsFood().Health <= 0))
		{
			return;
		}
		int type = armorPiece.type;
		player.RefreshInfoAccsFromItemType(armorPiece);
		player.RefreshMechanicalAccsFromItemType(type);
		if (armorPiece.type == 3017 || armorPiece.type == 3993)
		{
			player.flowerBoots = true;
			if (((Entity)player).whoAmI == Main.myPlayer)
			{
				player.DoBootsEffect(new TileActionAttempt(player.DoBootsEffect_PlaceFlowersOnTile));
			}
		}
		if (armorPiece.type == 5001)
		{
			player.moveSpeed += 0.25f;
			player.moonLordLegs = true;
		}
		player.statDefense += armorPiece.defense;
		player.lifeRegen += armorPiece.lifeRegen;
		if (armorPiece.shieldSlot > 0)
		{
			player.hasRaisableShield = true;
		}
		if (armorPiece.AsAnItem().ArmorEffectCode != null)
		{
			armorPiece.AsAnItem().ArmorEffectCode(armorPiece, player);
			return;
		}
		switch (armorPiece.type)
		{
		case 3797:
		{
			player.maxTurrets++;
			player.manaCost -= 0.1f;
			ref StatModifier damage30 = ref player.GetDamage(DamageClass.Magic);
			damage30 += 0.1f;
			break;
		}
		case 3798:
		{
			ref StatModifier damage28 = ref player.GetDamage(DamageClass.Magic);
			damage28 += 0.1f;
			ref StatModifier damage29 = ref player.GetDamage(DamageClass.Summon);
			damage29 += 0.2f;
			break;
		}
		case 3799:
		{
			ref StatModifier damage27 = ref player.GetDamage(DamageClass.Summon);
			damage27 += 0.1f;
			player.GetCritChance(DamageClass.Magic) += 20f;
			player.moveSpeed += 0.2f;
			break;
		}
		case 3800:
			player.maxTurrets++;
			player.lifeRegen += 4;
			break;
		case 3801:
		{
			ref StatModifier damage25 = ref player.GetDamage(DamageClass.Melee);
			damage25 += 0.15f;
			ref StatModifier damage26 = ref player.GetDamage(DamageClass.Summon);
			damage26 += 0.15f;
			break;
		}
		case 3802:
		{
			ref StatModifier damage24 = ref player.GetDamage(DamageClass.Summon);
			damage24 += 0.15f;
			player.GetCritChance(DamageClass.Melee) += 15f;
			player.moveSpeed += 0.15f;
			break;
		}
		case 3806:
			player.maxTurrets++;
			player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
			break;
		case 3807:
		{
			ref StatModifier damage22 = ref player.GetDamage(DamageClass.Melee);
			damage22 += 0.2f;
			ref StatModifier damage23 = ref player.GetDamage(DamageClass.Summon);
			damage23 += 0.2f;
			break;
		}
		case 3808:
		{
			ref StatModifier damage21 = ref player.GetDamage(DamageClass.Summon);
			damage21 += 0.1f;
			player.GetCritChance(DamageClass.Melee) += 15f;
			player.moveSpeed += 0.2f;
			break;
		}
		case 3803:
			player.maxTurrets++;
			player.GetCritChance(DamageClass.Ranged) += 10f;
			break;
		case 3804:
		{
			ref StatModifier damage19 = ref player.GetDamage(DamageClass.Ranged);
			damage19 += 0.2f;
			ref StatModifier damage20 = ref player.GetDamage(DamageClass.Summon);
			damage20 += 0.2f;
			player.huntressAmmoCost90 = true;
			break;
		}
		case 3805:
		{
			ref StatModifier damage18 = ref player.GetDamage(DamageClass.Summon);
			damage18 += 0.1f;
			player.moveSpeed += 0.2f;
			break;
		}
		case 3871:
		{
			player.maxTurrets += 2;
			ref StatModifier damage16 = ref player.GetDamage(DamageClass.Melee);
			damage16 += 0.1f;
			ref StatModifier damage17 = ref player.GetDamage(DamageClass.Summon);
			damage17 += 0.1f;
			break;
		}
		case 3872:
		{
			ref StatModifier damage15 = ref player.GetDamage(DamageClass.Summon);
			damage15 += 0.3f;
			player.lifeRegen += 8;
			break;
		}
		case 3873:
		{
			ref StatModifier damage14 = ref player.GetDamage(DamageClass.Summon);
			damage14 += 0.2f;
			player.GetCritChance(DamageClass.Melee) += 20f;
			player.moveSpeed += 0.2f;
			break;
		}
		case 3874:
		{
			player.maxTurrets += 2;
			ref StatModifier damage12 = ref player.GetDamage(DamageClass.Magic);
			damage12 += 0.15f;
			ref StatModifier damage13 = ref player.GetDamage(DamageClass.Summon);
			damage13 += 0.15f;
			break;
		}
		case 3875:
		{
			ref StatModifier damage10 = ref player.GetDamage(DamageClass.Summon);
			damage10 += 0.25f;
			ref StatModifier damage11 = ref player.GetDamage(DamageClass.Magic);
			damage11 += 0.1f;
			player.manaCost -= 0.15f;
			break;
		}
		case 3876:
		{
			ref StatModifier damage9 = ref player.GetDamage(DamageClass.Summon);
			damage9 += 0.2f;
			player.GetCritChance(DamageClass.Magic) += 25f;
			player.moveSpeed += 0.2f;
			break;
		}
		case 3877:
		{
			player.maxTurrets += 2;
			ref StatModifier damage8 = ref player.GetDamage(DamageClass.Summon);
			damage8 += 0.1f;
			player.GetCritChance(DamageClass.Ranged) += 10f;
			break;
		}
		case 3878:
		{
			ref StatModifier damage6 = ref player.GetDamage(DamageClass.Summon);
			damage6 += 0.25f;
			ref StatModifier damage7 = ref player.GetDamage(DamageClass.Ranged);
			damage7 += 0.25f;
			player.ammoCost80 = true;
			break;
		}
		case 3879:
		{
			ref StatModifier damage5 = ref player.GetDamage(DamageClass.Summon);
			damage5 += 0.25f;
			player.GetCritChance(DamageClass.Ranged) += 10f;
			player.moveSpeed += 0.2f;
			break;
		}
		case 3880:
		{
			player.maxTurrets += 2;
			ref StatModifier damage3 = ref player.GetDamage(DamageClass.Summon);
			damage3 += 0.2f;
			ref StatModifier damage4 = ref player.GetDamage(DamageClass.Melee);
			damage4 += 0.2f;
			break;
		}
		case 3881:
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
			player.GetCritChance(DamageClass.Melee) += 5f;
			ref StatModifier damage2 = ref player.GetDamage(DamageClass.Summon);
			damage2 += 0.2f;
			break;
		}
		case 3882:
		{
			ref StatModifier damage = ref player.GetDamage(DamageClass.Summon);
			damage += 0.2f;
			player.GetCritChance(DamageClass.Melee) += 20f;
			player.moveSpeed += 0.3f;
			break;
		}
		}
		if (armorPiece.type == 5100)
		{
			SpawnHallucination(player, armorPiece);
		}
		if (armorPiece.type == 268)
		{
			player.accDivingHelm = true;
		}
		if (armorPiece.type == 238)
		{
			ref StatModifier damage31 = ref player.GetDamage(DamageClass.Magic);
			damage31 += 0.05f;
			if (Main.tenthAnniversaryWorld)
			{
				player.maxMinions++;
			}
		}
		if (armorPiece.type == 3770)
		{
			player.slowFall = true;
		}
		if (armorPiece.type == 4404)
		{
			player.canFloatInWater = true;
		}
		if (armorPiece.type == 3776)
		{
			ref StatModifier damage32 = ref player.GetDamage(DamageClass.Magic);
			damage32 += 0.15f;
			ref StatModifier damage33 = ref player.GetDamage(DamageClass.Summon);
			damage33 += 0.15f;
		}
		if (armorPiece.type == 3777)
		{
			player.statManaMax2 += 40;
			ref StatModifier damage34 = ref player.GetDamage(DamageClass.Summon);
			damage34 += 0.1f;
			player.maxMinions++;
		}
		if (armorPiece.type == 3778)
		{
			player.statManaMax2 += 40;
			ref StatModifier damage35 = ref player.GetDamage(DamageClass.Magic);
			damage35 += 0.1f;
			player.maxMinions++;
		}
		if (armorPiece.type == 3212)
		{
			player.GetArmorPenetration(DamageClass.Generic) += 5f;
		}
		if (armorPiece.type == 2277)
		{
			ref StatModifier damage36 = ref player.GetDamage(DamageClass.Generic);
			damage36 += 0.05f;
			player.GetCritChance(DamageClass.Generic) += 5f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
			player.moveSpeed += 0.1f;
		}
		if (armorPiece.type == 2279)
		{
			ref StatModifier damage37 = ref player.GetDamage(DamageClass.Magic);
			damage37 += 0.06f;
			player.GetCritChance(DamageClass.Magic) += 6f;
			player.manaCost -= 0.1f;
		}
		if (armorPiece.type == 3109 || armorPiece.type == 4008)
		{
			player.nightVision = true;
		}
		if (armorPiece.type == 256 || armorPiece.type == 257 || armorPiece.type == 258)
		{
			player.GetCritChance(DamageClass.Generic) += 3f;
		}
		if (armorPiece.type == 3374)
		{
			player.GetCritChance(DamageClass.Ranged) += 4f;
		}
		if (armorPiece.type == 3375)
		{
			ref StatModifier damage38 = ref player.GetDamage(DamageClass.Ranged);
			damage38 += 0.05f;
		}
		if (armorPiece.type == 3376)
		{
			player.GetCritChance(DamageClass.Ranged) += 4f;
		}
		if (armorPiece.type == 151 || armorPiece.type == 959 || armorPiece.type == 152 || armorPiece.type == 153)
		{
			ref StatModifier damage39 = ref player.GetDamage(DamageClass.Ranged);
			damage39 += 0.05f;
		}
		if (armorPiece.type == 2275)
		{
			ref StatModifier damage40 = ref player.GetDamage(DamageClass.Magic);
			damage40 += 0.06f;
			player.GetCritChance(DamageClass.Magic) += 6f;
		}
		if (armorPiece.type == 123 || armorPiece.type == 124 || armorPiece.type == 125)
		{
			ref StatModifier damage41 = ref player.GetDamage(DamageClass.Magic);
			damage41 += 0.09f;
		}
		if (armorPiece.type == 228 || armorPiece.type == 960)
		{
			player.statManaMax2 += 40;
			player.GetCritChance(DamageClass.Magic) += 6f;
		}
		if (armorPiece.type == 229 || armorPiece.type == 961)
		{
			player.statManaMax2 += 20;
			ref StatModifier damage42 = ref player.GetDamage(DamageClass.Magic);
			damage42 += 0.06f;
		}
		if (armorPiece.type == 230 || armorPiece.type == 962)
		{
			player.statManaMax2 += 20;
			player.GetCritChance(DamageClass.Magic) += 6f;
		}
		if (armorPiece.type == 100 || armorPiece.type == 101 || armorPiece.type == 102)
		{
			player.GetCritChance(DamageClass.Generic) += 5f;
		}
		if (armorPiece.type == 956 || armorPiece.type == 957 || armorPiece.type == 958)
		{
			player.GetCritChance(DamageClass.Generic) += 5f;
		}
		if (armorPiece.type == 792 || armorPiece.type == 793 || armorPiece.type == 794)
		{
			ref StatModifier damage43 = ref player.GetDamage(DamageClass.Generic);
			damage43 += 0.03f;
		}
		if (armorPiece.type == 231)
		{
			player.GetCritChance(DamageClass.Melee) += 7f;
		}
		if (armorPiece.type == 232)
		{
			ref StatModifier damage44 = ref player.GetDamage(DamageClass.Melee);
			damage44 += 0.07f;
		}
		if (armorPiece.type == 233)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.07f;
		}
		if (armorPiece.type == 371)
		{
			player.GetCritChance(DamageClass.Magic) += 9f;
			ref StatModifier damage45 = ref player.GetDamage(DamageClass.Magic);
			damage45 += 0.1f;
			player.statManaMax2 += 40;
		}
		if (armorPiece.type == 372)
		{
			player.moveSpeed += 0.1f;
			ref StatModifier damage46 = ref player.GetDamage(DamageClass.Melee);
			damage46 += 0.15f;
		}
		if (armorPiece.type == 373)
		{
			ref StatModifier damage47 = ref player.GetDamage(DamageClass.Ranged);
			damage47 += 0.1f;
			player.GetCritChance(DamageClass.Ranged) += 10f;
		}
		if (armorPiece.type == 374)
		{
			player.GetCritChance(DamageClass.Generic) += 5f;
		}
		if (armorPiece.type == 375)
		{
			ref StatModifier damage48 = ref player.GetDamage(DamageClass.Generic);
			damage48 += 0.03f;
			player.moveSpeed += 0.1f;
		}
		if (armorPiece.type == 376)
		{
			ref StatModifier damage49 = ref player.GetDamage(DamageClass.Magic);
			damage49 += 0.15f;
			player.statManaMax2 += 60;
		}
		if (armorPiece.type == 377)
		{
			player.GetCritChance(DamageClass.Melee) += 8f;
			ref StatModifier damage50 = ref player.GetDamage(DamageClass.Melee);
			damage50 += 0.1f;
		}
		if (armorPiece.type == 378)
		{
			ref StatModifier damage51 = ref player.GetDamage(DamageClass.Ranged);
			damage51 += 0.12f;
			player.GetCritChance(DamageClass.Ranged) += 7f;
		}
		if (armorPiece.type == 379)
		{
			ref StatModifier damage52 = ref player.GetDamage(DamageClass.Generic);
			damage52 += 0.07f;
		}
		if (armorPiece.type == 380)
		{
			player.GetCritChance(DamageClass.Generic) += 10f;
		}
		if (armorPiece.type >= 2367 && armorPiece.type <= 2369)
		{
			player.fishingSkill += 5;
		}
		if (armorPiece.type == 400)
		{
			ref StatModifier damage53 = ref player.GetDamage(DamageClass.Magic);
			damage53 += 0.12f;
			player.GetCritChance(DamageClass.Magic) += 12f;
			player.statManaMax2 += 80;
		}
		if (armorPiece.type == 401)
		{
			player.GetCritChance(DamageClass.Melee) += 7f;
			ref StatModifier damage54 = ref player.GetDamage(DamageClass.Melee);
			damage54 += 0.14f;
		}
		if (armorPiece.type == 402)
		{
			ref StatModifier damage55 = ref player.GetDamage(DamageClass.Ranged);
			damage55 += 0.14f;
			player.GetCritChance(DamageClass.Ranged) += 10f;
		}
		if (armorPiece.type == 403)
		{
			ref StatModifier damage56 = ref player.GetDamage(DamageClass.Generic);
			damage56 += 0.08f;
		}
		if (armorPiece.type == 404)
		{
			player.GetCritChance(DamageClass.Generic) += 7f;
			player.moveSpeed += 0.05f;
		}
		if (armorPiece.type == 1205)
		{
			ref StatModifier damage57 = ref player.GetDamage(DamageClass.Melee);
			damage57 += 0.12f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.12f;
		}
		if (armorPiece.type == 1206)
		{
			ref StatModifier damage58 = ref player.GetDamage(DamageClass.Ranged);
			damage58 += 0.09f;
			player.GetCritChance(DamageClass.Ranged) += 9f;
		}
		if (armorPiece.type == 1207)
		{
			ref StatModifier damage59 = ref player.GetDamage(DamageClass.Magic);
			damage59 += 0.09f;
			player.GetCritChance(DamageClass.Magic) += 9f;
			player.statManaMax2 += 60;
		}
		if (armorPiece.type == 1208)
		{
			ref StatModifier damage60 = ref player.GetDamage(DamageClass.Generic);
			damage60 += 0.03f;
			player.GetCritChance(DamageClass.Generic) += 2f;
		}
		if (armorPiece.type == 1209)
		{
			ref StatModifier damage61 = ref player.GetDamage(DamageClass.Generic);
			damage61 += 0.02f;
			player.GetCritChance(DamageClass.Generic) += 1f;
		}
		if (armorPiece.type == 1210)
		{
			ref StatModifier damage62 = ref player.GetDamage(DamageClass.Melee);
			damage62 += 0.11f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.11f;
			player.moveSpeed += 0.07f;
		}
		if (armorPiece.type == 1211)
		{
			player.GetCritChance(DamageClass.Ranged) += 15f;
			player.moveSpeed += 0.08f;
		}
		if (armorPiece.type == 1212)
		{
			player.GetCritChance(DamageClass.Magic) += 18f;
			player.statManaMax2 += 80;
		}
		if (armorPiece.type == 1213)
		{
			player.GetCritChance(DamageClass.Generic) += 6f;
		}
		if (armorPiece.type == 1214)
		{
			player.moveSpeed += 0.11f;
			ref StatModifier damage63 = ref player.GetDamage(DamageClass.Generic);
			damage63 += 0.08f;
		}
		if (armorPiece.type == 1215)
		{
			ref StatModifier damage64 = ref player.GetDamage(DamageClass.Melee);
			damage64 += 0.09f;
			player.GetCritChance(DamageClass.Melee) += 9f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.09f;
		}
		if (armorPiece.type == 1216)
		{
			ref StatModifier damage65 = ref player.GetDamage(DamageClass.Ranged);
			damage65 += 0.16f;
			player.GetCritChance(DamageClass.Ranged) += 7f;
		}
		if (armorPiece.type == 1217)
		{
			ref StatModifier damage66 = ref player.GetDamage(DamageClass.Magic);
			damage66 += 0.16f;
			player.GetCritChance(DamageClass.Magic) += 7f;
			player.statManaMax2 += 100;
		}
		if (armorPiece.type == 1218)
		{
			ref StatModifier damage67 = ref player.GetDamage(DamageClass.Generic);
			damage67 += 0.04f;
			player.GetCritChance(DamageClass.Generic) += 3f;
		}
		if (armorPiece.type == 1219)
		{
			ref StatModifier damage68 = ref player.GetDamage(DamageClass.Generic);
			damage68 += 0.03f;
			player.GetCritChance(DamageClass.Generic) += 3f;
			player.moveSpeed += 0.06f;
		}
		if (armorPiece.type == 558 || armorPiece.type == 4898)
		{
			ref StatModifier damage69 = ref player.GetDamage(DamageClass.Magic);
			damage69 += 0.12f;
			player.GetCritChance(DamageClass.Magic) += 12f;
			player.statManaMax2 += 100;
		}
		if (armorPiece.type == 559 || armorPiece.type == 4896)
		{
			player.GetCritChance(DamageClass.Melee) += 10f;
			ref StatModifier damage70 = ref player.GetDamage(DamageClass.Melee);
			damage70 += 0.1f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
		}
		if (armorPiece.type == 553 || armorPiece.type == 4897)
		{
			ref StatModifier damage71 = ref player.GetDamage(DamageClass.Ranged);
			damage71 += 0.15f;
			player.GetCritChance(DamageClass.Ranged) += 8f;
		}
		if (armorPiece.type == 4873 || armorPiece.type == 4899)
		{
			ref StatModifier damage72 = ref player.GetDamage(DamageClass.Summon);
			damage72 += 0.1f;
			player.maxMinions++;
		}
		if (armorPiece.type == 551 || armorPiece.type == 4900)
		{
			player.GetCritChance(DamageClass.Generic) += 7f;
		}
		if (armorPiece.type == 552 || armorPiece.type == 4901)
		{
			ref StatModifier damage73 = ref player.GetDamage(DamageClass.Generic);
			damage73 += 0.07f;
			player.moveSpeed += 0.08f;
		}
		if (armorPiece.type == 4982)
		{
			player.GetCritChance(DamageClass.Generic) += 5f;
			player.manaCost -= 0.1f;
		}
		if (armorPiece.type == 4983)
		{
			ref StatModifier damage74 = ref player.GetDamage(DamageClass.Generic);
			damage74 += 0.05f;
			player.huntressAmmoCost90 = true;
		}
		if (armorPiece.type == 4984)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
			player.moveSpeed += 0.2f;
		}
		if (armorPiece.type == 1001)
		{
			ref StatModifier damage75 = ref player.GetDamage(DamageClass.Melee);
			damage75 += 0.16f;
			player.GetCritChance(DamageClass.Melee) += 6f;
		}
		if (armorPiece.type == 1002)
		{
			ref StatModifier damage76 = ref player.GetDamage(DamageClass.Ranged);
			damage76 += 0.16f;
			player.chloroAmmoCost80 = true;
		}
		if (armorPiece.type == 1003)
		{
			player.statManaMax2 += 80;
			player.manaCost -= 0.17f;
			ref StatModifier damage77 = ref player.GetDamage(DamageClass.Magic);
			damage77 += 0.16f;
		}
		if (armorPiece.type == 1004)
		{
			ref StatModifier damage78 = ref player.GetDamage(DamageClass.Generic);
			damage78 += 0.05f;
			player.GetCritChance(DamageClass.Generic) += 7f;
		}
		if (armorPiece.type == 1005)
		{
			player.GetCritChance(DamageClass.Generic) += 8f;
			player.moveSpeed += 0.05f;
		}
		if (armorPiece.type == 2189)
		{
			player.statManaMax2 += 60;
			player.manaCost -= 0.13f;
			ref StatModifier damage79 = ref player.GetDamage(DamageClass.Magic);
			damage79 += 0.1f;
			player.GetCritChance(DamageClass.Magic) += 10f;
		}
		if (armorPiece.type == 1504)
		{
			ref StatModifier damage80 = ref player.GetDamage(DamageClass.Magic);
			damage80 += 0.07f;
			player.GetCritChance(DamageClass.Magic) += 7f;
		}
		if (armorPiece.type == 1505)
		{
			ref StatModifier damage81 = ref player.GetDamage(DamageClass.Magic);
			damage81 += 0.08f;
			player.moveSpeed += 0.08f;
		}
		if (armorPiece.type == 1546)
		{
			player.GetCritChance(DamageClass.Ranged) += 5f;
			player.arrowDamage *= 1.15f;
		}
		if (armorPiece.type == 1547)
		{
			player.GetCritChance(DamageClass.Ranged) += 5f;
			player.bulletDamage *= 1.15f;
		}
		if (armorPiece.type == 1548)
		{
			player.GetCritChance(DamageClass.Ranged) += 5f;
			player.specialistDamage *= 1.15f;
		}
		if (armorPiece.type == 1549)
		{
			player.GetCritChance(DamageClass.Ranged) += 13f;
			ref StatModifier damage82 = ref player.GetDamage(DamageClass.Ranged);
			damage82 += 0.13f;
			player.ammoCost80 = true;
		}
		if (armorPiece.type == 1550)
		{
			player.GetCritChance(DamageClass.Ranged) += 7f;
			player.moveSpeed += 0.12f;
		}
		if (armorPiece.type == 1282)
		{
			player.statManaMax2 += 20;
			player.manaCost -= 0.05f;
		}
		if (armorPiece.type == 1283)
		{
			player.statManaMax2 += 40;
			player.manaCost -= 0.07f;
		}
		if (armorPiece.type == 1284)
		{
			player.statManaMax2 += 40;
			player.manaCost -= 0.09f;
		}
		if (armorPiece.type == 1285)
		{
			player.statManaMax2 += 60;
			player.manaCost -= 0.11f;
		}
		if (armorPiece.type == 1286 || armorPiece.type == 4256)
		{
			player.statManaMax2 += 60;
			player.manaCost -= 0.13f;
		}
		if (armorPiece.type == 1287)
		{
			player.statManaMax2 += 80;
			player.manaCost -= 0.15f;
		}
		if (armorPiece.type == 1316 || armorPiece.type == 1317 || armorPiece.type == 1318)
		{
			player.aggro += 250;
		}
		if (armorPiece.type == 1316)
		{
			ref StatModifier damage83 = ref player.GetDamage(DamageClass.Melee);
			damage83 += 0.06f;
		}
		if (armorPiece.type == 1317)
		{
			ref StatModifier damage84 = ref player.GetDamage(DamageClass.Melee);
			damage84 += 0.08f;
			player.GetCritChance(DamageClass.Melee) += 8f;
		}
		if (armorPiece.type == 1318)
		{
			player.GetCritChance(DamageClass.Melee) += 4f;
		}
		if (armorPiece.type == 2199 || armorPiece.type == 2202)
		{
			player.aggro += 250;
		}
		if (armorPiece.type == 2201)
		{
			player.aggro += 400;
		}
		if (armorPiece.type == 2199)
		{
			ref StatModifier damage85 = ref player.GetDamage(DamageClass.Melee);
			damage85 += 0.06f;
		}
		if (armorPiece.type == 2200)
		{
			ref StatModifier damage86 = ref player.GetDamage(DamageClass.Melee);
			damage86 += 0.08f;
			player.GetCritChance(DamageClass.Melee) += 8f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.06f;
			player.moveSpeed += 0.06f;
		}
		if (armorPiece.type == 2201)
		{
			ref StatModifier damage87 = ref player.GetDamage(DamageClass.Melee);
			damage87 += 0.05f;
			player.GetCritChance(DamageClass.Melee) += 5f;
		}
		if (armorPiece.type == 2202)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.06f;
			player.moveSpeed += 0.06f;
		}
		if (armorPiece.type == 684)
		{
			ref StatModifier damage88 = ref player.GetDamage(DamageClass.Ranged);
			damage88 += 0.16f;
			ref StatModifier damage89 = ref player.GetDamage(DamageClass.Melee);
			damage89 += 0.16f;
		}
		if (armorPiece.type == 685)
		{
			player.GetCritChance(DamageClass.Melee) += 11f;
			player.GetCritChance(DamageClass.Ranged) += 11f;
		}
		if (armorPiece.type == 686)
		{
			player.moveSpeed += 0.08f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
		}
		if (armorPiece.type == 5068)
		{
			player.maxMinions++;
			ref StatModifier damage90 = ref player.GetDamage(DamageClass.Summon);
			damage90 += 0.05f;
		}
		if (armorPiece.type == 2361)
		{
			player.maxMinions++;
			ref StatModifier damage91 = ref player.GetDamage(DamageClass.Summon);
			damage91 += 0.04f;
		}
		if (armorPiece.type == 2362)
		{
			player.maxMinions++;
			ref StatModifier damage92 = ref player.GetDamage(DamageClass.Summon);
			damage92 += 0.04f;
		}
		if (armorPiece.type == 2363)
		{
			ref StatModifier damage93 = ref player.GetDamage(DamageClass.Summon);
			damage93 += 0.05f;
		}
		if (armorPiece.type == 3266)
		{
			ref StatModifier damage94 = ref player.GetDamage(DamageClass.Summon);
			damage94 += 0.08f;
		}
		if (armorPiece.type == 3267)
		{
			player.maxMinions++;
		}
		if (armorPiece.type == 3268)
		{
			ref StatModifier damage95 = ref player.GetDamage(DamageClass.Summon);
			damage95 += 0.08f;
		}
		if (armorPiece.type == 410)
		{
			player.pickSpeed -= 0.1f;
		}
		if (armorPiece.type == 411)
		{
			player.pickSpeed -= 0.1f;
		}
		if (armorPiece.type >= 1158 && armorPiece.type <= 1161)
		{
			player.maxMinions++;
		}
		if (armorPiece.type == 1159)
		{
			player.whipRangeMultiplier += 0.1f;
		}
		if (armorPiece.type >= 1159 && armorPiece.type <= 1161)
		{
			ref StatModifier damage96 = ref player.GetDamage(DamageClass.Summon);
			damage96 += 0.1f;
		}
		if (armorPiece.type >= 2370 && armorPiece.type <= 2371)
		{
			ref StatModifier damage97 = ref player.GetDamage(DamageClass.Summon);
			damage97 += 0.05f;
			player.maxMinions++;
		}
		if (armorPiece.type == 2372)
		{
			ref StatModifier damage98 = ref player.GetDamage(DamageClass.Summon);
			damage98 += 0.06f;
			player.maxMinions++;
		}
		if (armorPiece.type == 3381)
		{
			player.maxMinions++;
			player.maxTurrets++;
			ref StatModifier damage99 = ref player.GetDamage(DamageClass.Summon);
			damage99 += 0.22f;
		}
		if (armorPiece.type == 3382 || armorPiece.type == 3383)
		{
			player.maxMinions += 2;
			player.whipRangeMultiplier += 0.15f;
			ref StatModifier damage100 = ref player.GetDamage(DamageClass.Summon);
			damage100 += 0.22f;
		}
		if (armorPiece.type == 2763)
		{
			player.aggro += 300;
			player.GetCritChance(DamageClass.Melee) += 26f;
			player.lifeRegen += 2;
		}
		if (armorPiece.type == 2764)
		{
			player.aggro += 300;
			ref StatModifier damage101 = ref player.GetDamage(DamageClass.Melee);
			damage101 += 0.29f;
			player.lifeRegen += 2;
		}
		if (armorPiece.type == 2765)
		{
			player.aggro += 300;
			player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
			player.moveSpeed += 0.15f;
			player.lifeRegen += 2;
		}
		if (armorPiece.type == 2757)
		{
			player.GetCritChance(DamageClass.Ranged) += 7f;
			ref StatModifier damage102 = ref player.GetDamage(DamageClass.Ranged);
			damage102 += 0.16f;
		}
		if (armorPiece.type == 2758)
		{
			player.ammoCost75 = true;
			player.GetCritChance(DamageClass.Ranged) += 12f;
			ref StatModifier damage103 = ref player.GetDamage(DamageClass.Ranged);
			damage103 += 0.12f;
		}
		if (armorPiece.type == 2759)
		{
			player.GetCritChance(DamageClass.Ranged) += 8f;
			ref StatModifier damage104 = ref player.GetDamage(DamageClass.Ranged);
			damage104 += 0.08f;
			player.moveSpeed += 0.1f;
		}
		if (armorPiece.type == 2760)
		{
			player.statManaMax2 += 60;
			player.manaCost -= 0.15f;
			player.GetCritChance(DamageClass.Magic) += 7f;
			ref StatModifier damage105 = ref player.GetDamage(DamageClass.Magic);
			damage105 += 0.07f;
		}
		if (armorPiece.type == 2761)
		{
			ref StatModifier damage106 = ref player.GetDamage(DamageClass.Magic);
			damage106 += 0.09f;
			player.GetCritChance(DamageClass.Magic) += 9f;
		}
		if (armorPiece.type == 2762)
		{
			player.moveSpeed += 0.1f;
			ref StatModifier damage107 = ref player.GetDamage(DamageClass.Magic);
			damage107 += 0.1f;
		}
		if (armorPiece.type == 1832)
		{
			player.maxMinions++;
			ref StatModifier damage108 = ref player.GetDamage(DamageClass.Summon);
			damage108 += 0.11f;
		}
		if (armorPiece.type == 1833)
		{
			player.maxMinions += 2;
			ref StatModifier damage109 = ref player.GetDamage(DamageClass.Summon);
			damage109 += 0.11f;
		}
		if (armorPiece.type == 1834)
		{
			player.moveSpeed += 0.2f;
			player.maxMinions++;
			ref StatModifier damage110 = ref player.GetDamage(DamageClass.Summon);
			damage110 += 0.11f;
		}
		if (armorPiece.type == 4256 || (armorPiece.type >= 1282 && armorPiece.type <= 1287))
		{
			player.hasGemRobe = true;
		}
		ItemLoader.UpdateEquip(armorPiece, player);
	}

	private static void SpawnHallucination(Player player, Item item)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (((Entity)player).whoAmI != Main.myPlayer)
		{
			return;
		}
		player.insanityShadowCooldown = Utils.Clamp<int>(player.insanityShadowCooldown - 1, 0, 100);
		if (player.insanityShadowCooldown > 0)
		{
			return;
		}
		player.insanityShadowCooldown = Main.rand.Next(20, 101);
		float num = 500f;
		int damage = 18;
		_hallucinationCandidates.Clear();
		for (int i = 0; i < 200; i++)
		{
			NPC nPC = Main.npc[i];
			if (nPC.CanBeChasedBy((object)player, false) && !(((Entity)player).Distance(((Entity)nPC).Center) > num) && Collision.CanHitLine(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, ((Entity)nPC).position, ((Entity)nPC).width, ((Entity)nPC).height))
			{
				_hallucinationCandidates.Add(nPC);
			}
		}
		if (_hallucinationCandidates.Count != 0)
		{
			Vector2 spawnposition = default(Vector2);
			Vector2 spawnvelocity = default(Vector2);
			float ai = default(float);
			float ai2 = default(float);
			Projectile.RandomizeInsanityShadowFor((Entity)(object)Utils.NextFromCollection<NPC>(Main.rand, _hallucinationCandidates), false, ref spawnposition, ref spawnvelocity, ref ai, ref ai2);
			Projectile.NewProjectile((IEntitySource)new EntitySource_ItemUse(player, item, (string)null), spawnposition, spawnvelocity, 964, damage, 0f, ((Entity)player).whoAmI, ai, ai2, 0f);
		}
	}

	public static void Detour_UpdateArmorSets(Player player)
	{
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Unknown result type (might be due to invalid IL or missing references)
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1403: Unknown result type (might be due to invalid IL or missing references)
		//IL_140d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1412: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1511: Unknown result type (might be due to invalid IL or missing references)
		//IL_151b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1520: Unknown result type (might be due to invalid IL or missing references)
		//IL_158e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_159d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1745: Unknown result type (might be due to invalid IL or missing references)
		//IL_174a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1770: Unknown result type (might be due to invalid IL or missing references)
		//IL_177d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1782: Unknown result type (might be due to invalid IL or missing references)
		//IL_1787: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_17db: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1697: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8e: Unknown result type (might be due to invalid IL or missing references)
		player.setBonus = "";
		if (ArmorSetHandler.CheckDefinedArmorSets(player))
		{
			player.ApplyArmorSoundAndDustChanges();
			return;
		}
		int type = player.armor[0].type;
		int type2 = player.armor[1].type;
		int type3 = player.armor[2].type;
		if (type <= 736)
		{
			if (type <= 687)
			{
				if (type != 89)
				{
					if (type == 90)
					{
						goto IL_01ce;
					}
					if (type == 687 && type2 == 688 && type3 == 689)
					{
						goto IL_0231;
					}
				}
				else if (type2 == 80 && type3 == 76)
				{
					goto IL_0231;
				}
			}
			else if (type != 730)
			{
				if (type != 733)
				{
					if (type == 736 && type2 == 737 && type3 == 738)
					{
						goto IL_01f5;
					}
				}
				else if (type2 == 734 && type3 == 735)
				{
					goto IL_01f5;
				}
			}
			else if (type2 == 731 && type3 == 732)
			{
				goto IL_01f5;
			}
		}
		else if (type <= 1548)
		{
			if (type != 924)
			{
				if (type == 954)
				{
					goto IL_01ce;
				}
				if ((uint)(type - 1546) <= 2u && type2 == 1549 && type3 == 1550)
				{
					player.setBonus = Language.GetTextValue("ArmorSetBonus.Shroomite");
					player.shroomiteStealth = true;
				}
			}
			else if (type2 == 925 && type3 == 926)
			{
				goto IL_01f5;
			}
		}
		else if (type != 2509)
		{
			if (type != 2512)
			{
				if (type == 5279 && type2 == 5280 && type3 == 5281)
				{
					player.setBonus = Language.GetTextValue("ArmorSetBonus.AshWood");
					player.ashWoodBonus = true;
				}
			}
			else if (type2 == 2513 && type3 == 2514)
			{
				goto IL_01f5;
			}
		}
		else if (type2 == 2510 && type3 == 2511)
		{
			goto IL_01f5;
		}
		goto IL_026c;
		IL_026c:
		if ((player.head == 3 && player.body == 3 && player.legs == 3) || ((player.head == 73 || player.head == 4) && player.body == 4 && player.legs == 4) || (player.head == 48 && player.body == 29 && player.legs == 28) || (player.head == 49 && player.body == 30 && player.legs == 29))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.MetalTier2");
			player.statDefense += 3;
		}
		if (player.head == 50 && player.body == 31 && player.legs == 30)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Platinum");
			player.statDefense += 4;
		}
		if (player.head == 112 && player.body == 75 && player.legs == 64)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Pumpkin");
			ref StatModifier damage = ref player.GetDamage(DamageClass.Generic);
			damage += 0.1f;
		}
		if (player.head == 180 && player.body == 182 && player.legs == 122)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Gladiator");
			player.noKnockback = true;
		}
		if (player.head == 22 && player.body == 14 && player.legs == 14)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Ninja");
			player.moveSpeed += 0.2f;
		}
		if (player.head == 188 && player.body == 189 && player.legs == 129)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Fossil");
			player.ammoCost80 = true;
		}
		if ((player.head == 75 || player.head == 7) && player.body == 7 && player.legs == 7)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Bone");
			player.GetCritChance(DamageClass.Ranged) += 10f;
		}
		if (player.head == 157 && player.body == 105 && player.legs == 98)
		{
			int num = 0;
			player.setBonus = Language.GetTextValue("ArmorSetBonus.BeetleDamage");
			player.beetleOffense = true;
			player.beetleCounter -= 3f;
			player.beetleCounter -= (float)(player.beetleCountdown / 10);
			player.beetleCountdown++;
			if (player.beetleCounter < 0f)
			{
				player.beetleCounter = 0f;
			}
			int num2 = 400;
			int num3 = 1200;
			int num4 = 4600;
			if (player.beetleCounter > (float)(num2 + num3 + num4 + num3))
			{
				player.beetleCounter = num2 + num3 + num4 + num3;
			}
			if (player.beetleCounter > (float)(num2 + num3 + num4))
			{
				player.AddBuff(100, 5, false, false);
				num = 3;
			}
			else if (player.beetleCounter > (float)(num2 + num3))
			{
				player.AddBuff(99, 5, false, false);
				num = 2;
			}
			else if (player.beetleCounter > (float)num2)
			{
				player.AddBuff(98, 5, false, false);
				num = 1;
			}
			if (num < player.beetleOrbs)
			{
				player.beetleCountdown = 0;
			}
			else if (num > player.beetleOrbs)
			{
				player.beetleCounter += 200f;
			}
			if (num != player.beetleOrbs && player.beetleOrbs > 0)
			{
				for (int j = 0; j < Player.MaxBuffs; j++)
				{
					if (player.buffType[j] >= 98 && player.buffType[j] <= 100 && player.buffType[j] != 97 + num)
					{
						player.DelBuff(j);
					}
				}
			}
		}
		else if (player.head == 157 && player.body == 106 && player.legs == 98)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.BeetleDefense");
			player.beetleDefense = true;
			player.beetleCounter += 1f;
			int num5 = 180;
			if (player.beetleCounter >= (float)num5)
			{
				if (player.beetleOrbs > 0 && player.beetleOrbs < 3)
				{
					for (int k = 0; k < Player.MaxBuffs; k++)
					{
						if (player.buffType[k] >= 95 && player.buffType[k] <= 96)
						{
							player.DelBuff(k);
						}
					}
				}
				if (player.beetleOrbs < 3)
				{
					player.AddBuff(95 + player.beetleOrbs, 5, false, false);
					player.beetleCounter = 0f;
				}
				else
				{
					player.beetleCounter = num5;
				}
			}
		}
		if (!player.beetleDefense && !player.beetleOffense)
		{
			player.beetleCounter = 0f;
		}
		else
		{
			player.beetleFrameCounter++;
			if (player.beetleFrameCounter >= 1)
			{
				player.beetleFrameCounter = 0;
				player.beetleFrame++;
				if (player.beetleFrame > 2)
				{
					player.beetleFrame = 0;
				}
			}
			for (int l = player.beetleOrbs; l < 3; l++)
			{
				player.beetlePos[l].X = 0f;
				player.beetlePos[l].Y = 0f;
			}
			for (int m = 0; m < player.beetleOrbs; m++)
			{
				ref Vector2 reference = ref player.beetlePos[m];
				reference += player.beetleVel[m];
				player.beetleVel[m].X += (float)Main.rand.Next(-100, 101) * 0.005f;
				player.beetleVel[m].Y += (float)Main.rand.Next(-100, 101) * 0.005f;
				float x = player.beetlePos[m].X;
				float y = player.beetlePos[m].Y;
				float num6 = (float)Math.Sqrt(x * x + y * y);
				if (num6 > 100f)
				{
					num6 = 20f / num6;
					x *= 0f - num6;
					y *= 0f - num6;
					int num7 = 10;
					player.beetleVel[m].X = (player.beetleVel[m].X * (float)(num7 - 1) + x) / (float)num7;
					player.beetleVel[m].Y = (player.beetleVel[m].Y * (float)(num7 - 1) + y) / (float)num7;
				}
				else if (num6 > 30f)
				{
					num6 = 10f / num6;
					x *= 0f - num6;
					y *= 0f - num6;
					int num8 = 20;
					player.beetleVel[m].X = (player.beetleVel[m].X * (float)(num8 - 1) + x) / (float)num8;
					player.beetleVel[m].Y = (player.beetleVel[m].Y * (float)(num8 - 1) + y) / (float)num8;
				}
				x = player.beetleVel[m].X;
				y = player.beetleVel[m].Y;
				num6 = (float)Math.Sqrt(x * x + y * y);
				if (num6 > 2f)
				{
					ref Vector2 reference2 = ref player.beetleVel[m];
					reference2 *= 0.9f;
				}
				ref Vector2 reference3 = ref player.beetlePos[m];
				reference3 -= ((Entity)player).velocity * 0.25f;
			}
		}
		if (player.head == 14 && ((player.body >= 58 && player.body <= 63) || player.body == 167 || player.body == 213))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Wizard");
			player.GetCritChance(DamageClass.Magic) += 10f;
		}
		if (player.head == 159 && ((player.body >= 58 && player.body <= 63) || player.body == 167 || player.body == 213))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.MagicHat");
			player.statManaMax2 += 60;
		}
		if ((player.head == 5 || player.head == 74) && (player.body == 5 || player.body == 48) && (player.legs == 5 || player.legs == 44))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.ShadowScale");
			player.shadowArmor = true;
		}
		if (player.head == 57 && player.body == 37 && player.legs == 35)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Crimson");
			player.crimsonRegen = true;
		}
		if (player.head == 101 && player.body == 66 && player.legs == 55)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.SpectreHealing");
			player.ghostHeal = true;
			ref StatModifier damage2 = ref player.GetDamage(DamageClass.Magic);
			damage2 -= 0.4f;
		}
		if (player.head == 156 && player.body == 66 && player.legs == 55)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.SpectreDamage");
			player.ghostHurt = true;
		}
		if (player.head == 6 && player.body == 6 && player.legs == 6)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Meteor");
			player.spaceGun = true;
		}
		if (player.head == 46 && player.body == 27 && player.legs == 26)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Frost");
			player.frostBurn = true;
			ref StatModifier damage3 = ref player.GetDamage(DamageClass.Melee);
			damage3 += 0.1f;
			ref StatModifier damage4 = ref player.GetDamage(DamageClass.Ranged);
			damage4 += 0.1f;
		}
		if ((player.head == 76 || player.head == 8) && (player.body == 49 || player.body == 8) && (player.legs == 45 || player.legs == 8))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Jungle");
			player.manaCost -= 0.16f;
		}
		if (player.head == 9 && player.body == 9 && player.legs == 9)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Molten");
			ref StatModifier damage5 = ref player.GetDamage(DamageClass.Melee);
			damage5 += 0.1f;
			player.buffImmune[24] = true;
		}
		if ((player.head == 58 || player.head == 77) && (player.body == 38 || player.body == 50) && (player.legs == 36 || player.legs == 46))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Snow");
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
		}
		if (player.head == 11 && player.body == 20 && player.legs == 19)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Mining");
			player.pickSpeed -= 0.1f;
		}
		if (player.head == 216 && player.body == 20 && player.legs == 19)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Mining");
			player.pickSpeed -= 0.1f;
		}
		if (player.head == 78 && player.body == 51 && player.legs == 47)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.ChlorophyteMelee");
			player.AddBuff(60, 18000, true, false);
			player.endurance += 0.05f;
		}
		else if ((player.head == 80 || player.head == 79) && player.body == 51 && player.legs == 47)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Chlorophyte");
			player.AddBuff(60, 18000, true, false);
		}
		else if (player.crystalLeaf)
		{
			for (int n = 0; n < Player.MaxBuffs; n++)
			{
				if (player.buffType[n] == 60)
				{
					player.DelBuff(n);
				}
			}
		}
		if (player.head == 161 && player.body == 169 && player.legs == 104)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Angler");
			player.anglerSetSpawnReduction = true;
		}
		if (player.head == 70 && player.body == 46 && player.legs == 42)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Cactus");
			player.cactusThorns = true;
		}
		if (player.head == 99 && player.body == 65 && player.legs == 54)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Turtle");
			player.endurance += 0.15f;
			player.thorns = 1f;
			player.turtleThorns = true;
		}
		if (player.body == 17 && player.legs == 16)
		{
			if (player.head == 29)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.CobaltCaster");
				player.manaCost -= 0.14f;
			}
			else if (player.head == 30)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.CobaltMelee");
				player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
			}
			else if (player.head == 31)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.CobaltRanged");
				player.ammoCost80 = true;
			}
		}
		if (player.body == 18 && player.legs == 17)
		{
			if (player.head == 32)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.MythrilCaster");
				player.manaCost -= 0.17f;
			}
			else if (player.head == 33)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.MythrilMelee");
				player.GetCritChance(DamageClass.Melee) += 10f;
			}
			else if (player.head == 34)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.MythrilRanged");
				player.ammoCost80 = true;
			}
		}
		if (player.body == 19 && player.legs == 18)
		{
			if (player.head == 35)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.AdamantiteCaster");
				player.manaCost -= 0.19f;
			}
			else if (player.head == 36)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.AdamantiteMelee");
				player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
				player.moveSpeed += 0.2f;
			}
			else if (player.head == 37)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.AdamantiteRanged");
				player.ammoCost75 = true;
			}
		}
		if (player.body == 54 && player.legs == 49 && (player.head == 83 || player.head == 84 || player.head == 85))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Palladium");
			player.onHitRegen = true;
		}
		if (player.body == 55 && player.legs == 50 && (player.head == 86 || player.head == 87 || player.head == 88))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Orichalcum");
			player.onHitPetal = true;
		}
		if (player.body == 56 && player.legs == 51)
		{
			bool flag = false;
			if (player.head == 91)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.Titanium");
				flag = true;
			}
			else if (player.head == 89)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.Titanium");
				flag = true;
			}
			else if (player.head == 90)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.Titanium");
				flag = true;
			}
			if (flag)
			{
				player.onHitTitaniumStorm = true;
			}
		}
		if ((player.body == 24 || player.body == 229) && (player.legs == 23 || player.legs == 212) && (player.head == 42 || player.head == 41 || player.head == 43 || player.head == 254 || player.head == 257 || player.head == 256 || player.head == 255 || player.head == 258))
		{
			if (player.head == 254 || player.head == 258)
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.HallowedSummoner");
				player.maxMinions += 2;
			}
			else
			{
				player.setBonus = Language.GetTextValue("ArmorSetBonus.Hallowed");
			}
			player.onHitDodge = true;
		}
		if (player.head == 261 && player.body == 230 && player.legs == 213)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.CrystalNinja");
			ref StatModifier damage6 = ref player.GetDamage(DamageClass.Generic);
			damage6 += 0.1f;
			player.GetCritChance(DamageClass.Generic) += 10f;
			player.dashType = 5;
		}
		if (player.head == 82 && player.body == 53 && player.legs == 48)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Tiki");
			player.maxMinions++;
			player.whipRangeMultiplier += 0.2f;
		}
		if (player.head == 134 && player.body == 95 && player.legs == 79)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Spooky");
			ref StatModifier damage7 = ref player.GetDamage(DamageClass.Summon);
			damage7 += 0.25f;
		}
		if (player.head == 160 && player.body == 168 && player.legs == 103)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Bee");
			ref StatModifier damage8 = ref player.GetDamage(DamageClass.Summon);
			damage8 += 0.1f;
			if (player.itemAnimation > 0 && player.inventory[player.selectedItem].type == 1121)
			{
				AchievementsHelper.HandleSpecialEvent(player, 3);
			}
		}
		if (player.head == 162 && player.body == 170 && player.legs == 105)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Spider");
			ref StatModifier damage9 = ref player.GetDamage(DamageClass.Summon);
			damage9 += 0.12f;
		}
		if (player.head == 171 && player.body == 177 && player.legs == 112)
		{
			player.endurance += 0.12f;
			player.setSolar = true;
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Solar");
			player.solarCounter++;
			int num9 = 180;
			if (player.solarCounter >= num9)
			{
				if (player.solarShields > 0 && player.solarShields < 3)
				{
					for (int i = 0; i < Player.MaxBuffs; i++)
					{
						if (player.buffType[i] >= 170 && player.buffType[i] <= 171)
						{
							player.DelBuff(i);
						}
					}
				}
				if (player.solarShields < 3)
				{
					player.AddBuff(170 + player.solarShields, 5, false, false);
					for (int num10 = 0; num10 < 16; num10++)
					{
						Dust obj = Main.dust[Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 6, 0f, 0f, 100, default(Color), 1f)];
						obj.noGravity = true;
						obj.scale = 1.7f;
						obj.fadeIn = 0.5f;
						obj.velocity *= 5f;
						obj.shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
					}
					player.solarCounter = 0;
				}
				else
				{
					player.solarCounter = num9;
				}
			}
			for (int num11 = player.solarShields; num11 < 3; num11++)
			{
				player.solarShieldPos[num11] = Vector2.Zero;
			}
			for (int num12 = 0; num12 < player.solarShields; num12++)
			{
				ref Vector2 reference4 = ref player.solarShieldPos[num12];
				reference4 += player.solarShieldVel[num12];
				Vector2 value = Utils.ToRotationVector2((float)player.miscCounter / 100f * ((float)Math.PI * 2f) + (float)num12 * ((float)Math.PI * 2f / (float)player.solarShields)) * 6f;
				value.X = ((Entity)player).direction * 20;
				player.solarShieldVel[num12] = (value - player.solarShieldPos[num12]) * 0.2f;
			}
			if (player.dashDelay >= 0)
			{
				player.solarDashing = false;
				player.solarDashConsumedFlare = false;
			}
			bool flag2 = player.solarDashing && player.dashDelay < 0;
			if (player.solarShields > 0 || flag2)
			{
				player.dashType = 3;
			}
		}
		else
		{
			player.solarCounter = 0;
		}
		if (player.head == 169 && player.body == 175 && player.legs == 110)
		{
			player.setVortex = true;
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Vortex", (object)Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN"));
		}
		else
		{
			player.vortexStealthActive = false;
		}
		if (player.head == 170 && player.body == 176 && player.legs == 111)
		{
			if (player.nebulaCD > 0)
			{
				player.nebulaCD--;
			}
			player.setNebula = true;
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Nebula");
		}
		if (player.head == 189 && player.body == 190 && player.legs == 130)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Stardust", (object)Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN"));
			player.setStardust = true;
			if (((Entity)player).whoAmI == Main.myPlayer)
			{
				if (player.FindBuffIndex(187) == -1)
				{
					player.AddBuff(187, 3600, true, false);
				}
				if (player.ownedProjectileCounts[623] < 1)
				{
					int num14 = 10;
					int num15 = 30;
					int num16 = Projectile.NewProjectile(((Entity)player).GetSource_Misc("SetBonus_Stardust"), ((Entity)player).Center.X, ((Entity)player).Center.Y, 0f, -1f, 623, num15, (float)num14, Main.myPlayer, 0f, 0f, 0f);
					Main.projectile[num16].originalDamage = num15;
				}
			}
		}
		else if (player.FindBuffIndex(187) != -1)
		{
			player.DelBuff(player.FindBuffIndex(187));
		}
		if (player.head == 200 && player.body == 198 && player.legs == 142)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Forbidden", (object)Language.GetTextValue(Main.ReversedUpDownArmorSetBonuses ? "Key.UP" : "Key.DOWN"));
			player.setForbidden = true;
			player.UpdateForbiddenSetLock();
			Lighting.AddLight(((Entity)player).Center, 0.8f, 0.7f, 0.2f);
		}
		if (player.head == 204 && player.body == 201 && player.legs == 145)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.SquireTier2");
			player.setSquireT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 203 && player.body == 200 && player.legs == 144)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.ApprenticeTier2");
			player.setApprenticeT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 205 && player.body == 202 && (player.legs == 147 || player.legs == 146))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.HuntressTier2");
			player.setHuntressT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 206 && player.body == 203 && player.legs == 148)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.MonkTier2");
			player.setMonkT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 210 && player.body == 204 && player.legs == 152)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.SquireTier3");
			player.setSquireT3 = true;
			player.setSquireT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 211 && player.body == 205 && player.legs == 153)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.ApprenticeTier3");
			player.setApprenticeT3 = true;
			player.setApprenticeT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 212 && player.body == 206 && (player.legs == 154 || player.legs == 155))
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.HuntressTier3");
			player.setHuntressT3 = true;
			player.setHuntressT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 213 && player.body == 207 && player.legs == 156)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.MonkTier3");
			player.setMonkT3 = true;
			player.setMonkT2 = true;
			player.maxTurrets++;
		}
		if (player.head == 185 && player.body == 187 && player.legs == 127)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.ObsidianOutlaw");
			ref StatModifier damage10 = ref player.GetDamage(DamageClass.Summon);
			damage10 += 0.15f;
			player.whipRangeMultiplier += 0.3f;
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.15f;
		}
		player.ApplyArmorSoundAndDustChanges();
		ItemLoader.UpdateArmorSet(player, player.armor[0], player.armor[1], player.armor[2]);
		return;
		IL_0231:
		player.setBonus = Language.GetTextValue("ArmorSetBonus.MetalTier1");
		player.statDefense += 2;
		goto IL_026c;
		IL_01ce:
		if (type2 == 81 && type3 == 77)
		{
			goto IL_0231;
		}
		goto IL_026c;
		IL_01f5:
		player.setBonus = Language.GetTextValue("ArmorSetBonus.Wood");
		player.statDefense = DefenseStat.op_Increment(player.statDefense);
		goto IL_026c;
	}

	public void ResetHealthRegenTime()
	{
		healthRegenTime = 0.0;
		healthRegenCount = 0.0;
	}

	public void ResetHealthRegenEffectList()
	{
		int num = 1;
		List<HealthRegenEffect> list = new List<HealthRegenEffect>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<HealthRegenEffect> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = new HealthRegenEffect(NaturalHealthRegen, natural: true);
		num2++;
		HealthRegenEffects = list;
	}

	public static double NaturalHealthRegen(Player player)
	{
		double oneMinuteFrameCount = V2Utils.SensibleTime(0, 1);
		double num = Math.Max(player.AsV2Player().healthRegenTime, 0.0) / oneMinuteFrameCount;
		double healthToRegenAtMaxNaturalEffectiveness = (double)player.statLifeMax2 / 100.0;
		return num * healthToRegenAtMaxNaturalEffectiveness;
	}

	public void HandleSittingAndSleepingHealthRegenEffect()
	{
		if (((ModPlayer)this).Player.sitting.isSitting || ((ModPlayer)this).Player.sleeping.isSleeping)
		{
			((ModPlayer)this).Player.AddHealthRegenEffect(0.8, natural: true, RelaxationModifyHealthRegenTime, RelaxationModifyTotalHealthRegen);
		}
	}

	public static void RelaxationModifyHealthRegenTime(Player player, ref double healthRegenTime)
	{
		healthRegenTime += 0.4;
	}

	public static void RelaxationModifyTotalHealthRegen(Player player, ref double naturalRegenAdditive, ref double naturalRegenMultiplicative, ref double artificialRegenAdditive, ref double artificialRegenMultiplicative)
	{
		naturalRegenAdditive += 0.25;
	}

	public static void Detour_UpdateLifeRegen(Player player)
	{
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_092b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		bool shinyStoneShouldEverFuckingWork = false;
		if (player.shinyStone && ((Vector2)(ref ((Entity)player).velocity)).Length() < 0.05f && player.itemAnimation == 0)
		{
			shinyStoneShouldEverFuckingWork = true;
		}
		player.AsV2Player().healthRegenTime += 1.0;
		foreach (HealthRegenEffect healthRegenEffect2 in player.AsV2Player().HealthRegenEffects)
		{
			healthRegenEffect2.modifyHealthRegenTimeMethod?.Invoke(player, ref player.AsV2Player().healthRegenTime);
		}
		double oneMinuteFrameCount = V2Utils.SensibleTime(0, 1);
		if (player.AsV2Player().healthRegenTime >= oneMinuteFrameCount)
		{
			player.AsV2Player().healthRegenTime = oneMinuteFrameCount;
		}
		player.AsV2Player().HealthRegenNatural.baseRegen = 0.0;
		player.AsV2Player().HealthRegenNatural.additiveRegenModifier = 1.0;
		player.AsV2Player().HealthRegenNatural.flatRegenBonus = 0.0;
		player.AsV2Player().HealthRegenNatural.multiplicativeRegenModifier = 1.0;
		player.AsV2Player().HealthRegenArtificial.baseRegen = 0.0;
		player.AsV2Player().HealthRegenArtificial.additiveRegenModifier = 1.0;
		player.AsV2Player().HealthRegenArtificial.flatRegenBonus = 0.0;
		player.AsV2Player().HealthRegenArtificial.multiplicativeRegenModifier = 1.0;
		foreach (HealthRegenEffect healthRegenEffect in player.AsV2Player().HealthRegenEffects)
		{
			if (healthRegenEffect.natural)
			{
				player.AsV2Player().HealthRegenNatural.baseRegen += (float)healthRegenEffect.healthPerSecond(player);
			}
			else
			{
				player.AsV2Player().HealthRegenArtificial.baseRegen += (float)healthRegenEffect.healthPerSecond(player);
			}
		}
		foreach (HealthRegenEffect healthRegenEffect3 in player.AsV2Player().HealthRegenEffects)
		{
			healthRegenEffect3.modifyTotalHealthRegenMethod?.Invoke(player, ref player.AsV2Player().HealthRegenNatural.additiveRegenModifier, ref player.AsV2Player().HealthRegenNatural.multiplicativeRegenModifier, ref player.AsV2Player().HealthRegenArtificial.additiveRegenModifier, ref player.AsV2Player().HealthRegenArtificial.multiplicativeRegenModifier);
		}
		double naturalHealthRegenCount = player.AsV2Player().HealthRegenNatural.baseRegen * player.AsV2Player().HealthRegenNatural.additiveRegenModifier + player.AsV2Player().HealthRegenNatural.flatRegenBonus;
		double artificialHealthRegenCount = player.AsV2Player().HealthRegenArtificial.baseRegen * player.AsV2Player().HealthRegenArtificial.additiveRegenModifier + player.AsV2Player().HealthRegenArtificial.flatRegenBonus;
		player.AsV2Player().healthRegenCount += naturalHealthRegenCount + artificialHealthRegenCount;
		while (player.AsV2Player().healthRegenCount >= 60.0)
		{
			player.AsV2Player().healthRegenCount -= 60.0;
			if (player.statLife < player.statLifeMax2)
			{
				player.statLife++;
				foreach (HealthRegenEffect healthRegenEffect4 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect4.onHealthAdjustmentMethod?.Invoke(player, 1);
				}
			}
			if (player.statLife > player.statLifeMax2)
			{
				player.statLife = player.statLifeMax2;
			}
		}
		while (player.AsV2Player().healthRegenCount <= -60.0)
		{
			if (player.AsV2Player().healthRegenCount <= -240.0)
			{
				player.AsV2Player().healthRegenCount += 240.0;
				player.statLife -= 4;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 4, false, true);
				foreach (HealthRegenEffect healthRegenEffect5 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect5.onHealthAdjustmentMethod?.Invoke(player, -4);
				}
			}
			else if (player.AsV2Player().healthRegenCount <= -180.0)
			{
				player.AsV2Player().healthRegenCount += 180.0;
				player.statLife -= 3;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 3, false, true);
				foreach (HealthRegenEffect healthRegenEffect6 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect6.onHealthAdjustmentMethod?.Invoke(player, -3);
				}
			}
			else if (player.AsV2Player().healthRegenCount <= -120.0)
			{
				player.AsV2Player().healthRegenCount += 120.0;
				player.statLife -= 2;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 2, false, true);
				foreach (HealthRegenEffect healthRegenEffect7 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect7.onHealthAdjustmentMethod?.Invoke(player, -2);
				}
			}
			else
			{
				player.AsV2Player().healthRegenCount += 60.0;
				player.statLife--;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 1, false, true);
				foreach (HealthRegenEffect healthRegenEffect8 in player.AsV2Player().HealthRegenEffects)
				{
					healthRegenEffect8.onHealthAdjustmentMethod?.Invoke(player, -1);
				}
			}
			if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
			{
				if (player.poisoned || player.venom)
				{
					player.KillMe(PlayerDeathReason.ByOther(9, -1), 10.0, 0, false);
				}
				else if (player.electrified)
				{
					player.KillMe(PlayerDeathReason.ByOther(10, -1), 10.0, 0, false);
				}
				else
				{
					player.KillMe(PlayerDeathReason.ByOther(8, -1), 10.0, 0, false);
				}
				return;
			}
		}
		PlayerLoader.UpdateBadLifeRegen(player);
		player.lifeRegenTime += 1f;
		if (player.lifeRegenTime >= 3600f)
		{
			player.lifeRegenTime = 3600f;
		}
		PlayerLoader.UpdateLifeRegen(player);
		float num5 = 0f;
		PlayerLoader.NaturalLifeRegen(player, ref num5);
		float num7 = (float)player.statLifeMax2 / 400f * 0.85f + 0.15f;
		num5 *= num7;
		player.lifeRegen += (int)Math.Round(num5);
		player.lifeRegenCount += player.lifeRegen;
		if (shinyStoneShouldEverFuckingWork && player.lifeRegen > 0 && player.statLife < player.statLifeMax2)
		{
			player.lifeRegenCount++;
			if (shinyStoneShouldEverFuckingWork && ((float)Main.rand.Next(30000) < player.lifeRegenTime || Utils.NextBool(Main.rand, 30)))
			{
				int num8 = Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 55, 0f, 0f, 200, default(Color), 0.5f);
				Main.dust[num8].noGravity = true;
				Dust obj = Main.dust[num8];
				obj.velocity *= 0.75f;
				Main.dust[num8].fadeIn = 1.3f;
				Vector2 vector = default(Vector2);
				((Vector2)(ref vector))._002Ector((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
				((Vector2)(ref vector)).Normalize();
				vector *= (float)Main.rand.Next(50, 100) * 0.04f;
				Main.dust[num8].velocity = vector;
				((Vector2)(ref vector)).Normalize();
				vector *= 34f;
				Main.dust[num8].position = ((Entity)player).Center - vector;
			}
		}
		while (player.lifeRegenCount >= 120)
		{
			player.lifeRegenCount -= 120;
			if (player.statLife < player.statLifeMax2)
			{
				player.statLife++;
				if (player.crimsonRegen)
				{
					for (int i = 0; i < 10; i++)
					{
						int num9 = Dust.NewDust(((Entity)player).position, ((Entity)player).width, ((Entity)player).height, 5, 0f, 0f, 175, default(Color), 1.75f);
						Main.dust[num9].noGravity = true;
						Dust obj2 = Main.dust[num9];
						obj2.velocity *= 0.75f;
						int num10 = Main.rand.Next(-40, 41);
						int num11 = Main.rand.Next(-40, 41);
						Main.dust[num9].position.X += num10;
						Main.dust[num9].position.Y += num11;
						Main.dust[num9].velocity.X = (float)(-num10) * 0.075f;
						Main.dust[num9].velocity.Y = (float)(-num11) * 0.075f;
					}
				}
			}
			if (player.statLife > player.statLifeMax2)
			{
				player.statLife = player.statLifeMax2;
			}
		}
		if (player.burned || player.suffocating || (player.tongued && Main.expertMode))
		{
			while (player.lifeRegenCount <= -600)
			{
				player.lifeRegenCount += 600;
				player.statLife -= 5;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 5, false, true);
				if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					if (player.suffocating)
					{
						player.KillMe(PlayerDeathReason.ByOther(7, -1), 10.0, 0, false);
					}
					else
					{
						player.KillMe(PlayerDeathReason.ByOther(8, -1), 10.0, 0, false);
					}
				}
			}
			return;
		}
		if (player.starving)
		{
			int num12 = player.statLifeMax2 / 50;
			if (num12 < 2)
			{
				num12 = 2;
			}
			int num13 = ((player.ZoneDesert || player.ZoneSnow) ? (num12 * 2) : num12);
			int num14 = 120 * num12;
			while (player.lifeRegenCount <= -num14)
			{
				player.lifeRegenCount += num14;
				player.statLife -= num13;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, num13, false, true);
				if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
				{
					player.KillMe(PlayerDeathReason.ByOther(18, -1), 10.0, 0, false);
				}
			}
			return;
		}
		while (player.lifeRegenCount <= -120)
		{
			if (player.lifeRegenCount <= -480)
			{
				player.lifeRegenCount += 480;
				player.statLife -= 4;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 4, false, true);
			}
			else if (player.lifeRegenCount <= -360)
			{
				player.lifeRegenCount += 360;
				player.statLife -= 3;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 3, false, true);
			}
			else if (player.lifeRegenCount <= -240)
			{
				player.lifeRegenCount += 240;
				player.statLife -= 2;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 2, false, true);
			}
			else
			{
				player.lifeRegenCount += 120;
				player.statLife--;
				CombatText.NewText(new Rectangle((int)((Entity)player).position.X, (int)((Entity)player).position.Y, ((Entity)player).width, ((Entity)player).height), CombatText.LifeRegen, 1, false, true);
			}
			if (player.statLife <= 0 && ((Entity)player).whoAmI == Main.myPlayer)
			{
				if (player.poisoned || player.venom)
				{
					player.KillMe(PlayerDeathReason.ByOther(9, -1), 10.0, 0, false);
				}
				else if (player.electrified)
				{
					player.KillMe(PlayerDeathReason.ByOther(10, -1), 10.0, 0, false);
				}
				else
				{
					player.KillMe(PlayerDeathReason.ByOther(8, -1), 10.0, 0, false);
				}
			}
		}
	}
}
