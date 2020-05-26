using UnityEngine;

namespace Characters.Abilities.Magical.Firemage {
	public class Firestorm : BaseAbility {
		public Firestorm() : base() {
			this.description = "Deals huge fire damage in a small area";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}