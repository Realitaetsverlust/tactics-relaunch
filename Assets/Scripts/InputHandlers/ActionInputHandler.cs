using Elements;
using UnityEngine;

namespace Utils {
	public class ActionInputHandler : MonoBehaviour {
		public bool isActionPhase;
		
		private Ray _ray;
		private RaycastHit _hit;
		private readonly int _layerMask;
		private Camera _camera;
		private CameraController _cameraController;

		private Range _currentRangeObject;
		
		public ActionInputHandler() {
			this._layerMask = 1 << 9;
		}

		public void setCurrentRangeObject(Range rangeObject) {
			this._currentRangeObject = rangeObject;
			this.isActionPhase = true;
		}

		void Update() {
			if(this.isActionPhase) {
				this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
				if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
					
				}
			}
		}
	}
}