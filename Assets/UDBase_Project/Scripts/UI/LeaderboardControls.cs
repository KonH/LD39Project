using System.Collections.Generic;
using UDBase.Controllers.LeaderboardSystem;
using UnityEngine;

namespace UDBase_Project.Scripts.UI {
	public class LeaderboardControls : MonoBehaviour {

		public LeaderboardContent Content;
		public GameObject LoadingItem;

		public int Limit = 100;

		bool Loading {
			set {
				LoadingItem.SetActive(value);
			}
		}

		void Start() {
			StartRefresh();
		}

		void StartRefresh() {
			Loading = true;
			UDBase.Controllers.LeaderboardSystem.Leaderboard.GetScores(Limit, "", EndRefresh);
		}

		void EndRefresh(List<LeaderboardItem> items) {
			Loading = false;
			Content.Clear();
			if ( items != null ) {
				for ( int i = 0; i < items.Count; i++ ) {
					var item = items[i];
					Content.Add(
						i + 1,
						item.UserName,
						item.Score);
				}
			}
		}
	}
}
