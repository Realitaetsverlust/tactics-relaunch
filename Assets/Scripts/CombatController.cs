using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterController = Characters.CharacterController;

public class CombatController : MonoBehaviour {
    public static int gamePhase;
    // 1 = Placement
    // 2 = Combat
    
    public void Start() {
        StartCoroutine(this._startPlacementPhase(GameObject.FindGameObjectsWithTag("combatCharacter")));
    }

    private IEnumerator _startPlacementPhase(GameObject[] characters) {
        CombatController.gamePhase = 1;

        foreach(var character in characters) {
            Debug.Log(String.Concat("Placing character: ", character.transform.name));
            yield return StartCoroutine(this._placeCharacterBeforeCombat(character));
        }
        
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator _placeCharacterBeforeCombat(GameObject character) {
        while(Input.GetKeyDown(KeyCode.Mouse0) == false) {
            yield return null;
        }
        
        character.GetComponent<CharacterController>().setCharacterToTile(GridController.getActiveTile());
        yield return new WaitForSeconds(0.1f);
    }
}
