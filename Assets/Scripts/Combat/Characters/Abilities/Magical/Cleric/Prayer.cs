using UnityEngine;

namespace Characters.Abilities.Magical.Cleric {
	public class Prayer : BaseAbility{
		public Prayer() : base() {
			this.description = "Heals target by a small amount";
		}
		
		public override void applyEffectsToTarget(GameObject caster, GameObject target) {
			target.GetComponent<CombatCharacterController>().regenerateHp(this.baseDamage);
		}
	}
}