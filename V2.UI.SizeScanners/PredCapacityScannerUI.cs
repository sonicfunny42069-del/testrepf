using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;
using Terraria.UI.Chat;
using V2.Core;
using V2.NPCs;
using V2.PlayerHandling;

namespace V2.UI.SizeScanners;

public class PredCapacityScannerUI : UIState
{
	public static bool Visible { get; set; }

	public override void Update(GameTime gameTime)
	{
		Visible = false;
		if (Main.LocalPlayer.AsFood().PredScanner)
		{
			Visible = true;
		}
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		double maxEntityDistanceForDrawing = V2Utils.TileCountAsPixelCount(100.0);
		Player player = Main.LocalPlayer;
		double playerSize = PreyData.GetPreySize((Entity)(object)player);
		PreyData playerAsFood = PreyData.NewData((Entity)(object)player);
		for (int i = 0; i < Main.maxNPCs; i++)
		{
			NPC futurePred = Main.npc[i];
			if (!((Entity)futurePred).active || ((Entity)(object)futurePred).CurrentCaptor() != null || (double)((Entity)futurePred).Distance(((Entity)(object)player).TrueCenter()) >= maxEntityDistanceForDrawing)
			{
				continue;
			}
			double futurePredGutCapacity = futurePred.AsPred().MaxStomachCapacity;
			double futurePredGutFullness = PredNPC.GetCurrentBellyWeight(futurePred);
			string size = "[c/";
			if (futurePred.AsPred().GetDigestionTickDamage == null || futurePred.AsPred().GetDigestionTickRate == null)
			{
				size = "[c/FF0000:N/A]";
			}
			else if (futurePred.AsPred().MaxStomachCapacity >= 9999999.0)
			{
				size = "[c/00FFFF:∞]";
			}
			else
			{
				if (player.AsFood().PerfectMeal)
				{
					size += "00FFFF";
				}
				else if (futurePredGutCapacity < playerSize)
				{
					size += "FF0000";
				}
				else
				{
					double num = futurePredGutCapacity - futurePredGutFullness;
					double futurePredGutTickDamage = Math.Max(futurePred.AsPred().GetDigestionTickDamage(futurePred, playerAsFood) - (double)DefenseStat.op_Implicit(player.statDefense), 0.0);
					double futurePredGutDPS = futurePredGutTickDamage * futurePred.AsPred().GetDigestionTickRate(futurePred, playerAsFood);
					size = ((num < playerSize) ? (size + "FFFF00") : ((futurePredGutTickDamage <= 0.0) ? (size + "FFFF00") : ((!((double)player.statLife > futurePredGutDPS * 60.0)) ? (size + "00FF00") : (size + "FFFF00"))));
				}
				size = size + ":" + futurePredGutCapacity + "]";
			}
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, size, ((Entity)futurePred).Center + new Vector2(0f, (float)(((Entity)futurePred).height / 2 + 16)) - Main.screenPosition, Color.White, 0f, ChatManager.GetStringSize(FontAssets.MouseText.Value, size, Vector2.One, -1f) * 0.5f, Vector2.One, -1f, 2f);
		}
		for (int j = 0; j < 255; j++)
		{
			Player futurePred2 = Main.player[j];
			if (((Entity)futurePred2).active && !futurePred2.dead && ((Entity)futurePred2).whoAmI != Main.myPlayer && ((Entity)(object)futurePred2).CurrentCaptor() == null && !((double)((Entity)futurePred2).Distance(((Entity)(object)player).TrueCenter()) >= maxEntityDistanceForDrawing))
			{
				double futurePredGutCapacity2 = futurePred2.AsPred().StomachCapacity;
				double futurePredGutFullness2 = futurePred2.AsPred().StomachFullness;
				string size2 = "[c/";
				if (futurePredGutCapacity2 < playerSize)
				{
					size2 += "FF00";
				}
				else
				{
					double num2 = futurePredGutCapacity2 - futurePredGutFullness2;
					double futurePredGutTickDamage2 = Math.Max(futurePred2.AsPred().DigestionTickDamage - (double)DefenseStat.op_Implicit(player.statDefense), 0.0);
					double futurePredGutDPS2 = futurePredGutTickDamage2 * futurePred2.AsPred().DigestionTickRate;
					size2 = ((num2 < playerSize) ? (size2 + "FFFF") : ((futurePredGutTickDamage2 <= 0.0) ? (size2 + "FFFF") : ((!((double)player.statLife > futurePredGutDPS2 * 60.0)) ? (size2 + "00FF") : (size2 + "FFFF"))));
				}
				size2 = size2 + "00:" + futurePredGutCapacity2 + "]";
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, size2, ((Entity)futurePred2).Center + new Vector2(0f, (float)(((Entity)futurePred2).height / 2 + 16)) - Main.screenPosition, Color.White, 0f, ChatManager.GetStringSize(FontAssets.MouseText.Value, size2, Vector2.One, -1f) * 0.5f, Vector2.One, -1f, 2f);
			}
		}
	}
}
