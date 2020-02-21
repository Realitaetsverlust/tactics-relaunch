using UnityEngine;

namespace Characters.Abilities.Magical.Manipulator {
	public class Enrage : BaseAbility {
		public Enrage() {
			this.description = "Greatly enhances physical attack of target, but loses control";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}