using System.Collections.Generic;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace InputHandlers {
	public class ActionInputHandler : MonoBehaviour {
		private GameObject _godObject;
		private Button _button;
		
		public bool isActionTargetSelectionPhase;
		
		private Ray _ray;
		private RaycastHit _hit;
		private readonly int _layerMask;
		private Camera _camera;
		private CameraController _cameraController;

		public ActionInputHandler() {
			this._layerMask = 1 << 9;
		}
		
		public void Start() {
			this._godObject = GameObject.Find("GodObject");
			this._button = GameObject.Find("ActionButton").GetComponent<Button>();
		}

		public void setCurrentRangeObject(Range rangeObject) {
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
			this.populateActionInput();
		}
		
		public void populateActionInput() {
			Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;

			GameObject parentPanel = GameObject.Find("BaseActionCommandPanel");
			
			foreach(KeyValuePair<string, Dictionary<string, BaseAbility>> jobSelection in moveset.movelist) {
				string menuJobTab = jobSelection.Key;

				GameObject button = GameObject.Instantiate(Resources.Load("Prefabs/UI/ActionClassSelectionButton") as GameObject, parentPanel.transform);
				button.name = menuJobTab;
				button.GetComponentInChildren<Text>().text = menuJobTab;
			}
			
			parentPanel.GetComponent<PanelManager>().resizePanel();
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