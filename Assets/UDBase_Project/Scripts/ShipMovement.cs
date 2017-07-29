using UnityEngine;

namespace UDBase_Project.Scripts {
	[RequireComponent(typeof(Rigidbody))]
	public class ShipMovement : MonoBehaviour {
		public float MoveSpeed = 1.0f;
		public float RotateSpeed = 1.0f;
		
		[HideInInspector]
		public Vector3 MoveVector = Vector3.zero;
		public Vector3 RotateVector = Vector3.zero;

		Rigidbody _rb;

		void Start() {
			_rb = GetComponent<Rigidbody>();
		}

		void Update() {
			_rb.velocity = MoveVector * MoveSpeed;
			_rb.MoveRotation(Quaternion.Euler(RotateVector * RotateSpeed));
		}
	}
}
