using UnityEngine;

namespace Characters.Abilities.Magical.Cleric {
	public class Devotion : BaseAbility {
		public Devotion() : base() {
			this.description = "Heals target by a good amount";
		}
		
		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			target.GetComponent<CombatCharacterController>().regenerateHp(this.baseDamage);
		}
	}
}