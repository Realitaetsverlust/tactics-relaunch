using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Elements {
    public class GridElement : MonoBehaviour {
        private MeshRenderer _renderer;
        private float _height;
       
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
        private Material _movementIndicator;
        private Material _test;

        public void Awake() {
            this._renderer = this.GetComponent<MeshRenderer>();
            this._height = this.transform.localScale.y;
            
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

            this._indicator = this.transform.Find("indicator").gameObject;
            this._movementIndicator = Resources.Load("Material/WalkRangeMaterial") as Material;
            this._test = Resources.Load("Material/WalkRangeMaterial") as Material;
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

        public void markAsYellow() {
            this._indicator.GetComponent<Renderer>().material = this._test;
            this._indicator.SetActive(true);
        }

        public void markAsWithinRange() {
            this._indicator.GetComponent<Renderer>().material = this._movementIndicator;
            this._indicator.SetActive(true);
        }

        public void unmarkAsWithinRange() {
            this._indicator.SetActive(false);
        }

        public Vector3 getCenterPositionForCharacter() {
            Vector3 center = this._renderer.bounds.center;
            return new Vector3(center.x, this._height + 1.5f, center.z);
        }
    }
}
