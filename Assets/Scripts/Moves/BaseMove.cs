using System.Runtime.CompilerServices;

namespace Moves {
	public abstract class BaseMove {
		protected int baseDamage;
		protected int damageType; //1 = phys; 2 = mag; 3 = heal; 4 = statusheal; 5 = terraineffect
		protected int range;
		protected int mpCost;
		protected string name;
		protected string description;

		public BaseMove() {
			this.setName();
		}

		protected void setName() {
			foreach(char character in this.GetType().Name.ToCharArray()) {
				
			} 
		}
	}
}