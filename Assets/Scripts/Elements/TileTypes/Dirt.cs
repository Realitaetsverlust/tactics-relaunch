using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class Dirt : TileType {
		public Dirt() : base() {
			this.tileMaterial = Resources.Load(String.Concat(this.terrainFilepath, "Stylize Metal")) as Material;
		}
	}
}