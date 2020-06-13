using UnityEngine;
using WorldMovement.Regions.Ebonshire;
using WorldMovement.UI;

namespace WorldMovement {
    public class WorldMapController : MonoBehaviour {
        public GameObject worldMapUi;
        private WorldMapUiController _worldMapUiController;
        public GameObject player;
        private PlayerMovementController _pmc;
        
        public void Start() {
            GlobalSceneLoader.loadWorldMap(new Ebonshire(), 0);
            this._worldMapUiController = this.worldMapUi.GetComponent<WorldMapUiController>();
            this._pmc = this.player.GetComponent<PlayerMovementController>();
        }
        public void Update() {
            if(Input.GetKeyDown(KeyCode.I)) {
                this._pmc.disableMovement();
                this._worldMapUiController.toggleUi();
            }
        }
    }
}