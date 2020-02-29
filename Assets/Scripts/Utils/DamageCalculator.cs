using System.Security.Cryptography.X509Certificates;
using Characters;
using Characters.Abilities;
using UnityEngine;

namespace Utils {
    public static class DamageCalculator {
        public static int calculateDamage(GameObject caster, GameObject target, BaseAbility ability) {
            int calculatedDamage;
            int casterPower;
            int targetResist;
            int abilityBasePower = ability.baseDamage;
            
            if(ability.damageType == 2) {
                casterPower = caster.GetComponent<CombatCharacterController>().magAtk;
                targetResist = target.GetComponent<CombatCharacterController>().magResist;
            }
            else {
                casterPower = caster.GetComponent<CombatCharacterController>().physAtk;
                targetResist = target.GetComponent<CombatCharacterController>().physResist;
            }
            
            if(targetResist <= 0) {
                targetResist = 1;
            }
            
            if(casterPower <= 0) {
                casterPower = 1;
            }

            calculatedDamage = (casterPower - targetResist/2) * abilityBasePower / 100;
            
            return calculatedDamage;
        }
    }
}