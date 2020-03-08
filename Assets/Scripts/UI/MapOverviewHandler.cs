using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace UI {
    public class MapOverviewHandler : MonoBehaviour {
        public bool isOverviewMode = false;
        public float velocity = 0.5f;

        public void Update() {
            if(this.isOverviewMode) {
                if(Input.GetKey(KeyCode.W)) { // Move upwards
                    Camera.main.transform.position += new Vector3(this.velocity, 0, -this.velocity);
                }
            
                if(Input.GetKey(KeyCode.A)) { // Move left
                    Camera.main.transform.position += new Vector3(this.velocity, 0, this.velocity);
                }
            
                if(Input.GetKey(KeyCode.S)) { // Move down
                    Camera.main.transform.position += new Vector3(-this.velocity, 0, this.velocity);
                }
            
                if(Input.GetKey(KeyCode.D)) { // Move right
                    Camera.main.transform.position += new Vector3(-this.velocity, 0, -this.velocity);
                }

                if(Input.GetKey(KeyCode.Escape)) {
                    this.isOverviewMode = false;
                }
            }
        }

        public void onClick() {
            this.isOverviewMode = true;
        }
    }
}
