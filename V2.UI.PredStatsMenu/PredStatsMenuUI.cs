using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.UI;
using Terraria.UI.Chat;
using V2.Core;
using V2.PlayerHandling;
using V2.PlayerHandling.PredPlayerGoals;

namespace V2.UI.PredStatsMenu;

public class PredStatsMenuUI : UIState
{
	private static readonly Asset<Texture2D> _predStatsMenuBackground = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Background", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsPizzaSlice_GLP = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_PredStatSlice_GLP", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsPizzaSlice_TUM = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_PredStatSlice_TUM", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsPizzaSlice_ACI = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_PredStatSlice_ACI", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsPizzaSlice_ABS = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_PredStatSlice_ABS", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsOverviewPanel = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_StatOverviewPanel", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsAvailablePointsPanel = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_AvailableStatPointsPanel", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsMenuBook = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_GoalsBook", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsStageDeselected = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Goals_SectionDeselected", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsStageSelected = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Goals_SectionSelected", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsMenuHeader = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Goals_Header", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsMenuFooter = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Goals_Footer", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsSortingClipboard = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Goals_SortingClipboard", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsGoalsMenuExitButton = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Goals_ExitButton", (AssetRequestMode)1);

	private static readonly Asset<Texture2D> _predStatsExitButton = ModContent.Request<Texture2D>("V2/UI/PredStatsMenu/PredStatsMenu_Exit", (AssetRequestMode)1);

	private static readonly SoundStyle AllocateSuccess;

	private static readonly SoundStyle AllocateFail;

	private static readonly SoundStyle SortStyleChange;

	public static bool Visible { get; set; }

	public static bool GoalsMenuOpen { get; set; }

	public static ProgressionStage SelectedProgressionStage { get; set; }

	public static PredGoalsSortingOption SortStyle { get; set; }

	public static int GoalsPage { get; set; }

	public override void OnInitialize()
	{
		SelectedProgressionStage = ModContent.GetInstance<StarterStage>();
		SortStyle = PredGoalsSortingOption.Default;
	}

	public override void Update(GameTime gameTime)
	{
		Visible = false;
		Player player = Main.LocalPlayer;
		if (!Main.playerInventory || V2.GetFooled)
		{
			player.AsPred().InPredStatsMenu = false;
		}
		if (player.AsPred().InPredStatsMenu)
		{
			Visible = true;
		}
		else
		{
			GoalsMenuOpen = false;
		}
	}

	public override void Draw(SpriteBatch spriteBatch)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1273: Unknown result type (might be due to invalid IL or missing references)
		//IL_127e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1283: Unknown result type (might be due to invalid IL or missing references)
		//IL_1292: Unknown result type (might be due to invalid IL or missing references)
		//IL_129c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_131e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1329: Unknown result type (might be due to invalid IL or missing references)
		//IL_132e: Unknown result type (might be due to invalid IL or missing references)
		//IL_133d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1347: Unknown result type (might be due to invalid IL or missing references)
		//IL_1351: Unknown result type (might be due to invalid IL or missing references)
		//IL_1366: Unknown result type (might be due to invalid IL or missing references)
		//IL_1372: Unknown result type (might be due to invalid IL or missing references)
		//IL_1399: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1411: Unknown result type (might be due to invalid IL or missing references)
		//IL_141d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1444: Unknown result type (might be due to invalid IL or missing references)
		//IL_1474: Unknown result type (might be due to invalid IL or missing references)
		//IL_147f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_1493: Unknown result type (might be due to invalid IL or missing references)
		//IL_149d: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_151f: Unknown result type (might be due to invalid IL or missing references)
		//IL_152a: Unknown result type (might be due to invalid IL or missing references)
		//IL_152f: Unknown result type (might be due to invalid IL or missing references)
		//IL_153e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1548: Unknown result type (might be due to invalid IL or missing references)
		//IL_1552: Unknown result type (might be due to invalid IL or missing references)
		//IL_1980: Unknown result type (might be due to invalid IL or missing references)
		//IL_198d: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1edc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1940: Unknown result type (might be due to invalid IL or missing references)
		//IL_194b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1950: Unknown result type (might be due to invalid IL or missing references)
		//IL_1955: Unknown result type (might be due to invalid IL or missing references)
		//IL_195f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1969: Unknown result type (might be due to invalid IL or missing references)
		//IL_1978: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1151: Unknown result type (might be due to invalid IL or missing references)
		//IL_115c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1161: Unknown result type (might be due to invalid IL or missing references)
		//IL_1168: Unknown result type (might be due to invalid IL or missing references)
		//IL_116d: Unknown result type (might be due to invalid IL or missing references)
		//IL_118d: Unknown result type (might be due to invalid IL or missing references)
		//IL_117f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1197: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_103f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1045: Unknown result type (might be due to invalid IL or missing references)
		//IL_1001: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_105d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1056: Unknown result type (might be due to invalid IL or missing references)
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_107c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1075: Unknown result type (might be due to invalid IL or missing references)
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_124f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1205: Unknown result type (might be due to invalid IL or missing references)
		//IL_1082: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_109b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1117: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_093a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_111d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_112d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba8: Unknown result type (might be due to invalid IL or missing references)
		if (!Visible)
		{
			return;
		}
		Main.LocalPlayer.mouseInterface = true;
		Vector2 backdropPos = default(Vector2);
		((Vector2)(ref backdropPos))._002Ector((float)((Main.screenWidth - _predStatsMenuBackground.Value.Width) / 2), (float)((Main.screenHeight - _predStatsMenuBackground.Value.Height) / 2));
		spriteBatch.Draw(_predStatsMenuBackground.Value, backdropPos, (Rectangle?)_predStatsMenuBackground.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		Rectangle backdropRect = _predStatsMenuBackground.Value.Bounds;
		backdropRect.X = (int)backdropPos.X;
		backdropRect.Y = (int)backdropPos.Y;
		Rectangle goalsMenuBookRect = default(Rectangle);
		((Rectangle)(ref goalsMenuBookRect))._002Ector((int)backdropPos.X + 644, (int)backdropPos.Y + 394, 30, 30);
		float mouseTextColorFactor = (float)(int)Main.mouseTextColor / 255f;
		if (GoalsMenuOpen)
		{
			List<PredPlayerGoal> selectedStageGoals = ModContent.GetContent<PredPlayerGoal>().ToList();
			List<ProgressionStage> stagesOrdered = PredPlayerGoalLoader.ProgressionStages.OrderBy((ProgressionStage progressionStage) => progressionStage.Order).ToList();
			selectedStageGoals.RemoveAll((PredPlayerGoal predPlayerGoal) => predPlayerGoal.Stage != SelectedProgressionStage || !predPlayerGoal.Available(Main.LocalPlayer));
			switch (SortStyle)
			{
			case PredGoalsSortingOption.Alphabetical:
				selectedStageGoals = selectedStageGoals.OrderBy((PredPlayerGoal predPlayerGoal) => Language.GetTextValue(predPlayerGoal.DisplayName(Main.LocalPlayer))).ToList();
				break;
			case PredGoalsSortingOption.AlphabeticalBackwards:
				selectedStageGoals = selectedStageGoals.OrderByDescending((PredPlayerGoal predPlayerGoal) => Language.GetTextValue(predPlayerGoal.DisplayName(Main.LocalPlayer))).ToList();
				break;
			case PredGoalsSortingOption.PointValue:
				selectedStageGoals = selectedStageGoals.OrderBy((PredPlayerGoal predPlayerGoal) => predPlayerGoal.StatPointsFromCompletion).ToList();
				break;
			case PredGoalsSortingOption.PointValueBackwards:
				selectedStageGoals = selectedStageGoals.OrderByDescending((PredPlayerGoal predPlayerGoal) => predPlayerGoal.StatPointsFromCompletion).ToList();
				break;
			case PredGoalsSortingOption.Completion:
				selectedStageGoals = selectedStageGoals.OrderBy((PredPlayerGoal predPlayerGoal) => !predPlayerGoal.Complete(Main.LocalPlayer)).ToList();
				break;
			case PredGoalsSortingOption.Incompletion:
				selectedStageGoals = selectedStageGoals.OrderByDescending((PredPlayerGoal predPlayerGoal) => !predPlayerGoal.Complete(Main.LocalPlayer)).ToList();
				break;
			}
			int columnCountPerPage = 10;
			int rowCountPerPage = 4;
			int totalGoalsPerPage = columnCountPerPage * rowCountPerPage;
			Math.Floor((double)(selectedStageGoals.Count - 1) / (double)totalGoalsPerPage);
			int num = (GoalsPage - 1) * totalGoalsPerPage;
			int lastIndexForThisPage = num + columnCountPerPage * rowCountPerPage - 1;
			if (lastIndexForThisPage >= selectedStageGoals.Count)
			{
				lastIndexForThisPage = selectedStageGoals.Count - 1;
			}
			Rectangle goalHoverRect = default(Rectangle);
			int statPointsFromCompletion = default(int);
			for (int i = num; i <= lastIndexForThisPage; i++)
			{
				int num2 = i % totalGoalsPerPage;
				int x = num2 % columnCountPerPage;
				int y = (int)Math.Floor((double)num2 / (double)columnCountPerPage);
				PredPlayerGoal goalToDraw = selectedStageGoals[i];
				Vector2 goalDrawPos = backdropPos + new Vector2(80f, 140f) + new Vector2((float)((PredPlayerGoal.TextureBounds.Width + 2) * x), (float)((PredPlayerGoal.TextureBounds.Height + 2) * y));
				spriteBatch.Draw(goalToDraw.Complete(Main.LocalPlayer) ? goalToDraw.CompleteTexture : goalToDraw.IncompleteTexture, goalDrawPos, (Rectangle?)PredPlayerGoal.TextureBounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				((Rectangle)(ref goalHoverRect))._002Ector((int)goalDrawPos.X, (int)goalDrawPos.Y, PredPlayerGoal.TextureBounds.Width, PredPlayerGoal.TextureBounds.Height);
				if (PredStatsMenuMouthUI.MouthState != 3 || !((Rectangle)(ref goalHoverRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
				{
					continue;
				}
				string[] obj = new string[13]
				{
					"[c/",
					Utils.Hex3(goalToDraw.DisplayNameColor(Main.LocalPlayer) * mouseTextColorFactor),
					":",
					Language.GetTextValue(goalToDraw.DisplayName(Main.LocalPlayer)),
					"]\n[c/",
					Utils.Hex3(new Color(127, 127, 127) * mouseTextColorFactor),
					":",
					goalToDraw.Complete(Main.LocalPlayer) ? "Complete" : "Incomplete",
					"; worth ",
					null,
					null,
					null,
					null
				};
				statPointsFromCompletion = goalToDraw.StatPointsFromCompletion;
				obj[9] = statPointsFromCompletion.ToString();
				obj[10] = " stat point";
				obj[11] = ((goalToDraw.StatPointsFromCompletion == 1) ? "" : "s");
				obj[12] = "]\n";
				string goalFullHoverText = string.Concat(obj);
				string descriptionKey = goalToDraw.Description(Main.LocalPlayer);
				descriptionKey = ((!((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160)) ? (descriptionKey + ".Default") : (descriptionKey + ".Clarification"));
				string[] array = Utils.WordwrapString(Language.GetTextValue(descriptionKey), FontAssets.MouseText.Value, 720, 15, ref statPointsFromCompletion);
				for (statPointsFromCompletion = 0; statPointsFromCompletion < array.Length; statPointsFromCompletion++)
				{
					string piece = array[statPointsFromCompletion];
					if (piece != null && piece != "")
					{
						goalFullHoverText += piece;
						if (!piece.Contains('\n'))
						{
							goalFullHoverText += "\n";
						}
					}
				}
				if (!((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160))
				{
					goalFullHoverText = goalFullHoverText + "[c/7F7F7F:" + Language.GetTextValue("Mods.V2.PredPlayerGoals.GenericText.HoldToLearnMore." + (goalToDraw.Complete(Main.LocalPlayer) ? "Complete" : "Incomplete")) + "]";
				}
				UICommon.TooltipMouseText(goalFullHoverText);
				Main.mouseText = true;
			}
			int selectedStageIndex = stagesOrdered.IndexOf(SelectedProgressionStage);
			Rectangle stageHoverRect = default(Rectangle);
			Color subtitleColor = default(Color);
			Color completionRatiosBaseColor = default(Color);
			for (int i2 = 0; i2 < stagesOrdered.Count; i2++)
			{
				ProgressionStage stageToDraw = stagesOrdered[i2];
				List<PredPlayerGoal> stageGoals = ModContent.GetContent<PredPlayerGoal>().ToList();
				stageGoals.RemoveAll((PredPlayerGoal predPlayerGoal) => predPlayerGoal.Stage != stageToDraw);
				List<PredPlayerGoal> stageGoalsCompleted = stageGoals.FindAll((PredPlayerGoal predPlayerGoal) => predPlayerGoal.Complete(Main.LocalPlayer));
				float goalCompletionRatio = (float)stageGoalsCompleted.Count / (float)stageGoals.Count;
				int pointsPossibleFromStage = 0;
				int pointsGainedFromStage = 0;
				foreach (PredPlayerGoal goal in stageGoals)
				{
					pointsPossibleFromStage += goal.StatPointsFromCompletion;
					if (goal.Complete(Main.LocalPlayer))
					{
						pointsGainedFromStage += goal.StatPointsFromCompletion;
					}
				}
				float pointsCompletionRatio = (float)pointsGainedFromStage / (float)pointsPossibleFromStage;
				Vector2 stageTabDrawPos = backdropPos + new Vector2(10f, 140f);
				if (i2 <= selectedStageIndex)
				{
					stageTabDrawPos.Y += i2 * 20;
				}
				else
				{
					stageTabDrawPos.Y += (i2 + 1) * 20;
				}
				spriteBatch.Draw((i2 == selectedStageIndex) ? _predStatsGoalsStageSelected.Value : _predStatsGoalsStageDeselected.Value, stageTabDrawPos, (Rectangle?)((i2 == selectedStageIndex) ? _predStatsGoalsStageSelected.Value.Bounds : _predStatsGoalsStageDeselected.Value.Bounds), Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				((Rectangle)(ref stageHoverRect))._002Ector((int)stageTabDrawPos.X, (int)stageTabDrawPos.Y, (i2 == selectedStageIndex) ? _predStatsGoalsStageSelected.Value.Width : _predStatsGoalsStageDeselected.Value.Width, (i2 == selectedStageIndex) ? _predStatsGoalsStageSelected.Value.Height : _predStatsGoalsStageDeselected.Value.Height);
				if (!((Rectangle)(ref stageHoverRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
				{
					continue;
				}
				Color nameColor = Color.LimeGreen;
				((Color)(ref subtitleColor))._002Ector(127, 127, 127);
				string stageFullHoverText = "[c/" + Utils.Hex3(nameColor * mouseTextColorFactor) + ":" + stageToDraw.DisplayName + "]\n[c/" + Utils.Hex3(subtitleColor * mouseTextColorFactor) + ":" + stageToDraw.DisplaySubtitle + "]\n";
				string[] array = Utils.WordwrapString(stageToDraw.Description, FontAssets.MouseText.Value, 600, 10, ref statPointsFromCompletion);
				foreach (string piece2 in array)
				{
					if (piece2 != null && piece2 != "")
					{
						stageFullHoverText += piece2;
						if (!piece2.Contains('\n'))
						{
							stageFullHoverText += "\n";
						}
					}
				}
				if (!stageToDraw.Available(Main.LocalPlayer))
				{
					stageFullHoverText = stageFullHoverText + "[c/" + Utils.Hex3(V2Colors.Basic.Red * mouseTextColorFactor) + ":You haven't unlocked this progression stage yet!]\n";
					stageFullHoverText = stageFullHoverText + "[c/" + Utils.Hex3(V2Colors.Basic.Red * mouseTextColorFactor) + ":You have to " + stageToDraw.UnlockCondition + " to unlock this progression stage!]\n";
				}
				((Color)(ref completionRatiosBaseColor))._002Ector(145, 155, 215);
				Color goalsCompleteColor = Color.Lerp(new Color(150, 50, 50), new Color(70, 210, 70), goalCompletionRatio.CastToDecimalPlaces(1));
				Color pointsGainedColor = Color.Lerp(new Color(150, 50, 50), new Color(70, 210, 70), pointsCompletionRatio.CastToDecimalPlaces(1));
				int currentHiddenGoalsInStage = stageGoals.FindAll((PredPlayerGoal predPlayerGoal) => !predPlayerGoal.Available(Main.LocalPlayer)).Count;
				string[] obj2 = new string[16]
				{
					stageFullHoverText,
					"[c/",
					Utils.Hex3(completionRatiosBaseColor * mouseTextColorFactor),
					":Stage Goals Completed:] [c/",
					Utils.Hex3(goalsCompleteColor * mouseTextColorFactor),
					":",
					stageGoalsCompleted.Count.ToString(),
					" / ",
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null
				};
				statPointsFromCompletion = stageGoals.Count;
				obj2[8] = statPointsFromCompletion.ToString();
				obj2[9] = " (";
				obj2[10] = goalCompletionRatio.ToPercentage(1);
				obj2[11] = ")] [c/";
				obj2[12] = Utils.Hex3(subtitleColor * mouseTextColorFactor);
				obj2[13] = ":(";
				obj2[14] = ((currentHiddenGoalsInStage == 1) ? "1 goal is" : (currentHiddenGoalsInStage + " goals are"));
				obj2[15] = " currently hidden)]\n";
				stageFullHoverText = string.Concat(obj2);
				stageFullHoverText = stageFullHoverText + "[c/" + Utils.Hex3(completionRatiosBaseColor * mouseTextColorFactor) + ":Points Gained From Stage:] [c/" + Utils.Hex3(pointsGainedColor * mouseTextColorFactor) + ":" + pointsGainedFromStage + " / " + pointsPossibleFromStage + " (" + pointsCompletionRatio.ToPercentage(1) + ")]";
				UICommon.TooltipMouseText(stageFullHoverText);
				Main.mouseText = true;
				if (stageToDraw.Available(Main.LocalPlayer) && Main.mouseLeft && Main.mouseLeftRelease)
				{
					SoundEngine.PlaySound(ref SoundID.MenuTick, (Vector2?)null, (SoundUpdateCallback)null);
					SelectedProgressionStage = stageToDraw;
				}
			}
			spriteBatch.Draw(_predStatsGoalsMenuHeader.Value, backdropPos + new Vector2((float)_predStatsMenuBackground.Value.Width / 2f, 10f), (Rectangle?)_predStatsGoalsMenuHeader.Value.Bounds, Color.White, 0f, new Vector2((float)_predStatsGoalsMenuHeader.Value.Width / 2f, 0f), 1f, (SpriteEffects)0, 0f);
			ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, Language.GetTextValue("Mods.V2.PredPlayerGoals.GenericText.Header.Title"), backdropPos + new Vector2((float)_predStatsMenuBackground.Value.Width / 2f, 12f), Color.White, 0f, new Vector2(ChatManager.GetStringSize(FontAssets.MouseText.Value, Language.GetTextValue("Mods.V2.PredPlayerGoals.GenericText.Header.Title"), new Vector2(1.2f), -1f).X / 2f, 0f), new Vector2(1.2f), -1f, 2f);
			ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, Language.GetTextValue("Mods.V2.PredPlayerGoals.GenericText.Header.Description"), backdropPos + new Vector2((float)_predStatsMenuBackground.Value.Width / 2f - (float)_predStatsGoalsMenuHeader.Value.Width / 2f + 8f, 12f + ChatManager.GetStringSize(FontAssets.MouseText.Value, Language.GetTextValue("Mods.V2.PredPlayerGoals.GenericText.Header.Title"), new Vector2(1.25f), -1f).Y + 2f), Color.White, 0f, Vector2.Zero, new Vector2(0.75f), (float)_predStatsGoalsMenuHeader.Value.Width - 16f, 2f);
			spriteBatch.Draw(_predStatsGoalsMenuFooter.Value, backdropPos + new Vector2((float)_predStatsMenuBackground.Value.Width / 2f - 30f, (float)_predStatsMenuBackground.Value.Height - 10f), (Rectangle?)_predStatsGoalsMenuFooter.Value.Bounds, Color.White, 0f, new Vector2((float)_predStatsGoalsMenuFooter.Value.Width / 2f, (float)_predStatsGoalsMenuFooter.Value.Height), 1f, (SpriteEffects)0, 0f);
			ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, SelectedProgressionStage.FooterAdvice, backdropPos + new Vector2((float)_predStatsMenuBackground.Value.Width / 2f - 30f - (float)_predStatsGoalsMenuFooter.Value.Width / 2f + 8f, (float)(_predStatsMenuBackground.Value.Height - _predStatsGoalsMenuFooter.Value.Height)), Color.White, 0f, Vector2.Zero, new Vector2(0.75f), (float)_predStatsGoalsMenuFooter.Value.Width - 16f, 2f);
			Rectangle sortingClipboardHoverRect = default(Rectangle);
			((Rectangle)(ref sortingClipboardHoverRect))._002Ector((int)backdropPos.X + 644, (int)backdropPos.Y + 154, _predStatsGoalsSortingClipboard.Value.Width, _predStatsGoalsSortingClipboard.Value.Height);
			spriteBatch.Draw(_predStatsGoalsSortingClipboard.Value, backdropPos + new Vector2(644f, 154f), (Rectangle?)(((Rectangle)(ref sortingClipboardHoverRect)).Contains(Utils.ToPoint(Main.MouseScreen)) ? new Rectangle(32, 0, 30, 48) : new Rectangle(0, 0, 30, 48)), Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			if (((Rectangle)(ref sortingClipboardHoverRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
			{
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					SortStyle = Utils.NextEnum<PredGoalsSortingOption>(SortStyle);
					SoundEngine.PlaySound(ref SortStyleChange, (Vector2?)null, (SoundUpdateCallback)null);
				}
				if (Main.mouseRight && Main.mouseRightRelease)
				{
					SortStyle = Utils.PreviousEnum<PredGoalsSortingOption>(SortStyle);
					SoundEngine.PlaySound(ref SortStyleChange, (Vector2?)null, (SoundUpdateCallback)null);
				}
				UICommon.TooltipMouseText(Language.GetTextValueWith("Mods.V2.PredPlayerGoals.SortingText", (object)new
				{
					HeaderColor = Utils.Hex3(V2Colors.Basic.Gold * mouseTextColorFactor),
					DefaultSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.Default) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					AlphabeticalSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.Alphabetical) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					AlphabeticalBackwardsSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.AlphabeticalBackwards) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					PointValueSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.PointValue) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					PointValueBackwardsSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.PointValueBackwards) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					CompletionSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.Completion) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					IncompletionSortColor = Utils.Hex3(((SortStyle == PredGoalsSortingOption.Incompletion) ? V2Colors.Basic.Aqua : V2Colors.Basic.LightGray) * mouseTextColorFactor),
					CycleColor = Utils.Hex3(V2Colors.Basic.Aqua * mouseTextColorFactor)
				}));
			}
			spriteBatch.Draw(_predStatsGoalsMenuExitButton.Value, backdropPos + new Vector2(644f, 394f), (Rectangle?)(((Rectangle)(ref goalsMenuBookRect)).Contains(Utils.ToPoint(Main.MouseScreen)) ? new Rectangle(32, 0, 30, 30) : new Rectangle(0, 0, 30, 30)), Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			if (PredStatsMenuMouthUI.MouthState == 3 && ((Rectangle)(ref goalsMenuBookRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
			{
				Main.instance.MouseText("Return to the main pred stats menu", 0, (byte)0, -1, -1, -1, -1, 0);
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					SoundEngine.PlaySound(ref SoundID.MenuClose, (Vector2?)null, (SoundUpdateCallback)null);
					GoalsMenuOpen = false;
					return;
				}
			}
			if (PredStatsMenuMouthUI.MouthState == 3 && ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)27) && !((KeyboardState)(ref Main.oldKeyState)).IsKeyDown((Keys)27))
			{
				SoundEngine.PlaySound(ref SoundID.MenuClose, (Vector2?)null, (SoundUpdateCallback)null);
				GoalsMenuOpen = false;
			}
			return;
		}
		string hoveredStatSlice = "none";
		spriteBatch.Draw(_predStatsPizzaSlice_GLP.Value, backdropPos + new Vector2(560f, 40f), (Rectangle?)_predStatsPizzaSlice_GLP.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		SliceHoverLogic(new Rectangle(backdropRect.X + 560, backdropRect.Y + 40, _predStatsPizzaSlice_GLP.Value.Width, _predStatsPizzaSlice_GLP.Value.Height), Main.LocalPlayer.AsPred().GLP, "Swallow strength", "GLP");
		spriteBatch.Draw(_predStatsPizzaSlice_TUM.Value, backdropPos + new Vector2(620f, 40f), (Rectangle?)_predStatsPizzaSlice_TUM.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		SliceHoverLogic(new Rectangle(backdropRect.X + 620, backdropRect.Y + 40, _predStatsPizzaSlice_TUM.Value.Width, _predStatsPizzaSlice_TUM.Value.Height), Main.LocalPlayer.AsPred().TUM, "Stomach strength", "TUM");
		spriteBatch.Draw(_predStatsPizzaSlice_ACI.Value, backdropPos + new Vector2(560f, 100f), (Rectangle?)_predStatsPizzaSlice_ACI.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		SliceHoverLogic(new Rectangle(backdropRect.X + 560, backdropRect.Y + 100, _predStatsPizzaSlice_ACI.Value.Width, _predStatsPizzaSlice_ACI.Value.Height), Main.LocalPlayer.AsPred().ACI, "Acid strength", "ACI");
		spriteBatch.Draw(_predStatsPizzaSlice_ABS.Value, backdropPos + new Vector2(620f, 100f), (Rectangle?)_predStatsPizzaSlice_ABS.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		SliceHoverLogic(new Rectangle(backdropRect.X + 620, backdropRect.Y + 100, _predStatsPizzaSlice_ABS.Value.Width, _predStatsPizzaSlice_ABS.Value.Height), Main.LocalPlayer.AsPred().ABS, "Absorption strength", "ABS");
		spriteBatch.Draw(_predStatsOverviewPanel.Value, backdropPos + new Vector2(20f, 20f), (Rectangle?)_predStatsOverviewPanel.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		if (hoveredStatSlice != "none")
		{
			string explainHoveredStatHow = "RelevantStats.Normal";
			if (((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160))
			{
				explainHoveredStatHow = "Description";
			}
			string acidTierKey = "Mods.V2.PredStatsMenu.StatDescription.ACI.AcidTiers.NormalBeta";
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, Language.GetTextValueWith("Mods.V2.PredStatsMenu.StatDescription." + hoveredStatSlice + "." + explainHoveredStatHow, (object)new
			{
				GLPTotal = Main.LocalPlayer.AsPred().GLP.Total,
				GLPSpent = Main.LocalPlayer.AsPred().GLP.Spent,
				GLPBase = Main.LocalPlayer.AsPred().GLP.Base,
				GLPExtra = Main.LocalPlayer.AsPred().GLP.Extra,
				PreySwallowSize = ((Main.LocalPlayer.AsPred().SwallowCapacity != -1.0) ? (Main.LocalPlayer.AsPred().SwallowCapacity.CastToDecimalPlaces(2).ToString() ?? "") : "Infinite"),
				LiquidSwallowRate = ((double)Main.LocalPlayer.AsPred().LiquidSwallowSize / 255.0 * PredPlayer.LiquidSwallowRatePerMinute).CastToDecimalPlaces(2),
				StruggleGracePeriod = Main.LocalPlayer.AsPred().StruggleGraceTimeReadable,
				BaseSwallowSize = PredPlayer.BaseSwallowSize,
				SwallowSizePerLevel = PredPlayer.SwallowSizePerLevel,
				BaseDrinkRate = ((double)PredPlayer.BaseLiquidSwallowSize / 255.0 * 60.0).CastToDecimalPlaces(2),
				DrinkRatePer5Levels = ((double)PredPlayer.LiquidSwallowSizePer5Levels / 255.0 * PredPlayer.LiquidSwallowRatePerMinute).CastToDecimalPlaces(2),
				BaseStruggleGraceTime = PredPlayer.BaseStruggleGraceTime,
				StruggleGraceTimePer5Levels = PredPlayer.StruggleGraceTimePer5Levels,
				TUMTotal = Main.LocalPlayer.AsPred().TUM.Total,
				TUMSpent = Main.LocalPlayer.AsPred().TUM.Spent,
				TUMBase = Main.LocalPlayer.AsPred().TUM.Base,
				TUMExtra = Main.LocalPlayer.AsPred().TUM.Extra,
				StomachCapacity = ((Main.LocalPlayer.AsPred().StomachCapacity != -1.0) ? (Main.LocalPlayer.AsPred().StomachCapacity.CastToDecimalPlaces(2).ToString() ?? "") : "Infinite"),
				StomachacheMeterCapacity = ((Main.LocalPlayer.AsPred().StomachacheMeterCapacity != -1.0) ? (Main.LocalPlayer.AsPred().StomachacheMeterCapacity.CastToDecimalPlaces(2).ToString() ?? "") : "Infinite"),
				StruggleChartEstimatedDifficulty = "Something for me to figure out later",
				BaseStomachCapacity = PredPlayer.BaseStomachCapacity,
				StomachCapacityPerLevel = PredPlayer.StomachCapacityPerLevel,
				BaseStomachacheMeterCapacity = PredPlayer.BaseStomachacheMeterCapacity,
				StomachacheMeterCapacityPer5Levels = PredPlayer.StomachacheMeterCapacityPer5Levels,
				ACITotal = Main.LocalPlayer.AsPred().ACI.Total,
				ACISpent = Main.LocalPlayer.AsPred().ACI.Spent,
				ACIBase = Main.LocalPlayer.AsPred().ACI.Base,
				ACIExtra = Main.LocalPlayer.AsPred().ACI.Extra,
				DigestionDamage = Main.LocalPlayer.AsPred().DigestionTickDamage.CastToDecimalPlaces(2),
				DigestionRate = Main.LocalPlayer.AsPred().DigestionTickRate.CastToDecimalPlaces(2),
				AcidTierWithDescription = Language.GetTextValue(acidTierKey),
				BaseDigestionDamage = PredPlayer.BaseDigestionTickDamage,
				DigestionDamagePerLevel = PredPlayer.DigestionTickDamagePerLevel,
				BaseDigestionRate = PredPlayer.BaseDigestionTickRate,
				DigestionRatePer5Levels = PredPlayer.DigestionTickRatePer5Levels,
				ABSTotal = Main.LocalPlayer.AsPred().ABS.Total,
				ABSSpent = Main.LocalPlayer.AsPred().ABS.Spent,
				ABSBase = Main.LocalPlayer.AsPred().ABS.Base,
				ABSExtra = Main.LocalPlayer.AsPred().ABS.Extra,
				AbsorptionRate = Main.LocalPlayer.AsPred().PreyAbsorptionRate.CastToDecimalPlaces(2),
				BuffExtensionTime = Main.LocalPlayer.AsPred().BuffExtensionFactor.ToPercentage(2),
				DebuffDisextensionTime = (1.0 / Main.LocalPlayer.AsPred().DebuffDisextensionFactor).ToPercentage(2),
				BaseAbsorbRate = PredPlayer.BasePreyAbsorptionRate.CastToDecimalPlaces(2),
				AbsorbRatePerLevel = PredPlayer.PreyAbsorptionRatePerLevel.CastToDecimalPlaces(2),
				BuffExtendPer5Levels = PredPlayer.BuffExtensionTimePer5Levels.CastToDecimalPlaces(2),
				DebuffLossPer5Levels = PredPlayer.DebuffDisextensionTimePer5Levels.CastToDecimalPlaces(2)
			}), backdropPos + new Vector2(30f, 30f), Color.White, 0f, Vector2.Zero, new Vector2(0.8f), 480f, 2f);
		}
		Rectangle availablePointsRect = default(Rectangle);
		((Rectangle)(ref availablePointsRect))._002Ector((int)backdropPos.X + 560, (int)backdropPos.Y + 192, _predStatsAvailablePointsPanel.Value.Width, _predStatsAvailablePointsPanel.Value.Height);
		spriteBatch.Draw(_predStatsAvailablePointsPanel.Value, backdropPos + new Vector2(560f, 192f), (Rectangle?)_predStatsAvailablePointsPanel.Value.Bounds, Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.MouseText.Value, "Points Available", backdropPos + new Vector2(564f, 198f), Color.White, 0f, Vector2.Zero, new Vector2(0.8f), 112f, 2f);
		ChatManager.DrawColorCodedStringWithShadow(Main.spriteBatch, FontAssets.DeathText.Value, Main.LocalPlayer.AsPred().AvailableStatPoints.ToString(), backdropPos + new Vector2(620f, 252f), Color.White, 0f, ChatManager.GetStringSize(FontAssets.DeathText.Value, Main.LocalPlayer.AsPred().AvailableStatPoints.ToString(), new Vector2(0.8f), -1f) / 2f, new Vector2(0.8f), -1f, 2f);
		if (((Rectangle)(ref availablePointsRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
		{
			string mouseText = Language.GetTextValueWith("Mods.V2.PredStatsMenu.StatPointHover.Default", (object)new
			{
				StatPointCount = Main.LocalPlayer.AsPred().AvailableStatPoints,
				StatPointTotal = Main.LocalPlayer.AsPred().TotalStatPoints,
				GLPSpent = Main.LocalPlayer.AsPred().GLP.Spent,
				TUMSpent = Main.LocalPlayer.AsPred().TUM.Spent,
				ACISpent = Main.LocalPlayer.AsPred().ACI.Spent,
				ABSSpent = Main.LocalPlayer.AsPred().ABS.Spent,
				CycleColor = Utils.Hex3(V2Colors.Basic.Aqua * mouseTextColorFactor)
			});
			if (Main.LocalPlayer.AsPred().CheatedStatPointsWork)
			{
				mouseText = mouseText + "\n\n" + Language.GetTextValueWith("Mods.V2.PredStatsMenu.StatPointHover.RoseAddon", (object)new
				{
					RoseFlowerColor = Utils.Hex3(new Color((int)(byte)(255f * mouseTextColorFactor), (int)(byte)(Main.masterColor * 200f * mouseTextColorFactor), 0, (int)Main.mouseTextColor)),
					CheatedPointAllocColor = Utils.Hex3(V2Colors.Basic.Aqua * mouseTextColorFactor),
					CheatedPointModifier = Main.LocalPlayer.AsPred().CheatedStatPoints
				});
			}
			UICommon.TooltipMouseText(mouseText);
			if (Main.LocalPlayer.AsPred().CheatedStatPointsWork && Main.mouseLeft && Main.mouseLeftRelease)
			{
				bool num3 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160);
				bool flag = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162);
				if (!num3)
				{
					if (!flag)
					{
						Main.LocalPlayer.AsPred().CheatedStatPoints++;
					}
					else
					{
						Main.LocalPlayer.AsPred().CheatedStatPoints += Main.LocalPlayer.AsPred().LegitStatPoints;
					}
				}
				else if (!flag)
				{
					Main.LocalPlayer.AsPred().CheatedStatPoints += 10;
				}
				else
				{
					Main.LocalPlayer.AsPred().CheatedStatPoints += 100;
				}
				SoundEngine.PlaySound(ref AllocateSuccess, (Vector2?)null, (SoundUpdateCallback)null);
			}
			else if (Main.LocalPlayer.AsPred().CheatedStatPointsWork && Main.mouseRight && Main.mouseRightRelease)
			{
				if (Main.LocalPlayer.AsPred().CheatedStatPoints <= 0)
				{
					SoundEngine.PlaySound(ref AllocateFail, (Vector2?)null, (SoundUpdateCallback)null);
				}
				else
				{
					bool num4 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160);
					bool flag = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162);
					if (!num4)
					{
						if (!flag)
						{
							Main.LocalPlayer.AsPred().CheatedStatPoints--;
						}
						else
						{
							Main.LocalPlayer.AsPred().CheatedStatPoints -= Math.Min(Main.LocalPlayer.AsPred().LegitStatPoints, Main.LocalPlayer.AsPred().CheatedStatPoints);
						}
					}
					else if (!flag)
					{
						Main.LocalPlayer.AsPred().CheatedStatPoints -= Math.Min(10, Main.LocalPlayer.AsPred().CheatedStatPoints);
					}
					else
					{
						Main.LocalPlayer.AsPred().CheatedStatPoints -= Math.Min(100, Main.LocalPlayer.AsPred().CheatedStatPoints);
					}
					if (Main.LocalPlayer.AsPred().CheatedStatPoints < 0)
					{
						Main.LocalPlayer.AsPred().CheatedStatPoints = 0;
					}
					SoundStyle allocateSuccess = AllocateSuccess;
					((SoundStyle)(ref allocateSuccess)).Pitch = -0.15f;
					SoundEngine.PlaySound(ref allocateSuccess, (Vector2?)null, (SoundUpdateCallback)null);
				}
			}
		}
		spriteBatch.Draw(_predStatsGoalsMenuBook.Value, backdropPos + new Vector2(644f, 394f), (Rectangle?)(((Rectangle)(ref goalsMenuBookRect)).Contains(Utils.ToPoint(Main.MouseScreen)) ? new Rectangle(32, 0, 30, 30) : new Rectangle(0, 0, 30, 30)), Color.White, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
		if (PredStatsMenuMouthUI.MouthState == 3 && ((Rectangle)(ref goalsMenuBookRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
		{
			Main.instance.MouseText("Open the pred goals menu", 0, (byte)0, -1, -1, -1, -1, 0);
			if (Main.mouseLeft && Main.mouseLeftRelease)
			{
				SoundEngine.PlaySound(ref SoundID.MenuOpen, (Vector2?)null, (SoundUpdateCallback)null);
				GoalsMenuOpen = true;
				GoalsPage = 1;
				SelectedProgressionStage = ModContent.GetInstance<StarterStage>();
			}
		}
		spriteBatch.Draw(_predStatsExitButton.Value, backdropPos + new Vector2(350f, 10f), (Rectangle?)_predStatsExitButton.Value.Bounds, Color.White, 0f, new Vector2(29f, 0f), 1f, (SpriteEffects)0, 0f);
		Rectangle exitGulletRect = default(Rectangle);
		((Rectangle)(ref exitGulletRect))._002Ector((int)backdropPos.X + 343, (int)backdropPos.Y + 20, 14, 14);
		if (PredStatsMenuMouthUI.MouthState == 3 && ((Rectangle)(ref exitGulletRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
		{
			Main.instance.MouseText("Close the pred stats menu\n(Are you sure your cursor can't stay a little longer?)", 0, (byte)0, -1, -1, -1, -1, 0);
			if (Main.mouseLeft && Main.mouseLeftRelease)
			{
				PredStatsMenuMouthUI.MouthState = 4;
				PredStatsMenuMouthUI.CanSkipThisFrame = false;
			}
		}
		if (PredStatsMenuMouthUI.MouthState == 3 && ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)27) && !((KeyboardState)(ref Main.oldKeyState)).IsKeyDown((Keys)27))
		{
			PredStatsMenuMouthUI.MouthState = 4;
			PredStatsMenuMouthUI.CanSkipThisFrame = false;
		}
		void SliceHoverLogic(Rectangle sliceRect, PredStat stat, string statFullName, string statShorthand)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			if (PredStatsMenuMouthUI.MouthState == 3 && ((Rectangle)(ref sliceRect)).Contains(Utils.ToPoint(Main.MouseScreen)))
			{
				hoveredStatSlice = statShorthand;
				bool num5 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160);
				bool flag2 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162);
				string pointsAllocationText = ((!num5) ? (flag2 ? "Mods.V2.PredStatsMenu.StatSliceHover.BulkMaximum" : "Mods.V2.PredStatsMenu.StatSliceHover.Default") : (flag2 ? "Mods.V2.PredStatsMenu.StatSliceHover.Bulk100" : "Mods.V2.PredStatsMenu.StatSliceHover.Bulk10"));
				UICommon.TooltipMouseText(Language.GetTextValueWith(pointsAllocationText, (object)new
				{
					PredStatName = statFullName,
					PredStatShorthand = statShorthand,
					SpentPoints = stat.Spent
				}));
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					if (Main.LocalPlayer.AsPred().AvailableStatPoints == 0)
					{
						SoundEngine.PlaySound(ref AllocateFail, (Vector2?)null, (SoundUpdateCallback)null);
					}
					else
					{
						bool num6 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160);
						flag2 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162);
						if (!num6)
						{
							if (!flag2)
							{
								stat.Spent++;
							}
							else
							{
								stat.Spent += Main.LocalPlayer.AsPred().AvailableStatPoints;
							}
						}
						else if (!flag2)
						{
							stat.Spent += Math.Min(10, Main.LocalPlayer.AsPred().AvailableStatPoints);
						}
						else
						{
							stat.Spent += Math.Min(100, Main.LocalPlayer.AsPred().AvailableStatPoints);
						}
						SoundEngine.PlaySound(ref AllocateSuccess, (Vector2?)null, (SoundUpdateCallback)null);
						if (Main.netMode == 1)
						{
							ModPacket packet = ((Mod)V2.Instance).GetPacket(256);
							((BinaryWriter)(object)packet).Write((byte)3);
							((BinaryWriter)(object)packet).Write((byte)Main.myPlayer);
							((BinaryWriter)(object)packet).Write(Main.LocalPlayer.AsPred().GLP.Spent);
							((BinaryWriter)(object)packet).Write(Main.LocalPlayer.AsPred().TUM.Spent);
							((BinaryWriter)(object)packet).Write(Main.LocalPlayer.AsPred().ACI.Spent);
							((BinaryWriter)(object)packet).Write(Main.LocalPlayer.AsPred().ABS.Spent);
							packet.Send(-1, Main.myPlayer);
						}
					}
				}
				else if (Main.mouseRight && Main.mouseRightRelease)
				{
					if (stat.Spent == 0)
					{
						SoundEngine.PlaySound(ref AllocateFail, (Vector2?)null, (SoundUpdateCallback)null);
					}
					else
					{
						bool num7 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)160);
						flag2 = ((KeyboardState)(ref Main.keyState)).IsKeyDown((Keys)162);
						if (!num7)
						{
							if (!flag2)
							{
								stat.Spent--;
							}
							else
							{
								stat.Spent -= stat.Spent;
							}
						}
						else if (!flag2)
						{
							stat.Spent -= Math.Min(10, stat.Spent);
						}
						else
						{
							stat.Spent -= Math.Min(100, stat.Spent);
						}
						SoundStyle allocateSuccess2 = AllocateSuccess;
						((SoundStyle)(ref allocateSuccess2)).Pitch = -0.15f;
						SoundEngine.PlaySound(ref allocateSuccess2, (Vector2?)null, (SoundUpdateCallback)null);
						if (Main.netMode == 1)
						{
							ModPacket packet2 = ((Mod)V2.Instance).GetPacket(256);
							((BinaryWriter)(object)packet2).Write((byte)3);
							((BinaryWriter)(object)packet2).Write((byte)Main.myPlayer);
							((BinaryWriter)(object)packet2).Write(Main.LocalPlayer.AsPred().GLP.Spent);
							((BinaryWriter)(object)packet2).Write(Main.LocalPlayer.AsPred().TUM.Spent);
							((BinaryWriter)(object)packet2).Write(Main.LocalPlayer.AsPred().ACI.Spent);
							((BinaryWriter)(object)packet2).Write(Main.LocalPlayer.AsPred().ABS.Spent);
							packet2.Send(-1, Main.myPlayer);
						}
					}
				}
			}
		}
	}

	static PredStatsMenuUI()
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		SoundStyle val = default(SoundStyle);
		((SoundStyle)(ref val))._002Ector("V2/Sounds/PredStatsMenu/AllocateSuccess", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		AllocateSuccess = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/PredStatsMenu/AllocateFail", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		AllocateFail = val;
		((SoundStyle)(ref val))._002Ector("V2/Sounds/PredStatsMenu/SortStyleChange", (SoundType)0);
		((SoundStyle)(ref val)).MaxInstances = 0;
		((SoundStyle)(ref val)).PitchVariance = 0f;
		SortStyleChange = val;
	}
}
