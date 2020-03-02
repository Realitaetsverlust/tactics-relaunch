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

        public void Update() {
            if(CombatUiStateKeeper.jumpBackEnabled == true) {
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this.jumpOneStepBack();
                }
            }
        }

        public void hideCombatUi() {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }

        public void showCombatUi() {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        }

        public void jumpOneStepBack() {
            if(CombatUiStateKeeper.step == 3) {
                this.displayActionSelectionStep();
            } else if(CombatUiStateKeeper.step == 2) {
                this.displayCommandStep();
            }
        }

        public void displayCommandStep() {
            this.showCombatUi();
            CombatUiStateKeeper.step = 1;
            CombatUiStateKeeper.displayCommandStep();
        }

        public void displayActionSelectionStep() {
            this.showCombatUi();
            CombatUiStateKeeper.step = 2;
            CombatUiStateKeeper.displayActionSelectionStep();

        }

        public void displayAbilitySelectionStep() {
            this.showCombatUi();
            CombatUiStateKeeper.step = 3;
            CombatUiStateKeeper.displayAbilitySelectionStep();
        }
    }
}