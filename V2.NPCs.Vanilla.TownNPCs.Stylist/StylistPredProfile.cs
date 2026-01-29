using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace V2.NPCs.Vanilla.TownNPCs.Stylist;

public class StylistPredProfile : ITownNPCProfile
{
	private readonly Asset<Texture2D> _defaultNoAlt;

	public StylistPredProfile()
	{
		if (!Main.dedServ)
		{
			string npcFileTitleFilePath = "V2/NPCs/Vanilla/TownNPCs/Stylist/Stylist_Default_WeightBase_BellyBase";
			_defaultNoAlt = ModContent.Request<Texture2D>(npcFileTitleFilePath, (AssetRequestMode)1);
		}
	}

	public int RollVariation()
	{
		return 0;
	}

	public string GetNameForVariant(NPC npc)
	{
		return "Amber";
	}

	public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
	{
		if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
		{
			return _defaultNoAlt;
		}
		string exactTextureToUse = "V2/NPCs/Vanilla/TownNPCs/Stylist/Stylist";
		string outfitString = "_Default";
		if (npc.IsShimmerVariant)
		{
			outfitString = "_Shimmer";
		}
		exactTextureToUse += outfitString;
		string weightString = "_WeightBase";
		exactTextureToUse += weightString;
		int bellySize = npc.AsPred().GetVisualBellySize(npc);
		string bellyString = "_Belly" + ((bellySize == 0) ? "Base" : ((object)bellySize));
		exactTextureToUse += bellyString;
		if (npc.altTexture == 1)
		{
			exactTextureToUse += "_Party";
		}
		return ModContent.Request<Texture2D>(exactTextureToUse, (AssetRequestMode)1);
	}

	public int GetHeadTextureIndex(NPC npc)
	{
		return 20;
	}
}
