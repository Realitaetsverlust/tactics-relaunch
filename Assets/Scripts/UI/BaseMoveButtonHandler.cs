using System;
using System.Collections.Generic;
using Characters;
using Elements;
using InputHandlers;
using UnityEngine;
using Utils;

/*
 * Handles the base move button in the command panel
 */

namespace UI {
    public class BaseMoveButtonHandler : BaseButton {
	    private bool _isMovementPhase = false;
        private Range _currentMovementRange;

        public void Update() {
            if(this._isMovementPhase) {
                Raycaster.castRay(1 << 9);

                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this._isMovementPhase = false;
                    this._currentMovementRange.hideRange();
                    this.abilityCommandPanelHandler.displayCommandStep();
                }
                
                if(Input.GetKeyDown(KeyCode.Mouse0)) {
                    GameObject clickedTile = GridController.getActiveTile();
                    GridElement gridElement = GridController.getActiveTile().GetComponent<GridElement>();
                    GameObject currentCharacterOnThisTile = GridController.getActiveTile().GetComponent<GridElement>().getCharacterOnThisTile();

                    if(this._currentMovementRange.isTileWithinRange(GridController.getActiveTile()) &&
                       currentCharacterOnThisTile == null &&
                       gridElement.tileType.passable == true) {
                        this._isMovementPhase = false;
                        TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().setCharacterToTile(clickedTile);
                        this.abilityCommandPanelHandler.displayCommandStep();
                        this.baseCommandPanelHandler.disableMove();
                        this._currentMovementRange.hideRange();
                    }
                    
                    //play "wrong sound"
                }
            }
        }

        public void onClick() {
            CombatCharacterController activeCharacter = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>();
            HashSet<GameObject> foundRange = Rangefinder.findAllTilesInRange(
                activeCharacter.getCurrentTileOfCharacter(), 
                activeCharacter.GetComponent<CombatCharacterController>().walkRange
            );
            this._currentMovementRange = new Range(foundRange, "movement");
            _currentMovementRange.colorRange();
            this._isMovementPhase = true;
        }
    }
}