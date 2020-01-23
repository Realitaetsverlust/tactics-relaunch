using System.Collections.Generic;
using Characters;
using Characters.Moves;
using Characters.Utils;
using Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Utils {
	public class ActionInputHandler : MonoBehaviour {
		private GameObject _godObject;
		private Button _button;
		
		public bool isActionTargetSelectionPhase;
		
		private Ray _ray;
		private RaycastHit _hit;
		private readonly int _layerMask;
		private Camera _camera;
		private CameraController _cameraController;

		private Range _currentRangeObject;
		
		public ActionInputHandler() {
			this._layerMask = 1 << 9;
		}
		
		public void Start() {
			this._godObject = GameObject.Find("GodObject");
			this._button = GameObject.Find("ActionButton").GetComponent<Button>();
		}

		public void setCurrentRangeObject(Range rangeObject) {
			this._currentRangeObject = rangeObject;
			this.isActionTargetSelectionPhase = true;
		}

		void Update() {
			if(this.isActionTargetSelectionPhase) {
				this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
				if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
					
				}
			}
		}
		
		public void onClick() {
			this._godObject.GetComponent<CombatController>().initiateMovementForCurrentCharacter();
		}
		
		public void populateActionInput() {
			Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;

			foreach(KeyValuePair<string, Dictionary<string, BaseMove>> jobSelection in moveset.movelist) {
				
			}
		}

		public void disableButton() {
			this._button.GetComponent<Image>().color = Color.gray;
			this._button.enabled = false;
		}
		
		public void enableButton() {
			this._button.GetComponent<Image>().color = Color.white;
			this._button.enabled = true;
		}
	}
}