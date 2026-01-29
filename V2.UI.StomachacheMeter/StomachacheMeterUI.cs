using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using V2.Core;
using V2.NPCs;
using V2.PlayerHandling;
using V2.Projectiles;

namespace V2.UI.StomachacheMeter;

public class StomachacheMeterUI : UIState
{
	private bool _predHasStomachFull;

	private int _stomachacheSegments;

	private float _stomachachePercent;

	private bool _stomachacheHovered;

	private double _stomachacheExactCurrent;

	private double _stomachacheExactMax;

	private Asset<Texture2D> _stomachacheFill = ModContent.Request<Texture2D>("V2/UI/StomachacheMeter/StomachacheMeter_Fill", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachachePanelLeft = ModContent.Request<Texture2D>("V2/UI/StomachacheMeter/StomachacheMeter_Panel_Left", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachachePanelMiddle = ModContent.Request<Texture2D>("V2/UI/StomachacheMeter/StomachacheMeter_Panel_Middle", (AssetRequestMode)1);

	private Asset<Texture2D> _stomachachePanelRight = ModContent.Request<Texture2D>("V2/UI/StomachacheMeter/StomachacheMeter_Panel_Right", (AssetRequestMode)1);

	public static bool Visible { get; set; }

	public override void Update(GameTime gameTime)
	{
		Visible = true;
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		Enumerator<Player> enumerator = Main.ActivePlayers.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Player player = enumerator.Current;
			if (!(player.AsPred().StomachCapacity <= 0.0))
			{
				PrepareFields(player);
				Draw((Entity)(object)player);
			}
		}
		Enumerator<NPC> enumerator2 = Main.ActiveNPCs.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			NPC npc = enumerator2.Current;
			if (npc.AsPred().MaxStomachCapacity <= 0.0)
			{
				continue;
			}
			bool anyPlayersEatenBy = false;
			enumerator = Main.ActivePlayers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!(!enumerator.Current.IsFoodFor((Entity)(object)npc, out var pastTense) || pastTense))
				{
					anyPlayersEatenBy = true;
					break;
				}
			}
			if (anyPlayersEatenBy)
			{
				PrepareFields(npc);
				Draw((Entity)(object)npc);
			}
		}
		Enumerator<Projectile> enumerator3 = Main.ActiveProjectiles.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			Projectile projectile = enumerator3.Current;
			if (projectile.AsPred().MaxStomachCapacity <= 0.0)
			{
				continue;
			}
			bool anyPlayersEatenBy2 = false;
			enumerator = Main.ActivePlayers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!(!enumerator.Current.IsFoodFor((Entity)(object)projectile, out var pastTense2) || pastTense2))
				{
					anyPlayersEatenBy2 = true;
					break;
				}
			}
			if (anyPlayersEatenBy2)
			{
				PrepareFields(projectile);
				Draw((Entity)(object)projectile);
			}
		}
		void Draw(Entity pred)
		{
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			if (pred.CurrentCaptor() == null && (pred is Player || _stomachacheExactMax != -1.0) && (_predHasStomachFull || !(_stomachacheExactCurrent <= 0.0)))
			{
				Vector2 topLeftCorner = default(Vector2);
				((Vector2)(ref topLeftCorner))._002Ector((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2));
				topLeftCorner.X -= 14 + _stomachacheSegments * (_stomachachePanelMiddle.Value.Width / 2);
				topLeftCorner.Y -= 40f * Main.GameZoomTarget;
				topLeftCorner += pred.Center - (Main.screenPosition + new Vector2((float)(Main.screenWidth / 2) * Main.UIScale, (float)(Main.screenHeight / 2)));
				topLeftCorner.Y /= Main.UIScale;
				for (int i = 0; i < _stomachacheSegments; i++)
				{
					spriteBatch.Draw(_stomachachePanelMiddle.Value, topLeftCorner + new Vector2((float)(14 + i * _stomachachePanelMiddle.Value.Width), 6f), (Rectangle?)_stomachachePanelMiddle.Value.Bounds, Color.White);
				}
				for (int j = 0; j < _stomachacheSegments; j++)
				{
					if (!((double)j / (double)_stomachacheSegments >= (double)_stomachachePercent))
					{
						Texture2D fillTexture = _stomachacheFill.Value;
						Rectangle fullDrawRect = fillTexture.Bounds;
						if (((double)j + 1.0) / (double)_stomachacheSegments > (double)_stomachachePercent)
						{
							double fullRatio = (double)j / (double)_stomachacheSegments;
							fullRatio = (double)_stomachachePercent - fullRatio;
							fullRatio *= (double)_stomachacheSegments;
							fullDrawRect.Width = (int)Math.Ceiling((double)fullDrawRect.Width * fullRatio);
						}
						spriteBatch.Draw(fillTexture, topLeftCorner + new Vector2((float)(14 + j * _stomachachePanelMiddle.Value.Width), 8f), (Rectangle?)fullDrawRect, Color.White);
					}
				}
				spriteBatch.Draw(_stomachachePanelLeft.Value, topLeftCorner, (Rectangle?)_stomachachePanelLeft.Value.Bounds, Color.White);
				spriteBatch.Draw(_stomachachePanelRight.Value, topLeftCorner + new Vector2((float)(10 + _stomachacheSegments * _stomachachePanelMiddle.Value.Width), 0f), (Rectangle?)_stomachachePanelRight.Value.Bounds, Color.White);
				Rectangle hoverRect = default(Rectangle);
				((Rectangle)(ref hoverRect))._002Ector((int)topLeftCorner.X, (int)topLeftCorner.Y + 4, 20 + _stomachacheSegments * _stomachachePanelMiddle.Value.Width + _stomachachePanelRight.Value.Width, _stomachachePanelMiddle.Value.Height);
				_stomachacheHovered = ((Rectangle)(ref hoverRect)).Contains(Utils.ToPoint(Main.MouseScreen));
				if (_stomachacheHovered && !Main.mouseText && !Main.LocalPlayer.AsPred().InPredStatsMenu)
				{
					Main.LocalPlayer.cursorItemIconEnabled = false;
					if (_stomachacheExactMax == -1.0)
					{
						string bottomlessText = "Stomach Unease: 0 (and it will stay that way)";
						Main.instance.MouseTextHackZoom(bottomlessText, (string)null);
					}
					else
					{
						string normalText = "Stomach Unease: " + _stomachacheExactCurrent.CastToDecimalPlaces(2) + "/" + _stomachacheExactMax.CastToDecimalPlaces(2) + " (" + (_stomachacheExactCurrent / _stomachacheExactMax).ToPercentage(2) + ")";
						Main.instance.MouseTextHackZoom(normalText, (string)null);
					}
					Main.mouseText = true;
				}
			}
		}
	}

	private void PrepareFields(Player player)
	{
		PlayerPredStomachacheSnapshot PlayerPredStatsSnapshot = new PlayerPredStomachacheSnapshot(player);
		VoreTracker stomachTracker = player.AsPred().StomachTracker;
		_predHasStomachFull = stomachTracker != null && stomachTracker.Prey.FindAll((PreyData x) => !x.NoHealth)?.Count > 0;
		_stomachacheSegments = PlayerPredStatsSnapshot.AmountOfStomachacheMeterSegments;
		if (PlayerPredStatsSnapshot.StomachacheMax == -1.0)
		{
			_stomachachePercent = 0f;
		}
		else
		{
			_stomachachePercent = (float)PlayerPredStatsSnapshot.Stomachache / (float)PlayerPredStatsSnapshot.StomachacheMax;
		}
		_stomachacheExactCurrent = PlayerPredStatsSnapshot.Stomachache;
		_stomachacheExactMax = PlayerPredStatsSnapshot.StomachacheMax;
	}

	private void PrepareFields(NPC npc)
	{
		NPCPredStomachacheSnapshot NPCPredStatsSnapshot = new NPCPredStomachacheSnapshot(npc);
		VoreTracker stomachTracker = PredNPC.GetStomachTracker(npc);
		_predHasStomachFull = stomachTracker != null && stomachTracker.Prey.FindAll((PreyData x) => !x.NoHealth)?.Count > 0;
		_stomachacheSegments = NPCPredStatsSnapshot.AmountOfStomachacheMeterSegments;
		if (NPCPredStatsSnapshot.StomachacheMax == -1.0)
		{
			_stomachachePercent = 0f;
		}
		else
		{
			_stomachachePercent = (float)NPCPredStatsSnapshot.Stomachache / (float)NPCPredStatsSnapshot.StomachacheMax;
		}
		_stomachacheExactCurrent = NPCPredStatsSnapshot.Stomachache;
		_stomachacheExactMax = NPCPredStatsSnapshot.StomachacheMax;
	}

	private void PrepareFields(Projectile projectile)
	{
		ProjectilePredStomachacheSnapshot NPCPredStatsSnapshot = new ProjectilePredStomachacheSnapshot(projectile);
		VoreTracker stomachTracker = PredProjectile.GetStomachTracker(projectile);
		_predHasStomachFull = stomachTracker != null && stomachTracker.Prey.FindAll((PreyData x) => !x.NoHealth)?.Count > 0;
		_stomachacheSegments = NPCPredStatsSnapshot.AmountOfStomachacheMeterSegments;
		if (NPCPredStatsSnapshot.StomachacheMax == -1.0)
		{
			_stomachachePercent = 0f;
		}
		else
		{
			_stomachachePercent = (float)NPCPredStatsSnapshot.Stomachache / (float)NPCPredStatsSnapshot.StomachacheMax;
		}
		_stomachacheExactCurrent = NPCPredStatsSnapshot.Stomachache;
		_stomachacheExactMax = NPCPredStatsSnapshot.StomachacheMax;
	}
}
