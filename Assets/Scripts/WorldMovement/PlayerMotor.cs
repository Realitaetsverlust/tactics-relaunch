using UnityEngine;
using UnityEngine.AI;

namespace WorldMovement {
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMotor : MonoBehaviour {
        private NavMeshAgent _agent;
        
        // Start is called before the first frame update
        void Start() {
            this._agent = this.GetComponent<NavMeshAgent>();
        }

        public void moveToPoint(Vector3 point) {
            this._agent.Move(point);
        }

        public void warpToPoint(Vector3 point) {
            this._agent.Warp(point);
        }
    }
}
