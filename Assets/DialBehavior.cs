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

		if (transform.localRotation.y > 0) {
            machine.fireRate = 1;
		} else if (transform.localRotation.y < 0) {
            machine.fireRate = 3;
		} else {
            machine.fireRate = 2;
		}
	}
}
