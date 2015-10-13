using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject enemy;
	public GameObject item1; //hp
	public GameObject item2; //ammo
	public GameObject item3; //score
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn());
		//Application.LoadLevel ("StartScreen");
	}

	IEnumerator Spawn()
	{
		int ran;
		GameObject g;

		while(true) {
			ran = Random.Range(0, 100);
			//Debug.Log (ran+"");
			switch(ran){
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
					g = item1;
					g.GetComponent<SpriteRenderer>().color = Color.blue;
					break;
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 24:
					g = item2;
					g.GetComponent<SpriteRenderer>().color = Color.red;
					break;
				case 25:
				case 26:
				case 27:
				case 28:
				case 29:
					g = item3;
					g.GetComponent<SpriteRenderer>().color = Color.white;
					break;
				default:
					g = enemy;
					//g.GetComponent<SpriteRenderer>().color = Color.green;
					break;
			}
			/*if(r == 0){
				enemy.GetComponent<SpriteRenderer>().color = Color.blue;
			}
			else{
				enemy.GetComponent<SpriteRenderer>().color = Color.white;
			}*/
			//Debug.Log ("Spawning");
			float x = gameObject.transform.position.x + Random.Range(-8, 8);
			float y = gameObject.transform.position.y;
			Vector2 v = new Vector2 (x, y);
			GameObject clone = (GameObject)Instantiate (g, v, Quaternion.identity);
			clone.SetActive (true);
			//Debug.Log (g.tag);
			yield return new WaitForSeconds (1f);
			//Debug.Log ("no more ex");
		}

	}
}
