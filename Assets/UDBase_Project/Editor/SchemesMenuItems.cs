using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.EditorTools {
	public static class SchemesMenuItems {
		[MenuItem("UDBase/Schemes/Default")]
		static void SwitchToScheme_Default() {
			SchemesTool.SwitchScheme("Default");
		}		[MenuItem("UDBase/Schemes/GameScheme")]
		static void SwitchToScheme_GameScheme() {
			SchemesTool.SwitchScheme("GameScheme");
		}		[MenuItem("UDBase/Schemes/PublishScheme")]
		static void SwitchToScheme_PublishScheme() {
			SchemesTool.SwitchScheme("PublishScheme");
		}
	}
}
