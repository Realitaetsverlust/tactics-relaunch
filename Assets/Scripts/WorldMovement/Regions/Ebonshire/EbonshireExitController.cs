using UnityEngine;

namespace WorldMovement.Regions.Ebonshire {
    public class EbonshireExitController : MonoBehaviour {
        public void OnTriggerEnter(Collider other) {
            GlobalSceneLoader.loadWorldMap(new Ebonshire());
        }
    }
}