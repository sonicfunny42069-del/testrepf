using System;
using Microsoft.Xna.Framework;
using Terraria;
using V2.Core;

namespace V2.NPCs.Vanilla.Sky;

public static class HarpyAI
{
	public class ChargingDiveBomb : NPCBehaviorPattern
	{
		public override int PatternLength => 2;

		public override void AI(NPC npc, Entity target)
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
			if (target == null)
			{
				npc.SwitchToPattern<MainFlying>(target);
				npc.netUpdate = true;
				return;
			}
			if (SecondaryTimer >= PatternLength)
			{
				npc.SwitchToPattern<DiveBombing>(target);
				npc.netUpdate = true;
			}
			float weightMovementModifier = ((float)PredNPC.GetCurrentBellyWeight(npc) + (float)npc.AsPred().ExtraWeight) * 0.8f;
			npc.spriteDirection = (((Entity)npc).direction = Utils.ToDirectionInt(target.position.X >= ((Entity)(object)npc).TrueCenter().X));
			Vector2 targetPos = target.TrueCenter();
			targetPos.X += V2Utils.TileCountAsPixelCount(12.5) * -((Entity)npc).direction;
			targetPos.Y -= V2Utils.TileCountAsPixelCount(12.5);
			float horizontalWeightMovementModifier = 1f + 0.4f * weightMovementModifier;
			((Entity)npc).velocity.X += 0.25f / horizontalWeightMovementModifier * (float)Utils.ToDirectionInt(targetPos.X >= ((Entity)(object)npc).TrueCenter().X);
			float maxHorizSpeed = HarpyStuff.Statistics.MaxMoveSpeed / horizontalWeightMovementModifier;
			if (((Entity)npc).velocity.X > maxHorizSpeed)
			{
				((Entity)npc).velocity.X = maxHorizSpeed;
			}
			if (((Entity)npc).velocity.X < 0f - maxHorizSpeed)
			{
				((Entity)npc).velocity.X = 0f - maxHorizSpeed;
			}
			float verticalWeightMovementModifier = 1f + 0.75f * weightMovementModifier;
			((Entity)npc).velocity.Y += 0.06f * verticalWeightMovementModifier;
			if (((Entity)npc).velocity.Y > 0.55f * verticalWeightMovementModifier)
			{
				((Entity)npc).velocity.Y = 0.55f * verticalWeightMovementModifier;
			}
			float wingFlapWeightMovementModifier = 1f + 0.35f * weightMovementModifier;
			float wingFlapExtraModifier = 1f;
			int num = npc.AsHarpy().WingFlapTimer++;
			int num2 = npc.AsPred().GetVisualWeightStage(npc);
			switch (num2)
			{
			case 0:
				num = 50;
				break;
			case 1:
				num = 40;
				break;
			case 2:
				num = 26;
				break;
			case 3:
				num = 14;
				break;
			case 4:
				num = 12;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num2);
				break;
			}
			int minDelay = num;
			num = npc.AsPred().GetVisualWeightStage(npc);
			switch (num)
			{
			case 0:
				num2 = 60;
				break;
			case 1:
				num2 = 50;
				break;
			case 2:
				num2 = 36;
				break;
			case 3:
				num2 = 22;
				break;
			case 4:
				num2 = 14;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num);
				break;
			}
			int flapChanceDenominator = num2;
			if (Utils.Distance(((Entity)(object)npc).TrueCenter(), targetPos) < (float)V2Utils.TileCountAsPixelCount(6.0))
			{
				minDelay = (int)Math.Round((float)minDelay * 0.6f);
				flapChanceDenominator = (int)Math.Round((float)flapChanceDenominator * 0.6f);
				wingFlapExtraModifier = 0.6f;
			}
			if (npc.AsHarpy().WingFlapTimer >= minDelay && Utils.NextBool(Main.rand, flapChanceDenominator) && ((Entity)npc).position.Y > targetPos.Y)
			{
				npc.AsHarpy().WingFlapTimer = -4;
			}
			else if (npc.AsHarpy().WingFlapTimer == 0)
			{
				if (Utils.Distance(((Entity)(object)npc).TrueCenter(), targetPos) < (float)V2Utils.TileCountAsPixelCount(6.0))
				{
					SecondaryTimer++;
				}
				((Entity)npc).velocity.Y = -3.2f / (wingFlapWeightMovementModifier * 0.8f) * wingFlapExtraModifier;
			}
		}
	}

	public class DiveBombing : NPCBehaviorPattern
	{
		public override int PatternLength => HarpyStuff.Statistics.DiveBombLength;

		public override void AI(NPC npc, Entity target)
		{
			if (target == null)
			{
				npc.SwitchToPattern<MainFlying>(target);
				npc.netUpdate = true;
			}
			else if (PatternTimer >= PatternLength)
			{
				npc.AsHarpy().WingFlapTimer = -4;
				npc.SwitchToPattern<RecoveringFromDiveBomb>(target);
				npc.netUpdate = true;
			}
			else
			{
				((Entity)npc).velocity.X = 5f * (float)((Entity)npc).direction;
				((Entity)npc).velocity.Y = 5f;
			}
		}
	}

	public class MainFlying : NPCBehaviorPattern
	{
		public override int PatternLength => -1;

		public override void AI(NPC npc, Entity target)
		{
			if (target != null)
			{
				npc.SwitchToPattern<ChargingDiveBomb>(target);
				npc.AsV2NPC().BehaviorPattern.SecondaryTimer = 0;
				npc.netUpdate = true;
				return;
			}
			float weightMovementModifier = ((float)PredNPC.GetCurrentBellyWeight(npc) + (float)npc.AsPred().ExtraWeight) * 0.8f;
			npc.AsHarpy().DirectionChangeTimer++;
			if (npc.AsHarpy().DirectionChangeTimer > 0 && Utils.NextBool(Main.rand, 180))
			{
				npc.AsHarpy().DirectionChangeTimer = -V2Utils.SensibleTime(0, 0, 3);
				((Entity)npc).direction = ((Entity)npc).direction * -1;
			}
			float horizontalWeightMovementModifier = 1f + 0.4f * weightMovementModifier;
			((Entity)npc).velocity.X += 0.2f / horizontalWeightMovementModifier * (float)((Entity)npc).direction;
			float maxHorizSpeed = HarpyStuff.Statistics.MaxMoveSpeed / horizontalWeightMovementModifier;
			if (((Entity)npc).velocity.X > maxHorizSpeed)
			{
				((Entity)npc).velocity.X = maxHorizSpeed;
			}
			if (((Entity)npc).velocity.X < 0f - maxHorizSpeed)
			{
				((Entity)npc).velocity.X = 0f - maxHorizSpeed;
			}
			float verticalWeightMovementModifier = 1f + 0.75f * weightMovementModifier;
			((Entity)npc).velocity.Y += 0.06f * verticalWeightMovementModifier;
			if (((Entity)npc).velocity.Y > 0.55f * verticalWeightMovementModifier)
			{
				((Entity)npc).velocity.Y = 0.55f * verticalWeightMovementModifier;
			}
			float wingFlapWeightMovementModifier = 1f + 0.35f * weightMovementModifier;
			int num = npc.AsHarpy().WingFlapTimer++;
			int num2 = npc.AsPred().GetVisualWeightStage(npc);
			switch (num2)
			{
			case 0:
				num = 60;
				break;
			case 1:
				num = 50;
				break;
			case 2:
				num = 36;
				break;
			case 3:
				num = 22;
				break;
			case 4:
				num = 14;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num2);
				break;
			}
			int minDelay = num;
			num = npc.AsPred().GetVisualWeightStage(npc);
			switch (num)
			{
			case 0:
				num2 = 60;
				break;
			case 1:
				num2 = 50;
				break;
			case 2:
				num2 = 36;
				break;
			case 3:
				num2 = 22;
				break;
			case 4:
				num2 = 14;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num);
				break;
			}
			int flapChance = num2;
			if (npc.AsHarpy().WingFlapTimer >= minDelay && Utils.NextBool(Main.rand, flapChance))
			{
				npc.AsHarpy().WingFlapTimer = -4;
			}
			else if (npc.AsHarpy().WingFlapTimer == 0)
			{
				((Entity)npc).velocity.Y = -3.2f / (wingFlapWeightMovementModifier * 0.8f);
			}
		}
	}

	public class RecoveringFromDiveBomb : NPCBehaviorPattern
	{
		public override int PatternLength => HarpyStuff.Statistics.DiveBombRecoveryLength;

		public override void AI(NPC npc, Entity target)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			if (PatternTimer >= PatternLength)
			{
				npc.SwitchToPattern<MainFlying>(target);
				npc.netUpdate = true;
				return;
			}
			((Entity)npc).velocity = ((Entity)npc).velocity * 0.97f;
			float weightMovementModifier = ((float)PredNPC.GetCurrentBellyWeight(npc) + (float)npc.AsPred().ExtraWeight) * 0.8f;
			float verticalWeightMovementModifier = 1f + 0.75f * weightMovementModifier;
			((Entity)npc).velocity.Y += 0.04f * verticalWeightMovementModifier;
			if (((Entity)npc).velocity.Y > 0.55f * verticalWeightMovementModifier)
			{
				((Entity)npc).velocity.Y = 0.55f * verticalWeightMovementModifier;
			}
			float wingFlapWeightMovementModifier = 1f + 0.35f * weightMovementModifier;
			int num = npc.AsHarpy().WingFlapTimer++;
			int num2 = npc.AsPred().GetVisualWeightStage(npc);
			switch (num2)
			{
			case 0:
				num = 80;
				break;
			case 1:
				num = 65;
				break;
			case 2:
				num = 50;
				break;
			case 3:
				num = 35;
				break;
			case 4:
				num = 20;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num2);
				break;
			}
			int minDelay = num;
			num = npc.AsPred().GetVisualWeightStage(npc);
			switch (num)
			{
			case 0:
				num2 = 80;
				break;
			case 1:
				num2 = 70;
				break;
			case 2:
				num2 = 60;
				break;
			case 3:
				num2 = 50;
				break;
			case 4:
				num2 = 40;
				break;
			default:
				global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(num);
				break;
			}
			int flapChance = num2;
			if (npc.AsHarpy().WingFlapTimer >= minDelay && Utils.NextBool(Main.rand, flapChance))
			{
				npc.AsHarpy().WingFlapTimer = -4;
			}
			else if (npc.AsHarpy().WingFlapTimer == 0)
			{
				((Entity)npc).velocity.Y = -3.2f / (wingFlapWeightMovementModifier * 0.8f);
			}
		}
	}
}
