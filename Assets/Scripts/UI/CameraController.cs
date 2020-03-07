using UnityEngine;
using Utils;

namespace UI {
    public class CameraController : MonoBehaviour
    {
        public float rotationSpeed = 200;

        private Camera _main;
        private Vector3 _mainCameraPosition;
        private Vector3 _cameraOffset = new Vector3(-5f, 10f, 5f);
        private bool _cameraAttached = false;
        private GameObject _currentlyAttachedTile;
        private float _distanceOfCameraToTile;

        private void Start() {
            this._main = Camera.main;
            this.setCameraToTile(GameObject.Find("1-1"));
        }

        public void Update() {
            if(Input.GetKey(KeyCode.Q)) {
                this.rotateLeft(TurnOrder.getActiveCharacter());
            }

            if(Input.GetKey(KeyCode.E)) {
                this.rotateRight(TurnOrder.getActiveCharacter());
            }
        }

        public void setCameraToTile(GameObject tile) {
            Vector3 tilePosition = tile.transform.position;

            if(this._cameraAttached == false) {
                this._main.transform.position = tilePosition + this._cameraOffset;
                this._distanceOfCameraToTile = (tilePosition - this._main.transform.position).magnitude;
                this._currentlyAttachedTile = tile;
                this._cameraAttached = true;
                return;
            }

            Vector3 direction = this._currentlyAttachedTile.transform.position - this._main.transform.position;

            this._main.transform.position = tilePosition + (direction * this._distanceOfCameraToTile);
            this._main.transform.LookAt(tilePosition);
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
