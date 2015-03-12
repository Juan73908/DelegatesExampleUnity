using UnityEngine;
using System.Collections;

// Destroy self after a random time and notify
public class CoinController : MonoBehaviour {

	// Life variables
	public float minLifeTime = 1.0f;
	public float maxLifeTime = 2.0f;

	// Physics variables
	public Vector2 minForce;
	public Vector2 maxForce;

	// Delegates to notify
	public delegate void OnDied(CoinController coinController);
	public event OnDied onDied;
	
	// Called automatically thanks to MonoBehaviour
	void Start () {
		// Automatic destroy after random time
		Invoke ("Died", Random.Range(minLifeTime, maxLifeTime));

		Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();
		// Apply random force if possible
		if (myRigidbody != null){
			// Random force at the position of the coin
			Vector2 randomForce = new Vector2(Random.Range(minForce.x, maxForce.x),
			                                  Random.Range(minForce.y, maxForce.y));
			myRigidbody.AddForceAtPosition(randomForce, transform.position);
		}
	}

	// Called automatically when time is up thanks to Invoke
	void Died () {
		// Notify if anyone is listening
		if (onDied != null)
			onDied(this);

		// Destroy self
		Destroy(gameObject);
	}
}
