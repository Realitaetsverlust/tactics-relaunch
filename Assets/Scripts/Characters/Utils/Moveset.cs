using System.Collections;
using System.Collections.Generic;
using Characters.Abilities;

namespace Characters.Utils {
	public class Moveset {
		private Dictionary<string, Dictionary<string, BaseMove>> _movelist = new Dictionary<string, Dictionary<string, BaseMove>>();

		public Dictionary<string, Dictionary<string, BaseMove>> movelist => this._movelist;

		public void removeFromMovelist(BaseMove move) {
			this._movelist[move.job].Remove(move.name);

			if(this._movelist[move.job].Count == 0) {
				this._movelist.Remove(move.job);
			}

		}

		public void addToMovelist(BaseMove move) {
			if(!this._movelist.ContainsKey(move.job)) {
				this._movelist[move.job] = new Dictionary<string, BaseMove>();
			}
			
			this._movelist[move.job].Add(move.name, move);
		}
	}
}