using UnityEngine;

namespace Characters.Abilities.Magical.Cleric {
	public class HeavensGrace : BaseAbility{
		public HeavensGrace() : base() {
			this.description = "Heals target by a tremendous amount";
		}
		
		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			target.GetComponent<CombatCharacterController>().regenerateHp(this.baseDamage);
		}
	}
}