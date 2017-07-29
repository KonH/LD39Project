using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(Collider))]
	public class EnergyHolder : MonoBehaviour {
		[HideInInspector]
		public float Energy;
		public float MaxEnergy = 100.0f;
		public float Decrease = 0.5f;

		void Start() {
			Energy = MaxEnergy;
		}

		void Update() {
			Energy -= Decrease * Time.deltaTime;
		}

		void OnCollisionEnter(Collision other) {
			var block = other.gameObject.GetComponent<EnergyBlock>();
			if (!block) {
				return;
			}
			Energy += block.Energy;
			Energy = Mathf.Min(Energy, MaxEnergy);
			block.Kill();
		}
	}
}
