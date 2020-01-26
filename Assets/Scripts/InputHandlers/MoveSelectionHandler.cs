using System;
using System.Runtime.InteropServices;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using UnityEngine;
using Utils;

namespace InputHandlers {
    public class MoveSelectionHandler : MonoBehaviour
    {
        private bool _moveIsSelected = false;
        private GameObject _combatUi;
        private Range _abilityRangeSelection;

        public void Awake() {
            this._combatUi = GameObject.Find("CombatUI");
        }

        public void Update() {
            if(this._moveIsSelected) {
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this._combatUi.GetComponent<CanvasGroup>().alpha = 1;
                    this._abilityRangeSelection.hideRange();
                    this._moveIsSelected = false;
                }
            }
        }
        
        public void onClick() {
            this._moveIsSelected = true;
            this._combatUi.GetComponent<CanvasGroup>().alpha = 0;
            
            BaseAbility ability = AbilityFactory.getAbility(this.name);

            this._abilityRangeSelection = new Range(Rangefinder.findAllTilesInRange(TurnOrder.getActiveCharacter().GetComponent<CharacterBase>().getCurrentTileOfCharacter(), ability.range), "ability");
            this._abilityRangeSelection.colorRange();
        }
    }
}
