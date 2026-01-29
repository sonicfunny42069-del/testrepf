using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using V2.NPCs;

namespace V2.Core;

public static class V2CommonDropRules
{
	public class DifficultyScalingDrop : IItemDropRule, INestedItemDropRule
	{
		public IItemDropRule ruleForNormalMode;

		public IItemDropRule ruleForExpertMode;

		public IItemDropRule ruleForMasterMode;

		public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

		public DifficultyScalingDrop(IItemDropRule ruleForNormalMode, IItemDropRule ruleForExpertMode, IItemDropRule ruleForMasterMode)
		{
			this.ruleForNormalMode = ruleForNormalMode;
			this.ruleForExpertMode = ruleForExpertMode;
			this.ruleForMasterMode = ruleForMasterMode;
			ChainedRules = new List<IItemDropRuleChainAttempt>();
		}

		public bool CanDrop(DropAttemptInfo info)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			if (info.IsMasterMode)
			{
				return ruleForMasterMode.CanDrop(info);
			}
			if (info.IsExpertMode)
			{
				return ruleForExpertMode.CanDrop(info);
			}
			return ruleForNormalMode.CanDrop(info);
		}

		public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			if (info.IsMasterMode)
			{
				return ruleForMasterMode.TryDroppingItem(info);
			}
			if (info.IsExpertMode)
			{
				return ruleForExpertMode.TryDroppingItem(info);
			}
			return ruleForNormalMode.TryDroppingItem(info);
		}

		public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info, ItemDropRuleResolveAction resolveAction)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			if (info.IsMasterMode)
			{
				return resolveAction.Invoke(ruleForMasterMode, info);
			}
			if (info.IsExpertMode)
			{
				return resolveAction.Invoke(ruleForExpertMode, info);
			}
			return resolveAction.Invoke(ruleForNormalMode, info);
		}

		public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			DropRateInfoChainFeed masterRatesInfo = ((DropRateInfoChainFeed)(ref ratesInfo)).With(1f);
			((DropRateInfoChainFeed)(ref masterRatesInfo)).AddCondition((IItemDropRuleCondition)new IsMasterMode());
			ruleForMasterMode.ReportDroprates(drops, masterRatesInfo);
			DropRateInfoChainFeed expertRatesInfo = ((DropRateInfoChainFeed)(ref ratesInfo)).With(1f);
			((DropRateInfoChainFeed)(ref expertRatesInfo)).AddCondition((IItemDropRuleCondition)new IsExpert());
			((DropRateInfoChainFeed)(ref expertRatesInfo)).AddCondition((IItemDropRuleCondition)new NotMasterMode());
			ruleForExpertMode.ReportDroprates(drops, expertRatesInfo);
			DropRateInfoChainFeed normalRatesInfo = ((DropRateInfoChainFeed)(ref ratesInfo)).With(1f);
			((DropRateInfoChainFeed)(ref normalRatesInfo)).AddCondition((IItemDropRuleCondition)new NotExpert());
			ruleForNormalMode.ReportDroprates(drops, normalRatesInfo);
			Chains.ReportDroprates(ChainedRules, 1f, drops, ratesInfo);
		}
	}

	public class RerollsBasedOnWeightLevelRule : CommonDrop
	{
		public int minimumWeightLevel;

		public RerollsBasedOnWeightLevelRule(int itemId, int chanceDenominator, int amountDroppedMinimum = 1, int amountDroppedMaximum = 1, int chanceNumerator = 1, int minimumWeightLevel = 0)
			: base(itemId, chanceDenominator, amountDroppedMinimum, amountDroppedMaximum, chanceNumerator)
		{
			this.minimumWeightLevel = minimumWeightLevel;
		}

		public override ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			bool flag = false;
			if (info.npc.AsPred().GetVisualWeightStage != null && info.npc.AsPred().GetVisualWeightStage(info.npc) >= minimumWeightLevel)
			{
				for (int i = 0; i < info.npc.AsPred().GetVisualWeightStage(info.npc) - minimumWeightLevel; i++)
				{
					flag = true;
				}
			}
			if (flag)
			{
				CommonCode.DropItem(info, base.itemId, info.rng.Next(base.amountDroppedMinimum, base.amountDroppedMaximum + 1), false);
				return new ItemDropAttemptResult
				{
					State = (ItemDropAttemptResultState)2
				};
			}
			return new ItemDropAttemptResult
			{
				State = (ItemDropAttemptResultState)1
			};
		}

		public override void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			float num = (float)base.chanceNumerator / (float)base.chanceDenominator;
			float num2 = 1f - num;
			float num3 = 1f;
			for (int i = 0; i < 1; i++)
			{
				num3 *= num2;
			}
			float num4 = 1f - num3;
			float dropRate = num4 * ratesInfo.parentDroprateChance;
			drops.Add(new DropRateInfo(base.itemId, base.amountDroppedMinimum, base.amountDroppedMaximum, dropRate, ratesInfo.conditions));
			Chains.ReportDroprates(((CommonDrop)this).ChainedRules, num4, drops, ratesInfo);
		}
	}
}
