/*using System.Collections.Generic;
using System.Linq;
using Characters;
using Characters.Abilities;
using Characters.Utils;
using Elements;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace InputHandlers {
	public class ActionInputHandler : MonoBehaviour {
		private GameObject _parentPanel;
		private Button _button;
		public bool isActionTargetSelectionPhase;
		private CombatUiHandler _combatUiHandler;
		
		public void Start() {
			this._parentPanel = GameObject.Find("BaseActionCommandPanel");
			this._button = GameObject.Find("ActionButton").GetComponent<Button>();
			this._combatUiHandler = GameObject.Find("CombatUI").GetComponent<CombatUiHandler>();
		}

		public void setCurrentRangeObject(Range rangeObject) {
			this.isActionTargetSelectionPhase = true;
		}

		public void onClick() {
			this._combatUiHandler.step = 2;
			this.populateActionInput();
		}
		
		public void populateActionInput() {
			Moveset moveset = TurnOrder.getActiveCharacter().GetComponent<CombatCharacterController>().moveset;
			
			List<GameObject> children = (from Transform child in this.gameObject.transform select child.gameObject).ToList();
			children.ForEach(Object.Destroy);
            
			//for some reason, destroying the object does not set the childCount immediately. So I'm using DetachChildren which resets the childcount to 0.
			this.gameObject.transform.DetachChildren();

			foreach(KeyValuePair<string, Dictionary<string, BaseAbility>> jobSelection in moveset.movelist) {
				string menuJobTab = jobSelection.Key;

				GameObject button = GameObject.Instantiate(Resources.Load("Prefabs/UI/ActionClassSelectionButton") as GameObject, this._parentPanel.transform);
				button.name = menuJobTab;
				button.GetComponentInChildren<Text>().text = menuJobTab;
			}
			
			this._parentPanel.GetComponent<PanelManager>().resizePanel();
		}

		public void disableButton() {
			this._button.GetComponent<Image>().color = Color.gray;
			this._button.enabled = false;
		}
		
		public void enableButton() {
			this._button.GetComponent<Image>().color = Color.white;
			this._button.enabled = true;
		}
	}
}*/