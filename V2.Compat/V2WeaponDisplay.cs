using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoMod.RuntimeDetour;
using Terraria;
using Terraria.ModLoader;
using V2.Core;
using WeaponDisplay.ItemInWorld;

namespace V2.Compat;

[JITWhenModsEnabled(new string[] { "WeaponDisplay" })]
public class V2WeaponDisplay : V2CompatModule
{
	private delegate bool orig_PreDrawInWorld(ItemLight self, Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI);

	internal static Hook WeaponDisplay_ItemInWorld_ItemLightHook;

	private static readonly MethodInfo WeaponDisplay_ItemInWorld_ItemLight_MethodInfo = typeof(ItemLight).GetMethod("PreDrawInWorld");

	public V2WeaponDisplay(Mod mod)
		: base(mod)
	{
	}

	public override void ApplyCompatibility()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		((Mod)V2.Instance).Logger.Info((object)"Applying patch: WeaponDisplay.ItemInWorld.ItemLight::PreDrawInWorld");
		WeaponDisplay_ItemInWorld_ItemLightHook = new Hook((MethodBase)WeaponDisplay_ItemInWorld_ItemLight_MethodInfo, (Delegate)(_003C_003EF_007B00240000_007D<orig_PreDrawInWorld, ItemLight, Item, SpriteBatch, Color, Color, float, float, int, bool>)delegate(orig_PreDrawInWorld orig, ItemLight self, Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			return ((Entity)(object)item).CurrentCaptor() == null && orig(self, item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
		});
		WeaponDisplay_ItemInWorld_ItemLightHook.Apply();
	}

	public override void UnapplyCompatibility()
	{
		if (WeaponDisplay_ItemInWorld_ItemLightHook != null)
		{
			WeaponDisplay_ItemInWorld_ItemLightHook.Undo();
			WeaponDisplay_ItemInWorld_ItemLightHook = null;
		}
	}
}
