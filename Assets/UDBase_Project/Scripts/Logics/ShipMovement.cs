using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	[RequireComponent(typeof(Rigidbody))]
	public class ShipMovement : MonoBehaviour {
		public float MoveForwardSpeed = 1.0f;
		public float StrafeSpeed = 1.0f;
		public float RotateSpeed = 1.0f;
		public bool ApplyRotation;
		
		[HideInInspector]
		public Vector3 MoveVector = Vector3.zero;
		[HideInInspector]
		public Vector3 RotateVector = Vector3.zero;

		Rigidbody _rb;

		void Start() {
			_rb = GetComponent<Rigidbody>();
		}

		void FixedUpdate() {
			var velocity = new Vector3(MoveVector.x, MoveVector.y, MoveVector.z);
			velocity.x *= StrafeSpeed;
			velocity.z *= MoveForwardSpeed;
			velocity.z = Mathf.Max(velocity.z, 0.0f);
			velocity = transform.TransformVector(velocity);
			if (float.IsNaN(velocity.x) || float.IsInfinity(velocity.x)) {
				return;
			}
			_rb.velocity = velocity;
			if (ApplyRotation) {
				_rb.MoveRotation(Quaternion.Euler(RotateVector * RotateSpeed));
			}
		}
	}
}
