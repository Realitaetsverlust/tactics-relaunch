using UnityEngine;

namespace Elements {
    public class UiHandler : MonoBehaviour {
        private GameObject _godObject;
        public void Start() {
            this._godObject = GameObject.Find("GodObject");
        }
        
        public void onMoveClick() {
            
        }

        public void onActionClick() {
            
        }
        
        public void onWaitClick() {
            this._godObject.GetComponent<CombatController>().swapToNextCharacter();
        }
    }
}
