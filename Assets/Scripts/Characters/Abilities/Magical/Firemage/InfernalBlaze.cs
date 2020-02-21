using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Characters.Abilities.Magical.Firemage {
	public class InfernalBlaze : BaseAbility {
		public InfernalBlaze() : base() {
			this.baseDamage = 200;
			this.description = "Deals tremendous fire damage in a large area";
			this.range = 6;
			this.damageType = 2;
		}

		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			this.defaultDamage(caster, target);
		}
	}
}