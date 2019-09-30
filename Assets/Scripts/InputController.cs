using System;
using System.Collections;
using System.Collections.Generic;
using Elements;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    private int _layerMask;

    private InputController() {
        this._layerMask = 1 << 9;
    }

    void Update() {
        if(CameraController.main != null) {
            this._ray = CameraController.main.ScreenPointToRay(Input.mousePosition);
        }

        if(Physics.Raycast(this._ray, out this._hit, float.PositiveInfinity, this._layerMask)) {
            Debug.Log(this._hit.transform.name);
            //var parent = this._hit.transform.parent;
            //GridController.markNewTileAsActive(parent.name == "mark" ? parent.parent.name : parent.name);
        }
    }
}
