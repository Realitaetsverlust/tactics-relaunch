﻿using System;
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
		public int regenHp;
		public int maxMp;
		public int currentMp;
		public int regenMp;
		public int init;
		public int maxAp;
		public int currentAp;
		public int regenAp;
		private GameObject _baseCharacterStatPanel;
		private GameObject _currentTile;

		public void turnStart() {
			this.calcAlteredStates();
			this.regenerateAp(this.regenAp);
			this.regenerateMp(this.regenMp);
			this.regenerateHp(this.regenHp);
		}

		public void calcAlteredStates() { }

		public void regenerateAp(int apGains) {
			this.currentAp += apGains;
			if(this.currentAp > this.maxAp) {
				this.currentAp = this.maxAp;
			}
		}

		public void regenerateMp(int mpGains) {
			this.currentMp += mpGains;
			if(this.currentMp > this.maxMp) {
				this.currentMp = this.maxMp;
			}
		}

		public void regenerateHp(int hpGains) {
			this.currentHp += hpGains;
			if(this.currentHp > this.maxHp) {
				this.currentHp = this.maxHp;
			}
		}

		public void initiateDeath() { }

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