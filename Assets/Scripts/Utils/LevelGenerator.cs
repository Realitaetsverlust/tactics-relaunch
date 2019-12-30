//Generates a tile based playing field
//Needs a generate.txt in the root folder of the project to work.
//Must contain numeric values representing the height, separated by "|" in order to work properly
//No error reporting or handling implemented
//Use at your own risk

using System;
using System.IO;
using Elements;
using Elements.TileTypes;
using UnityEngine;

namespace Utils {
	public class LevelGenerator : MonoBehaviour {

		private void Awake() {
			string[] fileContent;
			float positionX = 0;
			float positionZ = 0;
			int gridCounterHorizontal = 0;
			int gridCounterVertical = 0;
			GameObject gridElementPrefab = Resources.Load("Prefabs/terrainElement") as GameObject;

			if(GameObject.Find("terrainParent") != null) {
				Console.WriteLine("elevationParent already exists in scene - aborting.");
				return;
			}
		
			GameObject terrainParent = new GameObject("terrainParent");
			terrainParent.AddComponent<GridController>();
		
			try {
				fileContent = File.ReadAllLines("Assets/generate.txt");
			} catch(FileNotFoundException e) {
				Console.WriteLine(e);
				throw;
			}
		
			terrainParent.transform.position = new Vector3(0, 0, 0);
		
			foreach(var line in fileContent) {
				var heights = line.Split('|');
				gridCounterVertical += 1;
				
				foreach(var height in heights) {
					gridCounterHorizontal += 1;
					float elevationHeight = int.Parse(height);

					GameObject gridElement = GameObject.Instantiate(gridElementPrefab, terrainParent.transform, true);
					gridElement.GetComponent<GridElement>().setTileType(new Water());
					
					if(gridElement == null) {
						throw new Exception("terrainElement could not be loaded from Prefabs. Aborting.");
					}

					gridElement.transform.name = String.Concat(gridCounterVertical, "-", gridCounterHorizontal);
					gridElement.transform.position = new Vector3(positionX, 1f, positionZ);
					gridElement.transform.localScale = new Vector3(1f, elevationHeight, 1f);

					positionX += 1;
				}

				gridCounterHorizontal = 0;
			
				positionZ -= 1;
				positionX = 0;
			}
		}
	}
}