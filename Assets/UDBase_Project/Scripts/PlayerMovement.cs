using UnityEngine;

namespace UDBase_Project.Scripts {
	public class PlayerMovement : MonoBehaviour {
		public ShipMovement Movement;

		Vector3 FindMoveVector() {
			return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		}

		Vector3 FindRotateVector() {
			var mousePos = Input.mousePosition;
			var w = Screen.width;
			var h = Screen.height;
			var x = (mousePos.x - (float) w / 2) / w;
			var y = (mousePos.y - (float) h / 2) / h;
			var normalizedMousePos = new Vector2(x, y);
			return new Vector3(-normalizedMousePos.y, normalizedMousePos.x);
		}
		
		void Update() {
			Movement.MoveVector = FindMoveVector();
			Movement.RotateVector += FindRotateVector();
		}
	}
}
