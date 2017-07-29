using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.UI {
	public class HealthNotice : MonoBehaviour {
		public Damagable Damagable;
		public float NoticeValue = 0.25f;
		
		void Start() {
			Damagable.OnHealthChanged.AddListener(UpdateState);
			UpdateState();
		}

		void UpdateState() {
			var state = Damagable.Health / Damagable.MaxHealth < NoticeValue;
			gameObject.SetActive(state);
		}
	}
}
