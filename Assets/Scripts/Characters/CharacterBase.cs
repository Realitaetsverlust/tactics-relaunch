using Elements;
using UnityEngine;

namespace Characters {
    public class CharacterBase : MonoBehaviour
    {
        public void setCharacterToTile(GameObject tile) {
            this.transform.position = tile.GetComponent<GridElement>().getCenterPositionForCharacter();
        }    
    }
}
