using UnityEngine;
using UnityEngine.UI;

namespace UDBase_Project.Scripts.UI {
	public class ScoreItem : MonoBehaviour {

		public Text PlaceText;
		public Text NameText;
		public Text ScoresText;

		public bool Active { get; private set; }

		public void SetState(bool state) {
			Active = state;
			gameObject.SetActive(state);
		}
	}
}
