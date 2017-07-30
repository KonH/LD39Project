using System.Collections.Generic;
using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(ShipMovement))]
	public class EnemyShip : MonoBehaviour {
		public static List<EnemyShip> Instances = new List<EnemyShip>();
		
		public float MinDistance;
		public float MaxAttackTime;
		public float CooldownTime;
		
		ShipMovement _movement;
		Weapon[] _weapons;
		EnemyController _controller;
		float _attackTimer;
		float _cooldownTimer;
		
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
			if (!_controller.CanAttack()) {
				_movement.MoveVector = transform.forward;
				return;
			}
			transform.LookAt(targetTrans);
			if (Vector3.Distance(transform.position, targetTrans.position) > MinDistance) {
				var direction = targetTrans.position - transform.position;
				direction = transform.InverseTransformDirection(direction.normalized);
				_movement.MoveVector = direction.normalized;
			} else {
				if (_attackTimer > MaxAttackTime) {
					_cooldownTimer += Time.deltaTime;
					if (_cooldownTimer > CooldownTime) {
						_cooldownTimer = 0.0f;
						_attackTimer = 0.0f;
					}
					return;
				}
				_movement.MoveVector = Vector3.zero;
				foreach (var weapon in _weapons) {
					weapon.TryShoot();
				}
				_controller.AddAttack();
				_attackTimer += Time.deltaTime;
			}
		}
	}
}
