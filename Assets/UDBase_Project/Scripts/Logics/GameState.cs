using FullSerializer;
using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class GameState {
		[fsProperty("tutorial_shown")]
		public bool TutorialShown { get; set; }
	}
}
