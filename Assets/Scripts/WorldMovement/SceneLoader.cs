using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldMovement.Regions;

namespace WorldMovement {
    public abstract class SceneLoader : MonoBehaviour
    {
        public Animator transition;
        private static readonly int AnimatorTrigger = Animator.StringToHash("start");

        public void Start() {
            this.transition = GameObject.Find("SceneLoader/SceneFader/Image").GetComponent<Animator>();
        }

        public abstract void OnTriggerEnter(Collider other);
        
        protected void loadArea(BaseRegion area) {
            this.StartCoroutine(this._loadSceneWithTransition(area.sceneName, area.spawnPointOnEnter));
        }

        protected void loadWorldMap(BaseRegion areaNameComingFrom) {
            this.StartCoroutine(this._loadSceneWithTransition("Scenes/WorldOverview/WorldOverview", areaNameComingFrom.spawnPointOnExit)); 
        }

        private IEnumerator _loadSceneWithTransition(string sceneToLoad, Vector3 spawnCoordinates) {
            this.transition.SetTrigger(SceneLoader.AnimatorTrigger);
            
            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(sceneToLoad);
            GameObject.Find("Player").GetComponent<PlayerMovementController>().spawnCharacterToLocation(spawnCoordinates);
        }
    }
}
