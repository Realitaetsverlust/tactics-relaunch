using System.Net.Mime;
using UnityEngine.UI;
using UnityEngine;

namespace UI {
    public class DamagePopupHandler : MonoBehaviour {
        public Animator animator;
        private Text _damageText;

        public void OnEnable() {
            AnimatorClipInfo[] clipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
            Destroy(this.gameObject, clipInfo[0].clip.length);
            this._damageText = this.animator.GetComponent<Text>();
        }

        public void setText(string text) {
            this.animator.GetComponent<Text>().text = text;
        }
    }
}
