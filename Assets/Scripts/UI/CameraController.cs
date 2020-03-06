using UnityEngine;
using Utils;

namespace UI {
    public class CameraController : MonoBehaviour {
        public float rotationSpeed = 200;

        private Camera _main;
        private GameObject _target;
        private Vector3 _mainCameraPosition;

        private void Start() {
            this._main = Camera.main;
        }

        public void Update() {
            if(Input.GetKey(KeyCode.Q)) {
                this.rotateLeft(TurnOrder.getActiveCharacter());
            }

            if(Input.GetKey(KeyCode.E)) {
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
            float rotation = Time.deltaTime * this.rotationSpeed;

            this.transform.RotateAround(character.transform.position, Vector3.up, rotation);
        }

        public void rotateRight(GameObject character) {
            float rotation = Time.deltaTime * this.rotationSpeed;

            this.transform.RotateAround(character.transform.position, Vector3.up, rotation * -1);
        }
    }
}