using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Elements {
    public class GridElement : MonoBehaviour {
        private GameObject _top;
        private GameObject _bottom;
        private GameObject _north;
        private GameObject _east;
        private GameObject _south;
        private GameObject _west;

        private GameObject _mark;
        private GameObject _northMark;
        private GameObject _eastMark;
        private GameObject _southMark;
        private GameObject _westMark;

        public void Awake() {
            this._top = this.transform.Find("top").gameObject;
            this._bottom = this.transform.Find("bottom").gameObject;
            this._north = this.transform.Find("north").gameObject;
            this._east = this.transform.Find("east").gameObject;
            this._south = this.transform.Find("south").gameObject;
            this._west = this.transform.Find("west").gameObject;

            this._mark = this.transform.Find("mark").gameObject;
            
            this._northMark = this.transform.Find("mark/northMark").gameObject;
            this._eastMark = this.transform.Find("mark/eastMark").gameObject;
            this._southMark = this.transform.Find("mark/southMark").gameObject;
            this._westMark = this.transform.Find("mark/westMark").gameObject;
        }

        /**
         * Marks the top element of a tile
         */
        public void markAsActiveTile() {
            this._mark.SetActive(true);
        }

        /**
         * Unmarks the top element of a tile
         */
        public void unmarkAsActiveTile() {
            this._mark.SetActive(false);
        }
        
        /**
         * Rangefinding method START
         */
        public static HashSet<GameObject> findAllTilesInRange(string tileId, int range) {
            return _findAllTilesInRangeWithObject(GridController.getElementById(tileId), range, new HashSet<GameObject>());
        }
	
        private static HashSet<GameObject> _findAllTilesInRangeWithObject(GameObject targetTile, int range, HashSet<GameObject> areaOfEffect) {
            //Break condition for recursive call
            if(range <= 0) {
                return new HashSet<GameObject>();
            }

            HashSet<GameObject> foundTiles = findAdjacentTiles(targetTile);

            foreach(GameObject foundTile in foundTiles) {
                areaOfEffect.Add(foundTile);
            }
		
            foreach(GameObject foundTile in foundTiles) {
                HashSet<GameObject> pizdec = _findAllTilesInRangeWithObject(foundTile, range - 1, areaOfEffect);

                if(pizdec.Any()) {
                    foreach(GameObject piz in pizdec) {
                        areaOfEffect.Add(piz);
                    }
                }
            }

            return areaOfEffect;
        }
        
        private static HashSet<GameObject> findAdjacentTiles(GameObject targetTile) {
            GameObject directionalTile;

            HashSet<GameObject> adjacentTileList = new HashSet<GameObject>();

            if((directionalTile = findNorthernTile(targetTile)) != null) {
                adjacentTileList.Add(directionalTile);
            }
            if((directionalTile = findEasternTile(targetTile)) != null) {
                adjacentTileList.Add(directionalTile);
            }
            if((directionalTile = findSouthernTile(targetTile)) != null) {
                adjacentTileList.Add(directionalTile);
            }
            if((directionalTile = findWesternTile(targetTile)) != null) {
                adjacentTileList.Add(directionalTile);
            }
		
            return adjacentTileList;
        }

        private static GameObject findNorthernTile(GameObject targetTile) {
            return findTileInDirection('e', targetTile);
        }	
	
        private static GameObject findEasternTile(GameObject targetTile) {
            return findTileInDirection('e', targetTile);
        }
	
        private static GameObject findSouthernTile(GameObject targetTile) {
            return findTileInDirection('s', targetTile);
        }	
	
        private static GameObject findWesternTile(GameObject targetTile) {
            return findTileInDirection('w', targetTile);
        }

        private static GameObject findTileInDirection(char direction, GameObject targetTile) {
            var tileCoords = targetTile.transform.name.Split('-');
		
            switch(direction) {
                case 'n':
                    tileCoords[1] = (Convert.ToInt32(tileCoords[1]) + 1).ToString();
                    break;
                case 'e':
                    tileCoords[0] = (Convert.ToInt32(tileCoords[0]) + 1).ToString();
                    break;
                case 's':
                    tileCoords[1] = (Convert.ToInt32(tileCoords[1]) - 1).ToString();
                    break;
                case 'w':
                    tileCoords[0] = (Convert.ToInt32(tileCoords[0]) - 1).ToString();
                    break;
            }
		
            GameObject tile = GridController.getElementById(string.Join("-", tileCoords));

            return tile;
        }
        
        /**
         * Rangefinding method END
         */
    }
}
