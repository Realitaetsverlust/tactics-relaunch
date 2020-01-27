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
        private BaseAbility _ability;
        private Range _abilityRangeSelection;
        private Ray _ray;
        private RaycastHit _hit;
        private int _layerMask;

        public MoveSelectionHandler() {
            this._layerMask = 1 << 9;
        }

        public void Awake() {
            this._combatUi = GameObject.Find("CombatUI");
        }

        public void Update() {
            if(this._ability != null && this._ability.GetType().Name == this.gameObject.name && this._moveIsSelected) {
                if(Input.GetKeyDown(KeyCode.Escape)) {
                    this._combatUi.GetComponent<CanvasGroup>().alpha = 1;
                    this._abilityRangeSelection.hideRange();
                    this._moveIsSelected = false;
                }
                
                if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
                    Debug.Log("yey");
                    CombatCharacterController charControl = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>();
                    if(Input.GetKeyDown(KeyCode.Mouse0)) {
                        GameObject activeTile = GridController.getActiveTile();
                        Debug.Log(activeTile);
                        if(this._abilityRangeSelection.isTileWithinRange(activeTile) && activeTile.GetComponent<GridElement>().getCharacterOnThisTile() != null) {
                            GameObject targetPlayer = activeTile.GetComponent<GridElement>().getCharacterOnThisTile();
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
