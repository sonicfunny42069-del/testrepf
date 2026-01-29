using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using V2.Core;
using V2.PlayerHandling;

namespace V2.UI.StomachCapacityMeter;

public class StomachCapacityMeterUI : UIState
{
	private int _capacitySegmentsCount;

	private double _kickyPreyPercent;

	private float _capacityPercent;

	private bool _stomachCapacityHovered;

	private Asset<Texture2D> _stomachCapacityFill = ModContent.Request<Texture2D>("V2/UI/StomachCapacityMeter/StomachCapacityMeter_Fill", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachCapacityFillKicky = ModContent.Request<Texture2D>("V2/UI/StomachCapacityMeter/StomachCapacityMeter_Fill_Kicky", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachCapacityPanelLeft = ModContent.Request<Texture2D>("V2/UI/StomachCapacityMeter/StomachCapacityMeter_Panel_Left", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachCapacityPanelMiddle = ModContent.Request<Texture2D>("V2/UI/StomachCapacityMeter/StomachCapacityMeter_Panel_Middle", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachCapacityPanelRight = ModContent.Request<Texture2D>("V2/UI/StomachCapacityMeter/StomachCapacityMeter_Panel_Right", (AssetRequestMode)1);

	public static bool Visible { get; set; }

	public override void Update(GameTime gameTime)
	{
		Visible = false;
		Player player = Main.LocalPlayer;
		if (player.AsPred().StomachFullness > 0.0 && ((Entity)(object)player).CurrentCaptor() == null)
		{
			Visible = true;
		}
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		PrepareFields(Main.LocalPlayer);
		Vector2 topLeftCorner = default(Vector2);
		((Vector2)(ref topLeftCorner))._002Ector((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2));
		topLeftCorner.X -= 20 + _capacitySegmentsCount * (_stomachCapacityPanelMiddle.Value.Width / 2);
		topLeftCorner.Y += 32f * Main.GameZoomTarget;
		topLeftCorner += ((Entity)Main.LocalPlayer).Center - (Main.screenPosition + new Vector2((float)(Main.screenWidth / 2) * Main.UIScale, (float)(Main.screenHeight / 2)));
		topLeftCorner.Y /= Main.UIScale;
		for (int i = 0; i < _capacitySegmentsCount; i++)
		{
			spriteBatch.Draw(_stomachCapacityPanelMiddle.Value, topLeftCorner + new Vector2((float)(20 + i * _stomachCapacityPanelMiddle.Value.Width), 4f), (Rectangle?)_stomachCapacityPanelMiddle.Value.Bounds, Color.White);
		}
		for (int j = 0; j < _capacitySegmentsCount; j++)
		{
			if ((double)j / (double)_capacitySegmentsCount >= (double)_capacityPercent)
			{
				continue;
			}
			Texture2D fillTexture = _stomachCapacityFill.Value;
			Rectangle fullDrawRect = fillTexture.Bounds;
			if (((double)j + 1.0) / (double)_capacitySegmentsCount > (double)_capacityPercent)
			{
				double fullRatio = (double)j / (double)_capacitySegmentsCount;
				fullRatio = (double)_capacityPercent - fullRatio;
				fullRatio *= (double)_capacitySegmentsCount;
				fullDrawRect.Width = (int)Math.Ceiling((double)fullDrawRect.Width * fullRatio);
			}
			spriteBatch.Draw(fillTexture, topLeftCorner + new Vector2((float)(20 + j * _stomachCapacityPanelMiddle.Value.Width), 10f), (Rectangle?)fullDrawRect, Color.White);
			if (!(_kickyPreyPercent <= 0.0) && !((double)j / (double)_capacitySegmentsCount >= _kickyPreyPercent))
			{
				Texture2D kickyFillTexture = _stomachCapacityFillKicky.Value;
				Rectangle kickyDrawRect = kickyFillTexture.Bounds;
				if (((double)j + 1.0) / (double)_capacitySegmentsCount > _kickyPreyPercent)
				{
					double kickyRatio = (double)j / (double)_capacitySegmentsCount;
					kickyRatio = _kickyPreyPercent - kickyRatio;
					kickyRatio *= (double)_capacitySegmentsCount;
					kickyDrawRect.Width = (int)Math.Ceiling((double)kickyDrawRect.Width * kickyRatio);
				}
				spriteBatch.Draw(kickyFillTexture, topLeftCorner + new Vector2((float)(20 + j * _stomachCapacityPanelMiddle.Value.Width), 10f), (Rectangle?)kickyDrawRect, Color.White);
			}
		}
		spriteBatch.Draw(_stomachCapacityPanelLeft.Value, topLeftCorner, (Rectangle?)_stomachCapacityPanelLeft.Value.Bounds, Color.White);
		spriteBatch.Draw(_stomachCapacityPanelRight.Value, topLeftCorner + new Vector2((float)(20 + _capacitySegmentsCount * _stomachCapacityPanelMiddle.Value.Width), 4f), (Rectangle?)_stomachCapacityPanelRight.Value.Bounds, Color.White);
		Rectangle hoverRect = default(Rectangle);
		((Rectangle)(ref hoverRect))._002Ector((int)topLeftCorner.X, (int)topLeftCorner.Y + 4, 20 + _capacitySegmentsCount * _stomachCapacityPanelMiddle.Value.Width + _stomachCapacityPanelRight.Value.Width, _stomachCapacityPanelMiddle.Value.Height);
		_stomachCapacityHovered = ((Rectangle)(ref hoverRect)).Contains(Utils.ToPoint(Main.MouseScreen));
		if (_stomachCapacityHovered && !Main.mouseText && !Main.LocalPlayer.AsPred().InPredStatsMenu)
		{
			Player localPlayer = Main.LocalPlayer;
			localPlayer.cursorItemIconEnabled = false;
			if (localPlayer.AsPred().StomachCapacity == -1.0)
			{
				string bottomlessText = "Stomach Fullness: " + localPlayer.AsPred().StomachFullness.CastToDecimalPlaces(2) + " (Infinite Capacity)\nStomach Size: " + localPlayer.AsPred().StomachSize;
				Main.instance.MouseTextHackZoom(bottomlessText, (string)null);
			}
			else
			{
				string normalText = "Stomach Fullness: " + localPlayer.AsPred().StomachFullness.CastToDecimalPlaces(2) + "/" + localPlayer.AsPred().StomachCapacity.CastToDecimalPlaces(2) + " (" + (localPlayer.AsPred().StomachFullness / localPlayer.AsPred().StomachCapacity).ToPercentage(2) + ")\nStomach Size: " + localPlayer.AsPred().StomachSize;
				Main.instance.MouseTextHackZoom(normalText, (string)null);
			}
			Main.mouseText = true;
		}
	}

	private void PrepareFields(Player player)
	{
		PlayerPredStomachCapacitySnapshot PlayerPredStatsSnapshot = new PlayerPredStomachCapacitySnapshot(player);
		_capacitySegmentsCount = PlayerPredStatsSnapshot.AmountOfCapacitySegments;
		_kickyPreyPercent = PlayerPredStatsSnapshot.KickyPreyPercentage;
		if (PlayerPredStatsSnapshot.CapacityMax == -1.0)
		{
			_capacityPercent = 1f;
		}
		else
		{
			_capacityPercent = (float)PlayerPredStatsSnapshot.Fullness / (float)PlayerPredStatsSnapshot.CapacityMax;
		}
	}
}
