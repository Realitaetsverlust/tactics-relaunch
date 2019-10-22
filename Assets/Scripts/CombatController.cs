using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using Utils;
using CharacterController = Characters.CharacterController;

public class CombatController : MonoBehaviour {
    public static int gamePhase;
    // 1 = Placement
    // 2 = Combat
    public TurnOrder turnOrder;

    public void Start() {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("combatCharacter");
        this.placeUnits(characters);
        this.turnOrder = new TurnOrder(characters);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
        Debug.Log(this.turnOrder.getNextCharacter().name);
    }

    public void Update() {
        if(CombatController.gamePhase == 2) {
            this._combatBase();
        }
    }

    private void _combatBase() {
        
    }

    public void placeUnits(GameObject[] characters) {
        StartCoroutine(this._startPlacementPhase(characters));
    }

    private IEnumerator _startPlacementPhase(GameObject[] characters) {
        CombatController.gamePhase = 1;

        foreach(var character in characters) {
            Debug.Log(String.Concat("Placing character: ", character.transform.name));
            yield return StartCoroutine(this._placeCharacterBeforeCombat(character));
        }

        Debug.Log("All units placed!");

        CombatController.gamePhase = 2;
        
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