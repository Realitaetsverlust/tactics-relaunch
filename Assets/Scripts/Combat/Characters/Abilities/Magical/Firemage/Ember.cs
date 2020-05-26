using UnityEngine;

namespace Characters.Abilities.Magical.Firemage {
	public class Ember : BaseAbility {
		public Ember() : base() {
			this.baseDamage = 20;			
			this.description = "Deals small fire damage to a target";
			this.range = 4;
			this.damageType = 2;
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			this.defaultDamage(caster, target);
		}
	}
}