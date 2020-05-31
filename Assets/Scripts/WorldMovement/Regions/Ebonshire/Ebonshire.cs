using UnityEngine;

namespace WorldMovement.Regions.Ebonshire {
    public class Ebonshire : BaseRegion {
        public Ebonshire() {
            this.regionName = "Ebonshire";
            this.regionSubtext = "The shining capital of ventorat";
            this.spawnPointOnEnter = new Vector3(240, 0, 400);
            this.spawnPointOnExit = new Vector3(80f, 6.5f, 315f);
            this.sceneName = "Scenes/WorldOverview/Regions/Ebonshire";
        }
    }
}