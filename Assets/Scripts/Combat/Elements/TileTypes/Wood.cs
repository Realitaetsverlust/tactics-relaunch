using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Wood : TileType {
		public Wood() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize_Wood_diffuse");
		}
	}
}