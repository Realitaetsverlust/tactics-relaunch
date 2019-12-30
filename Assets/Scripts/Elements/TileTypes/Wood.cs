using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Wood : BaseTile {
		public Wood() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize_Wood_diffuse")) as Material;
		}
	}
}