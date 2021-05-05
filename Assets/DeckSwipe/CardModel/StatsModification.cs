using System;
﻿using DeckSwipe.Gamestate;

namespace DeckSwipe.CardModel {

	[Serializable]
	public class StatsModification {

		public int coal;
		public int food;
		public int health;
		public int hope;
		public int stat5;

		public StatsModification(int coal, int food, int health, int hope, int stat5) {
			this.coal = coal;
			this.food = food;
			this.health = health;
			this.hope = hope;
			this.stat5 = stat5;
		}

		public void Perform() {
			// TODO Pass through status effects
			Stats.ApplyModification(this);
		}

	}

}
