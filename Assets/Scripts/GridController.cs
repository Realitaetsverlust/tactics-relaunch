using System;
using System.Collections.Generic;
using System.Linq;
using Elements;
using UnityEngine;
using Utils;

public class GridController : CombatController {
	private static GameObject _grid;
	private static Dictionary<String, GameObject> _gridElements;
	private static GameObject _activeTile;
	private static GameObject _previousTile;

	public void Awake() {
		GridController._grid = GameObject.Find("terrainParent");
		GridController._gridElements = new Dictionary<string, GameObject>();

		for(int index = 0; index < GridController._grid.transform.childCount; index++) {
			Transform child = GridController._grid.transform.GetChild(index);
			GridController._gridElements.Add(child.name, child.gameObject);
		}
	}
	
	private void Start() {
		HashSet<GameObject> tiles = Rangefinder.findAllTilesInRange(GridController.getElementById("7-8"), 6);
		foreach(GameObject tile in tiles) {
			tile.GetComponent<GridElement>().markAsWithinRange();
		}
	}

	public static void markNewTileAsActive(string id) {
		GridController._previousTile = GridController._activeTile;
		GridController._activeTile = GridController.getElementById(id);

		if(GridController._previousTile != null) {
			GridController._previousTile.GetComponent<GridElement>().unmarkAsActiveTile();
		}

		GridController._activeTile.GetComponent<GridElement>().markAsActiveTile();
	}

	public static GameObject getElementById(string id) {
		try {
			return GridController._gridElements[id];
		} catch(Exception e) {
			return null;
		}
	}
}