using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

namespace V2;

public static class V2Utils
{
	public static class ItemIDSets
	{
		public static List<int> LargeGems
		{
			get
			{
				int num = 7;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 3643;
				num2++;
				span[num2] = 1522;
				num2++;
				span[num2] = 1527;
				num2++;
				span[num2] = 1525;
				num2++;
				span[num2] = 1526;
				num2++;
				span[num2] = 1524;
				num2++;
				span[num2] = 1523;
				num2++;
				return list;
			}
		}

		public static List<int> Dyes
		{
			get
			{
				int num = 119;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 1007;
				num2++;
				span[num2] = 1008;
				num2++;
				span[num2] = 1009;
				num2++;
				span[num2] = 1010;
				num2++;
				span[num2] = 1011;
				num2++;
				span[num2] = 1012;
				num2++;
				span[num2] = 1013;
				num2++;
				span[num2] = 1014;
				num2++;
				span[num2] = 1015;
				num2++;
				span[num2] = 1016;
				num2++;
				span[num2] = 1017;
				num2++;
				span[num2] = 1018;
				num2++;
				span[num2] = 1050;
				num2++;
				span[num2] = 2874;
				num2++;
				span[num2] = 1037;
				num2++;
				span[num2] = 1038;
				num2++;
				span[num2] = 1039;
				num2++;
				span[num2] = 1040;
				num2++;
				span[num2] = 1041;
				num2++;
				span[num2] = 1042;
				num2++;
				span[num2] = 1043;
				num2++;
				span[num2] = 1044;
				num2++;
				span[num2] = 1045;
				num2++;
				span[num2] = 1046;
				num2++;
				span[num2] = 1047;
				num2++;
				span[num2] = 1048;
				num2++;
				span[num2] = 1049;
				num2++;
				span[num2] = 2876;
				num2++;
				span[num2] = 3558;
				num2++;
				span[num2] = 1019;
				num2++;
				span[num2] = 1020;
				num2++;
				span[num2] = 1021;
				num2++;
				span[num2] = 1022;
				num2++;
				span[num2] = 1023;
				num2++;
				span[num2] = 1024;
				num2++;
				span[num2] = 1025;
				num2++;
				span[num2] = 1026;
				num2++;
				span[num2] = 1027;
				num2++;
				span[num2] = 1028;
				num2++;
				span[num2] = 1029;
				num2++;
				span[num2] = 1030;
				num2++;
				span[num2] = 2875;
				num2++;
				span[num2] = 3559;
				num2++;
				span[num2] = 1051;
				num2++;
				span[num2] = 1052;
				num2++;
				span[num2] = 1053;
				num2++;
				span[num2] = 1054;
				num2++;
				span[num2] = 1055;
				num2++;
				span[num2] = 1056;
				num2++;
				span[num2] = 1057;
				num2++;
				span[num2] = 1058;
				num2++;
				span[num2] = 1059;
				num2++;
				span[num2] = 1060;
				num2++;
				span[num2] = 1061;
				num2++;
				span[num2] = 1062;
				num2++;
				span[num2] = 2877;
				num2++;
				span[num2] = 3557;
				num2++;
				span[num2] = 1031;
				num2++;
				span[num2] = 1033;
				num2++;
				span[num2] = 1035;
				num2++;
				span[num2] = 1068;
				num2++;
				span[num2] = 1069;
				num2++;
				span[num2] = 1070;
				num2++;
				span[num2] = 1066;
				num2++;
				span[num2] = 1063;
				num2++;
				span[num2] = 1064;
				num2++;
				span[num2] = 1065;
				num2++;
				span[num2] = 1067;
				num2++;
				span[num2] = 1032;
				num2++;
				span[num2] = 1034;
				num2++;
				span[num2] = 1036;
				num2++;
				span[num2] = 3550;
				num2++;
				span[num2] = 3551;
				num2++;
				span[num2] = 3552;
				num2++;
				span[num2] = 3040;
				num2++;
				span[num2] = 3028;
				num2++;
				span[num2] = 3560;
				num2++;
				span[num2] = 2883;
				num2++;
				span[num2] = 3561;
				num2++;
				span[num2] = 3041;
				num2++;
				span[num2] = 3598;
				num2++;
				span[num2] = 3038;
				num2++;
				span[num2] = 3597;
				num2++;
				span[num2] = 3600;
				num2++;
				span[num2] = 2873;
				num2++;
				span[num2] = 2869;
				num2++;
				span[num2] = 2870;
				num2++;
				span[num2] = 2864;
				num2++;
				span[num2] = 3556;
				num2++;
				span[num2] = 3534;
				num2++;
				span[num2] = 2872;
				num2++;
				span[num2] = 2879;
				num2++;
				span[num2] = 3042;
				num2++;
				span[num2] = 3025;
				num2++;
				span[num2] = 3190;
				num2++;
				span[num2] = 3553;
				num2++;
				span[num2] = 3027;
				num2++;
				span[num2] = 3554;
				num2++;
				span[num2] = 3555;
				num2++;
				span[num2] = 3026;
				num2++;
				span[num2] = 2871;
				num2++;
				span[num2] = 3533;
				num2++;
				span[num2] = 3024;
				num2++;
				span[num2] = 3039;
				num2++;
				span[num2] = 2878;
				num2++;
				span[num2] = 2885;
				num2++;
				span[num2] = 2884;
				num2++;
				span[num2] = 3562;
				num2++;
				span[num2] = 3535;
				num2++;
				span[num2] = 3527;
				num2++;
				span[num2] = 3526;
				num2++;
				span[num2] = 3529;
				num2++;
				span[num2] = 3528;
				num2++;
				span[num2] = 3530;
				num2++;
				span[num2] = 3599;
				num2++;
				span[num2] = 1969;
				num2++;
				span[num2] = 4663;
				num2++;
				span[num2] = 4662;
				num2++;
				span[num2] = 4778;
				num2++;
				return list;
			}
		}
	}

	public static class NPCIDSets
	{
		public static List<int> Slimes
		{
			get
			{
				int num = 51;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = -3;
				num2++;
				span[num2] = 1;
				num2++;
				span[num2] = -7;
				num2++;
				span[num2] = -9;
				num2++;
				span[num2] = -8;
				num2++;
				span[num2] = -6;
				num2++;
				span[num2] = 335;
				num2++;
				span[num2] = 336;
				num2++;
				span[num2] = 333;
				num2++;
				span[num2] = 334;
				num2++;
				span[num2] = 16;
				num2++;
				span[num2] = -5;
				num2++;
				span[num2] = -10;
				num2++;
				span[num2] = 204;
				num2++;
				span[num2] = 50;
				num2++;
				span[num2] = 535;
				num2++;
				span[num2] = 657;
				num2++;
				span[num2] = 658;
				num2++;
				span[num2] = 659;
				num2++;
				span[num2] = 660;
				num2++;
				span[num2] = 244;
				num2++;
				span[num2] = 81;
				num2++;
				span[num2] = 183;
				num2++;
				span[num2] = 141;
				num2++;
				span[num2] = 121;
				num2++;
				span[num2] = -2;
				num2++;
				span[num2] = -25;
				num2++;
				span[num2] = -24;
				num2++;
				span[num2] = 138;
				num2++;
				span[num2] = 122;
				num2++;
				span[num2] = 676;
				num2++;
				span[num2] = 302;
				num2++;
				span[num2] = 225;
				num2++;
				span[num2] = -4;
				num2++;
				span[num2] = 667;
				num2++;
				span[num2] = 670;
				num2++;
				span[num2] = 684;
				num2++;
				span[num2] = 678;
				num2++;
				span[num2] = 679;
				num2++;
				span[num2] = 680;
				num2++;
				span[num2] = 681;
				num2++;
				span[num2] = 682;
				num2++;
				span[num2] = 683;
				num2++;
				span[num2] = 685;
				num2++;
				span[num2] = 686;
				num2++;
				span[num2] = 687;
				num2++;
				span[num2] = 59;
				num2++;
				span[num2] = 71;
				num2++;
				span[num2] = 147;
				num2++;
				span[num2] = 184;
				num2++;
				span[num2] = 537;
				num2++;
				return list;
			}
		}

		public static List<int> GemCritters
		{
			get
			{
				int num = 14;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 652;
				num2++;
				span[num2] = 646;
				num2++;
				span[num2] = 651;
				num2++;
				span[num2] = 649;
				num2++;
				span[num2] = 650;
				num2++;
				span[num2] = 648;
				num2++;
				span[num2] = 647;
				num2++;
				span[num2] = 645;
				num2++;
				span[num2] = 639;
				num2++;
				span[num2] = 644;
				num2++;
				span[num2] = 642;
				num2++;
				span[num2] = 643;
				num2++;
				span[num2] = 641;
				num2++;
				span[num2] = 640;
				num2++;
				return list;
			}
		}

		public static List<int> GoldCritters
		{
			get
			{
				int num = 14;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 442;
				num2++;
				span[num2] = 443;
				num2++;
				span[num2] = 444;
				num2++;
				span[num2] = 601;
				num2++;
				span[num2] = 667;
				num2++;
				span[num2] = 445;
				num2++;
				span[num2] = 592;
				num2++;
				span[num2] = 446;
				num2++;
				span[num2] = 605;
				num2++;
				span[num2] = 447;
				num2++;
				span[num2] = 627;
				num2++;
				span[num2] = 613;
				num2++;
				span[num2] = 448;
				num2++;
				span[num2] = 539;
				num2++;
				return list;
			}
		}

		public static List<int> LivingWeapons
		{
			get
			{
				int num = 3;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 84;
				num2++;
				span[num2] = 83;
				num2++;
				span[num2] = 179;
				num2++;
				return list;
			}
		}

		public static List<int> Mimics
		{
			get
			{
				int num = 7;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 85;
				num2++;
				span[num2] = 629;
				num2++;
				span[num2] = 341;
				num2++;
				span[num2] = 473;
				num2++;
				span[num2] = 474;
				num2++;
				span[num2] = 475;
				num2++;
				span[num2] = 476;
				num2++;
				return list;
			}
		}

		public static List<int> MiniFairies
		{
			get
			{
				int num = 3;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 585;
				num2++;
				span[num2] = 584;
				num2++;
				span[num2] = 583;
				num2++;
				return list;
			}
		}

		public static List<int> Butterflies
		{
			get
			{
				int num = 4;
				List<int> list = new List<int>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<int> span = CollectionsMarshal.AsSpan(list);
				int num2 = 0;
				span[num2] = 356;
				num2++;
				span[num2] = 444;
				num2++;
				span[num2] = 653;
				num2++;
				span[num2] = 661;
				num2++;
				return list;
			}
		}
	}

	public static void DebugPointMarker(Vector2 position)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		Texture2D p = ModContent.Request<Texture2D>("V2/DebugPoint", (AssetRequestMode)2).Value;
		Main.spriteBatch.Draw(p, position - Utils.Size(p) / 2f, Color.White);
	}

	public static int SensibleTime(int hours = 0, int minutes = 0, int seconds = 0, int frames = 0)
	{
		return hours * 60 * 60 * 60 + minutes * 60 * 60 + seconds * 60 + frames;
	}

	public static void FigureOutWhatTimeItIs(out bool pastMorning, out int hour, out int minute, out int second, out MealTime mealTime)
	{
		pastMorning = false;
		double hours = Main.time;
		if (!Main.dayTime)
		{
			hours += 54000.0;
		}
		hours = hours / 86400.0 * 24.0;
		double mainTimeOffset = 7.5;
		hours = hours - mainTimeOffset - 12.0;
		if (hours < 0.0)
		{
			hours += 24.0;
		}
		if (hours >= 12.0)
		{
			pastMorning = true;
		}
		hour = (int)hours;
		double minutes = hours - (double)hour;
		minute = (int)(minutes * 60.0);
		double seconds = minutes - (double)minute;
		second = (int)(seconds * 60.0);
		if (hour > 12)
		{
			hour -= 12;
		}
		if (hour == 0)
		{
			hour = 12;
		}
		if (!pastMorning)
		{
			switch (hour)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 12:
				mealTime = MealTime.LateNightSnacking;
				break;
			case 5:
			case 6:
			case 7:
				mealTime = MealTime.Breakfast;
				break;
			case 8:
			case 9:
			case 10:
				mealTime = MealTime.BetweenBreakfastAndLunch;
				break;
			default:
				mealTime = MealTime.Lunch;
				break;
			}
		}
		else
		{
			switch (hour)
			{
			default:
				mealTime = MealTime.Lunch;
				break;
			case 2:
			case 3:
			case 4:
				mealTime = MealTime.BetweenLunchAndDinner;
				break;
			case 5:
			case 6:
			case 7:
			case 8:
				mealTime = MealTime.Dinner;
				break;
			case 9:
			case 10:
			case 11:
				mealTime = MealTime.LateNightSnacking;
				break;
			}
		}
	}

	public static void AddVorariaDynamicItemTooltip(this List<TooltipLine> tooltips, string itemTooltipKey, object tooltipVariables)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		TooltipLine dynamicTooltip = new TooltipLine((Mod)(object)V2.Instance, "V2DynamicTooltip", (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160) && ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162)) ? Language.GetTextValue("Mods.V2.ItemTooltip." + itemTooltipKey + ".Flavor") : (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160) ? Language.GetTextValueWith("Mods.V2.ItemTooltip." + itemTooltipKey + ".Long", tooltipVariables) : Language.GetTextValueWith("Mods.V2.ItemTooltip." + itemTooltipKey + ".Short", tooltipVariables)));
		if (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160) && ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162))
		{
			string tooltipFlavorText = "";
			int lineAmount = default(int);
			string[] tooltipFlavorTextLines = Utils.WordwrapString(dynamicTooltip.Text, FontAssets.MouseText.Value, 900, 25, ref lineAmount);
			for (int i = 0; i < tooltipFlavorTextLines.Length; i++)
			{
				string line = tooltipFlavorTextLines[i];
				if (line != null && line != "")
				{
					tooltipFlavorText += line;
					if (!line.Contains("\n") && i < lineAmount)
					{
						tooltipFlavorText += "\n";
					}
				}
			}
			dynamicTooltip.Text = tooltipFlavorText;
			dynamicTooltip.OverrideColor = Color.Gray;
		}
		TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Mod == "Terraria" && x.Name.Contains("Tooltip"));
		TooltipLine lastPreFlavorLine;
		if (tooltipLine != null)
		{
			foreach (TooltipLine potentialTooltipLine in tooltips)
			{
				if (potentialTooltipLine.Mod == "Terraria" && potentialTooltipLine.Name.Contains("Tooltip"))
				{
					potentialTooltipLine.Hide();
				}
			}
			tooltips.Insert(tooltips.IndexOf(tooltipLine) + 1, dynamicTooltip);
		}
		else if (FindLastTooltipLineBeforeFlavorText(tooltips, out lastPreFlavorLine))
		{
			tooltips.Insert(tooltips.IndexOf(lastPreFlavorLine) + 1, dynamicTooltip);
		}
	}

	public static int TileCountAsPixelCount(double tileCount)
	{
		return (int)Math.Round(tileCount * 16.0);
	}

	public static bool FindLastTooltipLineBeforeFlavorText(List<TooltipLine> tooltips, out TooltipLine line)
	{
		line = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2EdibleByNormalUse") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2AcidResist") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2SizeAsFood") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2Durability") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Material") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Consumable") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Ammo") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Placeable") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "UseManaPerSecond") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "UseMana") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "HealMana") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "HealLife") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "TileBoost") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "HammerPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "AxePower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PickPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Defense") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "VanityLegal") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Vanity") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Quest") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "WandConsumes") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Equipable") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "BaitPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "NeedsBait") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "FishingPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Knockback") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Speed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "CritChance") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Damage") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "SocialDesc") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Social") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "FavoriteNoNoms") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "FavoriteDesc") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Favorite") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName");
		return line != null;
	}

	public static bool FindFirstTooltipLineThatIsOrComesAfterFlavorText(List<TooltipLine> tooltips, out TooltipLine line)
	{
		line = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2DynamicTooltip") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2SetBonus") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "V2LongAndFlavorTooltipNotice") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "EtherianManaWarning") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "WellFedExpert") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "BuffTime") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "OneDropLogo") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixDamage") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixSpeed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixCritChance") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixUseMana") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixSize") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixShootSpeed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixKnockback") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixAccDefense") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixAccMaxMana") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixAccCritChance") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixAccDamage") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixAccMoveSpeed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PrefixAccMeleeSpeed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "SetBonus") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Expert") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Master") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "JourneyResearch") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "BestiaryNotes") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "SpecialPrice") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Price");
		return line != null;
	}

	public static bool FindLastDamageRelatedTooltipLine(List<TooltipLine> tooltips, out TooltipLine line)
	{
		line = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Knockback") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Speed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "CritChance") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Damage");
		return line != null;
	}

	public static bool FindLastTooltipLineBeforeManaCost(List<TooltipLine> tooltips, out TooltipLine line)
	{
		line = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "HealMana") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "HealLife") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "TileBoost") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "HammerPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "AxePower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "PickPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Defense") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "VanityLegal") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Vanity") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Quest") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "WandConsumes") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Equipable") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "BaitPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "NeedsBait") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "FishingPower") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Knockback") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Speed") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "CritChance") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Damage") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "SocialDesc") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Social") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "FavoriteDesc") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Favorite") ?? tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName");
		return line != null;
	}

	public static void InsertNewTooltipLine(ref List<TooltipLine> tooltips, TooltipLine baseLine, int lineOffset, string lineName, string lineContents)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		TooltipLine newLine = new TooltipLine((Mod)(object)V2.Instance, lineName, lineContents);
		InsertNewTooltipLine(ref tooltips, baseLine, lineOffset, newLine);
	}

	public static void InsertNewTooltipLine(ref List<TooltipLine> tooltips, TooltipLine baseLine, int lineOffset, TooltipLine newLine)
	{
		if (tooltips.IndexOf(baseLine) + lineOffset > tooltips.Count - 1)
		{
			tooltips.Add(newLine);
		}
		else
		{
			tooltips.Insert(tooltips.IndexOf(baseLine) + lineOffset, newLine);
		}
	}
}
