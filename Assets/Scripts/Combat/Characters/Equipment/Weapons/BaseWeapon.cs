namespace Characters.Equipment.Weapons {
    public abstract class BaseWeapon : BaseEquipment {
        public int damage;
        public int range;
        public int hitrate;
        public int critchance;
        public string damageType;

        public BaseWeapon() {
            this.damage = 1;
            this.range = 1;
            this.hitrate = 100;
            this.critchance = 0;
            this.damageType = "physical";
        }
    }
}