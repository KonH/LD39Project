using System.Collections.Generic;
using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.Controls {
	public class PlayerWeapon : MonoBehaviour {
		public EnergyHolder Holder;
		public List<Weapon> Weapons = new List<Weapon>();
		public float EnergyUsage;

		void Update() {
			if (Input.GetMouseButton(0)) {
				foreach (var weapon in Weapons) {
					if (!weapon) {
						return;
					}
					weapon.TryShoot();
				}
				Holder.DecreaseEnergy(EnergyUsage * Time.deltaTime);
			}
		}
	}
}
