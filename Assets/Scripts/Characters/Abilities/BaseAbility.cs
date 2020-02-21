using System;
using UnityEngine;

namespace Characters.Abilities {
	public abstract class BaseAbility {
		public int baseDamage;
		public int range;
		public int mpCost;
		public int damageType; // 1 = phys, 2 = mag
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
			Type type = this.GetType();
			this.job = type.Namespace.Substring(type.Namespace.LastIndexOf('.') + 1);
		}

		public abstract void applyEffectsToTarget(GameObject caster, GameObject target);
	}
}