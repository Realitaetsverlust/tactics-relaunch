using Characters;
using Elements;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace InputHandlers {
	public class MovementInputHandler : MonoBehaviour {
		private GameObject _godObject;
		private Button _button;

		public bool isMovementPhase;
		
		private Ray _ray;
		private RaycastHit _hit;
		private readonly int _layerMask;
		private Camera _camera;
		private CameraController _cameraController;
	
		private Range _currentRangeObject;

		public MovementInputHandler() {
			this._layerMask = 1 << 9;
		}

		public void Start() {
			this._godObject = GameObject.Find("GodObject");
			this._button = GameObject.Find("MovementButton").GetComponent<Button>();
		}

		public void setCurrentRangeObject(Range rangeObject) {
			this._currentRangeObject = rangeObject;
			this.isMovementPhase = true;
		}

		void Update() {
			if(this.isMovementPhase) {
				this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
				if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
					CombatCharacterController charControl = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>();
					GameObject activeTile = GridController.getActiveTile();
					if(Input.GetKeyDown(KeyCode.Mouse0)) {
						if(this._currentRangeObject.isTileWithinRange(activeTile) && activeTile.GetComponent<GridElement>().tileType.passable == true && activeTile.GetComponent<GridElement>().getCharacterOnThisTile() == null) {
							charControl.setCharacterToTile(activeTile);
							charControl.moved = true;
							this.isMovementPhase = false;
							this._currentRangeObject.hideRange();
							this.disableMoveButton();	
						}
					}
				}
			}
		}
		
		public void onClick() {
			this._godObject.GetComponent<CombatController>().initiateMovementForCurrentCharacter();
		}

		public void disableMoveButton() {
			this._button.GetComponent<Image>().color = Color.gray;
			this._button.enabled = false;
		}
		
		public void enableMoveButton() {
			this._button.GetComponent<Image>().color = Color.white;
			this._button.enabled = true;
		}
	}
}