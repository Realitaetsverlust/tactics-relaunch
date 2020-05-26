using UnityEngine;

namespace UI {
    public class BaseButton : MonoBehaviour {
        protected GameObject characterControlUi;
        protected GameObject baseCommandPanel;
        protected BaseCommandPanelHandler baseCommandPanelHandler;
        protected GameObject actionCommandPanel;
        protected ActionCommandPanelHandler actionCommandPanelHandler;
        protected GameObject abilityCommandPanel;
        protected AbilityCommandPanelHandler abilityCommandPanelHandler;
        public void Start() {
            this.characterControlUi = GameObject.Find("CharacterControls");
            this.baseCommandPanel = GameObject.Find("BaseCommandPanel");
            this.baseCommandPanelHandler = this.baseCommandPanel.GetComponent<BaseCommandPanelHandler>();
            this.actionCommandPanel = GameObject.Find("ActionCommandPanel");
            this.actionCommandPanelHandler = this.actionCommandPanel.GetComponent<ActionCommandPanelHandler>();
            this.abilityCommandPanel = GameObject.Find("AbilityCommandPanel");
            this.abilityCommandPanelHandler = this.abilityCommandPanel.GetComponent<AbilityCommandPanelHandler>();
        }
    }
}
