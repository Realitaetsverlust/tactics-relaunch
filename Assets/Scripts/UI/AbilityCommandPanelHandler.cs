using System.Collections.Generic;
using System.Linq;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI {
    public class AbilityCommandPanelHandler : MonoBehaviour
    {
        public void populatePanel(string job) {
            //Clear the panel from all objects
            List<GameObject> children = (from Transform child in this.gameObject.transform select child.gameObject).ToList();
            children.ForEach(Object.Destroy);
            
            //for some reason, destroying the object does not set the childCount immediately. So I'm using DetachChildren which resets the child count to 0.
            this.gameObject.transform.DetachChildren();
            
            Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;
            
            foreach(KeyValuePair<string, BaseAbility> jobSelection in moveset.movelist[job]) {
                string moveName = jobSelection.Key;

                GameObject button = GameObject.Instantiate(Resources.Load("Prefabs/UI/AbilityButton") as GameObject, this.gameObject.transform);
                button.name = moveName;
                button.GetComponentInChildren<Text>().text = moveName;
            }
            
            this.gameObject.GetComponent<PanelManager>().resizePanel();
        }
    }
}
