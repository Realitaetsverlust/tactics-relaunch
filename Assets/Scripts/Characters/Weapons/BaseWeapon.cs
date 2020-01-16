using System.Runtime.CompilerServices;
using Characters.Utils;
using UnityEngine;

namespace Characters.Weapons {
    public class BaseWeapon {
        public string name;
        public string description;
        
        //offensive
        public int damage;
        public int range;
        public int hitrate;
        public int critchance;
        public Element element;
        public int plusLevel;
        public string damageType;

        //defensive
        public int evasion;
        public int block;
        //public Effect effect;
        
        public int rarity;

        public string requirement;

        public BaseWeapon() {
            this.name = "WEAPON_NAME_MISSING";
            this.description = "WEAPON_DESCRIPTION_MISSING";
            
            this.damage = 1;
            this.range = 1;
            this.hitrate = 100;
            this.critchance = 0;
            this.element = new Element();
            this.plusLevel = 0;
            this.damageType = "physical";

            this.evasion = 0;
            this.block = 0;
            this.rarity = 0;

            this.requirement = "none";
        }
    }
}