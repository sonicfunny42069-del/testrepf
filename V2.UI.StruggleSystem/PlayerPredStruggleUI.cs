using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using V2.Core.StruggleSystem;
using V2.PlayerHandling;

namespace V2.UI.StruggleSystem;

public class PlayerPredStruggleUI : UIState
{
	private Asset<Texture2D> _struggleSystemBackdrop = ModContent.Request<Texture2D>("V2/UI/StruggleSystem/StruggleSystem_Main_NoteBackdrop", (AssetRequestMode)1);

	private Asset<Texture2D> _struggleNoteUp = ModContent.Request<Texture2D>("V2/UI/StruggleSystem/StruggleSystem_Main_UpNote", (AssetRequestMode)1);

	private Asset<Texture2D> _struggleNoteLeft = ModContent.Request<Texture2D>("V2/UI/StruggleSystem/StruggleSystem_Main_LeftNote", (AssetRequestMode)1);

	private Asset<Texture2D> _struggleNoteSpecial = ModContent.Request<Texture2D>("V2/UI/StruggleSystem/StruggleSystem_Main_UpNote", (AssetRequestMode)1);

	private Asset<Texture2D> _struggleNoteRight = ModContent.Request<Texture2D>("V2/UI/StruggleSystem/StruggleSystem_Main_RightNote", (AssetRequestMode)1);

	private Asset<Texture2D> _struggleNoteDown = ModContent.Request<Texture2D>("V2/UI/StruggleSystem/StruggleSystem_Main_DownNote", (AssetRequestMode)1);

	public static bool Visible { get; set; }

	public override void Update(GameTime gameTime)
	{
		Visible = false;
		if (Main.netMode == 0)
		{
			Player player = Main.LocalPlayer;
			if (player.AsPred().KickyStomachFullness > 0.0 && player.AsPred().StomachTracker.PredatorStruggleChart != null)
			{
				Visible = true;
			}
		}
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		Vector2 bottomCenter = default(Vector2);
		((Vector2)(ref bottomCenter))._002Ector((float)(Main.screenWidth / 2), (float)(Main.screenHeight / 2));
		bottomCenter.X += 16f;
		bottomCenter.X += 80f;
		bottomCenter.Y -= 55f * Main.GameZoomTarget;
		bottomCenter += ((Entity)Main.LocalPlayer).Center - (Main.screenPosition + new Vector2((float)(Main.screenWidth / 2) * Main.UIScale, (float)(Main.screenHeight / 2)));
		bottomCenter.Y /= Main.UIScale;
		Texture2D value = _struggleSystemBackdrop.Value;
		Vector2 val = bottomCenter;
		Rectangle? val2 = _struggleSystemBackdrop.Value.Bounds;
		Color white = Color.White;
		Rectangle bounds = _struggleSystemBackdrop.Value.Bounds;
		spriteBatch.Draw(value, val, val2, white, 0f, new Vector2((float)((Rectangle)(ref bounds)).Bottom, (float)(_struggleSystemBackdrop.Value.Width / 2)), 1f, (SpriteEffects)0, 0f);
		Rectangle noteFrame = default(Rectangle);
		foreach (var noteData in Main.LocalPlayer.AsPred().StomachTracker.CheckCloseNotes(-1, forUI: true))
		{
			if (noteData.note.CorrectlyPressed && noteData.note.PressAnimTimer >= 28)
			{
				continue;
			}
			float alpha = 1f;
			if (!noteData.note.CorrectlyPressed)
			{
				if (noteData.proximity >= 0.0)
				{
					double realProximity = 2.5 - noteData.proximity;
					if (realProximity < 0.0)
					{
						realProximity = 0.0;
					}
					alpha = (float)Math.Min(Math.Max(realProximity / 2.5, 0.0), 1.0);
				}
				else if (noteData.proximity < 0.0)
				{
					double realProximity2 = 0.5 + noteData.proximity;
					if (realProximity2 < 0.0)
					{
						realProximity2 = 0.0;
					}
					alpha = (float)Math.Min(Math.Max(realProximity2 / 0.5, 0.0), 1.0);
				}
			}
			Vector2 notePosition = bottomCenter;
			notePosition.X -= 16f;
			ref float x = ref notePosition.X;
			float num = x;
			x = num + (float)(noteData.note.Lane switch
			{
				NoteLane.Up => -48, 
				NoteLane.Left => -24, 
				NoteLane.Special => 0, 
				NoteLane.Right => 24, 
				NoteLane.Down => 48, 
				_ => 0, 
			});
			notePosition.Y -= (float)((noteData.note.CorrectlyPressed ? noteData.note.PressedPosition : noteData.proximity) * 26.0) * 1.5f;
			int frame = 0;
			if (noteData.note.PressAnimTimer > 7)
			{
				frame = 1;
			}
			if (noteData.note.PressAnimTimer > 14)
			{
				frame = 2;
			}
			if (noteData.note.PressAnimTimer > 21)
			{
				frame = 3;
			}
			((Rectangle)(ref noteFrame))._002Ector(frame * 28, 0, 26, 26);
			spriteBatch.Draw((Texture2D)(noteData.note.Lane switch
			{
				NoteLane.Up => _struggleNoteUp.Value, 
				NoteLane.Left => _struggleNoteLeft.Value, 
				NoteLane.Special => _struggleNoteSpecial.Value, 
				NoteLane.Right => _struggleNoteRight.Value, 
				NoteLane.Down => _struggleNoteDown.Value, 
				_ => null, 
			}), notePosition, (Rectangle?)noteFrame, Color.White * alpha, 0f, Utils.Size(noteFrame) / 2f, 1f, (SpriteEffects)0, 0f);
		}
	}
}
