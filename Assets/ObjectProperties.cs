using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour {

	public string color;
	public string obj;
	public AudioClip audioClip;
	public bool defective;

	// Use this for initialization
	void Start () {
		
	}

	public bool held;
	Vector3 lastPos = Vector2.zero;
	public bool shakeCheck1;
	public bool shakeCheck2;
	public bool shakeCheck3;
	public bool shakeCheck4;
	// Update is called once per frame
	void Update () {
		if (held){
			Vector3 pos = transform.position;

			if (!shakeCheck1) {
				if (pos.x > lastPos.x ||
				    pos.z > lastPos.z) {
					shakeCheck1 = true;
				}
			} else {
				if (!shakeCheck2) {
					if (pos.x < lastPos.x ||
					    pos.z < lastPos.z) {
						shakeCheck2 = true;
					} else {
						shakeCheck1 = false;
					}
				} else { 
					if (!shakeCheck3) {
						if (pos.x > lastPos.x ||
						    pos.z > lastPos.z) {
							shakeCheck3 = true;
						} else {
							shakeCheck1 = false;
							shakeCheck2 = false;
						}
					} else {
						if (!shakeCheck4) {
							if (pos.x < lastPos.x ||
							    pos.z < lastPos.z) {
								shakeCheck4 = true;
							} else {
								shakeCheck1 = false;
								shakeCheck2 = false;
								shakeCheck3 = false;
							}
						}
					}
				}
			}

			if (shakeCheck4) {
				Debug.Log ("Shaken");
				shakeCheck1 = false;
				shakeCheck2 = false;
				shakeCheck3 = false;
				shakeCheck4 = false;
			}

			lastPos = pos;
		}

	}
}
