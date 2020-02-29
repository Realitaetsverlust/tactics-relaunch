using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class BaseCommandPanelHandler : CharacterControlHandler {
        public GameObject moveButton;
        public BaseMoveButtonHandler moveButtonHandler;
        public GameObject actionButton;
        public BaseActionButtonHandler actionButtonHandler;
        public GameObject waitButton;
        public BaseActionButtonHandler waitButtonHandler;

        public void Start() {
            this.moveButton = GameObject.Find("MovementButton");
            this.moveButtonHandler = this.moveButton.GetComponent<BaseMoveButtonHandler>();
            this.actionButton = GameObject.Find("ActionButton");
            this.actionButtonHandler = this.actionButton.GetComponent<BaseActionButtonHandler>();
            this.waitButton = GameObject.Find("WaitButton");
            this.waitButtonHandler = this.waitButton.GetComponent<BaseActionButtonHandler>();
        }

        public void enableMove() {
            this._enableButton(this.moveButton.GetComponent<Button>());
        }

        public void disableMove() {
            this._disableButton(this.moveButton.GetComponent<Button>());
        }

        public void enableAction() {
            this._enableButton(this.actionButton.GetComponent<Button>());
        }

        public void disableAction() {
            this._disableButton(this.actionButton.GetComponent<Button>());
        }

        private void _disableButton(Button button) {
            button.GetComponent<Image>().color = Color.gray;
            button.enabled = false;
        }

        private void _enableButton(Button button) {
            button.GetComponent<Image>().color = Color.white;
            button.enabled = true;
        }
    }
}
