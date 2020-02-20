using UnityEngine;

/*
 * Handles the action buttons in the second panel (attack, *class*, *class*, item)
 */

namespace UI {
    public class ActionSelectionButtonHandler : BaseButton
    {
        public void onClick() {
            this.abilityCommandPanelHandler.populatePanel(this.name);
            this.abilityCommandPanelHandler.displayAbilitySelectionStep();
        }
    }
}
