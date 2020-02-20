using System;
using UnityEngine;

/*
 * Handles the base action button in the command panel
 */

namespace UI {
    public class BaseActionButtonHandler : BaseButton
    {
        public void onClick() {
            this.actionCommandPanelHandler.populatePanel();
            this.actionCommandPanelHandler.displayActionSelectionStep();
        }
    }
}
