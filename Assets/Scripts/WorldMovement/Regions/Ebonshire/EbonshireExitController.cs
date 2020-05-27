using UnityEngine;

namespace WorldMovement.Regions.Ebonshire {
    public class EbonshireExitController : SceneLoader {
        public override void OnTriggerEnter(Collider other) {
            this.loadWorldMap(new Ebonshire());
        }
    }
}