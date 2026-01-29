using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace V2.UI.StylistAteThePublishButton;

public static class AntiPublishProtection
{
	[CompilerGenerated]
	private static class _003C_003EO
	{
		public static MouseEvent _003C0_003E__StylistAteThePublishButton_OnMouseOver;
	}

	public static void EnsurePublishButtonGetsGulped()
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		if (!Main.gameMenu)
		{
			return;
		}
		object UIModSources = typeof(Main).Assembly.GetType("Terraria.ModLoader.UI.Interface").GetField("modSources", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
		if (UIModSources == null)
		{
			return;
		}
		List<UIPanel> UIModSourceItemList = (List<UIPanel>)typeof(Main).Assembly.GetType("Terraria.ModLoader.UI.UIModSources").GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(UIModSources);
		if (UIModSourceItemList == null || UIModSourceItemList.Count <= 0)
		{
			return;
		}
		FieldInfo modNameInfo = typeof(Main).Assembly.GetType("Terraria.ModLoader.UI.UIModSourceItem").GetField("_mod", BindingFlags.Instance | BindingFlags.NonPublic);
		object V2ModSourceItem;
		using (List<UIPanel>.Enumerator enumerator = UIModSourceItemList.GetEnumerator())
		{
			UIPanel UIModSourceItem;
			do
			{
				if (enumerator.MoveNext())
				{
					UIModSourceItem = enumerator.Current;
					continue;
				}
				return;
			}
			while (!((string)modNameInfo.GetValue(UIModSourceItem) == "V2"));
			V2ModSourceItem = UIModSourceItem;
		}
		UIPanel V2ModSourcePanel = (UIPanel)((V2ModSourceItem is UIPanel) ? V2ModSourceItem : null);
		Language.GetTextValue("tModLoader.MSPublish");
		UIAutoScaleTextTextPanel<string> publishButton;
		using (IEnumerator<UIElement> enumerator2 = ((UIElement)V2ModSourcePanel).Children.GetEnumerator())
		{
			UIElement element;
			do
			{
				if (enumerator2.MoveNext())
				{
					element = enumerator2.Current;
					continue;
				}
				return;
			}
			while (!(element is UIAutoScaleTextTextPanel<string>) || element.Left.Pixels != 390f);
			publishButton = element as UIAutoScaleTextTextPanel<string>;
		}
		UIImage stylistAteThePublishButton = new UIImage(ModContent.Request<Texture2D>("V2/UI/StylistAteThePublishButton/StylistAteThePublishButton_Belly", (AssetRequestMode)2))
		{
			Height = 
			{
				Pixels = 144f
			},
			Width = 
			{
				Pixels = 56f
			},
			Left = 
			{
				Pixels = 390f
			},
			Top = 
			{
				Pixels = 40f
			},
			PaddingRight = 32f,
			PaddingTop = 14f
		};
		object obj = _003C_003EO._003C0_003E__StylistAteThePublishButton_OnMouseOver;
		if (obj == null)
		{
			MouseEvent val = StylistAteThePublishButton_OnMouseOver;
			_003C_003EO._003C0_003E__StylistAteThePublishButton_OnMouseOver = val;
			obj = (object)val;
		}
		((UIElement)stylistAteThePublishButton).OnMouseOver += (MouseEvent)obj;
		((UIElement)V2ModSourcePanel).RemoveChild((UIElement)(object)publishButton);
		((UIElement)V2ModSourcePanel).Append((UIElement)(object)stylistAteThePublishButton);
		((UIElement)V2ModSourcePanel).RecalculateChildren();
	}

	private static void StylistAteThePublishButton_OnMouseOver(UIMouseEvent evt, UIElement listeningElement)
	{
		Main.instance.MouseTextNoOverride("Don't worry about a misclick; [c/FFFF00:everything's okay]!\nThe Publish button is [c/BFBF00:safe in the depths of the Stylist's hungry stomach].\nAs such, Voraria: Second Course [c/BF3F00:can never be published to the Workshop].", 0, (byte)0, -1, -1, -1, -1, 0);
	}
}
