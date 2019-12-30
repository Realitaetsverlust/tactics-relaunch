using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Dirt : BaseTile {
		public Dirt() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize Metal")) as Material;
		}
	}
}