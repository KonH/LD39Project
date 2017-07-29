using UnityEngine;
using UnityEngine.Events;

namespace UDBase_Project.Scripts.Logics {
	public class Damagable : MonoBehaviour {
		[HideInInspector]
		public float Health;
		public float MaxHealth = 100.0f;

		public UnityEvent OnHealthChanged;

		void Start() {
			Health = MaxHealth;
		}

		void OnCollisionEnter(Collision other) {
			var damanger = other.gameObject.GetComponent<ContactDamager>();
			if (damanger) {
				TakeDamage(damanger.ContactDamage);
			}
		}

		void TakeDamage(float damage) {
			Health -= damage;
			OnHealthChanged.Invoke();
		}
	}
}
