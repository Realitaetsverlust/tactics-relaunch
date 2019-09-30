using UnityEngine;

namespace Elements {
    public class CameraController : MonoBehaviour {
        public static Camera main;
        void Start() {
            CameraController.main = Camera.main;
        }
    }
}
