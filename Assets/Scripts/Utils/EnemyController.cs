using System.Runtime.CompilerServices;
using Characters;
using Elements;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject _godObject;
    private GameObject[] _characters;
    void Start()
    {
        this._characters = this.fetchEnemyUnits();

        this._characters[0].gameObject.GetComponent<CombatCharacterController>().setCharacterToTile(GridController.getElementById("16-4"));
        this._characters[1].gameObject.GetComponent<CombatCharacterController>().setCharacterToTile(GridController.getElementById("15-3"));
        this._characters[2].gameObject.GetComponent<CombatCharacterController>().setCharacterToTile(GridController.getElementById("14-4"));
        this._characters[3].gameObject.GetComponent<CombatCharacterController>().setCharacterToTile(GridController.getElementById("11-2"));
    }

    public GameObject[] fetchEnemyUnits() {
        this._godObject = GameObject.Find("GodObject");
        return GameObject.FindGameObjectsWithTag("enemyCharacter");
    }
}
