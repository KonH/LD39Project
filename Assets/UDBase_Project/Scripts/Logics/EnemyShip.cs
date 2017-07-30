using System.Collections.Generic;
using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(ShipMovement))]
	public class EnemyShip : MonoBehaviour {
		public static List<EnemyShip> Instances = new List<EnemyShip>();
		
		public float MinDistance;
		
		ShipMovement _movement;
		Weapon[] _weapons;
		EnemyController _controller;

		void OnEnable() {
			Instances.Add(this);
		}

		void OnDisable() {
			Instances.Remove(this);
		}

		void Start() {
			_controller = EnemyController.Instance;
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
				if (!_controller.CanAttack()) {
					return;
				}
				foreach (var weapon in _weapons) {
					weapon.TryShoot();
				}
				_controller.AddAttack();
			}
		}
	}
}
