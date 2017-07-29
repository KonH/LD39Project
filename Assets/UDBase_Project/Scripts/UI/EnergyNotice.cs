using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.UI {
	public class EnergyNotice : MonoBehaviour {
		public EnergyHolder Holder;
		public float NoticeValue = 0.25f;

		void Start() {
			Holder.OnEnergyChanged.AddListener(UpdateState);
			UpdateState();
		}

		void UpdateState() {
			var state = Holder.Energy / Holder.MaxEnergy < NoticeValue;
			gameObject.SetActive(state);
		}
	}
}
