using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Cancel") || Input.GetButton ("Jump")) {
			Application.LoadLevel("StartScreen");
		}
	}
}
