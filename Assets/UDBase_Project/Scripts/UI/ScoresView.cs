using DG.Tweening;
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
			var scores = Controller.Scores;
			_text.text = scores.ToString();
			if (scores > 0) {
				transform.localScale = Vector3.one;
				transform.DOShakeScale(0.4f, 0.4f);
			}
		}
	}
}
