using System;
using System.Collections;
using System.Collections.Generic;
using Elements;
using UnityEngine;
using UnityEngine.UIElements;

public class InputController : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private readonly int _layerMask;
    private Camera _camera;
    private CameraController _cameraController;

    public InputController() {
        this._layerMask = 1 << 9;
    }

    public void Awake() {
        this._camera = Camera.main;
        this._cameraController = this._camera.GetComponent<CameraController>();
    }

    void Update() {
        this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
            Transform parent = this._hit.transform.parent;
            GridElement parentController = parent.gameObject.GetComponent<GridElement>();
            GridController.markNewTileAsActive(parent.name);

            GameObject character = parentController.getCharacterOnThisTile();
            
            if(character != null) {
                BaseCharacterStatPanel.showCharacterPanelForCharacter(character);
            } else {
                BaseCharacterStatPanel.hideCharacterPanel();
            }
        }

        this.handleKeystroke();
    }

    public void handleKeystroke() {
        Debug.Log(CombatController.activeCharacter);
        if(Input.GetKeyDown(KeyCode.Q)) {
            this._cameraController.rotateLeft(CombatController.activeCharacter);
        }
        
        if(Input.GetKeyDown(KeyCode.E)) {
            this._cameraController.rotateRight(CombatController.activeCharacter);
        }
    }
}
