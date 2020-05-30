using UnityEngine;

namespace WorldMovement.Regions.Ebonshire {
    public class EbonshireEntryController : MonoBehaviour {
        public void OnTriggerEnter(Collider other) {
            GlobalSceneLoader.loadScene(new Ebonshire());
        }
    }
}