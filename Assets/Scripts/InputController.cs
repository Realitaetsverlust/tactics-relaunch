using System;
using System.Collections;
using System.Collections.Generic;
using Elements;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;

    void Update() {
        if(Camera.main != null) {
            this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity)) {
            var parent = this._hit.transform.parent;
            GridController.checkForCharacterPanelDisplay();
            GridController.markNewTileAsActive(parent.name == "mark" ? parent.parent.name : parent.name);
        }
    }
}
