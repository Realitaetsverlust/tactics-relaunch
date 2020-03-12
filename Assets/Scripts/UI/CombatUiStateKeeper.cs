using System.Runtime.CompilerServices;
using UnityEngine;

namespace UI {
    public static class CombatUiStateKeeper {
        public static int step;
        public static bool jumpBackEnabled = true;
        
        private static readonly GameObject BaseCommandPanel;
        private static readonly GameObject ActionSelectionPanel;
        private static readonly GameObject AbilitySelectionPanel;
        private static readonly GameObject CombatUiPanel;
        private static readonly GameObject OverviewButton;

        static CombatUiStateKeeper() {
            CombatUiStateKeeper.CombatUiPanel = GameObject.Find("CombatUI");
            CombatUiStateKeeper.BaseCommandPanel = GameObject.Find("BaseCommandPanel");
            CombatUiStateKeeper.ActionSelectionPanel = GameObject.Find("ActionCommandPanel");
            CombatUiStateKeeper.AbilitySelectionPanel = GameObject.Find("AbilityCommandPanel");
            CombatUiStateKeeper.OverviewButton = GameObject.Find("OverviewModeButton");
        }

        public static void displayCommandStep() {
            CombatUiStateKeeper.step = 1;
            CombatUiStateKeeper.showCombatUi();
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().alpha = 0;
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().alpha = 0;
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

            CombatUiStateKeeper.OverviewButton.GetComponent<CanvasGroup>().alpha = 1;
        }
        
        public static void displayActionSelectionStep() {
            CombatUiStateKeeper.step = 2;
            CombatUiStateKeeper.showCombatUi();
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().alpha = 0;
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            
            CombatUiStateKeeper.OverviewButton.GetComponent<CanvasGroup>().alpha = 0;
        }
        
        public static void displayAbilitySelectionStep() {
            CombatUiStateKeeper.step = 3;
            CombatUiStateKeeper.showCombatUi();
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.BaseCommandPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.ActionSelectionPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().alpha = 1;
            CombatUiStateKeeper.AbilitySelectionPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
            
            CombatUiStateKeeper.OverviewButton.GetComponent<CanvasGroup>().alpha = 0;
        }

        public static void hideCombatUi() {
            CombatUiStateKeeper.CombatUiPanel.GetComponent<CanvasGroup>().alpha = 0;
        }

        public static void showCombatUi() {
            CombatUiStateKeeper.CombatUiPanel.GetComponent<CanvasGroup>().alpha = 1;
        }
    }
}