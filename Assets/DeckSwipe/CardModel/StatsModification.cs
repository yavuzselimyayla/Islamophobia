using System;
﻿using DeckSwipe.Gamestate;

namespace DeckSwipe.CardModel {

	[Serializable]
	public class StatsModification {

		public int stat1;
		public int stat2;
		public int stat3;
		public int stat4;
		public int stat5;

		public StatsModification(int stat1, int stat2, int stat3, int stat4, int stat5) {
			this.stat1 = stat1;
			this.stat2 = stat2;
			this.stat3 = stat3;
			this.stat4 = stat4;
			this.stat5 = stat5;
		}

		public void Perform() {
			// TODO Pass through status effects
			Stats.ApplyModification(this);
		}

	}

}
