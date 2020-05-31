using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WorldMovement.Regions;
using Object = UnityEngine.Object;

namespace WorldMovement {
    public class GlobalSceneLoader : MonoBehaviour
    {
        private static GlobalSceneLoader instance { get; set; }
    
        public Text regionNameField;
        public Text regionSubtextField;

        public Animator screenFade;
        public GameObject player;
    
        private Scene _currentScene;
        private static readonly int BeginTransition = Animator.StringToHash("BeginTransition");
        private static readonly int EndTransition = Animator.StringToHash("EndTransition");

        private void Awake() {
            if (GlobalSceneLoader.instance != null && GlobalSceneLoader.instance != this) {
                Debug.LogError("You have two scene loaders present when there should be only one!");
            }

            GlobalSceneLoader.instance = this;
        }
    
        public static void loadScene(BaseRegion region, float transitionTime = 3f) {
            GlobalSceneLoader.instance.StartCoroutine(GlobalSceneLoader.instance._loadScene(region.sceneName, region.spawnPointOnEnter, region.regionName, region.regionSubtext, transitionTime));
        }    
        
        public static void loadWorldMap(BaseRegion region, float transitionTime = 3f) {
            GlobalSceneLoader.instance.StartCoroutine(GlobalSceneLoader.instance._loadScene("Scenes/WorldOverview/WorldOverview", region.spawnPointOnExit, "", "", transitionTime));
        }
    
        private IEnumerator _loadScene(string nextScene, Vector3 spawnCoordinates, string regionName, string regionSubtext, float transitionTime) {
            this.screenFade.SetTrigger(GlobalSceneLoader.BeginTransition);
            this.player.GetComponent<PlayerMovementController>().disableMovement();
            
            this.regionNameField.text = regionName;
            this.regionSubtextField.text = regionSubtext;

            yield return new WaitForSeconds(transitionTime);

            if(this._currentScene.isLoaded) {
                SceneManager.UnloadSceneAsync(this._currentScene);
            }

            SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
            this._currentScene = SceneManager.GetSceneByPath(String.Concat("Assets/", nextScene, ".unity"));

            this.player.GetComponent<PlayerMovementController>().spawnCharacterToLocation(spawnCoordinates);
            this.screenFade.SetTrigger(GlobalSceneLoader.EndTransition);
            this.player.GetComponent<PlayerMovementController>().enableMovement();
        }
    }
}
