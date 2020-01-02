using System.Collections.Generic;
using UnityEngine;

namespace Elements {
	public class Range {
		private readonly HashSet<GameObject> _range;
		private readonly string _typing;

		public Range(HashSet<GameObject> range, string typing) {
			this._range = range;
			this._typing = typing;
		}

		public int getRangeElementCount() {
			return this._range.Count;
		}
		
		public void colorRange() {
			foreach(GameObject tile in this._range) {
				tile.GetComponent<GridElement>().displayIndicator(this._typing);
			}
		}
		
		public void hideRange() {
			foreach(GameObject tile in this._range) {
				tile.GetComponent<GridElement>().hideIndicator();
			}        
		}

		public bool isTileWithinRange(GameObject tile) {
			return this._range.Contains(tile);
		}
	}
}