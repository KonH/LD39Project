using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(Collider))]
	public class ContactDamager : MonoBehaviour {
		public float ContactDamage = 1.0f;
	}
}
