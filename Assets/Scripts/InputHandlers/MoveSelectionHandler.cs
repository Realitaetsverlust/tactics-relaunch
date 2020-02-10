using System;
using System.Runtime.InteropServices;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using UnityEngine;
using Utils;

namespace InputHandlers {
    public class MoveSelectionHandler : MonoBehaviour {
        private GameObject _godObject;
        private bool _moveIsSelected = false;
        private GameObject _combatUi;
        private BaseAbility _ability;
        private Range _abilityRangeSelection;
        private RaycastHit _hit;
        private int _layerMask;

        public MoveSelectionHandler() {
            this._layerMask = 1 << 9;
        }

        public void Start() {
            this._combatUi = GameObject.Find("CombatUI");
            this._godObject = GameObject.Find("GodObject");
        }

        public void Update() {
            if(this._ability != null && this._ability.GetType().Name == this.gameObject.name && this._moveIsSelected) {
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this._combatUi.GetComponent<CanvasGroup>().alpha = 1;
                    this._abilityRangeSelection.hideRange();
                    this._moveIsSelected = false;
                }
                
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out this._hit, float.PositiveInfinity, this._layerMask)) {
                    CombatCharacterController charControl = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>();
                    if(Input.GetKeyDown(KeyCode.Mouse0)) {
                        GameObject activeTile = GridController.getActiveTile();
                        if(this._abilityRangeSelection.isTileWithinRange(activeTile) && activeTile.GetComponent<GridElement>().getCharacterOnThisTile() != null && activeTile.GetComponent<GridElement>().getCharacterOnThisTile().GetComponent<CombatCharacterController>().isAttackable == true) {
                            GameObject targetPlayer = activeTile.GetComponent<GridElement>().getCharacterOnThisTile();
                            targetPlayer.GetComponent<CombatCharacterController>().subtractHp(this._ability.baseDamage);
                            this._combatUi.GetComponent<CanvasGroup>().alpha = 1;
                            this._abilityRangeSelection.hideRange();
                            this._moveIsSelected = false;
                            this._godObject.GetComponent<ActionInputHandler>().disableButton();
                        }
                    }
                }
            }
        }
        
        public void onClick() {
            this._combatUi.GetComponent<CanvasGroup>().alpha = 0;
            
            this._ability = AbilityFactory.getAbility(this.name);

            this._abilityRangeSelection = new Range(Rangefinder.findAllTilesInRange(TurnOrder.getActiveCharacter().GetComponent<CharacterBase>().getCurrentTileOfCharacter(), this._ability.range), "ability");
            this._abilityRangeSelection.colorRange();
            this._moveIsSelected = true;
        }
    }
}
