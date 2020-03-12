using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace UI {
    public class MapOverviewHandler : MonoBehaviour {
        [HideInInspector]
        public bool isOverviewMode = false;
        public Vector3 velocity = new Vector3(0.5f, 0, 0.5f);
        public Dictionary<string, float> maximumBoundsOfPlayingField;

        public void Start() {
            this.maximumBoundsOfPlayingField = GridController.getMaximumBoundsOfPlayingField();
        }

        public void Update() {
            if(this.isOverviewMode) {
                Vector3 currentVelocity = this.velocity;

                if(Input.GetKey(KeyCode.W)) { // Move upwards
                    Camera.main.transform.position += new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                }
                            
                if(Input.GetKey(KeyCode.S)) { // Move down
                    Camera.main.transform.position += new Vector3(-Camera.main.transform.forward.x, 0, -Camera.main.transform.forward.z);
                }
            
                if(Input.GetKey(KeyCode.A)) { // Move left
                    Camera.main.transform.position += -Camera.main.transform.right;
                }
            
                if(Input.GetKey(KeyCode.D)) { // Move right
                    Camera.main.transform.position += Camera.main.transform.right;                }

                if(Input.GetKey(KeyCode.Escape)) {
                    this.isOverviewMode = false;
                }
            }
        }

        public void onClick() {
            this.isOverviewMode = this.isOverviewMode != true;
        }
    }
}
