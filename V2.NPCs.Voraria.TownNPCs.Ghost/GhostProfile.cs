using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace V2.NPCs.Voraria.TownNPCs.Ghost;

public class GhostProfile : ITownNPCProfile
{
	private Asset<Texture2D> _defaultNoAlt;

	public int frameDelay = 8;

	public int frameWait;

	public int currentFrame;

	public GhostProfile()
	{
		if (!Main.dedServ)
		{
			string npcFileTitleFilePath = "V2/NPCs/Voraria/TownNPCs/Ghost/Echo_Weight0";
			_defaultNoAlt = ModContent.Request<Texture2D>(npcFileTitleFilePath, (AssetRequestMode)1);
		}
	}

	public int RollVariation()
	{
		return 0;
	}

	public string GetNameForVariant(NPC npc)
	{
		return "Echo";
	}

	public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
	{
		if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
		{
			return _defaultNoAlt;
		}
		return ModContent.Request<Texture2D>("V2/NPCs/Voraria/TownNPCs/Ghost/Echo_Weight0", (AssetRequestMode)2);
	}

	public int GetHeadTextureIndex(NPC npc)
	{
		return ModContent.GetModHeadSlot("V2/NPCs/Voraria/TownNPCs/Ghost/Echo_Head");
	}
}
