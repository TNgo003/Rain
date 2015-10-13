using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.CompareTag ("Enemy") || other.collider.CompareTag ("Wall")|| other.collider.CompareTag ("Item")) {
			Destroy(gameObject);
		}
		//Debug.Log (other.gameObject.name);
	}
}