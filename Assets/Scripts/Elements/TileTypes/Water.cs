using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Water : BaseTile {
		public Water() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize_Water_diffuse")) as Material;
		}
	}
}