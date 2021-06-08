using System;
using DeckSwipe.Gamestate;

namespace DeckSwipe.CardModel.DrawQueue {

	[Serializable]
	public class Followup : IFollowup {

		public int id;
		public int delay;

		public int Delay {
			get { return delay; }
			set { delay = value; }
		}

		public Followup(int id, int delay) {
			this.id = id;
			this.delay = delay;
		}

		public IFollowup Clone() => new Followup(id, delay);

		public ICard Fetch(CardStorage cardStorage) => cardStorage.ForId(id);
	}
}
