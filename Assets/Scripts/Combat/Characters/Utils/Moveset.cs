using System.Collections;
using System.Collections.Generic;
using Characters.Abilities;

namespace Characters.Utils {
	public class Moveset {
		private Dictionary<string, Dictionary<string, BaseAbility>> _movelist = new Dictionary<string, Dictionary<string, BaseAbility>>();

		public Dictionary<string, Dictionary<string, BaseAbility>> movelist => this._movelist;

		public void removeFromMovelist(BaseAbility move) {
			this._movelist[move.job].Remove(move.name);

			if(this._movelist[move.job].Count == 0) {
				this._movelist.Remove(move.job);
			}

		}

		public void addToMovelist(BaseAbility move) {
			if(!this._movelist.ContainsKey(move.job)) {
				this._movelist[move.job] = new Dictionary<string, BaseAbility>();
			}
			
			this._movelist[move.job].Add(move.name, move);
		}
	}
}