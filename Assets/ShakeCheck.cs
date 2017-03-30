using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class ShakeCheck : MonoBehaviour {

	Hand thisHand;
	// Use this for initialization
	void Start () {
		thisHand = GetComponent<Hand> ();
		StartCoroutine ("Stabilizer");
	}

	Vector3 lastPos = Vector2.zero;
	public float shakeOffset;
	public float stableOffset;
	public float delay;
	public bool shakeCheck1;
	public bool shakeCheck2;
	public bool shakeCheck3;
	public bool shakeCheck4;

	public bool shake1;
	public bool shake2;
	// Update is called once per frame
	void FixedUpdate () {
		if (thisHand.currentAttachedObject != null) {
			if (thisHand.currentAttachedObject.name == "BlankController_Hand1") {
				shakeCheck1 = false;
				shakeCheck2 = false;
				shakeCheck3 = false;
				shakeCheck4 = false;
				return;
			}
		}

		Vector3 pos = transform.position;
		if (!shake1) {
			if (pos.x < lastPos.x + shakeOffset ||
				pos.y < lastPos.y + shakeOffset ||
				pos.z < lastPos.z + shakeOffset) {
				shake1 = true;
			} else {
				shakeCount = 0;
			}
		} else {
			if (pos.x - shakeOffset > lastPos.x ||
				pos.y - shakeOffset > lastPos.y ||
			    pos.z - shakeOffset > lastPos.z) {
				shake2 = true;
				shakeCount += 1;
			} else {
				shake2 = false;
				shakeCount = 0;
			}
		}

		if (shakeCount >= 6) {
			Debug.Log ("Shaked");
			shakeCount = 0;
		}

		lastPos = pos;

	}

	Vector3 startPos;
	public int shakeCount = 0;
	IEnumerator Stabilizer(){
		bool done = false;

		while (!done){
			if (thisHand.currentAttachedObject != null){
				if (thisHand.currentAttachedObject.name == "BlankController_Hand1") {
					shakeCheck1 = false;
					shakeCheck2 = false;
					shakeCheck3 = false;
					shakeCheck4 = false;
					yield return null;
				}
			}
			Vector3 pos = transform.position;
			if (startPos.x > pos.x + stableOffset ||
			    startPos.z > pos.z + stableOffset) {
				shakeCount = 0;
				shakeCheck1 = false;
				shakeCheck2 = false;
				shakeCheck3 = false;
				shakeCheck4 = false;
			} else if (startPos.x < pos.x - stableOffset ||
			          startPos.z < pos.z - stableOffset) {
				shakeCount = 0;
				shakeCheck1 = false;
				shakeCheck2 = false;
				shakeCheck3 = false;
				shakeCheck4 = false;
			}


			if (!shakeCheck1) {
				if (pos.x > lastPos.x + shakeOffset ||
				    pos.z > lastPos.z + shakeOffset) {
					shakeCheck1 = true;
					startPos = pos;
				} 
			} else {
				if (!shakeCheck2) {
					if (pos.x - shakeOffset < lastPos.x ||
						pos.z - shakeOffset < lastPos.z) {
						shakeCheck2 = true;
					} else {
						shakeCheck1 = false;
					}
				} else { 
					if (!shakeCheck3) {
						if (pos.x > lastPos.x + shakeOffset ||
							pos.z > lastPos.z + shakeOffset) {
							shakeCheck3 = true;
						} else {
							shakeCheck1 = false;
							shakeCheck2 = false;
						}
					} else {
						if (!shakeCheck4) {
							if (pos.x - shakeOffset < lastPos.x ||
								pos.z - shakeOffset < lastPos.z) {
								shakeCheck4 = true;
							} else {
								shakeCheck1 = false;
								shakeCheck2 = false;
								shakeCheck3 = false;
							}
						} else {
							shakeCount = 0;
							shakeCheck1 = false;
							shakeCheck2 = false;
							shakeCheck3 = false;
							shakeCheck4 = false;
							Debug.Log ("Shaken");
						}
					}
				}
			}
			lastPos = pos;

			yield return new WaitForSeconds(delay);
		}
	}
}
