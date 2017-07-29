using UDBase_Project.Scripts.Logics;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase_Project.Scripts.UI {
	[RequireComponent(typeof(Slider))]
	public class HealthSlider : MonoBehaviour {
		public Damagable Damagable;
		
		Slider _slider;
		
		void Start () {
			_slider = GetComponent<Slider>();
			Damagable.OnHealthChanged.AddListener(UpdateHealth);
			UpdateHealth();
		}

		void UpdateHealth() {
			var value = Damagable.Health / Damagable.MaxHealth;
			_slider.value = value;
		}
	}
}
