using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.UI {
	public class TutorialUI : MonoBehaviour {

		void Update () {
			if (Input.anyKey) {
				var state = Save.GetNode<GameState>();
				state.TutorialShown = true;
				Save.SaveNode(state);
				Scene.LoadScene("Game");
			}
		}
	}
}
