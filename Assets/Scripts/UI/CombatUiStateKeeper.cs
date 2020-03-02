using UnityEngine;

namespace UI {
    public static class CombatUiStateKeeper {
        public static int step;
        public static bool jumpBackEnabled = true;
        
        private static readonly GameObject BaseCommandPanel;
        private static readonly GameObject ActionSelectionPanel;
        private static readonly GameObject AbilitySelectionPanel;

        static CombatUiStateKeeper() {
            CombatUiStateKeeper.BaseCommandPanel = GameObject.Find("BaseCommandPanel").gameObject;
            CombatUiStateKeeper.ActionSelectionPanel = GameObject.Find("ActionCommandPanel").gameObject;
            CombatUiStateKeeper.AbilitySelectionPanel = GameObject.Find("AbilityCommandPanel").gameObject;
        }

        public static void displayCommandStep() {
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().alpha = 0;
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().alpha = 0;
        }
        
        public static void displayActionSelectionStep() {
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().alpha = 0;
        }
        
        public static void displayAbilitySelectionStep() {
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}