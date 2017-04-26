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
	void FixedUpdate () {
		if (transform.localRotation.y > .5f) {
			if (transform.localRotation.y > .75f) {
				machine.fireRate = 1.5f;
			} else {
				machine.fireRate = 1;
			}
		} else if (transform.localRotation.y < .5f) {
			if (transform.localRotation.y < .25f) {
				machine.fireRate = 0;
				GameController.Instance.GetComponent<ButtonFunctions> ().StopShooting ();
			} else {
				machine.fireRate = 2f;
				GameController.Instance.GetComponent<ButtonFunctions> ().StartShooting ();
			}
		} else {
            machine.fireRate = 0;
		}
	}
		
}
