using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Gamepad;
using V2.NPCs;
using V2.PlayerHandling;

namespace V2.UI;

public static class UIOverrides
{
	public static void DrawInterface_21_HairWindow(NPC stylist)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_092f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Unknown result type (might be due to invalid IL or missing references)
		//IL_1061: Unknown result type (might be due to invalid IL or missing references)
		//IL_1067: Unknown result type (might be due to invalid IL or missing references)
		//IL_1094: Unknown result type (might be due to invalid IL or missing references)
		//IL_10aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1101: Unknown result type (might be due to invalid IL or missing references)
		//IL_1106: Unknown result type (might be due to invalid IL or missing references)
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1123: Unknown result type (might be due to invalid IL or missing references)
		//IL_1128: Unknown result type (might be due to invalid IL or missing references)
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1140: Unknown result type (might be due to invalid IL or missing references)
		//IL_114a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1156: Unknown result type (might be due to invalid IL or missing references)
		//IL_115c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f61: Unknown result type (might be due to invalid IL or missing references)
		if (!Main.hairWindow)
		{
			return;
		}
		if (Main.npcChatText != "" || Main.playerInventory || Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0 || Main.player[Main.myPlayer].talkNPC == -1 || Main.InGuideCraftMenu)
		{
			Main.CancelHairWindow();
			return;
		}
		FieldInfo grabColorSliderInfo = typeof(Main).GetField("grabColorSlider", BindingFlags.Instance | BindingFlags.NonPublic);
		Main.Hairstyles.UpdateUnlocks();
		int hairstyleCount = Main.Hairstyles.AvailableHairstyles.Count;
		int hairWindowYCoordA = Main.screenHeight / 2 + 60;
		int hairWindowXCoordA = Main.screenWidth / 2 - Utils.Width(TextureAssets.HairStyleBack) / 2;
		int hairWindowYCoordB = hairWindowYCoordA + 42;
		int hairWindowXCoordB = hairWindowXCoordA + 22;
		int hairWindowXCoordC = hairWindowXCoordA + 234;
		int hairWindowYCoordC = hairWindowYCoordA + 18;
		Main.selColor = Main.player[Main.myPlayer].hairColor;
		Main.spriteBatch.Draw(TextureAssets.HairStyleBack.Value, new Vector2((float)hairWindowXCoordA, (float)hairWindowYCoordA), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.HairStyleBack), Utils.Height(TextureAssets.HairStyleBack)), new Color(200, 200, 200, 200), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
		Rectangle val = new Rectangle(hairWindowXCoordA, hairWindowYCoordA, Utils.Width(TextureAssets.HairStyleBack), Utils.Height(TextureAssets.HairStyleBack));
		if (((Rectangle)(ref val)).Contains(Utils.ToPoint(Main.MouseScreen)))
		{
			int num7 = PlayerInput.ScrollWheelDelta / 120;
			num7 = -num7;
			int num8 = Math.Sign(num7);
			while (num7 != 0)
			{
				if (num7 < 0)
				{
					Main.hairStart -= 5;
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				else
				{
					Main.hairStart += 5;
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				num7 -= num8;
			}
		}
		if (Main.mouseX > hairWindowXCoordA && Main.mouseX < hairWindowXCoordA + Utils.Width(TextureAssets.HairStyleBack) && Main.mouseY > hairWindowYCoordA && Main.mouseY < hairWindowYCoordA + Utils.Height(TextureAssets.HairStyleBack))
		{
			Main.player[Main.myPlayer].mouseInterface = true;
		}
		int num9 = hairWindowXCoordC - 18;
		int num10 = hairWindowYCoordC + 74;
		if (Main.hairStart > 1)
		{
			if (Main.mouseX >= num9 && Main.mouseX <= num9 + Utils.Width(TextureAssets.CraftUpButton) && Main.mouseY >= num10 && Main.mouseY <= num10 + Utils.Height(TextureAssets.CraftUpButton))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
				if (Main.mouseLeftRelease && Main.mouseLeft)
				{
					Main.hairStart -= 15;
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
			}
			Main.spriteBatch.Draw(TextureAssets.ScrollLeftButton.Value, new Vector2((float)num9, (float)num10), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.CraftUpButton), Utils.Height(TextureAssets.CraftUpButton)), new Color(200, 200, 200, 200), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
		}
		if (Main.hairStart + 15 < hairstyleCount)
		{
			num9 += 296;
			if (Main.mouseX >= num9 && Main.mouseX <= num9 + Utils.Width(TextureAssets.CraftUpButton) && Main.mouseY >= num10 && Main.mouseY <= num10 + Utils.Height(TextureAssets.CraftUpButton))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
				if (Main.mouseLeftRelease && Main.mouseLeft)
				{
					Main.hairStart += 15;
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
			}
			Main.spriteBatch.Draw(TextureAssets.ScrollRightButton.Value, new Vector2((float)num9, (float)num10), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.CraftUpButton), Utils.Height(TextureAssets.CraftUpButton)), new Color(200, 200, 200, 200), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
		}
		if (Main.hairStart + 15 >= hairstyleCount)
		{
			Main.hairStart = hairstyleCount - 15;
		}
		if (Main.hairStart < 0)
		{
			Main.hairStart = 0;
		}
		int num17 = (Main.mouseTextColor * 2 + 255) / 3;
		Color color = new Color(num17, (int)((double)num17 / 1.1), num17 / 2, num17);
		int normalCutPrice = 0;
		int gutCutPrice = Item.buyPrice(0, 10, 0, 0);
		int savingsLocationX = hairWindowXCoordA + 18;
		int savingsLocationY = hairWindowYCoordA + 86;
		DrawNormalCutOption();
		DrawCancelOption();
		DrawGutCutOption();
		if (Main.mouseLeft && Main.mouseLeftRelease)
		{
			if (Main.npcChatFocus1)
			{
				if (Main.player[Main.myPlayer].BuyItem((long)normalCutPrice, -1))
				{
					Main.BuyHairWindow();
					return;
				}
			}
			else
			{
				if (Main.npcChatFocus2)
				{
					Main.CancelHairWindow();
					return;
				}
				if (Main.npcChatFocus3)
				{
					if (PredNPC.CanSwallow(stylist, (Entity)(object)Main.LocalPlayer))
					{
						if (Main.player[Main.myPlayer].BuyItem((long)gutCutPrice, -1))
						{
							SoundEngine.PlaySound(ref SoundID.Coins, (Vector2?)null, (SoundUpdateCallback)null);
							PredNPC.SwallowWithTextIfApplicable(stylist, Main.LocalPlayer, "Sure thing, hun! One Gut Cut experience, comin' right up! I hope you enjoy your new acid-worn look!\n[c/7F7F7F:<After preparing for a moment and giving you a friendly smile, " + stylist.GivenName + " steadily guides you down her throat, headfirst. She gives a pleasant hum as you settle into her stomach, the acids getting to work on your scalp.>]\nDe~licious! Now, just tell me when you're satisfied with your Gut Cut, and remember: I run a STRICT no-refunds policy for these!");
						}
						else
						{
							PredNPC.SetChatboxText(stylist, Main.LocalPlayer, "Sorry, hun, but you don't seem to have enough on you right now. I can't just give out the Gut Cut experience for free, y'know!");
						}
					}
					else
					{
						PredNPC.SetChatboxText(stylist, Main.LocalPlayer, "Sorry, hun, but I just don't have enough room right now. Tell you what, though; come back later, and I'll have a snazzy new acid-worn cut with your name on it!");
					}
				}
			}
		}
		if (!Main.mouseLeft)
		{
			SetGrabColorSlider(0);
			Main.blockMouse = false;
		}
		int num24 = 167;
		Vector3 val2 = Main.rgbToHsl(Main.selColor);
		float num25 = val2.X;
		float num26 = val2.Y;
		float z = val2.Z;
		float num27 = (float)(int)((Color)(ref Main.selColor)).A / 255f;
		if (Main.hBar == -1f || Main.sBar == -1f || Main.lBar == -1f || Main.aBar == -1f)
		{
			Main.hBar = num25;
			Main.sBar = num26;
			Main.lBar = z;
			Main.aBar = (float)(int)((Color)(ref Main.selColor)).A / 255f;
		}
		else
		{
			num25 = Main.hBar;
			num26 = Main.sBar;
			z = Main.lBar;
			Main.aBar = num27;
		}
		UILinkPointNavigator.SetPosition(2600, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB) + Utils.Size(TextureAssets.Hue.Value) / 2f);
		Main.spriteBatch.Draw(TextureAssets.Hue.Value, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB), Color.White);
		if ((Main.mouseX > hairWindowXCoordB - 4 && Main.mouseX < hairWindowXCoordB + Utils.Width(TextureAssets.Hue) + 4 && Main.mouseY > hairWindowYCoordB - 4 && Main.mouseY < hairWindowYCoordB + Utils.Height(TextureAssets.Hue) + 4) || GetGrabColorSlider() == 1)
		{
			Main.spriteBatch.Draw(TextureAssets.ColorHighlight.Value, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB), Main.OurFavoriteColor);
		}
		Main.spriteBatch.Draw(TextureAssets.ColorSlider.Value, new Vector2((float)hairWindowXCoordB + (float)(Utils.Width(TextureAssets.Hue) - 2) * Main.hBar - (float)(Utils.Width(TextureAssets.ColorSlider) / 2), (float)(hairWindowYCoordB - Utils.Height(TextureAssets.ColorSlider) / 2 + Utils.Height(TextureAssets.Hue) / 2)), Color.White);
		if (((Main.mouseX > hairWindowXCoordB - 4 && Main.mouseX < hairWindowXCoordB + Utils.Width(TextureAssets.Hue) + 4 && Main.mouseY > hairWindowYCoordB - 4 && Main.mouseY < hairWindowYCoordB + Utils.Height(TextureAssets.Hue) + 4) || GetGrabColorSlider() == 1) && Main.mouseLeft && !Main.blockMouse)
		{
			SetGrabColorSlider(1);
			num25 = Main.mouseX - hairWindowXCoordB;
			num25 /= (float)Utils.Width(TextureAssets.Hue);
			if (num25 < 0f)
			{
				num25 = 0f;
			}
			if (num25 > 1f)
			{
				num25 = 1f;
			}
			Main.hBar = num25;
		}
		hairWindowYCoordB += 26;
		UILinkPointNavigator.SetPosition(2601, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB) + Utils.Size(TextureAssets.ColorBar.Value) / 2f);
		Main.spriteBatch.Draw(TextureAssets.ColorBar.Value, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB), Color.White);
		for (int k = 0; k <= num24; k++)
		{
			float saturation = (float)k / (float)num24;
			Color color4 = Main.hslToRgb(num25, saturation, z, byte.MaxValue);
			Main.spriteBatch.Draw(TextureAssets.ColorBlip.Value, new Vector2((float)(hairWindowXCoordB + k + 5), (float)(hairWindowYCoordB + 4)), color4);
		}
		if ((Main.mouseX > hairWindowXCoordB - 4 && Main.mouseX < hairWindowXCoordB + Utils.Width(TextureAssets.Hue) + 4 && Main.mouseY > hairWindowYCoordB - 4 && Main.mouseY < hairWindowYCoordB + Utils.Height(TextureAssets.Hue) + 4) || GetGrabColorSlider() == 2)
		{
			Main.spriteBatch.Draw(TextureAssets.ColorHighlight.Value, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB), Main.OurFavoriteColor);
		}
		Main.spriteBatch.Draw(TextureAssets.ColorSlider.Value, new Vector2((float)hairWindowXCoordB + (float)(Utils.Width(TextureAssets.Hue) - 2) * Main.sBar - (float)(Utils.Width(TextureAssets.ColorSlider) / 2), (float)(hairWindowYCoordB - Utils.Height(TextureAssets.ColorSlider) / 2 + Utils.Height(TextureAssets.Hue) / 2)), Color.White);
		if (((Main.mouseX > hairWindowXCoordB - 4 && Main.mouseX < hairWindowXCoordB + Utils.Width(TextureAssets.Hue) + 4 && Main.mouseY > hairWindowYCoordB - 4 && Main.mouseY < hairWindowYCoordB + Utils.Height(TextureAssets.Hue) + 4) || GetGrabColorSlider() == 2) && Main.mouseLeft && !Main.blockMouse)
		{
			SetGrabColorSlider(2);
			num26 = Main.mouseX - hairWindowXCoordB;
			num26 /= (float)Utils.Width(TextureAssets.Hue);
			if (num26 < 0f)
			{
				num26 = 0f;
			}
			if (num26 > 1f)
			{
				num26 = 1f;
			}
			Main.sBar = num26;
		}
		hairWindowYCoordB += 26;
		UILinkPointNavigator.SetPosition(2602, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB) + Utils.Size(TextureAssets.ColorBar.Value) / 2f);
		Main.spriteBatch.Draw(TextureAssets.ColorBar.Value, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB), Color.White);
		float num28 = 0.15f;
		for (int l = 0; l <= num24; l++)
		{
			float luminosity = (float)l / (float)num24;
			Color color5 = Main.hslToRgb(num25, num26, luminosity, byte.MaxValue);
			Main.spriteBatch.Draw(TextureAssets.ColorBlip.Value, new Vector2((float)(hairWindowXCoordB + l + 5), (float)(hairWindowYCoordB + 4)), color5);
		}
		if ((Main.mouseX > hairWindowXCoordB - 4 && Main.mouseX < hairWindowXCoordB + Utils.Width(TextureAssets.Hue) + 4 && Main.mouseY > hairWindowYCoordB - 4 && Main.mouseY < hairWindowYCoordB + Utils.Height(TextureAssets.Hue) + 4) || GetGrabColorSlider() == 3)
		{
			Main.spriteBatch.Draw(TextureAssets.ColorHighlight.Value, new Vector2((float)hairWindowXCoordB, (float)hairWindowYCoordB), Main.OurFavoriteColor);
		}
		Main.spriteBatch.Draw(TextureAssets.ColorSlider.Value, new Vector2((float)hairWindowXCoordB + (float)(Utils.Width(TextureAssets.Hue) - 2) * ((Main.lBar - num28) / (1f - num28)) - (float)(Utils.Width(TextureAssets.ColorSlider) / 2), (float)(hairWindowYCoordB - Utils.Height(TextureAssets.ColorSlider) / 2 + Utils.Height(TextureAssets.Hue) / 2)), Color.White);
		if (((Main.mouseX > hairWindowXCoordB - 4 && Main.mouseX < hairWindowXCoordB + Utils.Width(TextureAssets.Hue) + 4 && Main.mouseY > hairWindowYCoordB - 4 && Main.mouseY < hairWindowYCoordB + Utils.Height(TextureAssets.Hue) + 4) || GetGrabColorSlider() == 3) && Main.mouseLeft && !Main.blockMouse)
		{
			SetGrabColorSlider(3);
			z = Main.mouseX - hairWindowXCoordB;
			z /= (float)Utils.Width(TextureAssets.Hue);
			if (z < 0f)
			{
				z = 0f;
			}
			if (z > 1f)
			{
				z = 1f;
			}
			z = (Main.lBar = z * (1f - num28) + num28);
		}
		Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar, byte.MaxValue);
		Main.player[Main.myPlayer].hairColor = Main.selColor;
		int num29 = hairWindowXCoordC;
		int num30 = hairWindowYCoordC;
		_ = Main.hairStart;
		int num31 = 0;
		int num32 = 0;
		for (int m = 0; m < 15; m++)
		{
			int num33 = Main.Hairstyles.AvailableHairstyles[Main.hairStart + m];
			UILinkPointNavigator.SetPosition(2605 + m, new Vector2((float)num29, (float)num30) + Utils.Size(TextureAssets.InventoryBack.Value) * 0.75f);
			if (Main.player[Main.myPlayer].hair == num33)
			{
				Main.spriteBatch.Draw(TextureAssets.InventoryBack14.Value, new Vector2((float)num29, (float)num30), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.InventoryBack), Utils.Height(TextureAssets.InventoryBack)), new Color(200, 200, 200, 200), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
			}
			else
			{
				Main.spriteBatch.Draw(TextureAssets.InventoryBack8.Value, new Vector2((float)num29, (float)num30), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.InventoryBack), Utils.Height(TextureAssets.InventoryBack)), new Color(200, 200, 200, 200), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
			}
			if (Main.mouseX > num29 && Main.mouseX < num29 + Utils.Width(TextureAssets.InventoryBack) && Main.mouseY > num30 && Main.mouseY < num30 + Utils.Height(TextureAssets.InventoryBack))
			{
				Asset<Texture2D> asset = Main.Assets.Request<Texture2D>("Images/UI/PanelBorder", (AssetRequestMode)2);
				Utils.DrawSplicedPanel(Main.spriteBatch, asset.Value, num29, num30, Utils.Width(TextureAssets.InventoryBack), Utils.Height(TextureAssets.InventoryBack), Utils.Width(asset) / 2 - 1, Utils.Width(asset) / 2 - 1, Utils.Height(asset) / 2 - 1, Utils.Height(asset) / 2 - 1, Main.OurFavoriteColor);
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					Main.mouseLeftRelease = false;
					Main.player[Main.myPlayer].hair = num33;
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
			}
			Main.instance.LoadHair(num33);
			float x = num29 + Utils.Width(TextureAssets.InventoryBack) / 2 - Utils.Width(TextureAssets.PlayerHair[num33]) / 2;
			float y = num30 + 4;
			Main.spriteBatch.Draw(TextureAssets.Players[num31, 0].Value, new Vector2(x, y), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.PlayerHair[num33]), 56), Main.player[Main.myPlayer].skinColor, 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
			Main.spriteBatch.Draw(TextureAssets.Players[num31, 1].Value, new Vector2(x, y), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.PlayerHair[num33]), 56), new Color(255, 255, 255, 255), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
			Main.spriteBatch.Draw(TextureAssets.Players[num31, 2].Value, new Vector2(x, y), (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.PlayerHair[num33]), 56), Main.player[Main.myPlayer].eyeColor, 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
			Vector2 value = Main.player[Main.myPlayer].GetHairDrawOffset(num33, false) * Main.player[Main.myPlayer].Directions;
			Main.spriteBatch.Draw(TextureAssets.PlayerHair[num33].Value, new Vector2(x, y) + value, (Rectangle?)new Rectangle(0, 0, Utils.Width(TextureAssets.PlayerHair[num33]), 56), Main.selColor, 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
			num32++;
			num29 += 56;
			if (num32 >= 5)
			{
				num32 = 0;
				num29 = hairWindowXCoordC;
				num30 += 56;
			}
		}
		void DrawCancelOption()
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			float scale = 0.9f;
			string cancelText = Language.GetTextValue("GameUI.Cancel");
			int num34 = hairWindowXCoordA + 148;
			int num35 = hairWindowYCoordA + 156;
			bool flag = false;
			if (Main.mouseX > num34 && (float)Main.mouseX < (float)num34 + FontAssets.MouseText.Value.MeasureString(cancelText).X && Main.mouseY > num35 && (float)Main.mouseY < (float)num35 + FontAssets.MouseText.Value.MeasureString(cancelText).Y)
			{
				flag = true;
				scale = 1.1f;
				if (!Main.npcChatFocus2)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				Main.npcChatFocus2 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus2)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				Main.npcChatFocus2 = false;
			}
			Vector2 cancelVector = FontAssets.MouseText.Value.MeasureString(cancelText);
			cancelVector *= 0.5f;
			UILinkPointNavigator.SetPosition(2604, new Vector2((float)num34, (float)num35) + cancelVector);
			for (int j = 0; j < 5; j++)
			{
				int num36 = num34;
				int num37 = num35;
				Color color6 = Color.Black;
				if (flag)
				{
					color6 = Color.Brown;
				}
				if (j == 0)
				{
					num36 -= 2;
				}
				if (j == 1)
				{
					num36 += 2;
				}
				if (j == 2)
				{
					num37 -= 2;
				}
				if (j == 3)
				{
					num37 += 2;
				}
				if (j == 4)
				{
					color6 = color;
				}
				DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, cancelText, new Vector2((float)num36 + cancelVector.X, (float)num37 + cancelVector.Y), color6, 0f, cancelVector, scale, (SpriteEffects)0, 0f);
			}
		}
		void DrawGutCutOption()
		{
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03df: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03be: Unknown result type (might be due to invalid IL or missing references)
			gutCutPrice = (int)((double)gutCutPrice * Main.player[Main.myPlayer].currentShoppingSettings.PriceAdjustment);
			gutCutPrice = (int)Math.Round((float)gutCutPrice / 100000f) * 100000;
			string gutCutText = "";
			string gutCutTextCopy = "";
			int gutCutPlatinum = 0;
			int gutCutGold = 0;
			int gutCutSilver = 0;
			int gutCutCopper = 0;
			int gutCutPriceLeft = gutCutPrice;
			if (gutCutPriceLeft < 0)
			{
				gutCutPriceLeft = 0;
			}
			gutCutPrice = gutCutPriceLeft;
			if (gutCutPriceLeft >= 1000000)
			{
				gutCutPlatinum = gutCutPriceLeft / 1000000;
				gutCutPriceLeft -= gutCutPlatinum * 1000000;
			}
			if (gutCutPriceLeft >= 10000)
			{
				gutCutGold = gutCutPriceLeft / 10000;
				gutCutPriceLeft -= gutCutGold * 10000;
			}
			if (gutCutPriceLeft >= 100)
			{
				gutCutSilver = gutCutPriceLeft / 100;
				gutCutPriceLeft -= gutCutSilver * 100;
			}
			if (gutCutPriceLeft >= 1)
			{
				gutCutCopper = gutCutPriceLeft;
			}
			if (gutCutPlatinum > 0)
			{
				gutCutTextCopy = gutCutTextCopy + gutCutPlatinum + " " + Lang.inter[15].Value + " ";
			}
			if (gutCutGold > 0)
			{
				gutCutTextCopy = gutCutTextCopy + gutCutGold + " " + Lang.inter[16].Value + " ";
			}
			if (gutCutSilver > 0)
			{
				gutCutTextCopy = gutCutTextCopy + gutCutSilver + " " + Lang.inter[17].Value + " ";
			}
			if (gutCutCopper > 0)
			{
				gutCutTextCopy = gutCutTextCopy + gutCutCopper + " " + Lang.inter[18].Value + " ";
			}
			gutCutText = Language.GetTextValueWith("Mods.V2.Menu.MiscVanilla.HairWindowGutCut", (object)new
			{
				Price = gutCutTextCopy
			});
			if (gutCutPrice == 0)
			{
				gutCutText = Language.GetTextValue("Mods.V2.Menu.MiscVanilla.HairWindowGutCutFree");
			}
			int num17V = (Main.mouseTextColor * 2 + 255) / 3;
			Color colorV = default(Color);
			((Color)(ref colorV))._002Ector(num17, (int)((double)num17V / 1.1), num17V / 2, num17V);
			float scaleV = 0.9f;
			string gutCutText3 = gutCutText;
			int gutCutLocationX = hairWindowXCoordA + ((gutCutPrice > 0) ? 40 : 70);
			int gutCutLocationY = hairWindowYCoordA + 16;
			bool flagV = false;
			if (normalCutPrice == 0 && gutCutPrice > 0)
			{
				ItemSlot.DrawSavings(Main.spriteBatch, (float)savingsLocationX, (float)savingsLocationY, true);
			}
			if (Main.mouseX > gutCutLocationX && (float)Main.mouseX < (float)gutCutLocationX + FontAssets.MouseText.Value.MeasureString(gutCutText3).X && Main.mouseY > gutCutLocationY && (float)Main.mouseY < (float)gutCutLocationY + FontAssets.MouseText.Value.MeasureString(gutCutText3).Y)
			{
				flagV = true;
				scaleV = 1.1f;
				if (!Main.npcChatFocus3)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				Main.npcChatFocus3 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus3)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				Main.npcChatFocus3 = false;
			}
			Vector2 gutCutVector = FontAssets.MouseText.Value.MeasureString(gutCutText3);
			gutCutVector *= 0.5f;
			for (int i = 0; i < 5; i++)
			{
				int num34 = gutCutLocationX;
				int num35 = gutCutLocationY;
				Color color6 = Color.Black;
				if (flagV)
				{
					color6 = Color.Brown;
				}
				if (i == 0)
				{
					num34 -= 2;
				}
				if (i == 1)
				{
					num34 += 2;
				}
				if (i == 2)
				{
					num35 -= 2;
				}
				if (i == 3)
				{
					num35 += 2;
				}
				if (i == 4)
				{
					color6 = (Color)((gutCutPrice != 0) ? colorV : new Color(100, 100, 100));
				}
				DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, gutCutText3, new Vector2((float)num34 + gutCutVector.X, (float)num35 + gutCutVector.Y), color6, 0f, gutCutVector, scaleV, (SpriteEffects)0, 0f);
			}
		}
		void DrawNormalCutOption()
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Unknown result type (might be due to invalid IL or missing references)
			//IL_030d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			//IL_0405: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0480: Unknown result type (might be due to invalid IL or missing references)
			//IL_0487: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0445: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			if ((int)typeof(Main).GetField("oldHairStyle", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) != Main.player[Main.myPlayer].hair)
			{
				normalCutPrice = ((Main.player[Main.myPlayer].hair <= 51) ? (normalCutPrice + 20000) : (normalCutPrice + 200000));
			}
			if ((Color)typeof(Main).GetField("oldHairColor", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) != Main.player[Main.myPlayer].hairColor)
			{
				normalCutPrice += 20000;
			}
			normalCutPrice = (int)((double)normalCutPrice * Main.player[Main.myPlayer].currentShoppingSettings.PriceAdjustment);
			normalCutPrice = (int)Math.Round((float)normalCutPrice / 10000f) * 10000;
			string normalCutText = "";
			string normalCutTextCopy = "";
			int normalCutPlatinum = 0;
			int normalCutGold = 0;
			int normalCutSilver = 0;
			int normalCutCopper = 0;
			int normalCutPriceLeft = normalCutPrice;
			if (normalCutPriceLeft < 0)
			{
				normalCutPriceLeft = 0;
			}
			normalCutPrice = normalCutPriceLeft;
			if (normalCutPriceLeft >= 1000000)
			{
				normalCutPlatinum = normalCutPriceLeft / 1000000;
				normalCutPriceLeft -= normalCutPlatinum * 1000000;
			}
			if (normalCutPriceLeft >= 10000)
			{
				normalCutGold = normalCutPriceLeft / 10000;
				normalCutPriceLeft -= normalCutGold * 10000;
			}
			if (normalCutPriceLeft >= 100)
			{
				normalCutSilver = normalCutPriceLeft / 100;
				normalCutPriceLeft -= normalCutSilver * 100;
			}
			if (normalCutPriceLeft >= 1)
			{
				normalCutCopper = normalCutPriceLeft;
			}
			if (normalCutPlatinum > 0)
			{
				normalCutTextCopy = normalCutTextCopy + normalCutPlatinum + " " + Lang.inter[15].Value + " ";
			}
			if (normalCutGold > 0)
			{
				normalCutTextCopy = normalCutTextCopy + normalCutGold + " " + Lang.inter[16].Value + " ";
			}
			if (normalCutSilver > 0)
			{
				normalCutTextCopy = normalCutTextCopy + normalCutSilver + " " + Lang.inter[17].Value + " ";
			}
			if (normalCutCopper > 0)
			{
				normalCutTextCopy = normalCutTextCopy + normalCutCopper + " " + Lang.inter[18].Value + " ";
			}
			normalCutText = Language.GetTextValue("GameUI.BuyWithValue", (object)normalCutTextCopy);
			if (normalCutPrice == 0)
			{
				normalCutText = Language.GetTextValue("GameUI.Buy");
			}
			float scale = 0.9f;
			string text3 = normalCutText;
			int normalCutLocationX = hairWindowXCoordA + 18;
			int normalCutLocationY = hairWindowYCoordA + 156;
			bool flag = false;
			if (normalCutPrice > 0)
			{
				ItemSlot.DrawSavings(Main.spriteBatch, (float)savingsLocationX, (float)savingsLocationY, true);
			}
			if (normalCutPrice > 0 && Main.mouseX > normalCutLocationX && (float)Main.mouseX < (float)normalCutLocationX + FontAssets.MouseText.Value.MeasureString(text3).X && Main.mouseY > normalCutLocationY && (float)Main.mouseY < (float)normalCutLocationY + FontAssets.MouseText.Value.MeasureString(text3).Y)
			{
				flag = true;
				scale = 1.1f;
				if (!Main.npcChatFocus1)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				Main.npcChatFocus1 = true;
				Main.player[Main.myPlayer].releaseUseItem = false;
			}
			else
			{
				if (Main.npcChatFocus1)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
				}
				Main.npcChatFocus1 = false;
			}
			Vector2 vector = FontAssets.MouseText.Value.MeasureString(text3);
			vector *= 0.5f;
			UILinkPointNavigator.SetPosition(2603, new Vector2((float)normalCutLocationX, (float)normalCutLocationY) + vector);
			for (int i = 0; i < 5; i++)
			{
				int num34 = normalCutLocationX;
				int num35 = normalCutLocationY;
				Color color6 = Color.Black;
				if (flag)
				{
					color6 = Color.Brown;
				}
				if (i == 0)
				{
					num34 -= 2;
				}
				if (i == 1)
				{
					num34 += 2;
				}
				if (i == 2)
				{
					num35 -= 2;
				}
				if (i == 3)
				{
					num35 += 2;
				}
				if (i == 4)
				{
					color6 = (Color)((normalCutPrice != 0) ? color : new Color(100, 100, 100));
				}
				DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, text3, new Vector2((float)num34 + vector.X, (float)num35 + vector.Y), color6, 0f, vector, scale, (SpriteEffects)0, 0f);
			}
		}
		int GetGrabColorSlider()
		{
			return (int)grabColorSliderInfo.GetValue(Main.instance);
		}
		void SetGrabColorSlider(int num34)
		{
			grabColorSliderInfo.SetValue(Main.instance, num34);
		}
	}

	public static void DrawInterface_35_YouDied()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		Player player = Main.player[Main.myPlayer];
		if (!player.dead)
		{
			return;
		}
		float yOffsetFromScreenCenter = -60f;
		string value = Lang.inter[38].Value;
		if (player.AsFood().Digested)
		{
			if (ModContent.GetInstance<V2ClientConfig>().TheGutSlutVisionOMatic)
			{
				yOffsetFromScreenCenter -= (float)Main.screenHeight * 0.3f;
			}
			value = Language.GetTextValue("Mods.V2.Death.DigestedPlayer.YouWereEaten");
		}
		DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.DeathText.Value, value, new Vector2((float)(Main.screenWidth / 2) - FontAssets.DeathText.Value.MeasureString(value).X / 2f, (float)(Main.screenHeight / 2) + yOffsetFromScreenCenter), player.GetDeathAlpha(Color.Transparent), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
		if (player.lostCoins > 0)
		{
			yOffsetFromScreenCenter += 50f;
			string textValue = Language.GetTextValue("Game.DroppedCoins", (object)player.lostCoinString);
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.MouseText.Value, textValue, new Vector2((float)(Main.screenWidth / 2) - FontAssets.MouseText.Value.MeasureString(textValue).X / 2f, (float)(Main.screenHeight / 2) + yOffsetFromScreenCenter), player.GetDeathAlpha(Color.Transparent), 0f, default(Vector2), 1f, (SpriteEffects)0, 0f);
		}
		yOffsetFromScreenCenter += (float)((player.lostCoins > 0) ? 24 : 50);
		yOffsetFromScreenCenter += 20f;
		float respawnCountdownScale = 0.7f;
		string textValue2 = Language.GetTextValue("Game.RespawnInSuffix", (object)((float)(int)(1f + (float)player.respawnTimer / 60f)).ToString());
		if (player.AsFood().Digested && ModContent.GetInstance<V2ClientConfig>().TheGutSlutVisionOMatic)
		{
			yOffsetFromScreenCenter += (float)Main.screenHeight * 0.5f;
			respawnCountdownScale = 0.5f;
			textValue2 = Language.GetTextValueWith("Mods.V2.Death.DigestedPlayer.ManualRespawn", (object)new
			{
				ManualRespawnButton = V2.RespawnAfterDigestionHotkey.GetAssignedKeys((InputMode)0)[0]
			});
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.DeathText.Value, textValue2, new Vector2((float)(Main.screenWidth / 2) - FontAssets.MouseText.Value.MeasureString(textValue2).X * respawnCountdownScale * 1.3333f, (float)(Main.screenHeight / 2) + yOffsetFromScreenCenter), player.GetDeathAlpha(Color.Transparent), 0f, default(Vector2), respawnCountdownScale, (SpriteEffects)0, 0f);
		}
		else
		{
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, FontAssets.DeathText.Value, textValue2, new Vector2((float)(Main.screenWidth / 2) - FontAssets.MouseText.Value.MeasureString(textValue2).X * respawnCountdownScale / 2f, (float)(Main.screenHeight / 2) + yOffsetFromScreenCenter), player.GetDeathAlpha(Color.Transparent), 0f, default(Vector2), respawnCountdownScale, (SpriteEffects)0, 0f);
		}
	}
}
