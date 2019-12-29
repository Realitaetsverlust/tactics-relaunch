using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CharacterController = Characters.CharacterController;

namespace Utils {
    public class TurnOrder {
        private static SortedDictionary<int, GameObject> _turnOrder;
        private static int _charactersInCombat;
        private static int _turn;
        private static int _turnCount;
        private static GameObject _activeCharacter;
        public static void buildCharacterList(GameObject[] characters) {
            TurnOrder._turnOrder = new SortedDictionary<int, GameObject>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            int charInit = 0;

            foreach(GameObject character in characters) {
                charInit = character.GetComponent<CharacterController>().init;
                TurnOrder._turnOrder.Add(charInit, character);
            }

            TurnOrder._charactersInCombat = TurnOrder._turnOrder.Count;
        }

        public static GameObject getNextCharacter() {
            TurnOrder._turn += 1;
            TurnOrder._turnCount += 1;

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