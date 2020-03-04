using System;
using Elements;
using UnityEngine;

namespace UI {
    public class CharacterControlHandler : MonoBehaviour {
        private GameObject _wrapper;
        private GameObject _baseCommandPanel;
        private GameObject _actionSelectionPanel;
        private GameObject _abilitySelectionPanel;

        public void Start() {
            this._wrapper = GameObject.Find("CharacterControls");
            this._baseCommandPanel = this._wrapper.transform.Find("BaseCommandPanel").gameObject;
            this._actionSelectionPanel = this._wrapper.transform.Find("ActionCommandPanel").gameObject;
            this._abilitySelectionPanel = this._wrapper.transform.Find("AbilityCommandPanel").gameObject;
        }

        public void hideCombatUi() {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }

        public void showCombatUi() {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Escape) && CombatUiStateKeeper.jumpBackEnabled) {
                this.jumpOneStepBack();
            }
        }

        private void jumpOneStepBack() {
            Debug.Log(this.name);
            Debug.Log(CombatUiStateKeeper.step);
            if(CombatUiStateKeeper.step == 3) {
                CombatUiStateKeeper.displayActionSelectionStep();
            } else if(CombatUiStateKeeper.step == 2) {
                CombatUiStateKeeper.displayCommandStep();
            }
        }
    }
}