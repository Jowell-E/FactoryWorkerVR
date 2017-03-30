using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour {

	public GameObject cube;
	public GameObject sphere;
	public int force;
	public Vector3 pos;

	public float waveTime;
	public float fireRate;
	float timeLimit;
	// Use this for initialization
	void Start () {
		
	}

	public bool shooting = false;
	// Update is called once per frame
	void Update () {
		if (shooting) {
			timeLimit -= Time.deltaTime;

			if (timeLimit <= 0) {
				shooting = false;
				CancelInvoke ("ShootObject");
			}
		}


	}

	public void StartShooting(){
		if (!shooting) {
			InvokeRepeating ("ShootObject", 0f, fireRate);
			shooting = true;
			timeLimit = waveTime;
		}
	}

	public void ShootObject(){
		int rand = Random.Range (0, 2);
		if (rand == 0) {
			GameObject obj = (GameObject)Instantiate (cube, pos, Quaternion.identity);
			obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 1, 1) * force;
			obj.name = cube.name;
		} else {
			GameObject obj = (GameObject)Instantiate (sphere, pos, Quaternion.identity);
			obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 1, 1) * force;
			obj.name = sphere.name;
		}
	}
}
