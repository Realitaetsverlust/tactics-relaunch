using UnityEngine;

namespace Characters.Abilities.Magical.Enhancer {
	public class Protect : BaseAbility {
		public Protect() : base() {
			this.description = "Enhances magical defense";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}