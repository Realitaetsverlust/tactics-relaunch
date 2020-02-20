using System;
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
        public bool targetMode;
        private BaseAbility _ability;

        public void Start() {
            base.Start();
            this.layerMask = 1 << 9;
        }

        public void Update() {
            if(this.targetMode) {
                Raycaster.castRay(this.layerMask);
            }

            if(Input.GetKey(KeyCode.Escape)) {
                this.targetMode = false;
            }

            if(Input.GetKey(KeyCode.Mouse0)) {
                GameObject target = GridController.getActiveTile().GetComponent<GridElement>().getCharacterOnThisTile();
                CombatController.handleAbilityUsage(this._ability, target);
            }
        }

        public void onClick() {
            this.abilityCommandPanelHandler.hideCombatUi();
            
            this._ability = AbilityFactory.getAbility(this.name);

            Range abilityRangeSelection = new Range(Rangefinder.findAllTilesInRange(TurnOrder.getActiveCharacter().GetComponent<CharacterBase>().getCurrentTileOfCharacter(), this._ability.range), "ability");
            abilityRangeSelection.colorRange();
            this.targetMode = true;
        }
    }
}
