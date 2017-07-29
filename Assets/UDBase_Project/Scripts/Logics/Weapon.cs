using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class Weapon : MonoBehaviour {
		public float Damage = 1.0f;
		public float MaxDistance = 50.0f;
		public LineRenderer Line;
		
		readonly RaycastHit[] _results = new RaycastHit[10];

		bool _shooted;
		
		public void TryShoot() {
			var ray = new Ray(transform.position, transform.forward);
			var count = Physics.RaycastNonAlloc(ray, _results, MaxDistance);
			for (int i = 0; i < count; i++) {
				var result = _results[i];
				var go = result.collider.gameObject;
				var damagable = go.GetComponent<Damagable>();
				if (damagable) {
					damagable.TakeDamage(Damage * Time.deltaTime);
				}
			}
			_shooted = true;
		}

		void Update() {
			Line.gameObject.SetActive(_shooted);
			_shooted = false;
		}
	}
}
