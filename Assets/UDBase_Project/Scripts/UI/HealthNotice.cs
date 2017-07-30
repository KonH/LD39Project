using DG.Tweening;
using UDBase.Utils;
using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.UI {
	public class HealthNotice : MonoBehaviour {
		public Damagable Damagable;
		public float NoticeValue = 0.25f;

		bool _prevState;
		Sequence _seq;
		
		void Start() {
			Damagable.OnHealthChanged.AddListener(UpdateState);
			UpdateState();
		}

		void UpdateState() {
			var state = Damagable.Health / Damagable.MaxHealth < NoticeValue;
			gameObject.SetActive(state);
			gameObject.SetActive(state);
			if (state != _prevState) {
				if (state) {
					_seq = DOTween.Sequence();
					_seq.Append(transform.DOShakeScale(0.4f, 0.6f));
					_seq.AppendInterval(0.4f);
					_seq.SetLoops(-1);
				} else {
					_seq = TweenHelper.Reset(_seq);
				}
			}
			_prevState = state;
		}
	}
}
