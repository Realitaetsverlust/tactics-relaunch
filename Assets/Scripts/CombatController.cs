using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Elements;
using UnityEditor;
using UnityEngine;
using Utils;
using CharacterController = Characters.CharacterController;

public class CombatController : MonoBehaviour {
    public static int gamePhase;
    public GameObject currentCharacter;
    // 1 = Placement
    // 2 = Combat
    private Camera _camera;
    private CameraController _cameraController;

    public void Start() {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("combatCharacter");
        this.placeUnits(characters);
        TurnOrder.buildCharacterList(characters);
        this._camera = Camera.main;
        if(this._camera != null) {
            this._cameraController = this._camera.GetComponent<CameraController>();
        }
    }

    public void Update() {
        if(CombatController.gamePhase == 2) {
            this._combatBase();
        }
    }

    private void _combatBase() {
        
    }
    
    public void endTurnForCurrentCharacter() {
        GameObject nextChar = TurnOrder.getNextCharacter();
        this._cameraController.setCameraToCharacter(nextChar);
    }

    public void initiateMovementForCurrentCharacter() {
        CharacterController activeCharacter = TurnOrder.getActiveCharacter().GetComponent<CharacterController>();
        HashSet<GameObject> foundRange = Rangefinder.findAllTilesInRange(activeCharacter.getCurrentTileOfCharacter(), 6);
        Range rangeObject = new Range(foundRange, "walking");
        rangeObject.colorRange();
    }

    public void placeUnits(GameObject[] characters) {
        this.StartCoroutine(this._startPlacementPhase(characters));
    }

    private IEnumerator _startPlacementPhase(GameObject[] characters) {
        CombatController.gamePhase = 1;

        foreach(var character in characters) {
            yield return StartCoroutine(this._placeCharacterBeforeCombat(character));
        }

        CombatController.gamePhase = 2;

        this.endTurnForCurrentCharacter();
    }

    private IEnumerator _placeCharacterBeforeCombat(GameObject character) {
        while(Input.GetKeyDown(KeyCode.Mouse0) == false || GridController.getActiveTile() == null) {
            yield return null;
        }
        
        character.GetComponent<CharacterController>().setCharacterToTile(GridController.getActiveTile());
        yield return new WaitForSeconds(0.1f);
    }
}
