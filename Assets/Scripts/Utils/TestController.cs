using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        GameObject.Find("player").GetComponent<Characters.CharacterController>().setCharacterToTile(GridController.getElementById("7-8"));
        GameObject.Find("player2").GetComponent<Characters.CharacterController>().setCharacterToTile(GridController.getElementById("16-2"));
    }
}
