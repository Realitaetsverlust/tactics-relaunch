using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class TileType {
		public bool passable;
		public string terrainType;
		public float causedDamagePerTurn;
		public Material tileMaterial;
		
		protected readonly string terrainFilepath = "Material/Stylize Terrain Texture/Materials/";

		protected TileType() {
			this.causedDamagePerTurn = 0;
			this.passable = true;
		}

		protected Material getTerrainMaterial(string materialName, string customTerrainFilepath = null) {
			if(customTerrainFilepath != null) {
				return Resources.Load(String.Concat(customTerrainFilepath, materialName)) as Material;
			}
			return Resources.Load(String.Concat(this.terrainFilepath, materialName)) as Material;
		}
	}
}