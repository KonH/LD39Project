using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(Rigidbody))]
	public class ShipMovement : MonoBehaviour {
		public float MoveForwardSpeed = 1.0f;
		public float StrafeSpeed = 1.0f;
		public float RotateSpeed = 1.0f;
		
		[HideInInspector]
		public Vector3 MoveVector = Vector3.zero;
		[HideInInspector]
		public Vector3 RotateVector = Vector3.zero;

		Rigidbody _rb;

		void Start() {
			_rb = GetComponent<Rigidbody>();
		}

		void Update() {
			MoveVector.x *= StrafeSpeed;
			MoveVector.z *= MoveForwardSpeed;
			MoveVector.z = Mathf.Max(MoveVector.z, 0.0f);
			_rb.velocity = transform.TransformDirection(MoveVector);
			_rb.MoveRotation(Quaternion.Euler(RotateVector * RotateSpeed));
		}
	}
}
