using System;
using UnityEngine;
using UnityEngine.AI;

namespace WorldMovement {
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerMovementController : MonoBehaviour {
        private Camera _cam;
        private PlayerMotor _motor;
        private bool _movementAllowed = true;
        public float moveSpeed;
        private float _calcSpeed;

        public void Start() {
            this._cam = Camera.main;
            this._motor = this.GetComponent<PlayerMotor>();
        }

        public void FixedUpdate() {
            if(this._movementAllowed) {
                Vector3 position = new Vector3(0, 0, 0);
                bool moved = false;
                this._calcSpeed = this.moveSpeed;
                
                if(Input.GetKey(KeyCode.LeftShift)) {
                    this._calcSpeed = 3 * this.moveSpeed;
                }

                if(Input.GetKey(KeyCode.W)) {
                    position.z += this._calcSpeed;
                    moved = true;
                }

                if(Input.GetKey(KeyCode.S)) {
                    position.z -= this._calcSpeed;
                    moved = true;
                }

                if(Input.GetKey(KeyCode.A)) {
                    position.x -= this._calcSpeed;
                    moved = true;
                }

                if(Input.GetKey(KeyCode.D)) {
                    position.x += this._calcSpeed;
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
            this._motor.warpToPoint(spawnCoordinates);
        }

        public void disableMovement() {
            this._movementAllowed = false;
        }
        
        public void enableMovement() {
            this._movementAllowed = true;
        }
    }
}