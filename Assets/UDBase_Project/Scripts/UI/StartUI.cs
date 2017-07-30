using UDBase.Controllers.UserSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase_Project.Scripts.UI {
	public class StartUI : MonoBehaviour {

		public InputField NameInput;
		public Button StartButton;
		public Button LeaderboardButton;
	
		void Start () {
			LoadName();
			NameInput.onValueChanged.AddListener(OnNameChanged);
			UpdateState();
		}

		void LoadName() {
			NameInput.text = User.Name;
		}
		
		void OnNameChanged(string value) {
			User.Name = value;
			UpdateState();
		}
		
		void UpdateState() {
			var isValid = !string.IsNullOrEmpty(User.Name);
			StartButton.interactable = isValid;
			LeaderboardButton.interactable = isValid;
		}
	}
}
