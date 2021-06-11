using System.Collections.Generic;
using DeckSwipe.CardModel;
using DeckSwipe.World;
using UnityEngine;
using UnityEngine.Analytics;

namespace DeckSwipe.Gamestate {
	
	public static class Stats {
		
		private const int _maxStatValue = 32;
		private const int _startingStat1 = 16;
		private const int _startingStat2 = 16;
		private const int _startingStat3 = 16;
		private const int _startingStat4 = 16;
		private const int _startingStat5 = 16;
		
		private static readonly List<StatsDisplay> _changeListeners = new List<StatsDisplay>();
		
		public static int Stat1 { get; private set; }
		public static int Stat2 { get; private set; }
		public static int Stat3 { get; private set; }
		public static int Stat4 { get; private set; }
		public static int Stat5 { get; private set; }
		
		public static float Stat1Percentage => (float) Stat1 / _maxStatValue;
		public static float Stat2Percentage => (float) Stat2 / _maxStatValue;
		public static float Stat3Percentage => (float) Stat3 / _maxStatValue;
		public static float Stat4Percentage => (float) Stat4 / _maxStatValue;
		public static float Stat5Percentage => (float) Stat5 / _maxStatValue;
		
		public static void ApplyModification(StatsModification mod) {
			Stat1 = ClampValue(Stat1 + mod.stat1);
			Stat2 = ClampValue(Stat2 + mod.stat2);
			Stat3 = ClampValue(Stat3 + mod.stat3);
			Stat4 = ClampValue(Stat4 + mod.stat4);
			
			Stat5 = Stat5 + mod.stat5;
			Game.islamophobiaLevel += mod.stat5;
			PlayerPrefs.SetInt("IslamophobiaLevel", Game.islamophobiaLevel);
            PlayerPrefs.Save();

			AnalyticsResult analyticsResult = Analytics.CustomEvent("Islamophobia Analysis",
				new Dictionary<string, object> {
					{"TotalCardsPlayed", Game.totalCardsPlayed},
					{"Level of Islamophobia", Game.islamophobiaLevel},
					{"Card - Islamophobia", $"{Game.totalCardsPlayed} -{Game.islamophobiaLevel} "}});

			Debug.Log(Stat5 + " - analyticsResult: "+analyticsResult);

			TriggerAllListeners();			
		}
		
		public static void ResetStats() {
			ApplyStartingValues();
			TriggerAllListeners();
		}
		
		private static void ApplyStartingValues() {
			Stat1 = ClampValue(_startingStat1);
			Stat2 = ClampValue(_startingStat2);
			Stat3 = ClampValue(_startingStat3);
			Stat4 = ClampValue(_startingStat4);
			Stat5 = _startingStat5;
			
		}
		
		private static void TriggerAllListeners() {
			for (int i = 0; i < _changeListeners.Count; i++) {
				if (_changeListeners[i] == null) {
					_changeListeners.RemoveAt(i);
				}
				else {
					_changeListeners[i].TriggerUpdate();
				}
			}
		}
		
		public static void AddChangeListener(StatsDisplay listener) {
			_changeListeners.Add(listener);
		}
		
		private static int ClampValue(int value) {
			return Mathf.Clamp(value, 0, _maxStatValue);
		}
		
	}
	
}
