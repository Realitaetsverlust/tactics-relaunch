using System.Collections.Generic;
using System.Linq;
using Characters;
using UnityEngine;

namespace Utils {
    public static class TurnOrder {
        private static SortedDictionary<int, GameObject> _turnOrder;
        private static int _charactersInCombat;
        private static int _turn = 1;
        private static GameObject _activeCharacter;
        public static int turnCount;
        
        public static void buildCharacterList(GameObject[] characters) {
            TurnOrder._turnOrder = new SortedDictionary<int, GameObject>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            foreach(GameObject character in characters) {
                TurnOrder._turnOrder.Add(character.GetComponent<CombatCharacterController>().init, character);
            }

            TurnOrder._charactersInCombat = TurnOrder._turnOrder.Count;
            TurnOrder._activeCharacter = TurnOrder._turnOrder.ElementAt(0).Value;
        }

        public static GameObject getNextCharacter() {
            TurnOrder._turn += 1;
            TurnOrder.turnCount += 1;
            
            Debug.Log(TurnOrder._turn);
            Debug.Log(TurnOrder._charactersInCombat);

            if(TurnOrder._turn > TurnOrder._charactersInCombat) {
                TurnOrder._turn = 1;
            }
            
            return (TurnOrder._activeCharacter = TurnOrder._turnOrder.ElementAt(TurnOrder._turn - 1).Value);
        }

        public static GameObject getActiveCharacter() {
            return TurnOrder._activeCharacter;
        }
    }
}