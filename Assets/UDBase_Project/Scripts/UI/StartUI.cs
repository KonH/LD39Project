using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.UserSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase_Project.Scripts.UI {
	public class StartUI : MonoBehaviour {

		public InputField NameInput;
		public Button StartButton;
		public Button LeaderboardButton;
	
		void Start () {
			StartButton.onClick.AddListener(OnStartClick);
			LeaderboardButton.onClick.AddListener(OnLeaderboardClick);
			LoadName();
			NameInput.onValueChanged.AddListener(OnNameChanged);
			UpdateState();
		}

		void OnStartClick() {
			Scene.LoadScene("Game");
		}

		void OnLeaderboardClick() {
			Scene.LoadScene("Leaderboard");
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
