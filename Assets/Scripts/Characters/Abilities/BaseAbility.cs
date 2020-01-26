using System;
using UnityEngine;

namespace Characters.Abilities {
	public abstract class BaseAbility {
		public int baseDamage;
		public int damageType; //1 = phys; 2 = mag; 3 = heal; 4 = statusheal; 5 = terraineffect
		public int range;
		public int mpCost;
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
			Type type = this.GetType();
			this.range = 1;
			this.job = type.Namespace.Substring(type.Namespace.LastIndexOf('.') + 1);
		}
	}
}