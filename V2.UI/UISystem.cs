using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using V2.UI.PredStatsMenu;
using V2.UI.SizeScanners;
using V2.UI.StomachacheMeter;
using V2.UI.StomachCapacityMeter;
using V2.UI.StruggleSystem;

namespace V2.UI;

public class UISystem : ModSystem
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GameInterfaceLayer, bool> _003C_003E9__21_2;

		public static GameInterfaceDrawMethod _003C_003E9__21_3;

		public static Func<GameInterfaceLayer, bool> _003C_003E9__21_4;

		public static GameInterfaceDrawMethod _003C_003E9__21_5;

		public static Func<GameInterfaceLayer, bool> _003C_003E9__21_6;

		public static Predicate<GameInterfaceLayer> _003C_003E9__21_0;

		public static Predicate<GameInterfaceLayer> _003C_003E9__21_1;

		internal bool _003CModifyInterfaceLayers_003Eb__21_2(GameInterfaceLayer x)
		{
			return x.Name == "Vanilla: Hair Window";
		}

		internal bool _003CModifyInterfaceLayers_003Eb__21_3()
		{
			if (Main.LocalPlayer.talkNPC != -1)
			{
				NPC stylist = Main.npc[Main.LocalPlayer.talkNPC];
				if (((Entity)stylist).active && stylist.type == 353)
				{
					UIOverrides.DrawInterface_21_HairWindow(stylist);
				}
			}
			return true;
		}

		internal bool _003CModifyInterfaceLayers_003Eb__21_4(GameInterfaceLayer x)
		{
			return x.Name == "Vanilla: Death Text";
		}

		internal bool _003CModifyInterfaceLayers_003Eb__21_5()
		{
			UIOverrides.DrawInterface_35_YouDied();
			return true;
		}

		internal bool _003CModifyInterfaceLayers_003Eb__21_6(GameInterfaceLayer x)
		{
			return x.Name == "Vanilla: Cursor";
		}

		internal bool _003CModifyInterfaceLayers_003Eb__21_0(GameInterfaceLayer layer)
		{
			return layer.Name.Equals("Vanilla: Hair Window (Voraria II Override)");
		}

		internal bool _003CModifyInterfaceLayers_003Eb__21_1(GameInterfaceLayer layer)
		{
			return layer.Name.Equals("Vanilla: Mouse Text");
		}
	}

	public UserInterface MouseRestrictionDummyLayer;

	public MouseRestrictionDummyUI MouseRestrictionDummy;

	public UserInterface HeldItemInterfaceLayer;

	public HeldItemDrawingUI HeldItemInterface;

	public UserInterface StomachCapacityBarInterfaceLayer;

	public StomachCapacityMeterUI StomachCapacityBarInterface;

	public UserInterface StomachacheMeterInterfaceLayer;

	public StomachacheMeterUI StomachacheMeterInterface;

	public UserInterface PlayerPredStruggleInterfaceLayer;

	public PlayerPredStruggleUI PlayerPredStruggleInterface;

	public UserInterface PlayerPreyStruggleInterfaceLayer;

	public PlayerPreyStruggleUI PlayerPreyStruggleInterface;

	public UserInterface PredStatsMenuMouthInterfaceLayer;

	public PredStatsMenuMouthUI PredStatsMenuMouthInterface;

	public UserInterface PredStatsMenuInterfaceLayer;

	public PredStatsMenuUI PredStatsMenuInterface;

	public UserInterface MealSizeScannerInterfaceLayer;

	public MealSizeScannerUI MealSizeScannerInterface;

	public UserInterface PredCapacityScannerInterfaceLayer;

	public PredCapacityScannerUI PredCapacityScannerInterface;

	public override void OnWorldLoad()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		MouseRestrictionDummyLayer = new UserInterface();
		MouseRestrictionDummy = new MouseRestrictionDummyUI();
		((UIElement)MouseRestrictionDummy).Activate();
		MouseRestrictionDummyLayer.SetState((UIState)(object)MouseRestrictionDummy);
		HeldItemInterfaceLayer = new UserInterface();
		HeldItemInterface = new HeldItemDrawingUI();
		((UIElement)HeldItemInterface).Activate();
		HeldItemInterfaceLayer.SetState((UIState)(object)HeldItemInterface);
		StomachCapacityBarInterfaceLayer = new UserInterface();
		StomachCapacityBarInterface = new StomachCapacityMeterUI();
		((UIElement)StomachCapacityBarInterface).Activate();
		StomachCapacityBarInterfaceLayer.SetState((UIState)(object)StomachCapacityBarInterface);
		StomachacheMeterInterfaceLayer = new UserInterface();
		StomachacheMeterInterface = new StomachacheMeterUI();
		((UIElement)StomachacheMeterInterface).Activate();
		StomachacheMeterInterfaceLayer.SetState((UIState)(object)StomachacheMeterInterface);
		PlayerPredStruggleInterfaceLayer = new UserInterface();
		PlayerPredStruggleInterface = new PlayerPredStruggleUI();
		((UIElement)PlayerPredStruggleInterface).Activate();
		PlayerPredStruggleInterfaceLayer.SetState((UIState)(object)PlayerPredStruggleInterface);
		PlayerPreyStruggleInterfaceLayer = new UserInterface();
		PlayerPreyStruggleInterface = new PlayerPreyStruggleUI();
		((UIElement)PlayerPreyStruggleInterface).Activate();
		PlayerPreyStruggleInterfaceLayer.SetState((UIState)(object)PlayerPreyStruggleInterface);
		PredStatsMenuMouthInterfaceLayer = new UserInterface();
		PredStatsMenuMouthInterface = new PredStatsMenuMouthUI();
		((UIElement)PredStatsMenuMouthInterface).Activate();
		PredStatsMenuMouthInterfaceLayer.SetState((UIState)(object)PredStatsMenuMouthInterface);
		PredStatsMenuInterfaceLayer = new UserInterface();
		PredStatsMenuInterface = new PredStatsMenuUI();
		((UIElement)PredStatsMenuInterface).Activate();
		PredStatsMenuInterfaceLayer.SetState((UIState)(object)PredStatsMenuInterface);
		MealSizeScannerInterfaceLayer = new UserInterface();
		MealSizeScannerInterface = new MealSizeScannerUI();
		((UIElement)MealSizeScannerInterface).Activate();
		MealSizeScannerInterfaceLayer.SetState((UIState)(object)MealSizeScannerInterface);
		PredCapacityScannerInterfaceLayer = new UserInterface();
		PredCapacityScannerInterface = new PredCapacityScannerUI();
		((UIElement)PredCapacityScannerInterface).Activate();
		PredCapacityScannerInterfaceLayer.SetState((UIState)(object)PredCapacityScannerInterface);
	}

	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		GameInterfaceLayer? obj = layers.FirstOrDefault((GameInterfaceLayer x) => x.Name == "Vanilla: Hair Window");
		LegacyGameInterfaceLayer hairStyleWindowLegacyLayer = (LegacyGameInterfaceLayer)(object)((obj is LegacyGameInterfaceLayer) ? obj : null);
		if (hairStyleWindowLegacyLayer != null)
		{
			int hairStyleWindowLegacyLayerIndex = layers.IndexOf((GameInterfaceLayer)(object)hairStyleWindowLegacyLayer);
			layers.Remove((GameInterfaceLayer)(object)hairStyleWindowLegacyLayer);
			object obj2 = _003C_003Ec._003C_003E9__21_3;
			if (obj2 == null)
			{
				GameInterfaceDrawMethod val = delegate
				{
					if (Main.LocalPlayer.talkNPC != -1)
					{
						NPC val3 = Main.npc[Main.LocalPlayer.talkNPC];
						if (((Entity)val3).active && val3.type == 353)
						{
							UIOverrides.DrawInterface_21_HairWindow(val3);
						}
					}
					return true;
				};
				_003C_003Ec._003C_003E9__21_3 = val;
				obj2 = (object)val;
			}
			layers.Insert(hairStyleWindowLegacyLayerIndex, (GameInterfaceLayer)new LegacyGameInterfaceLayer("Vanilla: Hair Window (Voraria II Override)", (GameInterfaceDrawMethod)obj2, (InterfaceScaleType)1));
		}
		GameInterfaceLayer? obj3 = layers.FirstOrDefault((GameInterfaceLayer x) => x.Name == "Vanilla: Death Text");
		LegacyGameInterfaceLayer deathTextLegacyLayer = (LegacyGameInterfaceLayer)(object)((obj3 is LegacyGameInterfaceLayer) ? obj3 : null);
		if (deathTextLegacyLayer != null)
		{
			int deathTextLegacyLayerIndex = layers.IndexOf((GameInterfaceLayer)(object)deathTextLegacyLayer);
			layers.Remove((GameInterfaceLayer)(object)deathTextLegacyLayer);
			object obj4 = _003C_003Ec._003C_003E9__21_5;
			if (obj4 == null)
			{
				GameInterfaceDrawMethod val2 = delegate
				{
					UIOverrides.DrawInterface_35_YouDied();
					return true;
				};
				_003C_003Ec._003C_003E9__21_5 = val2;
				obj4 = (object)val2;
			}
			layers.Insert(deathTextLegacyLayerIndex, (GameInterfaceLayer)new LegacyGameInterfaceLayer("Vanilla: Death Text (Voraria II Override)", (GameInterfaceDrawMethod)obj4, (InterfaceScaleType)1));
		}
		GameInterfaceLayer? obj5 = layers.FirstOrDefault((GameInterfaceLayer x) => x.Name == "Vanilla: Cursor");
		LegacyGameInterfaceLayer cursorLegacyLayer = (LegacyGameInterfaceLayer)(object)((obj5 is LegacyGameInterfaceLayer) ? obj5 : null);
		if (cursorLegacyLayer != null)
		{
			AddInterfaceLayer(layers, MouseRestrictionDummyLayer, (UIState)(object)MouseRestrictionDummy, layers.IndexOf((GameInterfaceLayer)(object)cursorLegacyLayer), "Voraria II: Mouse Restriction Dummy State");
		}
		int OverriddenHairWindowIndex = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Hair Window (Voraria II Override)"));
		if (OverriddenHairWindowIndex != -1)
		{
			AddInterfaceLayer(layers, StomachCapacityBarInterfaceLayer, (UIState)(object)StomachCapacityBarInterface, OverriddenHairWindowIndex, "Stomach Capacity Meter");
			AddInterfaceLayer(layers, StomachacheMeterInterfaceLayer, (UIState)(object)StomachacheMeterInterface, OverriddenHairWindowIndex + 1, "Stomachache Meter");
			AddInterfaceLayer(layers, MealSizeScannerInterfaceLayer, (UIState)(object)MealSizeScannerInterface, OverriddenHairWindowIndex + 2, "Sizemic Scanner");
			AddInterfaceLayer(layers, PredCapacityScannerInterfaceLayer, (UIState)(object)PredCapacityScannerInterface, OverriddenHairWindowIndex + 3, "Servant's Scanner");
			AddInterfaceLayer(layers, PlayerPredStruggleInterfaceLayer, (UIState)(object)PlayerPredStruggleInterface, OverriddenHairWindowIndex + 4, "Player Pred Struggles");
			AddInterfaceLayer(layers, PlayerPreyStruggleInterfaceLayer, (UIState)(object)PlayerPreyStruggleInterface, OverriddenHairWindowIndex + 5, "Player Prey Struggles");
			AddInterfaceLayer(layers, PredStatsMenuInterfaceLayer, (UIState)(object)PredStatsMenuInterface, OverriddenHairWindowIndex + 6, "Pred Stats Menu");
			AddInterfaceLayer(layers, PredStatsMenuMouthInterfaceLayer, (UIState)(object)PredStatsMenuMouthInterface, OverriddenHairWindowIndex + 7, "Pred Stats Menu's Hungry Mouth");
		}
		int MouseTextIndex = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Mouse Text"));
		if (MouseTextIndex != -1)
		{
			AddInterfaceLayer(layers, HeldItemInterfaceLayer, (UIState)(object)HeldItemInterface, MouseTextIndex, "Held Item");
		}
	}

	public static void AddInterfaceLayer(List<GameInterfaceLayer> layers, UserInterface userInterface, UIState state, int index, string customName = null)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		string name = ((customName != null) ? customName : ((object)state).ToString());
		layers.Insert(index, (GameInterfaceLayer)new LegacyGameInterfaceLayer("Voraria II: " + name, (GameInterfaceDrawMethod)delegate
		{
			userInterface.Update(Main._drawInterfaceGameTime);
			((UIElement)state).Draw(Main.spriteBatch);
			return true;
		}, (InterfaceScaleType)1));
	}
}
