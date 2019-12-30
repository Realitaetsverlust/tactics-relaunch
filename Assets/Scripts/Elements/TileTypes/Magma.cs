using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Magma : TileType {
		public Magma() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize_Lava_diffuse")) as Material;
		}
	}
}