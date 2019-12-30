using System;
using System.Collections.Generic;
using System.Linq;
using Elements.TileTypes;
using UnityEngine;

namespace Elements {
    public class GridElement : MonoBehaviour {
        private MeshRenderer _renderer;
        private float _height;

        private GameObject _cube;
       
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

        private GameObject _indicator;

        private GameObject _playerOnTile;

        private TileType _tileType;
        
        public void Awake() {
            this._renderer = this.GetComponent<MeshRenderer>();
            this._height = this.transform.localScale.y;
            
            this._cube = this.transform.Find("cube").gameObject;
            this._top = this.transform.Find("cube/top").gameObject;
            this._bottom = this.transform.Find("cube/bottom").gameObject;
            this._north = this.transform.Find("cube/north").gameObject;
            this._east = this.transform.Find("cube/east").gameObject;
            this._south = this.transform.Find("cube/south").gameObject;
            this._west = this.transform.Find("cube/west").gameObject;

            this._mark = this.transform.Find("mark").gameObject;
            this._northMark = this.transform.Find("mark/northMark").gameObject;
            this._eastMark = this.transform.Find("mark/eastMark").gameObject;
            this._southMark = this.transform.Find("mark/southMark").gameObject;
            this._westMark = this.transform.Find("mark/westMark").gameObject;

            this._indicator = this.transform.Find("indicator").gameObject;

            this._playerOnTile = null;
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

        public void setCharacterToThisTile(GameObject oldTile, GameObject player) {
            if(oldTile != null) {
                oldTile.GetComponent<GridElement>().emptyCharacterSlot();
            }
            this._playerOnTile = player;
        }

        public void emptyCharacterSlot() {
            this._playerOnTile = null;
        }

        public GameObject getCharacterOnThisTile() {
            return this._playerOnTile;
        }

        public Vector3 getCenterPositionForCharacter() {
            Vector3 center = this._renderer.bounds.center;
            return new Vector3(center.x, this._height + 1.5f, center.z);
        }

        public void displayIndicator(string typing) {
            this._indicator.SetActive(true);
        }

        public void hideIndicator() {
            this._indicator.SetActive(false);
        }

        public void setTileType(TileType tileType) {
            this._tileType = tileType;
            this.updateTile();
        }

        public void updateTile() {
            this._top.GetComponent<Renderer>().material = this._tileType.tileMaterial;
            this._bottom.GetComponent<Renderer>().material = this._tileType.tileMaterial;
            this._north.GetComponent<Renderer>().material = this._tileType.tileMaterial;
            this._south.GetComponent<Renderer>().material = this._tileType.tileMaterial;
            this._east.GetComponent<Renderer>().material = this._tileType.tileMaterial;
            this._west.GetComponent<Renderer>().material = this._tileType.tileMaterial;
        }
    }
}
