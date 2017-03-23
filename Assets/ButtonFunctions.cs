using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour {

	public GameObject cube;
	public GameObject sphere;
	public int force;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShootObject(){
		GameObject obj = (GameObject)Instantiate (cube, pos, Quaternion.identity);
		obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 1, 1) * force;
	}
}
