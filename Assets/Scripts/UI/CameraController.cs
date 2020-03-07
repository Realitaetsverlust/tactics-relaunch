using UnityEngine;
using Utils;

namespace UI {
    public class CameraController : MonoBehaviour {
        public float rotationSpeed = 200;

        private Camera _main;
        private Vector3 _mainCameraPosition;
        private Vector3 _cameraOffset = new Vector3(-5f, 10f, 5f);
        private bool _cameraAttached = false;
        private GameObject _currentlyAttachedTile;
        private Vector3 _desiredTile;

        private void Start() {
            this._main = Camera.main;
            this.setCameraToTile(GameObject.Find("5-10"));
        }

        public void Update() {
            if(Input.GetKey(KeyCode.Q)) {
                this.rotateLeft(TurnOrder.getActiveCharacter());
            }

            if(Input.GetKey(KeyCode.E)) {
                this.rotateRight(TurnOrder.getActiveCharacter());
            }
        }

        public void LateUpdate() {
            if(this._desiredTile != Vector3.zero) {
                this._main.transform.position = this._currentlyAttachedTile.transform.position + this._desiredTile;
                //this._main.transform.position = Vector3.Lerp(this._currentlyAttachedTile.transform.position, this._desiredTile, 0.125f);
            }
        }

        public void setCameraToTile(GameObject tile) {
            Vector3 tilePosition = tile.transform.position;

            if(this._cameraAttached == false) {
                this._main.transform.position = tilePosition + this._cameraOffset;
                this._currentlyAttachedTile = tile;
                this._cameraAttached = true;
                return;
            }

            Vector3 direction = this._main.transform.position - this._currentlyAttachedTile.transform.position;

            this._desiredTile = tilePosition + direction;
            
            Debug.Log(this._desiredTile);
            this._main.transform.position = this._desiredTile;
            
            this._currentlyAttachedTile = tile;
        }

        public void rotateLeft(GameObject character) {
            float rotation = Time.deltaTime * this.rotationSpeed;

            this.transform.RotateAround(character.transform.position, Vector3.up, rotation);
        }

        public void rotateRight(GameObject character) {
            float rotation = Time.deltaTime * this.rotationSpeed;

            this.transform.RotateAround(character.transform.position, Vector3.up, rotation * -1);
        }
    }
}