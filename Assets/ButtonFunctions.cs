using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

	public GameObject cube;
	public GameObject sphere;
	public float minForce;
	public float maxForce;
	public Vector3 pos;

	public float waveTime;
	public float fireRate;
	float timeLimit;
	// Use this for initialization
	void Start () {
		
	}

	public Text waveTimer;
	public bool shooting = false;
	// Update is called once per frame
	void Update () {
		if (shooting) {
			timeLimit -= Time.deltaTime;

			float minutes = Mathf.Floor (timeLimit / 60f);
			float seconds = (timeLimit % 60);

			waveTimer.text = string.Format ("{0:0}:{1:00}", minutes, seconds);

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
		} else {
			shooting = false;
			CancelInvoke ("ShootObject");
			waveTime = timeLimit;
		}
	}

	public void ShootObject(){
		int rand = Random.Range (0, GameController.Instance.objectToSort.Count);
		GameObject obj = (GameObject)Instantiate (GameController.Instance.objectToSort[rand], pos, Quaternion.identity);
		float force = Random.Range (minForce, maxForce);
		obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 1, 1) * force;
		obj.name = GameController.Instance.objectToSort[rand].name;
	}
}
