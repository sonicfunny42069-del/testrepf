using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using V2.Core;

namespace V2.UI;

public class DigestingBossHealthBar : GlobalBossBar
{
	public override bool PreDraw(SpriteBatch spriteBatch, NPC npc, ref BossBarDrawParams drawParams)
	{
		if (((Entity)(object)npc).CurrentCaptor() != null)
		{
			drawParams.BarTexture = ModContent.Request<Texture2D>("V2/UI/DigestingBossHealthBar", (AssetRequestMode)1).Value;
		}
		return true;
	}
}
