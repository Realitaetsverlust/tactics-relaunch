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
            this.enableButton(this.moveButton.GetComponent<Button>());
        }

        public void disableMove() {
            this.enableButton(this.moveButton.GetComponent<Button>());
        }

        public void enableAction() {
            this.enableButton(this.actionButton.GetComponent<Button>());
        }

        public void disableAction() {
            this.disableButton(this.actionButton.GetComponent<Button>());
        }

        public void disableButton(Button button) {
            button.GetComponent<Image>().color = Color.gray;
            button.enabled = false;
        }
		
        public void enableButton(Button button) {
            button.GetComponent<Image>().color = Color.white;
            button.enabled = true;
        }
    }
}
