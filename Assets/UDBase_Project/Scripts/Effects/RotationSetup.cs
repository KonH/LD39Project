using UnityEngine;

namespace UDBase_Project.Scripts.Effects {
	public class RotationSetup : MonoBehaviour {

		void Start () {
			transform.rotation = Random.rotation;
		}
	}
}
