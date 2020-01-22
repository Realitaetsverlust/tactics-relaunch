using Characters.Equipment.Accessory;
using Characters.Equipment.Armor;
using Characters.Equipment.Weapons;

namespace Characters.Utils {
    public class Equipmentset {
        private BaseWeapon _mainHand;
        private BaseWeapon _offHand;
        
        //Armor
        private BaseArmor _helmet;
        private BaseArmor _chest;
        private BaseArmor _legs;
        private BaseArmor _boots;
        private BaseArmor _hands;
        
        //Accessories
        private BaseAccessory _necklace;
        private BaseAccessory _leftRing;
        private BaseAccessory _rightRing;
        private BaseAccessory _leftEarring;
        private BaseAccessory _rightEarring;
        private BaseAccessory _belt;
        private BaseAccessory _bracelet;
        
        public BaseWeapon mainHand {
            get => this._mainHand;
            set => this._mainHand = value;
        }

        public BaseWeapon offHand {
            get => this._offHand;
            set => this._offHand = value;
        }

        public BaseArmor helmet {
            get => this._helmet;
            set => this._helmet = value;
        }

        public BaseArmor chest {
            get => this._chest;
            set => this._chest = value;
        }

        public BaseArmor legs {
            get => this._legs;
            set => this._legs = value;
        }

        public BaseArmor boots {
            get => this._boots;
            set => this._boots = value;
        }

        public BaseArmor hands {
            get => this._hands;
            set => this._hands = value;
        }

        public BaseAccessory necklace {
            get => this._necklace;
            set => this._necklace = value;
        }

        public BaseAccessory leftRing {
            get => this._leftRing;
            set => this._leftRing = value;
        }

        public BaseAccessory rightRing {
            get => this._rightRing;
            set => this._rightRing = value;
        }

        public BaseAccessory leftEarring {
            get => this._leftEarring;
            set => this._leftEarring = value;
        }

        public BaseAccessory rightEarring {
            get => this._rightEarring;
            set => this._rightEarring = value;
        }

        public BaseAccessory belt {
            get => this._belt;
            set => this._belt = value;
        }

        public BaseAccessory bracelet {
            get => this._bracelet;
            set => this._bracelet = value;
        }
    }
}