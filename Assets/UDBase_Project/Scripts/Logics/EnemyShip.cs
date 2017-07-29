using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(ShipMovement))]
	public class EnemyShip : MonoBehaviour {
		ShipMovement _movement;
		
		void Start() {
			_movement = GetComponent<ShipMovement>();
		}

		void Update() {
			var target = PlayerMark.Instance;
			if (target) {
				var targetTrans = target.transform;
				transform.LookAt(targetTrans);
				var direction = targetTrans.position - transform.position;
				direction = transform.InverseTransformDirection(direction.normalized);
				Debug.Log(direction);
				_movement.MoveVector = direction.normalized;
			}
		}
	}
}
