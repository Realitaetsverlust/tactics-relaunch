using System.Collections;
using Characters;
using Elements;
using UnityEngine;
using Utils;

namespace InputHandlers {
	public class UnitPlacementHandler : MonoBehaviour {
		public void placeUnits(GameObject[] characters) {
			this.StartCoroutine(this._startPlacementPhase(characters));
		}

		private IEnumerator _startPlacementPhase(GameObject[] characters) {
			CombatController.gamePhase = 1;

			foreach(var character in characters) {
				yield return StartCoroutine(this._placeCharacterBeforeCombat(character));
			}

			CombatController.gamePhase = 2;

			CombatController.characterPlacementDone = true;
			TurnOrder.setTurnOrderToIndex(0);
		}

		private IEnumerator _placeCharacterBeforeCombat(GameObject character) {
			while(Input.GetKeyDown(KeyCode.Mouse0) == false || 
				  GridController.getActiveTile() == null ||
				  GridController.getActiveTile().GetComponent<GridElement>().getCharacterOnThisTile() != null) {
				yield return null;
			}

			character.GetComponent<CombatCharacterController>().setCharacterToTile(GridController.getActiveTile());
			yield return new WaitForSeconds(0.1f);
		}
	}
}