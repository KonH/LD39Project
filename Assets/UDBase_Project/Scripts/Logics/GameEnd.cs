using UDBase.Controllers.EventSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.UserSystem;
using UnityEngine;

namespace UDBase_Project.Scripts.Logics {
	public class GameEnd : MonoBehaviour {
		public ScoresController Controller;
		
		void OnEnable() {
			Events.Subscribe<PlayerDestroyed>(this, OnPlayerDestroyed);
		}

		void OnDisable() {
			Events.Unsubscribe<PlayerDestroyed>(OnPlayerDestroyed);
		}

		void OnPlayerDestroyed(PlayerDestroyed e) {
			UDBase.Controllers.LeaderboardSystem.Leaderboard.PostScore("", User.Name, Controller.Scores, OnScoresSend);
		}

		void OnScoresSend(bool result) {
			Scene.LoadScene("Leaderboard");
		}
	}
}
