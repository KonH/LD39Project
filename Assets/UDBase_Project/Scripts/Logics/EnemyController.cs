using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class EnemyController : MonoBehaviour {
		public static EnemyController Instance;

		public int MaxAttacks;
		public int MaxEnemies;
		
		int _attackAtFrame;
		
		void OnEnable() {
			Instance = this;
		}

		void OnDisable() {
			Instance = null;
		}

		void LateUpdate() {
			_attackAtFrame = 0;
		}

		public bool CanSpawn() {
			return EnemyShip.Instances.Count < MaxEnemies;
		}

		public bool CanAttack() {
			return _attackAtFrame < MaxAttacks;
		}

		public void AddAttack() {
			_attackAtFrame++;
		}
	}
}
