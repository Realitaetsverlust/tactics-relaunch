using UnityEngine;

namespace Characters.Abilities.Magical.Cleric {
	public class Holy : BaseAbility{
		public Holy() : base() {
			this.description = "Attacks with the power of the heaven. Deals tremendous damage";
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			throw new System.NotImplementedException();
		}
	}
}