using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using V2.Core.StruggleSystem;
using V2.NPCs;
using V2.PlayerHandling;
using V2.Projectiles;

namespace V2.Core;

public class VoreTracker
{
	public static double MaximumNoteProximityRatio => 10.0;

	public double StruggleChartProgressRate { get; set; }

	public double StruggleChartProgress { get; set; }

	public Entity Predator { get; internal set; }

	public PredType PredatorType
	{
		get
		{
			if (Predator is Player)
			{
				return PredType.Player;
			}
			if (Predator is NPC)
			{
				return PredType.NPC;
			}
			if (Predator is Projectile)
			{
				return PredType.Projectile;
			}
			return PredType.Undefined;
		}
	}

	public List<PreyData> Prey { get; internal set; }

	public List<PreyData> PreyQueue { get; internal set; }

	public StruggleChart PredatorStruggleChart { get; internal set; }

	public int TotalPreySTR
	{
		get
		{
			int STR = 0;
			if (Prey != null && Prey.Count > 0)
			{
				foreach (PreyData prey in Prey)
				{
					if (prey != null && !prey.NoHealth && prey.Instance != null)
					{
						switch (prey.Type)
						{
						case PreyType.Player:
						{
							int num3 = STR;
							Entity instance3 = prey.Instance;
							STR = num3 + ((Player)(object)((instance3 is Player) ? instance3 : null)).AsFood().STR.Total;
							break;
						}
						case PreyType.NPC:
						{
							int num2 = STR;
							Entity instance2 = prey.Instance;
							STR = num2 + ((NPC)(object)((instance2 is NPC) ? instance2 : null)).AsFood().STR;
							break;
						}
						case PreyType.Projectile:
						{
							int num = STR;
							Entity instance = prey.Instance;
							STR = num + ((Projectile)(object)((instance is Projectile) ? instance : null)).AsFood().STR;
							break;
						}
						}
					}
				}
			}
			if (PreyQueue != null && PreyQueue.Count > 0)
			{
				foreach (PreyData prey2 in PreyQueue)
				{
					if (prey2 != null && !prey2.NoHealth && prey2.Instance != null)
					{
						switch (prey2.Type)
						{
						case PreyType.Player:
						{
							int num6 = STR;
							Entity instance6 = prey2.Instance;
							STR = num6 + ((Player)(object)((instance6 is Player) ? instance6 : null)).AsFood().STR.Total;
							break;
						}
						case PreyType.NPC:
						{
							int num5 = STR;
							Entity instance5 = prey2.Instance;
							STR = num5 + ((NPC)(object)((instance5 is NPC) ? instance5 : null)).AsFood().STR;
							break;
						}
						case PreyType.Projectile:
						{
							int num4 = STR;
							Entity instance4 = prey2.Instance;
							STR = num4 + ((Projectile)(object)((instance4 is Projectile) ? instance4 : null)).AsFood().STR;
							break;
						}
						}
					}
				}
			}
			return STR;
		}
	}

	public static void NewTracker(Entity pred, List<PreyData> prey)
	{
		VoreTracker tracker = new VoreTracker();
		tracker.Predator = pred;
		tracker.Prey = prey;
		tracker.PreyQueue = new List<PreyData>();
		ModContent.GetInstance<V2MasterSystem>().VoreTrackers.Add(tracker);
		if (Main.netMode == 0)
		{
			tracker.RefreshStruggleChartList();
		}
	}

	public void QueueNewPrey(PreyData prey)
	{
		PreyQueue.Add(prey);
	}

	public void RefreshStruggleChartList()
	{
		if (Prey.FirstOrDefault((PreyData x) => !x.NoHealth && x.Type != PreyType.Item) == null)
		{
			return;
		}
		StruggleChartProgress = -2.0;
		Entity predator = Predator;
		Player predPlayer = (Player)(object)((predator is Player) ? predator : null);
		if (predPlayer != null)
		{
			StruggleChartProgress = 0.0 - predPlayer.AsPred().StruggleGraceTime;
		}
		StruggleChartProgressRate = 1.75 / (double)V2Utils.SensibleTime(0, 0, 1);
		PredatorStruggleChart = new ProceduralStruggleChart();
		PredatorStruggleChart.ConnectedTracker = this;
		PredatorStruggleChart.ForPredator = true;
		PredatorStruggleChart.OnStartup();
		foreach (PreyData prey in Prey)
		{
			if (prey.NoHealth)
			{
				prey.AssignedStruggleChart = null;
				continue;
			}
			switch (prey.Type)
			{
			case PreyType.Player:
				prey.AssignedStruggleChart = new ProceduralStruggleChart();
				prey.AssignedStruggleChart.ConnectedTracker = this;
				prey.AssignedStruggleChart.ForPredator = false;
				prey.AssignedStruggleChart.OnStartup();
				break;
			case PreyType.NPC:
				prey.AssignedStruggleChart = new ProceduralStruggleChart();
				prey.AssignedStruggleChart.ConnectedTracker = this;
				prey.AssignedStruggleChart.ForPredator = false;
				prey.AssignedStruggleChart.OnStartup();
				break;
			case PreyType.Projectile:
				prey.AssignedStruggleChart = new ProceduralStruggleChart();
				prey.AssignedStruggleChart.ConnectedTracker = this;
				prey.AssignedStruggleChart.ForPredator = false;
				prey.AssignedStruggleChart.OnStartup();
				break;
			}
		}
	}

	public void UpdateProgress()
	{
		if (PredatorStruggleChart == null)
		{
			StruggleChartProgress = -1.0;
			return;
		}
		StruggleChartProgress += StruggleChartProgressRate;
		if (StruggleChartProgress > (double)PredatorStruggleChart.Notes.Count + 2.0)
		{
			StruggleChartProgress -= (double)PredatorStruggleChart.Notes.Count + 4.0;
		}
	}

	public void UpdatePrey()
	{
		if (!Predator.active)
		{
			return;
		}
		if (PreyQueue.Count > 0)
		{
			Prey = Prey.Concat(PreyQueue).ToList();
			PreyQueue.Clear();
			if (Main.netMode == 0)
			{
				RefreshStruggleChartList();
			}
		}
		if (Prey.FirstOrDefault((PreyData x) => !x.NoHealth) == null)
		{
			PredatorStruggleChart = null;
		}
		Prey.RemoveAll((PreyData x) => x.NoHealth && x.WeightLeftToDigest <= 0.0);
		if (Prey.Count <= 0)
		{
			return;
		}
		foreach (PreyData item in Prey)
		{
			item.timeSpentInStomach++;
		}
		Entity predator = Predator;
		Player predPlayer = (Player)(object)((predator is Player) ? predator : null);
		if (predPlayer != null)
		{
			PredPlayer.UpdatePrey(predPlayer);
			return;
		}
		Entity predator2 = Predator;
		NPC predNPC = (NPC)(object)((predator2 is NPC) ? predator2 : null);
		if (predNPC != null)
		{
			PredNPC.UpdatePrey(predNPC);
			return;
		}
		Entity predator3 = Predator;
		Projectile predProjectile = (Projectile)(object)((predator3 is Projectile) ? predator3 : null);
		if (predProjectile != null)
		{
			PredProjectile.UpdatePrey(predProjectile);
		}
	}

	public void HandleStruggleSystem()
	{
		if (Main.netMode != 0 || PredatorStruggleChart == null)
		{
			return;
		}
		PredatorStruggleChart.RefreshPressedNotes();
		foreach (PreyData prey in Prey)
		{
			if (!prey.NoHealth && prey.AssignedStruggleChart != null)
			{
				prey.AssignedStruggleChart.RefreshPressedNotes();
			}
		}
		List<(StruggleChartNote, double)> closeNotes = CheckCloseNotes(-1);
		if (Predator is Player)
		{
			if (V2.StruggleUpHotkey.JustPressed)
			{
				(StruggleChartNote, double) noteData = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Up);
				if (noteData.Item1 != null)
				{
					double absoluteProximity = Math.Abs(noteData.Item2);
					double proximityEffectivenessMultiplier = (MaximumNoteProximityRatio - absoluteProximity) / MaximumNoteProximityRatio;
					ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier / PredatorStruggleChart.DifficultyCoeff);
					SignifyNotePressed(noteData);
				}
				else
				{
					ModifyPredStomachacheMeter(1.0);
				}
			}
			if (V2.StruggleDownHotkey.JustPressed)
			{
				(StruggleChartNote, double) noteData2 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Down);
				if (noteData2.Item1 != null)
				{
					double absoluteProximity2 = Math.Abs(noteData2.Item2);
					double proximityEffectivenessMultiplier2 = (MaximumNoteProximityRatio - absoluteProximity2) / MaximumNoteProximityRatio;
					ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier2 / PredatorStruggleChart.DifficultyCoeff);
					SignifyNotePressed(noteData2);
				}
				else
				{
					ModifyPredStomachacheMeter(1.0);
				}
			}
			if (V2.StruggleLeftHotkey.JustPressed)
			{
				(StruggleChartNote, double) noteData3 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Left);
				if (noteData3.Item1 != null)
				{
					double absoluteProximity3 = Math.Abs(noteData3.Item2);
					double proximityEffectivenessMultiplier3 = (MaximumNoteProximityRatio - absoluteProximity3) / MaximumNoteProximityRatio;
					ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier3 / PredatorStruggleChart.DifficultyCoeff);
					SignifyNotePressed(noteData3);
				}
				else
				{
					ModifyPredStomachacheMeter(1.0);
				}
			}
			if (V2.StruggleRightHotkey.JustPressed)
			{
				(StruggleChartNote, double) noteData4 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Right);
				if (noteData4.Item1 != null)
				{
					double absoluteProximity4 = Math.Abs(noteData4.Item2);
					double proximityEffectivenessMultiplier4 = (MaximumNoteProximityRatio - absoluteProximity4) / MaximumNoteProximityRatio;
					ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier4 / PredatorStruggleChart.DifficultyCoeff);
					SignifyNotePressed(noteData4);
				}
				else
				{
					ModifyPredStomachacheMeter(1.0);
				}
			}
			if (V2.StruggleSpecialHotkey.JustPressed)
			{
				(StruggleChartNote, double) noteData5 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Special);
				if (noteData5.Item1 != null)
				{
					double absoluteProximity5 = Math.Abs(noteData5.Item2);
					double proximityEffectivenessMultiplier5 = (MaximumNoteProximityRatio - absoluteProximity5) / MaximumNoteProximityRatio;
					ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier5 / PredatorStruggleChart.DifficultyCoeff);
					SignifyNotePressed(noteData5);
				}
				else
				{
					ModifyPredStomachacheMeter(1.0);
				}
			}
		}
		else
		{
			Entity predator = Predator;
			NPC npcPredator = (NPC)(object)((predator is NPC) ? predator : null);
			if (npcPredator != null)
			{
				int counterSkill = npcPredator.AsPred().CounterStruggleEffectiveness;
				if (closeNotes != null)
				{
					foreach (var noteData6 in closeNotes)
					{
						double absoluteProximity6 = Math.Abs(noteData6.Item2);
						double proximityEffectivenessMultiplier6 = (MaximumNoteProximityRatio - absoluteProximity6) / MaximumNoteProximityRatio;
						switch (counterSkill)
						{
						case 1:
							if (!(absoluteProximity6 > MaximumNoteProximityRatio))
							{
								if (Utils.NextBool(Main.rand, 35) && Math.Abs(noteData6.Item2) < MaximumNoteProximityRatio && !noteData6.Item1.Failed)
								{
									ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier6 / PredatorStruggleChart.DifficultyCoeff);
									SignifyNotePressed(noteData6);
								}
								else
								{
									ModifyPredStomachacheMeter(0.4);
									noteData6.Item1.Failed = true;
								}
							}
							continue;
						case 0:
						case 2:
						case 3:
						case 4:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
						case 11:
						case 12:
							continue;
						}
						if (!(absoluteProximity6 >= MaximumNoteProximityRatio))
						{
							if (absoluteProximity6 > 4.0 && Utils.NextBool(Main.rand, 20))
							{
								ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier6 / PredatorStruggleChart.DifficultyCoeff);
								SignifyNotePressed(noteData6);
							}
							if (4.0 >= absoluteProximity6 && absoluteProximity6 > 3.0 && Utils.NextBool(Main.rand, 15))
							{
								ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier6 / PredatorStruggleChart.DifficultyCoeff);
								SignifyNotePressed(noteData6);
							}
							if (3.0 >= absoluteProximity6 && absoluteProximity6 > 2.0 && Utils.NextBool(Main.rand, 12))
							{
								ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier6 / PredatorStruggleChart.DifficultyCoeff);
								SignifyNotePressed(noteData6);
							}
							if (2.0 >= absoluteProximity6 && absoluteProximity6 > 1.0 && Utils.NextBool(Main.rand, 10))
							{
								ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier6 / PredatorStruggleChart.DifficultyCoeff);
								SignifyNotePressed(noteData6);
							}
							if (1.0 >= absoluteProximity6 && Utils.NextBool(Main.rand, 8))
							{
								ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier6 / PredatorStruggleChart.DifficultyCoeff);
								SignifyNotePressed(noteData6);
							}
						}
					}
				}
			}
			else
			{
				Entity predator2 = Predator;
				Projectile projectilePredator = (Projectile)(object)((predator2 is Projectile) ? predator2 : null);
				if (projectilePredator != null)
				{
					int counterSkill2 = projectilePredator.AsPred().CounterStruggleEffectiveness;
					if (closeNotes != null)
					{
						foreach (var noteData7 in closeNotes)
						{
							double absoluteProximity7 = Math.Abs(noteData7.Item2);
							double proximityEffectivenessMultiplier7 = (MaximumNoteProximityRatio - absoluteProximity7) / MaximumNoteProximityRatio;
							switch (counterSkill2)
							{
							case 1:
								if (!(absoluteProximity7 > MaximumNoteProximityRatio))
								{
									if (Utils.NextBool(Main.rand, 35) && Math.Abs(noteData7.Item2) < MaximumNoteProximityRatio && !noteData7.Item1.Failed)
									{
										ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier7 / PredatorStruggleChart.DifficultyCoeff);
										SignifyNotePressed(noteData7);
									}
									else
									{
										ModifyPredStomachacheMeter(0.4);
										noteData7.Item1.Failed = true;
									}
								}
								continue;
							case 0:
							case 2:
							case 3:
							case 4:
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
								continue;
							}
							if (!(absoluteProximity7 >= MaximumNoteProximityRatio))
							{
								if (absoluteProximity7 > 4.0 && Utils.NextBool(Main.rand, 20))
								{
									ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier7 / PredatorStruggleChart.DifficultyCoeff);
									SignifyNotePressed(noteData7);
								}
								if (4.0 >= absoluteProximity7 && absoluteProximity7 > 3.0 && Utils.NextBool(Main.rand, 15))
								{
									ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier7 / PredatorStruggleChart.DifficultyCoeff);
									SignifyNotePressed(noteData7);
								}
								if (3.0 >= absoluteProximity7 && absoluteProximity7 > 2.0 && Utils.NextBool(Main.rand, 12))
								{
									ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier7 / PredatorStruggleChart.DifficultyCoeff);
									SignifyNotePressed(noteData7);
								}
								if (2.0 >= absoluteProximity7 && absoluteProximity7 > 1.0 && Utils.NextBool(Main.rand, 10))
								{
									ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier7 / PredatorStruggleChart.DifficultyCoeff);
									SignifyNotePressed(noteData7);
								}
								if (1.0 >= absoluteProximity7 && Utils.NextBool(Main.rand, 8))
								{
									ModifyPredStomachacheMeter((0.0 - (double)TotalPreySTR * 0.96) * proximityEffectivenessMultiplier7 / PredatorStruggleChart.DifficultyCoeff);
									SignifyNotePressed(noteData7);
								}
							}
						}
					}
				}
			}
		}
		int num;
		if (PredatorType == PredType.NPC)
		{
			Entity predator3 = Predator;
			num = ((((NPC)((predator3 is NPC) ? predator3 : null)).type == 636) ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		bool predEmpress = (byte)num != 0;
		for (int i = 0; i < Prey.Count; i++)
		{
			PreyData prey2 = Prey[i];
			if (prey2.NoHealth || prey2.AssignedStruggleChart == null)
			{
				continue;
			}
			closeNotes = CheckCloseNotes(i);
			Entity preyEntity = prey2.Instance;
			if (preyEntity is Player)
			{
				if (V2.StruggleUpHotkey.JustPressed)
				{
					(StruggleChartNote, double) noteData8 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Up);
					if (noteData8.Item1 != null)
					{
						double absoluteProximity8 = Math.Abs(noteData8.Item2);
						double proximityEffectivenessMultiplier8 = (MaximumNoteProximityRatio - absoluteProximity8) / MaximumNoteProximityRatio;
						if (predEmpress)
						{
							proximityEffectivenessMultiplier8 *= 500.0;
						}
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier8 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData8);
					}
					else
					{
						ModifyPredStomachacheMeter(-0.9);
					}
				}
				if (V2.StruggleDownHotkey.JustPressed)
				{
					(StruggleChartNote, double) noteData9 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Down);
					if (noteData9.Item1 != null)
					{
						double absoluteProximity9 = Math.Abs(noteData9.Item2);
						double proximityEffectivenessMultiplier9 = (MaximumNoteProximityRatio - absoluteProximity9) / MaximumNoteProximityRatio;
						if (predEmpress)
						{
							proximityEffectivenessMultiplier9 *= 500.0;
						}
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier9 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData9);
					}
					else
					{
						ModifyPredStomachacheMeter(-0.9);
					}
				}
				if (V2.StruggleLeftHotkey.JustPressed)
				{
					(StruggleChartNote, double) noteData10 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Left);
					if (noteData10.Item1 != null)
					{
						double absoluteProximity10 = Math.Abs(noteData10.Item2);
						double proximityEffectivenessMultiplier10 = (MaximumNoteProximityRatio - absoluteProximity10) / MaximumNoteProximityRatio;
						if (predEmpress)
						{
							proximityEffectivenessMultiplier10 *= 500.0;
						}
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier10 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData10);
					}
					else
					{
						ModifyPredStomachacheMeter(-0.9);
					}
				}
				if (V2.StruggleRightHotkey.JustPressed)
				{
					(StruggleChartNote, double) noteData11 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Right);
					if (noteData11.Item1 != null)
					{
						double absoluteProximity11 = Math.Abs(noteData11.Item2);
						double proximityEffectivenessMultiplier11 = (MaximumNoteProximityRatio - absoluteProximity11) / MaximumNoteProximityRatio;
						if (predEmpress)
						{
							proximityEffectivenessMultiplier11 *= 500.0;
						}
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier11 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData11);
					}
					else
					{
						ModifyPredStomachacheMeter(-0.9);
					}
				}
				if (!V2.StruggleSpecialHotkey.JustPressed)
				{
					continue;
				}
				(StruggleChartNote, double) noteData12 = closeNotes.FirstOrDefault<(StruggleChartNote, double)>(((StruggleChartNote note, double proximity) x) => x.note.Lane == NoteLane.Special);
				if (noteData12.Item1 != null)
				{
					double absoluteProximity12 = Math.Abs(noteData12.Item2);
					double proximityEffectivenessMultiplier12 = (MaximumNoteProximityRatio - absoluteProximity12) / MaximumNoteProximityRatio;
					if (predEmpress)
					{
						proximityEffectivenessMultiplier12 *= 500.0;
					}
					ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier12 / prey2.AssignedStruggleChart.DifficultyCoeff);
					SignifyNotePressed(noteData12);
				}
				else
				{
					ModifyPredStomachacheMeter(-0.9);
				}
				continue;
			}
			NPC npcPrey = (NPC)(object)((preyEntity is NPC) ? preyEntity : null);
			if (npcPrey == null)
			{
				continue;
			}
			int struggleSkill = npcPrey.AsFood().StruggleEffectiveness;
			if (closeNotes == null)
			{
				continue;
			}
			bool preyEmpress = npcPrey.type == 636;
			foreach (var noteData13 in closeNotes)
			{
				double absoluteProximity13 = Math.Abs(noteData13.Item2);
				double proximityEffectivenessMultiplier13 = (MaximumNoteProximityRatio - absoluteProximity13) / MaximumNoteProximityRatio;
				if (preyEmpress)
				{
					proximityEffectivenessMultiplier13 /= 500.0;
				}
				if (predEmpress)
				{
					proximityEffectivenessMultiplier13 *= 500.0;
				}
				switch (struggleSkill)
				{
				case 1:
					if (!(absoluteProximity13 > MaximumNoteProximityRatio))
					{
						if (Utils.NextBool(Main.rand, 35) && Math.Abs(noteData13.Item2) < MaximumNoteProximityRatio && !noteData13.Item1.Failed)
						{
							ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier13 / prey2.AssignedStruggleChart.DifficultyCoeff);
							SignifyNotePressed(noteData13);
						}
						else
						{
							ModifyPredStomachacheMeter(0.4);
							noteData13.Item1.Failed = true;
						}
					}
					continue;
				case 0:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
					continue;
				}
				if (!(absoluteProximity13 > MaximumNoteProximityRatio))
				{
					if (absoluteProximity13 > 4.0 && Utils.NextBool(Main.rand, 20))
					{
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier13 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData13);
					}
					if (4.0 >= absoluteProximity13 && absoluteProximity13 > 3.0 && Utils.NextBool(Main.rand, 15))
					{
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier13 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData13);
					}
					if (3.0 >= absoluteProximity13 && absoluteProximity13 > 2.0 && Utils.NextBool(Main.rand, 12))
					{
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier13 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData13);
					}
					if (2.0 >= absoluteProximity13 && absoluteProximity13 > 1.0 && Utils.NextBool(Main.rand, 10))
					{
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier13 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData13);
					}
					if (1.0 >= absoluteProximity13 && Utils.NextBool(Main.rand, 8))
					{
						ModifyPredStomachacheMeter(preyEntity.StruggleStrength() * proximityEffectivenessMultiplier13 / prey2.AssignedStruggleChart.DifficultyCoeff);
						SignifyNotePressed(noteData13);
					}
				}
			}
		}
		static void SignifyNotePressed((StruggleChartNote note, double proximity) tuple)
		{
			tuple.note.CorrectlyPressed = true;
			tuple.note.PressedPosition = tuple.proximity;
		}
	}

	public void ModifyPredStomachacheMeter(double amount)
	{
		switch (PredatorType)
		{
		case PredType.Player:
		{
			Entity predator3 = Predator;
			Player player = (Player)(object)((predator3 is Player) ? predator3 : null);
			amount -= (double)player.AsPred().StomachacheDefense.Base;
			amount /= (double)((StatModifier)(ref player.AsPred().StomachacheDefense)).Additive;
			amount /= (double)((StatModifier)(ref player.AsPred().StomachacheDefense)).Multiplicative;
			amount -= (double)player.AsPred().StomachacheDefense.Flat;
			player.AsPred().Stomachache += amount;
			break;
		}
		case PredType.NPC:
		{
			Entity predator2 = Predator;
			((NPC)(object)((predator2 is NPC) ? predator2 : null)).AsPred().Stomachache += amount;
			break;
		}
		case PredType.Projectile:
		{
			Entity predator = Predator;
			((Projectile)(object)((predator is Projectile) ? predator : null)).AsPred().Stomachache += amount;
			break;
		}
		}
	}

	public List<(StruggleChartNote note, double proximity)> CheckCloseNotes(int preyIndex, bool forUI = false)
	{
		List<(StruggleChartNote, double)> closeNotes = new List<(StruggleChartNote, double)>();
		StruggleChart targetChart = PredatorStruggleChart;
		if (preyIndex != -1)
		{
			if (Prey[preyIndex].NoHealth)
			{
				return null;
			}
			targetChart = Prey[preyIndex].AssignedStruggleChart;
		}
		if (targetChart == null)
		{
			return null;
		}
		if (targetChart.Notes == null)
		{
			return null;
		}
		for (int noteSetIndex = (int)Math.Max(0.0, Math.Round(StruggleChartProgress) - 3.0); (double)noteSetIndex <= Math.Min(Math.Round(StruggleChartProgress) + 6.0, targetChart.Notes.Count - 1); noteSetIndex++)
		{
			StruggleChartNote[] noteSet = targetChart.Notes[noteSetIndex];
			if (noteSet == null || noteSet.FirstOrDefault((StruggleChartNote x) => x != null) == null)
			{
				continue;
			}
			foreach (StruggleChartNote note in noteSet)
			{
				if (note != null && (!note.CorrectlyPressed || forUI))
				{
					closeNotes.Add((note, (double)noteSetIndex - StruggleChartProgress));
				}
			}
		}
		if (!forUI)
		{
			closeNotes.RemoveAll(((StruggleChartNote note, double proximity) x) => x.proximity >= StruggleChartProgressRate * MaximumNoteProximityRatio);
			closeNotes.RemoveAll(((StruggleChartNote note, double proximity) x) => x.proximity <= (0.0 - StruggleChartProgressRate) * MaximumNoteProximityRatio);
		}
		return closeNotes;
	}

	public bool CheckClearability()
	{
		if (Prey == null)
		{
			return true;
		}
		if (Prey.Count <= 0)
		{
			return true;
		}
		if (!Predator.active)
		{
			return true;
		}
		Entity predator = Predator;
		Player playerPred = (Player)(object)((predator is Player) ? predator : null);
		if (playerPred != null)
		{
			if (playerPred.dead)
			{
				return true;
			}
		}
		else
		{
			Entity predator2 = Predator;
			NPC NPCPred = (NPC)(object)((predator2 is NPC) ? predator2 : null);
			if (NPCPred != null)
			{
				if (NPCPred.life <= 0)
				{
					return true;
				}
			}
			else
			{
				Entity predator3 = Predator;
				Projectile projectilePred = (Projectile)(object)((predator3 is Projectile) ? predator3 : null);
				if (projectilePred != null && projectilePred.AsFood().Health <= 0.0)
				{
					return true;
				}
			}
		}
		return false;
	}
}
