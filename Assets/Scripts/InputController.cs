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
        this._ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity)) {
            GridController.markNewTileAsActive(this._hit.transform.parent.name == "mark" ? this._hit.transform.parent.parent.name : this._hit.transform.parent.name);
        }
    }
}
