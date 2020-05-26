using UnityEngine;

namespace Characters.Abilities.Magical.Enhancer {
	public class Fortify : BaseAbility{
		public Fortify() : base() {
			this.description = "Enhances physical defense";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}