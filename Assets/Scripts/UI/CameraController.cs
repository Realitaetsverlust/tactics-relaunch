using System;
using UnityEngine;
using Utils;

namespace UI {
    public class CameraController : MonoBehaviour {
        private Camera _main;
        private GameObject _target;
        private Vector3 _mainCameraPosition;
        private float _mainCameraRotation;
        private bool _cameraMoveInProgress;
        private short _rotationDirection = 0; // 0 = no rotation, -1 = left, 1 = right
        
        private void Start() {
            this._main = Camera.main;
        }

        public void Update() {
            if(this._cameraMoveInProgress == false) {
                if(Input.GetKeyDown(KeyCode.Q)) {
                    this._cameraMoveInProgress = true;
                    
                }

                if(Input.GetKeyDown(KeyCode.E)) {
                    this._cameraMoveInProgress = true;
                    this.rotateRight(TurnOrder.getActiveCharacter());
                }
            }
        }

        public void setCameraToCharacter(GameObject character) {
            Vector3 characterPosition = character.transform.position;
            
            this._main.transform.position = new Vector3(characterPosition.x - 5f, 
                                                       characterPosition.y + 10f, 
                                                       characterPosition.z + 5f);
        }

        public void rotateLeft(GameObject character) { 
            //this.transform.RotateAround (character.transform.position, Vector3.up, 90);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0, 90, 0), 10f * Time.deltaTime);

        }

        public void rotateRight(GameObject character) {
            this.transform.RotateAround (character.transform.position, Vector3.up, -90);
        }
    }
}
