using UnityEngine;
using Utils;

namespace UI {
    public class CameraController : MonoBehaviour {
        public float rotationSpeed = 200;
        public float minRotation = -90;
        public float maxRotation = 90;
        
        private Camera _main;
        private GameObject _target;
        private Vector3 _mainCameraPosition;
        private float _mainCameraRotation;
        private bool _cameraMoveInProgress;
        private sbyte _rotationDirection = 0;
        private float _elapsedRotation;
        
        private void Start() {
            this._main = Camera.main;
        }

        public void Update() {
            if(!this._cameraMoveInProgress) {
                if(Input.GetKeyDown(KeyCode.Q)) {
                    this._cameraMoveInProgress = true;
                    this._rotationDirection = 1;
                }

                if(Input.GetKeyDown(KeyCode.E)) {
                    this._cameraMoveInProgress = true;
                    this._rotationDirection = -1;
                }
            }

            if(this._rotationDirection == 1) {
                this.rotateLeft(TurnOrder.getActiveCharacter());
            }

            if(this._rotationDirection == -1) {
                this.rotateRight(TurnOrder.getActiveCharacter());
            }
        }

        public void setCameraToCharacter(GameObject character) {
            Vector3 characterPosition = character.transform.position;
            
            this._main.transform.position = new Vector3(characterPosition.x - 5f,
                                                       characterPosition.y + 10f,
                                                       characterPosition.z + 5f);
        }

        public void rotateLeft(GameObject character) {
            float rotation = Time.deltaTime * 200f;

            if(this._elapsedRotation >= 90f) {
                rotation = 90f - this._elapsedRotation;
                this._cameraMoveInProgress = false;
                this._rotationDirection = 0;
                this._elapsedRotation = 0;
            }
            
            Debug.Log(rotation);

            this.transform.RotateAround (character.transform.position, Vector3.up, rotation);
            this._elapsedRotation += rotation;
        }

        public void rotateRight(GameObject character) {
            this.transform.RotateAround (character.transform.position, Vector3.up, -90);
        }
    }
}
