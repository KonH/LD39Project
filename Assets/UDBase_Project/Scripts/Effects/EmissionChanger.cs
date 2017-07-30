using UnityEngine;

namespace UDBase_Project.Scripts.Effects {
	public class EmissionChanger : MonoBehaviour {
		public Color StartColor;
		public Color EndColor;
		public float Speed = 1.0f;

		bool _inverse;
		float _timer;
		Renderer _renderer;
		
		void Start() {
			_renderer = GetComponent<Renderer>();
		}

		void Update() {
			if (_timer < 0.0f) {
				_inverse = false;
			}
			if (_timer > 1.0f) {
				_inverse = true;
			}
			var color = Color.Lerp(StartColor, EndColor, _timer);
			_renderer.material.SetColor("_EmissionColor", color);
			var change = Speed * Time.deltaTime;
			_timer += _inverse ? -change : change;
		}
	}
}
