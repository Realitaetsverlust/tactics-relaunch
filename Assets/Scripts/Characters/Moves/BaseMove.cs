using System;

namespace Characters.Moves {
	public abstract class BaseMove {
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

		protected BaseMove() {
			Type type = this.GetType(); 
			this.job = type.Namespace.Substring(type.Namespace.LastIndexOf('.') + 1);
		}
	}
}