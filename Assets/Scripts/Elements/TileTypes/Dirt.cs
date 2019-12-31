using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Dirt : TileType {
		public Dirt() : base() {
			this.tileMaterial = this.getTerrainMaterial("Stylize Metal");
		}
	}
}