using UnityEngine;

namespace Characters.Abilities.Magical.Watermage {
	public class Flashflood : BaseAbility{
		public Flashflood() : base() {
			this.description = "Deals huge water damage in a small area";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}