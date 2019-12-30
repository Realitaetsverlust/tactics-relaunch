using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Elements;
using UnityEngine;

public class GridController : MonoBehaviour {
	private static GameObject _grid;
	private static Dictionary<String, GameObject> _gridElements;
	private static GameObject _activeTile;
	private static GameObject _previousTile;
	private GameObject _godObject;

	public void Start() {
		this._godObject = GameObject.Find("GodObject");
		GridController._grid = GameObject.Find("terrainParent");
		GridController._gridElements = new Dictionary<string, GameObject>();
		
		Debug.Log(GridController._grid.transform.childCount);

		for(int index = 0; index < GridController._grid.transform.childCount; index++) {
			Transform child = GridController._grid.transform.GetChild(index);
			GridController._gridElements.Add(child.name, child.gameObject);
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

	public static GameObject getActiveTile() {
		if(GridController._activeTile != null) {
			return GridController._activeTile;
		}

		return null;
	}

	public static GameObject getElementById(string id) {
		if(GridController._gridElements.ContainsKey(id)) {
			return GridController._gridElements[id];
		}

		return null;
	}
}