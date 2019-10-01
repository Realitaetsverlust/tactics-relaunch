using System;
using System.Collections;
using System.Collections.Generic;
using Elements;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private readonly int _layerMask;

    public InputController() {
        this._layerMask = 1 << 9;
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
    }
}
