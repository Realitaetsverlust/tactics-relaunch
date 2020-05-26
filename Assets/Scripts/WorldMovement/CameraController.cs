using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace WorldMovement {
    public class CameraController : MonoBehaviour {

        private GameObject _attachTarget;

        public void Start() {
            this._attachTarget = GameObject.Find("Player");
        }
        public void Update() {
            Vector3 target = this._attachTarget.transform.position;
            this.transform.position = new Vector3(target.x, target.y + 20, target.z - 10);
        }
    }
}