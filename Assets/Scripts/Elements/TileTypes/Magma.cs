using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Magma : TileType {
		public Magma() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize_Lava_diffuse");
		}
	}
}