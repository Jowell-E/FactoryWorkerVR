using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startElevator : MonoBehaviour {

	public ElevatorBehavior elevator;
	void OnTriggerEnter(Collider other){
		Debug.Log ("hit me");
		Debug.Log (other.name);
		if (other.tag == "Player") {
			if (GameController.Instance.started == false) {
				elevator.On = true;
				GameController.Instance.started = true;
			}
		}
	}
}
