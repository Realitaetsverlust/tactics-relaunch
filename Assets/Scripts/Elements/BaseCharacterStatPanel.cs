using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Elements {
    public class BaseCharacterStatPanel : MonoBehaviour {
        private static GameObject _baseCharacterStatPanel;
        private static Text _nameText;
        private static Text _levelText;
        private static Text _hpText;
        private static Text _mpText;
        private static Text _statusText;
        
        static BaseCharacterStatPanel() {
            BaseCharacterStatPanel._baseCharacterStatPanel = GameObject.Find("BaseCharacterStatPanel");
            BaseCharacterStatPanel._nameText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Name").GetComponent<Text>();
            BaseCharacterStatPanel._levelText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Level").GetComponent<Text>();
            BaseCharacterStatPanel._hpText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("HP").GetComponent<Text>();
            BaseCharacterStatPanel._mpText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("MP").GetComponent<Text>();
            BaseCharacterStatPanel._statusText = BaseCharacterStatPanel._baseCharacterStatPanel.transform.Find("Status").GetComponent<Text>();
        }

        public static void populateCharacterPanel() {
            BaseCharacterStatPanel._nameText.text = "Luyen";
            BaseCharacterStatPanel._levelText.text = "50";
            BaseCharacterStatPanel._hpText.text = "60/60";
            BaseCharacterStatPanel._mpText.text = "115/115";
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
