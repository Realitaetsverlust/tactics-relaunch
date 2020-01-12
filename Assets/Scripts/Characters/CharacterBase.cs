﻿using System;
using Elements;
using Elements.TileTypes;
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
		public int walkRange;
		private GameObject _baseCharacterStatPanel;
		private GameObject _currentTile;
		public bool moved;
		public bool tookAction;

		public void turnStart() {
			this.calcAlteredStates();
			this.calcTerrainStatus();
			this.regenerateMp(this.regenMp);
			this.regenerateHp(this.regenHp);
			this.moved = false;
			this.tookAction = false;
		}

		public void calcAlteredStates() {
			// stub lohl
		}

		public void calcTerrainStatus() {
			TileType tileType = this._currentTile.GetComponent<GridElement>().tileType;
			this.subtractHp(tileType.causedDamagePerTurn);
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

		public int damageCalculation(int damage) {
			// lots of complicated stuff here

			int causedDamage = 10;
			
			return causedDamage < 0 ? 0 : causedDamage;
		}

		public void subtractHp(int damage) {
			this.currentHp -= damage;
			if(this.currentHp < 0) {
				this.currentHp = 0;
				this.initiateDeath();
			}
		}

		public void initiateDeath() {
			// gesdorben wird ned. Wer stirbd fliegd
		}

		public void revive() {
			
		}

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