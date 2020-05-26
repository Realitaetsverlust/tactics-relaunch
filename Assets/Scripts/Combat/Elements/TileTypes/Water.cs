using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Water : TileType {
		public Water() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Water Diffuse");
		}
	}
}