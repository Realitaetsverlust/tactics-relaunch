using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Snow : TileType {
		public Snow() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize Snow")) as Material;
		}
	}
}