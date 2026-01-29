using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using V2.Core;
using V2.PlayerHandling;

namespace V2.Items.Voraria.Accessories.Vanity;

public class BalloonBelly : ModItem
{
	public static SoundStyle InflationSound => new SoundStyle("V2/Sounds/Item/BalloonBellyInflate", (SoundType)0);

	public static SoundStyle DeflationSound => new SoundStyle("V2/Sounds/Item/BalloonBellyDeflate", (SoundType)0);

	public static int MaximumInflatedSize => 5;

	public int InflatedSize { get; set; }

	public Color SkinColor { get; set; }

	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Accessories.Vanity.BalloonBelly");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Accessories.Vanity.BalloonBelly.Short");

	public override string Texture => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size0";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetDefaults()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		((ModItem)this).Item.accessory = true;
		((ModItem)this).Item.useStyle = 1;
		((ModItem)this).Item.vanity = true;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 3;
		((ModItem)this).Item.value = Item.buyPrice(0, 5, 0, 0);
		InflatedSize = 0;
		SkinColor = Color.White;
	}

	public override ModItem Clone(Item newEntity)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		BalloonBelly obj = newEntity.ModItem as BalloonBelly;
		obj.InflatedSize = InflatedSize;
		obj.SkinColor = SkinColor;
		return ((ModType<Item, ModItem>)this).Clone(newEntity);
	}

	public override Color? GetAlpha(Color lightColor)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return SkinColor;
	}

	public override bool AltFunctionUse(Player player)
	{
		return true;
	}

	public override void Update(ref float gravity, ref float maxFallSpeed)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		SkinColor = Color.White;
	}

	public override void UpdateInventory(Player player)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		SkinColor = player.skinColor;
	}

	public override bool CanUseItem(Player player)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle val;
		if (Main.mouseLeft && Main.mouseLeftRelease && InflatedSize < MaximumInflatedSize)
		{
			InflatedSize++;
			float inflatePitch = InflatedSize switch
			{
				1 => 0f, 
				2 => -0.1f, 
				3 => -0.2f, 
				4 => -0.3f, 
				5 => -0.4f, 
				_ => -1f, 
			};
			val = InflationSound;
			((SoundStyle)(ref val)).Pitch = inflatePitch;
			SoundEngine.PlaySound(ref val, (Vector2?)((Entity)(object)player).TrueCenter(), (SoundUpdateCallback)null);
		}
		if (Main.mouseRight && Main.mouseRightRelease && InflatedSize > 0)
		{
			InflatedSize--;
			float deflatePitch = InflatedSize switch
			{
				0 => 0f, 
				1 => -0.1f, 
				2 => -0.2f, 
				3 => -0.3f, 
				4 => -0.4f, 
				_ => -1f, 
			};
			val = DeflationSound;
			((SoundStyle)(ref val)).Pitch = deflatePitch;
			SoundEngine.PlaySound(ref val, (Vector2?)((Entity)(object)player).TrueCenter(), (SoundUpdateCallback)null);
		}
		return false;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		SkinColor = player.skinColor;
	}

	public override void UpdateVanity(Player player)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		SkinColor = player.skinColor;
		player.AsPred().FlatBellySizeModifier += InflatedSize;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Accessories.Vanity.BalloonBelly", new { InflatedSize, MaximumInflatedSize });
	}

	public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
	{
		Asset<Texture2D>[] item = TextureAssets.Item;
		int type = ((ModItem)this).Type;
		item[type] = ModContent.Request<Texture2D>(InflatedSize switch
		{
			1 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size1", 
			2 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size2", 
			3 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size3", 
			4 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size4", 
			5 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size5", 
			_ => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size0", 
		}, (AssetRequestMode)1);
		return true;
	}

	public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
	{
		Asset<Texture2D>[] item = TextureAssets.Item;
		int type = ((ModItem)this).Type;
		item[type] = ModContent.Request<Texture2D>(InflatedSize switch
		{
			1 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size1", 
			2 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size2", 
			3 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size3", 
			4 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size4", 
			5 => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size5", 
			_ => "V2/Items/Voraria/Accessories/Vanity/BalloonBelly_Size0", 
		}, (AssetRequestMode)1);
		return true;
	}

	public override void SaveData(TagCompound tag)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		tag["BalloonBellySize"] = InflatedSize;
		Color skinColor = SkinColor;
		tag["BalloonBellySkinColorR"] = ((Color)(ref skinColor)).R;
		skinColor = SkinColor;
		tag["BalloonBellySkinColorG"] = ((Color)(ref skinColor)).G;
		skinColor = SkinColor;
		tag["BalloonBellySkinColorB"] = ((Color)(ref skinColor)).B;
		skinColor = SkinColor;
		tag["BalloonBellySkinColorA"] = ((Color)(ref skinColor)).A;
	}

	public override void LoadData(TagCompound tag)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (tag.ContainsKey("BalloonBellySize"))
		{
			InflatedSize = tag.GetInt("BalloonBellySize");
			SkinColor = new Color((int)tag.GetByte("BalloonBellySkinColorR"), (int)tag.GetByte("BalloonBellySkinColorG"), (int)tag.GetByte("BalloonBellySkinColorB"), (int)tag.GetByte("BalloonBellySkinColorA"));
		}
	}
}
