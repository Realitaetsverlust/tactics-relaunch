using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Snow : TileType {
		public Snow() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Snow");
		}
	}
}