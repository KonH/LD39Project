using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class EnergyBlock : MonoBehaviour {
		public float Energy = 25.0f;

		public void Kill() {
			Destroy(gameObject);
		}
	}
}
