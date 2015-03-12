using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Spawns so there is always the same amount of prefabs
public class CoinSpawner : MonoBehaviour {

	// The prefab we will spawn
	public CoinController prefab;
	// The number of prefabs we will have at all time
	public int prefabsCount = 1;

	// Delegates to notify the UI
	public delegate void OnSpawn();
	public event OnSpawn onSpawn;

	// Create the first coins so there is always the same amount on the screen
	void Start () {
		for (int i = 0; i < prefabsCount; i++){
			SpawnPrefab();
		}
	}

	// Helper function to spawn prefabs and subscribe
	public void SpawnPrefab (){
		// Spawn the coin
		CoinController newCoin = (CoinController)Instantiate(prefab, transform.position, transform.rotation);
		// Subscribe so the other class handles notification automatically
		newCoin.onDied += OnCoinDied;

		// Notify if any UI is listening
		if (onSpawn != null)
			onSpawn();
	}

	// Function that will be called automatically when the coin dies
	public void OnCoinDied (CoinController coinController){
		// We unsubscribe to avoid memory leaks
		coinController.onDied -= OnCoinDied;

		// Spawn a new coin
		SpawnPrefab();
	}
}
