using System.Collections.Generic;
using System.Linq;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
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
            //Clear the panel from all objects
            GameObject parentPanel = GameObject.Find("BaseMoveSelectionPanel");
            List<GameObject> children = (from Transform child in parentPanel.transform select child.gameObject).ToList();
            children.ForEach(Object.Destroy);
            
            //for some reason, destroying the object does not set the childCount immediatly. So I'm using DetachChildren which resets the childcount to 0.
            parentPanel.transform.DetachChildren();
            
            string job = this.name;
            Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;

            foreach(KeyValuePair<string, BaseAbility> jobSelection in moveset.movelist[job]) {
                string moveName = jobSelection.Key;

                GameObject button = GameObject.Instantiate(Resources.Load("Prefabs/UI/MoveSelectionButton") as GameObject, parentPanel.transform);
                button.name = moveName;
                button.GetComponentInChildren<Text>().text = moveName;
            }
            
            parentPanel.GetComponent<PanelManager>().resizePanel();
        }
    }
}
