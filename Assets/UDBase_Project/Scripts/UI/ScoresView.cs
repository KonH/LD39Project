using UDBase_Project.Scripts.Logics;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase_Project.Scripts.UI {
	public class ScoresView : MonoBehaviour {
		public ScoresController Controller;

		Text _text;
		
		void Start() {
			_text = GetComponent<Text>();
			Controller.OnScoresChanged.AddListener(UpdateScores);
			UpdateScores();
		}

		void UpdateScores() {
			_text.text = Controller.Scores.ToString();
		}
	}
}
