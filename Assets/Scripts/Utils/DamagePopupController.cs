using UI;
using UnityEngine;

namespace Utils {
    public class DamagePopupController : MonoBehaviour {
        private static DamagePopupHandler _damageTextPrefab;
        private static GameObject _canvas;
        
        static DamagePopupController() {
            DamagePopupController._canvas = GameObject.Find("DamagePopup");
            DamagePopupController._damageTextPrefab = Resources.Load<DamagePopupHandler>("Prefabs/UI/PopupTextParent");
        }
        
        public static void createDamageText(int damageAmount, Transform location) {
            DamagePopupHandler instance = GameObject.Instantiate(DamagePopupController._damageTextPrefab);
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
            instance.transform.SetParent(DamagePopupController._canvas.transform, false);
            instance.transform.position = screenPosition;
            
            instance.setText(damageAmount.ToString());
        }
    }
}
