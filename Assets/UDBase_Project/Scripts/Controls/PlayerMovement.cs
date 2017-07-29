using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.Controls {
	public class PlayerMovement : MonoBehaviour {
		public ShipMovement Movement;
		public Vector2 DeadZone;

		Vector3 FindMoveVector() {
			return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		}

		Vector3 FindRotateVector() {
			var mousePos = Input.mousePosition;
			var w = Screen.width;
			var h = Screen.height;
			var x = (mousePos.x - (float) w / 2) / w;
			var y = (mousePos.y - (float) h / 2) / h;
			var normPos = new Vector2(-y, x);
			if (Mathf.Abs(normPos.x) < DeadZone.x) {
				normPos.x = 0.0f;
			}
			if (Mathf.Abs(normPos.y) < DeadZone.y) {
				normPos.y = 0.0f;
			}
			return new Vector3(normPos.x, normPos.y);
		}
		
		void Update() {
			Movement.MoveVector = FindMoveVector();
			Movement.RotateVector += FindRotateVector();
		}
	}
}
