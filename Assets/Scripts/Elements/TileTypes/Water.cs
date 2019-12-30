using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Water : TileType {
		public Water() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize Water Diffuse")) as Material;
		}
	}
}