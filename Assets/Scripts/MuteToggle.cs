using UnityEngine;
using System.Collections;

// Helper function to toggle the AudioListener when pressing any key
public class MuteToggle : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// Whenever any key or mouse in pressed
		if (Input.anyKeyDown){
			// We toggle the audiolistener
			AudioListener.pause = ! AudioListener.pause;
		}
	}
}
