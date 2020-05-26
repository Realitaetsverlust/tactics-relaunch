using System;
using Characters;
using Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class CharacterStatPanelHandler : MonoBehaviour {
        private Text _nameText;
        private Text _levelText;
        private Text _hpText;
        private Text _mpText;
        private Text _statusText;
        private GameObject _currentCharacter;

        public void Start() {
            this.enabled = false;
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Static::HP").GetComponent<Text>().text = "HP:";
            GameObject.Find("Static::MP").GetComponent<Text>().text = "MP:";
            GameObject.Find("Static::Level").GetComponent<Text>().text = "Lv";
            this._nameText = this.gameObject.transform.Find("Name").GetComponent<Text>();
            this._levelText = this.gameObject.transform.Find("Level").GetComponent<Text>();
            this._hpText = this.gameObject.transform.Find("HP").GetComponent<Text>();
            this._mpText = this.gameObject.transform.Find("MP").GetComponent<Text>();
            this._statusText = this.gameObject.transform.Find("Status").GetComponent<Text>();
        }

        public void Update() {
            this._currentCharacter = GridController.getActiveTile().GetComponent<GridElement>().getCharacterOnThisTile();

            if(this._currentCharacter != null) {
                this.showCharacterStatPanel();
            }
            else {
                this.hideCharacterStatPanel();
            }
        }

        public void hideCharacterStatPanel() {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        }

        public void showCharacterStatPanel() {
            this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        }

        public void showCharacterPanelForCharacter() {
            this.populateCharacterPanel();
            this.showCharacterStatPanel();
        }

        private void populateCharacterPanel() {
            CombatCharacterController ccc = this._currentCharacter.GetComponent<CombatCharacterController>();
            this._nameText.text = ccc.charName;
            this._levelText.text = ccc.level.ToString();
            this._hpText.text = String.Concat(ccc.currentHp.ToString(), "/", ccc.maxHp.ToString());
            this._mpText.text = String.Concat(ccc.currentMp.ToString(), "/", ccc.maxMp.ToString());
            this._statusText.text = "";
        }
    }
}