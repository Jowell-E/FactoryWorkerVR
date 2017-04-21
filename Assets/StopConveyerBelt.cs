using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopConveyerBelt : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GetComponentInParent<ConveyerBeltBehavior> ().moving = false;
		}
	}
}
