using System;
using UnityEngine;

/*
 * Handles the base wait button in the command panel
 */

namespace UI {
    public class BaseWaitButtonHandler : BaseButton
    {
        public void onClick() {
            CombatUiStateKeeper.displayCommandStep();
			CombatController.endTurnForCurrentCharacter();   
        }
    }
}