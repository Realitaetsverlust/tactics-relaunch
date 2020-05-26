using UnityEngine;

namespace Characters.Abilities.Magical.Enhancer {
	public class LightningMuscles : BaseAbility {
		public LightningMuscles() : base() {
			this.description = "Target dodges the next physical attack";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}