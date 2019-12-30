using UnityEngine;

namespace Elements.TileTypes {
	public class BaseTile {
		protected string terrainType;
		protected Material tileMaterial;
		protected float causedDamagePerTurn;
		protected readonly string terrainFilepath = "Resources/Material/Stylize Terrain Textures/Materials/";

		protected BaseTile() {
			this.causedDamagePerTurn = 0;
		}
	}
}