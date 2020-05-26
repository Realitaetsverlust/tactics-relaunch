using System.Collections.Generic;
using UnityEngine;

namespace Elements {
	public class PanelManager : MonoBehaviour {
		private List<GameObject> _buttonsInPanel;
		private Vector3 _positionOfActionButton;
		
		public void Start() {
			this._positionOfActionButton = GameObject.Find("ActionButton").GetComponent<RectTransform>().position;
		}
	
		public void resizePanel(int buttonHeight = 50, int padding = 10) {
			this._buttonsInPanel = new List<GameObject>();
			
			for(int index = 0; index < this.transform.childCount; index++) {
				Transform child = this.transform.GetChild(index);
				this._buttonsInPanel.Add(child.gameObject);
			}

			float calculatedPanelHeight = (buttonHeight + padding) * this._buttonsInPanel.Count;
			
			RectTransform rectTransform = this.GetComponent<RectTransform>();
			
			rectTransform.sizeDelta = new Vector2(300f, calculatedPanelHeight);
			rectTransform.position = new Vector3(rectTransform.position.x, this._positionOfActionButton.y, 0);
			this.showPanel();
		}

		public void hidePanel() {
			this.GetComponent<CanvasGroup>().alpha = 0;
		}

		public void showPanel() {
			this.GetComponent<CanvasGroup>().alpha = 1;
		}
	}
}
