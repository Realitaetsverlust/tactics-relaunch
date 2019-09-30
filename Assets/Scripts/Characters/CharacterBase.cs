using System;
using Elements;
using UnityEditor;
using UnityEngine;

namespace Characters {
	public class CharacterBase : MonoBehaviour {
		public string charName;
		public int level;
		public int exp;
		public int maxHp;
		public int currentHp;
		public int maxMp;
		public int currentMp;
		private GameObject _baseCharacterStatPanel;
		

		public void setCharacterToTile(GameObject tile) {
			this.transform.position = tile.GetComponent<GridElement>().getCenterPositionForCharacter();
		}

		public void fillBaseCharacterStatPanel() {
			BaseCharacterStatPanel.populateCharacterPanel(this);
		}
	}
}