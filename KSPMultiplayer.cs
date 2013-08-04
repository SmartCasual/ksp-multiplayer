using System;
using UnityEngine;

namespace SC {
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	public class KSPMultiplayer : MonoBehaviour {
		private Vessel currVessel;
		private Vessel prevVessel;

		public void Update() {
			if (currVessel == null || FlightGlobals.ActiveVessel != currVessel) {
				prevVessel = currVessel;
				currVessel = FlightGlobals.ActiveVessel;

				Debug.Log("SCMP: "+currVessel.vesselName);
			}
		}
	}
}
