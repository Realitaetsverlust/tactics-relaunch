using System;
using UnityEngine;

namespace WorldMovement {
	public class TimeHandler : MonoBehaviour {
		public int daytimeHours;
		public int daytimeMinutes;
		public string daytimeFormatted { get; private set; }
		public float timeProgressionInterval;

		public void Start() {
			this.daytimeHours = 0;
			this.daytimeMinutes = 0;
			this.daytimeFormatted = "00:00";
			this.InvokeRepeating(nameof(this.progressTime), 3.0f, 3.0f);
			//this.InvokeRepeating(nameof(this.progressTime), this.timeProgressionInterval, this.timeProgressionInterval);
		}

		public void progressTime() {
			if(this.daytimeMinutes++ == 60) {
				this.daytimeMinutes = 0;
				this.daytimeHours++;
			}

			if(this.daytimeHours == 24) {
				this.daytimeHours = 0;
			}

			this.daytimeFormatted = this.formatTime();
		}

		public string formatTime() {
			return string.Concat(
				this.daytimeHours.ToString().Length == 1 ? String.Concat("0", this.daytimeHours) : this.daytimeHours.ToString(),
				":",
				this.daytimeMinutes.ToString().Length == 1 ? String.Concat("0", this.daytimeMinutes) : this.daytimeMinutes.ToString());
		}
	}
}