using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Grass : TileType {
		public Grass() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize_Grass");
		}
	}
}