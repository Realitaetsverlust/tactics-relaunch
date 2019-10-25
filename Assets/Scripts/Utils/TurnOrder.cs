using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CharacterController = Characters.CharacterController;

namespace Utils {
    public class TurnOrder {
        private SortedDictionary<int, GameObject> _turnOrder;
        private List<int> _speeds;
        private int _charactersInCombat;
        private int _turn;

        public TurnOrder(GameObject[] characters) {
            this._turnOrder = new SortedDictionary<int, GameObject>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            this._speeds = new List<int>();
            int charInit = 0;

            foreach(GameObject character in characters) {
                charInit = character.GetComponent<CharacterController>().init;
                this._turnOrder.Add(charInit, character);
            }

            this._charactersInCombat = this._turnOrder.Count;
        }
        
        public GameObject getNextCharacter() {
            this._turn += 1;

            if(this._turn > this._charactersInCombat) {
                this._turn = 1;
            }

            return this._turnOrder.ElementAt(this._turn - 1).Value;
            
            
        }
    }
}