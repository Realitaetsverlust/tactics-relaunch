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
		public int init;
		private GameObject _baseCharacterStatPanel;
		private GameObject _currentTile;

		public void setCharacterToTile(GameObject tile) {
			tile.GetComponent<GridElement>().setCharacterToThisTile(this._currentTile, this.gameObject);
			this._currentTile = tile;
			this.transform.position = tile.GetComponent<GridElement>().getCenterPositionForCharacter();
		}

		public void fillBaseCharacterStatPanel() {
			BaseCharacterStatPanel.showCharacterPanelForCharacter(this.gameObject);
		}

		public GameObject getCurrentTileOfCharacter() {
			return this._currentTile;
		}
	}
}