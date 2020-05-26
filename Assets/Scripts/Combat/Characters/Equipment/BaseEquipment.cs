namespace Characters.Equipment {
    public abstract class BaseEquipment {
        public string name;
        public string description;
        
        public int baseLevel;
        public int plusLevel;

        public int evasion;
        public int block;

        public int hpModifier;
        public int mpModifier;
        public int strModifier;
        public int magModifier;
        public int hitModifier;
        public int physResistModifier;
        public int magResistModifier;
        public int luckModifier;

        public int movementModifier;
        public int jumpModifier;
        
        public int rarity;
        public string requirement;

        public BaseEquipment() {
            this.name = "EQUIPMENT_NAME_MISSING";
            this.description = "EQUIPMENT_DESCRIPTION_MISSING";
            
            this.plusLevel = 0;
            this.evasion = 0;
            this.block = 0;
            this.rarity = 0;

            this.requirement = "none";
        }
    }
}