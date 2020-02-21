using UnityEngine;

namespace Characters.Abilities.Magical.Firemage {
	public class Ember : BaseAbility {
		public Ember() : base() {
			this.description = "Deals small fire damage to a target";
			this.range = 4;
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}