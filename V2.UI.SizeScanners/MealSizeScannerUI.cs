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

public class MealSizeScannerUI : UIState
{
	public static bool Visible { get; set; }

	public override void Update(GameTime gameTime)
	{
		Visible = false;
		if (Main.LocalPlayer.AsPred().SizeScanner)
		{
			Visible = true;
		}
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		double maxEntityDistanceForDrawing = V2Utils.TileCountAsPixelCount(100.0);
		Player player = Main.LocalPlayer;
		double playerGutCapacity = player.AsPred().StomachCapacity;
		double playerGutFullness = player.AsPred().StomachFullness;
		for (int i = 0; i < Main.maxNPCs; i++)
		{
			NPC futureFood = Main.npc[i];
			if (((Entity)futureFood).active && ((Entity)(object)futureFood).CurrentCaptor() == null && !futureFood.AsFood().CannotBeEatenDueToShenanigans && !((double)((Entity)futureFood).Distance(((Entity)(object)player).TrueCenter()) >= maxEntityDistanceForDrawing))
			{
				string size = "[c/";
				double npcSize = PreyData.GetPreySize((Entity)(object)futureFood).CastToDecimalPlaces(3);
				if (player.AsPred().Rose)
				{
					size += "00FFFF";
				}
				else if (player.AsPred().SwallowCapacity < npcSize)
				{
					size += "FF0000";
				}
				else if (player.AsPred().StomachCapacity < npcSize)
				{
					size += "FF0000";
				}
				else
				{
					double num = playerGutCapacity - playerGutFullness;
					double playerGutTickDamage = Math.Max(player.AsPred().DigestionTickDamage - (double)futureFood.defense, 0.0);
					double playerGutDPS = playerGutTickDamage * player.AsPred().DigestionTickRate;
					size = ((num < npcSize) ? (size + "FFFF00") : ((playerGutTickDamage <= 0.0) ? (size + "FFFF00") : ((!((double)futureFood.life > playerGutDPS * 60.0)) ? (size + "00FF00") : (size + "FFFF00"))));
				}
				size = size + ":" + npcSize + "]";
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, size, ((Entity)futureFood).Center + new Vector2(0f, (float)(-(((Entity)futureFood).height / 2 + 16))) - Main.screenPosition, Color.White, 0f, ChatManager.GetStringSize(FontAssets.MouseText.Value, size, Vector2.One, -1f) * 0.5f, Vector2.One, -1f, 2f);
			}
		}
		for (int j = 0; j < 255; j++)
		{
			Player futureFood2 = Main.player[j];
			if (((Entity)futureFood2).active && !futureFood2.dead && ((Entity)futureFood2).whoAmI != Main.myPlayer && ((Entity)(object)futureFood2).CurrentCaptor() == null && !((double)((Entity)futureFood2).Distance(((Entity)(object)player).TrueCenter()) >= maxEntityDistanceForDrawing))
			{
				string size2 = "[c/";
				double playerSize = PreyData.GetPreySize((Entity)(object)futureFood2).CastToDecimalPlaces(3);
				if (player.AsPred().SwallowCapacity < playerSize)
				{
					size2 += "FF00";
				}
				else if (player.AsPred().StomachCapacity < playerSize)
				{
					size2 += "FF00";
				}
				else
				{
					double num2 = playerGutCapacity - playerGutFullness;
					double playerGutTickDamage2 = Math.Max(player.AsPred().DigestionTickDamage - (double)DefenseStat.op_Implicit(futureFood2.statDefense), 0.0);
					double playerGutDPS2 = playerGutTickDamage2 * player.AsPred().DigestionTickRate;
					size2 = ((num2 < playerSize) ? (size2 + "FFFF") : ((playerGutTickDamage2 <= 0.0) ? (size2 + "FFFF") : ((!((double)futureFood2.statLife > playerGutDPS2 * 60.0)) ? (size2 + "00FF") : (size2 + "FFFF"))));
				}
				size2 = size2 + "00:" + playerSize + "]";
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, size2, ((Entity)futureFood2).Center + new Vector2(0f, (float)(-(((Entity)futureFood2).height / 2 + 16))) - Main.screenPosition, Color.White, 0f, ChatManager.GetStringSize(FontAssets.MouseText.Value, size2, Vector2.One, -1f) * 0.5f, Vector2.One, -1f, 2f);
			}
		}
	}
}
