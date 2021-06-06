using DeckSwipe.Gamestate;
using Outfrost;
using UnityEngine;
using UnityEngine.UI;

namespace DeckSwipe.World {
	
	public class StatsDisplay : MonoBehaviour {
		
		public Image coalBar;
		public Image foodBar;
		public Image healthBar;
		public Image hopeBar;
		public float relativeMargin;
		
		private float minFillAmount;
		private float maxFillAmount;
		
		private void Awake() {
			minFillAmount = Mathf.Clamp01(relativeMargin);
			maxFillAmount = Mathf.Clamp01(1.0f - relativeMargin);
			
			if (!Util.IsPrefab(gameObject)) {
				Stats.AddChangeListener(this);
				TriggerUpdate();
			}
		}
		
		public void TriggerUpdate() {
			coalBar.fillAmount = Mathf.Lerp(minFillAmount, maxFillAmount, Stats.Stat1Percentage);
			foodBar.fillAmount = Mathf.Lerp(minFillAmount, maxFillAmount, Stats.Stat2Percentage);
			healthBar.fillAmount = Mathf.Lerp(minFillAmount, maxFillAmount, Stats.Stat3Percentage);
			hopeBar.fillAmount = Mathf.Lerp(minFillAmount, maxFillAmount, Stats.Stat4Percentage);
		}
		
	}
	
}
