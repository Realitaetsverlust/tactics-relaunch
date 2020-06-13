using UnityEngine;
using UnityEngine.UI;

namespace WorldMovement.UI {
    public class WorldMapUiController : MonoBehaviour {
        private CanvasGroup _cg;
        public Button journalButton;
        public Button teamButton;
        public Button itemButton;
        public Button areaControlButton;
        public Button baseButton;
        public Button systemButton;

        public Animator animator;
        private static readonly int FadeIn = Animator.StringToHash("fadeIn");
        private static readonly int FadeOut = Animator.StringToHash("fadeOut");

        public bool uiVisible = false;

        public void Awake() {
            this._cg = this.GetComponent<CanvasGroup>();
        }

        public void toggleUi() {
            this._cg.alpha = this.uiVisible ? 0 : 1;
            this.uiVisible = !this.uiVisible;
        }

        public void onJournalClick() {
            
        }

        public void onItemClick() {
            
        }

        public void onTeamClick() {
            
        }

        public void onAreaControlClick() {
            
        }

        public void onBaseClick() {
            
        }

        public void onSystemClick() {
            
        }
    }
}