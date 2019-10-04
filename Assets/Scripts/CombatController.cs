using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {
    public static int gamePhase;
    // 1 = Placement
    // 2 = Combat
    
    public void Start() {
        this._startPlacementPhase();
    }

    private void _startPlacementPhase() {
        CombatController.gamePhase = 1;
        GameObject[] characters = GameObject.FindGameObjectsWithTag("combactCharacter");

        foreach(var character in characters) {
            this._placeCharacterBeforeCombat(character);
        }
    }

    private void _placeCharacterBeforeCombat(GameObject character) {
        
    }
}
