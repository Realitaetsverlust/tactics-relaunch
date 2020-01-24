using Elements;
using UnityEngine;
using UnityEngine.UI;

namespace InputHandlers {
	public class WaitInputHandler : MonoBehaviour {
		private GameObject _godObject;
		private Button _button;
		
		public bool isActionPhase;
		
		private Ray _ray;
		private RaycastHit _hit;
		private readonly int _layerMask;
		private Camera _camera;
		private CameraController _cameraController;

		private Range _currentRangeObject;
		
		public WaitInputHandler() {
			this._layerMask = 1 << 9;
		}
		
		public void Start() {
			this._godObject = GameObject.Find("GodObject");
			this._button = GameObject.Find("WaitButton").GetComponent<Button>();
		}

		public void setCurrentRangeObject(Range rangeObject) {
			this._currentRangeObject = rangeObject;
			this.isActionPhase = true;
		}

		void Update() {
		}
		
		public void onClick() {
			this._godObject.GetComponent<CombatController>().endTurnForCurrentCharacter();
		}
	}
}