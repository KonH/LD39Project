using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(ShipMovement))]
	public class EnemyShip : MonoBehaviour {
		public float MinDistance;
		
		ShipMovement _movement;
		Weapon[] _weapons;
		
		void Start() {
			_movement = GetComponent<ShipMovement>();
			_weapons = GetComponentsInChildren<Weapon>();
		}

		void Update() {
			var target = PlayerMark.Instance;
			if (!target) {
				return;
			}
			var targetTrans = target.transform;
			transform.LookAt(targetTrans);
			if (Vector3.Distance(transform.position, targetTrans.position) > MinDistance) {
				var direction = targetTrans.position - transform.position;
				direction = transform.InverseTransformDirection(direction.normalized);
				_movement.MoveVector = direction.normalized;
			} else {
				_movement.MoveVector = Vector3.zero;
				foreach (var weapon in _weapons) {
					weapon.TryShoot();
				}
			}
		}
	}
}
