using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WorldMovement.Regions;

namespace WorldMovement {
    public abstract class SceneLoader : MonoBehaviour
    {
        public Animator screenFade;
        private static readonly int AnimatorTrigger = Animator.StringToHash("start");

        public void Start() {
            this.screenFade = GameObject.Find("SceneLoader/SceneFader/Image").GetComponent<Animator>();
        }

        public abstract void OnTriggerEnter(Collider other);
        
        protected void loadArea(BaseRegion area) {
            this.StartCoroutine(this._loadSceneWithTransition(area.sceneName, area.spawnPointOnEnter, area.regionName, area.regionSubtext));
        }

        protected void loadWorldMap(BaseRegion areaNameComingFrom) {
            this.StartCoroutine(this._loadSceneWithTransition("Scenes/WorldOverview/WorldOverview", areaNameComingFrom.spawnPointOnExit, "", ""));
        }
        
        private IEnumerator _loadSceneWithTransition(string sceneToLoad, Vector3 spawnCoordinates, string regionName, string regionSubtext) {
            this.screenFade.SetTrigger(SceneLoader.AnimatorTrigger);
            GameObject.Find("SceneLoader/SceneFader/Image/RegionName").GetComponent<Text>().text = regionName;
            GameObject.Find("SceneLoader/SceneFader/Image/RegionSubtext").GetComponent<Text>().text = regionSubtext;

            yield return new WaitForSeconds(3f);
            
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
            
            while (!async.isDone) {
                yield return false;
            }
            
            GameObject.Find("SceneLoader/SceneFader/Image/RegionName").GetComponent<Text>().text = regionName;
            GameObject.Find("SceneLoader/SceneFader/Image/RegionSubtext").GetComponent<Text>().text = regionSubtext;

            GameObject.Find("Player").GetComponent<PlayerMovementController>().spawnCharacterToLocation(spawnCoordinates);
        }
    }
}
