using System.Security.Cryptography.X509Certificates;
using Characters;
using Characters.Abilities;
using UnityEngine;

/*
 * Damage Calculation:
 * 1. Check if phys or mag - Pick corresponding power and resist
 * 2. Multiply ability power by caster power, divide by target resist
 * 3. Apply elemental bonusses
 */

namespace Utils {
    public static class DamageCalculator {
        public static int calculateDamage(GameObject caster, GameObject target, AbilityEffects abilityEffects) {
            int calculatedDamage;
            int casterPower;
            int targetResist;
            int abilityBasePower = abilityEffects.damage;
            
            if(abilityEffects.damageType == 2) {
                casterPower = caster.GetComponent<CombatCharacterController>().magAtk;
                targetResist = target.GetComponent<CombatCharacterController>().magResist;
            }
            else {
                casterPower = caster.GetComponent<CombatCharacterController>().physAtk;
                targetResist = target.GetComponent<CombatCharacterController>().physResist;
            }
            
            //caster.getStatModifiersForAtk();

            calculatedDamage = (abilityBasePower * casterPower / targetResist) / 100;
            
            return 1;
        }
    }
}