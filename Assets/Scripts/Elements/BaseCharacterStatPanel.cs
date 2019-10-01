﻿using System;
using System.Runtime.CompilerServices;
using Characters;
using UnityEngine;
using UnityEngine.UI;
using CharacterController = Characters.CharacterController;

namespace Elements {
    public class BaseCharacterStatPanel : MonoBehaviour {
        private static GameObject _baseCharacterStatPanel;
        private static Text _nameText;
        private static Text _levelText;
        private static Text _hpText;
        private static Text _mpText;
        private static Text _statusText;
        
        static BaseCharacterStatPanel() {
            BaseCharacterStatPanel._baseCharacterStatPanel = GameObject.Find("BaseCharactGameObjecterStatPanel");
            Debug.Log(BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Name"));
            BaseCharacterStatPanel._nameText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Name").GetComponent<Text>();
            BaseCharacterStatPanel._levelText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Level").GetComponent<Text>();
            BaseCharacterStatPanel._hpText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("HP").GetComponent<Text>();
            BaseCharacterStatPanel._mpText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("MP").GetComponent<Text>();
            BaseCharacterStatPanel._statusText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Status").GetComponent<Text>();
        }

        public static void showCharacterPanelForCharacter(GameObject character) {
            BaseCharacterStatPanel.populateCharacterPanel(character.GetComponent<CharacterController>());
            BaseCharacterStatPanel.showCharacterPanel();
        }

        private static void populateCharacterPanel(CharacterController character) {
            BaseCharacterStatPanel._nameText.text = character.charName;
            BaseCharacterStatPanel._levelText.text = character.level.ToString();
            BaseCharacterStatPanel._hpText.text = String.Concat(character.currentHp.ToString(), "/", character.maxHp.ToString());
            BaseCharacterStatPanel._mpText.text = String.Concat(character.currentMp.ToString(), "/", character.maxMp.ToString());
            BaseCharacterStatPanel._statusText.text = "";
        }
        
        public static void showCharacterPanel() {
            BaseCharacterStatPanel._baseCharacterStatPanel.SetActive(true);
        }
        
        public static void hideCharacterPanel() {
            BaseCharacterStatPanel._baseCharacterStatPanel.SetActive(false);
        }
    }
}
