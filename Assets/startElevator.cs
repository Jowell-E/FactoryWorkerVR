using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startElevator : MonoBehaviour {

	public ElevatorBehavior elevator;
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (GameController.Instance.started == false) {
				elevator.On = true;
				GameController.Instance.started = true;
			}
		}
	}
}
