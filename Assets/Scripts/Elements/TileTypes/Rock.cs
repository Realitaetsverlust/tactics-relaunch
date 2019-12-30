using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Rock : BaseTile {
		public Rock() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize_Sand_diffuse")) as Material;
		}
	}
}