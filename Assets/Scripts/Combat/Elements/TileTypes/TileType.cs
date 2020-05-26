using System;
using UnityEngine;

namespace Elements.TileTypes {
	public class TileType {
		public bool passable;
		public string terrainType;
		public int causedDamagePerTurn;
		public int causedHealingPerTurn;
		protected Material tileMaterial;
		protected readonly string fixMeMaterial = "Material/FixMeMaterial";
		
		protected readonly string terrainFilepath = "Material/Stylize Terrain Texture/Materials/";

		protected TileType() {
			this.causedDamagePerTurn = 0;
			this.causedHealingPerTurn = 0;
			this.passable = true;
		}

		protected Material getTerrainMaterial(string materialName, string customTerrainFilepath = null) {
			if(customTerrainFilepath != null) {
				return Resources.Load(String.Concat(customTerrainFilepath, materialName)) as Material;
			}

			Material sourceMaterial = Resources.Load(String.Concat(this.terrainFilepath, materialName)) as Material;
			sourceMaterial.mainTexture.wrapMode = TextureWrapMode.Repeat;
			
			return sourceMaterial;
		}

		public Material getTerrainMaterial() {
			if(this.tileMaterial == null) {
				return Resources.Load(this.fixMeMaterial) as Material;
			}
			
			return this.tileMaterial;
		}
	}
}