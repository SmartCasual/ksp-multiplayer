using System;
using UnityEngine;

namespace SC {
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	public class KSPMultiplayer : MonoBehaviour {
		private Vessel currVessel;
		private Vessel prevVessel;

		public void Awake() {
			RenderingManager.AddToPostDrawQueue (3, new Callback (drawGUI));
		}

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

		// Private methods
		protected Rect windowPos;
		private void drawGUI() {
			GUI.skin = HighLogic.Skin;
			windowPos = GUILayout.Window(1, windowPos, WindowGUI, "Server or client?", GUILayout.MinWidth(200));
			windowPos = new Rect(Screen.width / 2, Screen.height / 2, 10, 10);
		}

		private void WindowGUI(int windowID) {
			GUIStyle mySty = new GUIStyle(GUI.skin.button);
			mySty.normal.textColor = mySty.focused.textColor = Color.white;
			mySty.hover.textColor = mySty.active.textColor = Color.yellow;
			mySty.onNormal.textColor = mySty.onFocused.textColor = mySty.onHover.textColor = mySty.onActive.textColor = Color.green;
			mySty.padding = new RectOffset(8, 8, 8, 8);

			GUILayout.BeginVertical();
			if (GUILayout.Button("Server",mySty,GUILayout.ExpandWidth(true))) {
				Network.InitializeServer (100, 12345, true);
				RenderingManager.RemoveFromPostDrawQueue(3, new Callback(drawGUI));
			}
			if (GUILayout.Button("Client",mySty,GUILayout.ExpandWidth(true))) {
				Network.Connect ("10.0.0.11", 12345);
				RenderingManager.RemoveFromPostDrawQueue(3, new Callback(drawGUI));
			}
			GUILayout.EndVertical();
		}
	}
}
