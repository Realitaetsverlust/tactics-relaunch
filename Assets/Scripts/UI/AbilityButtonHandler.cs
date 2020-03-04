﻿using System;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using InputHandlers;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

/*
 * Handles the ability selection buttons in the third panel
 */

namespace UI {
    public class AbilityButtonHandler : BaseButton {
        public int layerMask;
        private bool _targetMode = false;
        public Range abilityRangeSelection;
        private BaseAbility _ability;
        private GridController _gridController;

        public void Start() {
            base.Start();
            this.layerMask = 1 << 9;
            this._gridController = GameObject.Find("terrainParent").GetComponent<GridController>();
        }

        public void Update() {
            if(this._targetMode) {
                Raycaster.castRay(this.layerMask);
                
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this._targetMode = false;
                    CombatUiStateKeeper.displayAbilitySelectionStep();
                    this.abilityRangeSelection.hideRange();
                    CombatUiStateKeeper.jumpBackEnabled = true;
                }
                
                if(Input.GetKeyDown(KeyCode.Mouse0)) {
                    GameObject target = GridController.getActiveTile().GetComponent<GridElement>().getCharacterOnThisTile();
                    CombatController.handleAbilityUsage(this._ability, target);
                    this._targetMode = false;
                    CombatUiStateKeeper.displayCommandStep();
                    this.baseCommandPanelHandler.disableAction();
                    this.abilityRangeSelection.hideRange();
                }
            }
        }

        public void onClick() {
            CombatUiStateKeeper.hideCombatUi();
            
            this._ability = AbilityFactory.getAbility(this.name);

            this.abilityRangeSelection = new Range(Rangefinder.findAllTilesInRange(TurnOrder.getActiveCharacter().GetComponent<CharacterBase>().getCurrentTileOfCharacter(), this._ability.range), "ability");
            this.abilityRangeSelection.colorRange();
            this._targetMode = true;
            CombatUiStateKeeper.jumpBackEnabled = false;
        }
    }
}
