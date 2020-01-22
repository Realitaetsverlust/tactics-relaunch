using Characters.Equipment.Accessory;
using Characters.Equipment.Armor;
using Characters.Equipment.Weapons;

namespace Characters.Utils {
    public class Equipmentset {
        //Weapons
        public BaseWeapon mainHand;
        public BaseWeapon offHand;
        
        //Armor
        public BaseArmor helmet;
        public BaseArmor chest;
        public BaseArmor legs;
        public BaseArmor boots;
        public BaseArmor hands;
        
        //Accessories
        public BaseAccessory necklace;
        public BaseAccessory leftRing;
        public BaseAccessory rightRing;
        public BaseAccessory leftEarring;
        public BaseAccessory rightEarring;
        public BaseAccessory belt;
        public BaseAccessory bracelet;
    }
}