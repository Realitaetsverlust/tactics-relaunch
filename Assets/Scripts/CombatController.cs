using System.Collections.Generic;
using Characters;
using Characters.Abilities;
using Elements;
using InputHandlers;
using UI;
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
                
                Debug.Log(Camera.main);
                Debug.Log(Camera.main.GetComponent<CameraController>());
                Debug.Log(TurnOrder.getActiveCharacter());
                Debug.Log(TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>());
                Debug.Log(TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().getCurrentTileOfCharacter());
                    
                Camera.main.GetComponent<CameraController>().setCameraToTile(TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().getCurrentTileOfCharacter());
                CombatController.characterPlacementDone = false;
            }
        }
    }

    public static void endTurnForCurrentCharacter() {
        GameObject nextChar = TurnOrder.getNextCharacter();
        BaseCommandPanelHandler bcph = GameObject.Find("CombatUI/CharacterControls/BaseCommandPanel").GetComponent<BaseCommandPanelHandler>();
        bcph.enableMove();
        bcph.enableAction();
        nextChar.GetComponent<CombatCharacterController>().turnStart();
    }

    public static void handleAbilityUsage(BaseAbility ability, GameObject target) {
        GameObject caster = TurnOrder.getActiveCharacter();
        
        ability.applyEffectsToTarget(caster, target);
    }
}
