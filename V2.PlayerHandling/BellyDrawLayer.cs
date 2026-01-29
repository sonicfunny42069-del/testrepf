using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using V2.Core;

namespace V2.PlayerHandling;

public class BellyDrawLayer : PlayerDrawLayer
{
	public abstract class BellyDrawer
	{
		public const string V2TumSpritesRoot = "V2/PlayerHandling/TumSprites/";

		public abstract DrawData BuildDrawData(ref PlayerDrawSet drawInfo, int size, int frame);

		public abstract bool ShouldDraw(ref PlayerDrawSet drawInfo, int size, int frame);

		public virtual void PreparePlayer(ref PlayerDrawSet drawInfo, int size, int frame)
		{
		}
	}

	public class RegularBelly : BellyDrawer
	{
		public static Vector2 BellyPosition;

		public static Rectangle SourceBare;

		public static readonly IReadOnlyList<TextureOffset> StandardBellies = new _003C_003Ez__ReadOnlyArray<TextureOffset>(new TextureOffset[20]
		{
			new TextureOffset(-1, 27),
			new TextureOffset(-1, 27),
			new TextureOffset(-1, 27),
			new TextureOffset(-1, 37),
			new TextureOffset(-1, 37),
			new TextureOffset(0, 37),
			new TextureOffset(0, 37),
			new TextureOffset(0, 37),
			new TextureOffset(0, 37),
			new TextureOffset(0, 37),
			new TextureOffset(-1, 37),
			new TextureOffset(-1, 37),
			new TextureOffset(-1, 35),
			new TextureOffset(-1, 35),
			new TextureOffset(-1, 35),
			new TextureOffset(-1, 35),
			new TextureOffset(-1, 35),
			new TextureOffset(-1, 25),
			new TextureOffset(-1, 25),
			new TextureOffset(-1, 25)
		});

		public static readonly IReadOnlyList<TextureOffset> BossBellies = new _003C_003Ez__ReadOnlySingleElementList<TextureOffset>(new TextureOffset(-1, 63));

		private const int MAX_FRAMES = 6;

		public static Vector2 getPositionAtFeetOfPlayer(ref PlayerDrawSet drawInfo)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			return Utils.Floor(((PlayerDrawSet)(ref drawInfo)).Center + Vector2.UnitY * (float)((Entity)drawInfo.drawPlayer).height / 2f) - Utils.Floor(Main.screenPosition);
		}

		public static Vector2 getPositionForTumRender(Vector2 feetPosition, ref PlayerDrawSet drawInfo, float offsetX, float offsetY, Texture2D sprite)
		{
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			feetPosition.X += offsetX * (float)((Entity)drawInfo.drawPlayer).direction;
			feetPosition.Y -= offsetY - 2f;
			feetPosition.X -= sprite.Width * ((((Entity)drawInfo.drawPlayer).direction == -1) ? 1 : 0);
			return feetPosition;
		}

		public override bool ShouldDraw(ref PlayerDrawSet drawInfo, int size, int frame)
		{
			if (size > 0)
			{
				return size <= StandardBellies.Count;
			}
			return false;
		}

		public override DrawData BuildDrawData(ref PlayerDrawSet drawInfo, int size, int frame)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			Player player = drawInfo.drawPlayer;
			if (player.AsPred().IsLayingOnTum)
			{
				return default(DrawData);
			}
			if (size >= 1 && size <= StandardBellies.Count)
			{
				TextureOffset tum = StandardBellies[size - 1];
				int offsetX = tum.xOffset * 2;
				int offsetY = tum.yOffset * 2;
				Vector2 tumLocation = getPositionAtFeetOfPlayer(ref drawInfo);
				Texture2D bareTum = RequestTexture("V2/PlayerHandling/TumSprites/" + $"Tum{size}/Bare");
				tumLocation = getPositionForTumRender(tumLocation, ref drawInfo, offsetX, offsetY, bareTum);
				if (frame == 3 || frame == 5)
				{
					tumLocation.Y -= 2f;
				}
				if (frame == 2)
				{
					tumLocation.Y -= player.sitting.offsetForSeat.Y - 4f;
				}
				if (player.mount.Active)
				{
					tumLocation.Y += player.mount.HeightBoost;
					frame = 1;
				}
				else if (player.portableStoolInfo.IsInUse)
				{
					frame = 1;
				}
				if (player.gravDir == -1f)
				{
					tumLocation.Y += 6f;
				}
				Rectangle sourceRectBare = default(Rectangle);
				((Rectangle)(ref sourceRectBare))._002Ector(0, frame * (bareTum.Height / 6), bareTum.Width, bareTum.Height / 6);
				DrawData result = new DrawData(bareTum, tumLocation, (Rectangle?)sourceRectBare, drawInfo.colorBodySkin, player.bodyRotation, Vector2.Zero, 1f, drawInfo.playerEffect, 0f);
				BellyPosition = tumLocation;
				SourceBare = sourceRectBare;
				return result;
			}
			return default(DrawData);
		}
	}

	public class TorsoClothedBelly : BellyDrawer
	{
		private static string GetTummyCoverFromEquips(Item item, int size)
		{
			string ValidArmor = "Bare";
			switch (item.type)
			{
			case 3479:
				ValidArmor = "WeddingDress";
				break;
			case 5068:
				ValidArmor = "FlinxFurCoat";
				if (size > 4)
				{
					ValidArmor = "Bare";
				}
				break;
			case 5078:
				ValidArmor = "PrinceUniform";
				if (size > 4)
				{
					ValidArmor = "Bare";
				}
				break;
			}
			return ValidArmor;
		}

		public override DrawData BuildDrawData(ref PlayerDrawSet drawInfo, int size, int frame)
		{
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			Player player = drawInfo.drawPlayer;
			string tumCover = null;
			if (!player.armor[11].IsAir && player.armor[11].type != 269)
			{
				tumCover = GetTummyCoverFromEquips(player.armor[11], size);
			}
			else if (!player.armor[2].IsAir && player.armor[2].type != 269)
			{
				tumCover = GetTummyCoverFromEquips(player.armor[2], size);
			}
			string filePath = "V2/PlayerHandling/TumSprites/" + $"Tum{size}/{tumCover}";
			if (ModContent.HasAsset(filePath))
			{
				Texture2D TumArmor = RequestTexture(filePath);
				DrawData clothingDraw = default(DrawData);
				((DrawData)(ref clothingDraw))._002Ector(TumArmor, RegularBelly.BellyPosition, (Rectangle?)RegularBelly.SourceBare, drawInfo.colorArmorBody, player.bodyRotation, Vector2.Zero, 1f, drawInfo.playerEffect, 0f);
				clothingDraw.shader = drawInfo.cBody;
				return clothingDraw;
			}
			return default(DrawData);
		}

		public override bool ShouldDraw(ref PlayerDrawSet drawInfo, int size, int frame)
		{
			if (size <= 0)
			{
				return false;
			}
			if (drawInfo.drawPlayer.AsPred().IsLayingOnTum)
			{
				return false;
			}
			Player player = drawInfo.drawPlayer;
			string tumCover = "Bare";
			if (!player.armor[11].IsAir && player.armor[11].type != 269)
			{
				tumCover = GetTummyCoverFromEquips(player.armor[11], size);
			}
			else if (!player.armor[2].IsAir && player.armor[2].type != 269)
			{
				tumCover = GetTummyCoverFromEquips(player.armor[2], size);
			}
			return tumCover != "Bare";
		}
	}

	public class LayingBelly : RegularBelly
	{
		public readonly struct LayingBellyConfiguration(int bellyHeight, int x, int y)
		{
			public int BellyHeight => bellyHeight;

			public int X => x;

			public int Y => y;
		}

		public static IDictionary<int, LayingBellyConfiguration> Configurations = new Dictionary<int, LayingBellyConfiguration> { 
		{
			19,
			new LayingBellyConfiguration(27, 26, 20)
		} };

		public static int RestingHeight;

		public static int OffsetHeight;

		public override bool ShouldDraw(ref PlayerDrawSet drawInfo, int size, int frame)
		{
			if (base.ShouldDraw(ref drawInfo, size, frame))
			{
				return drawInfo.drawPlayer.AsPred().IsLayingOnTum;
			}
			return false;
		}

		public override DrawData BuildDrawData(ref PlayerDrawSet drawInfo, int size, int frame)
		{
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			string layingBellyPath = "V2/PlayerHandling/TumSprites/" + $"Tum{size}/BareLaying";
			DrawData result = default(DrawData);
			if (ModContent.HasAsset(layingBellyPath) && Configurations.TryGetValue(size, out var config))
			{
				RestingHeight = config.BellyHeight * 2;
				OffsetHeight = config.Y * 2;
				Texture2D bellyTexture = ModContent.Request<Texture2D>(layingBellyPath, (AssetRequestMode)2).Value;
				Vector2 tumPosition = RegularBelly.getPositionAtFeetOfPlayer(ref drawInfo);
				float xOffset = (float)(-config.X) * 2f;
				float yOffset = 0f;
				tumPosition.Y -= (RestingHeight - OffsetHeight) * 2;
				tumPosition = RegularBelly.getPositionForTumRender(tumPosition, ref drawInfo, xOffset, yOffset, bellyTexture);
				tumPosition.X = (int)tumPosition.X - ((Entity)drawInfo.drawPlayer).direction;
				tumPosition.Y = (int)tumPosition.Y - 1;
				V2Utils.DebugPointMarker(tumPosition);
				((DrawData)(ref result))._002Ector(bellyTexture, tumPosition, drawInfo.colorBodySkin);
				result.effect = drawInfo.playerEffect;
				result.ignorePlayerRotation = true;
				return result;
			}
			result = default(DrawData);
			return result;
		}
	}

	public struct TextureOffset
	{
		public string TexturePath { get; }

		public int xOffset { get; }

		public int yOffset { get; }

		public TextureOffset(int x, int y)
		{
			TexturePath = string.Empty;
			xOffset = x;
			yOffset = y;
		}

		public TextureOffset(string tum, int x, int y)
		{
			TexturePath = tum;
			xOffset = x;
			yOffset = y;
		}
	}

	private static readonly IDictionary<string, Texture2D> TumSpritesCache = new Dictionary<string, Texture2D>();

	public static readonly List<BellyDrawer> BellyDrawers;

	private static Texture2D RequestTexture(string path)
	{
		if (TumSpritesCache.TryGetValue(path, out var result))
		{
			return result;
		}
		result = ModContent.Request<Texture2D>(path, (AssetRequestMode)1).Value;
		TumSpritesCache[path] = result;
		return result;
	}

	public override Position GetDefaultPosition()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		return (Position)new AfterParent(PlayerDrawLayers.Torso);
	}

	public static int GetKingSlimeDigestionStage(Player plr)
	{
		PreyData giantJelloDessert = plr.AsPred().StomachTracker?.Prey?.FirstOrDefault((PreyData x) => x.Type == PreyType.NPC && x.ExactType == 50);
		if (giantJelloDessert == null)
		{
			return 0;
		}
		if (!giantJelloDessert.NoHealth)
		{
			return 1;
		}
		if (giantJelloDessert.WeightLeftToDigest > 20.0)
		{
			return 1;
		}
		return 0;
	}

	private int getFrameForBelly(Player player)
	{
		int Frame = 0;
		switch (player.legFrame.Y / 56)
		{
		case 0:
			Frame = 0;
			break;
		case 5:
			Frame = 1;
			break;
		case 7:
		case 14:
			Frame = 3;
			break;
		case 8:
		case 9:
		case 15:
		case 16:
			Frame = 5;
			break;
		case 10:
		case 17:
			Frame = 4;
			break;
		}
		if ((player.ItemAnimationActive || player.inventory[player.selectedItem].holdStyle != 0) && Frame != 1)
		{
			Frame = 0;
		}
		if (player.sitting.isSitting)
		{
			Frame = 2;
		}
		else if (player.sleeping.isSleeping)
		{
			Frame = 1;
		}
		return Frame;
	}

	private static void DrawPlayerBelly(ref PlayerDrawSet drawInfo, int size, int frame)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		foreach (BellyDrawer bellyDrawer in BellyDrawers)
		{
			bellyDrawer.PreparePlayer(ref drawInfo, size, frame);
			if (bellyDrawer.ShouldDraw(ref drawInfo, size, frame))
			{
				DrawData draw = bellyDrawer.BuildDrawData(ref drawInfo, size, frame);
				if (draw.texture != null)
				{
					drawInfo.DrawDataCache.Add(draw);
				}
			}
		}
	}

	protected override void Draw(ref PlayerDrawSet drawInfo)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		if (!drawInfo.drawPlayer.isDisplayDollOrInanimate)
		{
			Player player = drawInfo.drawPlayer;
			int tumSize = player.AsPred().StomachSize;
			if (V2.GetFooled)
			{
				SpriteEffects val = ((((Entity)player).direction != -1) ? ((SpriteEffects)0) : ((SpriteEffects)1));
				SpriteEffects spriteEffects = val;
				double bellySize = player.AsPred().StomachFullness;
				bellySize /= PreyData.NewData((Entity)(object)player).InitialSize;
				Texture2D texture = ModContent.Request<Texture2D>("V2/AprilFools/BellyColorless", (AssetRequestMode)1).Value;
				DrawData tumDraw = default(DrawData);
				((DrawData)(ref tumDraw))._002Ector(texture, ((Entity)player).Center - Main.screenPosition + new Vector2(0f, player.gfxOffY) + new Vector2((((Entity)player).direction == 1) ? 6f : (-26f), 2f) * (float)bellySize + new Vector2(0f, 8f), (Rectangle?)texture.Bounds, drawInfo.colorBodySkin, player.bodyRotation, new Vector2(32f, 32f), (float)bellySize * 0.33f, spriteEffects, 0f);
				drawInfo.DrawDataCache.Add(tumDraw);
			}
			else if (GetKingSlimeDigestionStage(player) <= 0)
			{
				DrawPlayerBelly(ref drawInfo, tumSize, getFrameForBelly(player));
			}
		}
	}

	static BellyDrawLayer()
	{
		int num = 3;
		List<BellyDrawer> list = new List<BellyDrawer>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<BellyDrawer> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = new RegularBelly();
		num2++;
		span[num2] = new TorsoClothedBelly();
		num2++;
		span[num2] = new LayingBelly();
		num2++;
		BellyDrawers = list;
	}
}
