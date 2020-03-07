using Characters;
using Elements.TileTypes;
using UnityEngine;
using Utils;

namespace UI {
	public class CameraController : MonoBehaviour {
		public float rotationSpeed = 200;

		private Camera _main;
		private Vector3 _mainCameraPosition;
		private Vector3 _cameraOffset = new Vector3(-5f, 10f, 5f);
		private bool _inRotation = false;
		private GameObject _currentlyAttachedTile;
		private GameObject _desiredTile;
		private Vector3 _directionalVector = new Vector3(0, 0, 0);

		private void Start() {
			this._main = Camera.main;
			this._currentlyAttachedTile = GameObject.Find("1-1");
			this._desiredTile = GameObject.Find("1-1");
			this.setNextTargetTileForCamera(GameObject.Find("5-10"));
		}

		public void Update() {
			if(Input.GetKey(KeyCode.Q)) {
				this._inRotation = true;
				this.rotateLeft(TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().getCurrentTileOfCharacter());
			}

			if(Input.GetKey(KeyCode.E)) {
				this._inRotation = true;
				this.rotateRight(TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().getCurrentTileOfCharacter());
			}
			
			this._inRotation = false;
		}

		public void LateUpdate() {
			//don't lerp while rotating or everything is FUCKED
			if(this._inRotation == false) {
				this._main.transform.position = Vector3.Lerp(this._main.transform.position, this._directionalVector, 0.125f);
			}
		}

		public void setNextTargetTileForCamera(GameObject tile) {
			this._currentlyAttachedTile = this._desiredTile;
			this._directionalVector = tile.transform.position + (this._main.transform.position - this._currentlyAttachedTile.transform.position);
			this._desiredTile = tile;
		}

		public void rotateLeft(GameObject tile) {
			float rotation = Time.deltaTime * this.rotationSpeed;

			this.transform.RotateAround(tile.transform.position, new Vector3(0, 1, 0), rotation);
			this._directionalVector = tile.transform.position + (this._main.transform.position - this._currentlyAttachedTile.transform.position);
		}

		public void rotateRight(GameObject tile) {
			float rotation = Time.deltaTime * this.rotationSpeed;
			
			this.transform.RotateAround(tile.transform.position, new Vector3(0, 1, 0), rotation * -1);
			this._directionalVector = tile.transform.position + (this._main.transform.position - this._currentlyAttachedTile.transform.position);
		}
	}
}