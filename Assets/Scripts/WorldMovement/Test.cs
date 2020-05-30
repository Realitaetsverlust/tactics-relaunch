using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WorldMovement;
using WorldMovement.Regions.Ebonshire;

public class Test : MonoBehaviour
{
    public void Start() {
        GlobalSceneLoader.loadWorldMap(new Ebonshire(), 0);
    }
}
