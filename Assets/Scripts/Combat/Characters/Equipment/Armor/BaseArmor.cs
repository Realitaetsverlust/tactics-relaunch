using Characters.Equipment.Weapons;

namespace Characters.Equipment.Armor {
    public class BaseArmor : BaseEquipment {
        public int bluntResist;
        public int cutResist;
        public int stabResist;
        public int magicResist;

        public int fireResist;
        public int waterResist;
        public int earthResist;
        public int airResist;
        public int holyResist;
        public int darkResist;

        public BaseArmor() : base() {
            
        }
    }
}