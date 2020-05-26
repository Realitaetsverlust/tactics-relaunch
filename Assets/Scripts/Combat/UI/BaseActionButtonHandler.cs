using System;
using UnityEngine;

/*
 * Handles the base action button in the command panel
 */

namespace UI {
    public class BaseActionButtonHandler : BaseButton
    {
        public void onClick() {
            CombatUiStateKeeper.displayActionSelectionStep();
            CombatUiStateKeeper.step = 2;
            this.actionCommandPanelHandler.populatePanel();
        }
    }
}
