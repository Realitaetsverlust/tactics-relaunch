using UnityEngine;

namespace WorldMovement.Regions.Ebonshire {
    public class Ebonshire : BaseRegion {
        public Ebonshire() {
            this.regionName = "Ebonshire";
            this.regionSubtext = "The shining capital of ventorat";
            this.spawnPointOnEnter = new Vector3(-25, 1, -10);
            this.spawnPointOnExit = new Vector3(80f, 7f, 315f);
            this.sceneName = "Scenes/WorldOverview/Regions/Ebonshire";
        }
    }
}