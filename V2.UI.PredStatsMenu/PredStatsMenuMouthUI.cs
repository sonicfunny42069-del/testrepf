using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using V2.PlayerHandling;
using V2.Sounds.Vore;

namespace V2.UI.PredStatsMenu;

public class PredStatsMenuMouthUI : UIState
{
	private static Asset<Texture2D> _predStatsMenuEntryMaw = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenuMouth_Panel", (AssetRequestMode)1);

	private static Asset<Texture2D> _predStatsMenuBackground = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Background", (AssetRequestMode)1);

	public static bool Visible { get; set; }

	public static bool CanSkipThisFrame { get; set; }

	public static Vector2 MouthPosition
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			Vector2 defPos = default(Vector2);
			((Vector2)(ref defPos))._002Ector(AccessorySlotLoader.DefenseIconPosition.X - 10f - 47f - 47f - 14f, AccessorySlotLoader.DefenseIconPosition.Y + (float)Utils.Height(TextureAssets.InventoryBack) * 0.5f);
			Vector2 mouthPosition = default(Vector2);
			((Vector2)(ref mouthPosition))._002Ector((float)(int)(defPos.X - (float)TextureAssets.Extra[58].Value.Width / 2f), (float)(int)(defPos.Y - (float)TextureAssets.Extra[58].Value.Height / 2f));
			mouthPosition.X -= 30f;
			mouthPosition.Y += 16f;
			return mouthPosition;
		}
	}

	public static int MouthState { get; set; }

	private int _mawHoverTime { get; set; }

	private int _mawSwallowTime { get; set; }

	public override void Update(GameTime gameTime)
	{
		Visible = false;
		if (Main.playerInventory && Main.EquipPage == 0 && !Main.LocalPlayer.dead && !V2.GetFooled)
		{
			Visible = true;
			return;
		}
		_mawHoverTime = 0;
		MouthState = 0;
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		int x = 1;
		int y = 1;
		Rectangle hoverBox = default(Rectangle);
		((Rectangle)(ref hoverBox))._002Ector((int)MouthPosition.X - 17, (int)MouthPosition.Y - 17, 34, 34);
		Vector2 backdropPos = default(Vector2);
		((Vector2)(ref backdropPos))._002Ector((float)((Main.screenWidth - _predStatsMenuBackground.Value.Width) / 2), (float)((Main.screenHeight - _predStatsMenuBackground.Value.Height) / 2));
		SoundStyle val;
		switch (MouthState)
		{
		case 0:
			if (((Rectangle)(ref hoverBox)).Contains(Utils.ToPoint(Main.MouseScreen)))
			{
				MouthState = 1;
				goto case 1;
			}
			_mawHoverTime--;
			if (_mawHoverTime < 0)
			{
				_mawHoverTime = 0;
			}
			DecideNormalFrame();
			y = 1;
			break;
		case 1:
			if (Main.mouseLeft && Main.mouseLeftRelease)
			{
				Main.LocalPlayer.AsPred().InPredStatsMenu = true;
				if (ModContent.GetInstance<V2ClientConfig>().SkipPredStatMenuAnims)
				{
					val = Gulps.Short;
					((SoundStyle)(ref val)).Volume = 1f;
					SoundEngine.PlaySound(ref val, (Vector2?)(Main.screenPosition + MouthPosition), (SoundUpdateCallback)null);
					MouthState = 3;
					goto case 3;
				}
				MouthState = 2;
				CanSkipThisFrame = false;
				goto case 2;
			}
			if (!((Rectangle)(ref hoverBox)).Contains(Utils.ToPoint(Main.MouseScreen)))
			{
				MouthState = 0;
				goto case 0;
			}
			Main.LocalPlayer.mouseInterface = true;
			_mawHoverTime++;
			if (_mawHoverTime > 225)
			{
				_mawHoverTime = 225;
			}
			Main.instance.MouseTextNoOverride("Open the pred stats menu\n(WARNING: Your cursor may or\nmay not get eaten by doing this)", 0, (byte)0, -1, -1, -1, -1, 0);
			DecideNormalFrame();
			y = 2;
			break;
		case 2:
			Main.LocalPlayer.mouseInterface = true;
			if (_mawSwallowTime >= 105 || (Main.mouseLeft && Main.mouseLeftRelease && CanSkipThisFrame) || ModContent.GetInstance<V2ClientConfig>().SkipPredStatMenuAnims)
			{
				_mawSwallowTime = 105;
				if (Main.hasFocus)
				{
					Mouse.SetPosition((int)backdropPos.X + _predStatsMenuBackground.Value.Width / 2, (int)backdropPos.Y + 40);
				}
				MouthState = 3;
				goto case 3;
			}
			switch (_mawSwallowTime)
			{
			case 0:
				val = Gulps.Short;
				((SoundStyle)(ref val)).Volume = 1f;
				SoundEngine.PlaySound(ref val, (Vector2?)(Main.screenPosition + MouthPosition), (SoundUpdateCallback)null);
				break;
			case 40:
				val = Gulps.Standard;
				((SoundStyle)(ref val)).Volume = 1f;
				((SoundStyle)(ref val)).Pitch = -0.35f;
				SoundEngine.PlaySound(ref val, (Vector2?)(Main.screenPosition + MouthPosition), (SoundUpdateCallback)null);
				break;
			}
			_mawSwallowTime++;
			if (Main.hasFocus)
			{
				Mouse.SetPosition((int)backdropPos.X + _predStatsMenuBackground.Value.Width / 2, (int)backdropPos.Y + 40);
			}
			DecideCursorGettingGulpedFrame(midSwallow: true);
			break;
		case 3:
			DecideCursorGettingGulpedFrame(midSwallow: false);
			break;
		case 4:
			Main.LocalPlayer.mouseInterface = true;
			if (_mawSwallowTime <= 0 || (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)27) && !((KeyboardState)(ref Main.oldKeyState)).IsKeyDown((Keys)27) && CanSkipThisFrame) || ModContent.GetInstance<V2ClientConfig>().SkipPredStatMenuAnims)
			{
				_mawSwallowTime = 0;
				val = Burps.Humanoid.Small;
				((SoundStyle)(ref val)).Volume = 0.9f;
				SoundEngine.PlaySound(ref val, (Vector2?)(Main.screenPosition + MouthPosition), (SoundUpdateCallback)null);
				Main.LocalPlayer.AsPred().InPredStatsMenu = false;
				_mawHoverTime = 145;
				Mouse.SetPosition((int)MouthPosition.X, (int)MouthPosition.Y);
				MouthState = 1;
				goto case 1;
			}
			if (Main.hasFocus)
			{
				Mouse.SetPosition((int)backdropPos.X + _predStatsMenuBackground.Value.Width / 2, (int)backdropPos.Y + 40);
			}
			_mawSwallowTime--;
			DecideCursorGettingGulpedFrame(midSwallow: true);
			break;
		}
		CanSkipThisFrame = true;
		spriteBatch.Draw(_predStatsMenuEntryMaw.Value, MouthPosition, (Rectangle?)new Rectangle(36 * (x - 1), 36 * (y - 1), 34, 34), Color.White, 0f, Utils.Size(hoverBox) / 2f, 1f, (SpriteEffects)0, 0f);
		void DecideCursorGettingGulpedFrame(bool midSwallow)
		{
			y = 3;
			if (midSwallow)
			{
				int i = _mawSwallowTime;
				if (i < 40)
				{
					x = 1;
				}
				else
				{
					int i2 = i;
					if (i2 >= 40 && i2 < 50)
					{
						x = 2;
					}
					else
					{
						int i3 = i;
						if (i3 >= 50 && i3 < 60)
						{
							x = 3;
						}
						else
						{
							int i4 = i;
							if (i4 >= 60 && i4 < 70)
							{
								x = 4;
							}
							else
							{
								int i5 = i;
								if (i5 >= 70 && i5 < 77)
								{
									x = 5;
								}
								else
								{
									int i6 = i;
									if (i6 >= 77 && i6 < 84)
									{
										x = 6;
									}
									else
									{
										int i7 = i;
										if (i7 >= 84 && i7 < 91)
										{
											x = 7;
										}
										else
										{
											int i8 = i;
											if (i8 >= 91 && i8 < 98)
											{
												x = 8;
											}
											else
											{
												int i9 = i;
												if (i9 >= 98 && i9 < 105)
												{
													x = 9;
												}
												else
												{
													x = 10;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				x = 10;
			}
		}
		void DecideNormalFrame()
		{
			int i = _mawHoverTime;
			if (i < 25)
			{
				x = 1;
			}
			else
			{
				int i2 = i;
				if (i2 >= 25 && i2 < 60)
				{
					x = 2;
				}
				else
				{
					int i3 = i;
					if (i3 >= 60 && i3 < 105)
					{
						x = 3;
					}
					else
					{
						int i4 = i;
						if (i4 >= 105 && i4 < 160)
						{
							x = 4;
						}
						else if (i >= 160)
						{
							x = 5;
						}
					}
				}
			}
		}
	}
}
