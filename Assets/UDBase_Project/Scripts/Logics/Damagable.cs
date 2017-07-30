using UDBase.Controllers.EventSystem;
using UnityEngine;
using UnityEngine.Events;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(Collider))]
	public class Damagable : MonoBehaviour {
		[HideInInspector]
		public float Health;
		public float MaxHealth = 100.0f;
		public bool Godmode;
		public GameObject DestroyEffect;
		
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

		public void TakeDamage(float damage) {
			if (Godmode) {
				return;
			}
			Health -= damage;
			OnHealthChanged.Invoke();
			if (Health < 0) {
				Kill();
			}
		}

		void Kill() {
			if (GetComponent<PlayerMark>()) {
				Events.Fire(new PlayerDestroyed());
			} else {
				if (GetComponent<EnemyShip>()) {
					Events.Fire(new EnemyDestroyed());
				} else {
					Events.Fire(new AsteroidDestroyed());
				}
			}
			Instantiate(DestroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
