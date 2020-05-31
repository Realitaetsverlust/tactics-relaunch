using System;
using UnityEngine;
using UnityEngine.AI;

namespace WorldMovement {
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerMovementController : MonoBehaviour {
        private Camera _cam;
        private PlayerMotor _motor;
        private bool _movementAllowed;

        public void Start() {
            this._cam = Camera.main;
            this._motor = this.GetComponent<PlayerMotor>();
        }

        public void Update() {
            if(this._movementAllowed) {
                Vector3 position = this.transform.position;
                bool moved = false;

                if(Input.GetKey(KeyCode.W)) {
                    position.z += 1;
                    moved = true;
                }

                if(Input.GetKey(KeyCode.S)) {
                    position.z -= 1;
                    moved = true;
                }

                if(Input.GetKey(KeyCode.A)) {
                    position.x -= 1;
                    moved = true;
                }

                if(Input.GetKey(KeyCode.D)) {
                    position.x += 1;
                    moved = true;
                }

                if(moved) {
                    if(Input.GetKey(KeyCode.LeftShift)) {
                        this._motor.GetComponent<NavMeshAgent>().speed = 20;
                    }
                    else {
                        this._motor.GetComponent<NavMeshAgent>().speed = 5;
                    }

                    this._motor.moveToPoint(position);
                }
            }
        }

        public void spawnCharacterToLocation(Vector3 spawnCoordinates) {
            this.transform.position = spawnCoordinates;
            this._motor.moveToPoint(spawnCoordinates);
        }

        public void disableMovement() {
            this._movementAllowed = false;
        }
        
        public void enableMovement() {
            this._movementAllowed = true;
        }
    }
}