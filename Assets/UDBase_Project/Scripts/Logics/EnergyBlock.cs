using UDBase.Controllers.EventSystem;
using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class EnergyBlock : MonoBehaviour {
		public float Energy = 25.0f;

		public void Kill() {
			Events.Fire(new EnergyCollected());
			Destroy(gameObject);
		}
	}
}
