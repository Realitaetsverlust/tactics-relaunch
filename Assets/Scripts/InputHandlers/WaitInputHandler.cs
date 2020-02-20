using Elements;
using UnityEngine;
using UnityEngine.UI;

namespace InputHandlers {
	public class WaitInputHandler : MonoBehaviour {
		private GameObject _godObject;
		private Button _button;
		
		private Range _currentRangeObject;
		
		public void Start() {
			this._godObject = GameObject.Find("GodObject");
			this._button = GameObject.Find("WaitButton").GetComponent<Button>();
		}

		public void onClick() {
			this._godObject.GetComponent<CombatController>().endTurnForCurrentCharacter();
		}
	}
}