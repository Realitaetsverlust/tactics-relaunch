using Characters.Equipment.Accessory;
using Characters.Equipment.Armor;
using Characters.Equipment.Weapons;

namespace Characters.Utils {
    public static class EquipmentFactory {
        public static BaseWeapon getWeapon(string name) {
            return WeaponFactory.WeaponList[name];
        }
        public static BaseArmor getArmor(string name) {
            return ArmorFactory.armorList[name];
        }
        public static BaseAccessory getAccessory(string name) {
            return AccessoryFactory.accessoryList[name];
        }
    }
}