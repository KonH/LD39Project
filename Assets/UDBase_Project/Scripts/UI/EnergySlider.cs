using UDBase_Project.Scripts.Logics;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase_Project.Scripts.UI {
	[RequireComponent(typeof(Slider))]
	public class EnergySlider : MonoBehaviour {
		public EnergyHolder Holder;
		
		Slider _slider;
		
		void Start () {
			_slider = GetComponent<Slider>();
		}

		void Update() {
			UpdateEnergy();
		}

		void UpdateEnergy() {
			var value = Holder.Energy / Holder.MaxEnergy;
			_slider.value = value;
		}
	}
}
