using Elements;
using UnityEngine;

namespace UI {
    public class CharacterControlHandler : MonoBehaviour {
        private GameObject _wrapper;
        private GameObject _baseCommandPanel;
        private GameObject _actionSelectionPanel;
        private GameObject _abilitySelectionPanel;
        protected int step = 1;

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

        public void displayCommandStep() {
            this.showCombatUi();
            this.step = 1;
            this._baseCommandPanel.GetComponent<PanelManager>().showPanel();
            this._actionSelectionPanel.GetComponent<PanelManager>().hidePanel();
            this._abilitySelectionPanel.GetComponent<PanelManager>().hidePanel();
        }

        public void displayActionSelectionStep() {
            this.showCombatUi();
            this.step = 2;
            this._baseCommandPanel.GetComponent<PanelManager>().showPanel();
            this._actionSelectionPanel.GetComponent<PanelManager>().showPanel();
            this._abilitySelectionPanel.GetComponent<PanelManager>().hidePanel();
        }

        public void displayAbilitySelectionStep() {
            this.showCombatUi();
            this.step = 3;
            this._baseCommandPanel.GetComponent<PanelManager>().showPanel();
            this._actionSelectionPanel.GetComponent<PanelManager>().showPanel();
            this._abilitySelectionPanel.GetComponent<PanelManager>().showPanel();
        }
    }
}