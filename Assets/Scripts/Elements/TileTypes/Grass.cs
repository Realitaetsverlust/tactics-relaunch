using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Grass : BaseTile {
		public Grass() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize_Grass")) as Material;
		}
	}
}