using UnityEngine;

namespace Characters.Abilities.Magical.Cleric {
	public class Rebirth : BaseAbility{
		public Rebirth() : base() {
			this.description = "Brings target back to life with 25% HP";
		}
		
		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			target.GetComponent<CombatCharacterController>().regenerateHp(this.baseDamage);
		}
	}
}