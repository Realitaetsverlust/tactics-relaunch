using UnityEngine;
using UnityEngine.UIElements;

namespace Elements {
    public class CameraController : MonoBehaviour {
        public Camera main;
        public GameObject target;
        private Vector3 _mainCameraPosition;
        private float _mainCameraRotation;
        private int _camDirection; // 0 = north; 1 = west; 2 = south; 3 = east
        
        private void Awake() {
            this._camDirection = 0;
            this.main = Camera.main;
        }

        public void setCameraToCharacter(GameObject character) {
            Vector3 characterPosition = character.transform.position;
            
            this.main.transform.position = new Vector3(characterPosition.x - 5f, 
                                                       characterPosition.y + 10f, 
                                                       characterPosition.z + 5f);
        }

        private void rotateCameraLeft() {
            this.setCameraDirection("clockwise");
            if(Camera.main != null) {
                Camera.main.transform.Rotate(0, -90f, 0, Space.World);
            }
        }

        private void rotateCameraRight() {
            this.setCameraDirection("counterclockwise");
            this.setCameraPosition();
            if(Camera.main != null) {
                Camera.main.transform.Rotate(0, 90f, 0, Space.World);
            }
        }

        private void setCameraPosition() {
            Vector3 activePlayerPosition = this.target.transform.position;
            switch(this._camDirection) {
                case 0: //x -5; z 5
                    this._mainCameraPosition = new Vector3(activePlayerPosition.x - 5f, 
                        activePlayerPosition.y + 10f, 
                        activePlayerPosition.z + 5f);
                    break;
                case 1: //x 5; z 5
                    this._mainCameraPosition = new Vector3(activePlayerPosition.x + 5f, 
                        activePlayerPosition.y + 10f, 
                        activePlayerPosition.z + 5f);
                    break;
                case 2: //x 5; z-5
                    this._mainCameraPosition = new Vector3(activePlayerPosition.x + 5f,
                        activePlayerPosition.y + 10f,
                        activePlayerPosition.z - 5f);
                    break;
                case 3: //x -5; z -5
                    this._mainCameraPosition = new Vector3(activePlayerPosition.x - 5f,
                        activePlayerPosition.y + 10f,
                        activePlayerPosition.z - 5f);
                    break;
            }
        }

        private void setCameraDirection(string direction) {
            if(direction.Equals("clockwise")) {
                this._camDirection -= 1;
                if (this._camDirection < 0) {
                    this._camDirection = 3;
                }
            }else if (direction.Equals("counterclockwise")) {
                this._camDirection += 1;
                if (this._camDirection > 3) {
                    this._camDirection = 0;
                }
            }
        }
    }
}
