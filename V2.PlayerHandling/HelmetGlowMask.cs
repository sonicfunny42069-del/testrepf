using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using V2.Items.Voraria.Armor;

namespace V2.PlayerHandling;

public class HelmetGlowMask : PlayerDrawLayer
{
	public override Position GetDefaultPosition()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		return (Position)new AfterParent(PlayerDrawLayers.Head);
	}

	protected override void Draw(ref PlayerDrawSet drawInfo)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		Player drawPlayer = drawInfo.drawPlayer;
		if (!drawInfo.drawPlayer.dead)
		{
			DrawData val = default(DrawData);
			if (drawPlayer.armor[10].type == ModContent.ItemType<MushroomHairpin>() || (drawPlayer.armor[10].type == 0 && drawPlayer.armor[0].type == ModContent.ItemType<MushroomHairpin>()))
			{
				Color color = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
				Texture2D texture = ModContent.Request<Texture2D>("V2/Items/Voraria/Armor/MushroomHairpin_Head_Glow", (AssetRequestMode)2).Value;
				Vector2 drawPos = drawInfo.Position - Main.screenPosition + new Vector2((float)(((Entity)drawPlayer).width / 2 - drawPlayer.bodyFrame.Width / 2), (float)(((Entity)drawPlayer).height - drawPlayer.bodyFrame.Height) + 4f) + drawPlayer.headPosition;
				Vector2 headVect = drawInfo.headVect;
				((DrawData)(ref val))._002Ector(texture, Utils.Floor(drawPos) + headVect, (Rectangle?)drawPlayer.bodyFrame, color, drawPlayer.headRotation, headVect, 1f, drawInfo.playerEffect, 0f);
				val.shader = drawInfo.cHead;
				DrawData drawData = val;
				drawInfo.DrawDataCache.Add(drawData);
			}
			else if (drawPlayer.armor[10].type == ModContent.ItemType<ShroomiteHairpin>() || (drawPlayer.armor[10].type == 0 && drawPlayer.armor[0].type == ModContent.ItemType<ShroomiteHairpin>()))
			{
				Color color2 = drawPlayer.GetImmuneAlphaPure(Color.White, drawInfo.shadow);
				Texture2D texture2 = ModContent.Request<Texture2D>("V2/Items/Voraria/Armor/ShroomiteHairpin_Head_Glow", (AssetRequestMode)2).Value;
				Vector2 drawPos2 = drawInfo.Position - Main.screenPosition + new Vector2((float)(((Entity)drawPlayer).width / 2 - drawPlayer.bodyFrame.Width / 2), (float)(((Entity)drawPlayer).height - drawPlayer.bodyFrame.Height) + 4f) + drawPlayer.headPosition;
				Vector2 headVect2 = drawInfo.headVect;
				((DrawData)(ref val))._002Ector(texture2, Utils.Floor(drawPos2) + headVect2, (Rectangle?)drawPlayer.bodyFrame, color2, drawPlayer.headRotation, headVect2, 1f, drawInfo.playerEffect, 0f);
				val.shader = drawInfo.cHead;
				DrawData drawData2 = val;
				drawInfo.DrawDataCache.Add(drawData2);
			}
		}
	}
}
