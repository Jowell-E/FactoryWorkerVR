using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialBehavior : MonoBehaviour {

	ButtonFunctions machine;
	// Use this for initialization
	void Start () {
		machine = GameController.Instance.GetComponent<ButtonFunctions> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (transform.localRotation.y);
		if (transform.localRotation.y > 0) {
			if (transform.localRotation.y > .45f) {
				machine.fireRate = .5f;
			} else {
				machine.fireRate = 1;
			}
		} else if (transform.localRotation.y < 0) {
			if (transform.localRotation.y < -.45f) {
				machine.fireRate = 3;
			} else {
				machine.fireRate = 2;
			}
		} else {
            machine.fireRate = 2;
		}
	}
}
