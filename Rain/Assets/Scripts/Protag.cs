using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Protag : MonoBehaviour {
	private int speed = 8;
	public Sprite left;
	public Sprite right;
	private bool jump = true;
	private bool fire = true;
	private Rigidbody2D body;
	public Text sLabel;
	public Text hLabel;
	public Text aLabel;
	private bool invinicible;
	public static int score = 0;
	private int hp = 20;
	private int ammo = 20;
	private int iframe = 0;
	//private float delay = 1f;
	public GameObject projectile;
	public int direction = 1;
	public GameObject clone;
	private float speedFactor = 12f;
	// Use this for initialization
	void Start () {
		//text = GetComponent<Text>();
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton ("Right")) {
			direction = 1;
			gameObject.GetComponent<SpriteRenderer>().sprite = right;
			gameObject.transform.Translate(Vector2.right*direction * speed * Time.deltaTime);
		}
		else if (Input.GetButton ("Left")) {
			direction = -1;
			gameObject.GetComponent<SpriteRenderer>().sprite = left;
			gameObject.transform.Translate(Vector2.right*direction * speed * Time.deltaTime);
		}
		if (jump && Input.GetButtonDown ("Up")) {
			body.AddForce(Vector2.up * 250 * Time.deltaTime, ForceMode2D.Impulse);
			jump = false;
			//sLabel.text = "Score: " + (++score);
			//hLabel.text = "HP: " + (++hp);
			//aLabel.text = "Ammo: " + (--ammo);
		}
		if (fire && Input.GetButtonDown ("Jump") && ammo > 0) {
			//body.AddForce(Vector2.up * 250 * Time.deltaTime, ForceMode2D.Impulse);
			ammo --;
			fire = false;
			//Debug.Log("Fire");
			Vector2 v = new Vector2(transform.position.x + direction, transform.position.y-.3f);
			StartCoroutine (Shoots (v, direction));

			//sLabel.text = "Score: " + (++score);
			//hLabel.text = "HP: " + (++hp);
			aLabel.text = "Ammo: " + (ammo);
		}
		if (clone == null) {
			fire = true;
			sLabel.text = "Score: " + (score);
		}
		if (iframe >= 30) {
			invinicible = false;
			iframe = 0;
		} else if(invinicible){
			iframe++;
		}


		if (hp <= 0) {
			Application.LoadLevel("GameOver");
		}
	}
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log (other.name);
		if (other.CompareTag ("Item")) {
			if(other.name.Contains("Ammo")){
				ammo +=12;
				aLabel.text = "Ammo: " + (ammo);
			}
			else if(other.name.Contains("HP")){
				hp +=5;
				hLabel.text = "HP: " + (hp);
			}
			else if(other.name.Contains("Score")){
				score += 10;
				sLabel.text = "Score: " + (score);
			}
			Destroy(other.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.collider.CompareTag("Floor")) {
			jump = true;
		}
		else if (other.collider.CompareTag ("Enemy")) {
			setHP (--hp);
		}
		/*else if (other.collider.CompareTag ("Item")) {
			ammo++;
			aLabel.text = "Ammo: " + (ammo);
			Destroy(other.gameObject);
		}*/


	}
	void OnCollisionStay2D(Collision2D other) 
	{
		if (other.collider.CompareTag ("Floor") 
			&& other.collider.GetComponent<SpriteRenderer> ().color == Color.green 
			&& !invinicible) {
			setHP (--hp);
			invinicible = true;
		}

		
	}

	public void setHP(int h){
		hp = h;
		hLabel.text = "HP: " + (hp);
	}
	
	public int getHP(){
		return hp;
	}

	IEnumerator Shoots(Vector2 v, int direction)
	{
		clone = (GameObject)Instantiate(projectile, v,Quaternion.identity);
		clone.SetActive(true);
		clone.GetComponent<Rigidbody2D>().velocity= Vector2.right*direction * speedFactor;
		yield return null;
		
	}
}
