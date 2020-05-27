using UnityEngine;

namespace WorldMovement.Regions.Ebonshire {
    public class EbonshireEntryController : SceneLoader
    {
        public override void OnTriggerEnter(Collider other) {
            this.loadArea(new Ebonshire());
        }
        
    }
}