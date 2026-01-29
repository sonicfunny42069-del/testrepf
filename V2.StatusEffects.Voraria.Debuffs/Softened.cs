using System;
using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using V2.Core;
using V2.NPCs;
using V2.PlayerHandling;

namespace V2.StatusEffects.Voraria.Debuffs;

public class Softened : ModBuff
{
	public static double MaxHealthDigestedForOneStack => 0.05;

	public static double DefenseReductionPerStack => 0.075;

	public static float DigestionDamageIncreasePerStack => 0.15f;

	public static int MaxStacks => 10;

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.StatusEffects.Voraria.Debuffs.Softened.Name");

	public override LocalizedText Description => Language.GetText("Mods.V2.StatusEffects.Voraria.Debuffs.Softened.Description.Base");

	public override void SetStaticDefaults()
	{
		Main.buffNoTimeDisplay[((ModBuff)this).Type] = true;
		Main.debuff[((ModBuff)this).Type] = true;
		Sets.NurseCannotRemoveDebuff[((ModBuff)this).Type] = true;
	}

	public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
	{
		if (Main.LocalPlayer.AsFood().SoftenedStacks > 0)
		{
			buffName = buffName + " " + RomanNumeralExtensions.ToRoman(Main.LocalPlayer.AsFood().SoftenedStacks);
		}
		rare = 7;
		string baseTooltip = Language.GetTextValueWith("Mods.V2.StatusEffects.Voraria.Debuffs.Softened.Description.Base", (object)new
		{
			SoftenedMaxHealthThreshold = MaxHealthDigestedForOneStack.ToPercentage(1),
			SoftenedMaxStacks = MaxStacks,
			SoftenedStacks = Main.LocalPlayer.AsFood().SoftenedStacks,
			SoftenedDefReduction = DefenseReductionPerStack.ToPercentage(1),
			SoftenedCurrentDefReduction = ((double)Main.LocalPlayer.AsFood().SoftenedStacks * DefenseReductionPerStack).ToPercentage(1),
			SoftenedDigestiveAid = DigestionDamageIncreasePerStack.ToPercentage(1),
			SoftenedCurrentDigestiveAid = ((float)Main.LocalPlayer.AsFood().SoftenedStacks * DigestionDamageIncreasePerStack).ToPercentage(1)
		});
		string dynamicFlavorText = "'" + Language.GetTextValue("Mods.V2.StatusEffects.Voraria.Debuffs.Softened.Description.Flavor." + Main.LocalPlayer.AsFood().SoftenedStacks) + "'";
		tip = baseTooltip + "\n" + dynamicFlavorText;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		player.DefenseEffectiveness *= (float)(1.0 - DefenseReductionPerStack * (double)player.AsFood().SoftenedStacks);
		PreyPlayer preyPlayer = player.AsFood();
		preyPlayer.TakenDigestionDamageModifier *= (float)(1.0 + (double)(DigestionDamageIncreasePerStack * (float)player.AsFood().SoftenedStacks));
		player.buffTime[buffIndex] = 3;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		npc.defense = (int)Math.Round((double)npc.defense * (1.0 - DefenseReductionPerStack * (double)npc.SoftenedStacks()));
		PreyNPC preyNPC = npc.AsFood();
		preyNPC.TakenDigestionDamageModifier *= (float)(1.0 + (double)(DigestionDamageIncreasePerStack * (float)npc.SoftenedStacks()));
		npc.buffTime[buffIndex] = 3;
	}

	public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		Texture2D buffTextureSheet = ModContent.Request<Texture2D>("V2/StatusEffects/Voraria/Debuffs/SoftenedSheet", (AssetRequestMode)2).Value;
		spriteBatch.Draw(buffTextureSheet, drawParams.Position, (Rectangle?)new Rectangle(34 * Main.LocalPlayer.AsFood().SoftenedStacks, 0, 32, 38), drawParams.DrawColor, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		double barFillRatio = Main.LocalPlayer.AsFood().SoftenedDigestionDamageTaken % ((double)Main.LocalPlayer.statLifeMax * MaxHealthDigestedForOneStack) / ((double)Main.LocalPlayer.statLifeMax * MaxHealthDigestedForOneStack);
		if (Main.LocalPlayer.AsFood().SoftenedStacks == MaxStacks)
		{
			barFillRatio = 0.0;
		}
		spriteBatch.Draw(buffTextureSheet, drawParams.Position + new Vector2(4f, 28f), (Rectangle?)new Rectangle(4, 40, (int)Math.Floor(24.0 * barFillRatio), 6), drawParams.DrawColor, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		spriteBatch.Draw(buffTextureSheet, drawParams.Position + new Vector2(4f + (float)Math.Floor(24.0 * barFillRatio), 28f), (Rectangle?)new Rectangle(4 + (int)Math.Floor(24.0 * barFillRatio), 46, (int)Math.Ceiling(24.0 * (1.0 - barFillRatio)), 6), drawParams.DrawColor, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		Vector2 stringSize = FontAssets.MouseText.Value.MeasureString(Main.LocalPlayer.AsFood().SoftenedStacks.ToString() ?? "");
		ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, (Main.LocalPlayer.AsFood().SoftenedStacks > 0) ? RomanNumeralExtensions.ToRoman(Main.LocalPlayer.AsFood().SoftenedStacks) : "0", drawParams.Position + new Vector2(30f, 25f), drawParams.DrawColor, 0f, new Vector2(stringSize.X, stringSize.Y / 2f), new Vector2(0.8f), -1f, 2f);
		return false;
	}
}
