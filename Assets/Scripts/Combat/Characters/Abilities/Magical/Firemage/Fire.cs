using UnityEngine;

namespace Characters.Abilities.Magical.Firemage {
	public class Fire : BaseAbility{
		public Fire() : base() {
			this.description = "Deals fire damage to a target";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}