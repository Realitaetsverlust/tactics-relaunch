using System;
using UnityEngine;
using Utils;

namespace Characters.Abilities {
	public abstract class BaseAbility {
		public int baseDamage;
		public int range;
		public int mpCost;
		public int damageType; // 1 = phys, 2 = mag
		public int areaOfEffect;
		private string _name;

		public string name {
			get {
				if(this._name == null) {
					return this.GetType().Name;
				}
				
				return this._name;
			}
			
			set => this._name = value;
		}

		public string description;
		public readonly string job;

		protected BaseAbility() {
			this.range = 1;
			this.areaOfEffect = 1;
			Type type = this.GetType();
			this.job = type.Namespace.Substring(type.Namespace.LastIndexOf('.') + 1);
		}

		public abstract void applyEffectsToTarget(GameObject caster, GameObject target);

		public void defaultDamage(GameObject caster, GameObject target) {
			int calculatedDamage = DamageCalculator.calculateDamage(caster, target, this);
			target.GetComponent<CombatCharacterController>().subtractHp(calculatedDamage);
		}

		public void defaultHeal() {
			
		}
	}
}