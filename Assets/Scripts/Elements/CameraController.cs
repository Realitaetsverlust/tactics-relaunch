using UnityEngine;
using UnityEngine.UIElements;

namespace Elements {
    public class CameraController : MonoBehaviour {
        public Camera main;
        public GameObject target;
        private Vector3 _mainCameraPosition;
        private float _mainCameraRotation;
        
        private void Awake() {
            this.main = Camera.main;
        }

        public void setCameraToCharacter(GameObject character) {
            Vector3 characterPosition = character.transform.position;
            
            this.main.transform.position = new Vector3(characterPosition.x - 5f, 
                                                       characterPosition.y + 10f, 
                                                       characterPosition.z + 5f);
        }

        public void rotateLeft(GameObject character) { 
            this.transform.RotateAround (character.transform.position, Vector3.up, 90);
        }

        public void rotateRight(GameObject character) {
            this.transform.RotateAround (character.transform.position, Vector3.up, -90);
        }
    }
}
