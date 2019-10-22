using System.Collections.Generic;
using UnityEngine;
using CharacterController = Characters.CharacterController;

namespace Utils {
    public class TurnOrder {
        private Dictionary<int, GameObject> _turnOrder;
        private List<int> _speeds;

        public TurnOrder(GameObject[] characters) {
            int charInit = 0;

            foreach(GameObject character in characters) {
                charInit = character.GetComponent<CharacterController>().init;
                this._speeds.Add(charInit);
                this._turnOrder.Add(charInit, character);
            }

            this._speeds.Sort(delegate(int i, int j) { return i.CompareTo(j); });
            
            Debug.Log(this._speeds);
        }
    }
}