using UnityEngine;

namespace Elements {
    public class CameraController : MonoBehaviour {
        public static Camera main;
        void Awake() {
            CameraController.main = Camera.main;
        }
    }
}
