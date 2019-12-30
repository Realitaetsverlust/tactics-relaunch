using Elements;
using UnityEngine;
using CharacterController = Characters.CharacterController;

namespace Utils {
	public class MovementInputHandler : MonoBehaviour {
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

		public void setCurrentRangeObject(Range rangeObject) {
			this._currentRangeObject = rangeObject;
			this.isMovementPhase = true;
		}

		void Update() {
			if(this.isMovementPhase) {
				this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
				if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
					CharacterController charControl = TurnOrder.getActiveCharacter().GetComponent<CharacterController>();
					GameObject activeTile = GridController.getActiveTile();
					if(Input.GetKeyDown(KeyCode.Mouse0)) {
						if(this._currentRangeObject.isTileWithinRange(activeTile)) {
							charControl.setCharacterToTile(activeTile);
							charControl.moved = true;
							this.isMovementPhase = false;
							this._currentRangeObject.hideRange();
						}
					}
				}
			}
		}
	}
}