using System.Collections.Generic;
using System.Linq;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using UnityEngine;
using UnityEngine.UI;
using Utils;

/*
 * Handles the second step
 */

namespace UI {
    public class ActionCommandPanelHandler : CharacterControlHandler
    {
        public void populatePanel() {
            Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;
			
            List<GameObject> children = (from Transform child in this.gameObject.transform select child.gameObject).ToList();
            children.ForEach(Object.Destroy);
            
            //for some reason, destroying the object does not set the childCount immediately. So I'm using DetachChildren which resets the childcount to 0.
            this.gameObject.transform.DetachChildren();

            foreach(KeyValuePair<string, Dictionary<string, BaseAbility>> jobSelection in moveset.movelist) {
                string menuJobTab = jobSelection.Key;

                GameObject button = GameObject.Instantiate(Resources.Load("Prefabs/UI/ActionSelectionButton") as GameObject, this.gameObject.transform);
                button.name = menuJobTab;
                button.GetComponentInChildren<Text>().text = menuJobTab;
            }
			
            this.gameObject.GetComponent<PanelManager>().resizePanel();
        }
    }
}
