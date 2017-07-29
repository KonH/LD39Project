using System.Collections.Generic;
using UDBase_Project.Scripts.Logics;
using UnityEngine;

namespace UDBase_Project.Scripts.Controls {
	public class PlayerWeapon : MonoBehaviour {
		public List<Weapon> Weapons = new List<Weapon>();

		void Update() {
			if (Input.GetMouseButton(0)) {
				foreach (var weapon in Weapons) {
					if (!weapon) {
						return;
					}
					weapon.TryShoot();
				}
			}
		}
	}
}
