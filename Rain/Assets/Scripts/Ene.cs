using UnityEngine;
using System.Collections;

public class Ene : MonoBehaviour {
	//private int speed = 10;
	//private Rigidbody2D body;
	private Vector2 direction;
	private int hp = 2;
	bool start = false;
	// Use this for initialization
	void Start () {
		//text = GetComponent<Text>();
		direction = new Vector2 (0,0);;
		//body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate(direction * Time.deltaTime);
		if (hp <= 0) {
			Destroy(gameObject);
			Protag.score++;
		}

	}

	void OnCollisionEnter2D(Collision2D other) 
	{

		if (other.collider.CompareTag ("Wall")) {
			direction *= -1;
		} 
		else if (other.collider.CompareTag ("Player") || other.collider.CompareTag("Enemy")) {
			direction *= -1;
			//other.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
		}
		else if (other.collider.CompareTag ("Floor")) {
			if(!start){
				direction = Vector2.right;
				start = true;
			}
		} 

		else if (other.collider.CompareTag ("Bullet")) {
			hp--;
		} 
	}
	void OnCollisionStay2D(Collision2D other) 
	{
		if (other.collider.CompareTag ("Player")) {
			direction *= -1;
		}

		else if (other.collider.CompareTag ("Wall")) {
			//other.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
			direction *= -1;
		} 
		else if (other.collider.CompareTag ("Floor")) {
			//other.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		} 
	}/*
	void OnCollisionExit2D(Collision2D other) 
	{
		if (other.collider.CompareTag ("Player")) {
			other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
		else if (other.collider.CompareTag ("Wall")) {
			other.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		} 
		else if (other.collider.CompareTag ("Floor")) {
			other.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		} 
	}*/
}
