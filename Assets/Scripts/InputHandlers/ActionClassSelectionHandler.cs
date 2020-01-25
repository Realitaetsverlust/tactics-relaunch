﻿using System.Collections.Generic;
using Characters;
using Characters.Moves;
using Characters.Utils;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace InputHandlers {
    public class ActionClassSelectionHandler : MonoBehaviour
    {
        public void onClick() {
            this.populateMoveSelectionInput();
        }

        public void populateMoveSelectionInput() {
            string job = this.name;
            Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;

            foreach(KeyValuePair<string, BaseMove> jobSelection in moveset.movelist[job]) {
                string moveName = jobSelection.Key;

                GameObject button = GameObject.Instantiate(Resources.Load("Prefabs/UI/MoveSelectionButton") as GameObject, GameObject.Find("BaseMoveSelectionPanel").transform);
                button.name = moveName;
                button.GetComponentInChildren<Text>().text = moveName;
            }
        }
    }
}
