using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GameObject enemy;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
	public static int MaxScore = 0;
	public Text hsLabel;
	// Update is called once per frame
	void Update () {
	
	}
	public void StartGame(){
		Application.LoadLevel("TestLevel");
	}
	public void Instructions(){
		Application.LoadLevel("Instructions");
	}

	// Use this for initialization
	void Start () {
		if(MaxScore < Protag.score){
			MaxScore = Protag.score;

		}
		Protag.score = 0;
		hsLabel.text = "High Score: " + MaxScore;
		StartCoroutine (Spawn());
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
				g = item2;
				g.GetComponent<SpriteRenderer>().color = Color.red;
				break;
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
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
			yield return new WaitForSeconds (.1f);
			//Debug.Log ("no more ex");
		}
		
	}
}
