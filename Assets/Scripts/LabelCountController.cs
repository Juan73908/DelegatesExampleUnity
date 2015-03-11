using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Label that shows the amount of coins spawned
public class LabelCountController : MonoBehaviour {

	// The coin spawner that we will be counting
	public CoinSpawner coinSpawner;

	// Label that we are controlling
	public Text label;

	void Awake () {
		// If not assigned we find a random one
		if (coinSpawner == null)
			coinSpawner = GameObject.FindObjectOfType<CoinSpawner>();

		// If we have an spawner we subscribe
		if (coinSpawner != null) 
			// Subscribe for spawn events
			coinSpawner.onSpawn += IncreaseCount;

		// Get the label reference
		if (label == null)
			label = GetComponent<Text>();
	}

	void OnDestroy () {
		// We unsubscribe to avoid memory leaks
		coinSpawner.onSpawn -= IncreaseCount;
	}

	// Called automatically when a new coin is spawned
	public void IncreaseCount() {
		// Turn the string into a int, add and reconvert to string
		label.text = (int.Parse(label.text) + 1).ToString();
	}
}
