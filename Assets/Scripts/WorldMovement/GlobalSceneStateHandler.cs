using System;
using System.Collections;
using UnityEngine;

namespace WorldMovement {
	public class GlobalSceneStateHandler : MonoBehaviour {
		public GameObject playerObject;
		public PlayerMovementController pmc;
		public TimeHandler th;

		public void Start() {
			this.th = this.gameObject.GetComponent<TimeHandler>();
		}

		public void Update() {
			Debug.Log(this.th.daytimeFormatted);
		}
	}
}
