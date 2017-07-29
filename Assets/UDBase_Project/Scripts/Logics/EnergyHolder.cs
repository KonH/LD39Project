using UnityEngine;
using UnityEngine.Events;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(Collider))]
	public class EnergyHolder : MonoBehaviour {
		[HideInInspector]
		public float Energy;
		public float MaxEnergy = 100.0f;
		public float Decrease = 0.5f;
		public float Damage = 0.5f;
		
		public UnityEvent OnEnergyChanged;

		Damagable _damagable;

		void Start() {
			_damagable = GetComponent<Damagable>();
			Energy = MaxEnergy;
		}

		void Update() {
			Energy -= Decrease * Time.deltaTime;
			Energy = Mathf.Max(Energy, 0.0f);
			UpdateValue();
		}

		void OnCollisionEnter(Collision other) {
			var block = other.gameObject.GetComponent<EnergyBlock>();
			if (!block) {
				return;
			}
			Energy += block.Energy;
			Energy = Mathf.Min(Energy, MaxEnergy);
			UpdateValue();
			block.Kill();
		}

		void UpdateValue() {
			OnEnergyChanged.Invoke();
			if (Energy <= 0.0f) {
				_damagable.TakeDamage(Damage * Time.deltaTime);
			}
		}

		public void DecreaseEnergy(float value) {
			Energy -= value;
			Energy = Mathf.Max(Energy, 0.0f);
			UpdateValue();
		}
	}
}
