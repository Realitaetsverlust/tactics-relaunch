using System.Collections.Generic;
using Characters;
using Elements.TileTypes;
using UnityEngine;
using Utils;

namespace UI {
	public class CameraController : MonoBehaviour {
		public float rotationSpeed = 200;
		public float moveSpeed = 0.125f;

		private Camera _main;
		private Vector3 _mainCameraPosition;
		private bool _inRotation = false;
		private GameObject _currentlyAttachedTile;
		private Vector3 _directionalVector = new Vector3(0, 0, 0);
		private MapOverviewHandler _mapOverviewHandler;

		private void Start() {
			this._mapOverviewHandler = GameObject.Find("OverviewModeButton").GetComponent<MapOverviewHandler>();
			this._main = Camera.main;
			this._currentlyAttachedTile = GameObject.Find("1-1");
			this.setNextTargetTileForCamera(GameObject.Find("5-10"));
		}

		public void Update() {
			if(this._mapOverviewHandler.isOverviewMode == false) {
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
		}

		public void LateUpdate() {
			if(this._mapOverviewHandler.isOverviewMode == false) {
				//don't lerp while rotating or everything is FUCKED
				if(this._inRotation == false) {
					this._main.transform.position = Vector3.Lerp(this._main.transform.position, this._directionalVector, this.moveSpeed);
				}	
			}
		}

		public void setNextTargetTileForCamera(GameObject tile) {
			Vector3 direction = this._main.transform.position - this._currentlyAttachedTile.transform.position;
			
			this._directionalVector = tile.transform.position + direction;
			this._currentlyAttachedTile = tile;
		}

		public void rotateLeft(GameObject tile) {
			Vector3 tilePosition = tile.transform.position;
			
			float rotation = Time.deltaTime * this.rotationSpeed;

			this.transform.RotateAround(tilePosition, new Vector3(0, 1, 0), rotation);
			this._directionalVector = this._main.transform.position;
		}

		public void rotateRight(GameObject tile) {
			Vector3 tilePosition = tile.transform.position;

			float rotation = Time.deltaTime * this.rotationSpeed;
			
			this.transform.RotateAround(tile.transform.position, new Vector3(0, 1, 0), rotation * -1);
			this._directionalVector = this._main.transform.position;
		}
	}
}