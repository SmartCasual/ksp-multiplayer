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

				if (prevVessel != null) {
					Debug.Log("SCMP: "+prevVessel.vesselName);
				}
				Debug.Log("SCMP: "+currVessel.vesselName);
				Debug.Log("SCMP: "+currVessel.gameObject);
				Debug.Log("SCMP: " + currVessel.transform);
				Debug.Log("SCMP: " + currVessel.transform.position);
				Debug.Log("SCMP: "+currVessel.gameObject.transform);
				Debug.Log("SCMP: "+currVessel.gameObject.transform.position);
			}
		}
	}
}
