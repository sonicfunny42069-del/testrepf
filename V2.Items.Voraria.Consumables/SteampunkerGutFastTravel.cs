using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using V2.Core;
using V2.NPCs;
using V2.Sounds.MuffledSounds;
using V2.Sounds.Vore;

namespace V2.Items.Voraria.Consumables;

public class SteampunkerGutFastTravel : ModItem
{
	public override LocalizedText DisplayName => Language.GetText("Mods.V2.ItemName.Voraria.Consumables.SteampunkerGutFastTravel");

	public override LocalizedText Tooltip => Language.GetText("Mods.V2.ItemTooltip.Voraria.Consumables.SteampunkerGutFastTravel.Short");

	public override string Texture => "V2/Items/UnspritedItem";

	public override bool IsLoadingEnabled(Mod mod)
	{
		return !V2.GetFooled;
	}

	public override void SetStaticDefaults()
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		DrawAnimationVertical anim = new DrawAnimationVertical(6, 12, false);
		Main.RegisterItemAnimation(((ModItem)this).Type, (DrawAnimation)(object)anim);
		Sets.AnimatesAsSoul[((ModItem)this).Type] = true;
	}

	public override void SetDefaults()
	{
		((ModItem)this).Item.AsFood().Size = 0.15;
		((ModItem)this).Item.AsFood().MaxHealth = 4000;
		((ModItem)this).Item.AsFood().AcidResistTier = 2;
		((ModItem)this).Item.useAnimation = 6;
		((ModItem)this).Item.useTime = 6;
		((ModItem)this).Item.useStyle = 4;
		((ModItem)this).Item.noMelee = true;
		((ModItem)this).Item.AsFood().CanUseInStomach = CanUseInStomach;
		((ModItem)this).Item.AsFood().UseInStomach = UseInStomach;
		((Entity)((ModItem)this).Item).width = 30;
		((Entity)((ModItem)this).Item).height = 30;
		((ModItem)this).Item.rare = 6;
		((ModItem)this).Item.value = Item.buyPrice(0, 12, 50, 0);
	}

	public override bool CanUseItem(Player player)
	{
		return NPC.AnyNPCs(178);
	}

	public override void UseAnimation(Player player)
	{
		NPC steamLass = Main.npc.FirstOrDefault((NPC x) => ((Entity)x).active && x.life > 0 && x.type == 178 && PredNPC.CanSwallow(x, (Entity)(object)player));
		if (steamLass != null)
		{
			SendDirectlyToSteamGalGut(steamLass, player);
		}
	}

	public static bool CanUseInStomach(Item item, Player player, Entity pred)
	{
		return true;
	}

	public static void UseInStomach(Item item, Player player, Entity pred)
	{
		NPC steamLass = Main.npc.FirstOrDefault((NPC x) => ((Entity)x).active && x.life > 0 && x.type == 178 && PredNPC.CanSwallow(x, (Entity)(object)player, skipCaptorCheck: true));
		if (steamLass == null)
		{
			return;
		}
		((Entity)(object)player).CurrentCaptor().Prey.RemoveAll(delegate(PreyData x)
		{
			if (!x.NoHealth)
			{
				Entity instance = x.Instance;
				Player val = (Player)(object)((instance is Player) ? instance : null);
				if (val != null)
				{
					return ((Entity)val).whoAmI == ((Entity)player).whoAmI;
				}
			}
			return false;
		});
		SendDirectlyToSteamGalGut(steamLass, player);
	}

	public static void SendDirectlyToSteamGalGut(NPC steamLass, Player food)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		((Entity)food).position = ((Entity)steamLass).position;
		PredNPC.Swallow(steamLass, (Entity)(object)food, 0, -1, playSound: false);
		SoundEngine.PlaySound(ref MuffledItemSounds.MagicMirrorTeleport, (Vector2?)((Entity)food).position, (SoundUpdateCallback)null);
		SoundEngine.PlaySound(ref Burps.Humanoid.Small, (Vector2?)((Entity)food).position, (SoundUpdateCallback)null);
		SoundStyle muffled = StomachNoises.Muffled;
		((SoundStyle)(ref muffled)).Pitch = 0.3f;
		SoundEngine.PlaySound(ref muffled, (Vector2?)((Entity)food).position, (SoundUpdateCallback)null);
		SoundEngine.PlaySound(ref StomachNoises.Muffled, (Vector2?)((Entity)food).position, (SoundUpdateCallback)null);
		muffled = StomachNoises.Muffled;
		((SoundStyle)(ref muffled)).Pitch = -0.3f;
		SoundEngine.PlaySound(ref muffled, (Vector2?)((Entity)food).position, (SoundUpdateCallback)null);
		PredNPC.SetChatboxText(steamLass, food, "[c/7F7F7F:<As you press the Translator's button, you find yourself packed away in a gut. Someone didn't read the fine print, it would seem...or maybe you did, and wanted this outcome. Either way, " + steamLass.GivenName + " finds a light belch forced out of her as you settle inside her tummy.>]\nAww, needed a quick reprieve from all those gluttonous gannets of the world? Well, you'll be quite comfortable in there! Just don't be surprised if I start melting you down instead, oho! A hard-working inventor such as myself needs herself nutrients aplenty, you know!");
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		tooltips.AddVorariaDynamicItemTooltip("Voraria.Consumables.SteampunkerGutFastTravel", new { });
	}
}
