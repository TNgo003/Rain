using UnityEngine;
using System.Collections;

public class ContaminateScript : MonoBehaviour {
	//private Color[] color = {Color.black, Color.blue, Color.red, Color.green, Color.white};
	// Use this for initialization
	private int infection;
	private bool contInfec;
	// Update is called once per frame
	void FixedUpdate () {
		if (!contInfec) {
			infection --;
		}
		if (infection < 50) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		} else if (infection < 200) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.cyan;
		} else if (infection < 400) {
			gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		} else {
			//Debug.Log(infection+"");
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.collider.CompareTag ("Enemy")) {
			contInfec = true;
		} 
	}
	void OnCollisionStay2D(Collision2D other) 
	{
		if (other.collider.CompareTag ("Enemy")) {
			if(infection < 450)
				infection ++;
		} 


	}
	void OnCollisionExit2D(Collision2D other) 
	{
		if (other.collider.CompareTag ("Enemy")) {
			contInfec = false;
		} 
	}
	void Start () {
		contInfec = false;
		infection = 0;
		//StartCoroutine (Infect());
	}
}
