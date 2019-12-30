using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Rock : TileType {
		public Rock() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Rock Diffuse");
		}
	}
}