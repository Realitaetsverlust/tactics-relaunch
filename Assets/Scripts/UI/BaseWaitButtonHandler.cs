using System;
using Characters;
using UnityEngine;
using Utils;

/*
 * Handles the base wait button in the command panel
 */

namespace UI {
    public class BaseWaitButtonHandler : BaseButton
    {
        public void onClick() {
            CombatUiStateKeeper.displayCommandStep();
			CombatController.endTurnForCurrentCharacter();
            Camera.main.GetComponent<CameraController>().setCameraToTile(TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().getCurrentTileOfCharacter());
        }
    }
}