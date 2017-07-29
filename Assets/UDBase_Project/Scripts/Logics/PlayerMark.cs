using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class PlayerMark : MonoBehaviour {
		public static PlayerMark Instance;
	
		void OnEnable() {
			Instance = this;
		}

		void OnDisable() {
			Instance = null;
		}
	}
}
