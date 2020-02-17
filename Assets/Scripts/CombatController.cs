using System.Collections.Generic;
using Characters;
using Elements;
using InputHandlers;
using UnityEngine;
using Utils;

public class CombatController : MonoBehaviour {
    public static int gamePhase;
    private GameObject _godObject;
    // 1 = Placement
    // 2 = Combat
    private Camera _camera;
    private CameraController _cameraController;
    public static bool characterPlacementDone = false;

    public void Start() {
        this._godObject = GameObject.Find("GodObject");
        GameObject[] characters = GameObject.FindGameObjectsWithTag("combatCharacter");
        this._godObject.GetComponent<UnitPlacementHandler>().placeUnits(characters);
        TurnOrder.buildCharacterList(characters);
        this._camera = Camera.main;
        if(this._camera != null) {
            this._cameraController = this._camera.GetComponent<CameraController>();
        }

    }

    public void Update() {
        if(CombatController.gamePhase == 2) {
            if(CombatController.characterPlacementDone) {
                GameObject.Find("BaseCommandPanel").GetComponent<PanelManager>().showPanel();
                this._cameraController.setCameraToCharacter(TurnOrder.getActiveCharacter());
                CombatController.characterPlacementDone = false;
            }
            this._combatBase();
        }
    }

    private void _combatBase() {
        
    }

    public void initiateMovementForCurrentCharacter() {
        CombatCharacterController activeCharacter = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>();
        HashSet<GameObject> foundRange = Rangefinder.findAllTilesInRange(
            activeCharacter.getCurrentTileOfCharacter(), 
            activeCharacter.GetComponent<CombatCharacterController>().walkRange
            );
        Range rangeObject = new Range(foundRange, "walking");
        this._godObject.GetComponent<MovementInputHandler>().setCurrentRangeObject(rangeObject);
        rangeObject.colorRange();
    }
    
        
    public void endTurnForCurrentCharacter() {
        GameObject nextChar = TurnOrder.getNextCharacter();
        this._godObject.GetComponent<MovementInputHandler>().enableMoveButton();
        this._godObject.GetComponent<ActionInputHandler>().enableButton();
        this._cameraController.setCameraToCharacter(nextChar);
        nextChar.GetComponent<CombatCharacterController>().turnStart();
    }
}
